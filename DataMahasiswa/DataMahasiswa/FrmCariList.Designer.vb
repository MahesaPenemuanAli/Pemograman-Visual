<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmCariList
    Inherits System.Windows.Forms.Form

    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then components.Dispose()
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    Private components As System.ComponentModel.IContainer

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New System.ComponentModel.Container()
        lblJudul = New Label()
        lblCari = New Label()
        txtCari = New TextBox()
        dgvMahasiswa = New DataGridView()
        lblJumlah = New Label()
        bsMahasiswa = New BindingSource(components)
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(bsMahasiswa, System.ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        lblJudul.Name = "lblJudul"
        lblJudul.Location = New Point(20, 18)
        lblJudul.Size = New Size(700, 32)
        lblJudul.Text = "Mencari di List(Of Mahasiswa)"
        lblJudul.Font = New Font("Segoe UI", 14.0!, FontStyle.Bold)
        lblCari.Name = "lblCari"
        lblCari.Location = New Point(20, 73)
        lblCari.Size = New Size(110, 23)
        lblCari.Text = "Cari nama/NIM:"
        txtCari.Name = "txtCari"
        txtCari.Location = New Point(135, 70)
        txtCari.Size = New Size(380, 23)
        txtCari.TabIndex = 2
        dgvMahasiswa.Name = "dgvMahasiswa"
        dgvMahasiswa.Location = New Point(20, 115)
        dgvMahasiswa.Size = New Size(680, 260)
        dgvMahasiswa.AllowUserToAddRows = False
        dgvMahasiswa.AllowUserToDeleteRows = False
        dgvMahasiswa.ReadOnly = True
        dgvMahasiswa.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvMahasiswa.MultiSelect = False
        dgvMahasiswa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvMahasiswa.TabIndex = 3
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Location = New Point(20, 393)
        lblJumlah.Size = New Size(680, 25)
        lblJumlah.Text = "Menampilkan 0 data"
        AutoScaleDimensions = New SizeF(7.0!, 15.0!)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(720, 430)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        StartPosition = FormStartPosition.CenterScreen
        Name = "FrmCariList"
        Text = "Pencarian dengan Perulangan"
        Controls.Add(lblJudul)
        Controls.Add(lblCari)
        Controls.Add(txtCari)
        Controls.Add(dgvMahasiswa)
        Controls.Add(lblJumlah)
        CType(dgvMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(bsMahasiswa, System.ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblCari As Label
    Friend WithEvents txtCari As TextBox
    Friend WithEvents dgvMahasiswa As DataGridView
    Friend WithEvents lblJumlah As Label
    Friend WithEvents bsMahasiswa As BindingSource
End Class
