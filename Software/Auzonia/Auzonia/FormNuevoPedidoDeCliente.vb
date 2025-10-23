Imports BE
Imports SEGURIDAD
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormNuevoPedidoDeCliente

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)

    Dim vListaDeVendedores As List(Of Usuario_SEG)
    Dim vVendedorSeleccionado As Usuario_SEG
    Dim vVendedorTEC As Usuario_TEC

    Dim vDictionaryClientes As New Dictionary(Of Integer, Cliente)
    Dim vListaDeClientes As List(Of Cliente)
    Dim vClienteSeleccionado As Cliente
    Dim vClienteNEG As Cliente_NEG

    Dim vPedidoDeCliente As PedidoDeCliente

    Dim vListaArticulos As New List(Of ArticuloPedidoDeCliente)

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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevoPedidoDeCliente")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormNuevoPedidoDeCliente").MensajeTraducido
        Me.lbVendedor.Text = vDiccionario("lbVendedor").MensajeTraducido
        Me.GBClientes.Text = vDiccionario("GBClientes").MensajeTraducido
        Me.GBDetallePedido.Text = vDiccionario("GBDetallePedido").MensajeTraducido
        Me.lbIDCliente.Text = vDiccionario("lbIDCliente").MensajeTraducido
        Me.lbRazonSocial.Text = vDiccionario("lbRazonSocial").MensajeTraducido
        Me.lbFechaDeEntrega.Text = vDiccionario("lbFechaDeEntrega").MensajeTraducido
        Me.GBComentarios.Text = vDiccionario("GBComentarios").MensajeTraducido
        Me.BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

    Private Sub SeleccionarVendedor()

        'Actualiza la variables del vendedor actual.
        vVendedorSeleccionado = CBVendedor.SelectedItem

        'Actualiza los clientes del vendedor seleccionado.
        Dim vClienteNEG As New Cliente_NEG
        Dim vCliente As New Cliente
        vCliente.IDVendedor = vVendedorSeleccionado.ID
        vListaDeClientes = vClienteNEG.ConsultaVarios(vCliente)
        DGVClientes.DataSource = vListaDeClientes
        DGVClientes.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("ID").Width = 50
        DGVClientes.Columns("RazonSocial").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("RazonSocial").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("RazonSocial").HeaderText = "Razón Social"
        DGVClientes.Columns("RazonSocial").Width = 115
        DGVClientes.Columns("CUIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("CUIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Calle").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Calle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Numero").HeaderText = "Número"
        DGVClientes.Columns("Numero").Width = 50
        DGVClientes.Columns("Telefono").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Telefono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Telefono").HeaderText = "Teléfono"
        DGVClientes.Columns("Email").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("Email").Width = 127
        DGVClientes.Columns("NombreContacto").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("NombreContacto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVClientes.Columns("NombreContacto").HeaderText = "Nombre Contacto"
        DGVClientes.Columns("NombreContacto").Width = 125
        DGVClientes.Columns("IDVendedor").Visible = False

        'Carla el diccionario de clientes.
        vDictionaryClientes.Clear()
        For Each vC As Cliente In vListaDeClientes
            vDictionaryClientes.Add(vC.ID, vC)
        Next

        SeleccionarCliente()

    End Sub

    Private Sub SeleccionarCliente()
        If DGVClientes.SelectedRows.Count > 0 Then
            vClienteSeleccionado = vDictionaryClientes(CInt(DGVClientes.SelectedRows(0).Cells(0).Value))
            TBIDCliente.Text = vClienteSeleccionado.ID
            TBRazonSocial.Text = vClienteSeleccionado.RazonSocial
            TBComentarios.Text = ""
            DTPFechaDeEntrega.Visible = True
            ActualizarListaDeArticulos()
        End If
    End Sub

    Private Sub ActualizarListaDeArticulos()
        Dim vArticuloNEG As New Articulo_NEG
        Dim vArticuloPedidoDeCliente As New ArticuloPedidoDeCliente
        vListaArticulos = vArticuloNEG.ConsultaVarios(vArticuloPedidoDeCliente)
        DGVDetallePedido.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        DGVDetallePedido.DataSource = Nothing
        DGVDetallePedido.DataSource = vListaArticulos
        DGVDetallePedido.Columns("Codigo").DisplayIndex = 0
        DGVDetallePedido.Columns("Codigo").Width = 140
        DGVDetallePedido.Columns("Codigo").HeaderText = "Código"
        DGVDetallePedido.Columns("Codigo").ReadOnly = True
        DGVDetallePedido.Columns("Descripcion").DisplayIndex = 1
        DGVDetallePedido.Columns("Descripcion").Width = 520
        DGVDetallePedido.Columns("Descripcion").HeaderText = "Descripción"
        DGVDetallePedido.Columns("Descripcion").ReadOnly = True
        DGVDetallePedido.Columns("Solicitadas").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
        DGVDetallePedido.Columns("Solicitadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVDetallePedido.Columns("Solicitadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVDetallePedido.Columns("Solicitadas").Width = 90
        DGVDetallePedido.Columns("Reservadas").Visible = False
        DGVDetallePedido.Columns("Pendientes").Visible = False
        DGVDetallePedido.Columns("Enviar").Visible = False
        DGVDetallePedido.Columns("IDProveedor").Visible = False
        DGVDetallePedido.Columns("ID").Visible = False
    End Sub


#End Region

#Region "Eventos"

    Private Sub FormNuevoPedidoDeCliente_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        vVendedorTEC = New Usuario_TEC
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
        ActualizarListaDeArticulos()
        Actualizar(Me.Idioma)
    End Sub

    Private Sub CBVendedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBVendedor.SelectedValueChanged
        SeleccionarVendedor()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub DGVClientes_MouseClick(sender As Object, e As MouseEventArgs) Handles DGVClientes.MouseClick
        SeleccionarCliente()
    End Sub

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click
        vPedidoDeCliente = New PedidoDeCliente
        vPedidoDeCliente.Cliente = vClienteSeleccionado
        vPedidoDeCliente.Comentarios = TBComentarios.Text & Environment.NewLine & "Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & Environment.NewLine
        vPedidoDeCliente.FechaDeEntrega = DTPFechaDeEntrega.Value
        Dim vListaDeArticulosAsignar As New List(Of ArticuloPedidoDeCliente)
        For Each vArticulo As ArticuloPedidoDeCliente In vListaArticulos
            If vArticulo.Solicitadas > 0 Then
                vListaDeArticulosAsignar.Add(vArticulo)
            End If
        Next
        vPedidoDeCliente.ListaDeArticulos = vListaDeArticulosAsignar
        Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG
        If vPedidoDeCliente.ListaDeArticulos.Count > 0 Then
            vPedidoDeClienteNEG.Alta(vPedidoDeCliente)
            MsgBox("El pedido ha sido ingresado con éxito.")
            ActualizarListaDeArticulos()
            Me.Close()
        Else
            MsgBox("Ingrese las cantidades a pedir.")
        End If

    End Sub

#Region "solo numeros"

    Private Sub DGVDetallePedido_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVDetallePedido.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error.")
        End If
    End Sub

    Private Sub DGVDetallePedido_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVDetallePedido.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            ' obtener indice de la columna 
            Dim columna As Integer = DGVDetallePedido.CurrentCell.ColumnIndex
            ' comprobar si la celda en edición corresponde a la columna 1 o 3 
            If columna = 0 Or columna = 1 Then
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

#Region "Ayuda en línea"

    Private Sub CBVendedor_MouseHover(sender As Object, e As EventArgs) Handles CBVendedor.MouseHover

        ToolTip.SetToolTip(CBVendedor, "Seleccione el vendedor a asociar.")
        ToolTip.ToolTipTitle = "Vendedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNAceptar_MouseHover(sender As Object, e As EventArgs) Handles BTNAceptar.MouseHover

        ToolTip.SetToolTip(BTNAceptar, "Haga clic aquí para confirmar la creación del nuevo pedido de cliente.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region

End Class