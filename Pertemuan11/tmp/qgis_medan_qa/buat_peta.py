# -*- coding: utf-8 -*-
import csv
import json
import shutil
import sys
import warnings
from collections import Counter
from pathlib import Path

from qgis.PyQt.QtCore import Qt, QVariant, QUrl, QUrlQuery
from qgis.PyQt.QtGui import QColor, QFont, QFontDatabase, QFontMetricsF
from qgis.core import *

HERE = Path(__file__).resolve().parent
WORK = HERE.parent.parent
OUT = WORK / 'Peta_Banjir_Genangan_Medan'
SOURCE = Path(r'E:\Praktikum Sistem Informasi Geografi\Pertemuan_11\data\Pertemuan 5')
DATA = OUT / 'Data'
REF = DATA / 'Batas_RBI'
STEM = 'Peta_Banjir_Genangan_Medan'
LAYOUT = 'Sebaran dan jumlah titik • Kota Medan'
PAPER = '#FFFFFF'
INK = '#163733'
SUB = '#46625E'
TEAL = '#14675F'
LINE = '#C7D5D1'
CANVAS = '#F6F8F6'
ANCHOR = '#244B49'
DOT = '#BF4E20'
OUTSIDE = '#613563'
COLORS = ['#F5F2E8', '#D8EBE4', '#9DCFC2', '#60AD9E', '#267E73']

def font(size, bold=False, semibold=False):
    face = QFont('Segoe UI')
    face.setPointSizeF(size)
    face.setWeight(QFont.Bold if bold else (QFont.DemiBold if semibold else QFont.Normal))
    return face

def text_format(size, color=INK, bold=False, semibold=False):
    fmt = QgsTextFormat()
    fmt.setFont(font(size, bold, semibold))
    fmt.setSize(size)
    fmt.setColor(QColor(color))
    return fmt

def fill(color, line=LINE, width=0.16):
    return QgsFillSymbol.createSimple({'color': color, 'outline_color': line,
                                      'outline_width': str(width), 'joinstyle':'round',
                                      'outline_style':'solid' if width else 'no'})

def line_symbol(color, width, style='solid'):
    return QgsLineSymbol.createSimple({'line_color': color,'line_width':str(width),
                                      'line_style':style,'capstyle':'round','joinstyle':'round'})

def point_symbol(shape, size, color, stroke, width):
    return QgsMarkerSymbol.createSimple({'name':shape, 'size':str(size),'color':color,
                                         'outline_color':stroke,'outline_width':str(width),
                                         'outline_style':'solid','joinstyle':'round'})

def mem_layer(kind, name, specs, crs):
    layer = QgsVectorLayer(kind+'?crs='+crs.authid(), name, 'memory')
    assert layer.isValid(), name
    provider = layer.dataProvider()
    assert provider.addAttributes([QgsField(key, typ) for key, typ in specs])
    layer.updateFields()
    return layer

def save_layer(source, dest, name, driver='GPKG'):
    opts = QgsVectorFileWriter.SaveVectorOptions()
    opts.driverName, opts.fileEncoding = driver, 'UTF-8'
    opts.layerName = name
    if driver=='GPKG': opts.layerOptions=['SPATIAL_INDEX=YES']
    if driver=='GPKG' and dest.exists():
        opts.actionOnExistingFile = QgsVectorFileWriter.CreateOrOverwriteLayer
    res = QgsVectorFileWriter.writeAsVectorFormatV3(source, str(dest), project.transformContext(),opts)
    if res[0]!=QgsVectorFileWriter.NoError:
        raise RuntimeError(str(res))
    path = str(dest) + ('|layername='+name if driver=='GPKG' else '')
    layer = QgsVectorLayer(path, name, 'ogr')
    assert layer.isValid() and layer.featureCount()==source.featureCount(), path
    return layer

def transformed_geometry(geom, tr):
    result=QgsGeometry(geom)
    if result.transform(tr)!=0: raise ValueError('Gagal mengubah CRS')
    return result

def add_records(layer, records):
    ok, _ = layer.dataProvider().addFeatures(records)
    assert ok
    layer.updateExtents()

