Imports SEGURIDAD
Imports BE

Public Class PedidoDeCliente_DAL

    Public Sub Alta(ByRef pPedidoDeCliente As PedidoDeCliente)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@PedCli_ID_Client", SqlDbType.Int, pPedidoDeCliente.Cliente.ID), _
                                      New DatosParametros("@PedCli_FechaEstimadaDeEntrega", SqlDbType.VarChar, pPedidoDeCliente.FechaDeEntrega), _
                                      New DatosParametros("@PedCli_Comentarios", SqlDbType.VarChar, pPedidoDeCliente.Comentarios)
                                      })
            pPedidoDeCliente.ID = Comando.EjecucionScalar("AltaPedidoDeCiente", vListaParametros)
            If Not pPedidoDeCliente.ListaDeArticulos Is Nothing Then
                Dim vArticuloDAL As New Articulo_DAL
                If pPedidoDeCliente.ListaDeArticulos.Count > 0 Then
                    For Each vArticulo As ArticuloPedidoDeCliente In pPedidoDeCliente.ListaDeArticulos
                        vArticuloDAL.Alta(vArticulo, pPedidoDeCliente)
                    Next
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub

    Public Function ConsultaVarios(ByRef pPedidoDeCliente As PedidoDeCliente) As List(Of PedidoDeCliente)

        Dim vListaPedidoDeCliente As New List(Of PedidoDeCliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@PedCli_ID", SqlDbType.Int, pPedidoDeCliente.ID), _
                                      New DatosParametros("@PedCli_ID_Cliente", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@PedCli_FechaDeCreacion", SqlDbType.Date, pPedidoDeCliente.FechaDeCreacion), _
                                      New DatosParametros("@PedCli_FechaEstimadaDeEntrega", SqlDbType.Date, pPedidoDeCliente.FechaDeEntrega), _
                                      New DatosParametros("@PedCli_Estado", SqlDbType.VarChar, pPedidoDeCliente.Estado)
                                     })
        If pPedidoDeCliente.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If Not pPedidoDeCliente.Cliente Is Nothing Then
            vListaParametros.Item(1).Valor = pPedidoDeCliente.Cliente.ID
            If pPedidoDeCliente.Cliente.ID = 0 Then
                vListaParametros.Item(1).Valor = Nothing
            End If
        End If
        If vListaParametros.Item(2).Valor = "0:00:00" Then
            vListaParametros.Item(2).Valor = Nothing
        End If
        If vListaParametros.Item(3).Valor = "0:00:00" Then
            vListaParametros.Item(3).Valor = Nothing
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaPedidoDeCliente", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim vNuevoPedidoDeCliente As New PedidoDeCliente(row.Item(0), row.Item(2), row.Item(3), row.Item(4), row.Item(5))
                If Not pPedidoDeCliente.Cliente Is Nothing Then
                    vNuevoPedidoDeCliente.Cliente = pPedidoDeCliente.Cliente
                Else
                    Dim vClienteDAL As New Cliente_DAL
                    Dim vNuevoCliente As New Cliente
                    vNuevoCliente.ID = row.Item(1)
                    vClienteDAL.Consulta(vNuevoCliente)
                End If
                vListaPedidoDeCliente.Add(vNuevoPedidoDeCliente)
            Next
        End If

        Return vListaPedidoDeCliente

    End Function

    Public Function ConsultaVariosPCArticuloPedidoDeCliente(ByRef pPedidoDeCliente As PedidoDeCliente) As List(Of PedidoDeCliente)

        Dim vListaPedidoDeCliente As List(Of PedidoDeCliente)
        vListaPedidoDeCliente = Me.ConsultaVarios(pPedidoDeCliente)
        Dim vArticulo As New Articulo_DAL
        For Each vPedidoDeCliente As PedidoDeCliente In vListaPedidoDeCliente
            vArticulo.ConsultaVarios(vPedidoDeCliente)
        Next
        Return vListaPedidoDeCliente

    End Function

    Public Sub Consulta(ByRef pPedidoDeCliente As PedidoDeCliente)
        Dim vPedidoDeCliente As PedidoDeCliente
        Dim vListaDePedidoDeCliente As List(Of PedidoDeCliente)
        vListaDePedidoDeCliente = Me.ConsultaVarios(pPedidoDeCliente)
        vPedidoDeCliente = vListaDePedidoDeCliente.Item(0)
        Dim vArticuloDAL As New Articulo_DAL
        vArticuloDAL.ConsultaVarios(vPedidoDeCliente)
        pPedidoDeCliente.ListaDeArticulos = vPedidoDeCliente.ListaDeArticulos
    End Sub

    Public Sub Modificacion(ByRef pPedidoDeCliente As PedidoDeCliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@PedCli_ID", SqlDbType.Int, pPedidoDeCliente.ID), _
                                      New DatosParametros("@PedCli_ID_Cliente", SqlDbType.Int, pPedidoDeCliente.Cliente.ID), _
                                      New DatosParametros("@PedCli_FechaEstimadaDeEntrega", SqlDbType.Date, pPedidoDeCliente.FechaDeEntrega), _
                                      New DatosParametros("@PedCli_Comentarios", SqlDbType.VarChar, pPedidoDeCliente.Comentarios), _
                                      New DatosParametros("@PedCli_Estado", SqlDbType.VarChar, pPedidoDeCliente.Estado)
                                  })
        Comando.Ejecucion("ModificarPedidoDeCliente", vListaParametros)
        If Not pPedidoDeCliente.ListaDeArticulos Is Nothing Then
            Dim vArticuloPedidoDeClienteDAL As New Articulo_DAL
            For Each vArticuloPedidoDeClienteActual As ArticuloPedidoDeCliente In pPedidoDeCliente.ListaDeArticulos
                vArticuloPedidoDeClienteDAL.Modificacion(vArticuloPedidoDeClienteActual, pPedidoDeCliente)
            Next
        End If
    End Sub

End Class
