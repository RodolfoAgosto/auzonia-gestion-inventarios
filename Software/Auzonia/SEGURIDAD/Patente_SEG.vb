Public Class Patente_SEG
    Inherits Permiso_SEG

    Public Overrides Sub AgregarHijo(ByRef pNuevoHijo As Permiso_SEG)

    End Sub

    Public Overrides Function EsValido(ByVal pNombre As String) As Boolean
        If pNombre = Me.Nombre Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Overrides Function ListarHijos() As List(Of Permiso_SEG)
        Return Nothing
    End Function

    Public Overrides Sub QuitarHijo(ByRef pHijoAQuitar As Permiso_SEG)

    End Sub

    Public Overrides Function TieneHijos() As Boolean
        Return False
    End Function

    Sub New()
        Me.EsPerfil = False
    End Sub

    Sub New(ByVal pCodigo As String, ByVal pNombre As String)
        Me.Codigo = pCodigo
        Me.Nombre = pNombre
        Me.EsPerfil = False
    End Sub

    Public Overrides Function Clone() As Object
        Dim vPatenteClone As New Patente_SEG With {
            .Codigo = Me.Codigo,
            .EsPerfil = True,
            .Nombre = Me.Nombre
        }
        Return vPatenteClone
    End Function

End Class
