import csv
import json
import sys
from collections import Counter
from pathlib import Path

from qgis.core import (
    QgsApplication, QgsCoordinateReferenceSystem, QgsCoordinateTransform,
    QgsGeometry, QgsPointXY, QgsProject, QgsVectorLayer, Qgis
)

base = Path(r'E:\Praktikum Sistem Informasi Geografi\Pertemuan_11\data\Pertemuan 5')
qa = Path(__file__).resolve().parent
profile = qa / 'profil'
profile.mkdir(exist_ok=True)
app = QgsApplication([], False, str(profile))
app.setPrefixPath('D:/qgis/apps/qgis-ltr', True)
app.initQgis()
wgs = QgsCoordinateReferenceSystem('EPSG:4326')
utm = QgsCoordinateReferenceSystem('EPSG:32647')
tr = QgsCoordinateTransform(wgs, utm, QgsProject.instance())
layer = QgsVectorLayer(str(base/'ADMINISTRASIKECAMATAN_AR_50K.shp'), 'Kecamatan', 'ogr')
assert layer.isValid() and layer.featureCount() == 21
polys = [(str(f['NAMOBJ']).title(), f.geometry()) for f in layer.getFeatures()]
with (base/'banjir.csv').open(encoding='utf-8-sig', newline='') as handle:
    rows = list(csv.DictReader(handle))
counts = Counter()
disagreements = Counter()
assignment = {}
xy = {}
by_loc = {}
for r in rows:
    p = QgsPointXY(float(r['longitude']), float(r['latitude']))
    hit = [n for n, geo in polys if geo.intersects(QgsGeometry.fromPointXY(p))]
    assert len(hit) <= 1, (r, hit)
    name = hit[0] if hit else 'Di luar batas'
    counts[name] += 1
    if name.casefold() != r['kecamatan'].casefold():
        disagreements[(r['kecamatan'], name)] += 1
    xy[r['id']] = [tr.transform(p).x(), tr.transform(p).y()]
    by_loc.setdefault(r['lokasi_referensi'],[]).append(xy[r['id']])
    assignment[r['id']] = name
district_info = {}
for name, geom in polys:
    g = QgsGeometry(geom)
    g.transform(tr)
    point = g.pointOnSurface().asPoint()
    box = g.boundingBox()
    district_info[name] = dict(n=counts.get(name,0), point=[point.x(),point.y()],
                              extent=[box.xMinimum(),box.yMinimum(),box.xMaximum(),box.yMaximum()])
context = dict(version=Qgis.QGIS_VERSION,counts=dict(counts),disagree=sum(disagreements.values()),
               discrepancies={' | '.join(k):v for k,v in disagreements.items()},
               by_id=assignment, coordinates=xy, locations=by_loc,districts=district_info)
(qa/'hasil_pemeriksaan.json').write_text(json.dumps(context,indent=2),encoding='utf-8')
print('QGIS', Qgis.QGIS_VERSION, '; assigned', dict(sorted(counts.items())))
print('Differences', sum(disagreements.values()), dict(disagreements))
for name, info in district_info.items():
    print(name, info['n'], [round(t) for t in info['point']])
print('Coordinate range',tuple(sorted((round(min(t[i] for t in xy.values())),round(max(t[i] for t in xy.values()))) for i in (0,1))))
sys.stdout.flush()
