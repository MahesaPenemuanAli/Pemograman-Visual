Option Strict On

Public Module ModValidasi
    ' Memeriksa panjang teks dan memastikan setiap karakter merupakan angka 0-9.
    Public Function SemuaDigit(teks As String, panjang As Integer) As Boolean
        If teks.Length <> panjang Then Return False
        For Each karakter As Char In teks
            If karakter < "0"c OrElse karakter > "9"c Then Return False
        Next
        Return True
    End Function

    ' Menerima kode BK diikuti tepat empat digit, termasuk masukan huruf kecil.
    Public Function KodeBukuValid(kode As String) As Boolean
        Dim kodeBersih As String = kode.Trim().ToUpperInvariant()
        If kodeBersih.Length <> 6 Then Return False
        If Not kodeBersih.StartsWith("BK") Then Return False
        Return SemuaDigit(kodeBersih.Substring(2), 4)
    End Function

    ' Melindungi isi kolom CSV yang mengandung titik koma atau tanda petik.
    Public Function KolomCsv(teks As String) As String
        Dim petik As String = ChrW(34)
        Return petik & teks.Replace(petik, petik & petik) & petik
    End Function
End Module