def layer_about(layer, title, description, aliases=()):
    layer.setName(title)
    md = layer.metadata()
    md.setTitle(title)
    md.setAbstract(description)
    layer.setMetadata(md)
    for key, alias in aliases:
        i = layer.fields().indexFromName(key)
        if i >= 0: layer.setFieldAlias(i,alias)
    layer.setDisplayExpression('"kec_nama"' if layer.fields().indexFromName('kec_nama')>=0 else '"lokasi_ref"')

def label_layer(layer, text_field, size, is_expr=False, fixed=None):
    pal=QgsPalLayerSettings()
    pal.fieldName=text_field
    pal.isExpression=is_expr
    pal.placement=Qgis.LabelPlacement.Horizontal
    pal.priority=7
    tf=text_format(size, INK, semibold=True)
    buffer=QgsTextBufferSettings(); buffer.setEnabled(True); buffer.setSize(0.48)
    buffer.setColor(QColor('#FFFFFF')); buffer.setOpacity(0.96)
    tf.setBuffer(buffer); pal.setFormat(tf)
    if fixed:
        props=QgsPropertyCollection()
        props.setProperty(QgsPalLayerSettings.PositionX,QgsProperty.fromField(fixed[0]))
        props.setProperty(QgsPalLayerSettings.PositionY,QgsProperty.fromField(fixed[1]))
        props.setProperty(QgsPalLayerSettings.Hali,QgsProperty.fromValue('Center'))
        props.setProperty(QgsPalLayerSettings.Vali,QgsProperty.fromValue('Half'))
        pal.setDataDefinedProperties(props)
    layer.setLabeling(QgsVectorLayerSimpleLabeling(pal))
    layer.setLabelsEnabled(True)

def map_marker_renderer(detail=False):
    data=[('Dalam batas','Titik banjir/genangan','circle',1.25 if not detail else 1.7,DOT,'#FFF9EB',0.18),
          ('Di luar batas','Titik di luar batas kota','diamond',2.1 if not detail else 2.45,OUTSIDE,'#FFFFFF',0.23)]
    return QgsCategorizedSymbolRenderer('status_geo',[QgsRendererCategory(k,point_symbol(s,sz,c,ol,w),label)
                                                     for k,label,s,sz,c,ol,w in data])

def geo_csv(filespec, name):
    uri=QUrl.fromLocalFile(str(filespec))
    q=QUrlQuery()
    for key,val in [('type','csv'),('detectTypes','yes'),('xField','longitude'),('yField','latitude'),
                    ('crs','EPSG:4326'),('decimalPoint','.'),('encoding','UTF-8'),('watchFile','no'),
                    ('spatialIndex','no'),('subsetIndex','no')]:
        q.addQueryItem(key,val)
    uri.setQuery(q)
    return QgsVectorLayer(uri.toString(),name,'delimitedtext')

def read_results():
    with (DATA/'banjir.csv').open(encoding='utf-8-sig',newline='') as stream:
        return list(csv.DictReader(stream))

