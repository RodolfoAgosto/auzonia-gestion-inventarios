Imports BE
Imports DAL

Public Class Remito_NEG

    Private _ListaClientes As List(Of Cliente)
    Public Property ListaClientes() As List(Of Cliente)
        Get
            Return _ListaClientes
        End Get
        Set(ByVal value As List(Of Cliente))
            _ListaClientes = value
        End Set
    End Property

    Public Sub GenerarRemito(ByRef pNotaDeEnvio As NotaDeEnvio)
        'Invoca la generación de un remito para cada uno de los clientes asociados al vendedor de la nota de envío.
        Dim vCliente As New Cliente
        vCliente.IDVendedor = pNotaDeEnvio.IDVendedor
        Dim vClienteNEG As New Cliente_NEG
        Me.ListaClientes = vClienteNEG.ConsultaVariosCltePedidoDeClienteArticuloPedCiente(vCliente)
        For Each vCli As Cliente In Me.ListaClientes
            GenerarRemitoCliente(vCli)
        Next
    End Sub

    Private Sub GenerarRemitoCliente(ByRef pCliente As Cliente)
        Dim vRemito As New Remito
        vRemito.Cliente = pCliente
        Dim vPedidoDelClienteNEG As New PedidoDeCliente_NEG
        Dim listaArticuloRemito As New List(Of ArticuloRemito)
        vRemito.ListaArticuloRemito = listaArticuloRemito
        If Not pCliente.ListaPedidoDeCliente Is Nothing Then
            For Each vPediCli As PedidoDeCliente In pCliente.ListaPedidoDeCliente
                Me.IncluirPedidoDeCliente(vRemito, vPediCli)
                Dim vCambiarEstado As Boolean = True
                For Each vArticulo As ArticuloPedidoDeCliente In vPediCli.ListaDeArticulos
                    If vArticulo.Enviar > 0 Then
                        If vArticulo.Reservadas >= vArticulo.Enviar Then
                            vArticulo.Reservadas = vArticulo.Reservadas - vArticulo.Enviar
                            vArticulo.Enviar = 0
                        Else
                            vArticulo.Enviar = vArticulo.Enviar - vArticulo.Reservadas
                            vArticulo.Reservadas = 0
                        End If
                        If vArticulo.Pendientes >= vArticulo.Enviar Then
                            vArticulo.Pendientes = vArticulo.Pendientes - vArticulo.Enviar
                            vArticulo.Enviar = 0
                        Else
                            vArticulo.Enviar = vArticulo.Enviar - vArticulo.Pendientes
                            vArticulo.Pendientes = 0
                        End If
                        vArticulo.Enviar = 0
                    End If
                    If vArticulo.Reservadas > 0 Or vArticulo.Pendientes > 0 Then
                        vCambiarEstado = False
                    End If
                Next
                If vCambiarEstado Then
                    vPediCli.Estado = "Entregado"
                End If

                vPedidoDelClienteNEG.Modificacion(vPediCli)
            Next
            Dim vRemitoDAL As New Remito_DAL
            vRemitoDAL.Alta(vRemito)
            Me.RegistrarMovimiento(vRemito)

        End If
    End Sub

    Private Sub IncluirPedidoDeCliente(ByRef pRemito As Remito, ByRef pPedidoDeCliente As PedidoDeCliente)
        For Each vArtPediCli As ArticuloPedidoDeCliente In pPedidoDeCliente.ListaDeArticulos
            If vArtPediCli.Enviar > 0 Then
                If pRemito.Diccionario.ContainsKey(vArtPediCli.ID) Then
                    pRemito.Diccionario(vArtPediCli.ID).Cantidad = pRemito.Diccionario(vArtPediCli.ID).Cantidad + vArtPediCli.Enviar
                Else
                    Dim vNuevoArticuloRemito As ArticuloRemito = New ArticuloRemito(vArtPediCli.ID, vArtPediCli.IDProveedor, vArtPediCli.Codigo, vArtPediCli.Descripcion, vArtPediCli.Enviar)
                    pRemito.ListaArticuloRemito.Add(vNuevoArticuloRemito)
                    pRemito.Diccionario.Add(vNuevoArticuloRemito.ID, vNuevoArticuloRemito)
                End If
            End If
        Next
    End Sub

    Private Sub RegistrarMovimiento(ByRef pRemito As Remito)

        For Each vArticuloRemito As ArticuloRemito In pRemito.ListaArticuloRemito
            Dim vMovimiento As New Movimiento
            Dim vMovimientoNEG As New Movimiento_NEG
            vMovimiento.Tipo = "Salida"
            vMovimiento.Articulo = vArticuloRemito
            vMovimiento.Documento = "Remito"
            vMovimiento.IDDocumento = pRemito.ID
            vMovimiento.Cantidad = vArticuloRemito.Cantidad
            vMovimientoNEG.Alta(vMovimiento)
        Next
        RegistrarSalida(pRemito)
    End Sub

    Private Sub RegistrarSalida(ByRef pRemito As Remito)
        Dim vValuacionNEG As New Valuacion_NEG
        vValuacionNEG.RegistrarSalida(pRemito)
        ActualizarPedidoDeCliente()
    End Sub

    Private Sub ActualizarPedidoDeCliente()
        Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG
        For Each vC As Cliente In Me.ListaClientes
            For Each vPC As PedidoDeCliente In vC.ListaPedidoDeCliente
                vPedidoDeClienteNEG.Modificacion(vPC)
            Next
        Next
    End Sub

End Class
