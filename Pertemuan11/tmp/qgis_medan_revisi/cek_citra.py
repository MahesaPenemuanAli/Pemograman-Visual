# -*- coding: utf-8 -*-
import sys, math, zipfile
from pathlib import Path
from urllib.parse import parse_qs
import xml.etree.ElementTree as ET
from qgis.core import QgsApplication,QgsRasterLayer,QgsBlockingNetworkRequest,QgsNetworkAccessManager,Qgis
from qgis.PyQt.QtCore import QUrl
from qgis.PyQt.QtNetwork import QNetworkRequest
from qgis.PyQt.QtGui import QImage

qa=Path(__file__).resolve().parent
profil=qa/'profil';profil.mkdir(exist_ok=True)
qgis=QgsApplication([],False,str(profil));qgis.setPrefixPath('D:/qgis/apps/qgis-ltr',True);qgis.initQgis()
old=Path(r'E:\Praktikum Sistem Informasi Geografi\Pertemuan_11\pertemuan11.qgz')
with zipfile.ZipFile(old) as z:
    root=ET.fromstring(z.read(next(n for n in z.namelist() if n.endswith('.qgs'))))
l=next(l for l in root.findall('./projectlayers/maplayer') if l.findtext('layername')=='Esri Satellite')
uri=l.findtext('datasource')
lyr=QgsRasterLayer(uri,'Esri Satellite','wms')
print('QGIS',Qgis.QGIS_VERSION,'Esri XYZ layer',lyr.isValid(),lyr.crs().authid(),flush=True)
QgsNetworkAccessManager.setTimeout(18000)
url=parse_qs(uri)['url'][0]
z=12; x=math.floor((98.66+180)/360*2**z); y=math.floor((1-math.asinh(math.tan(math.radians(3.60)))/math.pi)*.5*2**z)
test=url.replace('{z}',str(z)).replace('{x}',str(x)).replace('{y}',str(y))
req=QgsBlockingNetworkRequest();status=req.get(QNetworkRequest(QUrl(test)))
reply=req.reply()
data=bytes(reply.content())
img=QImage.fromData(data)
print('Check',str(status),req.errorMessage(),len(data),'Image:',img.width(),img.height(),flush=True)
if img.isNull():sys.exit(2)
print('Tile dimensions, provider and response verified.',flush=True)
