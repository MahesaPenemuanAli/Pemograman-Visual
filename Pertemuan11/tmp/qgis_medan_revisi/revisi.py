# -*- coding: utf-8 -*-
"""Build the revised editable layout using the installed QGIS desktop libraries."""
import csv
import hashlib
import json
import math
import os
import shutil
import sys
import warnings
import zipfile
import xml.etree.ElementTree as ET
from pathlib import Path

from qgis.PyQt.QtCore import Qt, QUrl, QUrlQuery
from qgis.PyQt.QtGui import QColor, QFont, QFontDatabase, QFontMetricsF
from qgis.core import *

QA=Path(__file__).resolve().parent
PRAK=Path(r'E:\Praktikum Sistem Informasi Geografi\Pertemuan_11')
STEM='Peta_Banjir_Genangan_Medan'
SRC=PRAK/STEM
OUT=QA/'hasil'/STEM
DATA=OUT/'Data'
EXPORT_TITLE='Sebaran dan Jumlah Titik Banjir/Genangan per Kecamatan di Kota Medan'
LAYOUT='Peta Banjir dan Genangan Kota Medan'
NAVY='#172F43'; INK='#1C2F39'; MUTED='#475962'; LIGHT='#E9F0F2'; EDGE='#829198'
INK_BLUE='#123A66'; WHITE='#FFFFFF'
CLASSES=[(0,0,'0 titik','#EEEBDD'),(0,4,'1–4 titik','#C8D9EB'),
         (4,8,'5–8 titik','#86B6D9'),(8,16,'9–16 titik','#4A8DB6'),
         (16,24,'17–24 titik','#24658D')]
PROJ='EPSG:32647'
LIVE_CREDIT='Esri, Vantor, Earthstar Geographics, and the GIS User Community'

def copy_inputs():
    DATA.mkdir(parents=True,exist_ok=True)
    for src in sorted((SRC/'Data').rglob('*')):
        if src.is_file() and src.suffix.lower() in ('.gpkg','.csv','.shp','.shx','.dbf','.prj','.xml','.cpg'):
            target=DATA/src.relative_to(SRC/'Data')
            target.parent.mkdir(parents=True,exist_ok=True)
            if not target.exists(): shutil.copy2(src,target)
            assert target.read_bytes()==src.read_bytes(), src.name

def qfont(n,bold=False,medium=False):
    f=QFont('Segoe UI');f.setPointSizeF(n)
    f.setWeight(QFont.Bold if bold else (QFont.DemiBold if medium else QFont.Normal))
    return f

def tx(n,c=INK,bold=False,medium=False):
    f=QgsTextFormat();f.setFont(qfont(n,bold,medium));f.setSize(n);f.setColor(QColor(c))
    return f

def outline_text(n,c=INK,halo='#FFFFFF',w=.48,bold=False):
    f=tx(n,c,bold=bold,medium=not bold)
    b=QgsTextBufferSettings();b.setEnabled(True);b.setColor(QColor(halo));b.setSize(w);f.setBuffer(b)
    return f

def rgba(hex_color,alpha=255):
    c=QColor(hex_color)
    return f'{c.red()},{c.green()},{c.blue()},{alpha}'

def linesym(color,width,style='solid'):
    return QgsLineSymbol.createSimple({'line_color':color,'line_width':str(width),
                                        'line_style':style,'joinstyle':'round','capstyle':'round'})

def fill(color,edge,width=0.2):
    return QgsFillSymbol.createSimple({'color':color,'outline_color':edge,'outline_width':str(width),
            'outline_style':'solid' if width else 'no','joinstyle':'round'})

def marker(name,w,col,edge,width):
    return QgsMarkerSymbol.createSimple({'name':name,'size':str(w),'color':col,'outline_color':edge,
                        'outline_width':str(width),'outline_style':'solid','joinstyle':'round'})

def xy_uri():
    with zipfile.ZipFile(PRAK/'pertemuan11.qgz') as z:
        tree=ET.fromstring(z.read(next(n for n in z.namelist() if n.endswith('.qgs'))))
    l=next(l for l in tree.findall('./projectlayers/maplayer') if l.findtext('layername')=='Esri Satellite')
    return l.findtext('datasource')

def csv_table():
    url=QUrl.fromLocalFile(str(DATA/'banjir.csv'));q=QUrlQuery()
    for k,v in [('type','csv'),('delimiter',','),('detectTypes','yes'),('geomType','none'),
                ('encoding','UTF-8'),('watchFile','no'),('subsetIndex','no')]:q.addQueryItem(k,v)
    url.setQuery(q)
    return QgsVectorLayer(url.toString(),'Data_banjir','delimitedtext')

