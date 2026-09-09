Public Class FrmLogin
    Private Sub FrmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cmbRole.SelectedIndex = 0
    End Sub

    Private Sub cmbRole_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbRole.SelectedIndexChanged
        If cmbRole.Text = "Manager" Then
            picImage.Image = Image.FromFile("assets\maneger.png")
        ElseIf cmbRole.Text = "Staff" Then
            picImage.Image = Image.FromFile("assets\staff.png")
        End If
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsLetter(e.KeyChar) AndAlso e.KeyChar <> " "c Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNIM_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNIM.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso Not Char.IsDigit(e.KeyChar) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim role As String = cmbRole.Text
        Dim nama As String = txtNama.Text.Trim()
        Dim nim As String = txtNIM.Text.Trim()

        If nama = "" OrElse nim = "" Then
            MessageBox.Show("Nama dan NIM tidak boleh kosong.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Dim isStaff As Boolean = (role = "Staff" AndAlso nama.ToLower() = "risky" AndAlso nim = "241712056")
        Dim isManager As Boolean = (role = "Manager" AndAlso nama.ToLower() = "mahesa penemuan ali" AndAlso nim = "241712064")

        If isStaff OrElse isManager Then
            MessageBox.Show("Login berhasil! Selamat datang, " & nama, "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            FrmPajak.Show()
            Me.Hide()

            txtNama.Clear()
            txtNIM.Clear()
        Else
            MessageBox.Show("Role, nama, atau NIM tidak sesuai.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            txtNama.Focus()
        End If
    End Sub
End Class