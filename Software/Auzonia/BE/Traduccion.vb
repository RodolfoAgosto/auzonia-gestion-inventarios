Public Class Traduccion

    Private _IDMensaje As Integer
    Public Property IDMensaje() As Integer
        Get
            Return _IDMensaje
        End Get
        Set(ByVal value As Integer)
            _IDMensaje = value
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

    Private _Propietario As String
    Public Property Propietario() As String
        Get
            Return _Propietario
        End Get
        Set(ByVal value As String)
            _Propietario = value
        End Set
    End Property

    Private _MensajeTraducido As String
    Public Property MensajeTraducido() As String
        Get
            Return _MensajeTraducido
        End Get
        Set(ByVal value As String)
            _MensajeTraducido = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pIDMensaje As Integer, ByVal pCodigo As String, ByVal pDescripcion As String, ByVal pPropietario As String, ByVal pMensajeTraducido As String)
        Me.New()
        Me.IDMensaje = pIDMensaje
        Me.Codigo = pCodigo
        Me.Descripcion = pDescripcion
        Me.Propietario = pPropietario
        Me.MensajeTraducido = pMensajeTraducido
    End Sub


End Class