def outputs():
    DATA.mkdir(parents=True,exist_ok=True)
    REF.mkdir(parents=True,exist_ok=True)
    shutil.copy2(SOURCE/'banjir.csv', DATA/'banjir.csv')
    for src in SOURCE.glob('ADMINISTRASIKECAMATAN_AR_50K.*'):
        shutil.copy2(src,REF/src.name)
    csv_layer=geo_csv(DATA/'banjir.csv','CSV koordinat latihan')
    bounds=QgsVectorLayer(str(REF/'ADMINISTRASIKECAMATAN_AR_50K.shp'),'Batas kecamatan RBI','ogr')
    assert csv_layer.isValid() and csv_layer.featureCount()==115
    assert bounds.isValid() and bounds.featureCount()==21
    original=read_results()
    lookup={int(f['id']):QgsGeometry(f.geometry()) for f in csv_layer.getFeatures()}
    reference=[(str(f['NAMOBJ']).title(),QgsGeometry(f.geometry())) for f in bounds.getFeatures()]
    # Reference geometry is queried in the geographic CRS of the source coordinates.
    count=Counter(); results=[]; discrepancies=0; outside=0
    pointfields=[('id_titik',QVariant.Int),('kec_csv',QVariant.String),('lokasi_ref',QVariant.String),
                 ('latitude',QVariant.Double),('longitude',QVariant.Double),('kejadian',QVariant.String),
                 ('kec_peta',QVariant.String),('status_geo',QVariant.String),('cek_nama',QVariant.String)]
    temppts=mem_layer('Point','Titik praktikum',pointfields,UTM)
    feats=[]
    for row in original:
        i=int(row['id'])
        geo=lookup[i]
        found=[n for n,g in reference if g.intersects(geo)]
        if len(found)>1: raise ValueError(f'ID {i} berada di lebih dari satu kecamatan')
        district=found[0] if found else None
        status='Dalam batas' if found else 'Di luar batas'
        audit=('Sesuai' if row['kecamatan'].casefold()==district.casefold() else 'Berbeda') if found else 'Di luar batas'
        if district: count[district]+=1
        if audit=='Berbeda': discrepancies+=1
        if not district: outside+=1
        ft=QgsFeature(temppts.fields())
        ft.setGeometry(transformed_geometry(geo,tr))
        ft.setAttributes([i,row['kecamatan'],row['lokasi_referensi'],float(row['latitude']),
                          float(row['longitude']),row['kejadian'],district,status,audit])
        feats.append(ft)
        results.append(dict(**row,kecamatan_spasial=district or '',status_batas=status,pemeriksaan_nama=audit))
    add_records(temppts,feats)
    with (DATA/'Titik_dan_kecamatan_spasial.csv').open('w',newline='',encoding='utf-8-sig') as f:
        writer=csv.DictWriter(f,fieldnames=list(results[0])); writer.writeheader(); writer.writerows(results)
    gpkg=DATA/'Banjir_Medan.gpkg'
    pts=save_layer(temppts,gpkg,'titik_banjir')
    # Cross-check via QGIS Processing's independent point-in-polygon calculation with unrounded input.
    ref2=mem_layer('MultiPolygon','Batas analisis',[('kec_nama',QVariant.String)],UTM)
    pfeatures=[]
    for district,g in reference:
        g=QgsGeometry(g); g.get().dropZValue(); g.get().dropMValue()
        geo=transformed_geometry(g,tr)
        if not geo.isMultipart(): geo.convertToMultiType()
        f=QgsFeature(ref2.fields()); f.setGeometry(geo); f.setAttributes([district]); pfeatures.append(f)
    add_records(ref2,pfeatures)
    pc=QgsProcessingContext(); pc.setProject(project)
    pc.setInvalidGeometryCheck(QgsFeatureRequest.GeometryNoCheck)
    actual=processing.run('native:countpointsinpolygon',{'POLYGONS':ref2,'POINTS':pts,
                          'FIELD':'jml_titik','OUTPUT':'memory:'},context=pc)['OUTPUT']
    tools_counts={str(f['kec_nama']):int(f['jml_titik']) for f in actual.getFeatures()}
    assert all(tools_counts[n]==count[n] for n,g in reference) and len(results)==sum(tools_counts.values())+outside
    districts=sorted(tools_counts)
    # Label anchor coordinates are cartographic placements. Source geometries and point locations stay unshifted.
    soft_positions={
       'Medan Helvetia':(458650,400160),'Medan Sunggal':(458650,395970),
       'Medan Barat':(462200,400800),'Medan Timur':(464800,400870),
       'Medan Perjuangan':(465430,398580),'Medan Tembung':(468570,399290),
       'Medan Petisah':(461500,396840),'Medan Baru':(460850,394730),
       'Medan Maimun':(464610,393320),'Medan Kota':(465350,395720),
       'Medan Area':(466780,396290),'Medan Denai':(469135,393960),
       'Medan Polonia':(463230,393620),'Medan Selayang':(458550,392680),
       'Medan Johor':(463520,389660),'Medan Labuhan':(465870,411200)}
    ks=mem_layer('MultiPolygon','Analisis kecamatan',
                 [('kode_peta',QVariant.String),('kec_nama',QVariant.String),('jml_titik',QVariant.Int),
                  ('label_x',QVariant.Double),('label_y',QVariant.Double)],UTM)
    saved=[]; recap=[]
    for f in actual.getFeatures():
        name=f['kec_nama']; code=f'{districts.index(name)+1:02}'; n=tools_counts[name]
        center=f.geometry().pointOnSurface().asPoint()
        x,y=soft_positions.get(name,(center.x(),center.y()))
        # Keep the number inside its district even where the optimal label anchor is close to a border.
        if not f.geometry().contains(QgsGeometry.fromPointXY(QgsPointXY(x,y))):
            x,y=center.x(),center.y()
        rec=QgsFeature(ks.fields()); rec.setGeometry(f.geometry())
        rec.setAttributes([code,name,n,x,y]); saved.append(rec)
        recap.append((code,name,n))
    add_records(ks,saved)
    polygons=save_layer(ks,gpkg,'rekap_kecamatan')
    recap.sort()
    with (DATA/'Jumlah_per_kecamatan.csv').open('w',newline='',encoding='utf-8-sig') as f:
        writer=csv.writer(f);writer.writerow(['kode_peta','kecamatan','jumlah_titik_spasial']);writer.writerows(recap)
    record=dict(n=sum(tools_counts.values()),out=outside,diff=discrepancies,total=len(results),
                represented=sum(n>0 for n in tools_counts.values()),recap=recap)
    assert sorted(int(row['id']) for row in results)==list(range(1,len(results)+1))
    return csv_layer,bounds,pts,polygons,record

