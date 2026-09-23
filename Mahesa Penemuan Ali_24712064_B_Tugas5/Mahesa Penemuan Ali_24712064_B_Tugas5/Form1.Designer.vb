<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    Private lblJudul As Label
    Private lblLayanan As Label
    Private cboLayanan As ComboBox
    Private lblBerat As Label
    Private txtBerat As TextBox
    Private WithEvents btnHitung As Button
    Private WithEvents btnReset As Button
    Private lblHasil As Label
    Private lblDaftarHarga As Label

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        lblJudul = New Label()
        lblLayanan = New Label()
        cboLayanan = New ComboBox()
        lblBerat = New Label()
        txtBerat = New TextBox()
        btnHitung = New Button()
        btnReset = New Button()
        lblHasil = New Label()
        lblDaftarHarga = New Label()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 18.0F, FontStyle.Bold)
        lblJudul.ForeColor = Color.FromArgb(CByte(31), CByte(78), CByte(121))
        lblJudul.Location = New Point(50, 42)
        lblJudul.Margin = New Padding(4, 0, 4, 0)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(242, 48)
        lblJudul.TabIndex = 8
        lblJudul.Text = "Tarif Laundry"
        ' 
        ' lblLayanan
        ' 
        lblLayanan.AutoSize = True
        lblLayanan.Location = New Point(54, 153)
        lblLayanan.Margin = New Padding(4, 0, 4, 0)
        lblLayanan.Name = "lblLayanan"
        lblLayanan.Size = New Size(114, 25)
        lblLayanan.TabIndex = 7
        lblLayanan.Text = "Jenis layanan"
        ' 
        ' cboLayanan
        ' 
        cboLayanan.DropDownStyle = ComboBoxStyle.DropDownList
        cboLayanan.FormattingEnabled = True
        cboLayanan.Items.AddRange(New Object() {"Cuci Kering", "Cuci Setrika", "Express"})
        cboLayanan.Location = New Point(54, 188)
        cboLayanan.Margin = New Padding(4, 5, 4, 5)
        cboLayanan.Name = "cboLayanan"
        cboLayanan.Size = New Size(348, 33)
        cboLayanan.TabIndex = 6
        ' 
        ' lblBerat
        ' 
        lblBerat.AutoSize = True
        lblBerat.Location = New Point(54, 263)
        lblBerat.Margin = New Padding(4, 0, 4, 0)
        lblBerat.Name = "lblBerat"
        lblBerat.Size = New Size(153, 25)
        lblBerat.TabIndex = 5
        lblBerat.Text = "Berat pakaian (kg)"
        ' 
        ' txtBerat
        ' 
        txtBerat.Location = New Point(54, 298)
        txtBerat.Margin = New Padding(4, 5, 4, 5)
        txtBerat.Name = "txtBerat"
        txtBerat.Size = New Size(348, 31)
        txtBerat.TabIndex = 4
        ' 
        ' btnHitung
        ' 
        btnHitung.BackColor = Color.FromArgb(CByte(31), CByte(78), CByte(121))
        btnHitung.FlatStyle = FlatStyle.Flat
        btnHitung.ForeColor = Color.White
        btnHitung.Location = New Point(54, 377)
        btnHitung.Margin = New Padding(4, 5, 4, 5)
        btnHitung.Name = "btnHitung"
        btnHitung.Size = New Size(164, 58)
        btnHitung.TabIndex = 3
        btnHitung.Text = "Hitung Tarif"
        btnHitung.UseVisualStyleBackColor = False
        ' 
        ' btnReset
        ' 
        btnReset.Location = New Point(240, 377)
        btnReset.Margin = New Padding(4, 5, 4, 5)
        btnReset.Name = "btnReset"
        btnReset.Size = New Size(164, 58)
        btnReset.TabIndex = 2
        btnReset.Text = "Reset"
        btnReset.UseVisualStyleBackColor = True
        ' 
        ' lblHasil
        ' 
        lblHasil.BackColor = Color.FromArgb(CByte(235), CByte(245), CByte(252))
        lblHasil.BorderStyle = BorderStyle.FixedSingle
        lblHasil.Font = New Font("Segoe UI", 11.0F, FontStyle.Bold)
        lblHasil.ForeColor = Color.FromArgb(CByte(31), CByte(78), CByte(121))
        lblHasil.Location = New Point(479, 138)
        lblHasil.Margin = New Padding(4, 0, 4, 0)
        lblHasil.Name = "lblHasil"
        lblHasil.Padding = New Padding(17, 20, 17, 20)
        lblHasil.Size = New Size(449, 295)
        lblHasil.TabIndex = 1
        lblHasil.Text = "Hasil perhitungan akan tampil di sini."
        ' 
        ' lblDaftarHarga
        ' 
        lblDaftarHarga.AutoSize = True
        lblDaftarHarga.ForeColor = Color.DimGray
        lblDaftarHarga.Location = New Point(54, 490)
        lblDaftarHarga.Margin = New Padding(4, 0, 4, 0)
        lblDaftarHarga.Name = "lblDaftarHarga"
        lblDaftarHarga.Size = New Size(351, 75)
        lblDaftarHarga.TabIndex = 0
        lblDaftarHarga.Text = "Daftar harga per kg:" & vbCrLf & "Cuci Kering   : Rp7.000" & vbCrLf & "Cuci Setrika : Rp10.000 | Express: Rp15.000"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.White
        ClientSize = New Size(986, 650)
        Controls.Add(lblDaftarHarga)
        Controls.Add(lblHasil)
        Controls.Add(btnReset)
        Controls.Add(btnHitung)
        Controls.Add(txtBerat)
        Controls.Add(lblBerat)
        Controls.Add(cboLayanan)
        Controls.Add(lblLayanan)
        Controls.Add(lblJudul)
        Font = New Font("Segoe UI", 9.0F)
        Margin = New Padding(4, 5, 4, 5)
        Name = "Form1"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Aplikasi Tarif Laundry"
        ResumeLayout(False)
        PerformLayout()
    End Sub

End Class
