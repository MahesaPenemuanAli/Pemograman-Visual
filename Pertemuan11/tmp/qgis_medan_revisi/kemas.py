from hashlib import sha256
from pathlib import Path
import os
from zipfile import ZipFile, ZIP_DEFLATED
from xml.etree import ElementTree

work = Path(__file__).resolve().parent
name = 'Peta_Banjir_Genangan_Medan'
root = work / 'hasil' / name
qgz = root / (name + '.qgz')
qpt = root / 'Layout_Banjir_Genangan_Medan.qpt'
gpkg = root / 'Data' / 'Banjir_Medan.gpkg'
portable = b'./Data/Banjir_Medan.gpkg'

def portable_layer_hints(xml):
    # QGIS writes six fallback URIs for layout references independently of the
    # project datasource paths. Preserve item IDs and use the same package paths.
    for path in (str(gpkg), gpkg.as_posix()):
        xml = xml.replace(path.encode(), portable)
    assert b'qgis_medan_revisi' not in xml
    document = ElementTree.fromstring(xml)
    hints = [item.attrib['source'] for item in document.iter()
             if item.tag in ('Layer', 'LayerStyle') and item.attrib.get('provider') == 'ogr']
    assert len(hints) == 6 and all(s.startswith('./Data/Banjir_Medan.gpkg|layername=') for s in hints), hints
    return xml

qpt.write_bytes(portable_layer_hints(qpt.read_bytes()))
rebuilt = qgz.with_suffix('.portable')
with ZipFile(qgz) as source, ZipFile(rebuilt, 'w') as out:
    for entry in source.infolist():
        data = source.read(entry)
        if entry.filename.endswith('.qgs'):
            data = portable_layer_hints(data)
        out.writestr(entry, data)
with ZipFile(rebuilt) as check:
    assert check.testzip() is None
os.replace(rebuilt, qgz)
raw_base = 'Data/Batas_RBI/ADMINISTRASIKECAMATAN_AR_50K'
files = [name+'.png', name+'.qgz', qpt.name, 'Data/banjir.csv', 'Data/Banjir_Medan.gpkg',
         'Data/Jumlah_per_kecamatan.csv','Data/Titik_dan_kecamatan_spasial.csv']
files.extend(raw_base+'.'+ext for ext in ['shp', 'shx', 'dbf', 'prj', 'shp.xml'])
archive = work / ('Paket_' + name + '.zip')
with ZipFile(archive, 'w', compression=ZIP_DEFLATED, compresslevel=6) as out:
    for file in files:
        out.write(root / file, name + '/' + file)
with ZipFile(archive) as packed:
    assert packed.testzip() is None and len(packed.namelist()) == len(files)
    for file in files:
        member = name + '/' + file
        assert sha256(packed.read(member)).digest() == sha256((root/file).read_bytes()).digest()
        packed.extract(member, work / 'uji_pindah')
print('Portable QPT/QGZ and package:', len(files), 'files;', archive.stat().st_size, 'bytes')