# Label placement is independent from the analytical geometry and can be edited in QGIS.
LABEL_POS={
 'Belawan':(463180,416900),'Marelan':(459940,411010),'Labuhan':(466440,410290),
 'Deli':(463960,404970),'Helvetia':(458620,400160),'Barat':(462470,400300),
 'Timur':(465260,400800),'Tembung':(469450,399260),'Perjuangan':(470370,398200),
 'Sunggal':(456990,395720),'Baru':(460570,394680),'Petisah':(461470,397050),
 'Area':(468720,396550),'Maimun':(464980,392890),'Kota':(466610,394090),
 'Denai':(470310,393900),'Polonia':(462820,393690),'Selayang':(458600,392790),
 'Johor':(463320,389610),'Amplas':(468920,391235),'Tuntungan':(457920,388650)}

def label_coord(axis):
    expr='CASE '+ ' '.join(f"""WHEN "kec_nama" = 'Medan {k}' THEN {point[axis]}""" for k,point in LABEL_POS.items())+' END'
    assert not QgsExpression(expr).hasParserError(),QgsExpression(expr).parserErrorString()
    return expr

def labels(layer):
    s=QgsPalLayerSettings();s.isExpression=True
    s.fieldName="concat(replace(\"kec_nama\", 'Medan ', ''), ' (', \"jml_titik\", ')')"
    s.placement=Qgis.LabelPlacement.Horizontal;s.priority=8
    s.setFormat(outline_text(9.4,INK,'#FFFFFF',.58,bold=True))
    props=QgsPropertyCollection()
    for prop,expr in [(QgsPalLayerSettings.PositionX,label_coord(0)),(QgsPalLayerSettings.PositionY,label_coord(1))]:
        props.setProperty(prop,QgsProperty.fromExpression(expr))
    props.setProperty(QgsPalLayerSettings.Hali,QgsProperty.fromValue('Center'))
    props.setProperty(QgsPalLayerSettings.Vali,QgsProperty.fromValue('Half'))
    props.setProperty(QgsPalLayerSettings.AlwaysShow,QgsProperty.fromValue(True))
    # The three displaced labels get short leader lines in the dense centre.
    props.setProperty(QgsPalLayerSettings.CalloutDraw,QgsProperty.fromExpression(
        "\"kec_nama\" IN ('Medan Perjuangan','Medan Kota','Medan Maimun','Medan Tembung')"))
    call=QgsSimpleLineCallout();call.setEnabled(True);call.setAnchorPoint(QgsCallout.PointOnSurface)
    leader=linesym(rgba('#F9F8EE',245),.64)
    leader.appendSymbolLayer(QgsSimpleLineSymbolLayer.create({'line_color':rgba('#213946',245),'line_width':'.24','capstyle':'round'}))
    call.setLineSymbol(leader);call.setMinimumLength(1.7);call.setOffsetFromLabel(.7)
    s.setCallout(call);s.setDataDefinedProperties(props)
    layer.setLabeling(QgsVectorLayerSimpleLabeling(s));layer.setLabelsEnabled(True)

def setmeta(l,title,desc):
    m=l.metadata();m.setTitle(title);m.setAbstract(desc);l.setMetadata(m)

