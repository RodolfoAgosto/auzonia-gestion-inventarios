Public Class Restaurador_SEG
    Public Property Directorio() As String

    Private _Nombre
    Public Property Nombre() As String
        Get
            Return Directorio
        End Get
        Set(ByVal value As String)
            Directorio = value
        End Set
    End Property

    Private _Fecha As Date
    Public Property Fecha() As Date
        Get
            Return _Fecha
        End Get
        Set(ByVal value As Date)
            _Fecha = value
        End Set
    End Property


End Class
