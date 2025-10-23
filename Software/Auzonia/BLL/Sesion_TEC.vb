Imports SEGURIDAD
Public Class Sesion_TEC

    ReadOnly _gestorPermisos As GestorPermisos_TEC
    Sub New()
        _gestorPermisos = New GestorPermisos_TEC
    End Sub

    Private _SesionSEG As Sesion_SEG
    Public Property SesionSEG() As Sesion_SEG
        Get
            Return _SesionSEG
        End Get
        Set(ByVal value As Sesion_SEG)
            _SesionSEG = value
        End Set
    End Property

    Public Function IniciarSesion(ByVal pCodigoUsuario As String, pContrasena As String) As RespuestaAcceso
        Dim vRespuestaHash As Boolean = False
        Dim vUsuarioTEC As New Usuario_TEC
        Dim vContrasenaIngresada As String = pContrasena
        Dim vUsuarioSEG As New Usuario_SEG With {
            .Codigo = pCodigoUsuario
        }
        vUsuarioTEC.Consulta(vUsuarioSEG)
        If vUsuarioSEG.Codigo = "" Then
            Return RespuestaAcceso.UsuarioInexistente
        ElseIf vUsuarioSEG.Bloqueado = True Then
            Return RespuestaAcceso.UsuarioBloqueado
        Else
            vRespuestaHash = GestorCriptografia.VerificarIgualdad(pContrasena, vUsuarioSEG.Contraseña)
            If vRespuestaHash Then
                Dim vGestorPermisosTEC As New GestorPermisos_TEC
                vUsuarioSEG.IntentosPendientes = 3
                ModificarUsuario(vUsuarioSEG)
                'Completo los datos de la sesion.
                Sesion_SEG.SesionActual.UsuarioSEG = vUsuarioSEG
                Sesion_SEG.SesionActual.ListaPermisos = vGestorPermisosTEC.ConsultaVarios(Sesion_SEG.SesionActual.UsuarioSEG)
                Dim vBitacora As New Bitacora With {
                    .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                    .CodigoBitacora = "0004",
                    .Informacion = "El usuario " + Sesion_SEG.SesionActual.UsuarioSEG.Codigo + " inició sesión.",
                    .TiporDeObjeto = "Sesion",
                    .IdentificadorDeObjeto = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
                }
                Dim vBitacoraTEC As New Bitacora_TEC
                vBitacoraTEC.RegistrarEnBitacora(vBitacora)
                Return RespuestaAcceso.AccesoValido
            Else
                If vUsuarioSEG.IntentosPendientes = 1 Then
                    vUsuarioSEG.IntentosPendientes = 3
                    vUsuarioSEG.Bloqueado = True
                    ModificarUsuario(vUsuarioSEG)
                    Return RespuestaAcceso.UsuarioBloqueado
                Else
                    vUsuarioSEG.IntentosPendientes = vUsuarioSEG.IntentosPendientes - 1
                    vUsuarioTEC.Modificacion(vUsuarioSEG)
                    Return RespuestaAcceso.Reintentar
                End If
            End If
        End If
    End Function

    Private Sub ModificarUsuario(ByRef pUsuario As Usuario_SEG)
        Try
            Dim vUsuarioTEC As New Usuario_TEC
            vUsuarioTEC.Modificacion(pUsuario)
        Catch ex As Exception

        End Try

    End Sub

    Public Function EsValido(ByVal pNombrePermiso As String)
        Dim vEsValido As Boolean = False
        For Each vPermiso As Permiso_SEG In Me._SesionSEG.ListaPermisos
            If Not vEsValido Then
                vEsValido = vPermiso.EsValido(pNombrePermiso)
            End If
        Next
        Return vEsValido
    End Function

End Class
