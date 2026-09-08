Imports System.Globalization
Imports System.IO

Public Class FrmLogin
    Public Sub New()
        InitializeComponent()
        cmbRole.SelectedIndex = 0
        SetRoleImage()
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        SetRoleImage()
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim role As String = If(cmbRole.SelectedItem, String.Empty).ToString().Trim()
        Dim nama As String = txtNama.Text.Trim()
        Dim nim As String = txtNIM.Text.Trim()
        Dim nimNumber As Long

        If Not Long.TryParse(nim, NumberStyles.None, CultureInfo.InvariantCulture, nimNumber) Then
            MessageBox.Show("NIM harus berupa angka yang valid.", "Validasi NIM", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtNIM.Focus()
            Return
        End If

        Dim isValidAccount As Boolean = (String.Equals(role, "Staff", StringComparison.OrdinalIgnoreCase) AndAlso String.Equals(nama, "Nadya", StringComparison.OrdinalIgnoreCase) AndAlso nim = "241712051") OrElse (String.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase) AndAlso String.Equals(nama, "Shata Diyaul Haq", StringComparison.OrdinalIgnoreCase) AndAlso nim = "241712061")

        If isValidAccount Then
            FrmPajak.Show()
            Hide()
            txtNama.Clear()
            txtNIM.Clear()
        Else
            MessageBox.Show("Role, nama, atau NIM tidak sesuai.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNama.Focus()
        End If
    End Sub

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

    Private Function LoadRoleImage(role As String) As Image
        Dim fileName As String = If(String.Equals(role, "Manager", StringComparison.OrdinalIgnoreCase), "maneger.jpg", "staff.jpg")
        Dim imagePath As String = Path.Combine(AppContext.BaseDirectory, "assets", fileName)

        If Not File.Exists(imagePath) Then
            Return Nothing
        End If

        Using sourceImage As Image = Image.FromFile(imagePath)
            Return New Bitmap(sourceImage)
        End Using
    End Function

    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