def prepare_project(csv_lyr,base_layer,points,districts):
    project.setTitle('Sebaran dan jumlah titik banjir/genangan per kecamatan di Kota Medan')
    info=project.metadata();info.setTitle(project.title());info.setAuthor('Mahesa Penemuan Ali')
    info.setAbstract('Peta tematik dari 115 koordinat pada CSV latihan. Titik dibuat melalui QGIS, dan jumlah dihitung dengan Count points in polygon terhadap batas kecamatan RBI. Nama kecamatan sumber dipertahankan.');project.setMetadata(info)
    project.setFilePathStorage(Qgis.FilePathType.Relative)
    layer_about(points,'Titik banjir/genangan','Dibentuk dari longitude dan latitude banjir.csv, data latihan praktikum. Lokasi, label kecamatan sumber, hasil pemeriksaan spasial, dan posisi terhadap batas kota tersimpan sebagai atribut.',
                [('kec_csv','Kecamatan pada CSV'),('kec_peta','Kecamatan dari koordinat'),('status_geo','Posisi terhadap batas'),('cek_nama','Perbandingan nama'),('lokasi_ref','Lokasi referensi')])
    layer_about(districts,'Jumlah titik per kecamatan','Poligon referensi RBI skala 1:50.000, diproyeksikan ke UTM 47N. Kolom jml_titik berasal dari QGIS Count points in polygon. Nilai nol menandakan tidak ada titik data pada poligon.',[('kec_nama','Kecamatan'),('jml_titik','Jumlah titik di dalam poligon'),('kode_peta','Nomor pada peta')])
    ranges=[]
    for lo,hi,label,color in zip([0,0,4,8,16],[0,4,8,16,24],['0','1–4','5–8','9–16','17–24'],COLORS):
        ranges.append(QgsRendererRange(float(lo),float(hi),fill(color,'#567D76',0.19),label))
    districts.setRenderer(QgsGraduatedSymbolRenderer('jml_titik',ranges))
    label_layer(districts,'kode_peta',8.1,fixed=('label_x','label_y'))
    points.setRenderer(map_marker_renderer())
    detail_poly=districts.clone();detail_poly.setName('Nama kecamatan pada peta detail')
    label_layer(detail_poly,'replace("kec_nama", \'Medan \', \'\')',8.2,True)
    detail_pts=points.clone();detail_pts.setName('Titik pada peta detail')
    detail_pts.setRenderer(map_marker_renderer(True))
    root=project.layerTreeRoot()
    main_group=root.addGroup('Peta tematik')
    for lyr in (points,districts):
        project.addMapLayer(lyr,False); main_group.addLayer(lyr)
    extra=root.addGroup('Tampilan khusus peta detail')
    for lyr in (detail_pts,detail_poly):
        project.addMapLayer(lyr,False); node=extra.addLayer(lyr);node.setItemVisibilityChecked(False)
    extra.setExpanded(False)
    ref=root.addGroup('Sumber data')
    for lyr in (csv_lyr,base_layer):
        project.addMapLayer(lyr,False); node=ref.addLayer(lyr);node.setItemVisibilityChecked(False)
    ref.setExpanded(False)
    bb=QgsRectangle(districts.extent());bb.scale(1.10)
    project.viewSettings().setDefaultViewExtent(QgsReferencedRectangle(bb,UTM))
    project.setBackgroundColor(QColor(CANVAS))
    return detail_poly,detail_pts

