Imports DAL
Imports BE

Public Class Movimiento_NEG

    Dim vMovimientoDAL As New Movimiento_DAL

    Public Sub Alta(ByRef pMovimiento As Movimiento)
        vMovimientoDAL.Alta(pMovimiento)
    End Sub

    Public Function ListarSalidas(ByVal pArticuloNotaDePedido As ArticuloNotaDePedido, ByVal pFechaDesde As Date, ByVal pFechaHasta As Date) As List(Of Movimiento)
        Return vMovimientoDAL.ListarSalidas(pArticuloNotaDePedido, pFechaDesde, pFechaHasta)
    End Function

End Class
