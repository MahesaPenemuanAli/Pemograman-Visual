# Tugas 08 - Inventaris Buku Perpustakaan

Nama: Mahesa Penemuan Ali  
NIM: 241712064  
Mata kuliah: Pemrograman Visual

## Menjalankan aplikasi

1. Buka `Inventaris Buku Perpustakaan_Tugas8.slnx` di Visual Studio yang mendukung .NET 10 dan Windows Forms VB.NET.
2. Buka `Form1.vb` dengan **View Designer / Shift+F7** untuk melihat rancangan form.
3. Tekan **F5** atau **Ctrl+F5** untuk menjalankan aplikasi.

Build dari folder solution ini:

```powershell
dotnet build ".\Inventaris Buku Perpustakaan_Tugas8\Inventaris Buku Perpustakaan_Tugas8.vbproj"
```

Proyek menggunakan `net10.0-windows` dan `Option Strict On`. Semua kontrol, `bsBuku`, dan `errBuku` dideklarasikan di `Form1.Designer.vb` dan dapat diedit melalui Designer.

## Acuan materi dan source perkuliahan

| Materi / source yang sudah dipelajari | Penggunaan pada tugas |
| --- | --- |
| Pertemuan 1-2: komponen visual, properti, naming convention, event | Label, TextBox, ComboBox, Button, CheckBox, GroupBox, dan DataGridView di Designer |
| Pertemuan 3-4: tipe data, operator, If, Select Case, TryParse, perulangan | Validasi kode/tahun/stok, penyusunan filter, pemeriksaan kode unik, dan penjumlahan stok |
| Pertemuan 5: Module, Sub, Function | Pemisahan fungsi validasi, pengaman filter, pengaturan kolom, dan ringkasan |
| `Form Peminjaman Buku/Form Peminjaman Buku/Form1.vb` | Pola `ValidasiInput() As Boolean`, `errBuku.Clear()`, `SetError()`, dan pembersihan isian setelah tambah |
| `Form Peminjaman Buku/Form Peminjaman Buku/ModValidasi.vb` | Fungsi `SemuaDigit()` dan `KodeBukuValid()`; fungsi CSV tidak disertakan karena tidak digunakan |
| `DataMahasiswa/DataMahasiswa/FrmDataTable.vb` | Pembuatan DataTable bertipe, Rows.Add, binding lewat BindingSource, Filter, FillWeight, dan perataan kolom |
| `DataMahasiswa/DataMahasiswa/ModPencarian.vb` | Fungsi `AmankanTeksFilter()` untuk tanda kutip dan karakter wildcard |

Acuan source di atas berada di folder lain pada repository perkuliahan. Tugas ini memperluas contoh tersebut dengan filter teks **AND** kategori, pemeriksaan kode pada `DataTable.Rows`, dan total stok melalui `DataGridView.Rows`.

Kode aplikasi memakai materi dasar tersebut, tanpa database, LINQ, regex, atau paket eksternal. Data buku merupakan data contoh latihan dan disimpan di memori selama aplikasi berjalan. Ketika aplikasi dibuka kembali, data kembali ke sepuluh buku awal.

## Struktur dan cara kerja

- `Form1.Designer.vb`: rancangan semua kontrol, item ComboBox, properti grid, BindingSource, dan ErrorProvider.
- `Form1.vb`: tabel awal, pengaturan kolom, validasi, tambah buku, filter gabungan, ringkasan, serta pengurutan.
- `ModValidasi.vb`: pemeriksaan format kode `BK` diikuti empat angka ASCII 0-9.
- `ModPencarian.vb`: pengamanan karakter `'`, `[`, `]`, `*`, dan `%` agar dibaca sebagai teks pencarian.
- `tugas.md`: salinan petunjuk tugas yang diberikan.
- `dokumentasi`: empat screenshot hasil serta catatan verifikasi.

`ValidasiInput()` memeriksa semua isian sekaligus. Kode di-Trim dan diubah menjadi huruf besar; keunikannya diperiksa melalui perulangan seluruh `tabelBuku.Rows`, termasuk buku yang tersembunyi oleh filter. Tahun harus 1900 sampai `Date.Today.Year`, sedangkan stok harus bilangan bulat 0 sampai batas tipe Integer. Penambahan menggunakan `tabelBuku.Rows.Add(...)`, sehingga grid diperbarui oleh binding yang sama.

