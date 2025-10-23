Public Enum TipoBitacora
    Actualizacion
    Excepcion
    Evento
End Enum

Public Class Bitacora

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _CodigoUsuario As String
    Public Property CodigoUsuario() As String
        Get
            Return _CodigoUsuario
        End Get
        Set(ByVal value As String)
            _CodigoUsuario = value
        End Set
    End Property

    Private _Fecha As DateTime
    Public Property Fecha() As DateTime
        Get
            Return _Fecha
        End Get
        Set(ByVal value As DateTime)
            _Fecha = value
        End Set
    End Property

    Private _Tipo As String
    Public Property Tipo() As String
        Get
            Return _Tipo
        End Get
        Set(ByVal value As String)
            _Tipo = value
        End Set
    End Property

    Private _CodigoBitacora As String
    Public Property CodigoBitacora() As String
        Get
            Return _CodigoBitacora
        End Get
        Set(ByVal value As String)
            _CodigoBitacora = value
        End Set
    End Property

    Private _Detalle As String
    Public Property Detalle() As String
        Get
            Return _Detalle
        End Get
        Set(ByVal value As String)
            _Detalle = value
        End Set
    End Property

    Private _Informacion As String
    Public Property Informacion() As String
        Get
            Return _Informacion
        End Get
        Set(ByVal value As String)
            _Informacion = value
        End Set
    End Property

    Private _TipoDeObjeto As String
    Public Property TiporDeObjeto() As String
        Get
            Return _TipoDeObjeto
        End Get
        Set(ByVal value As String)
            _TipoDeObjeto = value
        End Set
    End Property

    Private _IdentificadorDeObjeto As String
    Public Property IdentificadorDeObjeto() As String
        Get
            Return _IdentificadorDeObjeto
        End Get
        Set(ByVal value As String)
            _IdentificadorDeObjeto = value
        End Set
    End Property

End Class
