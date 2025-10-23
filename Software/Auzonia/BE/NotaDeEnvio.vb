Public Class NotaDeEnvio

    Private _ListaDeArticuloDeEnvio As List(Of ArticuloNotaDeEnvio)
    Public Property ListaDeArticuloDeEnvio() As List(Of ArticuloNotaDeEnvio)
        Get
            Return _ListaDeArticuloDeEnvio
        End Get
        Set(ByVal value As List(Of ArticuloNotaDeEnvio))
            _ListaDeArticuloDeEnvio = value
        End Set
    End Property

    Private _Diccionario As Dictionary(Of Integer, ArticuloNotaDeEnvio)
    Public Property Diccionario() As Dictionary(Of Integer, ArticuloNotaDeEnvio)
        Get
            Return _Diccionario
        End Get
        Set(ByVal value As Dictionary(Of Integer, ArticuloNotaDeEnvio))
            _Diccionario = value
        End Set
    End Property

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
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

    Private _Estado As String
    Public Property Estado() As String
        Get
            Return _Estado
        End Get
        Set(ByVal value As String)
            _Estado = value
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

    Private _IDVendedor As Integer
    Public Property IDVendedor() As Integer
        Get
            Return _IDVendedor
        End Get
        Set(ByVal value As Integer)
            _IDVendedor = value
        End Set
    End Property

    Sub New()
        Me.Diccionario = New Dictionary(Of Integer, ArticuloNotaDeEnvio)
    End Sub

    Sub New(ByVal pID As Integer, ByVal pFechaDeCreacion As Date, ByVal pFechaDeEntrega As Date, ByVal pEstado As String, ByVal pComentarios As String, ByVal pIDVendedor As Integer)
        Me.ID = pID
        Me.FechaDeCreacion = pFechaDeCreacion
        Me.FechaDeEntrega = pFechaDeEntrega
        Me.Estado = pEstado
        Me.Comentarios = pComentarios
        Me.IDVendedor = pIDVendedor
    End Sub

End Class
