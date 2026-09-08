# Tugas 1 — Aplikasi Login dan Perhitungan Pajak

Dokumentasi ini berisi langkah-langkah membuat aplikasi Windows Forms menggunakan VB.NET. Aplikasi terdiri dari dua form:

1. `FrmLogin` untuk validasi role, nama, dan NIM.
2. `FrmPajak` untuk menghitung pajak berdasarkan pendapatan.

## 1. Persiapan

Perangkat yang dibutuhkan:

- Visual Studio Community.
- Workload **Desktop development with .NET**.
- Project **Windows Forms App** menggunakan Visual Basic.
- Folder gambar `assets` yang berisi:
  - `staff.jpg`
  - `maneger.jpg`

> Nama file `maneger.jpg` mengikuti nama file yang tersedia saat ini. Jika file diubah menjadi `manager.jpg`, nama file tersebut juga harus diubah di kode program.

## 2. Membuat Project

1. Buka Visual Studio.
2. Pilih **Create a new project**.
3. Cari template **Windows Forms App**.
4. Pilih bahasa **Visual Basic**.
5. Beri nama project, misalnya `Tugas1_NIM_Nama`.
6. Pilih framework Windows yang tersedia.
7. Klik **Create**.
8. Simpan project di lokasi yang mudah ditemukan.

Project yang digunakan pada tugas ini memiliki struktur seperti berikut:

```text
form-login/
├── form-login.slnx
├── README.md
└── form-login/
	├── FrmLogin.vb
	├── FrmLogin.Designer.vb
	├── FrmLogin.resx
	├── FrmPajak.vb
	├── FrmPajak.Designer.vb
	├── FrmPajak.resx
	├── form-login.vbproj
	├── assets/
	│   ├── staff.jpg
	│   └── maneger.jpg
	└── My Project/
		└── Application.myapp
```

## 3. Membuat Form

### 3.1 Mengubah Form Pertama Menjadi FrmLogin

1. Pada **Solution Explorer**, klik kanan `Form1.vb`.
2. Pilih **Rename**.
3. Ubah menjadi `FrmLogin.vb`.
4. Pastikan nama class pada kode juga menjadi:

```vb
Public Class FrmLogin
```

### 3.2 Menambahkan FrmPajak

1. Klik kanan project.
2. Pilih **Add → Windows Form**.
3. Beri nama `FrmPajak.vb`.
4. Klik **Add**.
5. Pastikan class-nya menjadi:

```vb
Public Class FrmPajak
```

### 3.3 Mengatur Form Awal

Form pertama yang ditampilkan harus `FrmLogin`.

Cara melalui Visual Studio:

1. Klik kanan project.
2. Pilih **Properties**.
3. Buka tab **Application**.
4. Atur **Startup form** menjadi `FrmLogin`.
5. Simpan perubahan.

Jika project menggunakan `Application.myapp`, pastikan isinya memiliki:

```xml
<MainForm>FrmLogin</MainForm>
```

## 4. Menambahkan Folder Assets

1. Klik kanan project.
2. Pilih **Add → New Folder**.
3. Beri nama folder `assets`.
4. Salin file berikut ke dalam folder tersebut:
   - `staff.jpg`
   - `maneger.jpg`
5. Klik setiap file JPG di Solution Explorer.
6. Pada jendela **Properties**, atur:
   - **Build Action**: `Content`
   - **Copy to Output Directory**: `Copy if newer`

Tujuannya agar file gambar ikut tersedia di folder output saat aplikasi dijalankan.

## 5. Desain FrmLogin

Tambahkan komponen berikut dari Toolbox.

| Komponen | Name | Text / Fungsi |
|---|---|---|
| PictureBox | `picImage` | Menampilkan gambar sesuai role |
| ComboBox | `cmbRole` | Pilihan `Staff` dan `Manager` |
| TextBox | `txtNama` | Input nama |
| TextBox | `txtNIM` | Input NIM |
| Button | `btnLogin` | Memproses login |
| Label | `lblRole` | `Role :` |
| Label | `lblNama` | `Nama :` |
| Label | `lblNIM` | `NIM :` |