def place(item,key,x,y,w,h):
    item.setId(key); layout.addLayoutItem(item)
    item.attemptMove(QgsLayoutPoint(x,y)); item.attemptResize(QgsLayoutSize(w,h))
    return item

def box(key,x,y,w,h,color,border=None,stroke=0.15):
    i=QgsLayoutItemShape(layout); i.setShapeType(QgsLayoutItemShape.Rectangle)
    i.setSymbol(fill(color,border or color,stroke if border else 0))
    return place(i,key,x,y,w,h)

def label(key,x,y,w,h,text,size=9,color=INK,bold=False,semibold=False,align=Qt.AlignLeft):
    i=QgsLayoutItemLabel(layout);i.setText(text);i.setMargin(0)
    i.setFont(font(size,bold,semibold));i.setFontColor(QColor(color))
    i.setHAlign(align);i.setVAlign(Qt.AlignVCenter)
    return place(i,key,x,y,w,h)

def stroke(key,x,y,w,color=LINE,height=0.24):
    return box(key,x,y,w,height,color)

def capsule(key,x,y,txt,background=INK,foreground=PAPER):
    box(key+' latar',x,y,7,5,background)
    return label(key,x,y-0.06,7,5,txt,8,foreground,bold=True,align=Qt.AlignCenter)

def make_map(key,rect,layers,center,scale):
    x,y,w,h=rect;item=QgsLayoutItemMap(layout)
    place(item,key,x,y,w,h);item.setCrs(UTM)
    item.setLayers(layers);item.setKeepLayerSet(True)
    item.setBackgroundEnabled(True);item.setBackgroundColor(QColor(CANVAS))
    item.setFrameEnabled(True);item.setFrameStrokeColor(QColor('#9FB6B0'));item.setFrameStrokeWidth(QgsLayoutMeasurement(.19))
    dx,dy=w*scale/2000,h*scale/2000
    item.zoomToExtent(QgsRectangle(center[0]-dx,center[1]-dy,center[0]+dx,center[1]+dy))
    item.setScale(scale);item.refresh()
    return item

def grid_for(item):
    G=QgsLayoutItemMapGrid
    g=G('Koordinat geografis',item);item.grids().addGrid(g)
    g.setEnabled(True);g.setCrs(WGS);g.setIntervalX(0.05);g.setIntervalY(0.05)
    g.setStyle(G.Cross);g.setCrossLength(.88);g.setLineSymbol(line_symbol('#9CAEA9',.10))
    g.setFrameStyle(G.InteriorTicks);g.setFrameWidth(.95);g.setFramePenSize(.13);g.setFramePenColor(QColor('#758E86'))
    g.setAnnotationEnabled(True);g.setAnnotationFormat(G.CustomFormat);g.setAnnotationPrecision(2)
    g.setAnnotationExpression("replace(format_number(@grid_number,2), '.', ',') || '°' || if(@grid_axis='x',' BT',' LU')")
    g.setAnnotationFont(font(6.9));g.setAnnotationFontColor(QColor(SUB))
    g.setAnnotationDisplay(G.LongitudeOnly,G.Bottom);g.setAnnotationDisplay(G.LatitudeOnly,G.Left)
    for side in (G.Right,G.Top):g.setAnnotationDisplay(G.HideAll,side)
    for side in (G.Bottom,G.Left):g.setAnnotationPosition(G.InsideMapFrame,side)
    g.setAnnotationFrameDistance(1.15);item.updateBoundingRect()

def scale_bar(key,x,y,map_item,numeric=False,seg=2):
    i=QgsLayoutItemScaleBar(layout);i.setId(key);layout.addLayoutItem(i)
    i.setStyle('Numeric' if numeric else 'Single Box')
    i.setLinkedMap(map_item)
    i.setUnits(Qgis.DistanceUnit.Kilometers)
    i.setUnitsPerSegment(seg);i.setNumberOfSegments(2);i.setNumberOfSegmentsLeft(0)
    i.setUnitLabel('km');i.setTextFormat(text_format(8 if not numeric else 9.5,INK,semibold=numeric))
    i.setHeight(1.45);i.setLabelBarSpace(.65);i.setBoxContentSpace(.55)
    i.setFillColor(QColor(INK));i.setFillColor2(QColor(PAPER));i.setLineWidth(.16)
    i.setLineColor(QColor(INK))
    i.attemptMove(QgsLayoutPoint(x,y));i.update()
    return i

