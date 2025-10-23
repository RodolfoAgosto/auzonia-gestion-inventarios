Imports BE
Imports SEGURIDAD
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormPedidoDeCliente

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim WithEvents vFormNuevoPedidoDeCliente As FormNuevoPedidoDeCliente

    'Vendedor
    Dim vListaDeVendedores As List(Of Usuario_SEG)
    Dim vVendedorSeleccionado As Usuario_SEG
    Dim vVendedorTEC As New Usuario_TEC

    'Cliente
    Dim vDictionaryClientes As New Dictionary(Of Integer, Cliente)
    Dim vListaDeClientes As List(Of Cliente)
    Dim vClienteSeleccionado As Cliente
    Dim vClienteNEG As New Cliente_NEG

    'Pedido de Cliene
    Dim vDictionaryPedidoDeCliente As New Dictionary(Of Integer, PedidoDeCliente)
    Dim vListaDePedidoDeCliente As List(Of PedidoDeCliente)
    Dim vPedidoDeClienteSeleccionado As PedidoDeCliente
    Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG

    'Articulos
    Dim vDictionaryArticuloDePedidoDeCliente As New Dictionary(Of Integer, ArticuloPedidoDeCliente)
    Dim vListaArticulos As List(Of ArticuloPedidoDeCliente)
    Dim vArticulo_NEG As New Articulo_NEG

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

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormPedidoDeCliente")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormPedidoDeCliente").MensajeTraducido
        Me.lbVendedor.Text = vDiccionario("lbVendedor").MensajeTraducido
        Me.GBClientes.Text = vDiccionario("GBClientes").MensajeTraducido
        Me.GBPedidos.Text = vDiccionario("GBPedidos").MensajeTraducido
        Me.GPDetallePedido.Text = vDiccionario("GPDetallePedido").MensajeTraducido
        Me.lbIDCliente.Text = vDiccionario("lbIDCliente").MensajeTraducido
        Me.lbRazonSocial.Text = vDiccionario("lbRazonSocial").MensajeTraducido
        Me.lbFechaDeEntrega.Text = vDiccionario("lbFechaDeEntrega").MensajeTraducido
        Me.GBComentarios.Text = vDiccionario("GBComentarios").MensajeTraducido
        Me.BTNCancelarPedidoDeCliente.Text = vDiccionario("BTNCancelarPedidoDeCliente").MensajeTraducido
        Me.BTNGuardarCambios.Text = vDiccionario("BTNGuardarCambios").MensajeTraducido
        Me.BTNGenerarPedido.Text = vDiccionario("BTNGenerarPedido").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido
        Idioma = pIdioma
        If Not vFormNuevoPedidoDeCliente Is Nothing Then
            vFormNuevoPedidoDeCliente.Idioma = Idioma
            vFormNuevoPedidoDeCliente.Actualizar(pIdioma)
        End If

    End Sub

    'Asigna el vendedor seleccionado a la variable vVendedorSeleccionado.
    Private Sub SeleccionarVendedor()

        'Actualiza la variables del vendedor actual.
        vVendedorSeleccionado = CBVendedor.SelectedItem
        ActualizarClientes()

    End Sub

    'Actualiza el DGVClientes con los clientes del vendedor seleccionado.
    'Completa el vDictionaryClientes.
    Private Sub ActualizarClientes()
        'Actualiza el DGVClientes con los clientes del vendedor seleccionado.
        Dim vCliente As New Cliente
        If Not vVendedorSeleccionado Is Nothing Then
            vCliente.IDVendedor = vVendedorSeleccionado.ID
            vListaDeClientes = vClienteNEG.ConsultaVarios(vCliente)
            vDictionaryClientes.Clear()
            For Each vC As Cliente In vListaDeClientes
                vDictionaryClientes.Add(vC.ID, vC)
            Next
            DGVClientes.DataSource = Nothing
            'La siguiente instrucción dispara el evento DGVClientes_SelectionChanged que llama a al procedimiento SeleccionarCliente().
            DGVClientes.DataSource = vListaDeClientes
            DGVClientes.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("ID").Width = 50
            DGVClientes.Columns("RazonSocial").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("RazonSocial").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("RazonSocial").Width = 150
            DGVClientes.Columns("RazonSocial").HeaderText = "Razón Social"
            DGVClientes.Columns("CUIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Calle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Numero").HeaderText = "Número"
            DGVClientes.Columns("Numero").Width = 80
            DGVClientes.Columns("Telefono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Telefono").HeaderText = "Teléfono"
            DGVClientes.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Email").Width = 150
            DGVClientes.Columns("NombreContacto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("NombreContacto").HeaderText = "Nombre Contacto"
            DGVClientes.Columns("NombreContacto").Width = 150
            DGVClientes.Columns("IDVendedor").Visible = False

        End If
    End Sub

    'Asigna el cliente seleccionado a la variable vClienteSeleccionado.
    Private Sub SeleccionarCliente()
        If DGVClientes.SelectedRows.Count > 0 Then
            If vDictionaryClientes.Count > 0 Then
                vClienteSeleccionado = vDictionaryClientes(CInt(DGVClientes.SelectedRows(0).Cells(0).Value))
                TBIDCliente.Text = vClienteSeleccionado.ID
                TBRazonSocial.Text = vClienteSeleccionado.RazonSocial
                TBComentarios.Text = ""
                ActualizarListaDePedidosDeCliente()
            End If
        End If
    End Sub

    'Actualiza el DGVPedidoDeCliente con los pedidos del cliente seleccionado.
    'Completa el vDictionaryPedidoDeCliente.
    Private Sub ActualizarListaDePedidosDeCliente()
        Dim vPedidoDeCliente As New PedidoDeCliente()
        vPedidoDeCliente.Cliente = vClienteSeleccionado
        vListaDePedidoDeCliente = vPedidoDeClienteNEG.ConsultaVarios(vPedidoDeCliente)
        'Carga el diccionario de clientes.
        vDictionaryPedidoDeCliente.Clear()
        For Each vPC As PedidoDeCliente In vListaDePedidoDeCliente
            vDictionaryPedidoDeCliente.Add(vPC.ID, vPC)
        Next
        DGVPedidoDeCliente.DataSource = Nothing
        DGVPedidoDeCliente.DataSource = vListaDePedidoDeCliente
        DGVPedidoDeCliente.Columns(0).Width = 42
        DGVPedidoDeCliente.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVPedidoDeCliente.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeCreacion").Width = 100
        DGVPedidoDeCliente.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVPedidoDeCliente.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeEntrega").Width = 100
        DGVPedidoDeCliente.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("Estado").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns(5).Width = 85
        DGVPedidoDeCliente.Columns(1).Visible = False
        DGVPedidoDeCliente.Columns(4).Visible = False

        SeleccionarPedidoDeCliente()

    End Sub

    'Asigna el pedido seleccionado a la variable vPedidoDeClienteSeleccionado.
    Private Sub SeleccionarPedidoDeCliente()
        If DGVPedidoDeCliente.SelectedRows.Count > 0 Then
            vPedidoDeClienteSeleccionado = vDictionaryPedidoDeCliente(CInt(DGVPedidoDeCliente.SelectedRows(0).Cells(0).Value))
            DTPFechaDeEntrega.Value = vPedidoDeClienteSeleccionado.FechaDeEntrega
            TBComentarios.Text = vPedidoDeClienteSeleccionado.Comentarios
        Else
            vPedidoDeClienteSeleccionado = Nothing
            DTPFechaDeEntrega.Value = Now
        End If
        ActualizarListaDeArticulos()
    End Sub

    'Actualiza el DGVArticuloPedidoDeCliente con los artículos del pedido seleccionado.
    'Completa el vDictionaryArticuloPedidoDeCliente.
    Private Sub ActualizarListaDeArticulos()

        If vPedidoDeClienteSeleccionado IsNot Nothing Then
            DGVArticuloPedidoDeCliente.DataSource = Nothing
            vPedidoDeClienteNEG.Consulta(vPedidoDeClienteSeleccionado)
            'Carga el diccionario de articulos.
            vDictionaryArticuloDePedidoDeCliente.Clear()
            For Each vAPC As ArticuloPedidoDeCliente In vPedidoDeClienteSeleccionado.ListaDeArticulos
                vDictionaryArticuloDePedidoDeCliente.Add(vAPC.ID, vAPC)
            Next

            DGVArticuloPedidoDeCliente.DataSource = vPedidoDeClienteSeleccionado.ListaDeArticulos

            DGVArticuloPedidoDeCliente.Columns("ID").DisplayIndex = 0
            DGVArticuloPedidoDeCliente.Columns("ID").Width = 60
            DGVArticuloPedidoDeCliente.Columns("ID").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVArticuloPedidoDeCliente.Columns("Codigo").DisplayIndex = 1
            DGVArticuloPedidoDeCliente.Columns("Codigo").Width = 224
            DGVArticuloPedidoDeCliente.Columns("Codigo").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("Codigo").HeaderText = "Código"


            DGVArticuloPedidoDeCliente.Columns("Descripcion").DisplayIndex = 2
            DGVArticuloPedidoDeCliente.Columns("Descripcion").Width = 397
            DGVArticuloPedidoDeCliente.Columns("Descripcion").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("Descripcion").HeaderText = "Descripción"

            DGVArticuloPedidoDeCliente.Columns("Solicitadas").DisplayIndex = 3
            DGVArticuloPedidoDeCliente.Columns("Solicitadas").Width = 70
            DGVArticuloPedidoDeCliente.Columns("Solicitadas").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("Solicitadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVArticuloPedidoDeCliente.Columns("Reservadas").DisplayIndex = 4
            DGVArticuloPedidoDeCliente.Columns("Reservadas").Width = 70
            DGVArticuloPedidoDeCliente.Columns("Reservadas").ReadOnly = False
            DGVArticuloPedidoDeCliente.Columns("Reservadas").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
            DGVArticuloPedidoDeCliente.Columns("Reservadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVArticuloPedidoDeCliente.Columns("Pendientes").DisplayIndex = 5
            DGVArticuloPedidoDeCliente.Columns("Pendientes").Width = 70
            DGVArticuloPedidoDeCliente.Columns("Pendientes").ReadOnly = False
            DGVArticuloPedidoDeCliente.Columns("Pendientes").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
            DGVArticuloPedidoDeCliente.Columns("Pendientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVArticuloPedidoDeCliente.Columns("Enviar").DisplayIndex = 6
            DGVArticuloPedidoDeCliente.Columns("Enviar").Width = 70
            DGVArticuloPedidoDeCliente.Columns("Enviar").Visible = False
            DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVArticuloPedidoDeCliente.Columns("IDProveedor").Visible = False
        Else
            DGVArticuloPedidoDeCliente.DataSource = New List(Of ArticuloPedidoDeCliente)
        End If

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormPedidoDeCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vUsuarioGenerico As New Usuario_SEG
        Dim vListaDeUsuarios As New List(Of Usuario_SEG)
        vListaDeUsuarios = vVendedorTEC.ConsultaVarios(vUsuarioGenerico)
        vListaDeVendedores = New List(Of Usuario_SEG)
        For Each iUsuario As Usuario_SEG In vListaDeUsuarios
            Dim vEsValido As Boolean = False
            For Each iPermiso As Permiso_SEG In iUsuario.Permisos
                If Not vEsValido Then
                    vEsValido = iPermiso.EsValido("Vendedor")
                End If
            Next
            If vEsValido Then
                vListaDeVendedores.Add(iUsuario)
            End If
        Next

        CBVendedor.DataSource = vListaDeVendedores
        CBVendedor.DisplayMember = "NombreCompleto"
        'Actualiza la variable del vendedor actual y la lista de clientes asociados al mismo.
        SeleccionarVendedor()
        Actualizar(Me.Idioma)
        DGVClientes.ReadOnly = True
        DGVPedidoDeCliente.ReadOnly = True

    End Sub

    Private Sub BTNGenerarPedido_Click(sender As Object, e As EventArgs) Handles BTNGenerarPedido.Click
        If vFormNuevoPedidoDeCliente Is Nothing Then
            vFormNuevoPedidoDeCliente = New FormNuevoPedidoDeCliente
            vFormNuevoPedidoDeCliente.MdiParent = Me.MdiParent
        End If
        vFormNuevoPedidoDeCliente.Idioma = Me.Idioma
        vFormNuevoPedidoDeCliente.Actualizar(Me.Idioma)
        vFormNuevoPedidoDeCliente.Show()
    End Sub

    'Ocurre cuando se cambia el vendedor seleccionado.
    Private Sub CBVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBVendedor.SelectedValueChanged
        TBIDCliente.Text = ""
        TBRazonSocial.Text = ""
        DTPFechaDeEntrega.Value = Now
        TBComentarios.Text = ""
        SeleccionarVendedor()
    End Sub

    Private Sub DGVClientes_SelectionChanged(sender As Object, e As EventArgs) Handles DGVClientes.SelectionChanged
        SeleccionarCliente()
    End Sub

    Private Sub DGVPedidoDeCliente_SelectionChanged(sender As Object, e As EventArgs) Handles DGVPedidoDeCliente.SelectionChanged
        SeleccionarPedidoDeCliente()
    End Sub

    Private Sub BTNGuardarCambios_Click(sender As Object, e As EventArgs) Handles BTNGuardarCambios.Click

        vPedidoDeClienteSeleccionado.Comentarios = ""
        vPedidoDeClienteSeleccionado.Comentarios = TBComentarios.Text & Environment.NewLine & TBNuevoComentario.Text _
        & Environment.NewLine & "Usuario: " & Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & Environment.NewLine

        For Each vFila As DataGridViewRow In DGVArticuloPedidoDeCliente.Rows
            Dim vArticuloPedidoDeCliente As ArticuloPedidoDeCliente = vDictionaryArticuloDePedidoDeCliente(CInt(vFila.Cells(4).Value))
            vArticuloPedidoDeCliente.Reservadas = vFila.Cells("Reservadas").Value
            vArticuloPedidoDeCliente.Pendientes = vFila.Cells("Pendientes").Value
        Next
        vPedidoDeClienteSeleccionado.FechaDeEntrega = DTPFechaDeEntrega.Value
        vPedidoDeClienteNEG.Modificacion(vPedidoDeClienteSeleccionado)
        MsgBox("El pedido ha sido modificado.")
        TBComentarios.Text = vPedidoDeClienteSeleccionado.Comentarios
        TBNuevoComentario.Text = ""
    End Sub

    Private Sub BTNCancelarPedidoDeCliente_Click(sender As Object, e As EventArgs) Handles BTNCancelarPedidoDeCliente.Click
        vPedidoDeClienteSeleccionado.Comentarios = ""
        vPedidoDeClienteSeleccionado.Comentarios = TBComentarios.Text & Environment.NewLine & "Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & Environment.NewLine
        For Each vFila As DataRow In DGVArticuloPedidoDeCliente.Rows
            Dim vArticuloPedidoDeCliente As ArticuloPedidoDeCliente = vDictionaryArticuloDePedidoDeCliente(vFila.Item(0))
            vArticuloPedidoDeCliente.Reservadas = 0
            vArticuloPedidoDeCliente.Pendientes = 0
        Next
        vPedidoDeClienteSeleccionado.FechaDeEntrega = DTPFechaDeEntrega.Value
        vPedidoDeClienteSeleccionado.Estado = "Cancelado"
        vPedidoDeClienteNEG.Modificacion(vPedidoDeClienteSeleccionado)
        MsgBox("El pedido ha sido cancelado.")

    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloPedidoDeCliente_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVArticuloPedidoDeCliente.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub DGVArticuloPedidoDeCliente_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloPedidoDeCliente.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            ' obtener indice de la columna 
            Dim columna As Integer = DGVArticuloPedidoDeCliente.CurrentCell.ColumnIndex
            ' comprobar si la celda en edición corresponde a la columna 1 o 3 
            If columna = 2 Or columna = 1 Then
                ' Obtener caracter 
                Dim caracter As Char = e.KeyChar
                ' comprobar si el caracter es un número o el retroceso 
                If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                    'Me.Text = e.KeyChar 
                    e.KeyChar = Chr(0)
                End If
            End If
        Catch ex As Exception
            MsgBox("El valor no puede ser nulo.")
        End Try

    End Sub

#End Region

    Private Sub FormPedidoDeCliente_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If Not vFormNuevoPedidoDeCliente Is Nothing Then
            vFormNuevoPedidoDeCliente.Close()
        End If
    End Sub

    Private Sub vFormNuevoPedidosDeCliente_Closed(sender As Object, e As EventArgs) Handles vFormNuevoPedidoDeCliente.FormClosed
        vFormNuevoPedidoDeCliente = Nothing
        SeleccionarCliente()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Ayuda en línea"

    Private Sub BTNCancelarPedidoDeCliente_MouseHover(sender As Object, e As EventArgs) Handles BTNCancelarPedidoDeCliente.MouseHover
        ToolTip.SetToolTip(BTNCancelarPedidoDeCliente, "Haga clic aquí para cancelar el pedido.")
        ToolTip.ToolTipTitle = "Cancelar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNGenerarPedido_MouseHover(sender As Object, e As EventArgs) Handles BTNGenerarPedido.MouseHover
        ToolTip.SetToolTip(BTNGenerarPedido, "Haga clic aquí para generar el pedido.")
        ToolTip.ToolTipTitle = "Generar Pedido"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNGuardarCambios_MouseHover(sender As Object, e As EventArgs) Handles BTNGuardarCambios.MouseHover
        ToolTip.SetToolTip(BTNGuardarCambios, "Haga clic aquí para guardar los cambios.")
        ToolTip.ToolTipTitle = "Guardar Cambios"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub CBVendedor_MouseHover(sender As Object, e As EventArgs) Handles CBVendedor.MouseHover
        ToolTip.SetToolTip(CBVendedor, "Seleccione el vendedor.")
        ToolTip.ToolTipTitle = "Vendedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

End Class