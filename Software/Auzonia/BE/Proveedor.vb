Public Class Proveedor

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _RazonSocial As String
    Public Property RazonSocial() As String
        Get
            Return _RazonSocial
        End Get
        Set(ByVal value As String)
            _RazonSocial = value
        End Set
    End Property

    Private _CUIT As String
    Public Property CUIT() As String
        Get
            Return _CUIT
        End Get
        Set(ByVal value As String)
            _CUIT = value
        End Set
    End Property

    Private _Calle As String
    Public Property Calle() As String
        Get
            Return _Calle
        End Get
        Set(ByVal value As String)
            _Calle = value
        End Set
    End Property

    Private _Altura As String
    Public Property Altura() As String
        Get
            Return _Altura
        End Get
        Set(ByVal value As String)
            _Altura = value
        End Set
    End Property

    Private _Telefono As String
    Public Property Telefono() As String
        Get
            Return _Telefono
        End Get
        Set(ByVal value As String)
            _Telefono = value
        End Set
    End Property

    Private _Email As String
    Public Property Email() As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
        End Set
    End Property

    Private _NombreContacto As String
    Public Property NombreContacto() As String
        Get
            Return _NombreContacto
        End Get
        Set(ByVal value As String)
            _NombreContacto = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pID As Integer, ByVal pRazonSocial As String, ByVal pCalle As String, ByVal pAltura As String, ByVal pTelefono As String, ByVal pCUIT As String, ByVal pEmail As String, ByVal pContacto As String)
        Me.ID = pID
        Me.RazonSocial = pRazonSocial
        Me.Calle = pCalle
        Me.Altura = pAltura
        Me.Telefono = pTelefono
        Me.CUIT = pCUIT
        Me.Email = pEmail
        Me.NombreContacto = pContacto
    End Sub

End Class
