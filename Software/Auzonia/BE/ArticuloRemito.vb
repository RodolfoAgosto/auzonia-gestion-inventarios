Public Class ArticuloRemito
    Inherits Articulo

    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pId As Integer, ByVal pIDProveedor As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pCantidad As Integer)
        Me.ID = pId
        Me.IDProveedor = pIDProveedor
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Cantidad = pCantidad
    End Sub

End Class