Atur properti penting:

- Form `Text`: `Login`
- `cmbRole.DropDownStyle`: `DropDownList`
- Isi `cmbRole.Items`:
  - `Staff`
  - `Manager`
- `picImage.SizeMode`: `Zoom`
- `btnLogin.Text`: `Login`

Susunan form yang disarankan:

```text
	   [ PictureBox ]

Role :    [ ComboBox ]
Nama :    [ TextBox  ]
NIM  :    [ TextBox  ]
			 [Login]
```

## 6. Kode FrmLogin

Tambahkan import berikut di bagian paling atas file `FrmLogin.vb`:

```vb
Imports System.Globalization
Imports System.IO
```

### 6.1 Constructor dan Gambar Awal

```vb
Public Class FrmLogin
	Public Sub New()
		InitializeComponent()
		cmbRole.SelectedIndex = 0
		SetRoleImage()
	End Sub
```

`SelectedIndex = 0` memilih role `Staff` sebagai nilai awal.

### 6.2 Mengubah Gambar Berdasarkan Role

Buat event `SelectedIndexChanged` pada `cmbRole`:

```vb
Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
	SetRoleImage()
End Sub
```

Buat prosedur untuk mengganti gambar:

```vb
Private Sub SetRoleImage()
	Dim role As String = If(cmbRole.SelectedItem, String.Empty).ToString()
	Dim newImage As Image = LoadRoleImage(role)

	If newImage Is Nothing Then
		Return
	End If

	Dim previousImage As Image = picImage.Image
	picImage.Image = newImage

	If previousImage IsNot Nothing Then
		previousImage.Dispose()
	End If
End Sub
```

Buat fungsi untuk mengambil JPG dari folder `assets`:

```vb
Private Function LoadRoleImage(role As String) As Image
	Dim fileName As String = If(
		String.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase),
		"maneger.jpg",
		"staff.jpg")

	Dim imagePath As String = Path.Combine(
		AppContext.BaseDirectory,
		"assets",
		fileName)

	If Not File.Exists(imagePath) Then
		Return Nothing
	End If

	Using sourceImage As Image = Image.FromFile(imagePath)
		Return New Bitmap(sourceImage)
	End Using
End Function
```

`New Bitmap(sourceImage)` digunakan agar file JPG tidak terus terkunci oleh aplikasi setelah dibaca.

### 6.3 Membatasi Input Nama

Buat event `KeyPress` pada `txtNama`:

```vb
Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
	If Not Char.IsControl(e.KeyChar) AndAlso
	   Not Char.IsLetter(e.KeyChar) AndAlso
	   e.KeyChar <> " "c Then
		e.Handled = True
	End If
End Sub
```

Kode tersebut hanya menerima:

- Huruf.
- Spasi.
- Tombol kontrol seperti Backspace.

### 6.4 Membatasi Input NIM

Buat event `KeyPress` pada `txtNIM`:

```vb
Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
	If Not Char.IsControl(e.KeyChar) AndAlso
	   (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
		e.Handled = True
	End If
End Sub
```

Kode tersebut hanya menerima angka 0 sampai 9 dan tombol kontrol.

### 6.5 Login dan Validasi Akun

Data akun pengujian:

| Role | Nama | NIM |
|---|---|---|
| Staff | Nadya | 241712051 |
| Manager | Shata Diyaul Haq | 241712061 |

Buat event `Click` pada `btnLogin`:

```vb
Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
	Dim role As String = If(cmbRole.SelectedItem, String.Empty).ToString().Trim()
	Dim nama As String = txtNama.Text.Trim()
	Dim nim As String = txtNIM.Text.Trim()
	Dim nimNumber As Long

	If Not Long.TryParse(nim, NumberStyles.None, CultureInfo.InvariantCulture, nimNumber) Then
		MessageBox.Show(
			"NIM harus berupa angka yang valid.",
			"Validasi NIM",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning)
		txtNIM.Focus()
		Return
	End If

	Dim isValidAccount As Boolean =
		(String.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase) AndAlso
		 String.Equals(nama, "Nadya", StringComparison.OrdinalIgnoreCase) AndAlso
		 nim = "241712051") OrElse
		(String.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase) AndAlso
		 String.Equals(nama, "Shata Diyaul Haq", StringComparison.OrdinalIgnoreCase) AndAlso
		 nim = "241712061")

	If isValidAccount Then
		FrmPajak.Show()
		Hide()
		txtNama.Clear()
		txtNIM.Clear()
	Else
		MessageBox.Show(
			"Role, nama, atau NIM tidak sesuai.",
			"Login Gagal",
			MessageBoxButtons.OK,
			MessageBoxIcon.Error)
		txtNama.Focus()
	End If
End Sub
```

Alur login:

1. Membaca role, nama, dan NIM.
2. Menghapus spasi di awal dan akhir dengan `Trim()`.
3. Memastikan NIM berupa angka.
4. Membandingkan ketiga data akun.
5. Jika benar, membuka `FrmPajak` dengan `Show()`.
6. Menyembunyikan `FrmLogin` dengan `Hide()`.
7. Mengosongkan nama dan NIM menggunakan `Clear()`.
8. Jika salah, menampilkan `MessageBox` dan mengembalikan fokus ke input.

## 7. Desain FrmPajak

Tambahkan komponen berikut.

| Komponen | Name | Text / Fungsi |
|---|---|---|
| Label | `lblLimaJuta` | Informasi pajak di atas 5 juta |
| Label | `lblTigaPuluhJuta` | Informasi pajak di atas 30 juta |
| Label | `lblSeratusJuta` | Informasi pajak di atas 100 juta |
| Label | `lblPendapatan` | Petunjuk input pendapatan |
| Label | `lblRupiah` | `Rp.` |
| TextBox | `txtPendapatan` | Input pendapatan |
| Button | `btnHitung` | Menghitung pajak |
| Button | `btnKeluar` | Kembali ke login |

Atur properti form:

- `Text`: `Pajak`
- `lblLimaJuta.Text`: `Pendapatan lebih dari 5 juta, 10% Pajak`
- `lblTigaPuluhJuta.Text`: `Pendapatan lebih dari 30 juta, 20% Pajak`
- `lblSeratusJuta.Text`: `Pendapatan lebih dari 100 juta, 30% Pajak`
- `lblPendapatan.Text`: `Masukkan Pendapatan`
- `lblRupiah.Text`: `Rp.`
- `btnHitung.Text`: `Hitung`
- `btnKeluar.Text`: `Keluar`

## 8. Kode FrmPajak

Tambahkan import berikut:

```vb
Imports System.Globalization
```

### 8.1 Membatasi Input Pendapatan

Buat event `KeyPress` pada `txtPendapatan`:

```vb
Private Sub txtPendapatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPendapatan.KeyPress
	If Not Char.IsControl(e.KeyChar) AndAlso
	   (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
		e.Handled = True
	End If
End Sub
```

### 8.2 Menghitung Pajak

Aturan pajak:

| Pendapatan | Persentase |
|---|---:|
| Kurang dari atau sama dengan Rp5.000.000 | 0% |
| Lebih dari Rp5.000.000 sampai Rp30.000.000 | 10% |
| Lebih dari Rp30.000.000 sampai Rp100.000.000 | 20% |
| Lebih dari Rp100.000.000 | 30% |

Buat event `Click` pada `btnHitung`:

