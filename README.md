# 🖥️ Catatan & Log Praktikum: Pemrograman Visual (Visual Basic .NET)

[![Mata Kuliah - Pemrograman Visual](https://img.shields.io/badge/Mata%20Kuliah-Pemrograman%20Visual-007ACC?style=for-the-badge&logo=visualstudio&logoColor=white)](.)
[![Program Studi - D3 Teknik Informatika](https://img.shields.io/badge/Prodi-D3%20Teknik%20Informatika-3776AB?style=for-the-badge)](.)
[![Institusi - Universitas Sumatera Utara](https://img.shields.io/badge/Institusi-Universitas%20Sumatera%20Utara-2E7D32?style=for-the-badge)](.)
[![Tahun Ajaran - 2026/2027](https://img.shields.io/badge/Tahun%20Ajaran-2026%2F2027-gray?style=for-the-badge)](.)

Dokumentasi komprehensif, catatan materi, dan implementasi kode praktikum **Pemrograman Visual** menggunakan platform **Visual Studio (.NET / Windows Forms)** pada Program Studi D3 Teknik Informatika, Universitas Sumatera Utara.

---

## 📑 Daftar Isi

* [Pertemuan 01: Pengantar Pemrograman Visual & Setup Environment](#pertemuan-01-pengantar-pemrograman-visual--setup-environment)

  * [Konsep Dasar Visual Programming](#konsep-dasar-visual-programming)
  * [Karakteristik & Paradigma](#karakteristik--paradigma)
  * [Komparasi Kelebihan dan Keterbatasan](#komparasi-kelebihan-dan-keterbatasan)
  * [Ekosistem & Platform Populer](#ekosistem--platform-populer)
  * [Panduan Instalasi Visual Studio Community](#panduan-instalasi-visual-studio-community)

* [Pertemuan 02: Arsitektur GUI, Komponen Dasar, dan Event Handling](#pertemuan-02-arsitektur-gui-komponen-dasar-dan-event-handling)

  * [Konsep Antarmuka Grafis (GUI)](#konsep-antarmuka-grafis-gui)
  * [Komponen Dasar & Konvensi Penamaan (Prefix)](#komponen-dasar--konvensi-penamaan-prefix)
  * [Daftar Properti Esensial](#daftar-properti-esensial)
  * [Mekanisme Event-Driven Programming](#mekanisme-event-driven-programming)
  * [Alur Pembuatan Project Windows Forms (VB)](#alur-pembuatan-project-windows-forms-vb)
  * [Sintaks Dasar & Contoh Implementasi](#sintaks-dasar--contoh-implementasi)

* [Pertemuan 03: Operator, Struktur Kendali, dan Validasi Input](#pertemuan-03-operator-struktur-kendali-dan-validasi-input)

  * [Konsep Dasar Operator](#konsep-dasar-operator)
  * [Struktur Percabangan If...Then](#struktur-percabangan-ifthen)
  * [Contoh Implementasi Penilaian](#contoh-implementasi-penilaian)
  * [Validasi Input dengan Integer.TryParse](#validasi-input-dengan-integertryparse)
  * [Validasi Rentang Nilai](#validasi-rentang-nilai)
  * [Pembatasan Input Menggunakan KeyPress](#pembatasan-input-menggunakan-keypress)
  * [Komponen yang Digunakan](#komponen-yang-digunakan)

* [Pertemuan 04: Struktur Percabangan dan Perulangan](#pertemuan-04-struktur-percabangan-dan-perulangan)

  * [Konsep Perulangan](#konsep-perulangan)
  * [Perulangan dengan Nilai Menaik](#perulangan-dengan-nilai-menaik)
  * [Perulangan dengan Step -1](#perulangan-dengan-step--1)
  * [Implementasi Lengkap](#implementasi-lengkap)
  * [Struktur Logika Program](#struktur-logika-program)
  * [Komponen yang Digunakan](#komponen-yang-digunakan-1)

* [Pertemuan 05: Modul, Fungsi, dan Array](#pertemuan-05-modul-fungsi-dan-array)

  * [Konsep Modul](#konsep-modul)
  * [Procedure](#procedure)
  * [Function](#function)
  * [Perbedaan Sub dan Function](#perbedaan-sub-dan-function)
  * [Konsep Array](#konsep-array)
  * [Array Dua Dimensi](#array-dua-dimensi)
  * [Perulangan Array](#perulangan-array)
  * [Konsep Modularisasi](#konsep-modularisasi)

* [Pertemuan 06: Koneksi Database PostgreSQL dan CRUD Dasar](#pertemuan-06-koneksi-database-postgresql-dan-crud-dasar)

  * [Konsep Database](#konsep-database)
  * [Npgsql](#npgsql)
  * [Connection String](#connection-string)
  * [Membaca Connection String](#membaca-connection-string)
  * [Membuka Koneksi Database](#membuka-koneksi-database)
  * [Mengambil Data dari Database](#mengambil-data-dari-database)
  * [Menjalankan Query INSERT](#menjalankan-query-insert)
  * [Fungsi Eksekusi Query](#fungsi-eksekusi-query)
  * [Menampilkan Data ke DataGridView](#menampilkan-data-ke-datagridview)
  * [Menambahkan Data Mahasiswa](#menambahkan-data-mahasiswa)
  * [Komponen Windows Forms yang Digunakan](#komponen-windows-forms-yang-digunakan)
  * [Alur CRUD yang Dipraktikkan](#alur-crud-yang-dipraktikkan)
  * [Struktur File Pertemuan 06](#struktur-file-pertemuan-06)
  * [Pembagian Tanggung Jawab File](#pembagian-tanggung-jawab-file)

* [Referensi Shortcut Visual Studio](#referensi-shortcut-visual-studio)


---

## Pertemuan 01: Pengantar Pemrograman Visual & Setup Environment

### Konsep Dasar Visual Programming

**Visual Programming** adalah paradigma pengembangan perangkat lunak yang memanfaatkan elemen-elemen grafis (seperti ikon, blok, diagram, form, dan kontrol UI) untuk menyusun logika serta alur program, meminimalkan kebutuhan penulisan kode sintaks mentah secara manual di tahap awal perancangan.

### Karakteristik & Paradigma

* **Visual & Diagrammatic:** Logika bisnis dan tata letak aplikasi direpresentasikan dalam bentuk diagram alir atau kanvas visual.
* **Rapid Application Development (RAD):** Mempercepat pembuatan prototipe antarmuka menggunakan pendekatan *Drag-and-Drop*.
* **WYSIWYG (What You See Is What You Get):** Tampilan visual yang dirancang pada mode *Design View* identik dengan output saat program dieksekusi (*Runtime*).
* **Feedback Instan:** Evaluasi perubahan antarmuka atau alur logika dapat langsung diuji secara interaktif tanpa kompilasi manual bertingkat yang rumit.

### Komparasi Kelebihan dan Keterbatasan

| Kelebihan | Keterbatasan |
|---|---|
| Mempercepat pemahaman algoritma dan logika program bagi pemula. | Kurang fleksibel untuk kontrol sistem level rendah (*low-level computing*). |
| Mereduksi risiko kesalahan penulisan (*syntax error*) secara signifikan. | Overhead konsumsi memori dan dependensi runtime yang relatif lebih besar. |
| Mempercepat proses perancangan *User Interface* (UI). | Ketergantungan tinggi terhadap ekosistem IDE / vendor tertentu (*vendor lock-in*). |

### Ekosistem & Platform Populer

| Platform | Basis / Target | Karakteristik Utama |
|---|---|---|
| **Scratch** | Web / Educational | Berbasis visual block, dirancang untuk pengenalan dasar logika komputasi. |
| **MIT App Inventor** | Mobile (Android) | Block programming untuk pengembangan aplikasi mobile secara cepat. |
| **Visual Studio (VB.NET)** | Desktop (.NET) | Lingkungan IDE profesional berbasis Event-Driven GUI untuk sistem enterprise/desktop. |
| **JavaFX (Scene Builder)** | Desktop (Java Ecosystem) | Pemisahan layout deklaratif (FXML) dan kontroler logika berbasis Java OOP. |

### Panduan Instalasi Visual Studio Community

1. **Unduh Installer:** Kunjungi portal resmi [visualstudio.microsoft.com](https://visualstudio.microsoft.com/) dan unduh **Visual Studio Community** (versi 2022 atau rilis stabil terbaru).
2. **Konfigurasi Workload:** Buka **Visual Studio Installer**, pada tab *Workloads*, centang opsi:
   * `📁 .NET Desktop Development`
3. **Verifikasi Komponen Tambahan (Installation Details):**
   * Pastikan *.NET Framework SDK*, *Visual Basic runtime support*, serta *Blend for Visual Studio* masuk ke dalam daftar dependensi yang tercentang.
4. **Eksekusi Instalasi:** Klik tombol **Install / Modify** di pojok kanan bawah dan berikan izin administrator (*Allow*) hingga seluruh proses selesai (*All installations are up to date*).

---

## Pertemuan 02: Arsitektur GUI, Komponen Dasar, dan Event Handling

### Konsep Antarmuka Grafis (GUI)

Aplikasi Windows Forms dibangun di atas struktur hierarki kontrol visual. **Form** bertindak sebagai *Top-Level Container* (wadah kanvas utama), sementara kontrol-kontrol interaktif ditempatkan di atasnya untuk menerima masukan, memproses data, dan menampilkan luaran.

### Komponen Dasar & Konvensi Penamaan (Prefix)

Penerapan standar penamaan komponen (*Hungarian Notation / Prefix*) mempermudah pembacaan kode saat menangani banyak kontrol:

| Komponen | Prefix Standar | Deskripsi & Fungsi Utama |
|---|---|---|
| **Form** | `frm` | Jendela utama aplikasi tempat seluruh kontrol visual ditampung. |
| **Label** | `lbl` | Menampilkan teks deskriptif/statis; umumnya bersifat *read-only* bagi pengguna akhir. |
| **TextBox** | `txt` | Bidang input untuk menerima data alfanumerik dari pengguna. |
| **Button** | `btn` | Elemen pemicu aksi (*trigger*) saat pengguna melakukan klik. |

### Daftar Properti Esensial

Pengaturan properti dapat dilakukan melalui jendela **Properties Window (`F4`)**:

| Properti | Tipe Data / Nilai | Fungsi |
|---|---|---|
| `(Name)` | String (Identifier) | Identitas variabel kontrol yang digunakan dalam file kode (`.vb`). |
| `Text` | String | Nilai teks yang tampil langsung pada antarmuka pengguna. |
| `StartPosition` | Enum (`CenterScreen`, dll.) | Menentukan posisi kemunculan Form saat aplikasi pertama kali dijalankan. |
| `BackColor` | Color | Warna latar belakang pada kontrol atau Form. |
| `ForeColor` | Color | Warna teks/font pada kontrol. |
| `Font` | Font Dialog | Menentukan famili font, ukuran (*size*), ketebalan (*Bold*), dan gaya teks. |
| `Enabled` | Boolean (`True` / `False`) | Mengatur apakah kontrol dapat merespons interaksi pengguna. |
| `Visible` | Boolean (`True` / `False`) | Mengatur visibilitas kontrol di layar (ditampilkan atau disembunyikan). |

### Mekanisme Event-Driven Programming

Program berbasis GUI tidak berjalan secara linier dari baris atas ke bawah, melainkan beroperasi secara **Event-Driven**: program menunggu aksi dari pengguna (seperti `Click`, `TextChanged`, `MouseEnter`, atau `Form_Load`) lalu menjalankan blok kode yang terhubung (*Event Handler*).

### Alur Pembuatan Project Windows Forms (VB)

1. Jalankan **Visual Studio**, pilih **Create a new project**.
2. Filter bahasa ke **Visual Basic**, platform ke **Windows**, dan jenis project ke **Desktop**.
3. Pilih template **Windows Forms App (.NET)**.
4. Tentukan **Project Name**, pilih direktori penyimpanan, lalu centang **"Place solution and project in the same directory"** untuk struktur folder terpadu.
5. Tentukan target framework ke versi **LTS (Long Term Support)** stabil, kemudian klik **Create**.
6. IDE akan membuka `Form1.vb [Design]` yang siap dikustomisasi.

### Sintaks Dasar & Contoh Implementasi

| Sintaks / Fitur | Deskripsi |
|---|---|
| `MessageBox.Show(pesan, judul, tombol, ikon)` | Menampilkan kotak dialog modal/popup informasi kepada pengguna. |
| `&` | Operator konkatenasi (penggabung dua string atau variabel teks). |
| `vbCrLf` / `Environment.NewLine` | Karakter pembuat baris baru (*line-break/enter*). |
| `kontrol.Clear()` | Menghapus isi nilai teks pada TextBox secara instan. |

#### Contoh Potongan Kode: Event Klik Tombol Simpan

```vb
Public Class frmUtama
    ' Event Handler saat Button Simpan diklik
    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        ' Mengambil nilai dari TextBox
        Dim namaMahasiswa As String = txtNama.Text
        Dim nimMahasiswa As String = txtNIM.Text

        ' Validasi input sederhana
        If String.IsNullOrWhiteSpace(namaMahasiswa) Then
            MessageBox.Show("Nama tidak boleh kosong!", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNama.Focus()
            Exit Sub
        End If

        ' Penggabungan string menggunakan & dan vbCrLf
        Dim infoOutput As String = "Data Berhasil Disimpan:" & vbCrLf &
                                   "Nama: " & namaMahasiswa & vbCrLf &
                                   "NIM: " & nimMahasiswa

        ' Menampilkan kotak dialog konfirmasi
        MessageBox.Show(infoOutput, "Informasi Registrasi", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Reset form input
        txtNama.Clear()
        txtNIM.Clear()
        txtNama.Focus()
    End Sub
End Class

## Pertemuan 03: Operator, Struktur Kendali, dan Validasi Input

### Konsep Dasar Operator

Operator digunakan untuk melakukan perhitungan, perbandingan, serta pengujian kondisi dalam program. Dalam Visual Basic .NET, operator sangat sering digunakan bersama struktur kendali seperti `If...Then`, `ElseIf`, dan `Else`.

Jenis operator yang umum digunakan:

| Jenis Operator | Contoh                                  | Fungsi                              |
| -------------- | --------------------------------------- | ----------------------------------- |
| Aritmatika     | `+`, `-`, `*`, `/`                      | Melakukan operasi matematika        |
| Perbandingan   | `=`, `<>`, `<`, `>`, `<=`, `>=`         | Membandingkan dua nilai             |
| Logika         | `And`, `Or`, `Not`, `AndAlso`, `OrElse` | Menggabungkan atau membalik kondisi |
| Assignment     | `=`                                     | Memberikan nilai ke variabel        |

### Struktur Percabangan `If...Then`

Struktur `If` digunakan ketika program harus memilih tindakan berdasarkan kondisi tertentu.

```vb
If kondisi Then
    'Kode yang dijalankan jika kondisi benar
ElseIf kondisiLain Then
    'Kode jika kondisi pertama salah
Else
    'Kode jika seluruh kondisi sebelumnya salah
End If
```

### Contoh Implementasi Penilaian

Pada praktikum, nilai ujian digunakan sebagai dasar untuk menentukan gambar yang ditampilkan.

```vb
Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
    Dim nilaiUjian As Integer

    If Not Integer.TryParse(txtNilai.Text, nilaiUjian) Then
        MessageBox.Show("Masukkan dalam bentuk angka")
        txtNilai.Focus()
        Return
    End If

    If nilaiUjian < 0 OrElse nilaiUjian > 100 Then
        MessageBox.Show("Masukkan nilai 0 - 100")
        txtNilai.Focus()
        Return
    End If

    If nilaiUjian <= 50 Then
        picImage.Image = Image.FromFile("Assets\1.png")
    ElseIf nilaiUjian <= 75 Then
        picImage.Image = Image.FromFile("Assets\2.png")
    Else
        picImage.Image = Image.FromFile("Assets\3.png")
    End If
End Sub
```

### Validasi Input dengan `Integer.TryParse`

`Integer.TryParse()` digunakan untuk memastikan input dari `TextBox` dapat dikonversi menjadi bilangan bulat.

```vb
Dim nilaiUjian As Integer

If Not Integer.TryParse(txtNilai.Text, nilaiUjian) Then
    MessageBox.Show("Masukkan dalam bentuk angka")
    txtNilai.Focus()
    Return
End If
```

Keunggulannya adalah program dapat menangani input yang bukan angka tanpa menyebabkan program berhenti karena kesalahan konversi.

### Validasi Rentang Nilai

Nilai ujian dibatasi pada rentang 0 sampai 100.

```vb
If nilaiUjian < 0 OrElse nilaiUjian > 100 Then
    MessageBox.Show("Masukkan nilai 0 - 100")
    txtNilai.Focus()
    Return
End If
```

Operator `OrElse` digunakan untuk mengecek apakah salah satu dari dua kondisi bernilai benar.

### Pembatasan Input Menggunakan `KeyPress`

Selain validasi ketika tombol ditekan, input dapat dibatasi sejak pengguna mengetik.

```vb
Private Sub txtNilai_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNilai.KeyPress
    If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
        e.Handled = True
    End If
End Sub
```

Kode tersebut hanya mengizinkan karakter angka dan tombol kontrol seperti Backspace.

### Komponen yang Digunakan

| Komponen     | Fungsi                               |
| ------------ | ------------------------------------ |
| `TextBox`    | Menerima input nilai                 |
| `Button`     | Menjalankan proses input             |
| `PictureBox` | Menampilkan gambar berdasarkan nilai |
| `MessageBox` | Menampilkan pesan kesalahan          |
| `KeyPress`   | Membatasi karakter yang dimasukkan   |

### Kesimpulan Pertemuan 03

Pada pertemuan ini dipelajari penggunaan operator, struktur percabangan, validasi data, serta event `KeyPress`. Konsep tersebut menjadi dasar untuk membuat aplikasi yang mampu mengambil keputusan berdasarkan input pengguna.

---

## Pertemuan 04: Struktur Percabangan dan Perulangan

### Konsep Perulangan

Perulangan digunakan untuk menjalankan blok kode secara berulang selama kondisi tertentu terpenuhi.

Salah satu struktur perulangan yang digunakan pada praktikum adalah:

```vb
For ... Next
```

Struktur dasarnya:

```vb
For variabel = nilaiAwal To nilaiAkhir
    'Kode yang diulang
Next
```

### Perulangan dengan Nilai Menaik

```vb
For i As Integer = nilaiAwal To nilaiAkhir
    lstHasil.Items.Add(i)
Next
```

Jika nilai awal lebih kecil daripada nilai akhir, angka akan ditampilkan secara berurutan dari kecil ke besar.

Contoh:

```text
Nilai Awal = 1
Nilai Akhir = 5
```

Hasil:

```text
1
2
3
4
5
```

### Perulangan dengan `Step -1`

Visual Basic memungkinkan arah perulangan dibalik menggunakan `Step`.

```vb
For i As Integer = nilaiAwal To nilaiAkhir Step -1
    lstHasil.Items.Add(i)
Next
```

Jika nilai awal lebih besar daripada nilai akhir, nilai akan ditampilkan secara menurun.

Contoh:

```text
Nilai Awal = 5
Nilai Akhir = 1
```

Hasil:

```text
5
4
3
2
1
```

### Implementasi Lengkap

```vb
Private Sub btnInput_Click(sender As Object, e As EventArgs) Handles btnInput.Click
    Dim nilaiAwal As Integer
    Dim nilaiAkhir As Integer

    If Not Integer.TryParse(txtNilaiAwal.Text, nilaiAwal) Then
        MessageBox.Show("Masukan dalam bentuk angka")
        txtNilaiAwal.Focus()
        Return
    End If

    If Not Integer.TryParse(txtNilaiAkhir.Text, nilaiAkhir) Then
        MessageBox.Show("Masukan dalam bentuk angka")
        txtNilaiAkhir.Focus()
        Return
    End If

    lstHasil.Items.Clear()

    If nilaiAwal < nilaiAkhir Then
        For i As Integer = nilaiAwal To nilaiAkhir
            lstHasil.Items.Add(i)
        Next
    Else
        For i As Integer = nilaiAwal To nilaiAkhir Step -1
            lstHasil.Items.Add(i)
        Next
    End If
End Sub
```

### Struktur Logika Program

Alur program dapat digambarkan sebagai:

```text
Input Nilai Awal dan Nilai Akhir
            ↓
     Validasi Input
            ↓
  Apakah Awal < Akhir?
       ↙           ↘
     Ya             Tidak
      ↓               ↓
  For menaik      For menurun
      ↓               ↓
      └──────→ Tampilkan hasil
```

### Komponen yang Digunakan

| Komponen    | Fungsi                       |
| ----------- | ---------------------------- |
| `TextBox`   | Input nilai awal dan akhir   |
| `Button`    | Menjalankan proses           |
| `ListBox`   | Menampilkan hasil perulangan |
| `If...Else` | Menentukan arah perulangan   |

### Kesimpulan Pertemuan 04

Pada pertemuan ini dipelajari hubungan antara struktur percabangan dan perulangan. Percabangan menentukan kondisi yang harus dijalankan, sedangkan `For...Next` digunakan untuk menjalankan proses secara berulang.

---

## Pertemuan 05: Modul, Fungsi, dan Array

### Konsep Modul

`Module` digunakan untuk mengelompokkan prosedur, fungsi, variabel, atau data yang dapat digunakan oleh bagian lain dalam aplikasi.

Contoh:

```vb
Module ModArray

End Module
```

Penggunaan modul membantu memisahkan logika program sehingga kode menjadi lebih terstruktur dan mudah digunakan kembali.

### Procedure

Procedure adalah blok kode yang menjalankan suatu pekerjaan tertentu.

```vb
Public Sub TampilkanPesan(nama As String)
    MessageBox.Show("Halo " & nama)
End Sub
```

Procedure tidak mengembalikan nilai menggunakan `Return`.

### Function

`Function` mirip dengan `Sub`, tetapi menghasilkan nilai sebagai output.

```vb
Function Hitung(panjang As Integer, lebar As Integer) As Integer
    If panjang <= 50 Then
        Return 2 * panjang + 2 * lebar
    Else
        Return panjang * lebar
    End If
End Function
```

Cara memanggil fungsi:

```vb
Dim hasil As Integer
hasil = Hitung(20, 10)

MessageBox.Show(hasil.ToString())
```

### Perbedaan `Sub` dan `Function`

| Fitur                | `Sub`                     | `Function`         |
| -------------------- | ------------------------- | ------------------ |
| Mengembalikan nilai  | Tidak                     | Ya                 |
| Menggunakan `Return` | Tidak sebagai nilai hasil | Ya                 |
| Contoh               | `TampilkanPesan()`        | `Hitung()`         |
| Tujuan               | Menjalankan proses        | Menghasilkan nilai |

### Konsep Array

Array digunakan untuk menyimpan beberapa nilai dengan tipe data yang sama dalam satu variabel.

Contoh array satu dimensi:

```vb
Public nilai() As Integer = {50, 60, 70, 80, 90}
```

Data tersebut memiliki beberapa elemen yang dapat diakses berdasarkan indeks.

Visual Basic menggunakan indeks yang dimulai dari `0`.

```text
Indeks :  0   1   2   3   4
Nilai  : 50  60  70  80  90
```

Contoh akses:

```vb
MessageBox.Show(nilai(2).ToString())
```

Hasil:

```text
70
```

### Array Dua Dimensi

Array juga dapat memiliki dua dimensi seperti tabel.

```vb
Public nilai2D(,) As Integer = {
    {55, 58, 65},
    {70, 75, 82},
    {84, 86, 90}
}
```

Struktur datanya:

| Indeks  | Kolom 0 | Kolom 1 | Kolom 2 |
| ------- | ------: | ------: | ------: |
| Baris 0 |      55 |      58 |      65 |
| Baris 1 |      70 |      75 |      82 |
| Baris 2 |      84 |      86 |      90 |

Untuk mengambil nilai tertentu:

```vb
MessageBox.Show(nilai2D(1, 2).ToString())
```

Hasilnya:

```text
82
```

### Perulangan Array

Array dapat diproses menggunakan perulangan.

```vb
For i As Integer = 0 To nilai.Length - 1
    lstNilai.Items.Add(nilai(i))
Next
```

`Length` digunakan untuk mengetahui jumlah elemen pada array.

### Konsep Modularisasi

Pembagian program menjadi beberapa bagian memberikan beberapa manfaat:

* Kode lebih terorganisasi.
* Fungsi dapat digunakan kembali.
* Pemeliharaan program lebih mudah.
* Logika program dapat dipisahkan berdasarkan tugasnya.

### Kesimpulan Pertemuan 05

Pada pertemuan ini dipelajari konsep `Module`, `Sub`, `Function`, array satu dimensi, dan array dua dimensi. Materi ini menjadi dasar penting untuk membangun program yang lebih terstruktur dan dapat digunakan kembali.

---

## Pertemuan 06: Koneksi Database PostgreSQL dan CRUD Dasar

### Konsep Database

Database digunakan untuk menyimpan data aplikasi secara permanen. Pada praktikum ini aplikasi Windows Forms dihubungkan dengan database PostgreSQL menggunakan library **Npgsql**.

Arsitektur sederhana yang digunakan:

```text
Windows Forms
      ↓
   ModQuery
      ↓
 ModFunction
      ↓
 ModDatabase
      ↓
 PostgreSQL
```

Pembagian tersebut membuat kode database lebih terstruktur.

### Npgsql

**Npgsql** adalah provider .NET yang digunakan untuk berkomunikasi dengan PostgreSQL.

Pada project digunakan package:

```xml
<PackageReference Include="Npgsql" Version="10.0.3" />
```

Konfigurasi JSON digunakan untuk membaca connection string:

```xml
<PackageReference Include="Microsoft.Extensions.Configuration.Json" Version="10.0.12" />
```

### Connection String

Connection string disimpan dalam file `appsettings.json`.

Contoh struktur yang aman untuk dokumentasi:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=HOST;Port=5432;Database=DATABASE;Username=USERNAME;Password=PASSWORD;SSL Mode=Require;Trust Server Certificate=true"
  }
}
```

Untuk project nyata, password database sebaiknya tidak ditulis langsung ke repository GitHub atau README.

### Membaca Connection String

```vb
Imports Microsoft.Extensions.Configuration

Module ModDatabase

    Public Function GetConnectionString() As String
        Dim config As IConfiguration =
            New ConfigurationBuilder() _
            .SetBasePath(AppContext.BaseDirectory) _
            .AddJsonFile("Appsettings.json", optional:=False, reloadOnChange:=True) _
            .Build()

        Return config.GetConnectionString("DefaultConnection")
    End Function

End Module
```

Fungsi tersebut membaca konfigurasi database dari `appsettings.json`.

### Membuka Koneksi Database

```vb
Imports Npgsql

Public Sub DatabaseKoneksi()
    Try
        Using conn As New NpgsqlConnection(GetConnectionString)
            conn.Open()

            MessageBox.Show("Koneksi database berhasil")
        End Using

    Catch ex As Exception
        MessageBox.Show(
            "Koneksi database gagal" &
            vbCrLf &
            ex.Message
        )
    End Try
End Sub
```

`Using` digunakan agar koneksi database otomatis ditutup setelah selesai digunakan.

### Mengambil Data dari Database

Fungsi `AmbilData()` digunakan untuk menjalankan query `SELECT` dan mengembalikan hasil dalam bentuk `DataTable`.

```vb
Public Function AmbilData(query As String) As DataTable
    Dim dt As New DataTable

    Try
        Using conn As New NpgsqlConnection(ModDatabase.GetConnectionString())
            conn.Open()

            Using cmd As New NpgsqlCommand(query, conn)
                Using adapter As New NpgsqlDataAdapter(cmd)
                    adapter.Fill(dt)
                End Using
            End Using
        End Using

    Catch ex As Exception
        MessageBox.Show(
            "Gagal mengambil data" &
            vbCrLf &
            ex.Message,
            "Error Database"
        )
    End Try

    Return dt
End Function
```

### Menjalankan Query `INSERT`

Untuk menambahkan data mahasiswa digunakan query dengan parameter.

```vb
Public Function TambahData(
    nim As String,
    nama As String,
    jurusan As String
) As Boolean

    Dim query As String =
        "INSERT INTO mahasiswa (nim, nama, jurusan) " &
        "VALUES (@nim, @nama, @jurusan)"

    Dim parameters As New Dictionary(Of String, Object) From {
        {"@nim", nim},
        {"@nama", nama},
        {"@jurusan", jurusan}
    }

    Return ModFunction.EksekusiData(query, parameters)
End Function
```

Penggunaan parameter seperti `@nim`, `@nama`, dan `@jurusan` lebih aman dibandingkan menggabungkan input pengguna langsung ke string SQL.

### Fungsi Eksekusi Query

```vb
Public Function EksekusiData(
    query As String,
    parameters As Dictionary(Of String, Object)
) As Boolean

    Try
        Using conn As New NpgsqlConnection(
            ModDatabase.GetConnectionString()
        )
            conn.Open()

            Using cmd As New NpgsqlCommand(query, conn)

                For Each parameter In parameters
                    cmd.Parameters.AddWithValue(
                        parameter.Key,
                        parameter.Value
                    )
                Next

                cmd.ExecuteNonQuery()
                Return True
            End Using
        End Using

    Catch ex As Exception
        MessageBox.Show(
            "Gagal mengeksekusi data:" &
            vbCrLf &
            ex.Message,
            "Error Database"
        )

        Return False
    End Try

End Function
```

### Menampilkan Data ke `DataGridView`

```vb
Private Sub btnTampil_Click(
    sender As Object,
    e As EventArgs
) Handles btnTampil.Click

    dgvMahasiswa.AutoGenerateColumns = True
    dgvMahasiswa.DataSource = ModQuery.TampilkanData()

End Sub
```

Fungsi query untuk menampilkan data:

```vb
Public Function TampilkanData() As DataTable
    Return ModFunction.AmbilData(
        "SELECT * FROM mahasiswa ORDER BY id ASC"
    )
End Function
```

### Menambahkan Data Mahasiswa

```vb
Private Sub btnTambah_Click(
    sender As Object,
    e As EventArgs
) Handles btnTambah.Click

    If ModQuery.TambahData(
        txtNIM.Text,
        txtNama.Text,
        txtJurusan.Text
    ) Then

        MessageBox.Show("Data berhasil ditambahkan")

    End If

    txtJurusan.Clear()
    txtNIM.Clear()
    txtNama.Clear()

End Sub
```

### Komponen Windows Forms yang Digunakan

| Komponen            | Fungsi                               |
| ------------------- | ------------------------------------ |
| `TextBox`           | Input NIM, nama, dan jurusan         |
| `Button`            | Menambah dan menampilkan data        |
| `DataGridView`      | Menampilkan data dari database       |
| `DataTable`         | Menampung hasil query                |
| `NpgsqlConnection`  | Membuka koneksi PostgreSQL           |
| `NpgsqlCommand`     | Menjalankan SQL                      |
| `NpgsqlDataAdapter` | Mengisi `DataTable` dari hasil query |

### Alur CRUD yang Dipraktikkan

Praktikum ini sudah menerapkan bagian dasar dari CRUD:

```text
Create
  ↓
TambahData()
  ↓
INSERT INTO mahasiswa
```

```text
Read
  ↓
TampilkanData()
  ↓
SELECT * FROM mahasiswa
  ↓
DataGridView
```

Konsep `Update` dan `Delete` dapat dikembangkan dengan pola yang sama menggunakan query `UPDATE` dan `DELETE`.

### Struktur File Pertemuan 06

```text
Pertemuan6/
└── Pertemuan6/
    ├── Form1.vb
    ├── Form1.Designer.vb
    ├── ModDatabase.vb
    ├── ModFunction.vb
    ├── ModQuery.vb
    ├── appsettings.json
    └── Pertemuan6.vbproj
```

### Pembagian Tanggung Jawab File

| File                | Tanggung Jawab                      |
| ------------------- | ----------------------------------- |
| `Form1.vb`          | Antarmuka dan event pengguna        |
| `ModDatabase.vb`    | Konfigurasi dan koneksi database    |
| `ModFunction.vb`    | Fungsi umum untuk menjalankan query |
| `ModQuery.vb`       | Query khusus tabel/data aplikasi    |
| `appsettings.json`  | Konfigurasi connection string       |
| `Pertemuan6.vbproj` | Konfigurasi project dan package     |

### Kesimpulan Pertemuan 06

Pada pertemuan ini dipelajari integrasi aplikasi Windows Forms dengan database PostgreSQL. Materi mencakup connection string, koneksi menggunakan Npgsql, pengambilan data, penambahan data, penggunaan parameter SQL, `DataTable`, dan `DataGridView`.

Konsep ini menjadi dasar pengembangan aplikasi desktop berbasis database yang dapat dikembangkan lebih lanjut menjadi sistem CRUD lengkap.