def setup_layers():
    gp=DATA/'Banjir_Medan.gpkg'
    pts=QgsVectorLayer(str(gp)+'|layername=titik_banjir','Titik banjir dan genangan','ogr')
    polys=QgsVectorLayer(str(gp)+'|layername=rekap_kecamatan','Jumlah titik per kecamatan','ogr')
    tab=csv_table()
    sat=QgsRasterLayer(xy_uri(),'Esri Satellite','wms')
    assert pts.isValid() and pts.featureCount()==115 and polys.isValid() and polys.featureCount()==21
    assert tab.isValid() and tab.featureCount()==115 and tab.wkbType()==Qgis.WkbType.NoGeometry
    assert sat.isValid() and sat.crs().authid()=='EPSG:3857'
    rs=[]
    for lo,hi,label,c in CLASSES:
        rs.append(QgsRendererRange(lo,hi,fill(rgba(c,226),rgba('#2B414C',245),.27),label))
    polys.setRenderer(QgsGraduatedSymbolRenderer('jml_titik',rs))
    points=[QgsRendererCategory('Dalam batas',marker('circle',1.95,'#CF4D17','#FFFBF2',.24),'Di dalam batas kota'),
            QgsRendererCategory('Di luar batas',marker('diamond',2.85,'#7F225B','#FFF8FE',.30),'Di luar batas kota')]
    pts.setRenderer(QgsCategorizedSymbolRenderer('status_geo',points))
    pts.setDisplayExpression('"lokasi_ref"');polys.setDisplayExpression('"kec_nama"');tab.setDisplayExpression('"lokasi_referensi"')
    labels(polys)
    setmeta(polys,'Jumlah titik per kecamatan','21 poligon batas RBI dan jumlah titik hasil Count points in polygon. Angka 0 menunjukkan tidak ada koordinat pada data latihan yang jatuh dalam poligon.')
    setmeta(pts,'Titik banjir/genangan dari CSV latihan','115 titik dibuat dari longitude dan latitude CSV asli. Kolom kec_csv mempertahankan nama kecamatan dari CSV. Kolom kec_peta, status_geo dan cek_nama berisi hasil analisis posisi.')
    setmeta(tab,'Data latihan banjir.csv','Tabel koordinat sumber praktikum Pertemuan 5 tanpa geometri untuk rujukan langsung pada atribut asli.')
    sat.setAttribution(LIVE_CREDIT);sat.setAttributionUrl('https://www.arcgis.com/home/item.html?id=10df2279f9684e4a9f6a7f08febac2a9')
    setmeta(sat,'Esri Satellite','Esri World Imagery. Menggunakan koneksi XYZ yang sama dengan proyek praktikum QGIS. Sumber citra: '+LIVE_CREDIT+'.')
    for l,al in [(pts,{'kec_csv':'Kecamatan pada CSV','kec_peta':'Kecamatan secara spasial',
                         'cek_nama':'Hasil pemeriksaan nama','id_titik':'ID titik','lokasi_ref':'Lokasi referensi'}),
                 (polys,{'kec_nama':'Kecamatan','jml_titik':'Jumlah titik'})]:
        for k,v in al.items():l.setFieldAlias(l.fields().indexFromName(k),v)
    root=project.layerTreeRoot()
    for l in (pts,polys,tab,sat):
        project.addMapLayer(l,False);node=root.addLayer(l);node.setExpanded(l==polys)
    base=QgsRectangle(polys.extent());base.scale(1.15)
    project.viewSettings().setDefaultViewExtent(QgsReferencedRectangle(base,UTM))
    return pts,polys,tab,sat

def place(item,key,x,y,w,h):
    item.setId(key);layout.addLayoutItem(item);item.attemptMove(QgsLayoutPoint(x,y))
    item.attemptResize(QgsLayoutSize(w,h));return item

def box(key,x,y,w,h,color,edge=None,ow=.20):
    item=QgsLayoutItemShape(layout);item.setShapeType(QgsLayoutItemShape.Rectangle)
    item.setSymbol(fill(color,edge or color,ow if edge else 0));return place(item,key,x,y,w,h)

def text(key,x,y,w,h,value,size=9,colour=INK,bold=False,medium=False,align=Qt.AlignLeft):
    t=QgsLayoutItemLabel(layout);t.setText(value);t.setTextFormat(tx(size,colour,bold,medium))
    t.setMargin(0);t.setHAlign(align);t.setVAlign(Qt.AlignVCenter)
    return place(t,key,x,y,w,h)

def section(y,title,id):
    box('Latar '+id,249,y,162,7.7,LIGHT)
    text('Judul '+id,253,y,154,7.7,title,10.9,INK,bold=True)

def map_item(key,x,y,w,h,layers,center,scale):
    m=QgsLayoutItemMap(layout);place(m,key,x,y,w,h)
    m.setCrs(UTM);m.setLayers(layers);m.setKeepLayerSet(True)
    m.setBackgroundColor(QColor('#F0F1E9'));m.setBackgroundEnabled(True)
    m.setFrameEnabled(True);m.setFrameStrokeColor(QColor('#374E58'));m.setFrameStrokeWidth(QgsLayoutMeasurement(.35))
    dx=w*scale/2000;dy=h*scale/2000
    m.zoomToExtent(QgsRectangle(center[0]-dx,center[1]-dy,center[0]+dx,center[1]+dy))
    m.setScale(scale);m.refresh();return m

