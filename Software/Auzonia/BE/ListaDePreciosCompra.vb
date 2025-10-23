Public Class ListaDePreciosCompra

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
        End Set
    End Property

    Private _Proveedor As Proveedor
    Public Property Proveedor() As Proveedor
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As Proveedor)
            _Proveedor = value
        End Set
    End Property

    Private _Numero As Integer
    Public Property Numero() As Integer
        Get
            Return _Numero
        End Get
        Set(ByVal value As Integer)
            _Numero = value
        End Set
    End Property

    Private _FechaDeInicioVigencia As Date
    Public Property FechaDeInicioVigencia() As Date
        Get
            Return _FechaDeInicioVigencia
        End Get
        Set(ByVal value As Date)
            _FechaDeInicioVigencia = value
        End Set
    End Property

    Private _ListaDeArticuloPrecio As List(Of ArticuloListaDePrecios)
    Public Property ListaDeArticulos() As List(Of ArticuloListaDePrecios)
        Get
            Return _ListaDeArticuloPrecio
        End Get
        Set(ByVal value As List(Of ArticuloListaDePrecios))
            _ListaDeArticuloPrecio = value
        End Set
    End Property

    Sub New()

    End Sub

    Sub New(ByVal pID As Integer, ByVal pNumero As Integer, ByVal pFechaIV As Date)
        Me.ID = pID
        Me.Numero = pNumero
        Me.FechaDeInicioVigencia = pFechaIV
    End Sub

End Class
