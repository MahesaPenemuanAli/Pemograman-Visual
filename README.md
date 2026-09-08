# 🖥️ Catatan & Log Praktikum: Pemrograman Visual (Visual Basic .NET)

[![Mata Kuliah - Pemrograman Visual](https://img.shields.io/badge/Mata%20Kuliah-Pemrograman%20Visual-007ACC?style=for-the-badge&logo=visualstudio&logoColor=white)](.)
[![Program Studi - D3 Teknik Informatika](https://img.shields.io/badge/Prodi-D3%20Teknik%20Informatika-3776AB?style=for-the-badge)](.)
[![Institusi - Universitas Sumatera Utara](https://img.shields.io/badge/Institusi-Universitas%20Sumatera%20Utara-2E7D32?style=for-the-badge)](.)
[![Tahun Ajaran - 2026/2027](https://img.shields.io/badge/Tahun%20Ajaran-2026%2F2027-gray?style=for-the-badge)](.)

Dokumentasi komprehensif, catatan materi, dan implementasi kode praktikum **Pemrograman Visual** menggunakan platform **Visual Studio (.NET / Windows Forms)** pada Program Studi D3 Teknik Informatika, Universitas Sumatera Utara.

---

## 📑 Daftar Isi

- [Pertemuan 01: Pengantar Pemrograman Visual & Setup Environment](#pertemuan-01-pengantar-pemrograman-visual--setup-environment)
  - [Konsep Dasar Visual Programming](#konsep-dasar-visual-programming)
  - [Karakteristik & Paradigma](#karakteristik--paradigma)
  - [Komparasi Kelebihan dan Keterbatasan](#komparasi-kelebihan-dan-keterbatasan)
  - [Ekosistem & Platform Populer](#ekosistem--platform-populer)
  - [Panduan Instalasi Visual Studio Community](#panduan-instalasi-visual-studio-community)
- [Pertemuan 02: Arsitektur GUI, Komponen Dasar, dan Event Handling](#pertemuan-02-arsitektur-gui-komponen-dasar-dan-event-handling)
  - [Konsep Antarmuka Grafis (GUI)](#konsep-antarmuka-grafis-gui)
  - [Komponen Dasar & Konvensi Penamaan (Prefix)](#komponen-dasar--konvensi-penamaan-prefix)
  - [Daftar Properti Esensial](#daftar-properti-esensial)
  - [Mekanisme Event-Driven Programming](#mekanisme-event-driven-programming)
  - [Alur Pembuatan Project Windows Forms (VB)](#alur-pembuatan-project-windows-forms-vb)
  - [Sintaks Dasar & Contoh Implementasi](#sintaks-dasar--contoh-implementasi)
- [Referensi Shortcut Visual Studio](#referensi-shortcut-visual-studio)

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
