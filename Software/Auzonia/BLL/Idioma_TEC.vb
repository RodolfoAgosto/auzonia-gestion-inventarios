Imports BE
Imports DAL
Public Class Idioma_TEC

    Dim vIdiomaDAL As Idioma_DAL

    Sub New()
        vIdiomaDAL = New Idioma_DAL
    End Sub

    Public Sub Alta(ByVal vIdioma As Idioma)
        vIdiomaDAL.Alta(vIdioma)
    End Sub

    Public Function ListarIdiomas() As List(Of Idioma)
        Return vIdiomaDAL.ConsultaTodos
    End Function

    Public Sub Actualizar(ByVal pIdioma As Idioma)
        vIdiomaDAL.Actualizar(pIdioma)
    End Sub


End Class
