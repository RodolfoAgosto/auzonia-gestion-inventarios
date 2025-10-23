Public Class RemitoProveedor

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Proveedor As Proveedor
    Public Property Proveedor() As Proveedor
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As Proveedor)
            _Proveedor = value
        End Set
    End Property

    Private _FechaDeCreacion As Date
    Public Property FechaDeCreacion() As Date
        Get
            Return _FechaDeCreacion
        End Get
        Set(ByVal value As Date)
            _FechaDeCreacion = value
        End Set
    End Property

    Private _ListaDeArticulos As List(Of ArticuloRemitoProveedor)
    Public Property ListaDeArticulos() As List(Of ArticuloRemitoProveedor)
        Get
            Return _ListaDeArticulos
        End Get
        Set(ByVal value As List(Of ArticuloRemitoProveedor))
            _ListaDeArticulos = value
        End Set
    End Property

    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
        End Set
    End Property

    Private _Numero As String
    Public Property Numero() As String
        Get
            Return _Numero
        End Get
        Set(ByVal value As String)
            _Numero = value
        End Set
    End Property


    Public Sub New()

    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pFechaDeCreacion As Date, ByVal pEstado As String, ByVal pNumero As String)
        Me.ID = pID
        Me.FechaDeCreacion = pFechaDeCreacion
        Me.Estado = pEstado
        Me.Numero = pNumero
    End Sub

End Class
