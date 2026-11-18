Option Strict On
Imports System.Globalization
Imports System.IO

Public Class Mahasiswa
    Public Property NIM As String = ""
    Public Property Nama As String = ""
    Public Property Jurusan As String = ""
    Public Property Angkatan As Integer
    Public Property Tugas As Decimal
    Public Property UTS As Decimal
    Public Property UAS As Decimal
    Public Property NilaiAkhir As Decimal
    Public Property Grade As String = ""
    Public Property Status As String = ""
End Class

Public Module modData
    Public ReadOnly daftarMahasiswa As New List(Of Mahasiswa)
    Public ReadOnly komponenNilai As String() = {"Tugas", "UTS", "UAS"}
    Public ReadOnly contoh(,) As String = {
        {"241712001", "Andi", "Teknik Informatika"},
        {"241712002", "Sari", "Sistem Informasi"},
        {"241712003", "Ma'ruf", "Teknik Komputer"},
        {"241712004", "Rina", "Teknik Informatika"},
        {"241712005", "Dimas", "Sistem Informasi"}}
End Module

Public Module modPerhitungan
    Public Function HitungNilaiAkhir(tugas As Decimal, uts As Decimal, uas As Decimal) As Decimal
        Return tugas * 0.3D + uts * 0.3D + uas * 0.4D
    End Function
    Public Function TentukanGrade(nilai As Decimal) As String
        If nilai >= 85D Then
            Return "A"
        ElseIf nilai >= 75D Then
            Return "B"
        ElseIf nilai >= 65D Then
            Return "C"
        ElseIf nilai >= 50D Then
            Return "D"
        Else
            Return "E"
        End If
    End Function
    Public Function PenjelasanGrade(grade As String) As String
        Select Case grade
            Case "A" : Return "Sangat Baik"
            Case "B" : Return "Baik"
            Case "C" : Return "Cukup"
            Case "D" : Return "Kurang"
            Case Else : Return "Perlu latihan"
        End Select
    End Function
End Module

Public Module modValidasi
    Public Function BacaDesimal(teks As String, ByRef hasil As Decimal) As Boolean
        Return Decimal.TryParse(teks.Trim().Replace(","c, "."c),
            NumberStyles.AllowDecimalPoint Or NumberStyles.AllowLeadingSign,
            CultureInfo.InvariantCulture, hasil)
    End Function
    Public Function NIMValid(teks As String) As Boolean
        Return teks.Length = 9 AndAlso teks.All(Function(c) c >= "0"c AndAlso c <= "9"c)
    End Function
    Public Function AmankanFilter(teks As String) As String
        Dim hasil As New System.Text.StringBuilder()
        For Each c As Char In teks
            Select Case c
                Case "'"c : hasil.Append("''")
                Case "["c : hasil.Append("[[]")
                Case "]"c : hasil.Append("[]]")
                Case "*"c : hasil.Append("[*]")
                Case "%"c : hasil.Append("[%]")
                Case Else : hasil.Append(c)
            End Select
        Next
        Return hasil.ToString()
    End Function
    Public Function KolomCSV(teks As String) As String
        Dim petik As String = ChrW(34)
        Return petik & teks.Replace(petik, petik & petik) & petik
    End Function
End Module
