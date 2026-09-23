Public Class Form1

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim berat As Decimal
        Dim hargaPerKg As Decimal
        Dim namaLayanan As String = cboLayanan.Text

        If namaLayanan = "" Then
            MessageBox.Show("Silakan pilih jenis layanan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboLayanan.Focus()
            Exit Sub
        End If

        If Not Decimal.TryParse(txtBerat.Text, berat) OrElse berat <= 0 Then
            MessageBox.Show("Berat harus diisi dengan angka lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtBerat.Focus()
            Exit Sub
        End If

        If namaLayanan = "Cuci Kering" Then
            hargaPerKg = 7000
        ElseIf namaLayanan = "Cuci Setrika" Then
            hargaPerKg = 10000
        Else
            hargaPerKg = 15000
        End If

        Dim subtotal As Decimal = berat * hargaPerKg
        Dim diskon As Decimal = 0

        If berat >= 5 Then
            diskon = subtotal * 0.1D
        End If

        Dim total As Decimal = subtotal - diskon
        lblHasil.Text = "Layanan: " & namaLayanan & Environment.NewLine &
                        "Berat: " & berat.ToString("N1") & " kg" & Environment.NewLine &
                        "Subtotal: Rp" & subtotal.ToString("N0") & Environment.NewLine &
                        "Diskon: Rp" & diskon.ToString("N0") & Environment.NewLine &
                        "TOTAL: Rp" & total.ToString("N0")
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        cboLayanan.SelectedIndex = -1
        txtBerat.Clear()
        lblHasil.Text = "Hasil perhitungan akan tampil di sini."
        cboLayanan.Focus()
    End Sub

End Class
