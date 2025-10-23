Public Class ArticuloRemitoProveedor

    Inherits ArticuloNotaDeEnvio

    Private _CantidadIngresada As Integer
    Public Property CantidadIngresada() As Integer
        Get
            Return _CantidadIngresada
        End Get
        Set(ByVal value As Integer)
            _CantidadIngresada = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.IDProveedor = pIDProveedor
        Me.Cantidad = 0
        Me.CantidadIngresada = 0
    End Sub

    Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer, ByVal pCantidad As Integer, ByVal pCantidadIngresada As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.IDProveedor = pIDProveedor
        Me.Cantidad = pCantidad
        Me.CantidadIngresada = pCantidadIngresada
    End Sub

End Class
