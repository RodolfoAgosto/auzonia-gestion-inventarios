Imports BE
Imports DAL
Public Class Valuacion_NEG

    Dim vArticuloValuacionDAL As New Articulo_DAL

    Public Sub RegistrarSalida(ByRef pRemito As Remito)

        For Each vARTR As ArticuloRemito In pRemito.ListaArticuloRemito
            Dim vListaArticuloValuacion As List(Of ArticuloValuacion)
            Dim vArticuloValuacionConsulta As New ArticuloValuacion
            Dim vArticuloStock As New ArticuloStock
            vArticuloValuacionConsulta.Articulo = vArticuloStock
            vArticuloValuacionConsulta.Articulo.ID = vARTR.ID
            vListaArticuloValuacion = vArticuloValuacionDAL.ConsultaVarios(vArticuloValuacionConsulta)
            RestarFIFO(vARTR, vListaArticuloValuacion)
            RestarLIFO(vARTR, vListaArticuloValuacion)
            For Each vARTV As ArticuloValuacion In vListaArticuloValuacion
                vArticuloValuacionDAL.Modificacion(vARTV)
            Next
        Next
       
    End Sub

    Public Sub RegistrarIngreso(ByRef pRemitoProveedor As RemitoProveedor)
        For Each vARP As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
            Dim vNuevaValuacion As New ArticuloValuacion
            Dim vNuevoArticuloStock As New ArticuloStock With {
                .ID = vARP.ID,
                .Codigo = vARP.Codigo
            }
            vNuevaValuacion.Articulo = vNuevoArticuloStock
            vNuevaValuacion.CantidadFIFO = vARP.Cantidad
            vNuevaValuacion.CantidadLIFO = vARP.Cantidad
            vArticuloValuacionDAL.Alta(vNuevaValuacion)
        Next

    End Sub

    Private Sub RestarFIFO(ByRef pArticulo As ArticuloRemito, ByRef vListaArticulosValuacion As List(Of ArticuloValuacion))
        Dim vCantidad As Integer = pArticulo.Cantidad
        Dim vListaFIFO = From av In vListaArticulosValuacion Order By av.ID Ascending
        For Each vArticuloValuacion As ArticuloValuacion In vListaFIFO
            If vArticuloValuacion.CantidadFIFO > vCantidad Or vArticuloValuacion.CantidadFIFO = vCantidad Then
                vArticuloValuacion.CantidadFIFO = vArticuloValuacion.CantidadFIFO - vCantidad
                vCantidad = 0
            Else
                vCantidad = vCantidad - vArticuloValuacion.CantidadFIFO
                vArticuloValuacion.CantidadFIFO = 0
            End If
        Next

    End Sub

    Private Sub RestarLIFO(ByRef pArticulo As ArticuloRemito, ByRef vListaArticulosValuacion As List(Of ArticuloValuacion))
        Dim vCantidad As Integer = pArticulo.Cantidad
        Dim vListaLIFO = From av In vListaArticulosValuacion Order By av.ID Descending
        For Each vArticuloValuacion As ArticuloValuacion In vListaLIFO
            If vArticuloValuacion.CantidadLIFO > vCantidad Or vArticuloValuacion.CantidadLIFO = vCantidad Then
                vArticuloValuacion.CantidadLIFO = vArticuloValuacion.CantidadLIFO - vCantidad
                vCantidad = 0
            Else
                vCantidad = vCantidad - vArticuloValuacion.CantidadLIFO
                vArticuloValuacion.CantidadLIFO = 0
            End If
        Next


    End Sub

    Public Function CalcularValuacion(ByVal pProveedor As Proveedor) As List(Of ArticuloValuacion)
        Dim vListaArticuloValuacion As New List(Of ArticuloValuacion)
        Dim vArticuloNEG As New Articulo_NEG
        Dim vArticuloStockConsulta As New ArticuloStock With {
            .IDProveedor = pProveedor.ID
        }
        Dim vListaArticuloStock As List(Of ArticuloStock) = vArticuloNEG.ConsultaVarios(vArticuloStockConsulta)
        For Each vAS As ArticuloStock In vListaArticuloStock
            Dim vNuevoArticuloValuacion As New ArticuloValuacion With {
                .Articulo = vAS,
                .ID = vAS.ID,
                .Codigo = vAS.Codigo,
                .Descripcion = vAS.Descripcion
            }
            vListaArticuloValuacion.Add(vNuevoArticuloValuacion)
        Next
        For Each vAV As ArticuloValuacion In vListaArticuloValuacion
            Me.ValuarArticulo(vAV)
        Next
        Return vListaArticuloValuacion
    End Function

    Private Sub ValuarArticulo(ByRef vArticuloValuacion As ArticuloValuacion)
        Dim vArticuloDAL As New Articulo_DAL
        Dim vListaArticuloValuacion As List(Of ArticuloValuacion)
        vListaArticuloValuacion = vArticuloDAL.ConsultaVarios(vArticuloValuacion)
        Dim vListaDePreciosDAL As New ListaDePrecios_DAL
        Dim vPrecio As Double = 0
        Dim vValorASumarLIFO As Double = 0
        Dim vValorASumarFIFO As Double = 0
        For Each vAV As ArticuloValuacion In vListaArticuloValuacion
            vPrecio = vListaDePreciosDAL.ConsultarPrecio(vAV.Articulo.ID, vAV.IDListaDePrecios)
            vValorASumarLIFO += vPrecio * vAV.CantidadLIFO
            vValorASumarFIFO += vPrecio * vAV.CantidadFIFO
        Next
        vArticuloValuacion.ValuacionLIFO = vValorASumarLIFO
        vArticuloValuacion.ValuacionFIFO = vValorASumarFIFO
    End Sub

End Class
