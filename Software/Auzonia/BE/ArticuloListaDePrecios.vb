Public Class ArticuloListaDePrecios

    Inherits Articulo

    Private _Precio As Double
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pPrecio As Double)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Precio = pPrecio
    End Sub

End Class
