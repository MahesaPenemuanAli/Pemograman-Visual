<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmPerulangan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.lblNilaiAwal = New System.Windows.Forms.Label()
        Me.lblNilaiAkhir = New System.Windows.Forms.Label()
        Me.txtNilaiAwal = New System.Windows.Forms.TextBox()
        Me.txtNilaiAkhir = New System.Windows.Forms.TextBox()
        Me.btnInput = New System.Windows.Forms.Button()
        Me.lstHasil = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'lblNilaiAwal
        '
        Me.lblNilaiAwal.AutoSize = True
        Me.lblNilaiAwal.Location = New System.Drawing.Point(293, 48)
        Me.lblNilaiAwal.Name = "lblNilaiAwal"
        Me.lblNilaiAwal.Size = New System.Drawing.Size(80, 20)
        Me.lblNilaiAwal.TabIndex = 0
        Me.lblNilaiAwal.Text = "Nilai Awal:"
        '
        'lblNilaiAkhir
        '
        Me.lblNilaiAkhir.AutoSize = True
        Me.lblNilaiAkhir.Location = New System.Drawing.Point(293, 162)
        Me.lblNilaiAkhir.Name = "lblNilaiAkhir"
        Me.lblNilaiAkhir.Size = New System.Drawing.Size(86, 20)
        Me.lblNilaiAkhir.TabIndex = 1
        Me.lblNilaiAkhir.Text = "Nilai Akhir: "
        '
        'txtNilaiAwal
        '
        Me.txtNilaiAwal.Location = New System.Drawing.Point(297, 86)
        Me.txtNilaiAwal.Name = "txtNilaiAwal"
        Me.txtNilaiAwal.Size = New System.Drawing.Size(100, 26)
        Me.txtNilaiAwal.TabIndex = 2
        '
        'txtNilaiAkhir
        '
        Me.txtNilaiAkhir.Location = New System.Drawing.Point(297, 205)
        Me.txtNilaiAkhir.Name = "txtNilaiAkhir"
        Me.txtNilaiAkhir.Size = New System.Drawing.Size(100, 26)
        Me.txtNilaiAkhir.TabIndex = 3
        '
        'btnInput
        '
        Me.btnInput.Location = New System.Drawing.Point(304, 289)
        Me.btnInput.Name = "btnInput"
        Me.btnInput.Size = New System.Drawing.Size(75, 29)
        Me.btnInput.TabIndex = 4
        Me.btnInput.Text = "Input"
        Me.btnInput.UseVisualStyleBackColor = True
        '
        'lstHasil
        '
        Me.lstHasil.FormattingEnabled = True
        Me.lstHasil.ItemHeight = 20
        Me.lstHasil.Location = New System.Drawing.Point(304, 374)
        Me.lstHasil.Name = "lstHasil"
        Me.lstHasil.Size = New System.Drawing.Size(120, 84)
        Me.lstHasil.TabIndex = 5
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 517)
        Me.Controls.Add(Me.lstHasil)
        Me.Controls.Add(Me.btnInput)
        Me.Controls.Add(Me.txtNilaiAkhir)
        Me.Controls.Add(Me.txtNilaiAwal)
        Me.Controls.Add(Me.lblNilaiAkhir)
        Me.Controls.Add(Me.lblNilaiAwal)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblNilaiAwal As Label
    Friend WithEvents lblNilaiAkhir As Label
    Friend WithEvents txtNilaiAwal As TextBox
    Friend WithEvents txtNilaiAkhir As TextBox
    Friend WithEvents btnInput As Button
    Friend WithEvents lstHasil As ListBox
End Class
