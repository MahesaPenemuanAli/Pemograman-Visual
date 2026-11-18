# -*- coding: utf-8 -*-
import csv
import math
import sys
from pathlib import Path
from collections import Counter

from qgis.PyQt.QtGui import QFontDatabase, QImage
from qgis.core import (
    QgsApplication, QgsLayoutExporter, QgsLayoutItemLabel, QgsLayoutItemMap,
    QgsLayoutItemLegend, QgsLayoutItemPicture, QgsLayoutItemScaleBar, QgsProject
)

root=Path(sys.argv[1]).resolve()
qa=Path(__file__).resolve().parent
app=QgsApplication([],False,str(qa/'profil_verifikasi'))
app.setPrefixPath('D:/qgis/apps/qgis-ltr',True);app.initQgis()
for name in ('segoeui.ttf','segoeuib.ttf','seguisb.ttf'):
    QFontDatabase.addApplicationFont('C:/Windows/Fonts/'+name)
p=QgsProject.instance()
qgz=root/'Peta_Banjir_Genangan_Medan.qgz'
assert p.read(str(qgz)),p.error()
assert len(p.mapLayers())==6
for l in p.mapLayers().values():
    assert l.isValid(),(l.name(),l.source())
    uri=l.source()
    if l.providerType()=='delimitedtext':
        from qgis.PyQt.QtCore import QUrl
        filename=Path(QUrl(uri).toLocalFile())
    else: filename=Path(uri.split('|')[0])
    assert filename.resolve().is_relative_to(root),(l.name(),filename)
poly=p.mapLayersByName('Jumlah titik per kecamatan')[0]
pts=p.mapLayersByName('Titik banjir/genangan')[0]
counts={str(f['kec_nama']):int(f['jml_titik']) for f in poly.getFeatures()}
observed=Counter()
check=Counter()
for ft in pts.getFeatures():
    check[ft['cek_nama']]+=1
    if ft['status_geo']=='Dalam batas':
        observed[ft['kec_peta']]+=1
assert len(counts)==21 and all(n==observed[k] for k,n in counts.items())
assert sum(counts.values())==112 and pts.featureCount()==115
assert check=={'Sesuai':64,'Berbeda':48,'Di luar batas':3},check
with (root/'Data'/'Jumlah_per_kecamatan.csv').open(encoding='utf-8-sig',newline='') as f:
    assert counts=={r['kecamatan']:int(r['jumlah_titik_spasial']) for r in csv.DictReader(f)}
for lyr in (poly,pts):
    assert lyr.crs().authid()=='EPSG:32647'
layouts=p.layoutManager().printLayouts(); assert len(layouts)==1
layout=layouts[0]; assert layout.pageCollection().pageCount()==1
items=layout.items()
maps=[i for i in items if isinstance(i,QgsLayoutItemMap)]
assert len(maps)==2 and all(len(i.layers())==2 for i in maps)
main=next(i for i in maps if 'utama' in i.id())
assert main.grids().size()>0 and main.grid().enabled() and main.grid().annotationEnabled()
assert len(main.overviews().asList())==1
assert math.isclose(main.scale(),195000,rel_tol=0.00002)
assert len([i for i in items if isinstance(i,QgsLayoutItemLegend)])==2
scales=[i for i in items if isinstance(i,QgsLayoutItemScaleBar)]
assert len(scales)==3 and all(i.linkedMap() is not None for i in scales)
arrows=[i for i in items if isinstance(i,QgsLayoutItemPicture)]
assert len(arrows)==1 and not arrows[0].isMissingImage(), arrows[0].picturePath()
texts={i.id():i.text() for i in items if isinstance(i,QgsLayoutItemLabel)}
assert 'Mahesa Penemuan Ali'==texts['Nama pembuat'] and '241712064' in texts['Identitas kelas'] and 'KOM B1' in texts['Identitas kelas']
assert all('Jumlah '+f'{i:02}' in texts for i in range(1,22))
assert 'jumlah titik banjir/genangan' in texts['Judul peta'] and 'Detail A' in texts['Judul detail']
png=QImage(str(root/'Peta_Banjir_Genangan_Medan.png'))
assert not png.isNull() and png.size().width()==4960 and png.size().height()==3507
settings=QgsLayoutExporter.ImageExportSettings();settings.dpi=110
settings.generateWorldFile=False;settings.exportMetadata=False
ex=QgsLayoutExporter(layout)
assert ex.exportToImage(str(qa/'peta_buka_ulang.png'),settings)==QgsLayoutExporter.Success,ex.errorMessage()
print('QGIS REOPEN OK; 6 valid local sources, native Print Layout with 2 map frames, 2 legends, 3 linked scales, north arrow, coordinate grid and 21 tabulated districts.')
print('Stats validated:',check,'spatial total:',sum(counts.values()),'final PNG:',png.width(),png.height())
print('QGIS project:',qgz)
