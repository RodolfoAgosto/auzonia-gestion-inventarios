Imports SEGURIDAD
Imports BE
Public Class Movimiento_DAL

    Public Sub Alta(ByRef pMovimiento As Movimiento)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@Mov_Tipo", SqlDbType.VarChar, pMovimiento.Tipo),
                                      New DatosParametros("@Mov_CodigoArticulo", SqlDbType.VarChar, pMovimiento.Articulo.Codigo),
                                      New DatosParametros("@Mov_ID_Proveedor", SqlDbType.Int, pMovimiento.Articulo.IDProveedor),
                                      New DatosParametros("@Mov_Documento", SqlDbType.VarChar, pMovimiento.Documento),
                                      New DatosParametros("@Mov_IDDocumento ", SqlDbType.Int, pMovimiento.IDDocumento),
                                      New DatosParametros("@Mov_Cantidad", SqlDbType.Int, pMovimiento.Cantidad)
                                      })
            Comando.Ejecucion("AltaMovimiento", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Function ListarSalidas(ByVal pArticuloNotaDePedido As ArticuloNotaDePedido, ByVal pFechaDesde As Date, ByVal pFechaHasta As Date) As List(Of Movimiento)

        Dim vListaMovimientos As New List(Of Movimiento)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Mov_CodigoArticulo", SqlDbType.VarChar, pArticuloNotaDePedido.Codigo), _
                                      New DatosParametros("@Mov_IDProveedor", SqlDbType.Int, pArticuloNotaDePedido.IDProveedor), _
                                      New DatosParametros("@Mov_Desde", SqlDbType.Date, Format(CDate(pFechaDesde), "yyyy-MM-dd")), _
                                      New DatosParametros("@Mov_Hasta", SqlDbType.Date, Format(CDate(pFechaHasta), "yyyy-MM-dd"))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaMovimientosSalidas", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim vNuevoMovimiento As New Movimiento
                vNuevoMovimiento.Cantidad = (CInt(row.Item(0)))
                vListaMovimientos.Add(vNuevoMovimiento)
            Next
        End If
        Return vListaMovimientos
    End Function

End Class
