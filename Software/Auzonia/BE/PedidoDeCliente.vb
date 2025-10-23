Public Class PedidoDeCliente

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Cliente)
            _Cliente = value
        End Set
    End Property

    Private _ListaDeArticulos As List(Of ArticuloPedidoDeCliente)
    Public Property ListaDeArticulos() As List(Of ArticuloPedidoDeCliente)
        Get
            Return _ListaDeArticulos
        End Get
        Set(ByVal value As List(Of ArticuloPedidoDeCliente))
            _ListaDeArticulos = value
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

    Private _FechaDeEntrega As Date
    Public Property FechaDeEntrega() As Date
        Get
            Return _FechaDeEntrega
        End Get
        Set(ByVal value As Date)
            _FechaDeEntrega = value
        End Set
    End Property

    Private _Comentarios As String
    Public Property Comentarios() As String
        Get
            Return _Comentarios
        End Get
        Set(ByVal value As String)
            _Comentarios = value
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

    Sub New()

    End Sub

    Sub New(ByVal pID As Integer, ByVal pFechaDeCreacion As Date, ByVal pFechaDeEntrega As Date, ByVal pComentarios As String, ByVal pEstado As String)
        Me.ID = pID
        Me.FechaDeCreacion = pFechaDeCreacion
        Me.FechaDeEntrega = pFechaDeEntrega
        Me.Comentarios = pComentarios
        Me.Estado = pEstado
    End Sub

End Class
