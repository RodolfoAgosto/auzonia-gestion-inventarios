Public Class Usuario_SEG

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
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

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Apellido As String
    Public Property Apellido() As String
        Get
            Return _Apellido
        End Get
        Set(ByVal value As String)
            _Apellido = value
        End Set
    End Property

    Private _email As String
    Public Property Email() As String
        Get
            Return _email
        End Get
        Set(ByVal value As String)
            _email = value
        End Set
    End Property

    Private _DNI As String
    Public Property DNI() As String
        Get
            Return _DNI
        End Get
        Set(ByVal value As String)
            _DNI = value
        End Set
    End Property

    Private _Fecha_Alta As Date
    Public Property FechaAlta() As Date
        Get
            Return _Fecha_Alta
        End Get
        Set(ByVal value As Date)
            _Fecha_Alta = value
        End Set
    End Property

    Private _Contraseña As String
    Public Property Contraseña() As String
        Get
            Return _Contraseña
        End Get
        Set(ByVal value As String)
            _Contraseña = value
        End Set
    End Property

    Private _Bloqueado As Boolean
    Public Property Bloqueado() As Boolean
        Get
            Return _Bloqueado
        End Get
        Set(ByVal value As Boolean)
            _Bloqueado = value
        End Set
    End Property

    Private _IntentosPendientes As Integer
    Public Property IntentosPendientes() As Integer
        Get
            Return _IntentosPendientes
        End Get
        Set(ByVal value As Integer)
            _IntentosPendientes = value
        End Set
    End Property

    Private _DigitoVH As String
    Public Property DigitoVH() As String
        Get
            Return _DigitoVH
        End Get
        Set(ByVal value As String)
            _DigitoVH = value
        End Set
    End Property

    Private _Permisos As List(Of Permiso_SEG)
    Public Property Permisos() As List(Of Permiso_SEG)
        Get
            Return _Permisos
        End Get
        Set(ByVal value As List(Of Permiso_SEG))
            _Permisos = value
        End Set
    End Property

    Public ReadOnly Property NombreCompleto() As String
        Get
            Return Me.Apellido & " " & Me.Nombre & " (" & Me.Codigo & ")"
        End Get
    End Property


    Sub New()

    End Sub

    Sub New(ByVal pId As Integer, ByVal pCodigo As String, ByVal pNombre As String, ByVal pApellido As String, ByVal pEmail As String, ByVal pDNI As String, ByVal pFecha_Alta As Date, ByVal pContraseña As String, ByVal pBloqueado As Boolean, ByVal pIntentosPendientes As Integer)
        Me.ID = pId
        Me.Codigo = pCodigo
        Me.Nombre = pNombre
        Me.Apellido = pApellido
        Me.Email = pEmail
        Me.DNI = pDNI
        Me.FechaAlta = pFecha_Alta
        Me.Contraseña = pContraseña
        Me.Bloqueado = pBloqueado
        Me.IntentosPendientes = pIntentosPendientes
    End Sub

    Sub New(ByVal pId As Integer, ByVal pCodigo As String, ByVal pNombre As String, ByVal pApellido As String, ByVal pEmail As String, ByVal pDNI As String, ByVal pFecha_Alta As Date, ByVal pContraseña As String, ByVal pBloqueado As Boolean, ByVal pIntentosPendientes As Integer, ByVal pDVH As String)
        Me.ID = pId
        Me.Codigo = pCodigo
        Me.Nombre = pNombre
        Me.Apellido = pApellido
        Me.Email = pEmail
        Me.DNI = pDNI
        Me.FechaAlta = pFecha_Alta
        Me.Contraseña = pContraseña
        Me.Bloqueado = pBloqueado
        Me.IntentosPendientes = pIntentosPendientes
        Me.DigitoVH = pDVH
    End Sub


End Class
