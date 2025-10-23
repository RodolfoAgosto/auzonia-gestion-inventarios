Public Class ArticuloNotaDePedido

    Inherits ArticuloStock

    Private _Solicitadas As Integer
    Public Property Solicitadas() As Integer
        Get
            Return _Solicitadas
        End Get
        Set(ByVal value As Integer)
            _Solicitadas = value
        End Set
    End Property

    Private _Pendientes As Integer
    Public Property Pendientes() As Integer
        Get
            Return _Pendientes
        End Get
        Set(ByVal value As Integer)
            _Pendientes = value
        End Set
    End Property

    Sub New()

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

    Public Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer, ByVal pSolicitadas As Integer, ByVal pPendientes As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.IDProveedor = pIDProveedor
        Me.Solicitadas = pSolicitadas
        Me.Pendientes = pPendientes
    End Sub


End Class
