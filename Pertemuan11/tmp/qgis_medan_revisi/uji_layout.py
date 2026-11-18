from collections import Counter
from pathlib import Path
import sys
import warnings

from qgis.PyQt.QtCore import QUrl
from qgis.PyQt.QtGui import QFontDatabase
from qgis.PyQt.QtXml import QDomDocument
from qgis.core import (
    Qgis, QgsApplication, QgsLayerTreeLayer, QgsLayoutExporter,
    QgsLayoutItemLabel, QgsLayoutItemLegend, QgsLayoutItemMap,
    QgsLayoutItemMapGrid, QgsLayoutItemPicture, QgsLayoutItemScaleBar,
    QgsNetworkAccessManager, QgsPathResolver, QgsPrintLayout, QgsProject,
    QgsReadWriteContext,
)

qa = Path(__file__).resolve().parent
operation = sys.argv[1]
root = Path(sys.argv[2]).resolve()
project_path = root / 'Peta_Banjir_Genangan_Medan.qgz'
template_path = root / 'Layout_Banjir_Genangan_Medan.qpt'
app = QgsApplication([], False, str(qa / 'profil'))
app.setPrefixPath('D:/qgis/apps/qgis-ltr', True)
app.initQgis()
warnings.filterwarnings('ignore', category=DeprecationWarning)
for filename in ('segoeui.ttf', 'segoeuib.ttf', 'seguisb.ttf'):
    QFontDatabase.addApplicationFont('C:/Windows/Fonts/' + filename)
QgsNetworkAccessManager.setTimeout(22000)
project = QgsProject.instance()
assert project.read(str(project_path)), project.error()
assert len(project.layoutManager().printLayouts()) == 1
layout = project.layoutManager().printLayouts()[0]
assert layout.name() == 'Peta Banjir dan Genangan Kota Medan'
assert project.crs().authid() == 'EPSG:32647'
context = QgsReadWriteContext()
context.setPathResolver(QgsPathResolver(str(template_path)))
context.setTransformContext(project.transformContext())

def check_layout(current, layers):
    assert current.pageCollection().pageCount() == 1
    size = current.pageCollection().pages()[0].pageSize()
    assert abs(size.width()-420)<.01 and abs(size.height()-297)<.01
    main = current.itemById('Peta utama')
    inset = current.itemById('Detail • Medan bagian tengah')
    assert isinstance(main, QgsLayoutItemMap) and isinstance(inset, QgsLayoutItemMap)
    assert round(main.scale()) == 160000 and round(inset.scale()) == 125000
    for item in (main, inset):
        assert [a.id() for a in item.layers()] == [layers[i].id() for i in (0, 1, 3)]
    g = main.grids().asList()[0]
    assert g.enabled() and g.style() == QgsLayoutItemMapGrid.Solid
    assert abs(g.intervalX()-.05) < 1e-9 and abs(g.intervalY()-.05) < 1e-9
    assert g.annotationEnabled() and g.crs().authid() == 'EPSG:4326'
    for side in [g.Top, g.Bottom, g.Left, g.Right]:
        assert g.annotationDisplay(side) != g.HideAll
    overview = main.overviews().asList()[0]
    assert overview.enabled() and overview.linkedMap() is not None and overview.linkedMap().uuid() == inset.uuid()
    for key, l in [('Kelas jumlah titik', layers[1]), ('Status posisi titik', layers[0])]:
        legend = current.itemById(key)
        assert isinstance(legend, QgsLayoutItemLegend)
        assert legend.linkedMap().uuid() == main.uuid()
        assert legend.model().rootGroup().findLayers()[0].layer().id() == l.id()
    for key in ['Skala grafis peta utama', 'Skala angka peta utama']:
        scale = current.itemById(key)
        assert isinstance(scale, QgsLayoutItemScaleBar) and scale.linkedMap().uuid() == main.uuid()
    arrow = current.itemById('Arah utara')
    assert isinstance(arrow, QgsLayoutItemPicture) and not arrow.isMissingImage(), arrow.picturePath()
    assert isinstance(current.itemById('Judul utama'), QgsLayoutItemLabel)
    assert current.itemById('Nama').text() == 'Mahesa Penemuan Ali'
    assert len([i for i in current.items() if isinstance(i, QgsLayoutItemLabel)]) >= 27

nodes = project.layerTreeRoot().children()
assert len(nodes) == 4 and all(isinstance(n, QgsLayerTreeLayer) for n in nodes)
layers = [node.layer() for node in nodes]
assert all(l and l.isValid() for l in layers)
assert [l.name() for l in layers] == ['Titik banjir dan genangan','Jumlah titik per kecamatan','Data_banjir','Esri Satellite']
assert [n.isExpanded() for n in nodes] == [False, True, False, False]
pts, districts, table, basemap = layers
assert [l.featureCount() for l in layers[:3]] == [115, 21, 115]
assert not table.isSpatial()
for l in [pts,districts]:
    assert Path(l.source().split('|')[0]).resolve() == root/'Data'/'Banjir_Medan.gpkg'
assert Path(QUrl(table.source()).toLocalFile()).resolve() == root/'Data'/'banjir.csv'
assert basemap.providerType() == 'wms' and 'World_Imagery/MapServer' in basemap.source()
assert len(districts.renderer().ranges()) == 5 and len(pts.renderer().categories()) == 2
counts = {f['kec_nama']:f['jml_titik'] for f in districts.getFeatures()}
assert sum(counts.values()) == 112 and sum(n > 0 for n in counts.values()) == 17
assert max(counts, key=counts.get) == 'Medan Helvetia' and counts['Medan Helvetia'] == 24
assert Counter(f['status_geo'] for f in pts.getFeatures()) == {'Dalam batas':112,'Di luar batas':3}
assert sum(f['cek_nama'] == 'Berbeda' for f in pts.getFeatures()) == 48
check_layout(layout, layers)
if operation == 'template':
    assert layout.saveAsTemplate(str(template_path), context)
    print('Saved native editable template', template_path.name, template_path.stat().st_size, flush=True)
elif operation == 'test':
    qpt = QDomDocument()
    parsed = qpt.setContent(template_path.read_bytes())
    assert parsed[0] if isinstance(parsed, tuple) else parsed, parsed
    copy = QgsPrintLayout(project)
    copy.initializeDefaults()
    items, ok = copy.loadFromTemplate(qpt, context, True)
    assert ok and len(items) >= 40, (ok, len(items))
    copy.setName('Uji templat yang dipindah')
    check_layout(copy, layers)
    title = copy.itemById('Judul utama')
    original = title.text()
    title.setText('Uji pengeditan judul')
    assert title.text() == 'Uji pengeditan judul'
    assert layout.itemById('Judul utama').text() == original
    title.setText(original)
    exporter = QgsLayoutExporter(copy)
    settings = QgsLayoutExporter.ImageExportSettings()
    settings.dpi = 90
    settings.generateWorldFile = False
    settings.exportMetadata = False
    dest = qa/'uji_impor_template.png'
    result = exporter.exportToImage(str(dest), settings)
    assert result == QgsLayoutExporter.Success, (result, exporter.errorMessage())
    print('Verified relocated QGIS project and editable template', Qgis.QGIS_VERSION, flush=True)
    print('Layers:', [l.name() for l in layers], 'count:', sum(counts.values()), 'template items:',len(items), 're-export bytes:', dest.stat().st_size, flush=True)
else:
    raise ValueError(operation)
