Imports DAL
Imports BE

Public Class Proveedor_NEG

    Implements INTERFACES.Iabmc(Of Proveedor)

    Dim vProveedorDAL As New Proveedor_DAL

    Public Sub Alta(ByRef pProveedor As Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).Alta
        vProveedorDAL.Alta(pProveedor)
    End Sub

    Public Sub Baja(ByRef pProveedor As Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).Baja
        vProveedorDAL.Baja(pProveedor)
    End Sub

    Public Sub Consulta(ByRef pProveedor As Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).Consulta
        vProveedorDAL.Consulta(pProveedor)
    End Sub

    Public Function ConsultaIncremental(ByRef pProveedor As Proveedor) As List(Of Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).ConsultaIncremental
        Return vProveedorDAL.ConsultaIncremental(pProveedor)
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As Proveedor, ByRef pObjeto2 As Proveedor) As List(Of Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).ConsultaRango
        Return vProveedorDAL.ConsultaRango(pObjeto1, pObjeto2)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As Proveedor) As List(Of Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).ConsultaVarios
        Return vProveedorDAL.ConsultaVarios(pObjeto)
    End Function

    Public Sub Modificacion(ByRef pProveedor As Proveedor) Implements INTERFACES.Iabmc(Of Proveedor).Modificacion
        vProveedorDAL.Modificacion(pProveedor)
    End Sub

End Class
