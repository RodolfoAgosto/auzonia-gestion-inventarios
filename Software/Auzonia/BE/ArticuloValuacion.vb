Public Class ArticuloValuacion
    Inherits Articulo

    Private _Articulo As ArticuloStock
    Public Property Articulo() As ArticuloStock
        Get
            Return _Articulo
        End Get
        Set(ByVal value As ArticuloStock)
            _Articulo = value
        End Set
    End Property

    Private _LIFO As Integer
    Public Property CantidadLIFO() As Integer
        Get
            Return _LIFO
        End Get
        Set(ByVal value As Integer)
            _LIFO = value
        End Set
    End Property

    Private _FIFO As Integer
    Public Property CantidadFIFO() As Integer
        Get
            Return _FIFO
        End Get
        Set(ByVal value As Integer)
            _FIFO = value
        End Set
    End Property

    Private _IDListaDePrecios As Integer
    Public Property IDListaDePrecios() As Integer
        Get
            Return _IDListaDePrecios
        End Get
        Set(ByVal value As Integer)
            _IDListaDePrecios = value
        End Set
    End Property

    Private _Precio As Double
    Public Property Precio() As Double
        Get
            Return _Precio
        End Get
        Set(ByVal value As Double)
            _Precio = value
        End Set
    End Property

    Private _ValuacionLIFO As Double
    Public Property ValuacionLIFO() As Double
        Get
            Return _ValuacionLIFO
        End Get
        Set(ByVal value As Double)
            _ValuacionLIFO = value
        End Set
    End Property

    Private _ValuacionFIFO As Double
    Public Property ValuacionFIFO() As Double
        Get
            Return _ValuacionFIFO
        End Get
        Set(ByVal value As Double)
            _ValuacionFIFO = value
        End Set
    End Property


End Class
