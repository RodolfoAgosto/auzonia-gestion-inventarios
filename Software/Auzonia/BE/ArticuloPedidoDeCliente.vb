Public Class ArticuloPedidoDeCliente

    Inherits Articulo

    Private _Solicitadas As Integer
    Public Property Solicitadas() As Integer
        Get
            Return _Solicitadas
        End Get
        Set(ByVal value As Integer)
            _Solicitadas = value
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

    Private _Pendientes As Integer
    Public Property Pendientes() As Integer
        Get
            Return _Pendientes
        End Get
        Set(ByVal value As Integer)
            _Pendientes = value
        End Set
    End Property

    Private _Enviar As Integer
    Public Property Enviar() As Integer
        Get
            Return _Enviar
        End Get
        Set(ByVal value As Integer)
            _Enviar = value
        End Set
    End Property

    Sub New()

    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Solicitadas = 0
        Me.Reservadas = 0
        Me.Pendientes = 0
        Me.IDProveedor = pIDProveedor
    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer, ByVal pSolicitadas As Integer, ByVal pReservadas As Integer, ByVal pPendientes As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Solicitadas = pSolicitadas
        Me.Reservadas = pReservadas
        Me.Pendientes = pPendientes
        Me.IDProveedor = pIDProveedor
    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pIDProveedor As Integer, ByVal pSolicitadas As Integer, ByVal pReservadas As Integer, ByVal pPendientes As Integer, ByVal pEnviar As Integer)
        Me.ID = pID
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Solicitadas = pSolicitadas
        Me.Reservadas = pReservadas
        Me.Pendientes = pPendientes
        Me.IDProveedor = pIDProveedor
        Me.Enviar = pEnviar
    End Sub


End Class
