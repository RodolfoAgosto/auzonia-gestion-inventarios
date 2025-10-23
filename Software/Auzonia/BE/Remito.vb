Public Class Remito

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

    Private _Cliente As Cliente
    Public Property Cliente() As Cliente
        Get
            Return _Cliente
        End Get
        Set(ByVal value As Cliente)
            _Cliente = value
        End Set
    End Property

    Private _ListaDeArticuloRemito As List(Of ArticuloRemito)
    Public Property ListaArticuloRemito() As List(Of ArticuloRemito)
        Get
            Return _ListaDeArticuloRemito
        End Get
        Set(ByVal value As List(Of ArticuloRemito))
            _ListaDeArticuloRemito = value
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

    Private _Diccionario As Dictionary(Of Integer, ArticuloRemito)
    Public Property Diccionario() As Dictionary(Of Integer, ArticuloRemito)
        Get
            Return _Diccionario
        End Get
        Set(ByVal value As Dictionary(Of Integer, ArticuloRemito))
            _Diccionario = value
        End Set
    End Property

    Sub New()
        Me.Diccionario = New Dictionary(Of Integer, ArticuloRemito)
    End Sub


End Class
