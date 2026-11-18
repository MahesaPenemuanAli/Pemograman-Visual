# Latihan Responsi — Pengelolaan Nilai Mahasiswa

Buka "Latihan Responsi.slnx" di Visual Studio, lalu tekan F5.
Target proyek: Visual Basic, Windows Forms, .NET 10.

## Penggunaan
1. Pada Input dan Data, klik Isi 5 contoh atau isi formulir lalu Tambah.
2. Nilai akhir = 30% tugas + 30% UTS + 40% UAS.
3. Grade A >=85, B >=75, C >=65, D >=50, selainnya E. Lulus >=65.
4. Cari berdasarkan NIM/nama dan jurusan. Reset pencarian sebelum menambah/menghapus.
5. Pilih satu baris lalu Hapus terpilih; konfirmasikan penghapusan.
6. Ekspor CSV mengekspor seluruh daftar utama, termasuk ketika tampilan sedang difilter.
7. Latihan Array menampilkan array 1D, array 2D, nested loop, Mod, dan urutan mundur.
8. Rekap DataTable: klik Muat ulang rekap; cari nama/NIM dan jurusan; klik header untuk sort.
   Statistik dihitung dari hasil filter. Muat ulang setelah daftar utama berubah.
9. Uji Konversi: masukkan 25, abc, dan 999999999999999 untuk membandingkan hasilnya.

Data hanya berada di memori dan hilang ketika aplikasi ditutup. CSV adalah ekspor,
bukan penyimpanan yang dimuat otomatis. Tidak ada database atau paket database.

## Peta kode dan materi
- Form1.vb: logika form utama bernama frmUtama dan event tombol.
- Form1.Designer.vb: seluruh komponen tampilan, dapat dilihat dan diedit lewat Windows Forms Designer sebelum Run.
- Materi.vb / Mahasiswa: Class dan Public Property untuk satu baris mahasiswa.
- modData: List(Of Mahasiswa), array 1D, array 2D.
- modPerhitungan: Function, aritmatika, If/ElseIf, Select Case.
- modValidasi: TryParse, format NIM, normalisasi desimal, escaping filter dan CSV.
- ValidasiInput: ErrorProvider, rentang, wajib isi, NIM unik.
- Tambah/Hapus/Cari: BindingSource, List, event dan perulangan.
- TampilArray: grid manual (unbound), nested For, Step -1, Mod.
- MuatRekap/FilterRekap: DataTable di memori, BindingSource.Filter, sort.
- PerbaruiStatistik: For Each, While, Do Loop, pemeriksaan data kosong.
- Ekspor: SaveFileDialog, Using, Try/Catch/Finally.
- BuatKonversi: FormatException dan OverflowException.

## Urutan belajar
1. Pelajari properti Mahasiswa dan fungsi HitungNilaiAkhir.
2. Ikuti alur ValidasiInput -> Tambah -> BindingSource -> DataGridView.
3. Bandingkan pengisian grid manual dengan binding List dan DataTable.
4. Bandingkan pencarian List dengan Filter pada DataTable.
5. Baca statistik dan identifikasi kondisi berhenti setiap perulangan.
6. Baca ekspor, lalu uji kegagalan file dan penanganan exception.

## Pemeriksaan manual
- 80, 70, 90 menghasilkan 81 / B / Lulus.
- Uji batas grade: 85, 75, 65, 50; isi ketiga nilai sama untuk mencapai batas tersebut.
- Nama kosong, NIM duplikat, angkatan huruf, nilai -1 dan 101 ditolak.
- Nilai 80,5 dan 80.5 diterima sebagai desimal yang sama.
- Cari Ma'ruf dan karakter [ ] * % pada rekap; tidak boleh error.
- Klik Tampilkan Array dua kali; jumlah baris tetap lima.
- Rekap kosong menghasilkan statistik nol.
- Reset pencarian mengembalikan daftar utama.
- Batalkan dialog ekspor; aplikasi tetap berjalan.
- Ekspor ke file yang terkunci; pesan kesalahan muncul dan tombol aktif kembali.
