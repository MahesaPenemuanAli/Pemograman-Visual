<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmKasir
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
        components = New ComponentModel.Container()
        lblJudul = New Label()
        lblLayanan = New Label()
        cboLayanan = New ComboBox()
        lblJumlah = New Label()
        txtJumlah = New TextBox()
        btnTambah = New Button()
        btnBaru = New Button()
        dgvPesanan = New DataGridView()
        lblTotalBayar = New Label()
        lblTotal = New Label()
        errInput = New ErrorProvider(components)
        bsPesanan = New BindingSource(components)
        CType(dgvPesanan, ComponentModel.ISupportInitialize).BeginInit()
        CType(errInput, ComponentModel.ISupportInitialize).BeginInit()
        CType(bsPesanan, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.AutoSize = True
        lblJudul.Font = New Font("Segoe UI", 18F, FontStyle.Bold)
        lblJudul.Location = New Point(24, 18)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(262, 48)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Kasir Fotokopi"
        ' 
        ' lblLayanan
        ' 
        lblLayanan.AutoSize = True
        lblLayanan.Location = New Point(24, 98)
        lblLayanan.Name = "lblLayanan"
        lblLayanan.Size = New Size(83, 28)
        lblLayanan.TabIndex = 2
        lblLayanan.Text = "Layanan"
        ' 
        ' cboLayanan
        ' 
        cboLayanan.DropDownStyle = ComboBoxStyle.DropDownList
        cboLayanan.FormattingEnabled = True
        cboLayanan.Location = New Point(179, 94)
        cboLayanan.Name = "cboLayanan"
        cboLayanan.Size = New Size(300, 36)
        cboLayanan.TabIndex = 3
        ' 
        ' lblJumlah
        ' 
        lblJumlah.AutoSize = True
        lblJumlah.Location = New Point(24, 141)
        lblJumlah.Name = "lblJumlah"
        lblJumlah.Size = New Size(151, 28)
        lblJumlah.TabIndex = 4
        lblJumlah.Text = "Jumlah (lembar)"
        ' 
        ' txtJumlah
        ' 
        txtJumlah.Location = New Point(176, 137)
        txtJumlah.Name = "txtJumlah"
        txtJumlah.Size = New Size(130, 34)
        txtJumlah.TabIndex = 5
        ' 
        ' btnTambah
        ' 
        btnTambah.Location = New Point(522, 91)
        btnTambah.Name = "btnTambah"
        btnTambah.Size = New Size(150, 34)
        btnTambah.TabIndex = 7
        btnTambah.Text = "Tambah"
        btnTambah.UseVisualStyleBackColor = True
        ' 
        ' btnBaru
        ' 
        btnBaru.Location = New Point(705, 91)
        btnBaru.Name = "btnBaru"
        btnBaru.Size = New Size(198, 34)
        btnBaru.TabIndex = 8
        btnBaru.Text = "Transaksi Baru"
        btnBaru.UseVisualStyleBackColor = True
        ' 
        ' dgvPesanan
        ' 
        dgvPesanan.AllowUserToAddRows = False
        dgvPesanan.AllowUserToDeleteRows = False
        dgvPesanan.AllowUserToResizeRows = False
        dgvPesanan.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        dgvPesanan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
        dgvPesanan.BackgroundColor = SystemColors.ScrollBar
        dgvPesanan.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgvPesanan.Location = New Point(24, 191)
        dgvPesanan.MultiSelect = False
        dgvPesanan.Name = "dgvPesanan"
        dgvPesanan.ReadOnly = True
        dgvPesanan.RowHeadersVisible = False
        dgvPesanan.RowHeadersWidth = 62
        dgvPesanan.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgvPesanan.Size = New Size(917, 280)
        dgvPesanan.TabIndex = 9
        ' 
        ' lblTotalBayar
        ' 
        lblTotalBayar.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        lblTotalBayar.AutoSize = True
        lblTotalBayar.Font = New Font("Segoe UI", 11F, FontStyle.Bold)
        lblTotalBayar.Location = New Point(24, 500)
        lblTotalBayar.Name = "lblTotalBayar"
        lblTotalBayar.Size = New Size(129, 30)
        lblTotalBayar.TabIndex = 10
        lblTotalBayar.Text = "Total Bayar"
        ' 
        ' lblTotal
        ' 
        lblTotal.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        lblTotal.Font = New Font("Segoe UI", 22F, FontStyle.Bold)
        lblTotal.Location = New Point(608, 483)
        lblTotal.Name = "lblTotal"
        lblTotal.Size = New Size(333, 66)
        lblTotal.TabIndex = 11
        lblTotal.Text = "Rp 0"
        lblTotal.TextAlign = ContentAlignment.MiddleRight
        ' 
        ' errInput
        ' 
        errInput.BlinkStyle = ErrorBlinkStyle.NeverBlink
        errInput.ContainerControl = Me
        ' 
        ' bsPesanan
        ' 
        ' 
        ' FrmKasir
        ' 
        AcceptButton = btnTambah
        AutoScaleDimensions = New SizeF(11F, 28F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(965, 580)
        Controls.Add(lblTotal)
        Controls.Add(lblTotalBayar)
        Controls.Add(dgvPesanan)
        Controls.Add(btnBaru)
        Controls.Add(btnTambah)
        Controls.Add(txtJumlah)
        Controls.Add(lblJumlah)
        Controls.Add(cboLayanan)
        Controls.Add(lblLayanan)
        Controls.Add(lblJudul)
        Font = New Font("Segoe UI", 10F)
        MinimumSize = New Size(896, 619)
        Name = "FrmKasir"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Kasir Fotokopi - Perbaikan UTS"
        CType(dgvPesanan, ComponentModel.ISupportInitialize).EndInit()
        CType(errInput, ComponentModel.ISupportInitialize).EndInit()
        CType(bsPesanan, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblLayanan As Label
    Friend WithEvents cboLayanan As ComboBox
    Friend WithEvents lblJumlah As Label
    Friend WithEvents txtJumlah As TextBox
    Friend WithEvents btnTambah As Button
    Friend WithEvents btnBaru As Button
    Friend WithEvents dgvPesanan As DataGridView
    Friend WithEvents lblTotalBayar As Label
    Friend WithEvents lblTotal As Label
    Friend WithEvents errInput As ErrorProvider
    Friend WithEvents bsPesanan As BindingSource
End Class
