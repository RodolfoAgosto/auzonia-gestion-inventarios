Imports BE
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES
Imports System.Text.RegularExpressions

Public Class FormProveedores

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vContexto As ContextoProveedor = ContextoProveedor.NuevaBusqueda
    Dim vProveedorSeleccionado As Proveedor
    Dim vListaProveedores As List(Of Proveedor)
    Dim vProveedorNEG As New Proveedor_NEG

    Enum ContextoProveedor
        NuevaBusqueda
        ProveedorSeleccionado
        ModicarProveedor
        CrearProveedor
    End Enum

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

#Region "Procedimientos"

    ' Limpia los campos del usuario en el formulario.
    Public Sub LimpiarCamposProveedor()

        TBID.Text = ""
        TBRazonSocial.Text = ""
        TBCalle.Text = ""
        TBAltura.Text = ""
        TBTelefono.Text = ""
        TBCUIT.Text = ""
        TBEmail.Text = ""
        TBContacto.Text = ""

    End Sub

    ' Habilita los campos del usuario en el formulario.
    Public Sub HabilitarCamposProveedor()

        TBID.Enabled = True
        TBRazonSocial.Enabled = True
        TBCalle.Enabled = True
        TBAltura.Enabled = True
        TBTelefono.Enabled = True
        TBCUIT.Enabled = True
        TBEmail.Enabled = True
        TBContacto.Enabled = True

    End Sub

    ' Completa los campos del formulario con los datos del proveedor seleccionado en el DGV.
    Public Sub CompletarCamposProveedor()

        TBID.Enabled = False
        TBRazonSocial.Enabled = False
        TBCalle.Enabled = False
        TBAltura.Enabled = False
        TBTelefono.Enabled = False
        TBCUIT.Enabled = False
        TBEmail.Enabled = False
        TBContacto.Enabled = False

        ' Recorre la lista de proveedores según el ID y asigna a la variable vProveedorSeleccionado el proveedor coincidente 
        ' con el proveedor seleccionado en DGVProveedores.
        SeleccionarProveedor()
        If DGVProveedor.SelectedRows.Count > 0 Then
            TBID.Text = DGVProveedor.SelectedRows(0).Cells(0).Value
            TBRazonSocial.Text = DGVProveedor.SelectedRows(0).Cells(1).Value
            TBCalle.Text = DGVProveedor.SelectedRows(0).Cells("Calle").Value
            TBAltura.Text = DGVProveedor.SelectedRows(0).Cells(4).Value
            TBTelefono.Text = DGVProveedor.SelectedRows(0).Cells("Telefono").Value
            TBCUIT.Text = DGVProveedor.SelectedRows(0).Cells("CUIT").Value
            TBEmail.Text = DGVProveedor.SelectedRows(0).Cells(6).Value
            TBContacto.Text = DGVProveedor.SelectedRows(0).Cells(7).Value
        End If
    End Sub

    ' Asigna a la varieble vProveedorSeleccionado el usuario seleccionado en DGVProveedores. 
    Public Sub SeleccionarProveedor()

        If DGVProveedor.SelectedRows.Count > 0 Then
            Dim vID As String = DGVProveedor.SelectedRows.Item(0).Cells.Item(0).Value.ToString
            For Each vProveedor As Proveedor In vListaProveedores
                If vProveedor.ID = vID Then
                    vProveedorSeleccionado = vProveedor
                End If
            Next
        End If

    End Sub

    'Cambia el contexto del formulario al seleccionar un nuevo proveedor.
    Private Sub DGVProveedor_SelectionChanged(sender As Object, e As EventArgs) Handles DGVProveedor.SelectionChanged
        If DGVProveedor.SelectedRows IsNot Nothing Then
            ContextoProveedorSeleccionado()
        End If
    End Sub

    'Actualiza el idioma del formulario.
    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormProveedores")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormProveedores").MensajeTraducido
        Me.LbRazonSocial.Text = vDiccionario("LbRazonSocial").MensajeTraducido
        Me.LbCalle.Text = vDiccionario("LbCalle").MensajeTraducido
        Me.LbAltura.Text = vDiccionario("LbAltura").MensajeTraducido
        Me.LbTelefono.Text = vDiccionario("LbTelefono").MensajeTraducido
        Me.LbContacto.Text = vDiccionario("LbContacto").MensajeTraducido
        Me.GBResultados.Text = vDiccionario("GBResultados").MensajeTraducido
        Me.BTNCrearProveedor.Text = vDiccionario("BTNCrearProveedor").MensajeTraducido
        Me.BTNBuscar.Text = vDiccionario("BTNBuscar").MensajeTraducido
        Me.BTNModificar.Text = vDiccionario("BTNModificar").MensajeTraducido
        Me.BTNEliminar.Text = vDiccionario("BTNEliminar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

    'Valida los cambios ingresados por el usuario.
    Public Function Validar() As Boolean
        Dim res As Boolean = True
        Dim vEmail As Boolean = False
        vEmail = IsValidEmail(TBEmail.Text)
        If Not vEmail Then
            res = False
            MsgBox("El mail no es valido.")
        End If
        Dim vCUIT As Boolean = False
        vCUIT = mkf_validacuit(TBCUIT.Text)
        If Not vCUIT Then
            res = False
            MsgBox("El CUIT no es válido.")
        End If
        Return res
    End Function

    'Validar el formato del mail.
    Public Function IsValidEmail(ByVal email As String) As Boolean
        If email = String.Empty Then Return False
        ' Compruebo si el formato de la dirección es correcto.
        Dim re As Regex = New Regex("^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")
        Dim m As Match = re.Match(email)
        Return (m.Captures.Count <> 0)
    End Function

    'Valida el formato del CUIT.
    Private Function mkf_validacuit(ByVal mk_p_nro As String) As Boolean
        Dim mk_suma As Integer
        Dim mk_valido As Boolean = False
        mk_p_nro = mk_p_nro.Replace("-", "")
        If IsNumeric(mk_p_nro) Then
            If mk_p_nro.Length <> 11 Then
                mk_valido = False
            Else
                mk_suma = 0
                mk_suma += CInt(mk_p_nro.Substring(0, 1)) * 5
                mk_suma += CInt(mk_p_nro.Substring(1, 1)) * 4
                mk_suma += CInt(mk_p_nro.Substring(2, 1)) * 3
                mk_suma += CInt(mk_p_nro.Substring(3, 1)) * 2
                mk_suma += CInt(mk_p_nro.Substring(4, 1)) * 7
                mk_suma += CInt(mk_p_nro.Substring(5, 1)) * 6
                mk_suma += CInt(mk_p_nro.Substring(6, 1)) * 5
                mk_suma += CInt(mk_p_nro.Substring(7, 1)) * 4
                mk_suma += CInt(mk_p_nro.Substring(8, 1)) * 3
                mk_suma += CInt(mk_p_nro.Substring(9, 1)) * 2
                mk_suma += CInt(mk_p_nro.Substring(10, 1)) * 1
                If Math.Round(mk_suma / 11, 0) = (mk_suma / 11) Then
                    mk_valido = True
                Else
                    mk_valido = False
                End If

            End If

        Else
            mk_valido = False
        End If
        Return (mk_valido)
    End Function


#Region "Configuracion de contextos"

    Private Sub ContextoNuevaBusqueda()

        ' Cambia la variable del contexto. 
        vContexto = ContextoProveedor.NuevaBusqueda

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearProveedor.Visible = True
        BTNCrearProveedor.Text = "Crear Proveedor"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Buscar"

        ' Adapta la variable al nuevo contexto.
        vProveedorSeleccionado = Nothing

        LimpiarCamposProveedor()
        HabilitarCamposProveedor()
        DGVProveedor.DataSource = Nothing

    End Sub

    Private Sub ContextoCrearProveedor()

        ' Cambia la variable del contexto. 
        vContexto = ContextoProveedor.CrearProveedor

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearProveedor.Visible = True
        BTNCrearProveedor.Text = "Guardar"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        ' Adapta la variable al nuevo contexto.
        vProveedorSeleccionado = Nothing

        LimpiarCamposProveedor()
        HabilitarCamposProveedor()
        TBID.Enabled = False

    End Sub

    Private Sub ContextoProveedorSeleccionado()

        ' Cambia la variable del contexto. 
        vContexto = ContextoProveedor.ProveedorSeleccionado

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = True
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = True
        BTNEliminar.Text = "Eliminar"
        BTNCrearProveedor.Visible = True
        BTNCrearProveedor.Text = "Crear Proveedor"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Nueva Búsqueda"

        ' Adapta la variable al nuevo contexto.
        SeleccionarProveedor()

        LimpiarCamposProveedor()
        CompletarCamposProveedor()

    End Sub

    Private Sub ContextoModificarProveedor()

        ' Cambia la variable del contexto. 
        vContexto = ContextoProveedor.ModicarProveedor
        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearProveedor.Visible = True
        BTNCrearProveedor.Text = "Guardar Cambios"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        HabilitarCamposProveedor()
        TBID.Enabled = False

    End Sub

#End Region

#End Region

#Region "Eventos"

#Region "Buttons"

    Private Sub BTNCrearProveedor_Click(sender As Object, e As EventArgs) Handles BTNCrearProveedor.Click

        If vContexto = ContextoProveedor.CrearProveedor Then
            Dim vNuevoProveedor As New Proveedor
            If TBRazonSocial.Text <> "" And TBCalle.Text <> "" And TBAltura.Text <> "" And TBTelefono.Text <> "" And TBCUIT.Text <> "" And TBEmail.Text <> "" And TBContacto.Text <> "" Then
                Try
                    vNuevoProveedor.RazonSocial = TBRazonSocial.Text
                    vNuevoProveedor.Calle = TBCalle.Text
                    vNuevoProveedor.Altura = TBAltura.Text
                    vNuevoProveedor.Telefono = TBTelefono.Text
                    vNuevoProveedor.CUIT = TBCUIT.Text
                    vNuevoProveedor.Email = TBEmail.Text
                    vNuevoProveedor.NombreContacto = TBContacto.Text
                    Dim vRespuestaValidacion As Boolean = False
                    vRespuestaValidacion = Validar()
                    If vRespuestaValidacion Then
                        vProveedorNEG.Alta(vNuevoProveedor)
                        MsgBox("El Proveedor ha sido ingresado con éxito.")
                        ContextoNuevaBusqueda()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoProveedor.ModicarProveedor Then
            Dim vNuevoProveedor As New Proveedor
            If TBRazonSocial.Text <> "" And TBCalle.Text <> "" And TBAltura.Text <> "" And TBTelefono.Text <> "" And TBCUIT.Text <> "" And TBEmail.Text <> "" And TBContacto.Text <> "" Then
                vNuevoProveedor.ID = TBID.Text
                vNuevoProveedor.RazonSocial = TBRazonSocial.Text
                vNuevoProveedor.Calle = TBCalle.Text
                vNuevoProveedor.Altura = TBAltura.Text
                vNuevoProveedor.Telefono = TBTelefono.Text
                vNuevoProveedor.CUIT = TBCUIT.Text
                vNuevoProveedor.Email = TBEmail.Text
                vNuevoProveedor.NombreContacto = TBContacto.Text
                Dim vRespuestaValidacion As Boolean = False
                vRespuestaValidacion = Validar()
                If vRespuestaValidacion Then
                    vProveedorNEG.Modificacion(vNuevoProveedor)
                    MsgBox("El proveedor ha sido modificado con éxito.")
                    LimpiarCamposProveedor()
                    ContextoNuevaBusqueda()
                End If
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoProveedor.NuevaBusqueda Or vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ContextoCrearProveedor()
        End If

    End Sub

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim vRespuesta As MsgBoxResult
        vRespuesta = MsgBox("Está a punto de borrar el proveedor. ¿Desea continuar?", MsgBoxStyle.YesNo, "Borrar Proveedor")
        If vRespuesta = MsgBoxResult.Yes Then
            Dim vProveedor As New Proveedor
            vProveedor.ID = DGVProveedor.SelectedRows(0).Cells(0).Value
            vProveedorNEG.Baja(vProveedor)
            MsgBox("El proveedor fue eliminado exitosamente.")
            ContextoNuevaBusqueda()
        End If
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

        If vContexto = ContextoProveedor.NuevaBusqueda Then

            Dim vNuevoProveedor As New Proveedor
            If TBID.Text <> "" Then
                vNuevoProveedor.ID = TBID.Text
            End If
            If TBRazonSocial.Text <> "" Then
                vNuevoProveedor.RazonSocial = TBRazonSocial.Text
            End If
            If TBCalle.Text <> "" Then
                vNuevoProveedor.Calle = TBCalle.Text
            End If
            If TBAltura.Text <> "" Then
                vNuevoProveedor.Altura = TBAltura.Text
            End If
            If TBTelefono.Text <> "" Then
                vNuevoProveedor.Telefono = TBTelefono.Text
            End If
            If TBCUIT.Text <> "" Then
                vNuevoProveedor.CUIT = TBCUIT.Text
            End If
            If TBEmail.Text <> "" Then
                vNuevoProveedor.Email = TBEmail.Text
            End If
            If TBContacto.Text <> "" Then
                vNuevoProveedor.NombreContacto = TBContacto.Text
            End If

            DGVProveedor.DataSource = Nothing
            vListaProveedores = vProveedorNEG.ConsultaVarios(vNuevoProveedor)
            DGVProveedor.DataSource = vListaProveedores

            'ID
            DGVProveedor.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("ID").Width = 50
            'RazonSocial
            DGVProveedor.Columns("RazonSocial").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("RazonSocial").Width = 130
            DGVProveedor.Columns("RazonSocial").HeaderText = "Razón Social"
            'CUIT
            DGVProveedor.Columns("CUIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("CUIT").Width = 85
            'Calle
            DGVProveedor.Columns("Calle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Numero
            DGVProveedor.Columns("Altura").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("Altura").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("Altura").Width = 70
            DGVProveedor.Columns("Altura").HeaderText = "Número"
            'Telefono
            DGVProveedor.Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("Telefono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("Telefono").HeaderText = "Teléfono"
            'Email
            DGVProveedor.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("Email").Width = 140
            'NombreContacto
            DGVProveedor.Columns("NombreContacto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVProveedor.Columns("NombreContacto").Width = 140
            DGVProveedor.Columns("NombreContacto").HeaderText = "Contacto"

            ' Cuando el contexto es crear usuario cancela la carga y vuelve al contexto nueva búsqueda. 
        ElseIf vContexto = ContextoProveedor.CrearProveedor Then
            ContextoNuevaBusqueda()
        ElseIf vContexto = ContextoProveedor.ProveedorSeleccionado Or vContexto = ContextoProveedor.ModicarProveedor Then
            ContextoNuevaBusqueda()
            ContextoNuevaBusqueda()
        End If

    End Sub

    Private Sub BTNModificar_Click(sender As Object, e As EventArgs) Handles BTNModificar.Click

        If vProveedorSeleccionado Is Nothing Then
            MsgBox("Debe seleccionar al proveedor que desea modificar. Haga clic en el botón Nueva Búsqueda.")
        Else
            ContextoModificarProveedor()
        End If

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Ayuda en línea"

    Private Sub TBAltura_MouseHover(sender As Object, e As EventArgs) Handles TBAltura.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBAltura, "Ingrese el Número de calle del domicilio.")
            ToolTip.ToolTipTitle = "Número"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBAltura, "")
            ToolTip.ToolTipTitle = "Número"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBAltura, "Ingrese el Número de calle del domicilio.")
            ToolTip.ToolTipTitle = "Número"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBAltura, "Ingrese el Número de calle del domicilio.")
            ToolTip.ToolTipTitle = "Número"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBCalle_MouseHover(sender As Object, e As EventArgs) Handles TBCalle.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBCalle, "Ingrese la calle del domicilio.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBCalle, "Ingrese la calle del domicilio.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBCalle, "Ingrese la calle del domicilio.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBCalle, "Ingrese la calle del domicilio.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBContacto_MouseHover(sender As Object, e As EventArgs) Handles TBContacto.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBContacto, "Ingrese el contacto del proveedor.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBContacto, "Ingrese el contacto del proveedor.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBContacto, "Ingrese el contacto del proveedor.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBContacto, "Ingrese el contacto del proveedor.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBCUIT_MouseHover(sender As Object, e As EventArgs) Handles TBCUIT.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBCUIT, "Ingrese el CUIT del proveedor a buscar.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBCUIT, "")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBCUIT, "Ingrese el CUIT del proveedor a modificar.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBCUIT, "Ingrese el CUIT del proveedor a crear.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBEmail_MouseHover(sender As Object, e As EventArgs) Handles TBEmail.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBEmail, "Ingrese el Email del proveedor a buscar.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBEmail, "")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBEmail, "Ingrese el Email del proveedor a modificar.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBEmail, "Ingrese el Email del proveedor a crear.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBID_MouseHover(sender As Object, e As EventArgs) Handles TBID.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBID, "Ingrese el ID del proveedor a buscar.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBID, "")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBID, "Ingrese el ID del proveedor a modificar.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBID, "Ingrese el ID del proveedor a crear.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBRazonSocial_MouseHover(sender As Object, e As EventArgs) Handles TBRazonSocial.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese la Razón Social del proveedor a buscar.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBRazonSocial, "")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese la Razón Social del proveedor a modificar.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese la Razón Social del proveedor a crear.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBTelefono_MouseHover(sender As Object, e As EventArgs) Handles TBTelefono.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(TBTelefono, "Ingrese el Teléfono del proveedor a buscar.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(TBTelefono, "")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(TBTelefono, "Ingrese el Teléfono del proveedor a modificar.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBTelefono, "Ingrese el Teléfono del proveedor a crear.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNBuscar_MouseHover(sender As Object, e As EventArgs) Handles BTNBuscar.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para ejecutar la búsqueda.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para ejecutar una nueva búsqueda.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic para cancelar los cambios.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para cancelar.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNCrearProveedor_MouseHover(sender As Object, e As EventArgs) Handles BTNCrearProveedor.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNCrearProveedor, "Haga clic aquí para crear un crear un nuevo proveedor.")
            ToolTip.ToolTipTitle = "Crear Proveedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(BTNCrearProveedor, "Haga clic aquí para crear un crear un nuevo proveedor.")
            ToolTip.ToolTipTitle = "Crear Proveedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(BTNCrearProveedor, "Haga clic aquí para guardar los cambios.")
            ToolTip.ToolTipTitle = "Crear Proveedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNCrearProveedor, "Haga clic aquí para guardar.")
            ToolTip.ToolTipTitle = "Crear Proveedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNEliminar_MouseHover(sender As Object, e As EventArgs) Handles BTNEliminar.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNEliminar, "")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el proveedor seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el proveedor seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNEliminar, "")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNModificar_MouseHover(sender As Object, e As EventArgs) Handles BTNModificar.MouseHover

        If Me.vContexto = ContextoProveedor.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para crear un crear un nuevo proveedor.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ProveedorSeleccionado Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para crear un crear un nuevo proveedor.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoProveedor.ModicarProveedor Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para guardar los cambios.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para guardar.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

#End Region

#End Region

End Class