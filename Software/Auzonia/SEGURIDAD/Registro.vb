Public Class Registro

    Private _Detalle As String
    Public Property Detalle() As String
        Get
            Return _Detalle
        End Get
        Set(ByVal value As String)
            _Detalle = value
        End Set
    End Property

End Class
