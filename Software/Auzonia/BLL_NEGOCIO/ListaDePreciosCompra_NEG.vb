Imports BE
Imports INTERFACES
Imports DAL
Public Class ListaDePreciosCompra_NEG
    Implements Iabmc(Of ListaDePreciosCompra)

    Dim vListaDePreciosCompraDAL As New ListaDePrecios_DAL

    Public Sub Alta(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Alta
        vListaDePreciosCompraDAL.Alta(pObjeto)
    End Sub

    Public Sub Baja(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Consulta

    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As ListaDePreciosCompra, ByRef pObjeto2 As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaVarios
        Return vListaDePreciosCompraDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVariosLPDCArticulo(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra)
        Return vListaDePreciosCompraDAL.ConsultaVariosLPDCArticulo(pObjeto)
    End Function

    Public Sub Modificacion(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Modificacion
        vListaDePreciosCompraDAL.Modificacion(pObjeto)
    End Sub

End Class
