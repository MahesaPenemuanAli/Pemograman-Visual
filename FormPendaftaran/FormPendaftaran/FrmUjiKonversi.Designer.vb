<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUjiKonversi
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
        lblPetunjuk = New Label()
        lblInput = New Label()
        txtInput = New TextBox()
        btnCInt = New Button()
        btnVal = New Button()
        btnTryParse = New Button()
        btnTryCatch = New Button()
        btnCatchBertingkat = New Button()
        lblHasil = New Label()
        SuspendLayout()
        ' lblJudul
        lblJudul.Location = New Point(24, 20)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(592, 32)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Uji Konversi Input"
        lblJudul.AutoSize = False
        lblJudul.Font = New Font("Segoe UI", 14.0F, FontStyle.Bold)
        ' lblPetunjuk
        lblPetunjuk.Location = New Point(24, 62)
        lblPetunjuk.Name = "lblPetunjuk"
        lblPetunjuk.Size = New Size(592, 40)
        lblPetunjuk.TabIndex = 1
        lblPetunjuk.Text = "Ketik sebuah nilai lalu coba setiap tombol. Coba: 25, abc, 12abc, 3,5, 99999999999, atau kosong."
        lblPetunjuk.AutoSize = False
        ' lblInput
        lblInput.Location = New Point(24, 117)
        lblInput.Name = "lblInput"
        lblInput.Size = New Size(54, 23)
        lblInput.TabIndex = 2
        lblInput.Text = "Input:"
        lblInput.AutoSize = False
        ' txtInput
        txtInput.Location = New Point(84, 114)
        txtInput.Name = "txtInput"
        txtInput.Size = New Size(280, 23)
        txtInput.TabIndex = 3
        ' btnCInt
        btnCInt.Location = New Point(24, 160)
        btnCInt.Name = "btnCInt"
        btnCInt.Size = New Size(128, 36)
        btnCInt.TabIndex = 4
        btnCInt.Text = "CInt (tanpa Try)"
        btnCInt.UseVisualStyleBackColor = True
        ' btnVal
        btnVal.Location = New Point(162, 160)
        btnVal.Name = "btnVal"
        btnVal.Size = New Size(76, 36)
        btnVal.TabIndex = 5
        btnVal.Text = "Val"
        btnVal.UseVisualStyleBackColor = True
        ' btnTryParse
        btnTryParse.Location = New Point(248, 160)
        btnTryParse.Name = "btnTryParse"
        btnTryParse.Size = New Size(100, 36)
        btnTryParse.TabIndex = 6
        btnTryParse.Text = "TryParse"
        btnTryParse.UseVisualStyleBackColor = True
        ' btnTryCatch
        btnTryCatch.Location = New Point(358, 160)
        btnTryCatch.Name = "btnTryCatch"
        btnTryCatch.Size = New Size(114, 36)
        btnTryCatch.TabIndex = 7
        btnTryCatch.Text = "Try...Catch"
        btnTryCatch.UseVisualStyleBackColor = True
        ' btnCatchBertingkat
        btnCatchBertingkat.Location = New Point(482, 160)
        btnCatchBertingkat.Name = "btnCatchBertingkat"
        btnCatchBertingkat.Size = New Size(134, 36)
        btnCatchBertingkat.TabIndex = 8
        btnCatchBertingkat.Text = "Catch Bertingkat"
        btnCatchBertingkat.UseVisualStyleBackColor = True
        ' lblHasil
        lblHasil.Location = New Point(24, 220)
        lblHasil.Name = "lblHasil"
        lblHasil.Size = New Size(592, 94)
        lblHasil.TabIndex = 9
        lblHasil.Text = "Hasil akan tampil di sini."
        lblHasil.AutoSize = False
        lblHasil.BorderStyle = BorderStyle.FixedSingle
        lblHasil.Padding = New Padding(8)
        AutoScaleDimensions = New SizeF(7.0F, 15.0F)
        AutoScaleMode = AutoScaleMode.Font
        Font = New Font("Segoe UI", 9.0F)
        ClientSize = New Size(640, 340)
        Controls.Add(lblJudul)
        Controls.Add(lblPetunjuk)
        Controls.Add(lblInput)
        Controls.Add(txtInput)
        Controls.Add(btnCInt)
        Controls.Add(btnVal)
        Controls.Add(btnTryParse)
        Controls.Add(btnTryCatch)
        Controls.Add(btnCatchBertingkat)
        Controls.Add(lblHasil)
        FormBorderStyle = FormBorderStyle.FixedSingle
        MaximizeBox = False
        Name = "FrmUjiKonversi"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Uji Konversi Input"
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents lblPetunjuk As Label
    Friend WithEvents lblInput As Label
    Friend WithEvents txtInput As TextBox
    Friend WithEvents btnCInt As Button
    Friend WithEvents btnVal As Button
    Friend WithEvents btnTryParse As Button
    Friend WithEvents btnTryCatch As Button
    Friend WithEvents btnCatchBertingkat As Button
    Friend WithEvents lblHasil As Label
End Class
