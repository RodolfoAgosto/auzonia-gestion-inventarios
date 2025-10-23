Imports BE
Imports BLL_NEGOCIO
Imports INTERFACES
Imports BLL_TECNICA

Public Class FormNotaDePedido

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim WithEvents vFormNuevaNotaDePedido As FormNuevaNotaDePedido
    ' Permite actualizar el ComboBox de los proveedores.
    Dim vDictionaryProveedor As New Dictionary(Of Integer, Proveedor)
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG
    Dim vDictionaryArticuloNotaDePedido As New Dictionary(Of Integer, ArticuloNotaDePedido)
    Dim vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido)
    Dim vArticuloNotaDePedidoActual As ArticuloNotaDePedido
    Dim vArticuloNEG As New Articulo_NEG
    Dim vDictionaryNotaDePedido As New Dictionary(Of Integer, NotaDePedido)
    Dim vListaNotaDePedido As List(Of NotaDePedido)
    Dim vNotaDePedidoActual As NotaDePedido
    Dim vNotaDePedidoNEG As New NotaDePedido_NEG

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

    Private Sub ActualizarNotasDePedido()
        Dim vNotaDePedidoDeBusqueda As New NotaDePedido
        vNotaDePedidoDeBusqueda.Proveedor = vProveedorActual
        vListaNotaDePedido = vNotaDePedidoNEG.ConsultaVarios(vNotaDePedidoDeBusqueda)
        For Each vNotaDePedido As NotaDePedido In vListaNotaDePedido
            vNotaDePedidoNEG.Consulta(vNotaDePedido)
        Next
        DGVNotasDePedido.DataSource = Nothing
        If Not vListaNotaDePedido Is Nothing Then
            DGVNotasDePedido.DataSource = vListaNotaDePedido
            DGVNotasDePedido.Columns("ID").HeaderText = "ID"
            DGVNotasDePedido.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVNotasDePedido.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVNotasDePedido.Columns("Proveedor").Visible = False
            DGVNotasDePedido.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
            DGVNotasDePedido.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVNotasDePedido.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVNotasDePedido.Columns("FechaDeCreacion").Width = 129
            DGVNotasDePedido.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVNotasDePedido.Columns("Estado").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        'Carga el diccionario de clientes.
        vDictionaryNotaDePedido.Clear()
        For Each vNdP As NotaDePedido In vListaNotaDePedido
            vDictionaryNotaDePedido.Add(vNdP.ID, vNdP)
        Next
        SeleccionarNotaDePedido()
    End Sub

    Public Sub SeleccionarNotaDePedido()
        If DGVNotasDePedido.SelectedRows.Count > 0 Then
            If vDictionaryNotaDePedido.ContainsKey(CInt(DGVNotasDePedido.SelectedRows(0).Cells(0).Value)) Then
                If DGVNotasDePedido.SelectedRows.Count > 0 Then
                    vNotaDePedidoActual = vDictionaryNotaDePedido(CInt(DGVNotasDePedido.SelectedRows(0).Cells(0).Value))
                    TBIDNotaDePedido.Text = vNotaDePedidoActual.ID
                    TBRazonSocial.Text = vNotaDePedidoActual.Proveedor.RazonSocial
                    DTPFechaDeEntrega.Value = vNotaDePedidoActual.FechaDeCreacion
                    ActualizarListaDeArticulosNotaDePedido()
                End If
            End If
        End If
    End Sub

    Private Sub ActualizarListaDeArticulosNotaDePedido()
        vListaArticuloNotaDePedido = vNotaDePedidoActual.ListaDeArticulos
        If Not vListaArticuloNotaDePedido Is Nothing Then
            DGVArticuloNotaDePedido.DataSource = vListaArticuloNotaDePedido
            DGVArticuloNotaDePedido.Columns("Codigo").DisplayIndex = 0
            DGVArticuloNotaDePedido.Columns("Codigo").ReadOnly = True
            DGVArticuloNotaDePedido.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVArticuloNotaDePedido.Columns("Codigo").Width = 90
            DGVArticuloNotaDePedido.Columns("Codigo").HeaderText = "Código"
            DGVArticuloNotaDePedido.Columns("Descripcion").DisplayIndex = 1
            DGVArticuloNotaDePedido.Columns("Descripcion").ReadOnly = True
            DGVArticuloNotaDePedido.Columns("Descripcion").HeaderText = "Descripción"
            DGVArticuloNotaDePedido.Columns("Descripcion").Width = 269
            DGVArticuloNotaDePedido.Columns("Solicitadas").DisplayIndex = 2
            DGVArticuloNotaDePedido.Columns("Solicitadas").Width = 70
            DGVArticuloNotaDePedido.Columns("Solicitadas").ReadOnly = True
            DGVArticuloNotaDePedido.Columns("Solicitadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVArticuloNotaDePedido.Columns("Solicitadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVArticuloNotaDePedido.Columns("Pendientes").DisplayIndex = 3
            DGVArticuloNotaDePedido.Columns("Pendientes").Width = 78
            DGVArticuloNotaDePedido.Columns("Pendientes").ReadOnly = True
            DGVArticuloNotaDePedido.Columns("Pendientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVArticuloNotaDePedido.Columns("Pendientes").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").Visible = False
            DGVArticuloNotaDePedido.Columns("StockDeSeguridad").Visible = False
            DGVArticuloNotaDePedido.Columns("StockFisico").Visible = False
            DGVArticuloNotaDePedido.Columns("Reservadas").Visible = False
            DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").Visible = False
            DGVArticuloNotaDePedido.Columns(7).Visible = False
            DGVArticuloNotaDePedido.Columns(9).Visible = False
            DGVArticuloNotaDePedido.Columns(12).Visible = False
            DGVArticuloNotaDePedido.Columns("Disponible").Visible = False

        End If
        'Carga el diccionario de clientes.
        vDictionaryArticuloNotaDePedido.Clear()
        For Each vANdP As ArticuloNotaDePedido In vListaArticuloNotaDePedido
            vDictionaryArticuloNotaDePedido.Add(vANdP.ID, vANdP)
        Next
    End Sub

#End Region

#Region "Eventos"

    Private Sub FormNotaDePedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BTNGenerarPedido_Click(sender As Object, e As EventArgs) Handles BTNGenerarPedido.Click
        If vFormNuevaNotaDePedido Is Nothing Then
            vFormNuevaNotaDePedido = New FormNuevaNotaDePedido
            vFormNuevaNotaDePedido.MdiParent = Me.MdiParent
        End If
        vFormNuevaNotaDePedido.Idioma = Me.Idioma
        vFormNuevaNotaDePedido.Show()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged
        vProveedorActual = CBProveedor.SelectedValue
        ActualizarNotasDePedido()
    End Sub

    Private Sub DGVNotasDePedido_SelectionChanged(sender As Object, e As EventArgs) Handles DGVNotasDePedido.SelectionChanged
        SeleccionarNotaDePedido()
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNotaDePedido")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next
        Me.Idioma = pIdioma
        Me.Text = vDiccionario("FormNotaDePedido").MensajeTraducido
        Me.lbProveedor.Text = vDiccionario("lbProveedor").MensajeTraducido
        Me.GBNotasDePedido.Text = vDiccionario("GBNotasDePedido").MensajeTraducido
        Me.GBDetallePedido.Text = vDiccionario("GBDetallePedido").MensajeTraducido
        Me.lbFechaDeEntrega.Text = vDiccionario("lbFechaDeEntrega").MensajeTraducido
        Me.lbIDNotaDePedido.Text = vDiccionario("lbIDNotaDePedido").MensajeTraducido
        Me.lbRazonSocial.Text = vDiccionario("lbRazonSocial").MensajeTraducido
        Me.BTNGenerarPedido.Text = vDiccionario("BTNGenerarPedido").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

        If Not vFormNuevaNotaDePedido Is Nothing Then
            vFormNuevaNotaDePedido.Idioma = Me.Idioma
            vFormNuevaNotaDePedido.Actualizar(Me.Idioma)
        End If

    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloNotaDePedido_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloNotaDePedido.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)

        ' obtener indice de la columna 
        Dim columna As Integer = DGVArticuloNotaDePedido.CurrentCell.ColumnIndex
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
    End Sub

