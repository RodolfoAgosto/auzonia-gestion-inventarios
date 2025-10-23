Imports SEGURIDAD
Public Class GestorIntegridad_DAL

    ' Devuelve todos los DVH de una tabla.
    Public Function ListarDVH(ByVal pNombreTabla As String) As DataTable

        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@NombreTabla", SqlDbType.VarChar, pNombreTabla))

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ListarDVH", vListaParametros)

        Return vDataTable

    End Function

    ' Guarda el DVV de una tabla.
    Public Sub GuardarDVV(ByVal pNombreTabla As String)
        Try
            Dim vDVV As String = ""
            Dim vDTRegistrosDVH As DataTable
            Dim vGestorCriptografia As New GestorCriptografia
            ' Lista en la DataTable los DVH de la tabla.
            vDTRegistrosDVH = ListarDVH(pNombreTabla)
            ' Solo si tiene un registro la tabla de DVH. 
            If vDTRegistrosDVH.Rows.Count > 0 Then
                For Each vRow As DataRow In vDTRegistrosDVH.Rows
                    vDVV = vDVV + vRow.Item(0).ToString
                    vDVV = vGestorCriptografia.Hash(vDVV)
                Next

                Dim vListaParametros As New List(Of DatosParametros)
                vListaParametros.Add(New DatosParametros("@NombreTabla", SqlDbType.VarChar, pNombreTabla))
                vListaParametros.Add(New DatosParametros("@DVV", SqlDbType.VarChar, vDVV))
                Comando.Ejecucion("GuardarDVV", vListaParametros)
            End If
        Catch ex As Exception

        End Try

    End Sub

    ' Devuelve el DVV de una tabla.
    Public Function ListarDVV(ByVal pNombreTabla As String) As String

        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@NombreTabla", SqlDbType.VarChar, pNombreTabla))

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ListarDVV", vListaParametros)

        Return vDataTable.Rows(0).Item(0).ToString

    End Function

    ' Devuelve los registros corruptos. POR AHORA NO LA UTILIZO.
    Public Function ListarRegistrosCorruptos(ByVal pNombreTabla As String) As DataTable
        Dim vTablaRegistrosDevueltos As DataTable
        Dim vListaParametros As New List(Of DatosParametros)
        Dim vParametroNombreTabla As New DatosParametros
        vParametroNombreTabla.NombreParametro = "@NombreTabla"
        vParametroNombreTabla.TipoParametro = SqlDbType.VarChar
        vParametroNombreTabla.Valor = pNombreTabla
        vListaParametros.Add(vParametroNombreTabla)
        vTablaRegistrosDevueltos = Comando.EjecucionRetornoDataTable("ListarRegistrosPorNombreTabla", vListaParametros)
        If vTablaRegistrosDevueltos.Rows.Count > 0 Then
            For Each vFila As DataRow In vTablaRegistrosDevueltos.Rows
                Dim vContatenacion As String = ""
                Dim vDVH As String = vFila.Item(vFila.ItemArray.Count - 1)
                For vIndice As Integer = 0 To vFila.ItemArray.Count - 2
                    vContatenacion = vContatenacion + vFila.Item(vIndice).ToString
                Next
                Dim vResultadoIgualdad As Boolean = False
                vResultadoIgualdad = GestorCriptografia.VerificarIgualdad(vContatenacion, vDVH)
                If vResultadoIgualdad Then
                    vFila.Delete()
                End If
            Next
        End If
        vTablaRegistrosDevueltos.AcceptChanges()
        Return vTablaRegistrosDevueltos
    End Function

    ' Valida el DVV de una tabla dada.
    Public Function ValidarDVV(ByVal pNombreTabla As String) As Boolean
        Dim vListaDVH As DataTable
        Dim vDVV As String
        Dim vConcatenacion As String = ""
        vListaDVH = ListarDVH(pNombreTabla)
        vDVV = ListarDVV(pNombreTabla)
        Dim cm As New GestorCriptografia
        If vListaDVH.Rows.Count > 0 Then
            For Each vFila As DataRow In vListaDVH.Rows
                vConcatenacion = vConcatenacion + vFila.Item(0).ToString
                vConcatenacion = cm.Hash(vConcatenacion)
            Next
            If vDVV = vConcatenacion Then
                Return True
            Else
                Return False
            End If

        Else
            Return True
        End If
    End Function

End Class
