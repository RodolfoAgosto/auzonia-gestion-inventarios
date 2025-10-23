Imports DAL
Imports BE
Public Class RemitoProveedor_NEG
    Implements INTERFACES.Iabmc(Of RemitoProveedor)

    Public Sub Alta(ByRef pObjeto As RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).Alta
        Dim vRemitoProveedorDAL As New RemitoProveedor_DAL
        vRemitoProveedorDAL.Alta(pObjeto)
    End Sub

    Public Sub Baja(ByRef pObjeto As RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).Consulta
        Dim vRemitoProveedorDAL As New RemitoProveedor_DAL
        vRemitoProveedorDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As RemitoProveedor) As List(Of RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As RemitoProveedor, ByRef pObjeto2 As RemitoProveedor) As List(Of RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As RemitoProveedor) As List(Of RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).ConsultaVarios
        Dim vRemitoProveedorDAL As New RemitoProveedor_DAL
        Return vRemitoProveedorDAL.ConsultaVarios(pObjeto)
    End Function

    Public Sub Modificacion(ByRef pObjeto As RemitoProveedor) Implements INTERFACES.Iabmc(Of RemitoProveedor).Modificacion
        Dim vRemitoProveedorDAL As New RemitoProveedor_DAL
        vRemitoProveedorDAL.Modificacion(pObjeto)
    End Sub

    Public Sub IngresarRemito(ByRef pObjeto As RemitoProveedor)
        If pObjeto.Estado = "Ingresado" Then
            Me.ActualizarStock(pObjeto)
            Me.IngresarMovimientos(pObjeto)
            Me.ActualizarValuacion(pObjeto)
            Me.Modificacion(pObjeto)
            Me.ActualizarNotasDePedido(pObjeto)
        End If
    End Sub

    Private Sub ActualizarStock(ByRef pRemitoProveedor As RemitoProveedor)
        Dim vDictionaryArticuloStock As New Dictionary(Of Integer, ArticuloStock)
        Dim vListaArticuloStock As New List(Of ArticuloStock)
        Dim vArticuloStockDeBusqueda As New ArticuloStock
        vArticuloStockDeBusqueda.IDProveedor = pRemitoProveedor.Proveedor.ID
        Dim vArticuloStockNEG As New Articulo_NEG
        vListaArticuloStock = vArticuloStockNEG.ConsultaVarios(vArticuloStockDeBusqueda)
        vDictionaryArticuloStock.Clear()
        For Each vAS As ArticuloStock In vListaArticuloStock
            vDictionaryArticuloStock.Add(vAS.ID, vAS)
        Next
        'Ingreso al stock las cantidades.
        For Each vAS As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
            vDictionaryArticuloStock.Item(vAS.ID).StockFisico += vAS.CantidadIngresada
            vArticuloStockNEG.Modificacion(vDictionaryArticuloStock.Item(vAS.ID))
        Next
    End Sub

    Private Sub IngresarMovimientos(ByRef pRemitoProveedor As RemitoProveedor)
        For Each vAR As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
            If vAR.CantidadIngresada > 0 Then
                Dim vNuevoMovimiento As New Movimiento
                Dim vMovimientoNEG As New Movimiento_NEG
                vNuevoMovimiento.Tipo = "Ingreso"
                vNuevoMovimiento.Articulo = vAR
                vNuevoMovimiento.IDProveedor = pRemitoProveedor.Proveedor.ID
                vNuevoMovimiento.Documento = "Remito Proveedor"
                vNuevoMovimiento.IDDocumento = pRemitoProveedor.ID
                vNuevoMovimiento.Cantidad = vAR.CantidadIngresada
                vMovimientoNEG.Alta(vNuevoMovimiento)
            End If
        Next
    End Sub

    Private Sub ActualizarValuacion(ByRef pRemitoProveedor As RemitoProveedor)
        Dim vValuacionNEG As New Valuacion_NEG
        vValuacionNEG.RegistrarIngreso(pRemitoProveedor)
    End Sub

    Private Sub ActualizarNotasDePedido(ByRef pRemitoProveedor As RemitoProveedor)

        Dim vDictionaryArticuloRemitoProveedor As New Dictionary(Of Integer, ArticuloRemitoProveedor)
        vDictionaryArticuloRemitoProveedor.Clear()
        For Each vARP As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
            vDictionaryArticuloRemitoProveedor.Add(vARP.ID, vARP)
        Next
        Dim vNotaDePedidoConsulta As New NotaDePedido
        Dim vNotaDePedidoNEG As New NotaDePedido_NEG
        vNotaDePedidoConsulta.Proveedor = pRemitoProveedor.Proveedor
        vNotaDePedidoConsulta.Estado = "Pendiente"
        Dim vListaNotaDePedido As List(Of NotaDePedido)
        vListaNotaDePedido = vNotaDePedidoNEG.ConsultaVarios(vNotaDePedidoConsulta)
        For Each vNotadePedido As NotaDePedido In vListaNotaDePedido
            vNotaDePedidoNEG.Consulta(vNotadePedido)
            Dim vEntregada As Boolean = True
            For Each vArticulo As ArticuloNotaDePedido In vNotadePedido.ListaDeArticulos
                If vDictionaryArticuloRemitoProveedor.ContainsKey(vArticulo.ID) Then
                    If vArticulo.Pendientes >= vDictionaryArticuloRemitoProveedor(vArticulo.ID).CantidadIngresada Then
                        vArticulo.Pendientes -= vDictionaryArticuloRemitoProveedor(vArticulo.ID).CantidadIngresada
                        vDictionaryArticuloRemitoProveedor(vArticulo.ID).CantidadIngresada -= vDictionaryArticuloRemitoProveedor(vArticulo.ID).CantidadIngresada
                    Else
                        vArticulo.Pendientes -= vArticulo.Pendientes
                        vDictionaryArticuloRemitoProveedor(vArticulo.ID).CantidadIngresada -= vArticulo.Pendientes
                    End If
                    If vArticulo.Pendientes > 0 Then
                        vEntregada = False
                    End If
                End If
            Next
            If vEntregada Then
                vNotadePedido.Estado = "Entregada"
            End If
            vNotaDePedidoNEG.Modificacion(vNotadePedido)
        Next
    End Sub

End Class
