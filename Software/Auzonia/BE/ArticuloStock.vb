Public Class ArticuloStock

    Inherits Articulo

    Private _PuntoDeReposicion As Integer
    Public Property PuntoDeReposicion() As Integer
        Get
            Return _PuntoDeReposicion
        End Get
        Set(ByVal value As Integer)
            _PuntoDeReposicion = value
        End Set
    End Property

    Private _StockDeSeguridad As Integer
    Public Property StockDeSeguridad() As Integer
        Get
            Return _StockDeSeguridad
        End Get
        Set(ByVal value As Integer)
            _StockDeSeguridad = value
        End Set
    End Property

    Private _StockFisico As Integer
    Public Property StockFisico() As Integer
        Get
            Return _StockFisico
        End Get
        Set(ByVal value As Integer)
            _StockFisico = value
        End Set
    End Property

    Private _Reservadas As Integer
    Public Property Reservadas() As Integer
        Get
            Return _Reservadas
        End Get
        Set(ByVal value As Integer)
            _Reservadas = value
        End Set
    End Property

    Private _PendientesDeEntrega As Integer
    Public Property PendientesDeEntrega() As Integer
        Get
            Return _PendientesDeEntrega
        End Get
        Set(ByVal value As Integer)
            _PendientesDeEntrega = value
        End Set
    End Property

    Private _PendientesDeIngreso As Integer
    Public Property PendientesDeIngreso() As Integer
        Get
            Return _PendientesDeIngreso
        End Get
        Set(ByVal value As Integer)
            _PendientesDeIngreso = value
        End Set
    End Property

    Private _Disponible As Integer
    Public Property Disponible() As Integer
        Get
            Return _Disponible
        End Get
        Set(ByVal value As Integer)
            _Disponible = value
        End Set
    End Property

    Public Sub New()

    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pPuntoDeReposicion As Integer, ByVal pStockDeSeguridad As Integer, ByVal pStockFisico As Integer, ByVal pIDProveedor As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.PuntoDeReposicion = pPuntoDeReposicion
        Me.StockDeSeguridad = pStockDeSeguridad
        Me.StockFisico = pStockFisico
        Me.IDProveedor = pIDProveedor
    End Sub

End Class