def grid(m):
    G=QgsLayoutItemMapGrid
    g=G('Grid geografis 0,05 derajat',m);m.grids().addGrid(g)
    g.setEnabled(True);g.setStyle(G.Solid);g.setCrs(WGS);g.setIntervalX(.05);g.setIntervalY(.05)
    sym=linesym(rgba('#102B36',155),.65)
    sym.appendSymbolLayer(QgsSimpleLineSymbolLayer.create({'line_color':rgba('#FAFAE9',235),'line_width':'.29',
                                                          'line_style':'solid','capstyle':'flat'}))
    g.setLineSymbol(sym)
    g.setStackingPosition(QgsLayoutItemMapItem.StackBelowMapLabels)
    g.setFrameStyle(G.InteriorTicks);g.setFrameWidth(1.0);g.setFramePenSize(.22);g.setFramePenColor(QColor(INK))
    g.setAnnotationEnabled(True);g.setAnnotationFormat(G.CustomFormat)
    g.setAnnotationExpression("replace(format_number(@grid_number,2), '.', ',') || '° ' || if(@grid_axis='x','BT','LU')")
    g.setAnnotationPrecision(2);g.setAnnotationTextFormat(tx(7.9,INK,medium=True))
    for side in (G.Bottom,G.Top,G.Left,G.Right):
        g.setAnnotationPosition(G.OutsideMapFrame,side)
        if side in (G.Bottom,G.Top):
            g.setAnnotationDisplay(G.LongitudeOnly,side);g.setAnnotationDirection(G.Horizontal,side)
        else:
            g.setAnnotationDisplay(G.LatitudeOnly,side);g.setAnnotationDirection(G.VerticalDescending,side)
    g.setAnnotationFrameDistance(.83)
    m.updateBoundingRect()

def scale(key,m,x,y,numeric=False,segment=2):
    s=QgsLayoutItemScaleBar(layout);s.setId(key);layout.addLayoutItem(s)
    s.setStyle('Numeric' if numeric else 'Single Box');s.setLinkedMap(m)
    s.setUnits(Qgis.DistanceUnit.Kilometers);s.setUnitsPerSegment(segment)
    s.setNumberOfSegments(2);s.setNumberOfSegmentsLeft(0);s.setUnitLabel('km')
    s.setTextFormat(tx(16.6 if numeric else 8.1,INK,bold=numeric,medium=not numeric))
    s.setFillColor(QColor(INK));s.setFillColor2(QColor(WHITE));s.setLineColor(QColor(INK))
    s.setLineWidth(.19);s.setHeight(1.75);s.setLabelBarSpace(.45);s.setBoxContentSpace(.45)
    s.attemptMove(QgsLayoutPoint(x,y));s.update();return s

def legend(key,m,layer,x,y):
    l=QgsLayoutItemLegend(layout);l.setId(key);layout.addLayoutItem(l)
    l.setTitle('');l.setLinkedMap(m);l.setAutoUpdateModel(False)
    group=l.model().rootGroup();group.removeAllChildren();n=group.addLayer(layer)
    QgsLegendRenderer.setNodeLegendStyle(n,Qgis.LegendComponent.Hidden)
    l.setLegendFilterByMapEnabled(False);l.setSymbolHeight(3.3);l.setSymbolWidth(7.1)
    l.setBoxSpace(.0)
    l.setFontColor(QColor(INK));l.setStyleFont(Qgis.LegendComponent.SymbolLabel,qfont(9.15))
    l.setStyleMargin(Qgis.LegendComponent.Symbol,.65);l.setStyleMargin(Qgis.LegendComponent.SymbolLabel,QgsLegendStyle.Left,1.6)
    l.setResizeToContents(True);l.attemptMove(QgsLayoutPoint(x,y));l.refresh();l.adjustBoxSize()
    return l

