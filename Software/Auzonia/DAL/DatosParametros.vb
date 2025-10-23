Public Class DatosParametros
    'Esta clase define la estructura necesaria para poder trabajar con los datos de un parámetro que un procedimiento_
    'almacenado requiere. Estos datos son: el nombre del parámetro, el tipo del parámetro y el valor que contiene.

    Sub New()

    End Sub

    Sub New(ByVal pNombre As String, ByVal pTipo As SqlDbType, ByVal pValor As String)
        Me.NombreParametro = pNombre
        Me.TipoParametro = pTipo
        Me.Valor = pValor
    End Sub

    Private _NombreParametro As String
    Public Property NombreParametro() As String
        Get
            Return _NombreParametro
        End Get
        Set(ByVal value As String)
            _NombreParametro = value
        End Set
    End Property

    Private _TipoParametro As SqlDbType
    Public Property TipoParametro() As SqlDbType
        Get
            Return _TipoParametro
        End Get
        Set(ByVal value As SqlDbType)
            _TipoParametro = value
        End Set
    End Property

    Private _Valor As String
    Public Property Valor() As String
        Get
            Return _Valor
        End Get
        Set(ByVal value As String)
            _Valor = value
        End Set
    End Property

End Class
