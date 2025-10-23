Imports BE
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES
Public Class FormRemitoProveedor

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim WithEvents vFormNuevoRemito As FormNuevoRemitoProveedor
    ' Proveedores
    Dim vDictionaryProveedor As New Dictionary(Of Integer, Proveedor)
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG
    ' Remitor Proveedor
    Dim vDictionaryRemitoProveedor As New Dictionary(Of Integer, RemitoProveedor)
    Dim vListaRemitoProveedor As List(Of RemitoProveedor)
    Dim vRemitoProveedorActual As RemitoProveedor
    Dim vRemitoProveedorNEG As New RemitoProveedor_NEG
    'Articulo
    Dim vDictionaryArticuloRemitoProveedor As New Dictionary(Of Integer, ArticuloRemitoProveedor)
    Dim vListaArticuloRemitoProveedor As List(Of ArticuloRemitoProveedor)
    Dim vArticuloRemitoProveedorActual As ArticuloRemitoProveedor
    Dim vArticuloNEG As New Articulo_NEG

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

#Region "Provedimientos"

    Private Sub ActualizarRemitoProveedor()
        Dim vRemitoProveedorDeBusqueda As New RemitoProveedor
        vRemitoProveedorDeBusqueda.Proveedor = vProveedorActual
        vListaRemitoProveedor = vRemitoProveedorNEG.ConsultaVarios(vRemitoProveedorDeBusqueda)
        For Each vRemitoProveedor As RemitoProveedor In vListaRemitoProveedor
            vRemitoProveedorNEG.Consulta(vRemitoProveedor)
        Next
        DGVRemitoProveedor.DataSource = Nothing
        If Not vListaRemitoProveedor Is Nothing Then
            DGVRemitoProveedor.DataSource = vListaRemitoProveedor
            DGVRemitoProveedor.Columns("ID").Width = 70
            DGVRemitoProveedor.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("Proveedor").Visible = False
            DGVRemitoProveedor.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
            DGVRemitoProveedor.Columns("FechaDeCreacion").Width = 129
            DGVRemitoProveedor.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("Estado").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVRemitoProveedor.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        End If
        'Carla el diccionario de clientes.
        vDictionaryRemitoProveedor.Clear()
        For Each vNdP As RemitoProveedor In vListaRemitoProveedor
            vDictionaryRemitoProveedor.Add(vNdP.ID, vNdP)
        Next
        SeleccionarRemitoProveedor()
    End Sub

    Public Sub SeleccionarRemitoProveedor()
        If DGVRemitoProveedor.SelectedRows.Count > 0 Then
            If vDictionaryRemitoProveedor.ContainsKey(CInt(DGVRemitoProveedor.SelectedRows(0).Cells(0).Value)) Then
                vRemitoProveedorActual = vDictionaryRemitoProveedor(CInt(DGVRemitoProveedor.SelectedRows(0).Cells(0).Value))
                TBIDRemitoProveedor.Text = vRemitoProveedorActual.ID
                TBRazonSocial.Text = vRemitoProveedorActual.Proveedor.RazonSocial
                DTPFechaDeEntrega.Value = vRemitoProveedorActual.FechaDeCreacion
            End If
        Else
            vRemitoProveedorActual = Nothing
            TBIDRemitoProveedor.Text = ""
            TBRazonSocial.Text = ""
            DTPFechaDeEntrega.Value = Now
        End If
        ActualizarListaDeArticulosRemitoProveedor()
    End Sub

    Private Sub ActualizarListaDeArticulosRemitoProveedor()
        If Not vRemitoProveedorActual Is Nothing Then
            vListaArticuloRemitoProveedor = vRemitoProveedorActual.ListaDeArticulos
            If Not vListaArticuloRemitoProveedor Is Nothing Then
                DGVArticuloRemitoProveedor.DataSource = vListaArticuloRemitoProveedor
            End If
            'Carga el diccionario de articulos.
            vDictionaryArticuloRemitoProveedor.Clear()
            For Each vARP As ArticuloRemitoProveedor In vListaArticuloRemitoProveedor
                vDictionaryArticuloRemitoProveedor.Add(vARP.ID, vARP)
            Next
        Else
            Dim vListaArticuloRemitoProveedor As New List(Of ArticuloRemitoProveedor)
            DGVArticuloRemitoProveedor.DataSource = vListaArticuloRemitoProveedor
        End If
        DGVArticuloRemitoProveedor.Columns("ID").DisplayIndex = 0
        DGVArticuloRemitoProveedor.Columns("ID").Width = 70
        DGVArticuloRemitoProveedor.Columns("ID").ReadOnly = True
        DGVArticuloRemitoProveedor.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemitoProveedor.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemitoProveedor.Columns("Codigo").DisplayIndex = 1
        DGVArticuloRemitoProveedor.Columns("Codigo").Width = 95
        DGVArticuloRemitoProveedor.Columns("Codigo").ReadOnly = True
        DGVArticuloRemitoProveedor.Columns("Codigo").HeaderText = "Código"
        DGVArticuloRemitoProveedor.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemitoProveedor.Columns("Descripcion").DisplayIndex = 2
        DGVArticuloRemitoProveedor.Columns("Descripcion").Width = 279
        DGVArticuloRemitoProveedor.Columns("Descripcion").ReadOnly = True
        DGVArticuloRemitoProveedor.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticuloRemitoProveedor.Columns("Descripcion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemitoProveedor.Columns("IDProveedor").Visible = False
        DGVArticuloRemitoProveedor.Columns("Cantidad").DisplayIndex = 3
        DGVArticuloRemitoProveedor.Columns("Cantidad").Width = 70
        DGVArticuloRemitoProveedor.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemitoProveedor.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemitoProveedor.Columns("Cantidad").ReadOnly = True
        DGVArticuloRemitoProveedor.Columns("Cantidad").DefaultCellStyle.BackColor = Color.White
        If Not vRemitoProveedorActual Is Nothing Then
            If vRemitoProveedorActual.Estado = "Revisado" Then
                DGVArticuloRemitoProveedor.Columns("Cantidad").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
                DGVArticuloRemitoProveedor.Columns("Cantidad").ReadOnly = False
            End If
        End If

        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").DisplayIndex = 4
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").Width = 70
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").HeaderText = "Cantidad Ingresada"
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").ReadOnly = True
        DGVArticuloRemitoProveedor.Columns("CantidadIngresada").DefaultCellStyle.BackColor = Color.White
        If Not vRemitoProveedorActual Is Nothing Then
            If vRemitoProveedorActual.Estado = "Revisado" Or vRemitoProveedorActual.Estado = "Pendiente" Then
                DGVArticuloRemitoProveedor.Columns("CantidadIngresada").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
                DGVArticuloRemitoProveedor.Columns("CantidadIngresada").ReadOnly = False
            End If
        End If

    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormRemitoProveedor")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormRemitoProveedor").MensajeTraducido
        Me.lbProveedor.Text = vDiccionario("lbProveedor").MensajeTraducido
        Me.GBRemitoProveedor.Text = vDiccionario("GBRemitoProveedor").MensajeTraducido
        Me.GBDetallePedido.Text = vDiccionario("GBDetallePedido").MensajeTraducido
        Me.lbFechaDeEntrega.Text = vDiccionario("lbFechaDeEntrega").MensajeTraducido
        Me.lbIDRemitoProveedor.Text = vDiccionario("lbIDRemitoProveedor").MensajeTraducido
        Me.lbRazonSocial.Text = vDiccionario("lbRazonSocial").MensajeTraducido
        Me.BTNCancelarPedidoDeCliente.Text = vDiccionario("BTNCancelarPedidoDeCliente").MensajeTraducido
        Me.BTNGuardarCambios.Text = vDiccionario("BTNGuardarCambios").MensajeTraducido
        Me.BTNGenerarRemito.Text = vDiccionario("BTNGenerarRemito").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

        If Not vFormNuevoRemito Is Nothing Then
            vFormNuevoRemito.Actualizar(pIdioma)
        End If

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormRemitoProveedor_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
    End Sub

    Private Sub BTNGenerarPedido_Click(sender As Object, e As EventArgs) Handles BTNGenerarRemito.Click
        If vFormNuevoRemito Is Nothing Then
            vFormNuevoRemito = New FormNuevoRemitoProveedor
            vFormNuevoRemito.MdiParent = Me.MdiParent
            vFormNuevoRemito.Actualizar(Idioma)
        End If
        vFormNuevoRemito.Show()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged
        vProveedorActual = CBProveedor.SelectedValue
        ActualizarRemitoProveedor()
    End Sub

    Private Sub DGVRemitoProveedor_SelectionChanged(sender As Object, e As EventArgs) Handles DGVRemitoProveedor.SelectionChanged
        SeleccionarRemitoProveedor()
        ActualizarListaDeArticulosRemitoProveedor()
    End Sub

    Private Sub DGVArticuloRemitoProveedor_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloRemitoProveedor.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        ' obtener indice de la columna 
        Dim columna As Integer = DGVArticuloRemitoProveedor.CurrentCell.ColumnIndex
        ' comprobar si la celda en edición corresponde a la columna 1 o 3 
        If columna = 1 Or columna = 0 Then
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso 
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar 
                e.KeyChar = Chr(0)
            End If
        End If
    End Sub

    Private Sub BTNGuardarCambios_Click(sender As Object, e As EventArgs) Handles BTNGuardarCambios.Click
        If vRemitoProveedorActual.Estado = "Pendiente" Then
            Dim respuesta As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Verifique haber controlado las cantidades de todos los artículos. En caso de continuar el remito pasará a estar en estado Revisado.¿Desea continuar?", MsgBoxStyle.YesNoCancel)
            If respuesta = MsgBoxResult.Yes Then
                vRemitoProveedorActual.Estado = "Revisado"
                vRemitoProveedorNEG.Modificacion(vRemitoProveedorActual)
            End If
        ElseIf vRemitoProveedorActual.Estado = "Revisado" Then
            Dim respuesta As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Verifique haber controlado las cantidades de todos los artículos. En caso de continuar el remito pasará a estar en estado Ingresado.¿Desea continuar?", MsgBoxStyle.YesNoCancel)
            If respuesta = MsgBoxResult.Yes Then
                vRemitoProveedorActual.Estado = "Ingresado"
                vRemitoProveedorActual.Proveedor = vProveedorActual
                vRemitoProveedorNEG.IngresarRemito(vRemitoProveedorActual)
            End If
        ElseIf vRemitoProveedorActual.Estado = "Ingresado" Then
            MsgBox("El remito ya ha sido ingresado anteriormente.")
        ElseIf vRemitoProveedorActual.Estado = "Cancelado" Then
            Dim respuesta As Microsoft.VisualBasic.MsgBoxResult = MsgBox("El remito pasara a estado Pendiente.¿Desea continuar?", MsgBoxStyle.YesNoCancel)
            If respuesta = MsgBoxResult.Yes Then
                vRemitoProveedorActual.Estado = "Pendiente"
                vRemitoProveedorNEG.Modificacion(vRemitoProveedorActual)
            End If
        End If
    End Sub

    Private Sub BTNCancelarPedidoDeCliente_Click(sender As Object, e As EventArgs) Handles BTNCancelarPedidoDeCliente.Click
        If vRemitoProveedorActual.Estado = "Pendiente" Or vRemitoProveedorActual.Estado = "Revisado" Then
            Dim respuesta As Microsoft.VisualBasic.MsgBoxResult = MsgBox("Esta a punto de cancelar el remito.¿Desea continuar?", MsgBoxStyle.YesNoCancel)
            If respuesta = MsgBoxResult.Yes Then
                vRemitoProveedorActual.Estado = "Cancelado"
                vRemitoProveedorNEG.Modificacion(vRemitoProveedorActual)
                MsgBox("El remito se encuentra cancelado.")
            End If
        ElseIf vRemitoProveedorActual.Estado = "Cancelado" Then
            MsgBox("El remito ya ha sido Cancelado.")
        Else
            MsgBox("No es posible cancelar el remito. Ya ha sido ingresado.")
        End If
    End Sub

    Private Sub DGVArticuloRemitoProveedor_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVArticuloRemitoProveedor.DataError
        e.Cancel = True
    End Sub

    Private Sub DGVRemitoProveedor_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVRemitoProveedor.DataError
        e.Cancel = True
    End Sub

    Private Sub vFormNuevoRemito_Closed(sender As Object, e As EventArgs) Handles vFormNuevoRemito.Closed
        vFormNuevoRemito = Nothing
    End Sub

    Private Sub FormRemitoProveedor_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        If Not vFormNuevoRemito Is Nothing Then
            vFormNuevoRemito.Close()
        End If

    End Sub

#End Region

#Region "Ayuda en línea"

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover
        ToolTip.SetToolTip(CBProveedor, "Seleccione proveedor.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNCancelarPedidoDeCliente_MouseHover(sender As Object, e As EventArgs) Handles BTNCancelarPedidoDeCliente.MouseHover
        ToolTip.SetToolTip(BTNCancelarPedidoDeCliente, "Haga clic aquí para cancelar. Los cambios no serán guardados.")
        ToolTip.ToolTipTitle = "Cancelar"
        ToolTip.ToolTipIcon = ToolTipIcon.Warning
    End Sub

    Private Sub BTNGenerarRemito_MouseHover(sender As Object, e As EventArgs) Handles BTNGenerarRemito.MouseHover
        ToolTip.SetToolTip(BTNGenerarRemito, "Haga clic aquí para generar un nuevo remito.")
        ToolTip.ToolTipTitle = "Generar Remito"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNGuardarCambios_MouseHover(sender As Object, e As EventArgs) Handles BTNGuardarCambios.MouseHover
        ToolTip.SetToolTip(BTNGuardarCambios, "Haga clic aquí para guardar los cambios.")
        ToolTip.ToolTipTitle = "Guardar Cambios"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

End Class