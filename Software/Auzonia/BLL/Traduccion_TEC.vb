Imports BE
Imports DAL

Public Class Traduccion_TEC

    Dim vTraduccionDAL As Traduccion_DAL

    Sub New()
        vTraduccionDAL = New Traduccion_DAL
    End Sub

    Public Function ListarTraducciones(ByVal pIdioma As Idioma) As List(Of Traduccion)
        Return vTraduccionDAL.ListarTraducciones(pIdioma)
    End Function

    Public Function ListarTraducciones(ByVal pIdioma As Idioma, ByVal pPropietario As String) As List(Of Traduccion)
        Return vTraduccionDAL.ListarTraducciones(pIdioma, pPropietario)
    End Function

    Public Shared Function BusquedaPorCodigo(ByVal pTraduccion As Traduccion) As Boolean
        Return pTraduccion.Codigo
    End Function

End Class
