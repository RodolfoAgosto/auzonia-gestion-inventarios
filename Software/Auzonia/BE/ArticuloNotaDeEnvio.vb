Public Class ArticuloNotaDeEnvio

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

    Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer, ByVal pCantidad As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.IDProveedor = pIDProveedor
        Me.Cantidad = pCantidad
    End Sub

End Class
