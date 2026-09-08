Imports System.Globalization

Public Class FrmPajak
    Public Sub New()
        InitializeComponent()
    End Sub

    Private Sub txtPendapatan_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtPendapatan.KeyPress
        If Not Char.IsControl(e.KeyChar) AndAlso (e.KeyChar < "0"c OrElse e.KeyChar > "9"c) Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnHitung_Click(sender As Object, e As EventArgs) Handles btnHitung.Click
        Dim pendapatan As Decimal
        Dim inputPendapatan As String = txtPendapatan.Text.Trim()

        If Not Decimal.TryParse(inputPendapatan, NumberStyles.None, CultureInfo.InvariantCulture, pendapatan) Then
            MessageBox.Show("Pendapatan harus berupa angka yang valid.", "Validasi Pendapatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
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
        Dim hasilRupiah As String = pajak.ToString("N0", CultureInfo.GetCultureInfo("id-ID"))
        MessageBox.Show("Pajak yang harus dibayar: Rp " & hasilRupiah, "Hasil Perhitungan", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub

    Private Sub btnKeluar_Click(sender As Object, e As EventArgs) Handles btnKeluar.Click
        Close()
        FrmLogin.Show()
    End Sub

    Private Sub FrmPajak_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
