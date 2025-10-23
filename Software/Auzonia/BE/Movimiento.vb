Public Class Movimiento

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property

    Private _Tipo As String
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Private _Articulo As Articulo
    Public Property Articulo() As Articulo
        Get
            Return _Articulo
        End Get
        Set(ByVal value As Articulo)
            _Articulo = value
        End Set
    End Property

    Private _Documento As String
    Public Property Documento() As String
        Get
            Return _Documento
        End Get
        Set(ByVal value As String)
            _Documento = value
        End Set
    End Property

    Private _IDDocumento As Integer
    Public Property IDDocumento() As Integer
        Get
            Return _IDDocumento
        End Get
        Set(ByVal value As Integer)
            _IDDocumento = value
        End Set
    End Property

    Private _Cantidad As Integer
    Public Property Cantidad() As Integer
        Get
            Return _Cantidad
        End Get
        Set(ByVal value As Integer)
            _Cantidad = value
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
