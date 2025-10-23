Imports DAL
Imports BE
Public Class PedidoDeCliente_NEG
    Implements INTERFACES.Iabmc(Of PedidoDeCliente)

    Public Sub Alta(ByRef pObjeto As PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).Alta
        Dim vPedidoDeClienteDAL As New PedidoDeCliente_DAL
        vPedidoDeClienteDAL.Alta(pObjeto)
    End Sub

    Public Sub Baja(ByRef pObjeto As PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).Consulta
        Dim vPedidoDeClienteDAL As New PedidoDeCliente_DAL
        vPedidoDeClienteDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As PedidoDeCliente) As List(Of PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As PedidoDeCliente, ByRef pObjeto2 As PedidoDeCliente) As List(Of PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As PedidoDeCliente) As List(Of PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).ConsultaVarios
        Dim vPedidoDeClienteDAL As New PedidoDeCliente_DAL
        Return vPedidoDeClienteDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVarios() As List(Of PedidoDeCliente)
        Dim vPedidoDeCliente As New PedidoDeCliente
        Return Me.ConsultaVarios(vPedidoDeCliente)
    End Function

    Public Sub Modificacion(ByRef pObjeto As PedidoDeCliente) Implements INTERFACES.Iabmc(Of PedidoDeCliente).Modificacion
        Dim vPedidoDeClienteDAL As New PedidoDeCliente_DAL
        vPedidoDeClienteDAL.Modificacion(pObjeto)
    End Sub

End Class
