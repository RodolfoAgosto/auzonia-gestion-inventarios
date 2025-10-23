Public Class Documento

    Private _Nombre As String
    Public Property Nombre() As String
        Get
            Return _Nombre
        End Get
        Set(ByVal value As String)
            _Nombre = value
        End Set
    End Property

    Private _Cuerpo As Byte()
    Public Property Cuerpo() As Byte()
        Get
            Return _Cuerpo
        End Get
        Set(ByVal value As Byte())
            _Cuerpo = value
        End Set
    End Property

End Class
