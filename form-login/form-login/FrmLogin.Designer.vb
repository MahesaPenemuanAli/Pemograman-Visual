<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmLogin
    Inherits System.Windows.Forms.Form

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

    Private components As System.ComponentModel.IContainer
    Friend WithEvents picImage As PictureBox
    Friend WithEvents cmbRole As ComboBox
    Friend WithEvents txtNama As TextBox
    Friend WithEvents txtNIM As TextBox
    Friend WithEvents btnLogin As Button
    Friend WithEvents lblRole As Label
    Friend WithEvents lblNama As Label
    Friend WithEvents lblNIM As Label

    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        picImage = New PictureBox()
        cmbRole = New ComboBox()
        txtNama = New TextBox()
        txtNIM = New TextBox()
        btnLogin = New Button()
        lblRole = New Label()
        lblNama = New Label()
        lblNIM = New Label()
        CType(picImage, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' picImage
        ' 
        picImage.BackColor = Color.White
        picImage.Location = New Point(130, 20)
        picImage.Name = "picImage"
        picImage.Size = New Size(100, 100)
        picImage.SizeMode = PictureBoxSizeMode.Zoom
        picImage.TabIndex = 7
        picImage.TabStop = False
        ' 
        ' cmbRole
        ' 
        cmbRole.DropDownStyle = ComboBoxStyle.DropDownList
        cmbRole.FormattingEnabled = True
        cmbRole.Items.AddRange(New Object() {"Staff", "Manager"})
        cmbRole.Location = New Point(130, 151)
        cmbRole.Name = "cmbRole"
        cmbRole.Size = New Size(170, 33)
        cmbRole.TabIndex = 1
        ' 
        ' txtNama
        ' 
        txtNama.Location = New Point(130, 196)
        txtNama.Name = "txtNama"
        txtNama.Size = New Size(170, 31)
        txtNama.TabIndex = 3
        ' 
        ' txtNIM
        ' 
        txtNIM.Location = New Point(130, 241)
        txtNIM.Name = "txtNIM"
        txtNIM.Size = New Size(170, 31)
        txtNIM.TabIndex = 5
        ' 
        ' btnLogin
        ' 
        btnLogin.Location = New Point(130, 290)
        btnLogin.Name = "btnLogin"
        btnLogin.Size = New Size(100, 32)
        btnLogin.TabIndex = 6
        btnLogin.Text = "Login"
        btnLogin.UseVisualStyleBackColor = True
        ' 
        ' lblRole
        ' 
        lblRole.AutoSize = True
        lblRole.Location = New Point(65, 155)
        lblRole.Name = "lblRole"
        lblRole.Size = New Size(55, 25)
        lblRole.TabIndex = 0
        lblRole.Text = "Role :"
        ' 
        ' lblNama
        ' 
        lblNama.AutoSize = True
        lblNama.Location = New Point(65, 200)
        lblNama.Name = "lblNama"
        lblNama.Size = New Size(68, 25)
        lblNama.TabIndex = 2
        lblNama.Text = "Nama :"
        ' 
        ' lblNIM
        ' 
        lblNIM.AutoSize = True
        lblNIM.Location = New Point(65, 245)
        lblNIM.Name = "lblNIM"
        lblNIM.Size = New Size(55, 25)
        lblNIM.TabIndex = 4
        lblNIM.Text = "NIM :"
        ' 
        ' FrmLogin
        ' 
        AcceptButton = btnLogin
        AutoScaleDimensions = New SizeF(10.0F, 25.0F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(360, 350)
        Controls.Add(btnLogin)
        Controls.Add(txtNIM)
        Controls.Add(lblNIM)
        Controls.Add(txtNama)
        Controls.Add(lblNama)
        Controls.Add(cmbRole)
        Controls.Add(lblRole)
        Controls.Add(picImage)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmLogin"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Login"
        CType(picImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub
End Class
