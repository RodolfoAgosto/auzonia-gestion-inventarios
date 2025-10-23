Imports DAL
Imports SEGURIDAD
Public Class GestorPermisos_TEC

    Dim vPermisoDAL As New Permiso_DAL

    Public Sub Alta(ByRef pPermiso_SEG As Permiso_SEG)
        vPermisoDAL.Alta(pPermiso_SEG)
    End Sub

    Public Sub Baja(ByRef pPermiso_SEG As Permiso_SEG)
        vPermisoDAL.Baja(pPermiso_SEG)
    End Sub

    Public Sub Consulta(ByRef pPermiso As Permiso_SEG)

    End Sub

    Public Function ConsultaIncremental(ByRef pPermiso_SEG As Object) As List(Of Permiso_SEG)
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pPermiso_SEG1 As Permiso_SEG, ByRef pPermiso_SEG2 As Permiso_SEG) As List(Of Permiso_SEG)
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pPermiso_SEG As Permiso_SEG) As List(Of Permiso_SEG)
        Return vPermisoDAL.ConsultaVarios(pPermiso_SEG)
    End Function

    Public Function ConsultaVarios(ByRef pUsuario_SEG As Usuario_SEG) As List(Of Permiso_SEG)
        Return vPermisoDAL.ConsultaVarios(pUsuario_SEG)
    End Function

    Public Function ConsultaTodos() As List(Of Permiso_SEG)
        Return vPermisoDAL.ConsultaTodos()
    End Function

    Public Sub Modificacion(ByRef pPermiso_SEG As Permiso_SEG)
        Try
            vPermisoDAL.IniciarTransaccion()
            vPermisoDAL.Modificacion(pPermiso_SEG)
            vPermisoDAL.EliminarHijos(pPermiso_SEG)
            If pPermiso_SEG.TieneHijos Then
                For Each unPermiso As Permiso_SEG In pPermiso_SEG.ListarHijos
                    vPermisoDAL.AgregarHijo(pPermiso_SEG.Codigo, unPermiso.Codigo)
                Next
            End If
            vPermisoDAL.Commit()
        Catch ex As Exception
            vPermisoDAL.RollBack()
        End Try
    End Sub

    Public Sub AsignarPermisoAUsuario(ByVal pUsuario As Usuario_SEG, ByVal pPermiso As Permiso_SEG)
        Dim vPermisoDAL As New Permiso_DAL
        vPermisoDAL.AsignarPermisoAUsuario(pUsuario.ID, pPermiso.Codigo)
        Dim vBitacora As New Bitacora
        vBitacora.CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
        vBitacora.CodigoBitacora = "0001"
        vBitacora.Informacion = "Se le asigno el permiso " & pPermiso.Nombre & "(" & pPermiso.Codigo & ") al usuario " & pUsuario.Codigo
        vBitacora.TiporDeObjeto = "Usuario"
        vBitacora.IdentificadorDeObjeto = pUsuario.Codigo
        RegistrarEnBitacora(vBitacora)
    End Sub

    Public Sub DesasignarPermisoAUsuario(ByVal pUsuario As Usuario_SEG, ByVal pPermiso As Permiso_SEG)
        Dim vPermisoDAL As New Permiso_DAL
        vPermisoDAL.DesasignarPermisoAUsuario(pUsuario.ID, pPermiso.Codigo)
        Dim vBitacora As New Bitacora
        vBitacora.CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
        vBitacora.CodigoBitacora = "0002"
        vBitacora.Informacion = "Se le quito el permiso " & pPermiso.Nombre & "(" & pPermiso.Codigo & ") al usuario " & pUsuario.Codigo
        vBitacora.TiporDeObjeto = "Usuario"
        vBitacora.IdentificadorDeObjeto = pUsuario.Codigo
        RegistrarEnBitacora(vBitacora)
    End Sub

    Private Sub RegistrarEnBitacora(ByVal pBitacora As Bitacora)
        Dim vBitacoraTEC As New Bitacora_TEC
        vBitacoraTEC.RegistrarEnBitacora(pBitacora)
    End Sub

End Class