#End Region


#End Region

#Region "Ayuda en línea"

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover

        ToolTip.SetToolTip(CBProveedor, "Seleccione el proveedor asociado.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub DTPFechaDeEntrega_MouseHover(sender As Object, e As EventArgs) Handles DTPFechaDeEntrega.MouseHover

        ToolTip.SetToolTip(DTPFechaDeEntrega, "Ingrese la fecha de entrega.")
        ToolTip.ToolTipTitle = "Fecha de Entrega"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBIDNotaDePedido_MouseHover(sender As Object, e As EventArgs) Handles TBIDNotaDePedido.MouseHover

        ToolTip.SetToolTip(TBIDNotaDePedido, "Ingrese aquí el número de la nota de pedido.")
        ToolTip.ToolTipTitle = "Nota de Pedido"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBRazonSocial_MouseHover(sender As Object, e As EventArgs) Handles TBRazonSocial.MouseHover

        ToolTip.SetToolTip(TBRazonSocial, "Ingrese aquí la Razón Social de la nota de pedido.")
        ToolTip.ToolTipTitle = "Razón Social"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNGenerarPedido_MouseHover(sender As Object, e As EventArgs) Handles BTNGenerarPedido.MouseHover

        ToolTip.SetToolTip(BTNGenerarPedido, "Haga clic aquí para generar el pedido.")
        ToolTip.ToolTipTitle = "Generar Pedido"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub vFormNuevaNotaDePedido_Closed(sender As Object, e As EventArgs) Handles vFormNuevaNotaDePedido.Closed
        vFormNuevaNotaDePedido = Nothing
    End Sub

    Private Sub FormNotaDePedido_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        If Not vFormNuevaNotaDePedido Is Nothing Then
            vFormNuevaNotaDePedido.Close()
        End If

    End Sub

#End Region

End Class