`TerapkanFilter()` menyusun satu ekspresi, misalnya:

```vb
(Judul LIKE '%an%' OR Penulis LIKE '%an%') AND Kategori = 'Fiksi'
```

Jika pencarian kosong, kategori Semua, dan filter stok habis tidak dicentang, `RemoveFilter()` menampilkan semua buku. Tombol **Bersihkan Isian** hanya membersihkan data buku baru dan ikon error; pilihan pencarian tetap aktif. Buku yang ditambah tetap tersimpan meskipun tidak memenuhi filter yang sedang aktif.

`PerbaruiRingkasan()` mengambil jumlah hasil dari BindingSource dan menjumlahkan stok melalui `For Each baris As DataGridViewRow In dgvBuku.Rows`. Penampung total memakai `Long` agar penjumlahan beberapa stok Integer yang besar tidak melampaui batas Integer.

Kedua tantangan tambahan tersedia: **Urutkan buku** mengatur `bsBuku.Sort`, sedangkan **Hanya stok habis** menambahkan `AND Stok = 0` pada filter yang sama.

## Contoh penggunaan dan screenshot

1. Tambahkan `BK0011`, judul `Belajar Visual Basic`, penulis `Andi Pratama`, kategori **Referensi**, tahun `2026`, stok `4`. Grid menjadi **11 dari 11 buku**, total stok **44 eksemplar**. Lihat `dokumentasi/01-tambah-buku.png`.
2. Masukkan data yang sama lagi dan klik Tambah Buku. Ikon ErrorProvider muncul di kode buku; jumlah tetap 11 dan stok tetap 44. Lihat `dokumentasi/02-kode-ganda-errorprovider.png`.
3. Klik Bersihkan Isian, cari `an`, lalu pilih kategori **Fiksi**. Hasilnya **2 dari 11 buku**, total stok **8 eksemplar**: Laskar Pelangi (8) dan Bumi Manusia (0). Lihat `dokumentasi/03-pencarian-gabungan.png`.
4. Ganti teks pencarian menjadi `'`. Aplikasi tetap berjalan, hasil **0 dari 11 buku** dan stok **0 eksemplar**, karena tidak ada judul atau penulis Fiksi yang mengandung tanda tersebut. Lihat `dokumentasi/04-pencarian-tanda-kutip.png`.

Screenshot menampilkan form aplikasi saat dijalankan, bukan gambar rancangan. Pengambilan ulang menggunakan assembly proyek utama melalui fixture dokumentasi dan menangkap jendela form tanpa menyertakan kursor desktop atau sorotan kursor GPT.

## Hasil verifikasi - 31 Oktober 2026

- Build aplikasi: **berhasil, 0 warning, 0 error**.
- Form terbuka di **Designer Visual Studio**, termasuk komponen `bsBuku` dan `errBuku`.
- **107 pemeriksaan lulus** terhadap assembly aplikasi. Rinciannya ada di `dokumentasi/hasil-verifikasi.txt`.
- Pemeriksaan mencakup data awal, binding, properti kolom, semua isian kosong, format kode salah, kode ganda yang tersembunyi filter, batas tahun/stok, tambah tanpa mengisi ulang grid, pembersihan, filter gabungan, pencarian penulis, hasil kosong, kutip/wildcard literal, total stok besar, dan kedua fitur bonus.
- Pengujian kode menggunakan fixture terpisah di `.verifikasi`; kode fixture dan hasil build tidak dimasukkan ke ZIP source.
- Empat skenario screenshot juga dijalankan melalui antarmuka aplikasi utama.

## Pengumpulan

Arsip: `241712064_Mahesa_Penemuan_Ali_Tugas08.zip`.

ZIP memuat solution, source proyek, petunjuk, dokumentasi, dan empat screenshot. Folder `bin`, `obj`, `.vs`, `.verifikasi`, serta pengaturan pribadi Visual Studio tidak disertakan. Arsip disiapkan secara lokal untuk dikumpulkan ke LMS.
