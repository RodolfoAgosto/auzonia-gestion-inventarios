Public Class Idioma

    Private _ID As Integer
    Public Property ID() As Integer
        Get
            Return _ID
        End Get
        Set(ByVal value As Integer)
            _ID = value
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

    Public Sub New()

    End Sub

    Public Sub New(ByVal pID As Integer, ByVal pNombre As String)
        Me.New()
        Me.ID = pID
        Me.Nombre = pNombre
    End Sub

    Private _ListaTraducciones As List(Of Traduccion)
    Public Property ListaTraducciones() As List(Of Traduccion)
        Get
            Return _ListaTraducciones
        End Get
        Set(ByVal value As List(Of Traduccion))
            _ListaTraducciones = value
        End Set
    End Property


End Class
