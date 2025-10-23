Imports BE
Imports BLL_NEGOCIO
Imports SEGURIDAD
Imports INTERFACES
Imports BLL_TECNICA
Imports System.Text.RegularExpressions

Public Class FormCliente

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vContexto As ContextoCliente = ContextoCliente.NuevaBusqueda
    Dim vClienteSeleccionado As Cliente
    Dim vListaClientes As List(Of Cliente)
    Dim vClienteNEG As New Cliente_NEG
    Dim vVendedorActual As Usuario_SEG
    Dim vListaUsuarios As List(Of SEGURIDAD.Usuario_SEG)

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Enum ContextoCliente
        NuevaBusqueda
        ClienteSeleccionado
        ModicarCliente
        CrearCliente
    End Enum

#Region "Click en botones"

    Private Sub BTNCrearCliente_Click(sender As Object, e As EventArgs) Handles BTNCrearCliente.Click

        If vContexto = ContextoCliente.CrearCliente Then
            Dim vNuevoCliente As New Cliente
            If TBRazonSocial.Text <> "" And TBCalle.Text <> "" And TBNumero.Text <> "" And TBTelefono.Text <> "" And TBCUIT.Text <> "" And TBEmail.Text <> "" And TBContacto.Text <> "" And Not vVendedorActual Is Nothing Then
                Try
                    vNuevoCliente.RazonSocial = TBRazonSocial.Text
                    vNuevoCliente.Calle = TBCalle.Text
                    vNuevoCliente.Numero = TBNumero.Text
                    vNuevoCliente.Telefono = TBTelefono.Text
                    vNuevoCliente.CUIT = TBCUIT.Text
                    vNuevoCliente.Email = TBEmail.Text
                    vNuevoCliente.NombreContacto = TBContacto.Text
                    vNuevoCliente.IDVendedor = vVendedorActual.ID
                    Dim vRespuestaValidacion As Boolean = False
                    vRespuestaValidacion = Validar()
                    If vRespuestaValidacion Then
                        vClienteNEG.Alta(vNuevoCliente)
                        MsgBox("El Cliente ha sido ingresado con éxito.")
                        ContextoNuevaBusqueda()
                    End If
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoCliente.ModicarCliente Then
            Dim vNuevoCliente As New Cliente
            If TBRazonSocial.Text <> "" And TBCalle.Text <> "" And TBNumero.Text <> "" And TBTelefono.Text <> "" And TBCUIT.Text <> "" And TBEmail.Text <> "" And TBContacto.Text <> "" And Not vVendedorActual Is Nothing Then
                vNuevoCliente.ID = TBID.Text
                vNuevoCliente.RazonSocial = TBRazonSocial.Text
                vNuevoCliente.Calle = TBCalle.Text
                vNuevoCliente.Numero = TBNumero.Text
                vNuevoCliente.Telefono = TBTelefono.Text
                vNuevoCliente.CUIT = TBCUIT.Text
                vNuevoCliente.Email = TBEmail.Text
                vNuevoCliente.NombreContacto = TBContacto.Text
                vNuevoCliente.IDVendedor = vVendedorActual.ID
                Dim vRespuestaValidacion As Boolean = False
                vRespuestaValidacion = Validar()
                If vRespuestaValidacion Then
                    vClienteNEG.Modificacion(vNuevoCliente)
                    MsgBox("El Cliente ha sido modificado con éxito.")
                    LimpiarCamposCliente()
                    ContextoNuevaBusqueda()
                End If
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoCliente.NuevaBusqueda Or vContexto = ContextoCliente.ClienteSeleccionado Then
            ContextoCrearCliente()
        End If
    End Sub

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim vRespuesta As MsgBoxResult
        vRespuesta = MsgBox("Está a punto de borrar el Cliente. ¿Desea continuar?", MsgBoxStyle.YesNo, "Borrar Cliente")
        If vRespuesta = MsgBoxResult.Yes Then
            Dim vCliente As New Cliente
            vCliente.ID = DGVClientes.SelectedRows(0).Cells(0).Value
            vClienteNEG.Baja(vCliente)
            MsgBox("El Cliente fue eliminado exitosamente.")
            ContextoNuevaBusqueda()
        End If
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

        If vContexto = ContextoCliente.NuevaBusqueda Then

            Dim vNuevoCliente As New Cliente
            If TBID.Text <> "" Then
                vNuevoCliente.ID = TBID.Text
            End If
            If TBRazonSocial.Text <> "" Then
                vNuevoCliente.RazonSocial = TBRazonSocial.Text
            End If
            If TBCUIT.Text <> "" Then
                vNuevoCliente.CUIT = TBCUIT.Text
            End If
            If TBCalle.Text <> "" Then
                vNuevoCliente.Calle = TBCalle.Text
            End If
            If TBNumero.Text <> "" Then
                vNuevoCliente.Numero = TBNumero.Text
            End If
            If TBTelefono.Text <> "" Then
                vNuevoCliente.Telefono = TBTelefono.Text
            End If
            If TBEmail.Text <> "" Then
                vNuevoCliente.Email = TBEmail.Text
            End If
            If TBContacto.Text <> "" Then
                vNuevoCliente.NombreContacto = TBContacto.Text
            End If
            If Not vVendedorActual Is Nothing Then
                vNuevoCliente.IDVendedor = vVendedorActual.ID
            End If
            DGVClientes.DataSource = Nothing
            vListaClientes = vClienteNEG.ConsultaVarios(vNuevoCliente)
            DGVClientes.DataSource = vListaClientes
            DGVClientes.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("ID").Width = 50
            DGVClientes.Columns("RazonSocial").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("RazonSocial").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("RazonSocial").Width = 150
            DGVClientes.Columns("RazonSocial").HeaderText = "Razón Social"
            DGVClientes.Columns("CUIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("CUIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("CUIT").Width = 100
            DGVClientes.Columns("Calle").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Calle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Calle").Width = 130
            DGVClientes.Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Numero").Width = 50
            DGVClientes.Columns("Numero").HeaderText = "Número"
            DGVClientes.Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Telefono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Telefono").Width = 100
            DGVClientes.Columns("Telefono").HeaderText = "Teléfono"
            DGVClientes.Columns("Email").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Email").Width = 140
            DGVClientes.Columns("NombreContacto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("NombreContacto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("NombreContacto").Width = 130
            DGVClientes.Columns("NombreContacto").HeaderText = "Nombre Contacto"
            DGVClientes.Columns("IDVendedor").Visible = False

            ' Cuando el contexto es crear usuario cancela la carga y vuelve al contexto nueva búsqueda. 
        ElseIf vContexto = ContextoCliente.CrearCliente Then
            ContextoNuevaBusqueda()
        ElseIf vContexto = ContextoCliente.ClienteSeleccionado Or vContexto = ContextoCliente.ModicarCliente Then
            ContextoNuevaBusqueda()
        End If

    End Sub

    Private Sub BTNModificar_Click(sender As Object, e As EventArgs) Handles BTNModificar.Click
        ContextoModificarCliente()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Procedimientos"

    ' Limpia los campos del usuario en el formulario.
    Public Sub LimpiarCamposCliente()
        TBID.Text = ""
        TBRazonSocial.Text = ""
        TBCalle.Text = ""
        TBNumero.Text = ""
        TBTelefono.Text = ""
        TBCUIT.Text = ""
        TBEmail.Text = ""
        TBContacto.Text = ""
        CBUsuarios.SelectedItem = Nothing
    End Sub

    ' Habilita los campos del usuario en el formulario.
    Public Sub HabilitarCamposCliente()
        TBID.Enabled = True
        TBRazonSocial.Enabled = True
        TBCalle.Enabled = True
        TBNumero.Enabled = True
        TBTelefono.Enabled = True
        TBCUIT.Enabled = True
        TBEmail.Enabled = True
        TBContacto.Enabled = True
    End Sub

    ' Completa los campos del formulario con los datos del proveedor seleccionado en el DGV.
    Public Sub CompletarCamposCliente()

        TBID.Enabled = False
        TBRazonSocial.Enabled = False
        TBCalle.Enabled = False
        TBNumero.Enabled = False
        TBTelefono.Enabled = False
        TBCUIT.Enabled = False
        TBEmail.Enabled = False
        TBContacto.Enabled = False

        ' Recorre la lista de proveedores según el ID y asigna a la variable vClienteSeleccionado el proveedor coincidente 
        ' con el proveedor seleccionado en DGVClientes.
        SeleccionarCliente()

        TBID.Text = DGVClientes.SelectedRows(0).Cells(0).Value
        TBRazonSocial.Text = DGVClientes.SelectedRows(0).Cells(1).Value
        TBCUIT.Text = DGVClientes.SelectedRows(0).Cells(2).Value
        TBCalle.Text = DGVClientes.SelectedRows(0).Cells(3).Value
        TBNumero.Text = DGVClientes.SelectedRows(0).Cells(4).Value
        TBTelefono.Text = DGVClientes.SelectedRows(0).Cells(5).Value
        TBEmail.Text = DGVClientes.SelectedRows(0).Cells(6).Value
        TBContacto.Text = DGVClientes.SelectedRows(0).Cells(7).Value


        SeleccionarVendedor(CInt(DGVClientes.SelectedRows(0).Cells(8).Value))

    End Sub

    ' Asigna a la varieble vClienteSeleccionado el usuario seleccionado en DGVClientes. 
    Public Sub SeleccionarCliente()
        Dim vID As String = DGVClientes.SelectedRows.Item(0).Cells.Item(0).Value.ToString
        For Each vCliente As Cliente In vListaClientes
            If vCliente.ID = vID Then
                vClienteSeleccionado = vCliente
            End If
        Next
    End Sub

    ' Se ejecuta al elegir un usuario dentro del DGVUsuarios.
    Private Sub DGVCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVClientes.CellClick
        If DGVClientes.SelectedRows IsNot Nothing Then
            ContextoClienteSeleccionado()
        End If
    End Sub

    Private Sub FormClientes_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vUsuarioTEC As New Usuario_TEC
        vContexto = ContextoCliente.NuevaBusqueda
        vVendedorActual = New Usuario_SEG
        Dim vUsuarioSEG As New Usuario_SEG
        vListaUsuarios = vUsuarioTEC.ConsultaVarios(vUsuarioSEG)
        CBUsuarios.DataSource = vListaUsuarios
        CBUsuarios.DisplayMember = "NombreCompleto"
        Actualizar(Me.Idioma)
    End Sub

    Private Sub CBUsuarios_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBUsuarios.SelectedValueChanged
        vVendedorActual = CBUsuarios.SelectedItem
        If vVendedorActual Is Nothing And Not vClienteSeleccionado Is Nothing Then
            SeleccionarVendedor(vClienteSeleccionado.IDVendedor)
        End If
        If Not vClienteSeleccionado Is Nothing Then
            vClienteSeleccionado.IDVendedor = vVendedorActual.ID
        End If
    End Sub

    Public Sub SeleccionarVendedor(ByVal pId As Integer)
        For Each vVendedor As Usuario_SEG In vListaUsuarios
            If vVendedor.ID = pId Then
                vVendedorActual = vVendedor
            End If
        Next
        CBUsuarios.SelectedItem = vVendedorActual
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



#End Region

#Region "Configuracion de contextos"

    Private Sub ContextoNuevaBusqueda()

        ' Cambia la variable del contexto. 
        vContexto = ContextoCliente.NuevaBusqueda

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearCliente.Visible = True
        BTNCrearCliente.Text = "Crear Cliente"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Buscar"

        ' Adapta la variable al nuevo contexto.
        vClienteSeleccionado = Nothing

        LimpiarCamposCliente()
        HabilitarCamposCliente()
        DGVClientes.DataSource = Nothing

    End Sub

    Private Sub ContextoCrearCliente()

        ' Cambia la variable del contexto. 
        vContexto = ContextoCliente.CrearCliente

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearCliente.Visible = True
        BTNCrearCliente.Text = "Guardar"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        ' Adapta la variable al nuevo contexto.
        vClienteSeleccionado = Nothing

        LimpiarCamposCliente()
        HabilitarCamposCliente()
        TBID.Enabled = False

    End Sub

    Private Sub ContextoClienteSeleccionado()

        ' Cambia la variable del contexto. 
        vContexto = ContextoCliente.ClienteSeleccionado

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = True
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = True
        BTNEliminar.Text = "Eliminar"
        BTNCrearCliente.Visible = True
        BTNCrearCliente.Text = "Crear Cliente"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Nueva Búsqueda"

        ' Adapta la variable al nuevo contexto.
        SeleccionarCliente()

        LimpiarCamposCliente()
        CompletarCamposCliente()

    End Sub

    Private Sub ContextoModificarCliente()

        ' Cambia la variable del contexto. 
        vContexto = ContextoCliente.ModicarCliente
        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearCliente.Visible = True
        BTNCrearCliente.Text = "Guardar Cambios"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        HabilitarCamposCliente()
        TBID.Enabled = False

    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormCliente")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormCliente").MensajeTraducido
        Me.lbUsuario.Text = vDiccionario("lbUsuario").MensajeTraducido
        Me.lbRazonSocial.Text = vDiccionario("lbRazonSocial").MensajeTraducido
        Me.LbCalle.Text = vDiccionario("LbCalle").MensajeTraducido
        Me.LbNumero.Text = vDiccionario("LbNumero").MensajeTraducido
        Me.LbTelefono.Text = vDiccionario("LbTelefono").MensajeTraducido
        Me.LbContacto.Text = vDiccionario("LbContacto").MensajeTraducido
        Me.BTNCrearCliente.Text = vDiccionario("BTNCrearCliente").MensajeTraducido
        Me.BTNBuscar.Text = vDiccionario("BTNBuscar").MensajeTraducido
        Me.BTNModificar.Text = vDiccionario("BTNModificar").MensajeTraducido
        Me.BTNEliminar.Text = vDiccionario("BTNEliminar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido
        Me.GBResultados.Text = vDiccionario("GBResultados").MensajeTraducido

    End Sub

#End Region

    Private Sub CBUsuarios_MouseHover(sender As Object, e As EventArgs) Handles CBUsuarios.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(CBUsuarios, "Seleccione al vendedor asociado al cliente a buscar.")
            ToolTip.ToolTipTitle = "Vendedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(CBUsuarios, "Seleccione el vendedor.")
            ToolTip.ToolTipTitle = "Vendedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(CBUsuarios, "Seleccione el vendedor a asociar.")
            ToolTip.ToolTipTitle = "Vendedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(CBUsuarios, "Seleccione el vendedor a asociar.")
            ToolTip.ToolTipTitle = "Vendedor"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBCalle_MouseHover(sender As Object, e As EventArgs) Handles TBCalle.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBCalle, "Ingrese aquí la calle del cliente a buscar.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBCalle, "No es posible modificar calle del cliente desde el contexto actual. Para modificarla haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBCalle, "Ingrese aquí la calle del cliente a modificar.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBCalle, "Ingrese aquí la calle del cliente del usuario a crear.")
            ToolTip.ToolTipTitle = "Calle"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBContacto_MouseHover(sender As Object, e As EventArgs) Handles TBContacto.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBContacto, "Ingrese aquí el contacto del cliente a buscar.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBContacto, "No es posible modificar el contacto del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBContacto, "Ingrese aquí el contacto del cliente a modificar.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBContacto, "Ingrese aquí el contacto del cliente a crear.")
            ToolTip.ToolTipTitle = "Contacto"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBCUIT_MouseHover(sender As Object, e As EventArgs) Handles TBCUIT.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBCUIT, "Ingrese aquí el CUIT del cliente a buscar.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBCUIT, "No es posible modificar el CUIT del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBCUIT, "Ingrese aquí el CUIT del cliente a modificar.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBCUIT, "Ingrese aquí el CUIT del cliente a crear.")
            ToolTip.ToolTipTitle = "CUIT"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBEmail_MouseHover(sender As Object, e As EventArgs) Handles TBEmail.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBEmail, "Ingrese aquí el Email del cliente a buscar.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBEmail, "No es posible modificar el Email del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBEmail, "Ingrese aquí el Email del cliente a modificar.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBEmail, "Ingrese aquí el Email del cliente a crear.")
            ToolTip.ToolTipTitle = "Email"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBID_MouseHover(sender As Object, e As EventArgs) Handles TBID.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBID, "Ingrese aquí el ID del cliente a buscar.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBID, "No es posible modificar el ID del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBID, "Ingrese aquí el ID del cliente a modificar.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBID, "Ingrese aquí el ID del cliente a crear.")
            ToolTip.ToolTipTitle = "ID"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBNumero_MouseHover(sender As Object, e As EventArgs) Handles TBNumero.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBNumero, "Ingrese aquí el número de la calle a buscar.")
            ToolTip.ToolTipTitle = "Numero"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBNumero, "No es posible modificar el número de la calle desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Numero"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBNumero, "Ingrese aquí el número de la calle a modificar.")
            ToolTip.ToolTipTitle = "Numero"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBNumero, "Ingrese aquí el número de la calle a crear.")
            ToolTip.ToolTipTitle = "Numero"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBRazonSocial_MouseHover(sender As Object, e As EventArgs) Handles TBRazonSocial.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese aquí la Razón Social del cliente a buscar.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBRazonSocial, "No es posible modificar la Razón Social del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese aquí la Razón Social del cliente a modificar.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBRazonSocial, "Ingrese aquí la Razón Social del cliente a crear.")
            ToolTip.ToolTipTitle = "Razón Social"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBTelefono_MouseHover(sender As Object, e As EventArgs) Handles TBTelefono.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(TBTelefono, "Ingrese aquí el Teléfono del cliente a buscar.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(TBTelefono, "No es posible modificar el Teléfono del cliente desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(TBTelefono, "Ingrese aquí el Teléfono del cliente a modificar.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBTelefono, "Ingrese aquí el Teléfono del cliente a crear.")
            ToolTip.ToolTipTitle = "Teléfono"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNCrearCliente_MouseHover(sender As Object, e As EventArgs) Handles BTNCrearCliente.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNCrearCliente, "Haga clic aquí para crear un nuevo cliente.")
            ToolTip.ToolTipTitle = "Crear Cliente"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(BTNCrearCliente, "Haga clic aquí para crear un nuevo cliente.")
            ToolTip.ToolTipTitle = "Crear Cliente"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(BTNCrearCliente, "Haga clic aquí para guardar los cambios.")
            ToolTip.ToolTipTitle = "Crear Cliente"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNCrearCliente, "Haga clic aquí para crear un nuevo cliente.")
            ToolTip.ToolTipTitle = "Crear Cliente"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNBuscar_MouseHover(sender As Object, e As EventArgs) Handles BTNBuscar.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNBuscar, "Presione aquí para ejecutar la búsqueda.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(BTNBuscar, "Presione aquí para iniciar una nueva búsqueda.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(BTNBuscar, "Presione aquí para cancelar. Los cambios no serán guardado.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNBuscar, "Presione aquí para cancelar. El nuevo cliente no será guardado.")
            ToolTip.ToolTipTitle = "Buscar"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        End If

    End Sub

    Private Sub BTNEliminar_MouseHover(sender As Object, e As EventArgs) Handles BTNEliminar.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el cliente.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el cliente.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el cliente.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el cliente.")
            ToolTip.ToolTipTitle = "Eliminar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNModificar_MouseHover(sender As Object, e As EventArgs) Handles BTNModificar.MouseHover

        If Me.vContexto = ContextoCliente.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para modificar el cliente.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ClienteSeleccionado Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para modificar el cliente.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoCliente.ModicarCliente Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para modificar el cliente.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para modificar el cliente.")
            ToolTip.ToolTipTitle = "Modificar"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

End Class