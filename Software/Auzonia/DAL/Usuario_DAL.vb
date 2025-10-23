Imports SEGURIDAD

Public Class Usuario_DAL

    Public Sub Alta(ByRef pUsuario As SEGURIDAD.Usuario_SEG)
        Try
            'Crea una instancia del tipo especificado usando el constructor predeterminado de ese tipo.
            Dim vUsuario As SEGURIDAD.Usuario_SEG
            Dim vGestorIntegridad As New GestorIntegridad_DAL
            vUsuario = pUsuario
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@Us_Codigo", SqlDbType.VarChar, vUsuario.Codigo), _
                                      New DatosParametros("@Us_Nombre", SqlDbType.VarChar, vUsuario.Nombre), _
                                      New DatosParametros("@Us_Apellido", SqlDbType.VarChar, vUsuario.Apellido), _
                                      New DatosParametros("@Us_Email", SqlDbType.VarChar, vUsuario.Email), _
                                      New DatosParametros("@Us_DNI", SqlDbType.VarChar, vUsuario.DNI), _
                                      New DatosParametros("@Us_Contraseña", SqlDbType.VarChar, vUsuario.Contraseña)
                                     })
            Comando.Ejecucion("AltaUsuario", vListaParametros)
            Me.Consulta(vUsuario)
            Me.Modificacion(vUsuario)
            vGestorIntegridad.GuardarDVV("Usuario")
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pUsuario As SEGURIDAD.Usuario_SEG)
        Dim vGestorIntegridad As New GestorIntegridad_DAL
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Us_Codigo", SqlDbType.VarChar, pUsuario.Codigo)
        }
        Comando.Ejecucion("BajaUsuario", vListaParametros)
        vGestorIntegridad.GuardarDVV("Usuario")
    End Sub

    Public Sub Consulta(ByRef pObjeto As SEGURIDAD.Usuario_SEG)
        'Crea una instancia del tipo especificado usando el constructor predeterminado de ese tipo.
        Dim vUsuario As SEGURIDAD.Usuario_SEG = Activator.CreateInstance(pObjeto.GetType)
        vUsuario = pObjeto

        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@UsCodigo", SqlDbType.VarChar, vUsuario.Codigo)
        }
        Dim vDataTable As DataTable = Comando.EjecucionRetornoDataTable("ConsultaUsuario", vListaParametros)
        If vDataTable.Rows.Count <> 0 Then
            vUsuario.ID = vDataTable.Rows(0).Item("ID_Usuario")
            vUsuario.Apellido = vDataTable.Rows(0).Item("Apellido")
            vUsuario.Codigo = vDataTable.Rows(0).Item("Codigo")
            vUsuario.Contraseña = vDataTable.Rows(0).Item("Contraseña")
            vUsuario.DNI = vDataTable.Rows(0).Item("DNI")
            vUsuario.Email = vDataTable.Rows(0).Item("Email")
            vUsuario.FechaAlta = vDataTable.Rows(0).Item("Fecha_Alta")
            vUsuario.Nombre = vDataTable.Rows(0).Item("Nombre")
            vUsuario.Bloqueado = vDataTable.Rows(0).Item("Bloqueado")
            vUsuario.IntentosPendientes = vDataTable.Rows(0).Item("IntentosPendientes")
            If Not IsDBNull(vDataTable.Rows(0).Item("DigitoVerificadorH")) Then
                vUsuario.DigitoVH = vDataTable.Rows(0).Item("DigitoVerificadorH")
            End If
        Else
            'Si no existe pongo el codigo como vacio=""
            vUsuario.Codigo = ""
        End If
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG)
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As SEGURIDAD.Usuario_SEG, ByRef pObjeto2 As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG)
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As SEGURIDAD.Usuario_SEG) As List(Of SEGURIDAD.Usuario_SEG)
        Dim vListaUsuarios As New List(Of SEGURIDAD.Usuario_SEG)
        'Crea una instancia del tipo especificado usando el constructor predeterminado de ese tipo.
        Dim vUsuario As SEGURIDAD.Usuario_SEG = Activator.CreateInstance(pObjeto.GetType)
        vUsuario = pObjeto

        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Us_Codigo", SqlDbType.VarChar, vUsuario.Codigo),
            New DatosParametros("@Us_Nombre", SqlDbType.VarChar, vUsuario.Nombre),
            New DatosParametros("@Us_Apellido", SqlDbType.VarChar, vUsuario.Apellido),
            New DatosParametros("@Us_Email", SqlDbType.VarChar, vUsuario.Email),
            New DatosParametros("@Us_DNI", SqlDbType.VarChar, vUsuario.DNI)
        }
        'vListaParametros.Add(New DatosParametros("@Us_Bloqueado", SqlDbType.Bit, vUsuario.Bloqueado))

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaUsuarios", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaUsuarios.Add(New SEGURIDAD.Usuario_SEG(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8), row.Item(9), row.Item(10)))
            Next
        End If

        Dim vPermisoDAL As New Permiso_DAL

        For Each vUsuario In vListaUsuarios
            vUsuario.Permisos = vPermisoDAL.ConsultaVarios(vUsuario)
        Next

        Return vListaUsuarios

    End Function

    Public Sub Modificacion(ByRef pUsuario As SEGURIDAD.Usuario_SEG)
        Dim vGestorIntegridad As New GestorIntegridad_DAL
        Me.CalcularDVH(pUsuario)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Us_Codigo", SqlDbType.VarChar, pUsuario.Codigo),
                                  New DatosParametros("@Us_Nombre", SqlDbType.VarChar, pUsuario.Nombre),
                                  New DatosParametros("@Us_Apellido", SqlDbType.VarChar, pUsuario.Apellido),
                                  New DatosParametros("@Us_Email", SqlDbType.VarChar, pUsuario.Email),
                                  New DatosParametros("@Us_DNI", SqlDbType.VarChar, pUsuario.DNI),
                                  New DatosParametros("@Us_Contraseña", SqlDbType.VarChar, pUsuario.Contraseña),
                                  New DatosParametros("@Us_Bloqueado", SqlDbType.VarChar, pUsuario.Bloqueado),
                                  New DatosParametros("@Us_IntentosPendientes", SqlDbType.VarChar, pUsuario.IntentosPendientes),
                                  New DatosParametros("@Us_DigitoVerificadorH", SqlDbType.VarChar, pUsuario.DigitoVH)
    })
        Comando.Ejecucion("ModificacionUsuario", vListaParametros)
        If Not Sesion_SEG.SesionActual.UsuarioSEG Is Nothing Then
            GuardarEnBitacora(pUsuario)
        End If
        vGestorIntegridad.GuardarDVV("Usuario")
    End Sub

    Public Sub CalcularDVH(ByVal pUsuario As SEGURIDAD.Usuario_SEG)
        pUsuario.DigitoVH = ""
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.ID.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Codigo.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Nombre.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Apellido.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Email.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.DNI.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.FechaAlta.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Contraseña.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.Bloqueado.ToString
        pUsuario.DigitoVH = pUsuario.DigitoVH + pUsuario.IntentosPendientes.ToString
        Dim vGestorCriptografia As New SEGURIDAD.GestorCriptografia
        pUsuario.DigitoVH = vGestorCriptografia.Hash(pUsuario.DigitoVH)
    End Sub

    Public Sub GuardarEnBitacora(ByVal pUsuario As SEGURIDAD.Usuario_SEG)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                  New DatosParametros("@Us_Codigo", SqlDbType.VarChar, pUsuario.Codigo),
                                  New DatosParametros("@Us_Nombre", SqlDbType.VarChar, pUsuario.Nombre),
                                  New DatosParametros("@Us_Apellido", SqlDbType.VarChar, pUsuario.Apellido),
                                  New DatosParametros("@Us_Email", SqlDbType.VarChar, pUsuario.Email),
                                  New DatosParametros("@Us_DNI", SqlDbType.VarChar, pUsuario.DNI),
                                  New DatosParametros("@Us_Contraseña", SqlDbType.VarChar, pUsuario.Contraseña),
                                  New DatosParametros("@Us_CodigoUsuario", SqlDbType.VarChar, Sesion_SEG.SesionActual.UsuarioSEG.Codigo)
                                 })
        Comando.Ejecucion("RegistrarBitacoraUsuario", vListaParametros)

    End Sub

    Public Function ConsultarCambios(ByVal pCodigo As String) As DataTable
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Us_Codigo", SqlDbType.VarChar, pCodigo)
        }

        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ListarCambiosBitacoraUsuario", vListaParametros)
        Return vDataTable

    End Function

End Class