def legend_for(key,x,y,w,h,layer,linked_map):
    l=QgsLayoutItemLegend(layout); l.setId(key);layout.addLayoutItem(l)
    l.setTitle('');l.setLinkedMap(linked_map);l.setAutoUpdateModel(False)
    root=l.model().rootGroup();root.removeAllChildren(); node=root.addLayer(layer)
    QgsLegendRenderer.setNodeLegendStyle(node,Qgis.LegendComponent.Hidden)
    l.setStyleFont(Qgis.LegendComponent.SymbolLabel,font(8.8))
    l.setFontColor(QColor(INK));l.setSymbolWidth(7);l.setSymbolHeight(3.05)
    l.setBoxSpace(.15);l.setStyleMargin(Qgis.LegendComponent.Symbol,.26)
    l.setStyleMargin(Qgis.LegendComponent.SymbolLabel,QgsLegendStyle.Left,1.45)
    l.setResizeToContents(True);l.attemptMove(QgsLayoutPoint(x,y)); l.refresh();l.adjustBoxSize()
    return l

def make_layout(points,districts,detail_poly,detail_pts,stats):
    page=layout.pageCollection().pages()[0]
    page.setPageSize(QgsLayoutSize(420,297))
    layout.renderContext().setDpi(300)
    # Header, with compact geographic context and space left for the two map frames.
    box('Warna kepala',0,0,420,3.0,TEAL)
    label('Identitas praktikum',12,6,247,6,'SISTEM INFORMASI GEOGRAFI     /     PRAKTIKUM 11',8.2,TEAL,bold=True)
    label('Wilayah',278,6,130,6,'KOTA MEDAN  /  SUMATERA UTARA',8.2,SUB,semibold=True,align=Qt.AlignRight)
    label('Judul peta',12,12.4,398,16,'Sebaran dan jumlah titik banjir/genangan per kecamatan di Kota Medan',25.5,INK,bold=True)
    label('Subjudul',12,31,390,7,'Setiap titik mewakili satu koordinat dalam data latihan. Warna kecamatan menunjukkan jumlah titik di dalam batasnya.',10.8,SUB)
    stroke('Garis pembuka',12,42.3,396)
    main=make_map('Peta utama • Kota Medan',(12,55,150,190),[points,districts],(463500,402550),195000)
    layout.setReferenceMap(main)
    grid_for(main)
    detail=make_map('Detail A • Medan bagian tengah',(171,55,142,91),[detail_pts,detail_poly],(462570,396800),100000)
    ov=QgsLayoutItemMapOverview('Bingkai cakupan detail A',main)
    s=QgsFillSymbol.createSimple({'style':'no','outline_color':ANCHOR,'outline_width':'0.33','outline_style':'dash','joinstyle':'miter'})
    ov.setFrameSymbol(s);ov.setLinkedMap(detail);ov.setEnabled(True);main.overviews().addOverview(ov)
    header_y=46.2
    label('Judul peta utama',12,header_y,150,6.7,'Peta utama  /  Seluruh kecamatan',11.1,INK,semibold=True)
    label('Judul detail',171,header_y,142,6.7,'Detail A  /  Medan bagian tengah',11.1,INK,semibold=True)
    label('Judul rekap',322,header_y,86,6.7,'Jumlah per kecamatan',11.1,INK,semibold=True)
    # Native QGIS picture item referencing its bundled, relocatable north arrow.
    north=QgsLayoutItemPicture(layout);north.setSvgFillColor(QColor(INK));north.setSvgStrokeColor(QColor(INK))
    north.setPicturePath('D:/qgis/apps/qgis-ltr/svg/arrows/NorthArrow_11.svg')
    north.setLinkedMap(main);place(north,'Arah utara',24,65,6,8)
    label('Huruf utara',23.5,59.6,7.2,5.2,'U',8.0,INK,bold=True,align=Qt.AlignCenter)
    # Put the same detail key next to the frame it identifies.
    r=main.extent();d=detail.extent()
    ax=12+(d.xMinimum()-r.xMinimum())/r.width()*150; ay=55+(r.yMaximum()-d.yMaximum())/r.height()*190
    capsule('Penanda cakupan detail',ax,ay-5,'A',ANCHOR)
    label('Keterangan peta detail',171,147.4,108,5.2,'Bingkai putus-putus menandai cakupan Detail A.',8.0,SUB)
    scale_bar('Skala angka detail',284,147.1,detail,True)
    stroke('Garis legenda',171,155,142)
    label('Judul legenda area',171,157,70,6,'Jumlah titik per kecamatan',10.1,INK,semibold=True)
    label('Judul legenda titik',244,157,69,6,'Simbol lokasi',10.1,INK,semibold=True)
    legend_for('Legenda jumlah • terhubung ke poligon',171,165.8,55,27,districts,main)
    legend_for('Legenda titik • terhubung ke titik',244,165.8,67,15,points,main)
    label('Arti nilai nol',244,180.5,68.5,14.0,'Nilai 0 berarti tidak ada titik\ndalam data latihan pada kecamatan itu.',8.2,SUB)
    stroke('Garis ringkasan',171,197.5,142)
    label('Judul ringkasan',171,199.5,142,6.4,'Hasil pemeriksaan koordinat',10.8,INK,semibold=True)
    cards=[(171,stats['total'],'titik pada CSV'),(219.2,stats['n'],'di dalam kota'),(267.4,stats['out'],'di luar batas')]
    for ix,(x,n,title) in enumerate(cards):
        box('Ringkasan '+title,x,208.5,45.6,24.5,['#E5F1EC','#D4E9E3','#F0EBF2'][ix])
        label('Nilai '+title,x+3,209.3,39,13.2,str(n),20,INK if ix<2 else OUTSIDE,bold=True)
        label('Keterangan '+title,x+3,223,40,6.5,title,8.8,SUB,semibold=True)
    label('Catatan jumlah',171,235,142,10.3,
          f"{stats['represented']} dari 21 kecamatan memuat titik. Pada {stats['diff']} titik di dalam kota,\nnama kecamatan di CSV berbeda dari hasil spasial.",8.6,SUB)
    # Native scale bars stay linked to the main map and remain correct after editing the extent.
    label('Keterangan skala angka',12,249,33,6,'Skala peta utama',8.25,SUB,semibold=True)
    scale_bar('Skala angka dinamis',43,248.5,main,True)
    scale_bar('Skala grafis dinamis',79,247.9,main,False,2)
    label('Catatan penomoran',327,54.9,79,5.2,'Nomor mengikuti label pada peta utama.',7.9,SUB)
    # Compact table is sorted by name and uses unobtrusive bars proportional to the exact count.
    tabx,tabw=322,86
    box('Kepala tabel',tabx,62.1,tabw,7.6,INK)
    label('Kolom nomor',324.1,62.15,9,7.3,'No.',7.6,PAPER,semibold=True)
    label('Kolom kecamatan',333.8,62.15,48,7.3,'Kecamatan',7.6,PAPER,semibold=True)
    label('Kolom titik',394,62.15,11.4,7.3,'Titik',7.6,PAPER,semibold=True,align=Qt.AlignRight)
    y=70.3; rh=7.62; mx=max(n for _,_,n in stats['recap'])
    for ix,(code,fullname,n) in enumerate(stats['recap']):
        top=y+ix*rh
        if ix%2==0: box('Latar baris '+code,tabx,top,tabw,rh,'#F1F5F3')
        nm=fullname.removeprefix('Medan ')
        label('Nomor '+code,324.1,top,8.3,rh,code,8.15,SUB)
        label('Kecamatan '+code,333.8,top,41,rh,nm,9.3,INK,semibold=n==mx)
        if n:
            box('Batang '+code,374.2,top+rh/2-.67,16.5*n/mx,1.34,'#478E82' if n!=mx else '#276A61')
        label('Jumlah '+code,394,top,11.4,rh,str(n),9.3,INK,semibold=True,align=Qt.AlignRight)
    bottom=y+21*rh
    box('Footer tabel',tabx,bottom+.4,tabw,10,'#D8EBE4')
    label('Total label',324.1,bottom+.4,61,10,'Total dalam batas kota',9.1,INK,semibold=True)
    label('Total nilai',390,bottom+.4,15.4,10,str(stats['n']),12,INK,bold=True,align=Qt.AlignRight)
    label('Keterangan tabel',322,242.3,86,10,'Medan Helvetia memuat titik terbanyak\ndalam data latihan ini.',8.4,SUB)
    # Source, methodology and student identity are all print-layout text, editable on reopening.
    stroke('Garis keterangan bawah',12,260.4,396,TEAL,.5)
    label('Judul sumber',12,264,156,5.5,'SUMBER DATA',7.8,TEAL,bold=True)
    label('Isi sumber',12,270.1,150,16.4,'Koordinat  •  banjir.csv, data latihan praktikum Pertemuan 5.\nBatas  •  RBI Sumatera 1:50.000, administrasi kecamatan.\nMetadata batas  •  Januari 2017.',8.5,SUB)
    label('Judul metode',171,264,142,5.5,'METODE DAN SISTEM KOORDINAT',7.8,TEAL,bold=True)
    label('Isi metode',171,270.1,142,16.4,'Agregasi  •  Count points in polygon (QGIS 3.44).\nProyeksi  •  WGS 84 / UTM zona 47N (EPSG:32647).\nGrid geografis  •  WGS 84, interval 0,05°.',8.5,SUB)
    label('Judul pembuat',322,264,86,5.5,'IDENTITAS PEMBUAT',7.8,TEAL,bold=True)
    label('Nama pembuat',322,270.2,86,7,'Mahesa Penemuan Ali',12.1,INK,semibold=True)
    label('Identitas kelas',322,278,86,6,'NIM 241712064    /    KOM B1',8.8,SUB)
    layout.refresh()
    return main,detail

