Imports DAL
Imports BE

Public Class Cliente_NEG

    Implements INTERFACES.Iabmc(Of Cliente)

    Dim vClienteDAL As New Cliente_DAL

    Public Sub Alta(ByRef pCliente As Cliente) Implements INTERFACES.Iabmc(Of Cliente).Alta
        vClienteDAL.Alta(pCliente)
    End Sub

    Public Sub Baja(ByRef pCliente As Cliente) Implements INTERFACES.Iabmc(Of Cliente).Baja
        vClienteDAL.Baja(pCliente)
    End Sub

    Public Sub Consulta(ByRef pCliente As Cliente) Implements INTERFACES.Iabmc(Of Cliente).Consulta
        vClienteDAL.Consulta(pCliente)
    End Sub

    Public Function ConsultaIncremental(ByRef pCliente As Cliente) As List(Of Cliente) Implements INTERFACES.Iabmc(Of Cliente).ConsultaIncremental
        Return vClienteDAL.ConsultaIncremental(pCliente)
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As Cliente, ByRef pObjeto2 As Cliente) As List(Of Cliente) Implements INTERFACES.Iabmc(Of Cliente).ConsultaRango
        Return vClienteDAL.ConsultaRango(pObjeto1, pObjeto2)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As Cliente) As List(Of Cliente) Implements INTERFACES.Iabmc(Of Cliente).ConsultaVarios
        Return vClienteDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVariosCltePedidoDeClienteArticuloPedCiente(ByRef pCliente As Cliente) As List(Of Cliente)
        Return vClienteDAL.ConsultaVariosCltePedidoDeClienteArticuloPedCiente(pCliente)
    End Function


    Public Sub Modificacion(ByRef pCliente As Cliente) Implements INTERFACES.Iabmc(Of Cliente).Modificacion
        vClienteDAL.Modificacion(pCliente)
    End Sub


End Class
