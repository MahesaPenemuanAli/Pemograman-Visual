# Tugas 07 - Form Peminjaman Buku

Nama: Mahesa Penemuan Ali
NIM: 241712064
Mata kuliah: Pemrograman Visual

## Menjalankan proyek

1. Buka `Form Peminjaman Buku.slnx` di Visual Studio yang mendukung .NET 10 dan workload .NET desktop development.
2. Buka `Form1.vb` melalui View Designer atau Shift+F7 untuk melihat rancangan.
3. Tekan F5 atau Ctrl+F5 untuk menjalankan aplikasi.

Build lewat terminal, dari folder ini:

```powershell
dotnet build ".\Form Peminjaman Buku\Form Peminjaman Buku.vbproj"
```

Semua kontrol dibuat di `Form1.Designer.vb` dan bisa diedit melalui Designer. Tidak ada pembuatan kontrol di event Click atau Load. `Option Strict On` diaktifkan pada proyek.

## Kaitan dengan materi yang sudah dipelajari

| Materi / source kuliah | Penggunaan pada tugas |
| --- | --- |
| Pertemuan 1-2: komponen visual, properti, event | Label, TextBox, ComboBox, Button, ListBox dan event Click |
| Pertemuan 3-4: operator, If, perulangan, TryParse | Pemeriksaan panjang, batas 1-14 hari, For dan For Each |
| Pertemuan 5: Module, Sub, Function, array, koleksi | ModValidasi, BersihkanForm, array enam kolom, List(Of String), List(Of String()) |
| Pertemuan 7: naming convention, validasi, exception | ValidasiInput, ErrorProvider, Validating, Try...Catch...Finally |
| FormPendaftaran/FrmPendaftaran.vb | Pola validasi semua isian, pencegahan duplikat, pembersihan, StreamWriter |
| FormPendaftaran/ModValidasi.vb | Pola fungsi SemuaDigit |
| Latihan Responsi/Materi.vb | Pola pengamanan tanda petik untuk kolom CSV |

Materi PDF yang dijadikan acuan ada di folder `Visual pemograman` pada repository, terutama Pertemuan 5 dan 7. Tidak memakai database, LINQ, regex, kelas model tambahan, atau library eksternal.

## Cara kerja kode

- `ValidasiInput()` membersihkan error lama, memeriksa seluruh isian, lalu mengembalikan True/False.
- `KodeBukuValid()` melakukan Trim, mengubah kode menjadi huruf besar, memeriksa panjang dan awalan BK, lalu memanggil `SemuaDigit()` untuk empat digit terakhir. Pemeriksaan panjang dilakukan sebelum Substring.
- `daftarKodeBuku As List(Of String)` menyimpan kode dalam huruf besar untuk mencegah peminjaman ulang dalam satu sesi.
- Event Validating memakai fungsi format kode yang sama dan tidak membatalkan perpindahan fokus.
- Tombol Pinjam menghitung `Date.Today.AddDays(lamaPinjam)`, menambah satu baris, memperbarui jumlah dan membersihkan isian.
- Tombol Bersihkan menghapus isian dan seluruh ikon error. Daftar tetap ada. CausesValidation bernilai False.
- Array enam kolom menyimpan nilai yang sama dengan tampilan ListBox agar judul yang mengandung karakter `|` tidak merusak pemisahan CSV.
- Ekspor memakai pemisah titik koma, satu baris header, dan tanda petik di setiap nilai data. Tanda petik di dalam nilai digandakan.
- StreamWriter selalu ditutup di Finally. IOException dan UnauthorizedAccessException diberi pesan tindakan pengguna, termasuk bila penutupan file gagal.

Data peminjaman disimpan selama aplikasi berjalan. Menutup aplikasi mengosongkan daftar; file CSV adalah hasil ekspor, bukan sumber data yang dimuat ulang.

## Uji manual

