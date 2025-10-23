Imports BE
Public Class Documento_DAL

    Public Sub Consulta(ByRef pDocumento As Documento)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Doc_Nombre", SqlDbType.VarChar, pDocumento.Nombre)
        }
        Dim vDataTable As DataTable = Comando.EjecucionRetornoDataTable("ConsultaDocumento", vListaParametros)
        If vDataTable.Rows.Count <> 0 Then
            pDocumento.Cuerpo = vDataTable.Rows(0).Item("Cuerpo")
        Else
            'Si no existe pongo el codigo como vacio=""
        End If

    End Sub

End Class
