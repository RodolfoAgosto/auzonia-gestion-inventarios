Imports DAL
Imports BE
Public Class Articulo_NEG

    Implements INTERFACES.Iabmc(Of ArticuloStock)

    Dim vArticuloDAL As New Articulo_DAL

    Public Sub Alta(ByRef pObjeto As ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).Alta
        vArticuloDAL.Alta(pObjeto)
    End Sub

    Public Sub Baja(ByRef pObjeto As ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).Baja
        vArticuloDAL.Baja(pObjeto)
    End Sub

    Public Sub Consulta(ByRef pObjeto As ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).Consulta
        vArticuloDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As ArticuloStock) As List(Of ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As ArticuloStock, ByRef pObjeto2 As ArticuloStock) As List(Of ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).ConsultaRango
        Return vArticuloDAL.ConsultaRango(pObjeto1, pObjeto2)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ArticuloStock) As List(Of ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).ConsultaVarios
        Return vArticuloDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ArticuloPedidoDeCliente) As List(Of ArticuloPedidoDeCliente)
        Return vArticuloDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ArticuloNotaDePedido) As List(Of ArticuloNotaDePedido)
        Dim vListaArticuloStock As List(Of ArticuloStock)
        Dim vArticuloStockDeConsulta As ArticuloStock = CType(pObjeto, ArticuloStock)
        Dim vArticuloDAL As New Articulo_DAL
        vListaArticuloStock = vArticuloDAL.ConsultaVarios(vArticuloStockDeConsulta)
        Dim vListaArticuloNotaDePedido As New List(Of ArticuloNotaDePedido)

        For Each vAS As ArticuloStock In vListaArticuloStock
            Dim nuevoArticuloNotaDePedido As New ArticuloNotaDePedido With {
                .ID = vAS.ID,
                .Codigo = vAS.Codigo,
                .Descripcion = vAS.Descripcion,
                .PuntoDeReposicion = vAS.PuntoDeReposicion,
                .StockDeSeguridad = vAS.StockDeSeguridad,
                .StockFisico = vAS.StockFisico,
                .IDProveedor = vAS.IDProveedor
            }
            vListaArticuloNotaDePedido.Add(nuevoArticuloNotaDePedido)
        Next

        Me.CalcularStockDeSeguridad(vListaArticuloNotaDePedido)
        Me.CalcularReservadas(vListaArticuloNotaDePedido)
        Me.CalcularPendientesDeEntrega(vListaArticuloNotaDePedido)
        Me.CalcularPendientesDeIngreso(vListaArticuloNotaDePedido)
        Me.CalcularDisponibles(vListaArticuloNotaDePedido)
        Me.CalcularSolicitadas(vListaArticuloNotaDePedido)
        Return vListaArticuloNotaDePedido

    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ArticuloRemitoProveedor) As List(Of ArticuloRemitoProveedor)
        Dim vArticuloDAL As New Articulo_DAL
        Dim vListaArticuloRemitoProveedor As List(Of ArticuloRemitoProveedor)
        vListaArticuloRemitoProveedor = vArticuloDAL.ConsultaVarios(pObjeto)
        Return vListaArticuloRemitoProveedor
    End Function

    Public Sub Modificacion(ByRef pObjeto As ArticuloStock) Implements INTERFACES.Iabmc(Of ArticuloStock).Modificacion
        vArticuloDAL.Modificacion(pObjeto)
    End Sub

    Public Sub CalcularStockDeSeguridad(ByRef vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido))
        
        For Each vLANP As ArticuloNotaDePedido In vListaArticuloNotaDePedido
            Dim vCantMesAnoAnterior As Integer = 0
            Dim vCantTrimestreAnoAnterior As Integer = 0
            Dim vCantUltimoTrimestre As Integer = 0
            vCantMesAnoAnterior = Me.CalcularMesAnoAnterior(vLANP)
            vCantTrimestreAnoAnterior = Me.CalcularTrimestreAnoAnterior(vLANP)
            vCantUltimoTrimestre = Me.CalcularUltimoTrimestre(vLANP)
            If vCantMesAnoAnterior > 0 And vCantTrimestreAnoAnterior > 0 And vCantUltimoTrimestre > 0 Then
                Dim vRelacionIntreTrimestral As Double
                vRelacionIntreTrimestral = (vCantUltimoTrimestre * 100) / vCantTrimestreAnoAnterior
                vRelacionIntreTrimestral = vRelacionIntreTrimestral / 100
                vLANP.StockDeSeguridad = vCantMesAnoAnterior * vRelacionIntreTrimestral
            End If
        Next

    End Sub

    Private Function CalcularMesAnoAnterior(ByVal pArticuloNotaDePedido As ArticuloNotaDePedido) As Integer
        Dim vResultado As Integer = 0
        Dim vMovimientoNEG As New Movimiento_NEG
        Dim vFDesde As Date = Date.Now.AddDays(-365)
        Dim vFHAsta As Date = Date.Now.AddDays(-335)
        Dim vListaDeMovimientos As List(Of Movimiento)
        vListaDeMovimientos = vMovimientoNEG.ListarSalidas(pArticuloNotaDePedido, vFDesde, vFHAsta)
        For Each vMovimiento As Movimiento In vListaDeMovimientos
            vResultado += vMovimiento.Cantidad
        Next
        Return vResultado
    End Function

    Private Function CalcularTrimestreAnoAnterior(ByVal pArticuloNotaDePedido As ArticuloNotaDePedido) As Integer
        Dim vResultado As Integer = 0
        Dim vMovimientoNEG As New Movimiento_NEG
        Dim vFDesde As Date = Date.Now.AddDays(-455)
        Dim vFHAsta As Date = Date.Now.AddDays(-365)
        Dim vListaDeMovimientos As List(Of Movimiento)
        vListaDeMovimientos = vMovimientoNEG.ListarSalidas(pArticuloNotaDePedido, vFDesde, vFHAsta)
        For Each vMovimiento As Movimiento In vListaDeMovimientos
            vResultado += vMovimiento.Cantidad
        Next
        Return vResultado
    End Function

    Private Function CalcularUltimoTrimestre(ByVal pArticuloNotaDePedido As ArticuloNotaDePedido) As Integer
        Dim vResultado As Integer = 0
        Dim vMovimientoNEG As New Movimiento_NEG
        Dim vFDesde As Date = Date.Now.AddDays(-90)
        Dim vFHAsta As Date = Date.Now
        Dim vListaDeMovimientos As List(Of Movimiento)
        vListaDeMovimientos = vMovimientoNEG.ListarSalidas(pArticuloNotaDePedido, vFDesde, vFHAsta)
        For Each vMovimiento As Movimiento In vListaDeMovimientos
            vResultado += vMovimiento.Cantidad
        Next
        Return vResultado
    End Function

    Public Sub CalcularReservadas(ByRef vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido))

        Dim vDictionaryArticuloNotaDePedido As New Dictionary(Of Integer, ArticuloNotaDePedido)
        CompletarDiccionario(vListaArticuloNotaDePedido, vDictionaryArticuloNotaDePedido)
        Dim vListaDePedidoDeCliente As List(Of PedidoDeCliente)
        Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG
        Dim vPedidoDeCiente As New PedidoDeCliente With {
            .Estado = "Pendiente"
        }
        vListaDePedidoDeCliente = vPedidoDeClienteNEG.ConsultaVarios(vPedidoDeCiente)

        For Each vPDC As PedidoDeCliente In vListaDePedidoDeCliente
            vPedidoDeClienteNEG.Consulta(vPDC)
            For Each vAPDC As ArticuloPedidoDeCliente In vPDC.ListaDeArticulos
                If vDictionaryArticuloNotaDePedido.ContainsKey(vAPDC.ID) Then
                    vDictionaryArticuloNotaDePedido(vAPDC.ID).Reservadas = vDictionaryArticuloNotaDePedido(vAPDC.ID).Reservadas + vAPDC.Reservadas
                End If
            Next
        Next

    End Sub

    Public Sub CalcularPendientesDeEntrega(ByRef vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido))

        Dim vDictionaryArticuloNotaDePedido As New Dictionary(Of Integer, ArticuloNotaDePedido)
        CompletarDiccionario(vListaArticuloNotaDePedido, vDictionaryArticuloNotaDePedido)
        Dim vListaDePedidoDeCliente As List(Of PedidoDeCliente)
        Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG
        Dim vPedidoDeCiente As New PedidoDeCliente With {
            .Estado = "Pendiente"
        }
        vListaDePedidoDeCliente = vPedidoDeClienteNEG.ConsultaVarios(vPedidoDeCiente)

        For Each vPDC As PedidoDeCliente In vListaDePedidoDeCliente
            vPedidoDeClienteNEG.Consulta(vPDC)
            For Each vAPDC As ArticuloPedidoDeCliente In vPDC.ListaDeArticulos
                If vDictionaryArticuloNotaDePedido.ContainsKey(vAPDC.ID) Then
                    vDictionaryArticuloNotaDePedido(vAPDC.ID).PendientesDeEntrega = vDictionaryArticuloNotaDePedido(vAPDC.ID).PendientesDeEntrega + vAPDC.Pendientes
                End If
            Next
        Next

    End Sub

    Public Sub CalcularPendientesDeIngreso(ByRef vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido))

        Dim vDictionaryArticuloNotaDePedido As New Dictionary(Of Integer, ArticuloNotaDePedido)
        CompletarDiccionario(vListaArticuloNotaDePedido, vDictionaryArticuloNotaDePedido)

        Dim vListaNotaDePedido As List(Of NotaDePedido)
        Dim vNotaDePedidoNEG As New NotaDePedido_NEG
        Dim vNotaDePedido As New NotaDePedido With {
            .Estado = "Pendiente"
        }
        Dim vproveedor As New Proveedor With {
            .ID = vListaArticuloNotaDePedido.Item(0).IDProveedor
        }
        vNotaDePedido.Proveedor = vproveedor
        vListaNotaDePedido = vNotaDePedidoNEG.ConsultaVarios(vNotaDePedido)

        If Not vListaNotaDePedido Is Nothing Then
            For Each vNDP As NotaDePedido In vListaNotaDePedido
                vNotaDePedidoNEG.Consulta(vNDP)
                For Each vANDP As ArticuloNotaDePedido In vNDP.ListaDeArticulos
                    If vDictionaryArticuloNotaDePedido.ContainsKey(vANDP.ID) Then
                        vDictionaryArticuloNotaDePedido(vANDP.ID).PendientesDeIngreso = vDictionaryArticuloNotaDePedido(vANDP.ID).PendientesDeIngreso + vANDP.Pendientes
                    End If
                Next
            Next
        End If

    End Sub

    Public Sub CalcularDisponibles(ByRef vListardeArticuloNotaDePedido As List(Of ArticuloNotaDePedido))
        For Each vANDP As ArticuloNotaDePedido In vListardeArticuloNotaDePedido
            vANDP.Disponible = vANDP.StockFisico - vANDP.Reservadas
        Next
    End Sub

    Public Sub CalcularSolicitadas(ByRef vListardeArticuloNotaDePedido As List(Of ArticuloNotaDePedido))
        For Each vANDP As ArticuloNotaDePedido In vListardeArticuloNotaDePedido
            vANDP.Solicitadas = vANDP.StockDeSeguridad - vANDP.StockFisico + vANDP.Reservadas - vANDP.PendientesDeIngreso + vANDP.PendientesDeEntrega
            If vANDP.Solicitadas < 0 Then
                vANDP.Solicitadas = 0
            End If
        Next
    End Sub

    Private Sub CompletarDiccionario(ByRef pListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido), ByRef pDictionaryArticuloNotaDePedido As Dictionary(Of Integer, ArticuloNotaDePedido))
        pDictionaryArticuloNotaDePedido.Clear()
        For Each vAPDC As ArticuloNotaDePedido In pListaArticuloNotaDePedido
            pDictionaryArticuloNotaDePedido.Add(vAPDC.ID, vAPDC)
        Next
    End Sub



End Class