| Langkah | Hasil yang diharapkan |
| --- | --- |
| Klik Pinjam saat semua isian kosong | Lima ikon ErrorProvider, tanpa MessageBox validasi |
| Masukkan BK12A4 atau BK12345, lalu pindah fokus | Ikon kesalahan format kode; fokus tetap bisa pindah |
| Masukkan bk0105, Laskar Pelangi, Fiksi, Rina Lubis, 7 | Tersimpan sebagai BK0105; tanggal kembali hari ini + 7 |
| Masukkan kode bk0105 lagi setelah tersimpan | ErrorProvider: Buku ini sedang dipinjam. |
| Nama diisi dua karakter setelah Trim | Ditolak; minimal tiga karakter |
| Lama diisi abc, 12abc, 0, -1, 15, 3.5 atau angka melampaui Integer | Ditolak tanpa crash |
| Lama diisi 1 dan 14 | Keduanya diterima |
| Klik Bersihkan ketika kode salah | Isian dan ikon error hilang, daftar tetap ada |
| Klik Ekspor ketika daftar kosong | Pesan daftar kosong; tidak membuat file |
| Ekspor tiga peminjaman | Header dan tiga baris data di Documents/peminjaman.csv |
| Buka hasil CSV di Excel, lalu klik Ekspor lagi | Pesan Ekspor Gagal; aplikasi dan daftar tetap ada |
| Tutup CSV di Excel, lalu ekspor kembali | Ekspor berhasil |
| File hasil uji diberi atribut Read-only, lalu ekspor | Pesan akses ditolak; kembalikan atribut setelah uji |

## Lokasi ekspor dan catatan lingkungan

Proyek utama menggunakan:

```vb
Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
             "peminjaman.csv")
```

Pada sesi pengujian di komputer ini, Windows menolak pembuatan file di Documents dengan FileNotFoundException, yang termasuk IOException, walaupun foldernya ada. Aplikasi menangkapnya dan tetap berjalan. Pengaturan keamanan Windows tidak diubah.

Pengujian ekspor lanjutan memakai fixture terpisah di folder `.verifikasi`, dengan lokasi file diarahkan ke workspace. Fixture memuat assembly aplikasi yang sama; source proyek utama tetap mengekspor ke Documents. Kode pengujian tersebut tidak dimasukkan ke ZIP tugas.

## Pengumpulan

Arsip source disiapkan dengan nama `241712064_Mahesa_Penemuan_Ali_Tugas07.zip`, tanpa bin, obj, .vs, pengaturan pengguna Visual Studio, dan fixture pengujian. Screenshot ada di folder `dokumentasi`. Periksa kembali identitas serta tenggat di LMS sebelum mengumpulkan.

## Hasil verifikasi (31 Oktober 2026)

- Build setelah nama dikembalikan ke Form1: berhasil, 0 warning dan 0 error.
- Nama file, kelas form, dan form startup: Form1. Properti Name tetap frmPeminjamanBuku.
- File rancangan: Form1.Designer.vb; resource: Form1.resx.
- Pengujian logika sebelumnya mencakup 44 pemeriksaan, termasuk validasi, normalisasi kode, duplikat, dan batas lama pinjam.
- Ekspor telah diuji dengan CSV yang dibuka di Excel dan file Read-only; setelah hambatan dilepas ekspor berhasil kembali.
- Screenshot terbaru diambil langsung dari form dengan tampilan terbaru, tanpa penunjuk kursor.

Tiga screenshot yang disertakan dalam ZIP:

1. dokumentasi/form dengan ikon ErrorProvider pada beberapa isian yang salah.jpg
2. dokumentasi/lstPeminjaman berisi minimal tiga peminjaman.jpg
3. dokumentasi/pesan yang muncul ketika ekspor gagal karena file sedang dibuka di Excel.jpg

Screenshot pertama memperlihatkan kesalahan pada kode buku, nama yang terlalu pendek, dan lama pinjam 15 hari. Screenshot kedua memperlihatkan tiga peminjaman beserta tanggal kembali. Screenshot ketiga adalah dialog kegagalan ekspor saat CSV benar-benar sedang dibuka di Excel.

Dokumentasi ekspor memakai CSV uji di workspace karena penulisan Documents dibatasi pada komputer ini. Form dan handler berasal dari assembly aplikasi; lokasi file dan data awal disiapkan melalui fixture terpisah yang tidak ikut dalam ZIP.

Arsip sebelum perbaikan nama form dan pembaruan screenshot disimpan di folder cadangan.
