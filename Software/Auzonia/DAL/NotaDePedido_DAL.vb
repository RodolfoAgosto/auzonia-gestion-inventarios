Imports SEGURIDAD
Imports BE

Public Class NotaDePedido_DAL

    Public Sub Alta(ByRef pNotaDePedido As NotaDePedido)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@NotPed_Proveedor", SqlDbType.Int, pNotaDePedido.Proveedor.ID)
                                      })
            pNotaDePedido.ID = Comando.EjecucionScalar("AltaNotaDePedido", vListaParametros)
            Dim vArticuloDAL As New Articulo_DAL
            For Each vANDP As ArticuloNotaDePedido In pNotaDePedido.ListaDeArticulos
                vArticuloDAL.Alta(vANDP, pNotaDePedido)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function ConsultaVarios(ByRef pNotaDePedido As NotaDePedido) As List(Of NotaDePedido)
        If Not pNotaDePedido.Proveedor Is Nothing Then
            Dim vListaNotaDePedido As New List(Of NotaDePedido)
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                          New DatosParametros("@NotPed_ID", SqlDbType.Int, pNotaDePedido.ID), _
                                          New DatosParametros("@NotPed_ID_Proveedor", SqlDbType.Int, pNotaDePedido.Proveedor.ID), _
                                          New DatosParametros("@NotPed_FechaDeCreacion", SqlDbType.Date, pNotaDePedido.FechaDeCreacion), _
                                          New DatosParametros("@NotPed_Estado", SqlDbType.VarChar, pNotaDePedido.Estado)
                                       })
            If pNotaDePedido.ID = 0 Then
                vListaParametros.Item(0).Valor = Nothing
            End If
            If Not pNotaDePedido.Proveedor Is Nothing Then
                vListaParametros.Item(1).Valor = pNotaDePedido.Proveedor.ID
                If pNotaDePedido.Proveedor.ID = 0 Then
                    vListaParametros.Item(1).Valor = Nothing
                End If
            End If
            If vListaParametros.Item(2).Valor = "0:00:00" Then
                vListaParametros.Item(2).Valor = Nothing
            End If
            Dim vDataTable As DataTable
            vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaNotaDePedido", vListaParametros)

            If vDataTable.Rows.Count > 0 Then
                For Each row As DataRow In vDataTable.Rows
                    Dim vNuevaNotaDePedido As New NotaDePedido(CInt(row.Item(0)), CDate(row.Item(2)), row.Item(3))
                    Dim vProveedorDAL As New Proveedor_DAL
                    vProveedorDAL.Consulta(pNotaDePedido.Proveedor)
                    vNuevaNotaDePedido.Proveedor = pNotaDePedido.Proveedor
                    vListaNotaDePedido.Add(vNuevaNotaDePedido)
                Next
            End If
            Return vListaNotaDePedido
        Else
            Return Nothing

        End If

    End Function

    Public Sub Consulta(ByRef pNotaDePedido As NotaDePedido)
        Dim vNotaDePedido As NotaDePedido
        Dim vListaDeNotaDePedido As List(Of NotaDePedido)
        vListaDeNotaDePedido = Me.ConsultaVarios(pNotaDePedido)
        vNotaDePedido = vListaDeNotaDePedido.Item(0)
        Dim vArticuloDAL As New Articulo_DAL
        vArticuloDAL.ConsultaVarios(vNotaDePedido)
        pNotaDePedido.ListaDeArticulos = vNotaDePedido.ListaDeArticulos
    End Sub

    Public Sub Modificacion(ByRef pNotaDePedido As NotaDePedido)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@NotPed_ID", SqlDbType.Int, pNotaDePedido.ID), _
                                      New DatosParametros("@NotPed_ID_Proveedor", SqlDbType.Int, pNotaDePedido.Proveedor.ID), _
                                      New DatosParametros("@NotPed_FechaDeCreacion", SqlDbType.Date, pNotaDePedido.FechaDeCreacion), _
                                      New DatosParametros("@NotPed_Estado", SqlDbType.VarChar, pNotaDePedido.Estado)
                                   })
        Comando.Ejecucion("ModificarNotaDePedido", vListaParametros)
        If Not pNotaDePedido.ListaDeArticulos Is Nothing Then
            Dim vArticuloNotaDePedidoDAL As New Articulo_DAL
            For Each vArticuloNotaDePedidoActual As ArticuloNotaDePedido In pNotaDePedido.ListaDeArticulos
                vArticuloNotaDePedidoDAL.Modificacion(vArticuloNotaDePedidoActual, pNotaDePedido)
            Next
        End If
    End Sub


End Class
