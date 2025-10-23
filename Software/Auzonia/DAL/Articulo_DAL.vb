Imports BE

Public Class Articulo_DAL

    Public Sub ActualizarStock(ByRef pArticuloRemitoProveedor As ArticuloRemitoProveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtStc_ID", SqlDbType.Int, pArticuloRemitoProveedor.ID), _
                                      New DatosParametros("@ArtStc_Cantidad", SqlDbType.Int, pArticuloRemitoProveedor.Cantidad)
                                  })
        Comando.Ejecucion("ActualizarStock", vListaParametros)
    End Sub

    Public Sub Alta(ByRef pArticulo As ArticuloStock)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticulo.Codigo), _
                                      New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticulo.Descripcion), _
                                      New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, pArticulo.PuntoDeReposicion), _
                                      New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, pArticulo.StockDeSeguridad), _
                                      New DatosParametros("@Art_StockFisico", SqlDbType.Int, pArticulo.StockFisico), _
                                      New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, pArticulo.IDProveedor)
                                      })
            Comando.Ejecucion("AltaArticulo", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloPedidoDeCliente As ArticuloPedidoDeCliente, ByVal pPedidoDeCliente As PedidoDeCliente)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtPedCli_ID_PedidoCliente", SqlDbType.Int, pPedidoDeCliente.ID), _
                                        New DatosParametros("@ArtPedCli_ID_Articulo", SqlDbType.Int, pArticuloPedidoDeCliente.ID), _
                                        New DatosParametros("@ArtPedCli_Solicitadas", SqlDbType.Int, pArticuloPedidoDeCliente.Solicitadas)
                                        })
            Comando.Ejecucion("AltaArticuloPedidoDeCiente", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloNotaDePedido As ArticuloNotaDePedido, ByVal pNotaDePedido As NotaDePedido)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtNotPed_ID_NotaDePedido", SqlDbType.Int, pNotaDePedido.ID), _
                                        New DatosParametros("@ArtNotPed_ID_Articulo", SqlDbType.Int, pArticuloNotaDePedido.ID), _
                                        New DatosParametros("@ArtNotPed_Solicitadas", SqlDbType.Int, pArticuloNotaDePedido.Solicitadas)
                                        })
            Comando.Ejecucion("AltaArticuloNotaDePedido", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloRemitoProveedor As ArticuloRemitoProveedor, ByVal pRemitoProveedor As RemitoProveedor)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtRemPro_ID_RemitoProveedor", SqlDbType.Int, pRemitoProveedor.ID), _
                                        New DatosParametros("@ArtRemPro_ID_Articulo", SqlDbType.Int, pArticuloRemitoProveedor.ID), _
                                        New DatosParametros("@ArtRemPro_Cantidad", SqlDbType.Int, pArticuloRemitoProveedor.Cantidad)
                                        })
            Comando.Ejecucion("AltaArticuloRemitoProveedor", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloNotaDeEnvio As ArticuloNotaDeEnvio, ByVal pNotaDeEnvio As NotaDeEnvio)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtNotEnv_ID_NotaDeEnvio", SqlDbType.Int, pNotaDeEnvio.ID), _
                                        New DatosParametros("@ArtNotEnv_ID_Articulo", SqlDbType.Int, pArticuloNotaDeEnvio.ID), _
                                        New DatosParametros("@ArtNotEnv_Cantidad", SqlDbType.Int, pArticuloNotaDeEnvio.Cantidad)
                                        })
            Comando.Ejecucion("AltaArticuloNotaDeEnvio", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloRemito As ArticuloRemito, ByVal pRemito As Remito)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtRem_ID_Remito", SqlDbType.Int, pRemito.ID), _
                                        New DatosParametros("@ArtRem_ID_Articulo", SqlDbType.Int, pArticuloRemito.ID), _
                                        New DatosParametros("@ArtRem_Cantidad", SqlDbType.Int, pArticuloRemito.Cantidad)
                                        })
            Comando.Ejecucion("AltaArticuloRemito", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Alta(ByRef pArticuloValuacion As ArticuloValuacion)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                        New DatosParametros("@ArtVal_ID_Articulo", SqlDbType.Int, pArticuloValuacion.Articulo.ID), _
                                        New DatosParametros("@ArtVal_CantidadFIFO", SqlDbType.Int, pArticuloValuacion.CantidadFIFO), _
                                        New DatosParametros("@ArtVal_CantidadLIFO", SqlDbType.Int, pArticuloValuacion.CantidadLIFO)
                                      })
            Comando.Ejecucion("AltaArticuloValuacion", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pArticulo As ArticuloStock)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Art_ID", SqlDbType.Int, pArticulo.ID)
        }
        Comando.Ejecucion("BajaArticulo", vListaParametros)
    End Sub

    Public Sub Consulta(ByRef pArticulo As ArticuloStock)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Art_ID", SqlDbType.Int, pArticulo.ID)
        }
        Dim vDataTable As DataTable = Comando.EjecucionRetornoDataTable("ConsultaArticulo", vListaParametros)
        If vDataTable.Rows.Count <> 0 Then
            pArticulo.ID = vDataTable.Rows(0).Item("ID")
            pArticulo.Codigo = vDataTable.Rows(0).Item("Codigo")
            pArticulo.Descripcion = vDataTable.Rows(0).Item("Descripcion")
            pArticulo.PuntoDeReposicion = vDataTable.Rows(0).Item("PuntoDeReposicion")
            pArticulo.StockDeSeguridad = vDataTable.Rows(0).Item("StockDeSeguridad")
            pArticulo.StockFisico = vDataTable.Rows(0).Item("StockFisico")
            pArticulo.IDProveedor = vDataTable.Rows(0).Item("ID_Proveedor")
        Else
            'Si no existe pongo el codigo como vacio=""
            pArticulo.ID = ""
        End If

    End Sub

    Public Function ConsultaRango(ByRef pObjeto1 As ArticuloStock, ByRef pObjeto2 As ArticuloStock) As List(Of ArticuloStock)
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pArticulo As ArticuloStock) As List(Of ArticuloStock)

        Dim vListaArticulo As New List(Of ArticuloStock)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Art_ID", SqlDbType.Int, CInt(pArticulo.ID)), _
                                      New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticulo.Codigo), _
                                      New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticulo.Descripcion), _
                                      New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, CInt(pArticulo.PuntoDeReposicion)), _
                                      New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, CInt(pArticulo.StockDeSeguridad)), _
                                      New DatosParametros("@Art_StockFisico", SqlDbType.Int, CInt(pArticulo.StockFisico)), _
                                      New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, CInt(pArticulo.IDProveedor))
                                   })
        If pArticulo.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pArticulo.PuntoDeReposicion = 0 Then
            vListaParametros.Item(3).Valor = Nothing
        End If
        If pArticulo.StockDeSeguridad = 0 Then
            vListaParametros.Item(4).Valor = Nothing
        End If
        If pArticulo.StockFisico = 0 Then
            vListaParametros.Item(5).Valor = Nothing
        End If
        If pArticulo.IDProveedor = 0 Then
            vListaParametros.Item(6).Valor = Nothing
        End If

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticulo.Add(New ArticuloStock(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6)))
            Next
        End If

        Return vListaArticulo

    End Function

    Public Function ConsultaVarios(ByRef pArticuloRemitoProveedor As ArticuloRemitoProveedor) As List(Of ArticuloRemitoProveedor)

        Dim vListaArticulo As New List(Of ArticuloRemitoProveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Art_ID", SqlDbType.Int, CInt(pArticuloRemitoProveedor.ID)), _
                                      New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticuloRemitoProveedor.Codigo), _
                                      New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticuloRemitoProveedor.Descripcion), _
                                      New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_StockFisico", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, CInt(pArticuloRemitoProveedor.IDProveedor))
                                   })
        If pArticuloRemitoProveedor.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pArticuloRemitoProveedor.IDProveedor = 0 Then
            vListaParametros.Item(6).Valor = Nothing
        End If

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticulo.Add(New ArticuloRemitoProveedor(row.Item(0), row.Item(1), row.Item(2), row.Item(6)))
            Next
        End If

        Return vListaArticulo


    End Function

    Public Function ConsultaVarios(ByRef pArticulo As ArticuloNotaDePedido) As List(Of ArticuloNotaDePedido)

        'Dim vListaArticuloNotaDePedido As New List(Of ArticuloNotaDePedido)
        'Dim vListaParametros As New List(Of DatosParametros)
        'vListaParametros.AddRange({
        '                              New DatosParametros("@Art_ID", SqlDbType.Int, CInt(pArticulo.ID)), _
        '                              New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticulo.Codigo), _
        '                              New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticulo.Descripcion), _
        '                              New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, CInt(pArticulo.PuntoDeReposicion)), _
        '                              New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, CInt(pArticulo.StockDeSeguridad)), _
        '                              New DatosParametros("@Art_StockFisico", SqlDbType.Int, CInt(pArticulo.StockFisico)), _
        '                              New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, CInt(pArticulo.IDProveedor))
        '                           })
        'If pArticulo.ID = 0 Then
        '    vListaParametros.Item(0).Valor = Nothing
        'End If
        'If pArticulo.PuntoDeReposicion = 0 Then
        '    vListaParametros.Item(3).Valor = Nothing
        'End If
        'If pArticulo.StockDeSeguridad = 0 Then
        '    vListaParametros.Item(4).Valor = Nothing
        'End If
        'If pArticulo.StockFisico = 0 Then
        '    vListaParametros.Item(5).Valor = Nothing
        'End If
        'If pArticulo.IDProveedor = 0 Then
        '    vListaParametros.Item(6).Valor = Nothing
        'End If

        'Dim vDataTable As DataTable
        'vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulos", vListaParametros)

        'If vDataTable.Rows.Count > 0 Then
        '    For Each row As DataRow In vDataTable.Rows
        '        vListaArticuloNotaDePedido.Add(New ArticuloNotaDePedido(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6)))
        '    Next
        'End If

        'Return vListaArticuloNotaDePedido
        Return Nothing

    End Function

    Public Function ConsultaVarios(ByRef pArticulo As ArticuloPedidoDeCliente) As List(Of ArticuloPedidoDeCliente)

        Dim vListaArticulo As New List(Of ArticuloPedidoDeCliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Art_ID", SqlDbType.Int, CInt(pArticulo.ID)), _
                                      New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticulo.Codigo), _
                                      New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticulo.Descripcion), _
                                      New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_StockFisico", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, CInt(pArticulo.IDProveedor))
                                   })
        If pArticulo.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pArticulo.IDProveedor = 0 Then
            vListaParametros.Item(6).Valor = Nothing
        End If

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticulo.Add(New ArticuloPedidoDeCliente(row.Item(0), row.Item(1), row.Item(2), row.Item(6)))
            Next
        End If

        Return vListaArticulo

    End Function

    Public Function ConsultaVarios(ByRef pArticulo As ArticuloValuacion) As List(Of ArticuloValuacion)

        Dim vListaArticulo As New List(Of ArticuloValuacion)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                     New DatosParametros("@ArtVal_ID_Articulo", SqlDbType.VarChar, pArticulo.Articulo.ID), _
                                     New DatosParametros("@ArtVal_ID_ListaDePrecios", SqlDbType.VarChar, pArticulo.IDListaDePrecios)
                                   })
        Dim vDataTable As DataTable
        If pArticulo.Articulo.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pArticulo.IDListaDePrecios = 0 Then
            vListaParametros.Item(1).Valor = Nothing
        End If
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulosValuacion", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim vArticulo As New ArticuloStock With {
                    .ID = row.Item(1),
                    .Codigo = row.Item(2),
                    .Descripcion = row.Item(3),
                    .IDProveedor = row.Item(4)
                }
                Dim vArticuloValuacion As New ArticuloValuacion With {
                    .ID = row.Item(0),
                    .Articulo = vArticulo,
                    .CantidadFIFO = row.Item(5),
                    .CantidadLIFO = row.Item(6),
                    .IDListaDePrecios = row.Item(7)
                }
                vListaArticulo.Add(vArticuloValuacion)
            Next
        End If

        Return vListaArticulo

    End Function

    Private Sub AgregarPrecioValuacion(ByRef pArticuloValuacion As ArticuloValuacion)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtVal_IDArticulo", SqlDbType.Int, pArticuloValuacion.ID), _
                                      New DatosParametros("@ArtVal_ID_ListaDePrecios", SqlDbType.Int, pArticuloValuacion.IDListaDePrecios)
                                   })
        Dim vDataTable As DataTable
        If pArticuloValuacion.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pArticuloValuacion.IDListaDePrecios = 0 Then
            vListaParametros.Item(1).Valor = Nothing
        End If
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaPrecioArticuloValuacion", vListaParametros)
        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                pArticuloValuacion.Precio = row.Item(0)
            Next
        End If
    End Sub

    Public Sub ConsultaVarios(ByRef pPedidoDeCliente As PedidoDeCliente)

        Dim vListaArticuloPedidoDeCliente As New List(Of ArticuloPedidoDeCliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtPedCli_ID_PedidoCliente", SqlDbType.Int, CInt(pPedidoDeCliente.ID))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulosPedidoDeCliente", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticuloPedidoDeCliente.Add(New ArticuloPedidoDeCliente(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7)))
            Next
        End If

        pPedidoDeCliente.ListaDeArticulos = vListaArticuloPedidoDeCliente

    End Sub

    Public Sub ConsultaVarios(ByRef pNotaDePedido As NotaDePedido)

        Dim vListaArticuloNotaDePedido As New List(Of ArticuloNotaDePedido)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtNotPed_ID_NotaDePedido", SqlDbType.Int, CInt(pNotaDePedido.ID))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulosNotaDePedido", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticuloNotaDePedido.Add(New ArticuloNotaDePedido(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5)))
            Next
        End If

        pNotaDePedido.ListaDeArticulos = vListaArticuloNotaDePedido

    End Sub

    Public Sub ConsultaVarios(ByRef pNotaDeEnvio As NotaDeEnvio)

        Dim vListaArticuloNotaDeEnvio As New List(Of ArticuloNotaDeEnvio)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtNotEnv_ID_NotaDeEnvio", SqlDbType.Int, CInt(pNotaDeEnvio.ID))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulosNotaDeEnvio", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticuloNotaDeEnvio.Add(New ArticuloNotaDeEnvio(CInt(row.Item(0)), CStr(row.Item(1)), CStr(row.Item(2)), CInt(row.Item(3)), CInt(row.Item(4))))
            Next
        End If

        pNotaDeEnvio.ListaDeArticuloDeEnvio = vListaArticuloNotaDeEnvio

    End Sub

    Public Sub ConsultaVarios(ByRef pRemitoProveedor As RemitoProveedor)

        Dim vListaArticuloRemitoProveedor As New List(Of ArticuloRemitoProveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtRemPro_ID_RemitoProveedor", SqlDbType.Int, CInt(pRemitoProveedor.ID))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticulosRemitoProveedor", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticuloRemitoProveedor.Add(New ArticuloRemitoProveedor(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5)))
            Next
        End If

        pRemitoProveedor.ListaDeArticulos = vListaArticuloRemitoProveedor

    End Sub

    Public Sub ConsultaVarios(ByRef pListaDePreciosCompra As ListaDePreciosCompra)

        Dim vListaArticuloListaDePrecios As New List(Of ArticuloListaDePrecios)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtPreCom_ID_ListaDePrecios", SqlDbType.Int, CInt(pListaDePreciosCompra.ID))
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaArticuloListaDePreciosCompra", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaArticuloListaDePrecios.Add(New ArticuloListaDePrecios(row.Item(0), row.Item(1), row.Item(2), row.Item(4)))
            Next
        End If

        pListaDePreciosCompra.ListaDeArticulos = vListaArticuloListaDePrecios

    End Sub

    Public Sub Modificacion(ByRef pArticulo As ArticuloStock)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Art_ID", SqlDbType.Int, pArticulo.ID), _
                                      New DatosParametros("@Art_Codigo", SqlDbType.VarChar, pArticulo.Codigo), _
                                      New DatosParametros("@Art_Descripcion", SqlDbType.VarChar, pArticulo.Descripcion), _
                                      New DatosParametros("@Art_PuntoDeReposicion", SqlDbType.Int, pArticulo.PuntoDeReposicion), _
                                      New DatosParametros("@Art_StockDeSeguridad", SqlDbType.Int, pArticulo.StockDeSeguridad), _
                                      New DatosParametros("@Art_StockFisico", SqlDbType.Int, pArticulo.StockFisico), _
                                      New DatosParametros("@Art_ID_Proveedor", SqlDbType.Int, pArticulo.IDProveedor)
                                 })
        Comando.Ejecucion("ModificarArticulo", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloValuacion As ArticuloValuacion)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@ArtVal_ID", SqlDbType.Int, pArticuloValuacion.ID), _
                                      New DatosParametros("@ArtVal_FIFO", SqlDbType.Int, pArticuloValuacion.CantidadFIFO), _
                                      New DatosParametros("@ArtVal_LIFO", SqlDbType.Int, pArticuloValuacion.CantidadLIFO)
                                  })
        Comando.Ejecucion("ModificarArticuloValuacion", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloPedidoDeCliente As ArticuloPedidoDeCliente, ByVal pPedidoDeCliente As PedidoDeCliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                        New DatosParametros("@ArtPedCli_ID_PedidoCliente", SqlDbType.Int, pPedidoDeCliente.ID), _
                                        New DatosParametros("@ArtPedCli_ID_Articulo", SqlDbType.Int, pArticuloPedidoDeCliente.ID), _
                                        New DatosParametros("@ArtPedCli_Solicitadas", SqlDbType.Int, pArticuloPedidoDeCliente.Solicitadas), _
                                        New DatosParametros("@ArtPedCli_Reservadas", SqlDbType.Int, pArticuloPedidoDeCliente.Reservadas), _
                                        New DatosParametros("@ArtPedCli_Pendientes", SqlDbType.Int, pArticuloPedidoDeCliente.Pendientes), _
                                        New DatosParametros("@ArtPedCli_Enviar", SqlDbType.Int, pArticuloPedidoDeCliente.Enviar)
                                    })
        Comando.Ejecucion("ModificarArticuloPedidoDeCliente", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloRemitoProveedor As ArticuloRemitoProveedor, ByVal pRemitoProveedor As RemitoProveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                        New DatosParametros("@ArtPedPro_ID_RemitoProveedor", SqlDbType.Int, pRemitoProveedor.ID), _
                                        New DatosParametros("@ArtPedPro_ID_Articulo", SqlDbType.Int, pArticuloRemitoProveedor.ID), _
                                        New DatosParametros("@ArtPedPro_Cantidad", SqlDbType.Int, pArticuloRemitoProveedor.Cantidad), _
                                        New DatosParametros("@ArtPedPro_CantidadIngresada", SqlDbType.Int, pArticuloRemitoProveedor.CantidadIngresada)
                                  })
        Comando.Ejecucion("ModificarArticuloRemitoProveedor", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloNotaDePedido As ArticuloNotaDePedido, ByVal pNotaDePedido As NotaDePedido)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                        New DatosParametros("@ArtNotPed_ID_NotaDePedido", SqlDbType.Int, pNotaDePedido.ID), _
                                        New DatosParametros("@ArtNotPed_ID_Articulo", SqlDbType.Int, pArticuloNotaDePedido.ID), _
                                        New DatosParametros("@ArtNotPed_Solicitadas", SqlDbType.Int, pArticuloNotaDePedido.Solicitadas), _
                                        New DatosParametros("@ArtNotPed_Pendientes", SqlDbType.Int, pArticuloNotaDePedido.Pendientes)
                                  })
        Comando.Ejecucion("ModificarArticuloNotaDePedido", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloNotaDeEnvio As ArticuloNotaDeEnvio, ByVal pNotaDeEnvio As NotaDeEnvio)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                        New DatosParametros("@NotEnv_ID_NotaDeEnvio", SqlDbType.Int, pNotaDeEnvio.ID), _
                                        New DatosParametros("@NotEnv_ID_Articulo", SqlDbType.Int, pArticuloNotaDeEnvio.ID), _
                                        New DatosParametros("@NotEnv_Cantidad", SqlDbType.Int, pArticuloNotaDeEnvio.Cantidad)
                                  })
        Comando.Ejecucion("ModificarArticuloNotaDeEnvio", vListaParametros)
    End Sub

    Public Sub Modificacion(ByRef pArticuloListaDePrecios As ArticuloListaDePrecios, ByVal pListaDePreciosCompra As ListaDePreciosCompra)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                        New DatosParametros("@ArLisPreC_ID_ListaDePrecios", SqlDbType.Int, pListaDePreciosCompra.ID), _
                                        New DatosParametros("@ArLisPreC_ID_Articulo", SqlDbType.Int, pArticuloListaDePrecios.ID), _
                                        New DatosParametros("@ArLisPreC_Precio", SqlDbType.Money, pArticuloListaDePrecios.Precio)
                                  })
        Comando.Ejecucion("ModificarArticuloListaDePreciosCompra", vListaParametros)
    End Sub

    Public Sub CrearArticulos(ByVal pListaDePreciosCompra As ListaDePreciosCompra)
        Try
            Dim vDTArticulos As DataTable
            Dim vParametros As New List(Of DatosParametros)
            vParametros.AddRange({
                New DatosParametros("@Art_IDProveedor", SqlDbType.Int, pListaDePreciosCompra.Proveedor.ID)
                                })
            vDTArticulos = Comando.EjecucionRetornoDataTable("ListarArticulos", vParametros)
            For Each vA As DataRow In vDTArticulos.Rows
                vParametros.Clear()
                vParametros.AddRange({
                 New DatosParametros("@ArtLisPreC_ID_ListaDePrecios", SqlDbType.Int, pListaDePreciosCompra.ID),
                 New DatosParametros("@ArtLisPreC_ID_Articulo", SqlDbType.Int, vA.Item(0))
                             })
                Comando.Ejecucion("AltaArticuloListaDePrecioCompra", vParametros)
            Next

        Catch ex As Exception

            MsgBox("Ocurrio un error no pudieron cargarse las traducciones.")
        End Try

    End Sub

End Class