```vb
Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
	Dim pendapatan As Decimal
	Dim inputPendapatan As String = txtPendapatan.Text.Trim()

	If Not Decimal.TryParse(
		inputPendapatan,
		NumberStyles.None,
		CultureInfo.InvariantCulture,
		pendapatan) Then

		MessageBox.Show(
			"Pendapatan harus berupa angka yang valid.",
			"Validasi Pendapatan",
			MessageBoxButtons.OK,
			MessageBoxIcon.Warning)
		txtPendapatan.Focus()
		Return
	End If

	Dim persentasePajak As Decimal

	If pendapatan <= 5000000D Then
		persentasePajak = 0D
	ElseIf pendapatan <= 30000000D Then
		persentasePajak = 0.1D
	ElseIf pendapatan <= 100000000D Then
		persentasePajak = 0.2D
	Else
		persentasePajak = 0.3D
	End If

	Dim pajak As Decimal = pendapatan * persentasePajak
	Dim hasilRupiah As String = pajak.ToString(
		"N0",
		CultureInfo.GetCultureInfo("id-ID"))

	MessageBox.Show(
		"Pajak yang harus dibayar: Rp " & hasilRupiah,
		"Hasil Perhitungan",
		MessageBoxButtons.OK,
		MessageBoxIcon.Information)
End Sub
```

Contoh perhitungan:

- Pendapatan `5.000.000` → pajak `Rp 0`.
- Pendapatan `10.000.000` → pajak `Rp 1.000.000`.
- Pendapatan `50.000.000` → pajak `Rp 10.000.000`.
- Pendapatan `150.000.000` → pajak `Rp 45.000.000`.

### 8.3 Tombol Keluar

Buat event `Click` pada `btnKeluar`:

```vb
Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
	Close()
	FrmLogin.Show()
End Sub
```

## 9. Daftar Event yang Wajib Ada

| Event | Kontrol | Kegunaan |
|---|---|---|
| `SelectedIndexChanged` | `cmbRole` | Mengubah gambar role |
| `Click` | `btnLogin` | Memvalidasi login |
| `KeyPress` | `txtNama` | Membatasi input nama |
| `KeyPress` | `txtNIM` | Membatasi input NIM |
| `Click` | `btnHitung` | Menghitung pajak |
| `KeyPress` | `txtPendapatan` | Membatasi input angka |
| `Click` | `btnKeluar` | Kembali ke login |

## 10. Method yang Digunakan

- `Show()` — menampilkan form.
- `Hide()` — menyembunyikan form login.
- `Close()` — menutup form pajak.
- `Clear()` — mengosongkan TextBox.
- `Focus()` — mengembalikan fokus ke input yang salah.
- `MessageBox.Show()` — menampilkan pesan, peringatan, error, dan hasil pajak.
- `Trim()` — menghapus spasi awal dan akhir input.
- `Decimal.TryParse()` — memvalidasi pendapatan.
- `Long.TryParse()` — memvalidasi NIM.
- `Image.FromFile()` — membaca gambar JPG dari folder `assets`.

## 11. Skenario Pengujian

Lakukan pengujian berikut sebelum mengumpulkan tugas:

| No. | Skenario | Hasil yang Diharapkan |
|---:|---|---|
| 1 | Memilih role Staff | Gambar `staff.jpg` tampil |
| 2 | Memilih role Manager | Gambar `maneger.jpg` tampil |
| 3 | Login Staff dengan data benar | `FrmPajak` terbuka |
| 4 | Login Manager dengan data benar | `FrmPajak` terbuka |
| 5 | Role, nama, atau NIM salah | Pesan login gagal tampil |
| 6 | Mengetik huruf pada NIM | Huruf ditolak |
| 7 | Mengetik angka pada nama | Angka ditolak |
| 8 | Pendapatan kosong | Pesan validasi tampil |
| 9 | Pendapatan berupa huruf | Karakter ditolak atau pesan validasi tampil |
| 10 | Pendapatan Rp5.000.000 | Pajak 0% |
| 11 | Pendapatan Rp10.000.000 | Pajak 10% |
| 12 | Pendapatan Rp50.000.000 | Pajak 20% |
| 13 | Pendapatan Rp150.000.000 | Pajak 30% |
| 14 | Menekan tombol Keluar | Kembali ke `FrmLogin` |

