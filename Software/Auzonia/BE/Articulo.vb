Public MustInherit Class Articulo

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _Descripcion As String
    Public Property Descripcion() As String
        Get
            Return _Descripcion
        End Get
        Set(ByVal value As String)
            _Descripcion = value
        End Set
    End Property

    Private _IDProveedor As Integer
    Public Property IDProveedor() As Integer
        Get
            Return _IDProveedor
        End Get
        Set(ByVal value As Integer)
            _IDProveedor = value
        End Set
    End Property


End Class
