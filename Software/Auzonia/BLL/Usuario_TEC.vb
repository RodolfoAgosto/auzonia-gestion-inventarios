Imports DAL
Imports SEGURIDAD

Public Class Usuario_TEC

    Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG)

    Dim vUsuarioDAL As New DAL.Usuario_DAL

    Public Sub Alta(ByRef pUsuario As SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).Alta

        Try
            Dim vGestorIntegridad As New GestorIntegridad_TEC
            Dim vRespuestaValidacion As Boolean = False
            vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad
            If vRespuestaValidacion Then
                Dim vBitacora As New Bitacora With {
                .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                .CodigoBitacora = "0001",
                .Informacion = "Se creó el usuario " & pUsuario.Codigo & " - " & pUsuario.Nombre & " " & pUsuario.Apellido,
                .TiporDeObjeto = "Usuario",
                .IdentificadorDeObjeto = pUsuario.Codigo
            }
                RegistrarEnBitacora(vBitacora)
                vUsuarioDAL.Alta(pUsuario)
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            Throw New Exception
        End Try

    End Sub

    Public Sub Baja(ByRef pUsuario As SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).Baja

        Try
            Dim vGestorIntegridad As New GestorIntegridad_TEC
            Dim vRespuestaValidacion As Boolean = False
            vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad
            If vRespuestaValidacion Then
                Dim vBitacora As New Bitacora With {
                    .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                    .CodigoBitacora = "0002",
                    .Informacion = "Se eliminó el usuario " & pUsuario.Codigo & " - " & pUsuario.Nombre & " " & pUsuario.Apellido,
                    .TiporDeObjeto = "Usuario",
                    .IdentificadorDeObjeto = pUsuario.Codigo
                }
                RegistrarEnBitacora(vBitacora)
                vUsuarioDAL.Baja(pUsuario)
            Else
                Throw New Exception
            End If
        Catch ex As Exception
            Throw New Exception
        End Try

    End Sub

    Public Sub Consulta(ByRef pObjeto As SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).Consulta
        vUsuarioDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).ConsultaIncremental
        Return vUsuarioDAL.ConsultaIncremental(pObjeto)
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As SEGURIDAD.Usuario_SEG, ByRef pObjeto2 As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).ConsultaRango
        Return vUsuarioDAL.ConsultaRango(pObjeto1, pObjeto2)
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).ConsultaVarios
        Return vUsuarioDAL.ConsultaVarios(pObjeto)
    End Function

    Public Sub Modificacion(ByRef pUsuario As SEGURIDAD.Usuario_SEG) Implements INTERFACES.Iabmc(Of SEGURIDAD.Usuario_SEG).Modificacion

        Try
            Dim vGestorIntegridad As New GestorIntegridad_TEC
            Dim vRespuestaValidacion As Boolean = False
            vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad()
            If vRespuestaValidacion Then
                If Not Sesion_SEG.SesionActual.UsuarioSEG Is Nothing Then
                    Dim vBitacora As New Bitacora With {
                        .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                        .CodigoBitacora = "0003",
                        .Informacion = "Se modificó el usuario " & pUsuario.Codigo & " - " & pUsuario.Nombre & " " & pUsuario.Apellido,
                        .TiporDeObjeto = "Usuario",
                        .IdentificadorDeObjeto = pUsuario.Codigo
                    }
                    RegistrarEnBitacora(vBitacora)
                End If
                vUsuarioDAL.Modificacion(pUsuario)
            Else
                Throw New Exception
            End If
        Catch ex As Exception

        End Try

    End Sub

    Public Sub CalcularDVH(ByVal pUsuarioSEG As SEGURIDAD.Usuario_SEG)
        Dim vUsuarioDAL As New Usuario_DAL
        vUsuarioDAL.CalcularDVH(pUsuarioSEG)
    End Sub

    Private Sub RegistrarEnBitacora(ByVal pBitacora As Bitacora)
        Dim vBitacoraTEC As New Bitacora_TEC
        vBitacoraTEC.RegistrarEnBitacora(pBitacora)
    End Sub

    Public Function ConsultaCambios(ByVal pCodigo As String) As DataTable
        Dim vUsuarioDAL As New Usuario_DAL
        Return vUsuarioDAL.ConsultarCambios(pCodigo)
    End Function

End Class
