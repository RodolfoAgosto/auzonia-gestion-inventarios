Imports DAL
Imports SEGURIDAD
Public Class GestorBackUp_TEC

    Dim vGestorBackUpDAL As DAL.BackUp_DAL

    Sub New()
        vGestorBackUpDAL = New BackUp_DAL
    End Sub

    Public Sub RealizarBackUp(ByVal pBackUp As Restaurador_SEG)
        vGestorBackUpDAL.RealizarBackUp(pBackUp.Directorio)
    End Sub

    Public Sub RestaurarBaseDeDatos(ByVal pBackUp As Restaurador_SEG)
        Try
            vGestorBackUpDAL.RestaurarBaseDeDatos(pBackUp.Directorio)
        Catch ex As Exception
            Throw New Exception
        End Try
    End Sub

    Public Function ListarDirectorios() As List(Of Restaurador_SEG)
        Return vGestorBackUpDAL.ListarDirectorios()
    End Function

End Class
