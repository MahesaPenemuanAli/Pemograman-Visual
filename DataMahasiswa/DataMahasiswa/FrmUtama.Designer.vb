<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmUtama
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
        lblJudul = New Label()
        btnDariArray = New Button()
        btnDariList = New Button()
        btnDataTable = New Button()
        btnCariList = New Button()
        SuspendLayout()
        ' 
        ' lblJudul
        ' 
        lblJudul.Font = New Font("Segoe UI", 14F, FontStyle.Bold)
        lblJudul.Location = New Point(43, 37)
        lblJudul.Margin = New Padding(4, 0, 4, 0)
        lblJudul.Name = "lblJudul"
        lblJudul.Size = New Size(543, 58)
        lblJudul.TabIndex = 0
        lblJudul.Text = "Contoh Pertemuan 8"
        ' 
        ' btnDariArray
        ' 
        btnDariArray.Location = New Point(43, 125)
        btnDariArray.Margin = New Padding(4, 5, 4, 5)
        btnDariArray.Name = "btnDariArray"
        btnDariArray.Size = New Size(543, 67)
        btnDariArray.TabIndex = 1
        btnDariArray.Text = "1. DataGridView dari Array"
        ' 
        ' btnDariList
        ' 
        btnDariList.Location = New Point(43, 208)
        btnDariList.Margin = New Padding(4, 5, 4, 5)
        btnDariList.Name = "btnDariList"
        btnDariList.Size = New Size(543, 67)
        btnDariList.TabIndex = 2
        btnDariList.Text = "2. Binding List(Of Mahasiswa)"
        ' 
        ' btnDataTable
        ' 
        btnDataTable.Location = New Point(43, 292)
        btnDataTable.Margin = New Padding(4, 5, 4, 5)
        btnDataTable.Name = "btnDataTable"
        btnDataTable.Size = New Size(543, 67)
        btnDataTable.TabIndex = 3
        btnDataTable.Text = "3. DataTable, Rapikan Kolom dan Filter"
        ' 
        ' btnCariList
        ' 
        btnCariList.Location = New Point(43, 375)
        btnCariList.Margin = New Padding(4, 5, 4, 5)
        btnCariList.Name = "btnCariList"
        btnCariList.Size = New Size(543, 67)
        btnCariList.TabIndex = 4
        btnCariList.Text = "4. Pencarian dengan Perulangan"
        ' 
        ' FrmUtama
        ' 
        AutoScaleDimensions = New SizeF(10F, 25F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(629, 500)
        Controls.Add(lblJudul)
        Controls.Add(btnDariArray)
        Controls.Add(btnDariList)
        Controls.Add(btnDataTable)
        Controls.Add(btnCariList)
        FormBorderStyle = FormBorderStyle.FixedSingle
        Margin = New Padding(4, 5, 4, 5)
        MaximizeBox = False
        Name = "FrmUtama"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Pertemuan 8 - DataGridView, Array & Koleksi Data"
        ResumeLayout(False)
    End Sub

    Friend WithEvents lblJudul As Label
    Friend WithEvents btnDariArray As Button
    Friend WithEvents btnDariList As Button
    Friend WithEvents btnDataTable As Button
    Friend WithEvents btnCariList As Button
End Class
