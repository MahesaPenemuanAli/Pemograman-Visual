from pathlib import Path
from hashlib import sha256
from zipfile import ZipFile
from uuid import uuid4
import shutil
import sys

folder = 'Peta_Banjir_Genangan_Medan'
archive_name = 'Paket_' + folder + '.zip'
work = Path(__file__).resolve().parent
tested = work / 'hasil' / folder
area = sys.argv[1]
destinations = {'workspace': Path('D:/pemograman-visual/Pertemuan11'),
                'assignment': Path('E:/Praktikum Sistem Informasi Geografi/Pertemuan_11')}
dest = destinations[area]
assert (dest/folder/'Data').is_dir()
source_files = [(tested/(folder+'.png'),dest/folder/(folder+'.png')),
                (tested/(folder+'.qgz'),dest/folder/(folder+'.qgz')),
                (tested/'Layout_Banjir_Genangan_Medan.qpt',dest/folder/'Layout_Banjir_Genangan_Medan.qpt'),
                (work/archive_name,dest/archive_name)]
existing = {'.png':'4836b478b65d4921297eeb35b103a287d069c360d3a943ad8c419255aabb8cb9',
            '.qgz': '436903aaeb8451bcce982f8a3e3d4cb84e78b60344ef956520f7655254117262' if area=='workspace' else 'c4dcd5b7a95c0ec47c68d8e6945df637739ffbf252101a077493780a2e9bb061',
            '.zip':'c4f68ff59d826d6ce22db09f36cf0b1056ca57e14a1b28a9b17b6c5a12cf6de8'}

def digest(p):
    return sha256(p.read_bytes()).hexdigest()

with ZipFile(work/archive_name) as packed:
    for entry in packed.namelist():
        if entry.startswith(folder+'/Data/'):
            assert sha256(packed.read(entry)).hexdigest()==digest(dest/entry), entry
for src, dst in source_files:
    assert src.is_file()
    if dst.exists() and digest(src) != digest(dst):
        assert digest(dst) == existing.get(dst.suffix), ('File changed since verification',dst)
previous = dest/folder/(folder+'.qgz')
if area == 'assignment' and digest(previous) == existing['.qgz']:
    backup_dir = work/'versi_sebelum_revisi'
    backup_dir.mkdir(exist_ok=True)
    backup = backup_dir/(folder+'.qgz')
    if not backup.exists():
        shutil.copy2(previous,backup)
    assert digest(backup) == existing['.qgz']
pending = []
for src,dst in source_files:
    if dst.exists() and digest(src)==digest(dst):
        continue
    temp = dst.with_name('.'+dst.name+'.'+uuid4().hex+'.tmp')
    shutil.copy2(src,temp)
    assert digest(temp)==digest(src)
    pending.append((temp,dst))
for temp,dst in pending:
    temp.replace(dst)
for src,dst in source_files:
    assert digest(src)==digest(dst)
    print(dst.name, dst.stat().st_size, flush=True)
with ZipFile(dest/archive_name) as packed:
    assert packed.testzip() is None
    for entry in packed.namelist():
        assert sha256(packed.read(entry)).hexdigest()==digest(dest/entry), entry
print('Published and verified 12 package members against',dest, flush=True)
