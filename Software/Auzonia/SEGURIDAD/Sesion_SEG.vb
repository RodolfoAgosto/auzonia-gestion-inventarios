Public Class Sesion_SEG

    'Provee una unica sesion para la aplicacion
    Private Shared _sesionActual As Sesion_SEG
    Shared Function SesionActual() As Sesion_SEG
        If _sesionActual Is Nothing Then _sesionActual = New Sesion_SEG
        Return _sesionActual
    End Function

    Private _Usuario As SEGURIDAD.Usuario_SEG
    Public Property UsuarioSEG() As SEGURIDAD.Usuario_SEG
        Get
            Return _Usuario
        End Get
        Set(ByVal value As SEGURIDAD.Usuario_SEG)
            _Usuario = value
        End Set
    End Property

    Private _ListaPermisos As List(Of Permiso_SEG)
    Public Property ListaPermisos() As List(Of Permiso_SEG)
        Get
            Return _ListaPermisos
        End Get
        Set(ByVal value As List(Of Permiso_SEG))
            _ListaPermisos = value
        End Set
    End Property

End Class