def run():
    global project,UTM,WGS,tr,layout
    profile=HERE/'profil';profile.mkdir(exist_ok=True)
    warnings.filterwarnings('ignore', category=DeprecationWarning)
    app=QgsApplication([],False,str(profile));app.setPrefixPath('D:/qgis/apps/qgis-ltr',True);app.initQgis()
    for face in ('segoeui.ttf','segoeuib.ttf','seguisb.ttf'):
        path=Path('C:/Windows/Fonts')/face
        if path.is_file():
            aid=QFontDatabase.addApplicationFont(str(path))
            print('Print font:',face,aid,QFontDatabase.applicationFontFamilies(aid),flush=True)
    assert QFontMetricsF(font(10)).inFont('M'), 'Print font not loaded'
    sys.path.insert(0,'D:/qgis/apps/qgis-ltr/python/plugins')
    global processing
    import processing
    from processing.core.Processing import Processing
    Processing.initialize()
    project=QgsProject.instance();project.clear()
    UTM=QgsCoordinateReferenceSystem('EPSG:32647');WGS=QgsCoordinateReferenceSystem('EPSG:4326')
    project.setCrs(UTM);project.setEllipsoid('WGS84')
    tr=QgsCoordinateTransform(WGS,UTM,project)
    OUT.mkdir(exist_ok=True); project_path=OUT/(STEM+'.qgz');project.setFileName(str(project_path))
    csv_lyr,bounds,points,districts,stats=outputs()
    detail_poly,detail_pts=prepare_project(csv_lyr,bounds,points,districts)
    layout=QgsPrintLayout(project);layout.initializeDefaults();layout.setName(LAYOUT)
    main,detail=make_layout(points,districts,detail_poly,detail_pts,stats)
    assert project.layoutManager().addLayout(layout)
    assert project.write(), project.error()
    # Export from native QGIS layout renderer. Low-resolution export is confined to the working directory.
    exporter=QgsLayoutExporter(layout)
    cfg=QgsLayoutExporter.ImageExportSettings()
    cfg.dpi=150 if '--preview' in sys.argv else 300
    cfg.generateWorldFile=False
    cfg.exportMetadata=False
    imgpath=(HERE/'pratinjau.png') if '--preview' in sys.argv else (OUT/(STEM+'.png'))
    status=exporter.exportToImage(str(imgpath),cfg)
    if status!=QgsLayoutExporter.Success: raise RuntimeError(f'Export {status}: {exporter.errorMessage()}')
    print('QGIS',Qgis.QGIS_VERSION,'export',imgpath,'scales',round(main.scale()),round(detail.scale()),'stats',stats,flush=True)

if __name__=='__main__':
    run()
