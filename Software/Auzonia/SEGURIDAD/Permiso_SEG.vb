Public MustInherit Class Permiso_SEG

    Implements ICloneable

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

    Private _EsPerfil As Boolean
    Public Property EsPerfil() As Boolean
        Get
            Return _EsPerfil
        End Get
        Set(ByVal value As Boolean)
            _EsPerfil = value
        End Set
    End Property

    Public MustOverride Sub AgregarHijo(ByRef pNuevoHijo As Permiso_SEG)

    Public MustOverride Sub QuitarHijo(ByRef pHijoAQuitar As Permiso_SEG)

    Public MustOverride Function EsValido(ByVal pNombre As String) As Boolean

    Public MustOverride Function ListarHijos() As List(Of Permiso_SEG)

    Public MustOverride Function TieneHijos() As Boolean

    Public Overridable Function Clone() As Object Implements ICloneable.Clone
        Dim vPatenteClone As New Patente_SEG With {
            .Codigo = Me.Codigo,
            .EsPerfil = True,
            .Nombre = Me.Nombre
        }
        Return vPatenteClone
    End Function

End Class