<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmArray
    Inherits System.Windows.Forms.Form

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
        lblPanjang = New Label()
        txtPanjang = New TextBox()
        lblLebar = New Label()
        txtLebar = New TextBox()
        btnTampilkan = New Button()
        lstNilai = New ListBox()
        SuspendLayout()
        ' 
        ' lblPanjang
        ' 
        lblPanjang.AutoSize = True
        lblPanjang.Location = New Point(372, 24)
        lblPanjang.Name = "lblPanjang"
        lblPanjang.Size = New Size(74, 25)
        lblPanjang.TabIndex = 0
        lblPanjang.Text = "Panjang"
        ' 
        ' txtPanjang
        ' 
        txtPanjang.Location = New Point(372, 69)
        txtPanjang.Name = "txtPanjang"
        txtPanjang.Size = New Size(150, 31)
        txtPanjang.TabIndex = 1
        ' 
        ' lblLebar
        ' 
        lblLebar.AutoSize = True
        lblLebar.Location = New Point(372, 126)
        lblLebar.Name = "lblLebar"
        lblLebar.Size = New Size(55, 25)
        lblLebar.TabIndex = 2
        lblLebar.Text = "Lebar"
        ' 
        ' txtLebar
        ' 
        txtLebar.Location = New Point(372, 172)
        txtLebar.Name = "txtLebar"
        txtLebar.Size = New Size(150, 31)
        txtLebar.TabIndex = 3
        ' 
        ' btnTampilkan
        ' 
        btnTampilkan.Location = New Point(395, 234)
        btnTampilkan.Name = "btnTampilkan"
        btnTampilkan.Size = New Size(112, 34)
        btnTampilkan.TabIndex = 4
        btnTampilkan.Text = "Tampilkan"
        btnTampilkan.UseVisualStyleBackColor = True
        ' 
        ' lstNilai
        ' 
        lstNilai.FormattingEnabled = True
        lstNilai.Location = New Point(372, 295)
        lstNilai.Name = "lstNilai"
        lstNilai.Size = New Size(180, 129)
        lstNilai.TabIndex = 5
        ' 
        ' FrmArray
        ' 
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(lstNilai)
        Controls.Add(btnTampilkan)
        Controls.Add(txtLebar)
        Controls.Add(lblLebar)
        Controls.Add(txtPanjang)
        Controls.Add(lblPanjang)
        Name = "FrmArray"
        Text = "Form1"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblPanjang As Label
    Friend WithEvents txtPanjang As TextBox
    Friend WithEvents lblLebar As Label
    Friend WithEvents txtLebar As TextBox
    Friend WithEvents btnTampilkan As Button
    Friend WithEvents lstNilai As ListBox

End Class