def layout_map(points,polys,sat):
    layout.pageCollection().pages()[0].setPageSize(QgsLayoutSize(420,297))
    layout.renderContext().setDpi(300)
    shell=box('Bingkai lembar peta',9,9,402,279,'#FFFFFF','#344B55',.38)
    box('Pemisah kolom',248.75,9,.30,279,'#344B55')
    box('Garis kepala peta utama',10,21.6,238,.24,'#BECBD0')
    text('Keterangan peta kiri',14,10.2,157,7.8,'KOTA MEDAN  /  SUMATERA UTARA',9.1,NAVY,bold=True)
    text('Keterangan koordinat',169,10.2,72,7.8,'Grid geografis 0,05°',8.3,MUTED,align=Qt.AlignRight)
    main=map_item('Peta utama',18,31.2,222,236.5,[points,polys,sat],(463350,402520),160000)
    layout.setReferenceMap(main);grid(main)
    # A scale card belongs to the map, as in the teaching example.
    box('Alas batang skala',200.0,253.0,35.0,10.6,rgba('#FFFFFF',246),'#65747C',.17)
    scale('Skala grafis peta utama',main,201.5,254.5,segment=2.0)
    text('Atribusi citra',14,273.5,228,6.8,'Citra satelit  •  Esri, Vantor, Earthstar Geographics, dan GIS User Community.',8.0,MUTED)
    text('Sumber data kiri',14,280.2,228,6.2,'Titik latihan Pertemuan 5   /   Batas kecamatan RBI Sumatera skala 1:50.000.',8.6,INK)
    text('Judul utama',253,12.0,154,23.2,'Peta Sebaran dan Jumlah\nTitik Banjir/Genangan',19.1,NAVY,bold=True,align=Qt.AlignCenter)
    text('Wilayah judul',253,36.2,154,6.6,'per Kecamatan di Kota Medan',12.9,INK,medium=True,align=Qt.AlignCenter)
    box('Garis skala',249,46.2,162,.27,EDGE)
    box('Pemisah arah utara',286.6,46.3,.22,23.1,EDGE)
    text('Huruf utara',261.7,47.4,12,5,'U',9.2,INK,bold=True,align=Qt.AlignCenter)
    pic=QgsLayoutItemPicture(layout);pic.setSvgFillColor(QColor(NAVY));pic.setSvgStrokeColor(QColor(NAVY))
    pic.setPicturePath('D:/qgis/apps/qgis-ltr/svg/arrows/NorthArrow_11.svg');pic.setLinkedMap(main)
    place(pic,'Arah utara',263.0,53.1,9.5,12.4)
    text('Judul skala angka',299,47.5,100,6,'Skala peta utama',9.1,MUTED,medium=True,align=Qt.AlignCenter)
    scale('Skala angka peta utama',main,334,54.3,True)
    section(69.7,'Legenda','legenda')
    text('Legenda poligon',254,80.3,74,6.3,'Jumlah titik per kecamatan',9.5,INK,bold=True)
    text('Legenda lokasi',333.4,80.3,73,6.3,'Lokasi pada data latihan',9.5,INK,bold=True)
    legend('Kelas jumlah titik',main,polys,254.0,89.7)
    legend('Status posisi titik',main,points,333.4,89.7)
    text('Panduan membaca label',333.4,104.7,72.7,12.0,'Angka dalam kurung pada label\nmenunjukkan jumlah titik.',8.35,MUTED)
    section(119.2,'Detail peta','detail')
    # Inset uses the same project layers; no duplicate layers are added to the Layers panel.
    inset=map_item('Detail • Medan bagian tengah',254,131.4,79.5,44.0,[points,polys,sat],(462950,397530),125000)
    old_labeling=polys.labeling().clone();polys.setLabelsEnabled(False)
    inset.storeCurrentLayerStyles();inset.setKeepLayerStyles(True)
    polys.setLabelsEnabled(True);polys.setLabeling(old_labeling)
    overview=QgsLayoutItemMapOverview('Cakupan peta detail',main);overview.setLinkedMap(inset);overview.setEnabled(True)
    osym=QgsFillSymbol.createSimple({'style':'no','outline_color':'#24313E','outline_width':'.37','outline_style':'dash','joinstyle':'miter'})
    overview.setFrameSymbol(osym);overview.setStackingPosition(QgsLayoutItemMapItem.StackBelowMapLabels);main.overviews().addOverview(overview)
    ib=inset.extent();mb=main.extent();ax=18+(ib.xMinimum()-mb.xMinimum())/mb.width()*222;ay=31.2+(mb.yMaximum()-ib.yMaximum())/mb.height()*236.5
    box('Penanda area detail',ax,ay-5.0,7.2,5.0,NAVY)
    text('Kode detail pada peta utama',ax,ay-5.0,7.2,5,'A',8.1,WHITE,bold=True,align=Qt.AlignCenter)
    text('Judul pembesaran',338.6,131.0,67.4,7.0,'A. Medan bagian tengah',9.9,INK,bold=True)
    text('Keterangan pembesaran',338.6,138.6,67.2,10.5,'Pembesaran area dalam bingkai\nputus-putus pada peta utama.',8.4,MUTED)
    text('Koordinat peta',338.6,151,67.4,5.5,'Sistem koordinat',8.4,MUTED)
    text('Proyeksi peta',338.6,157,67.4,10.8,'WGS 84 / UTM zona 47N\nEPSG:32647',9.4,INK,medium=True)
    text('Keterangan skala inset',338.6,169.5,67.4,6,'Skala detail  1:125.000',8.5,MUTED)
    text('Metode penghitungan',254,180,152,13.4,'Jumlah dihitung dari posisi koordinat di dalam batas kecamatan\nmenggunakan Count points in polygon pada QGIS.',9.15,INK)
    text('Pemeriksaan nama kecamatan',254,192.7,152,5.5,'Pada 48 titik di dalam kota, kecamatan hasil spasial berbeda dari nama pada CSV.',8.1,MUTED)
    section(199.0,'Hasil penghitungan','hasil')
    columns=[(254,49,'115','Titik pada CSV'),(305,49,'112','Dalam batas kota'),(356,49,'3','Di luar batas')]
    for i,(x,w,val,k) in enumerate(columns):
        text('Angka '+k,x,209.2,w,10.5,val,16.0,NAVY,bold=True)
        text('Keterangan '+k,x,220.2,w,5.6,k,8.7,MUTED)
    text('Catatan kecamatan',254,229,152,13.0,'Medan Helvetia memiliki 24 titik, terbanyak dalam data latihan.\n17 dari 21 kecamatan memuat sedikitnya satu titik.',9.1,INK)
    section(246.0,'Identitas pembuat','pembuat')
    text('Nama',254,256,152,9.2,'Mahesa Penemuan Ali',14.1,NAVY,bold=True)
    text('NIM dan kelas',254,266.4,152,7,'NIM 241712064    /    KOM B1',9.9,INK,medium=True)
    text('Mata kuliah',254,276.0,152,7,'Praktikum Sistem Informasi Geografi  •  Pertemuan 11',8.8,MUTED)
    layout.refresh();return main,inset

