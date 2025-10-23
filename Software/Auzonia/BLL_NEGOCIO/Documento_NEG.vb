Imports BE
Imports DAL
Public Class Documento_NEG

    Public Sub Consulta(ByRef pDocumento As Documento)
        Dim vDocumento_DAL As New Documento_DAL
        vDocumento_DAL.Consulta(pDocumento)
    End Sub

End Class
