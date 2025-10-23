Public Class Tabla_SEG

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _ListaRegistros As List(Of Registro)
    Public Property ListaRegistros() As List(Of Registro)
        Get
            Return _ListaRegistros
        End Get
        Set(ByVal value As List(Of Registro))
            _ListaRegistros = value
        End Set
    End Property


End Class
