Imports SEGURIDAD
Imports BE
Public Class Remito_DAL

    Public Sub Alta(ByRef pRemito As Remito)
        Try

            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                       New DatosParametros("@Rem_ID_Cliente", SqlDbType.Int, pRemito.Cliente.ID)
                                       })
            pRemito.ID = Comando.EjecucionScalar("AltaRemito", vListaParametros)
            Dim vArticuloDAL As New Articulo_DAL
            For Each vAR As ArticuloRemito In pRemito.ListaArticuloRemito
                vArticuloDAL.Alta(vAR, pRemito)
            Next
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

End Class
