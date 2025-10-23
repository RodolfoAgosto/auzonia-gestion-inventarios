Imports BE
Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports System.Text.RegularExpressions

Public Class FormAdmPerfilesUsuarios

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Private _CerrarAplicacion As Boolean
    Public Property CerrarAplicacion() As Boolean
        Get
            Return _CerrarAplicacion
        End Get
        Set(ByVal value As Boolean)
            _CerrarAplicacion = value
        End Set
    End Property

#Region "Pestaña Usuarios"

    Dim vContexto As ContextoUsuario = ContextoUsuario.NuevaBusqueda
    Dim vUsuarioSeleccionado As Usuario_SEG
    Dim vListaUsuarios As List(Of Usuario_SEG)
    Dim WithEvents vFormBitacora As FormBitacoraCambios

    Enum ContextoUsuario
        NuevaBusqueda
        UsuarioSeleccionado
        ModicarUsuario
        CrearUsuario
    End Enum

#Region "Click en botones"

    Public Function Validar() As Boolean
        Dim res As Boolean = True
        Dim Email As Boolean = False
        Email = IsValidEmail(TBEMail.Text)
        If Not Email Then
            res = False
            MsgBox("El mail no es valido.")
        End If
        Dim DNI As Integer = TBDNI.Text
        If DNI < 2000000 Or DNI > 900000000 Then
            res = False
            MsgBox("DNI no valido.")
        End If
        Return res
    End Function

    Public Function IsValidEmail(ByVal email As String) As Boolean
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function

    Private Sub BTNCrearUsuario_Click(sender As Object, e As EventArgs) Handles BTNCrearUsuario.Click
        Dim vUsuarioTEC As New Usuario_TEC
        If vContexto = ContextoUsuario.CrearUsuario Then

            Dim vNuevoUsuario As New Usuario_SEG
            If TBApellido.Text <> "" And TBDNI.Text <> "" And TBEMail.Text <> "" And TBNombre.Text <> "" And TBUsuario.Text <> "" Then
                If Validar() Then
                    Try
                        Dim vGestorCriptografia As New SEGURIDAD.GestorCriptografia
                        vNuevoUsuario.Apellido = TBApellido.Text
                        vNuevoUsuario.Codigo = TBUsuario.Text
                        vNuevoUsuario.DNI = TBDNI.Text
                        vNuevoUsuario.Email = TBEMail.Text.ToLower
                        vNuevoUsuario.Nombre = TBNombre.Text
                        Dim vPsw As String = ""
                        vPsw = InputBox("Ingrese contraseña.")
                        If vPsw.Length > 0 Then
                            Dim vContraseñaValidar As Boolean = False
                            vContraseñaValidar = ValidarContraseña(vPsw)
                            If vContraseñaValidar Then
                                vNuevoUsuario.Contraseña = vGestorCriptografia.Hash(vPsw)
                                Dim vRespuestaValidacion As Boolean = False
                                Dim vGestorIntegridad As New GestorIntegridad_TEC
                                vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad()
                                If vRespuestaValidacion Then
                                    vUsuarioTEC.Alta(vNuevoUsuario)
                                    MsgBox("El usuario ha sido ingresado con éxito.")
                                    ContextoNuevaBusqueda()
                                Else
                                    Dim vSesionTEC As New Sesion_TEC
                                    vSesionTEC.SesionSEG = Sesion_SEG.SesionActual
                                    If vSesionTEC.EsValido("Administrador") Then
                                        MsgBox("La base de datos ha sido corrompida. Restaurela desde el módulo Sistema.")
                                    Else
                                        MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                                        CerrarAplicacion = True
                                    End If
                                    Me.Close()
                                End If
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message)
                    End Try
                End If
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoUsuario.ModicarUsuario Then
            Dim vNuevoUsuario As New Usuario_SEG
            If TBApellido.Text <> "" And TBDNI.Text <> "" And TBEMail.Text <> "" And TBNombre.Text <> "" And TBUsuario.Text <> "" Then
                vNuevoUsuario = vUsuarioSeleccionado
                vNuevoUsuario.Apellido = TBApellido.Text
                vNuevoUsuario.Codigo = TBUsuario.Text
                vNuevoUsuario.DNI = TBDNI.Text
                vNuevoUsuario.Email = TBEMail.Text.ToLower
                vNuevoUsuario.Nombre = TBNombre.Text
                vNuevoUsuario.Contraseña = vUsuarioSeleccionado.Contraseña
                Dim vRespuestaValidacion As Boolean = False
                Dim vGestorIntegridad As New GestorIntegridad_TEC
                vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad()
                If vRespuestaValidacion Then
                    vUsuarioTEC.Modificacion(vNuevoUsuario)
                    MsgBox("El usuario ha sido modificado con éxito.")
                    LimpiarCamposUsuario()
                    ContextoNuevaBusqueda()
                Else
                    Dim vSesionTEC As New Sesion_TEC
                    vSesionTEC.SesionSEG = Sesion_SEG.SesionActual
                    If vSesionTEC.EsValido("Administrador") Then
                        MsgBox("La base de datos ha sido corrompida. Restaurela desde el módulo Sistema.")
                    Else
                        MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                        CerrarAplicacion = True
                    End If
                    Me.Close()
                End If
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoUsuario.NuevaBusqueda Or vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ContextoCrearUsuario()
        End If
    End Sub

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Try
            Dim vUsuarioTEC As New Usuario_TEC
            Dim vRespuesta As MsgBoxResult
            vRespuesta = MsgBox("Está a punto de borrar el usuario. ¿Desea continuar?", MsgBoxStyle.YesNo, "Borrar Usuario")
            If vRespuesta = MsgBoxResult.Yes Then
                Dim vUsuario As New Usuario_SEG
                vUsuario.Codigo = DGVUsuarios.SelectedRows(0).Cells(1).Value
                vUsuarioTEC.Baja(vUsuario)
                MsgBox("El usuario fue eliminado exitosamente.")
                ContextoNuevaBusqueda()
            End If
        Catch ex As Exception
            Dim vSesionTEC As New Sesion_TEC
            vSesionTEC.SesionSEG = Sesion_SEG.SesionActual
            If vSesionTEC.EsValido("Administrador") Then
                MsgBox("La base de datos ha sido corrompida. Restaurela desde el módulo Sistema.")
            Else
                MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                CerrarAplicacion = True
            End If
            Me.Close()
        End Try
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

        If vContexto = ContextoUsuario.NuevaBusqueda Then

            Dim vNuevoUsuario As New Usuario_SEG
            If TBApellido.Text <> "" Then
                vNuevoUsuario.Apellido = TBApellido.Text
            End If
            If TBDNI.Text <> "" Then
                vNuevoUsuario.DNI = TBDNI.Text
            End If
            If TBEMail.Text <> "" Then
                vNuevoUsuario.Email = TBEMail.Text
            End If
            If TBNombre.Text <> "" Then
                vNuevoUsuario.Nombre = TBNombre.Text
            End If
            If TBUsuario.Text <> "" Then
                vNuevoUsuario.Codigo = TBUsuario.Text
            End If
            Dim vUsuarioTEC As New Usuario_TEC
            DGVUsuarios.DataSource = Nothing
            vListaUsuarios = vUsuarioTEC.ConsultaVarios(vNuevoUsuario)
            DGVUsuarios.DataSource = vListaUsuarios
            If DGVUsuarios.Columns.Count > 0 Then
                'ID
                DGVUsuarios.Columns("ID").Width = 60
                DGVUsuarios.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Codigo
                DGVUsuarios.Columns("Codigo").Width = 80
                DGVUsuarios.Columns("Codigo").HeaderText = "Código"
                DGVUsuarios.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Nombre
                DGVUsuarios.Columns("Nombre").Width = 90
                DGVUsuarios.Columns("Nombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Apellido
                DGVUsuarios.Columns("Apellido").Width = 90
                DGVUsuarios.Columns("Apellido").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'Email
                DGVUsuarios.Columns("Email").Width = 165
                DGVUsuarios.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'DNI
                DGVUsuarios.Columns("DNI").Width = 88
                DGVUsuarios.Columns("DNI").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'FechaAlta
                DGVUsuarios.Columns("FechaAlta").Width = 80
                DGVUsuarios.Columns("FechaAlta").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("FechaAlta").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("FechaAlta").HeaderText = "Fecha de Alta"
                'Contraseña
                DGVUsuarios.Columns("Contraseña").Visible = False
                'Bloqueado
                DGVUsuarios.Columns("Bloqueado").Width = 73
                DGVUsuarios.Columns("Bloqueado").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                'IntentosPendientes
                DGVUsuarios.Columns("IntentosPendientes").Width = 75
                DGVUsuarios.Columns("IntentosPendientes").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("IntentosPendientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("IntentosPendientes").HeaderText = "Intentos Pendientes"
                'DigitoVH
                DGVUsuarios.Columns("DigitoVH").Visible = False
                'NombreCompleto
                DGVUsuarios.Columns("NombreCompleto").Width = 160
                DGVUsuarios.Columns("NombreCompleto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                DGVUsuarios.Columns("NombreCompleto").HeaderText = "Nombre Completo"

            End If

            ' Cuando el contexto es crear usuario cancela la carga y vuelve al contexto nueva búsqueda. 
        ElseIf vContexto = ContextoUsuario.CrearUsuario Then
            ContextoNuevaBusqueda()
        ElseIf vContexto = ContextoUsuario.UsuarioSeleccionado Or vContexto = ContextoUsuario.ModicarUsuario Then
            ContextoNuevaBusqueda()
        End If

    End Sub

    Private Sub BTNModificar_Click(sender As Object, e As EventArgs) Handles BTNModificar.Click
        ContextoModificarUsuario()
    End Sub

    Private Sub BTNBitacora_Click(sender As Object, e As EventArgs) Handles BTNBitacora.Click
        If vFormBitacora Is Nothing Then
            vFormBitacora = New FormBitacoraCambios
            vFormBitacora.MdiParent = Me.MdiParent
        End If
        vFormBitacora.NombreTabla = "BitacoraUsuario"
        vFormBitacora.Codigo = vUsuarioSeleccionado.Codigo
        vFormBitacora.LayoutMdi(MdiLayout.TileVertical)
        vFormBitacora.Idioma = Me.Idioma
        vFormBitacora.Actualizar(Idioma)
        vFormBitacora.Show()

    End Sub

    Private Sub BTNDesbloquear_Click(sender As Object, e As EventArgs) Handles BTNDesbloquear.Click

        If vUsuarioSeleccionado.Bloqueado = False Then
            MsgBox("El usuario no se encuentra bloqueado.")
        Else
            Dim vUsuarioTEC As New Usuario_TEC
            Dim vNuevoUsuario As New Usuario_SEG
            Dim vGestorCriptografia As New SEGURIDAD.GestorCriptografia
            vNuevoUsuario = vUsuarioSeleccionado
            vNuevoUsuario.Apellido = TBApellido.Text
            vNuevoUsuario.Codigo = TBUsuario.Text
            vNuevoUsuario.DNI = TBDNI.Text
            vNuevoUsuario.Email = TBEMail.Text
            vNuevoUsuario.Nombre = TBNombre.Text
            vNuevoUsuario.Contraseña = vUsuarioSeleccionado.Contraseña
            vNuevoUsuario.Bloqueado = False
            vNuevoUsuario.IntentosPendientes = 3
            Dim vRespuestaValidacion As Boolean = False
            Dim vGestorIntegridad As New GestorIntegridad_TEC
            vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad()
            If vRespuestaValidacion Then
                vUsuarioTEC.Modificacion(vNuevoUsuario)
                MsgBox("El usuario ha sido desbloqueado con éxito.")
                LimpiarCamposUsuario()
                ContextoNuevaBusqueda()
            Else
                Dim vSesionTEC As New Sesion_TEC
                vSesionTEC.SesionSEG = Sesion_SEG.SesionActual
                If vSesionTEC.EsValido("Administrador") Then
                    MsgBox("La base de datos ha sido corrompida. Restaurela desde el módulo Sistema.")
                Else
                    MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                    CerrarAplicacion = True
                End If
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BTNCambiarContraseña_Click(sender As Object, e As EventArgs) Handles BTNCambiarContraseña.Click
        Dim vUsuarioTEC As New Usuario_TEC
        Dim vNuevoUsuario As New Usuario_SEG
        Dim vGestorCriptografia As New SEGURIDAD.GestorCriptografia
        vNuevoUsuario = vUsuarioSeleccionado
        vNuevoUsuario.Apellido = TBApellido.Text
        vNuevoUsuario.Codigo = TBUsuario.Text
        vNuevoUsuario.DNI = TBDNI.Text
        vNuevoUsuario.Email = TBEMail.Text
        vNuevoUsuario.Nombre = TBNombre.Text
        Dim vPsw As String = ""
        vPsw = InputBox("Ingrese contraseña.")
        Dim vContraseñaValidar As Boolean = False
        vContraseñaValidar = ValidarContraseña(vPsw)
        If vContraseñaValidar Then
            vNuevoUsuario.Contraseña = vGestorCriptografia.Hash(vPsw)
            vNuevoUsuario.Bloqueado = False
            vNuevoUsuario.IntentosPendientes = 3
            Dim vRespuestaValidacion As Boolean = False
            Dim vGestorIntegridad As New GestorIntegridad_TEC
            vRespuestaValidacion = vGestorIntegridad.VerificarIntegridad()
            If vRespuestaValidacion Then
                vUsuarioTEC.Modificacion(vNuevoUsuario)
                MsgBox("La contraseña ha sido modificada con éxito.")
                LimpiarCamposUsuario()
                ContextoNuevaBusqueda()
            Else
                Dim vSesionTEC As New Sesion_TEC
                vSesionTEC.SesionSEG = Sesion_SEG.SesionActual
                If vSesionTEC.EsValido("Administrador") Then
                    MsgBox("La base de datos ha sido corrompida. Restaurela desde el módulo Sistema.")
                Else
                    MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                    CerrarAplicacion = True
                End If
                Me.Close()
            End If
        End If

    End Sub

#End Region

#Region "Procedimientos"

    ' Limpia los campos del usuario en el formulario.
    Public Sub LimpiarCamposUsuario()
        TBNombre.Text = ""
        TBUsuario.Text = ""
        TBDNI.Text = ""
        TBEMail.Text = ""
        TBApellido.Text = ""
    End Sub

    ' Habilita los campos del usuario en el formulario.
    Public Sub HabilitarCamposUsuario()
        TBNombre.Enabled = True
        TBUsuario.Enabled = True
        TBDNI.Enabled = True
        TBEMail.Enabled = True
        TBApellido.Enabled = True
    End Sub

    ' Completa los campos del formulario con los datos del usuario seleccionado en el DGV.
    Public Sub CompletarCamposUsuario()

        TBNombre.Enabled = False
        TBUsuario.Enabled = False
        TBDNI.Enabled = False
        TBEMail.Enabled = False
        TBApellido.Enabled = False

        ' Recorre la lista de usuarios según el código y asigna a la variable vUsuarioSeleccionado el usuario coincidente 
        ' con el usuario seleccionado en DGVUsuarios.
        SeleccionarUsuario()

        TBUsuario.Text = DGVUsuarios.SelectedRows(0).Cells(1).Value
        TBNombre.Text = DGVUsuarios.SelectedRows(0).Cells(2).Value
        TBDNI.Text = DGVUsuarios.SelectedRows(0).Cells(5).Value
        TBEMail.Text = DGVUsuarios.SelectedRows(0).Cells(4).Value
        TBApellido.Text = DGVUsuarios.SelectedRows(0).Cells(3).Value

    End Sub

    ' Asigna a la varieble vUsuarioSeleccionado el usuario seleccionado en DGVUsuarios. 
    Public Sub SeleccionarUsuario()
        Dim vCodigo As String = DGVUsuarios.SelectedRows.Item(0).Cells.Item(1).Value.ToString
        For Each vUsuario As Usuario_SEG In vListaUsuarios
            If vUsuario.Codigo = vCodigo Then
                vUsuarioSeleccionado = vUsuario
            End If
        Next
    End Sub

    ' Se ejecuta al elegir un usuario dentro del DGVUsuarios.
    Private Sub DGVUsuarios_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVUsuarios.CellClick
        If DGVUsuarios.SelectedRows IsNot Nothing Then
            ContextoUsuarioSeleccionado()
            ActualizarPermisosUsuario()
            vListaDeTraducciones.Clear()
            Dim vTraduccionTEC As New Traduccion_TEC
            vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(Me.Idioma, "FormAdmPerfilesUsuarios")
            Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
            For Each vTraduccion As Traduccion In vListaDeTraducciones
                vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
            Next
            Me.BTNModificar.Text = vDiccionario("BTNModificar").MensajeTraducido
            Me.BTNEliminar.Text = vDiccionario("BTNEliminar").MensajeTraducido
        End If
    End Sub

    ' Limpia los DGV
    Private Sub LimpiarPermisosUsuario()
        vPermisoAsignadoSeleccionado = Nothing
        vPermisoDisponibleSeleccionado = Nothing
        DGVPermisosAsignadosUsuario.DataSource = Nothing
        DGVPermisosDisponiblesUsuario.DataSource = Nothing
    End Sub

    'Validar la contraseña ingresada
    Public Function ValidarContraseña(ByVal pPsw As String) As Boolean

        Dim minLength As Integer = 8
        Dim numUpper As Integer = 1
        Dim numLower As Integer = 1
        Dim numNumbers As Integer = 1
        Dim numSpecial As Integer = 1

        ' Replace [A-Z] with \p{Lu}, to allow for Unicode uppercase letters.
        Dim upper As New System.Text.RegularExpressions.Regex("[A-Z]")
        Dim lower As New System.Text.RegularExpressions.Regex("[a-z]")
        Dim number As New System.Text.RegularExpressions.Regex("[0-9]")
        ' Special is "none of the above".
        Dim special As New System.Text.RegularExpressions.Regex("[^a-zA-Z0-9]")

        ' Check the length.
        If Len(pPsw) < minLength Then
            MsgBox("La contraseña debe tener al menos ocho caracteres.")
            Return False
        End If
        ' Check for minimum number of occurrences.
        If upper.Matches(pPsw).Count < numUpper Then
            MsgBox("La contraseña debe tener al menos un caracter en mayúscula.")
            Return False
        End If
        If lower.Matches(pPsw).Count < numLower Then
            MsgBox("La contraseña debe tener al menos un caracter en minúscula.")
            Return False
        End If
        If number.Matches(pPsw).Count < numNumbers Then
            MsgBox("La contraseña debe tener al menos un número.")
            Return False
        End If
        If special.Matches(pPsw).Count < numSpecial Then
            MsgBox("La contraseña debe tener al menos un caracter especial (+,-,#,%,$...).")
            Return False
        End If

        ' Passed all checks.
        Return True

    End Function

#End Region

#Region "Configuracion de contextos"

    Private Sub ContextoNuevaBusqueda()

        ' Cambia la variable del contexto. 
        vContexto = ContextoUsuario.NuevaBusqueda

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearUsuario.Visible = True
        BTNCrearUsuario.Text = "Crear Usuario"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Buscar"
        BTNBuscar.Width = 84
        BTNBitacora.Visible = False
        BTNDesbloquear.Visible = False
        BTNCambiarContraseña.Visible = False

        ' Adapta la variable al nuevo contexto.
        vUsuarioSeleccionado = Nothing

        LimpiarCamposUsuario()
        HabilitarCamposUsuario()
        LimpiarPermisosUsuario()
        DGVUsuarios.DataSource = Nothing

    End Sub

    Private Sub ContextoCrearUsuario()

        ' Cambia la variable del contexto. 
        vContexto = ContextoUsuario.CrearUsuario

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearUsuario.Visible = True
        BTNCrearUsuario.Text = "Guardar"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"
        BTNBuscar.Width = 84
        BTNBitacora.Visible = False
        BTNDesbloquear.Visible = False
        BTNCambiarContraseña.Visible = False

        ' Adapta la variable al nuevo contexto.
        vUsuarioSeleccionado = Nothing

        LimpiarCamposUsuario()
        HabilitarCamposUsuario()
        LimpiarPermisosUsuario()

    End Sub

    Private Sub ContextoUsuarioSeleccionado()

        ' Cambia la variable del contexto. 
        vContexto = ContextoUsuario.UsuarioSeleccionado

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = True
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = True
        BTNEliminar.Text = "Eliminar"
        BTNCrearUsuario.Visible = True
        BTNCrearUsuario.Text = "Crear Usuario"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Nueva Búsqueda"
        BTNBuscar.Width = 110
        BTNBitacora.Visible = True
        BTNDesbloquear.Visible = True
        BTNCambiarContraseña.Visible = True

        ' Adapta la variable al nuevo contexto.
        SeleccionarUsuario()

        LimpiarCamposUsuario()
        CompletarCamposUsuario()

    End Sub

    Private Sub ContextoModificarUsuario()

        ' Cambia la variable del contexto. 
        vContexto = ContextoUsuario.ModicarUsuario

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearUsuario.Visible = True
        BTNCrearUsuario.Text = "Guardar Cambios"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"
        BTNBuscar.Width = 84
        BTNBitacora.Visible = False
        BTNDesbloquear.Visible = False
        BTNCambiarContraseña.Visible = False

        HabilitarCamposUsuario()
        TBUsuario.Enabled = False

    End Sub

#End Region

#Region "Asignacion de permisos"

    Dim vListaPermisosCompleta As List(Of Permiso_SEG)
    Dim vListaPermisosDisponiblesUsuario As New List(Of Permiso_SEG)
    Dim vPermisoAsignadoSeleccionado As Permiso_SEG = Nothing
    Dim vPermisoDisponibleSeleccionado As Permiso_SEG = Nothing

    Private Sub ActualizarPermisosUsuario()

        ' Actualizo las listas de permisos. La que contiene todos los permisos existentes y la de permisos posibles a asignar.
        Dim vPermisoTEC As New GestorPermisos_TEC
        vListaPermisosCompleta = vPermisoTEC.ConsultaTodos()
        ' Completo la lista de los permisos disponibles.
        vListaPermisosDisponiblesUsuario.Clear()
        For Each vPermiso As Permiso_SEG In vListaPermisosCompleta
            If vUsuarioSeleccionado.Permisos Is Nothing Then
                vListaPermisosDisponiblesUsuario.Add(vPermiso)
            Else
                Dim vAgregarPermisoDisponible As Boolean = True
                For Each vPermisoUsuario As Permiso_SEG In vUsuarioSeleccionado.Permisos
                    If vPermisoUsuario.Codigo = vPermiso.Codigo Then
                        vAgregarPermisoDisponible = False
                    End If
                Next
                If vAgregarPermisoDisponible Then
                    vListaPermisosDisponiblesUsuario.Add(vPermiso)
                End If
            End If
        Next


        DGVPermisosAsignadosUsuario.DataSource = Nothing
        DGVPermisosAsignadosUsuario.DataSource = vUsuarioSeleccionado.Permisos
        DGVPermisosAsignadosUsuario.DataSource = vUsuarioSeleccionado.Permisos
        'Codigo
        DGVPermisosAsignadosUsuario.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosUsuario.Columns("Codigo").HeaderText = "Código"
        'Nombre
        DGVPermisosAsignadosUsuario.Columns("Nombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosUsuario.Columns("Nombre").HeaderText = "Nombre"
        'EsPerfil
        DGVPermisosAsignadosUsuario.Columns("EsPerfil").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosUsuario.Columns("EsPerfil").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosUsuario.Columns("EsPerfil").HeaderText = "Es Perfil"
        DGVPermisosAsignadosUsuario.Columns("EsPerfil").Width = 81

        DGVPermisosDisponiblesUsuario.DataSource = Nothing
        DGVPermisosDisponiblesUsuario.DataSource = vListaPermisosDisponiblesUsuario

        'Codigo
        DGVPermisosDisponiblesUsuario.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesUsuario.Columns("Codigo").HeaderText = "Código"
        'Nombre
        DGVPermisosDisponiblesUsuario.Columns("Nombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesUsuario.Columns("Nombre").HeaderText = "Nombre"
        'EsPerfil
        DGVPermisosDisponiblesUsuario.Columns("EsPerfil").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesUsuario.Columns("EsPerfil").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesUsuario.Columns("EsPerfil").HeaderText = "Es Perfil"
        DGVPermisosDisponiblesUsuario.Columns("EsPerfil").Width = 80

    End Sub

    Private Sub BTNDesasignar_Click(sender As Object, e As EventArgs) Handles BTNDesasignar.Click
        If Not IsNothing(vPermisoAsignadoSeleccionado) Then
            Dim vGestorPermisoTEC As New GestorPermisos_TEC
            vGestorPermisoTEC.DesasignarPermisoAUsuario(vUsuarioSeleccionado, vPermisoAsignadoSeleccionado)
            MsgBox("El permiso ha sido quitado correctamente.")
            vUsuarioSeleccionado.Permisos.Remove(vPermisoAsignadoSeleccionado)
            ActualizarPermisosUsuario()
        End If
    End Sub

    Private Sub BTNAsignar_Click(sender As Object, e As EventArgs) Handles BTNAsignar.Click

        If Not IsNothing(vPermisoDisponibleSeleccionado) Then
            Dim vGestorPermisoTEC As New GestorPermisos_TEC
            vGestorPermisoTEC.AsignarPermisoAUsuario(vUsuarioSeleccionado, vPermisoDisponibleSeleccionado)
            MsgBox("El permiso ha sido asignado correctamente.")
            vUsuarioSeleccionado.Permisos.Add(vPermisoDisponibleSeleccionado)
            ActualizarPermisosUsuario()
        End If

    End Sub

#Region "Configurar variables Permisos Seleccionado"

    Private Sub DGVPermisosAsignadosUsuario_SelectionChanged(sender As Object, e As EventArgs) Handles DGVPermisosAsignadosUsuario.SelectionChanged
        SeleccionarPermisoAsignadoActual()
    End Sub

    Private Sub DGVPermisosDisponiblesUsuario_SelectionChanged(sender As Object, e As EventArgs) Handles DGVPermisosDisponiblesUsuario.SelectionChanged
        SeleccionarPermisoDisponibleActual()
    End Sub

    Private Sub SeleccionarPermisoAsignadoActual()
        If DGVPermisosAsignadosUsuario.SelectedRows.Count > 0 Then
            For Each vPermiso As Permiso_SEG In vUsuarioSeleccionado.Permisos
                If vPermiso.Codigo = DGVPermisosAsignadosUsuario.SelectedRows.Item(0).Cells.Item(0).Value.ToString Then
                    vPermisoAsignadoSeleccionado = vPermiso
                End If
            Next
        End If
    End Sub

    Private Sub SeleccionarPermisoDisponibleActual()
        If DGVPermisosDisponiblesUsuario.SelectedRows.Count > 0 Then
            For Each vPermiso As Permiso_SEG In vListaPermisosDisponiblesUsuario
                If vPermiso.Codigo = DGVPermisosDisponiblesUsuario.SelectedRows.Item(0).Cells.Item(0).Value.ToString Then
                    vPermisoDisponibleSeleccionado = vPermiso
                End If
            Next
        End If
    End Sub

#End Region

#End Region

#End Region

#Region "Pestaña Perfiles"

    ' Formulario para crear un perfil nuevo.
    Dim WithEvents vFormNuevaFamilia As FormNuevoPerfil

    ' Permite actualizar el ComboBox de los perfiles.
    Dim vListaFamilias As New List(Of Permiso_SEG)

    ' DataSourse de DGV de los permisos que pueden ser asignados a una familia.
    Dim vListaPermisosDisponibles As New List(Of Permiso_SEG)

    ' Todos los permisos existentes en la aplicacion.
    Dim vListaPermisos As New List(Of Permiso_SEG)

    ' Permiso seleccionado en el ComboBox.
    Dim vPermisoActual As Permiso_SEG

    ' Permiso seleccionado en el DGVPermisosAsignadosPerfil.
    Dim vPermisoSeleccionadoAsignado As Permiso_SEG = Nothing

    ' Permiso seleccionado en el DGVPermisosDisponiblesPerfil.
    Dim vPermisoSeleccionadoDisponible As Permiso_SEG = Nothing

    ' Indica si hay que advertir al usuario que se realizaron cambios del perfil actual.
    Dim vConsultarPorCambios As Boolean = True

    Private _FamiliaModificada As Boolean
    Public Property vFamiliaModificada() As Boolean
        Get
            Return _FamiliaModificada
        End Get
        Set(ByVal value As Boolean)
            If _FamiliaModificada = False Then
                Dim vFamilia As Familia_SEG
                vFamilia = vPermisoActual
                vFamilia.SetState()
            End If
            _FamiliaModificada = value
        End Set
    End Property

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Private Sub BTNGuardarCambios_Click(sender As Object, e As EventArgs) Handles BTNGuardarCambios.Click
        If vFamiliaModificada = True And Not vPermisoActual Is Nothing Then
            Dim vPermisoTEC As New GestorPermisos_TEC
            vPermisoTEC.Modificacion(vPermisoActual)
            vFamiliaModificada = False
            CargarPermisosExistentes()
            ActualizarPerfiles()
            DGVPermisosAsignadosPerfil.DataSource = Nothing
            DGVPermisosDisponiblesPerfil.DataSource = Nothing
            MsgBox("Modificación realizada con éxito.")
        Else
            MsgBox("No se han encontrado cambios.")
        End If
    End Sub

    Private Sub DGVPermisosAsignadosPerfil_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPermisosAsignadosPerfil.CellDoubleClick
        VariablePermisoAsignadoActual(DGVPermisosAsignadosPerfil.SelectedRows.Item(0).Cells.Item(0).Value.ToString)
        DesasignarPermiso()
    End Sub

    Private Sub BTNCrearPerfil_Click(sender As Object, e As EventArgs) Handles BTNCrearPerfil.Click
        If Me.vFormNuevaFamilia Is Nothing Then
            Me.vFormNuevaFamilia = New FormNuevoPerfil
            Me.vFormNuevaFamilia.MdiParent = Me.MdiParent
        End If
        vFormNuevaFamilia.Actualizar(Idioma)
        vFormNuevaFamilia.Show()
    End Sub

    Private Sub vFormNuevoPerfil_FormClosing(sender As Object, e As FormClosingEventArgs) Handles vFormNuevaFamilia.FormClosing
        vFormNuevaFamilia = Nothing
        ActualizarPerfiles()
    End Sub

    Private Sub ActualizarPerfiles()
        'Actualiza el ComboBox de Familias
        Dim vGestorPermisoTEC As New GestorPermisos_TEC
        CBPerfiles.Items.Clear()
        Dim vFamilia As New Familia_SEG
        vFamilia.EsPerfil = True
        vListaFamilias = Nothing
        vListaFamilias = vGestorPermisoTEC.ConsultaVarios(vFamilia)
        For Each vPerfil As SEGURIDAD.Permiso_SEG In vListaFamilias
            CBPerfiles.Items.Add(vPerfil)
        Next
        CBPerfiles.DisplayMember = "Nombre"
    End Sub

    Private Sub FormAdmPerfilesUsuarios_Load(sender As Object, e As EventArgs) Handles Me.Load
        CargarPermisosExistentes()
        ActualizarPerfiles()
        Actualizar(Me.Idioma)
        CerrarAplicacion = False
    End Sub

    Private Sub CBPerfiles_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBPerfiles.SelectedValueChanged
        If vFamiliaModificada Then
            If vConsultarPorCambios Then
                Dim result As Integer = MessageBox.Show("No ha guardado los cambios. Confirme para continuar sin guardar.", "¡Atención!", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then
                    vConsultarPorCambios = False
                    CBPerfiles.SelectedItem = vPermisoActual
                    vConsultarPorCambios = True
                ElseIf result = DialogResult.No Then
                    vConsultarPorCambios = False
                    CBPerfiles.SelectedItem = vPermisoActual
                    vConsultarPorCambios = True
                ElseIf result = DialogResult.Yes Then
                    Dim vFamilia As Familia_SEG = vPermisoActual
                    vFamilia.RestartState()
                    vPermisoActual = CBPerfiles.SelectedItem
                    DGVPermisosAsignadosPerfil.DataSource = Nothing
                    If Not vPermisoActual.ListarHijos Is Nothing Then
                        If vPermisoActual.ListarHijos.Count > 0 Then
                            ActualizarDGVPermisosAsignadosPerfil()
                        End If
                    End If
                    ActualizarPermisosDisponibles()
                    vFamiliaModificada = False
                End If
            End If
        Else
            vPermisoActual = CBPerfiles.SelectedItem
            DGVPermisosAsignadosPerfil.DataSource = Nothing
            If Not vPermisoActual.ListarHijos Is Nothing Then
                If vPermisoActual.ListarHijos.Count > 0 Then
                    ActualizarDGVPermisosAsignadosPerfil()
                End If
            End If
            ActualizarPermisosDisponibles()
        End If
    End Sub

    Private Sub ActualizarDGVPermisosAsignadosPerfil()

        DGVPermisosAsignadosPerfil.DataSource = vPermisoActual.ListarHijos
        'Codigo
        DGVPermisosAsignadosPerfil.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosPerfil.Columns("Codigo").HeaderText = "Código"
        'Nombre
        DGVPermisosAsignadosPerfil.Columns("Nombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosPerfil.Columns("Nombre").HeaderText = "Nombre"
        DGVPermisosAsignadosPerfil.Columns("Nombre").Width = 131
        'EsPerfil
        DGVPermisosAsignadosPerfil.Columns("EsPerfil").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosPerfil.Columns("EsPerfil").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosAsignadosPerfil.Columns("EsPerfil").HeaderText = "Es Perfil"
        DGVPermisosAsignadosPerfil.Columns("EsPerfil").Width = 72

    End Sub

    Private Sub ActualizarDGVPermisosDisponiblesPerfil()

        DGVPermisosDisponiblesPerfil.DataSource = vListaPermisosDisponibles
        'Codigo
        DGVPermisosDisponiblesPerfil.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesPerfil.Columns("Codigo").HeaderText = "Código"
        'Nombre
        DGVPermisosDisponiblesPerfil.Columns("Nombre").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesPerfil.Columns("Nombre").HeaderText = "Nombre"
        DGVPermisosDisponiblesPerfil.Columns("Nombre").Width = 131
        'EsPerfil
        DGVPermisosDisponiblesPerfil.Columns("EsPerfil").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesPerfil.Columns("EsPerfil").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPermisosDisponiblesPerfil.Columns("EsPerfil").HeaderText = "Es Perfil"
        DGVPermisosDisponiblesPerfil.Columns("EsPerfil").Width = 72

    End Sub

    Private Sub BTNEliminarPerfil_Click(sender As Object, e As EventArgs) Handles BTNEliminarPerfil.Click
        Dim vPermisoTEC As New GestorPermisos_TEC
        If Not vPermisoActual Is Nothing Then
            Try
                Dim result As Integer = MessageBox.Show("Esta a punto de eliminar el perfil. Confirme para continuar.", "¡Atención!", MessageBoxButtons.YesNoCancel)
                If result = DialogResult.Cancel Then

                ElseIf result = DialogResult.No Then
                    MessageBox.Show("No se dará de baja el perfil.")
                ElseIf result = DialogResult.Yes Then
                    vPermisoTEC.Baja(vPermisoActual)
                    MessageBox.Show("El perfil ha sido dado de baja.")
                    CBPerfiles.Text = ""
                    ActualizarDGVPermisosAsignadosPerfil()
                    DGVPermisosDisponiblesPerfil.DataSource = Nothing
                    ActualizarDGVPermisosDisponiblesPerfil()
                    ActualizarPerfiles()
                    CargarPermisosExistentes()
                    vFamiliaModificada = False
                End If
            Catch ex As Exception

            End Try
        Else
            MsgBox("Debe seleccionar un perfil.")
        End If
    End Sub

    Private Sub CargarPermisosExistentes()
        'Actualiza el listado con todos los permisos del sistema.
        Dim vGestorPermisoTEC As New GestorPermisos_TEC
        vListaPermisos = Nothing
        vListaPermisos = vGestorPermisoTEC.ConsultaTodos()
    End Sub

    Sub ActualizarPermisosDisponibles()
        vListaPermisosDisponibles.Clear()
        DGVPermisosDisponiblesPerfil.DataSource = Nothing
        Dim vFamilia As Familia_SEG
        vFamilia = vPermisoActual
        For Each vPermiso As Permiso_SEG In vListaPermisos
            If Not vFamilia.PermisoAsignado(vPermiso) Then
                vListaPermisosDisponibles.Add(vPermiso)
            End If
        Next
        DGVPermisosDisponiblesPerfil.DataSource = vListaPermisosDisponibles
        ActualizarDGVPermisosDisponiblesPerfil()
    End Sub

    Private Sub DGVPermisosAsignadosPerfil_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPermisosAsignadosPerfil.CellClick
        VariablePermisoAsignadoActual(DGVPermisosAsignadosPerfil.SelectedRows.Item(0).Cells.Item(0).Value.ToString)
    End Sub

    Private Sub VariablePermisoAsignadoActual(ByVal pCodigo As String)
        For Each vPermiso As Permiso_SEG In vPermisoActual.ListarHijos
            If vPermiso.Codigo = pCodigo Then
                vPermisoSeleccionadoAsignado = vPermiso
            End If
        Next
    End Sub

    Private Sub VariablePermisoDisponibleActual(ByVal pCodigo As String)
        For Each vPermiso As Permiso_SEG In vListaPermisosDisponibles
            If vPermiso.Codigo = pCodigo Then
                vPermisoSeleccionadoDisponible = vPermiso
            End If
        Next
    End Sub

    Private Sub AsignarPermiso()
        If Not IsNothing(vPermisoSeleccionadoDisponible) Then
            vFamiliaModificada = True
            If Not vPermisoSeleccionadoDisponible.EsValido(vPermisoActual.Nombre) Then
                vPermisoActual.AgregarHijo(vPermisoSeleccionadoDisponible)
                vListaPermisosDisponibles.Remove(vPermisoSeleccionadoDisponible)
                vPermisoSeleccionadoDisponible = Nothing
                ActualizarPermisosDisponibles()
                DGVPermisosAsignadosPerfil.DataSource = Nothing
                ActualizarDGVPermisosAsignadosPerfil()
                CargarPermisosExistentes()
            Else
                MsgBox("Los permisos no pueden ser recursivos.")
            End If
        Else
            MsgBox("Debe seleccionar un permiso a asignar.")
        End If
    End Sub

    Private Sub DesasignarPermiso()
        If Not IsNothing(vPermisoSeleccionadoAsignado) Then
            vListaPermisosDisponibles.Add(vPermisoSeleccionadoAsignado)
            vPermisoActual.QuitarHijo(vPermisoSeleccionadoAsignado)
            vPermisoSeleccionadoAsignado = Nothing
            ActualizarPermisosDisponibles()
            DGVPermisosAsignadosPerfil.DataSource = Nothing
            ActualizarDGVPermisosAsignadosPerfil()
            vFamiliaModificada = True
            CargarPermisosExistentes()
        Else
            MsgBox("Debe seleccionar un permiso a quitar.")
        End If
    End Sub

    Private Sub BTNAsignarPermiso_Click(sender As Object, e As EventArgs) Handles BTNAsignarPermiso.Click
        AsignarPermiso()
    End Sub

    Private Sub DGVPermisosDisponiblesPerfil_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPermisosDisponiblesPerfil.CellClick
        VariablePermisoDisponibleActual(DGVPermisosDisponiblesPerfil.SelectedRows.Item(0).Cells.Item(0).Value.ToString)
    End Sub

    Private Sub DGVPermisosDisponiblesPerfil_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPermisosDisponiblesPerfil.CellDoubleClick
        VariablePermisoDisponibleActual(DGVPermisosDisponiblesPerfil.SelectedRows.Item(0).Cells.Item(0).Value.ToString)
        AsignarPermiso()
    End Sub

    Private Sub BTNDesasignarPermiso_Click(sender As Object, e As EventArgs) Handles BTNDesasignarPermiso.Click
        DesasignarPermiso()
    End Sub

#End Region

#Region "Eventos"

    ' El evento se dispara al cerrar el formulario (Me.Leave)
    Public Event CerrarForm()

    Private Sub FormAdmPerfilesUsuarios_Leave(sender As Object, e As EventArgs) Handles Me.Leave
        RaiseEvent CerrarForm()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Try
            Me.Close()
        Catch ex As Exception

        End Try
    End Sub

    Private Sub TBDNI_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBDNI.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub FormAdmPerfilesUsuarios_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not vFormNuevaFamilia Is Nothing Then
            vFormNuevaFamilia.Close()
        End If
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormAdmPerfilesUsuarios")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormAdmPerfilesUsuarios").MensajeTraducido
        Me.TPUsuarios.Text = vDiccionario("TPUsuarios").MensajeTraducido
        Me.TPPerfiles.Text = vDiccionario("TPPerfiles").MensajeTraducido
        Me.LbUsuario.Text = vDiccionario("LbUsuario").MensajeTraducido
        Me.LbNombre.Text = vDiccionario("LbNombre").MensajeTraducido
        Me.LbApellido.Text = vDiccionario("LbApellido").MensajeTraducido
        Me.LbEmail.Text = vDiccionario("LbEmail").MensajeTraducido
        Me.BTNModificar.Text = vDiccionario("BTNModificar").MensajeTraducido
        Me.BTNEliminar.Text = vDiccionario("BTNEliminar").MensajeTraducido
        Me.BTNCrearUsuario.Text = vDiccionario("BTNCrearUsuario").MensajeTraducido
        Me.BTNBuscar.Text = vDiccionario("BTNBuscar").MensajeTraducido
        Me.BTNBitacora.Text = vDiccionario("BTNBitacora").MensajeTraducido
        Me.BTNDesasignar.Text = vDiccionario("BTNDesasignar").MensajeTraducido
        Me.BTNAsignar.Text = vDiccionario("BTNAsignar").MensajeTraducido
        Me.GBResultados.Text = vDiccionario("GBResultados").MensajeTraducido
        Me.GPPermisosAsignadosUsuarios.Text = vDiccionario("GPPermisosAsignadosUsuarios").MensajeTraducido
        Me.GPPermisosDisponiblesUsuarios.Text = vDiccionario("GPPermisosDisponiblesUsuarios").MensajeTraducido
        Me.LbPerfil.Text = vDiccionario("LbPerfil").MensajeTraducido
        Me.BTNCrearPerfil.Text = vDiccionario("BTNCrearPerfil").MensajeTraducido
        Me.BTNGuardarCambios.Text = vDiccionario("BTNGuardarCambios").MensajeTraducido
        Me.BTNEliminarPerfil.Text = vDiccionario("BTNEliminarPerfil").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido
        Me.GBPermisosAsignadosPerfiles.Text = vDiccionario("GBPermisosAsignadosPerfiles").MensajeTraducido
        Me.GBPermisosDisponiblesPerfiles.Text = vDiccionario("GBPermisosDisponiblesPerfiles").MensajeTraducido
        Me.BTNCambiarContraseña.Text = vDiccionario("BTNCambiarContraseña").MensajeTraducido
        Me.BTNDesbloquear.Text = vDiccionario("BTNDesbloquear").MensajeTraducido
        Idioma = pIdioma
        If Not vFormNuevaFamilia Is Nothing Then
            vFormNuevaFamilia.Idioma = Me.Idioma
            vFormNuevaFamilia.Actualizar(Me.Idioma)
        End If

        If Not vFormBitacora Is Nothing Then
            vFormBitacora.Idioma = Me.Idioma
            vFormBitacora.Actualizar(Me.Idioma)
        End If

    End Sub


#End Region

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

#Region "Ayuda en Línea"

    Private Sub TBUsuario_MouseHover(sender As Object, e As EventArgs) Handles TBUsuario.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el código del usuario a buscar.")
            ToolTip.ToolTipTitle = "Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(TBUsuario, "No es posible modificar el código del usuario desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el código del usuario a modificar.")
            ToolTip.ToolTipTitle = "Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el código del usuario a crear.")
            ToolTip.ToolTipTitle = "Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBNombre_MouseHover(sender As Object, e As EventArgs) Handles TBNombre.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(TBNombre, "Ingrese aquí el Nombre del usuario a buscar.")
            ToolTip.ToolTipTitle = "Nombre"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(TBUsuario, "No es posible modificar el Nombre del usuario desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Nombre"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el Nombre del usuario a buscar.")
            ToolTip.ToolTipTitle = "Nombre"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el Nombre del usuario a crear.")
            ToolTip.ToolTipTitle = "Nombre"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBApellido_MouseHover(sender As Object, e As EventArgs) Handles TBApellido.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(TBNombre, "Ingrese aquí el Apellido del usuario a buscar.")
            ToolTip.ToolTipTitle = "Apellido"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(TBUsuario, "No es posible modificar el Apellido del usuario desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Apellido"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el Apellido del usuario a modificar.")
            ToolTip.ToolTipTitle = "Apellido"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el Apellido del usuario a crear.")
            ToolTip.ToolTipTitle = "Apellido"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBDNI_MouseHover(sender As Object, e As EventArgs) Handles TBDNI.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(TBNombre, "Ingrese aquí el DNI del usuario a buscar.")
            ToolTip.ToolTipTitle = "DNI"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(TBUsuario, "No es posible modificar el DNI del usuario desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "DNI"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el DNI del usuario a modificar.")
            ToolTip.ToolTipTitle = "DNI"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el DNI del usuario a crear.")
            ToolTip.ToolTipTitle = "DNI"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBEMail_MouseHover(sender As Object, e As EventArgs) Handles TBEMail.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(TBEMail, "Ingrese aquí el EMail del usuario a buscar.")
            ToolTip.ToolTipTitle = "EMail"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(TBUsuario, "No es posible modificar el EMail del usuario desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "EMail"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el EMail del usuario a modificar.")
            ToolTip.ToolTipTitle = "EMail"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBUsuario, "Ingrese aquí el EMail del usuario a crear.")
            ToolTip.ToolTipTitle = "EMail"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNModificar_MouseHover(sender As Object, e As EventArgs) Handles BTNModificar.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNModificar, "")
            ToolTip.ToolTipTitle = "Modificar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic para modificar el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Modificar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic para guardar los cambios realizados.")
            ToolTip.ToolTipTitle = "Modificar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNModificar, "")
            ToolTip.ToolTipTitle = "Modificar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNEliminar_MouseHover(sender As Object, e As EventArgs) Handles BTNEliminar.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNEliminar, "")
            ToolTip.ToolTipTitle = "Eliminar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic para eliminar el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic para eliminar el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNEliminar, "")
            ToolTip.ToolTipTitle = "Eliminar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNCrearUsuario_MouseHover(sender As Object, e As EventArgs) Handles BTNCrearUsuario.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNCrearUsuario, "Haga clic para crear un nuevo usuario.")
            ToolTip.ToolTipTitle = "Crear Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNCrearUsuario, "Haga clic para crear un nuevo usuario.")
            ToolTip.ToolTipTitle = "Crear Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNCrearUsuario, "Haga clic para guardar los cambios realizados.")
            ToolTip.ToolTipTitle = "Crear Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNCrearUsuario, "Haga clic para confirmar la creación del nuevo usuario.")
            ToolTip.ToolTipTitle = "Crear Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNBuscar_MouseHover(sender As Object, e As EventArgs) Handles BTNBuscar.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic para efectuar la búsqueda.")
            ToolTip.ToolTipTitle = "Buscar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic para realizar una nueva búsqueda.")
            ToolTip.ToolTipTitle = "Buscar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic para realizar una nueva búsqueda. Los cambios no serán guardados.")
            ToolTip.ToolTipTitle = "Buscar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNBuscar, "Haga clic para realizar una nueva búsqueda.")
            ToolTip.ToolTipTitle = "Buscar Usuario"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNCambiarContraseña_MouseHover(sender As Object, e As EventArgs) Handles BTNCambiarContraseña.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNCambiarContraseña, "Haga clic para cambiar la contraseña.")
            ToolTip.ToolTipTitle = "Cambiar Contraseña"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNCambiarContraseña, "Haga clic para cambiar la contraseña.")
            ToolTip.ToolTipTitle = "Cambiar Contraseña"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNCambiarContraseña, "Haga clic para cambiar la contraseña.")
            ToolTip.ToolTipTitle = "Cambiar Contraseña"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNCambiarContraseña, "Haga clic para cambiar la contraseña.")
            ToolTip.ToolTipTitle = "Cambiar Contraseña"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNDesbloquear_MouseHover(sender As Object, e As EventArgs) Handles BTNDesbloquear.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNDesbloquear, "Haga clic para desbloquear el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Desbloqueo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNDesbloquear, "Haga clic para desbloquear el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Desbloqueo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNDesbloquear, "Haga clic para desbloquear el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Desbloqueo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNDesbloquear, "Haga clic para desbloquear el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Desbloqueo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNBitacora_MouseHover(sender As Object, e As EventArgs) Handles BTNBitacora.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNBitacora, "Haga clic para visualizar el historial de cambios realizados en el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Bitacora"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNBitacora, "Haga clic para visualizar el historial de cambios realizados en el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Bitacora"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNBitacora, "Haga clic para visualizar el historial de cambios realizados en el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Bitacora"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNBitacora, "Haga clic para visualizar el historial de cambios realizados en el usuario seleccionado.")
            ToolTip.ToolTipTitle = "Bitacora"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNDesasignar_MouseHover(sender As Object, e As EventArgs) Handles BTNDesasignar.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNDesasignar, "Seleccione un usuario desde el panel de búsqueda.")
            ToolTip.ToolTipTitle = "Desasignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNDesasignar, "Seleccione un permiso y haga clic aquí para quitarlo.")
            ToolTip.ToolTipTitle = "Desasignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNDesasignar, "Seleccione un permiso y haga clic aquí para quitarlo.")
            ToolTip.ToolTipTitle = "Desasignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNDesasignar, "Seleccione un usuario desde el panel de búsqueda.")
            ToolTip.ToolTipTitle = "Desasignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNAsignar_MouseHover(sender As Object, e As EventArgs) Handles BTNAsignar.MouseHover

        If Me.vContexto = ContextoUsuario.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNAsignar, "Seleccione un usuario desde el panel de búsqueda.")
            ToolTip.ToolTipTitle = "Asignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.UsuarioSeleccionado Then
            ToolTip.SetToolTip(BTNAsignar, "Seleccione un permiso y haga clic aquí para agregarlo.")
            ToolTip.ToolTipTitle = "Asignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoUsuario.ModicarUsuario Then
            ToolTip.SetToolTip(BTNAsignar, "Seleccione un permiso y haga clic aquí para agregarlo.")
            ToolTip.ToolTipTitle = "Asignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNAsignar, "Seleccione un usuario desde el panel de búsqueda.")
            ToolTip.ToolTipTitle = "Asignar Permisos"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub CBPerfiles_MouseHover(sender As Object, e As EventArgs) Handles CBPerfiles.MouseHover

        ToolTip.SetToolTip(CBPerfiles, "Seleccione el perfil a modificar.")
        ToolTip.ToolTipTitle = "Perfiles"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNCrearPerfil_MouseHover(sender As Object, e As EventArgs) Handles BTNCrearPerfil.MouseHover

        ToolTip.SetToolTip(BTNCrearPerfil, "Haga clic para crear un nuevo perfil.")
        ToolTip.ToolTipTitle = "Crear Perfil"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNGuardarCambios_MouseHover(sender As Object, e As EventArgs) Handles BTNGuardarCambios.MouseHover

        ToolTip.SetToolTip(BTNGuardarCambios, "Haga clic para guardar los cambios realizados.")
        ToolTip.ToolTipTitle = "Guardar Cambios"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNEliminarPerfil_MouseHover(sender As Object, e As EventArgs) Handles BTNEliminarPerfil.MouseHover

        ToolTip.SetToolTip(BTNEliminarPerfil, "El perfil seleccionado será eliminado del sistema.")
        ToolTip.ToolTipTitle = "Eliminar Perfil"
        ToolTip.ToolTipIcon = ToolTipIcon.Warning

    End Sub

    Private Sub BTNAsignarPermiso_MouseHover(sender As Object, e As EventArgs) Handles BTNAsignarPermiso.MouseHover

        ToolTip.SetToolTip(BTNAsignarPermiso, "Seleccione un permiso y haga clic aquí para agregarlo.")
        ToolTip.ToolTipTitle = "Asignar Permiso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNDesasignarPermiso_MouseHover(sender As Object, e As EventArgs) Handles BTNDesasignarPermiso.MouseHover

        ToolTip.SetToolTip(BTNDesasignarPermiso, "Seleccione un permiso y haga clic aquí para quitarlo.")
        ToolTip.ToolTipTitle = "Desasignar Permiso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub FormAdmPerfilesUsuarios_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        If Not vFormNuevaFamilia Is Nothing Then
            vFormNuevaFamilia.Close()
        End If
        If Not vFormBitacora Is Nothing Then
            vFormBitacora.Close()
        End If

    End Sub

    Private Sub vFormBitacora_Closed(sender As Object, e As EventArgs) Handles vFormBitacora.Closed
        vFormBitacora = Nothing
    End Sub

#End Region

End Class