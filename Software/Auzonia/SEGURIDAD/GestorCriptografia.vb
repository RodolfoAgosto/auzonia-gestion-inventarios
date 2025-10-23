Imports System
Imports System.Security
Imports System.Security.Cryptography
Imports System.Text
Public Class GestorCriptografia

    Public Shared Function VerificarIgualdad(ByVal pCadenaOriginal As String, ByVal pCadenaCodificada As String) As Boolean
        Dim vGC As New GestorCriptografia
        pCadenaOriginal = vGC.Hash(pCadenaOriginal)
        If pCadenaOriginal = pCadenaCodificada Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Function Hash(ByVal pValorOriginal As String) As String
        Dim UE As New UnicodeEncoding
        Dim bHash As Byte()

        'Almacena la cadena ingresada en una matriz de bytes
        Dim bCadena() As Byte = UE.GetBytes(pValorOriginal)
        Dim s1Service As New SHA1CryptoServiceProvider

        'Crea el hash
        bHash = s1Service.ComputeHash(bCadena)

        'Retorna como una cadena codificada en base64
        Dim Resumen As String
        Resumen = Convert.ToBase64String(bHash)

        Return Resumen
    End Function

End Class