def run():
    global project,layout,UTM,WGS
    copy_inputs()
    profile=QA/'profil';profile.mkdir(exist_ok=True)
    app=QgsApplication([],False,str(profile));app.setPrefixPath('D:/qgis/apps/qgis-ltr',True);app.initQgis()
    warnings.filterwarnings('ignore',category=DeprecationWarning)
    for name in ('segoeui.ttf','segoeuib.ttf','seguisb.ttf'):QFontDatabase.addApplicationFont('C:/Windows/Fonts/'+name)
    assert QFontMetricsF(qfont(10)).inFont('M')
    QgsNetworkAccessManager.setTimeout(22000)
    project=QgsProject.instance();UTM=QgsCoordinateReferenceSystem(PROJ);WGS=QgsCoordinateReferenceSystem('EPSG:4326')
    qgz=OUT/(STEM+'.qgz');project.setFileName(str(qgz));project.setFilePathStorage(Qgis.FilePathType.Relative)
    project.setCrs(UTM);project.setEllipsoid('WGS84');project.setTitle(EXPORT_TITLE)
    md=project.metadata();md.setAuthor('Mahesa Penemuan Ali');md.setTitle(EXPORT_TITLE)
    md.setAbstract('Peta praktikum dari 115 koordinat sumber. QGIS menghitung 112 titik dalam batas kecamatan dan 3 titik di luar batas. Untuk 48 titik di dalam batas, nama kecamatan sumber berbeda dari hasil pengecekan spasial. CSV dan pemeriksaan per titik disertakan dalam folder Data.')
    project.setMetadata(md)
    points,polys,tab,sat=setup_layers()
    layout=QgsPrintLayout(project);layout.initializeDefaults();layout.setName(LAYOUT)
    main,ins=layout_map(points,polys,sat)
    project.layoutManager().addLayout(layout)
    project.viewSettings().setDefaultViewExtent(QgsReferencedRectangle(main.extent(),UTM))
    assert project.write(),project.error()
    preview='--final' not in sys.argv
    img=QA/'preview_revisi.png' if preview else OUT/(STEM+'.png')
    exporter=QgsLayoutExporter(layout);settings=QgsLayoutExporter.ImageExportSettings()
    settings.dpi=150 if preview else 300;settings.generateWorldFile=False;settings.exportMetadata=False
    print('Starting QGIS layout export:',img,settings.dpi,'dpi',flush=True)
    result=exporter.exportToImage(str(img),settings)
    assert result==QgsLayoutExporter.Success,(result,exporter.errorMessage())
    print('QGIS',Qgis.QGIS_VERSION,'success',img,'layers',len(project.mapLayers()),'scales',round(main.scale()),round(ins.scale()),flush=True)

if __name__=='__main__':
    run()