## 12. Troubleshooting Designer dan Toolbox

### Toolbox kosong

1. Pastikan project sudah terbuka dan berhasil di-build.
2. Buka file `FrmLogin.vb` atau `FrmPajak.vb`.
3. Klik kanan file tersebut.
4. Pilih **View Designer**.
5. Buka **View → Toolbox** atau tekan `Ctrl + Alt + X`.
6. Klik area form terlebih dahulu agar Toolbox menampilkan kontrol Windows Forms.

### Form tidak bisa dibuka di Designer

Pastikan:

- Class form mewarisi `System.Windows.Forms.Form` melalui file `.Designer.vb`.
- Nama class pada file utama dan `.Designer.vb` sama.
- Ada method `InitializeComponent()`.
- File `FrmLogin.Designer.vb` berada di bawah `FrmLogin.vb`.
- File `FrmPajak.Designer.vb` berada di bawah `FrmPajak.vb`.
- Project memiliki properti berikut:

```xml
<UseWindowsForms>true</UseWindowsForms>
<MyType>WindowsForms</MyType>
```

Jika masih bermasalah:

1. Tutup Visual Studio.
2. Hapus folder `bin` dan `obj`.
3. Buka kembali solution.
4. Pilih **Build → Rebuild Solution**.
5. Buka kembali form dengan **View Designer**.

### Gambar tidak tampil

Periksa hal berikut:

- Nama file harus tepat: `staff.jpg` dan `maneger.jpg`.
- Folder harus bernama `assets`.
- File JPG harus berada di dalam folder project.
- **Build Action** harus `Content`.
- **Copy to Output Directory** harus `Copy if newer`.
- Jangan menggunakan nama `manager.jpg` pada file jika kode masih menggunakan `maneger.jpg`.

## 13. Checklist Sebelum Dikumpulkan

- [ ] Project menggunakan VB.NET Windows Forms.
- [ ] Form pertama adalah `FrmLogin`.
- [ ] Form kedua adalah `FrmPajak`.
- [ ] Semua nama kontrol sudah sesuai ketentuan.
- [ ] Gambar Staff dan Manager dapat berubah.
- [ ] Nama hanya menerima huruf dan spasi.
- [ ] NIM hanya menerima angka.
- [ ] Login memeriksa role, nama, dan NIM.
- [ ] Form pajak menghitung empat kategori tarif.
- [ ] Hasil pajak menggunakan format rupiah tanpa desimal.
- [ ] Tombol `Keluar` kembali ke form login.
- [ ] Project berhasil di-build tanpa error.
- [ ] Semua skenario pengujian sudah dicoba.

## 14. Urutan Singkat Saat Ulangan Coding

Jika harus membuat ulang dari awal, gunakan urutan berikut:

1. Buat project Windows Forms VB.NET.
2. Siapkan form `FrmLogin` dan `FrmPajak`.
3. Atur `FrmLogin` sebagai startup form.
4. Buat folder `assets` dan masukkan `staff.jpg` serta `maneger.jpg`.
5. Desain `FrmLogin` dan beri nama semua kontrol.
6. Isi ComboBox dengan Staff dan Manager.
7. Tulis kode loader gambar JPG.
8. Tulis validasi `KeyPress` nama dan NIM.
9. Tulis validasi tombol Login.
10. Desain `FrmPajak`.
11. Tulis validasi input pendapatan.
12. Tulis percabangan pajak menggunakan `If...ElseIf...Else`.
13. Tulis tombol `Keluar`.
14. Build project.
15. Jalankan seluruh skenario pengujian.
