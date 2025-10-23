Imports SEGURIDAD
Imports System.Data
Imports System.Data.SqlClient

Public Class Permiso_DAL

    Private _Transaccion As SqlTransaction
    Public Property Transaccion() As SqlTransaction
        Get
            Return _Transaccion
        End Get
        Set(ByVal value As SqlTransaction)
            _Transaccion = value
        End Set
    End Property

    Public Sub Alta(ByRef pObjeto As Permiso_SEG)
        Dim _objeto As Permiso_SEG = Activator.CreateInstance(pObjeto.GetType)
        _objeto = pObjeto
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
            New DatosParametros("@Per_Codigo", SqlDbType.VarChar, _objeto.Codigo),
            New DatosParametros("@Per_Nombre", SqlDbType.VarChar, _objeto.Nombre)
        })
        Comando.Ejecucion("AltaPermiso", vListaParametros)
    End Sub

    Public Sub Baja(ByRef pPermiso_SEG As Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@Per_Codigo", SqlDbType.VarChar, pPermiso_SEG.Codigo))
        Comando.Ejecucion("BajaFamilia", vListaParametros)
    End Sub

    Public Function ConsultaVarios(ByRef pPermiso_SEG As Permiso_SEG) As List(Of Permiso_SEG)
        Dim vListaPermiso_SEG As New List(Of Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@Per_Codigo", SqlDbType.VarChar, pPermiso_SEG.Codigo))
        vListaParametros.Add(New DatosParametros("@Per_Nombre", SqlDbType.VarChar, pPermiso_SEG.Nombre))
        If pPermiso_SEG.EsPerfil Then
            vListaParametros.Add(New DatosParametros("@Per_EsFamilia", SqlDbType.Bit, Convert.ToBoolean(True)))
        Else
            vListaParametros.Add(New DatosParametros("@Per_EsFamilia", SqlDbType.Bit, Convert.ToBoolean(False)))
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaPermisos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                If Convert.ToBoolean(row.Item(2)) Then
                    vListaPermiso_SEG.Add(New SEGURIDAD.Familia_SEG(row.Item(0), row.Item(1)))
                Else
                    vListaPermiso_SEG.Add(New SEGURIDAD.Patente_SEG(row.Item(0), row.Item(1)))
                End If
            Next
        End If

        For Each vPermiso As Permiso_SEG In vListaPermiso_SEG
            If vPermiso.EsPerfil Then
                Dim vFamilia As Familia_SEG = vPermiso
                vFamilia.ListaHijos = ConsultarHijos(vPermiso.Codigo)
            End If
        Next

        Return vListaPermiso_SEG

    End Function

    Public Function ConsultaVarios(ByRef pUsuarioSEG As Usuario_SEG) As List(Of Permiso_SEG)
        Dim vListaPermiso_SEG As New List(Of Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@Us_Per_Usuario_ID_Usuario", SqlDbType.Int, pUsuarioSEG.ID))
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ListarPermisosPorUsuario", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                If Convert.ToBoolean(row.Item(2)) Then
                    vListaPermiso_SEG.Add(New SEGURIDAD.Familia_SEG(row.Item(0), row.Item(1)))
                Else
                    vListaPermiso_SEG.Add(New SEGURIDAD.Patente_SEG(row.Item(0), row.Item(1)))
                End If
            Next
        End If

        For Each vPermiso As Permiso_SEG In vListaPermiso_SEG
            If vPermiso.EsPerfil Then
                Dim vFamilia As Familia_SEG = vPermiso
                vFamilia.ListaHijos = ConsultarHijos(vPermiso.Codigo)
            End If
        Next

        Return vListaPermiso_SEG


    End Function

    Public Function ConsultaTodos() As List(Of Permiso_SEG)
        Dim vListaPermiso_SEG As New List(Of Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaPermisos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                If Convert.ToBoolean(row.Item(2)) Then
                    vListaPermiso_SEG.Add(New SEGURIDAD.Familia_SEG(row.Item(0), row.Item(1)))
                Else
                    vListaPermiso_SEG.Add(New SEGURIDAD.Patente_SEG(row.Item(0), row.Item(1)))
                End If
            Next
        End If

        For Each vPermiso As Permiso_SEG In vListaPermiso_SEG
            If vPermiso.EsPerfil Then
                Dim vFamilia As Familia_SEG = vPermiso
                vFamilia.ListaHijos = ConsultarHijos(vPermiso.Codigo)
            End If
        Next

        Return vListaPermiso_SEG

    End Function

    Public Sub Modificacion(ByRef pPermisoSEG As Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Per_Codigo", SqlDbType.VarChar, pPermisoSEG.Codigo), _
                                  New DatosParametros("@Per_Nombre", SqlDbType.VarChar, pPermisoSEG.Nombre)
                                  })
        Comando.Ejecucion("ModificacionPermiso", vListaParametros, Me.Transaccion)
    End Sub

    Public Function ConsultarHijos(ByVal pCodigo As String) As List(Of Permiso_SEG)
        Dim vlistaHijos As New List(Of Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.Add(New DatosParametros("@Per_Codigo", SqlDbType.VarChar, pCodigo))

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ListarHijos", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                If Convert.ToBoolean(row.Item(2)) Then
                    Dim vnuevaFamilia As New SEGURIDAD.Familia_SEG(row.Item(0), row.Item(1))
                    vnuevaFamilia.ListaHijos = ConsultarHijos(vnuevaFamilia.Codigo)
                    vlistaHijos.Add(vnuevaFamilia)
                Else
                    vlistaHijos.Add(New SEGURIDAD.Patente_SEG(row.Item(0), row.Item(1)))
                End If
            Next
        End If

        Return vlistaHijos

    End Function

    Public Sub EliminarHijos(ByRef pPermisoSEG As Permiso_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Per_Codigo", SqlDbType.VarChar, pPermisoSEG.Codigo)
                                  })
        Comando.Ejecucion("EliminarHijos", vListaParametros, Me.Transaccion)
    End Sub

    Public Sub AgregarHijo(ByRef pCodigoPadre As String, ByRef pCodigoHijo As String)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Per_CodigoPadre", SqlDbType.VarChar, pCodigoPadre),
                                  New DatosParametros("@Per_CodigoHijo", SqlDbType.VarChar, pCodigoHijo)
                                  })
        Comando.Ejecucion("AgregarHijo", vListaParametros, Me.Transaccion)
    End Sub

    Public Sub IniciarTransaccion()
        Dim _conexion As SqlConnection = Conexion.ObjetoConexion
        Me.Transaccion = _conexion.BeginTransaction
    End Sub

    Public Sub Commit()
        Me.Transaccion.Commit()
    End Sub

    Public Sub RollBack()
        Me.Transaccion.Rollback()
    End Sub

    Public Sub AsignarPermisoAUsuario(pId_Usuario, pCodigoPermiso)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Usu_Usuario_ID_Usuario", SqlDbType.Int, pId_Usuario),
                                  New DatosParametros("@Per_Permiso_Codigo", SqlDbType.VarChar, pCodigoPermiso)
                                  })
        Comando.Ejecucion("AsignarPermisoAUsuario", vListaParametros)
    End Sub

    Public Sub DesasignarPermisoAUsuario(pId_Usuario, pCodigoPermiso)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Usu_Usuario_ID_Usuario", SqlDbType.Int, pId_Usuario),
                                  New DatosParametros("@Per_Permiso_Codigo", SqlDbType.VarChar, pCodigoPermiso)
                                  })
        Comando.Ejecucion("DesasignarPermisoAUsuario", vListaParametros)
    End Sub

End Class
