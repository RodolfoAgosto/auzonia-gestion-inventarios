Imports BE
Imports BLL_NEGOCIO
Imports INTERFACES
Imports BLL_TECNICA

Public Class FormListaDePrecios

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim WithEvents vFormNuevaListaCompra As FormNuevaListaCompras

    ' Permite actualizar el ComboBox de los proveedores.
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG

    ' Permite actualizar el DGV de las listas de precio compras.
    Dim vListaDePreciosCompra As New List(Of ListaDePreciosCompra)
    Dim vListaDePreciosCompraActual As ListaDePreciosCompra
    Dim vListaDePreciosCompraNEG As New ListaDePreciosCompra_NEG
    Dim vDiccionarioListaDePreciosCompra As New Dictionary(Of Integer, ListaDePreciosCompra)

    ' Permite actualizar el DGV de las listas de precio compras.
    Dim vDiccionarioArticuloDeListaDePreciosCompra As New Dictionary(Of Integer, ArticuloListaDePrecios)

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

    Private Sub CargarProveedores()
        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
    End Sub

    Private Sub SeleccionarProveedor()
        vProveedorActual = CBProveedor.SelectedItem
        ActualizarListaDePreciosCompra()
    End Sub

    Public Sub ActualizarListaDePreciosCompra()

        Dim vListaDePreciosCompraBusqueda As New ListaDePreciosCompra
        If Not vProveedorActual Is Nothing Then
            vListaDePreciosCompraBusqueda.Proveedor = vProveedorActual
            vListaDePreciosCompra = vListaDePreciosCompraNEG.ConsultaVariosLPDCArticulo(vListaDePreciosCompraBusqueda)
            DGVListaCompra.DataSource = Nothing
            DGVListaCompra.DataSource = vListaDePreciosCompra

            DGVListaCompra.Columns("ID").Visible = False
            DGVListaCompra.Columns("Proveedor").Visible = False
            DGVListaCompra.Columns("Numero").DisplayIndex = 1
            DGVListaCompra.Columns("Numero").Width = 59
            DGVListaCompra.Columns("Numero").HeaderText = "Número"
            DGVListaCompra.Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVListaCompra.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            DGVListaCompra.Columns("FechaDeInicioVigencia").Width = 120
            DGVListaCompra.Columns("FechaDeInicioVigencia").HeaderText = "Fecha de Vigencia"
            DGVListaCompra.Columns("FechaDeInicioVigencia").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVListaCompra.Columns("FechaDeInicioVigencia").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

            'Carga el diccionario de Lista de Precios
            vDiccionarioListaDePreciosCompra.Clear()
            For Each vLPC As ListaDePreciosCompra In vListaDePreciosCompra
                vDiccionarioListaDePreciosCompra.Add(vLPC.ID, vLPC)
            Next

            SeleccionarListaDePrecioCompra()

        End If

    End Sub

    Private Sub SeleccionarListaDePrecioCompra()
        DGVDetalleListaCompra.DataSource = Nothing
        vDiccionarioListaDePreciosCompra.Clear()
        For Each vLPC As ListaDePreciosCompra In vListaDePreciosCompra
            vDiccionarioListaDePreciosCompra.Add(vLPC.ID, vLPC)
        Next
        If DGVListaCompra.SelectedRows.Count > 0 Then
            If vDiccionarioListaDePreciosCompra.Count > 0 Then
                vListaDePreciosCompraActual = vDiccionarioListaDePreciosCompra(DGVListaCompra.SelectedRows(0).Cells(0).Value)
            Else
                vListaDePreciosCompraActual = Nothing
            End If
        End If
        ActualizarListaDeArticuloDeListaDePrecioCompra()
    End Sub

    Private Sub ActualizarListaDeArticuloDeListaDePrecioCompra()

        If DGVListaCompra.SelectedRows.Count = 0 Then
            Dim vListaArticulos As New List(Of ArticuloListaDePrecios)
            DGVDetalleListaCompra.DataSource = vListaArticulos
        Else
            DGVDetalleListaCompra.DataSource = vListaDePreciosCompraActual.ListaDeArticulos
        End If

        DGVDetalleListaCompra.Columns("IDProveedor").Visible = False
        DGVDetalleListaCompra.Columns("ID").Visible = False
        'Codigo
        DGVDetalleListaCompra.Columns("Codigo").HeaderText = "Código"
        DGVDetalleListaCompra.Columns("Codigo").Width = 110
        DGVDetalleListaCompra.Columns("Codigo").ReadOnly = True
        'Descripción
        DGVDetalleListaCompra.Columns("Descripcion").HeaderText = "Descripción"
        DGVDetalleListaCompra.Columns("Descripcion").Width = 255
        DGVDetalleListaCompra.Columns("Descripcion").ReadOnly = True
        'Precio
        DGVDetalleListaCompra.Columns("Precio").DisplayIndex = 3
        DGVDetalleListaCompra.Columns("Precio").HeaderText = "Precio (ARS)"
        DGVDetalleListaCompra.Columns("Precio").Width = 99
        DGVDetalleListaCompra.Columns("Precio").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVDetalleListaCompra.Columns("Precio").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
        DGVDetalleListaCompra.Columns("Precio").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormListaDePrecios")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormListaDePrecios").MensajeTraducido
        Me.LbProveedor.Text = vDiccionario("LbProveedor").MensajeTraducido
        Me.TBCompras.Text = vDiccionario("TBCompras").MensajeTraducido
        Me.GBListaCompra.Text = vDiccionario("GBListaCompra").MensajeTraducido
        Me.GBDetalleArticulosCompra.Text = vDiccionario("GBDetalleArticulosCompra").MensajeTraducido
        Me.BTNNuevaListaCompra.Text = vDiccionario("BTNNuevaListaCompra").MensajeTraducido
        Me.BTNGuardarCambioCompra.Text = vDiccionario("BTNGuardarCambioCompra").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido
        Me.TabPCompra.Text = vDiccionario("TBCompras").MensajeTraducido
        If Not vFormNuevaListaCompra Is Nothing Then
            vFormNuevaListaCompra.Actualizar(Me.Idioma)
        End If

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormListaDePrecios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CargarProveedores()
        SeleccionarProveedor()
        Actualizar(Me.Idioma)
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged
        SeleccionarProveedor()
    End Sub

    Private Sub BTNNuevaListaCompra_Click(sender As Object, e As EventArgs) Handles BTNNuevaListaCompra.Click
        If vFormNuevaListaCompra Is Nothing Then
            vFormNuevaListaCompra = New FormNuevaListaCompras
            vFormNuevaListaCompra.MdiParent = Me.MdiParent
        End If
        vFormNuevaListaCompra.Idioma = Me.Idioma
        vFormNuevaListaCompra.Show()
        vFormNuevaListaCompra.Proveedor = vProveedorActual
        vFormNuevaListaCompra.FormListaDePrecios = Me
    End Sub

    Private Sub DGVListaCompra_SelectionChanged(sender As Object, e As EventArgs) Handles DGVListaCompra.SelectionChanged
        SeleccionarListaDePrecioCompra()
        DGVDetalleListaCompra.DataSource = Nothing
        If Not vListaDePreciosCompraActual Is Nothing Then
            ActualizarListaDeArticuloDeListaDePrecioCompra()
        End If
    End Sub

    Private Sub BTNGuardarCambioCompra_Click(sender As Object, e As EventArgs) Handles BTNGuardarCambioCompra.Click
        vListaDePreciosCompraNEG.Modificacion(vListaDePreciosCompraActual)
        MsgBox("La lista de precios ha sido actualizada.")
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloPedidoDeCliente_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVDetalleListaCompra.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub DGVArticuloPedidoDeCliente_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVDetalleListaCompra.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 6
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso 
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar 
                e.KeyChar = Chr(0)
            End If
        Catch ex As Exception
            MsgBox("El valor no puede ser nulo.")
        End Try
    End Sub

    Private Sub vFormNuevaListaCompra_Closed(sender As Object, e As EventArgs) Handles vFormNuevaListaCompra.Closed
        vFormNuevaListaCompra = Nothing
    End Sub

    Private Sub FormListaDePrecios_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not vFormNuevaListaCompra Is Nothing Then
            vFormNuevaListaCompra.Close()
        End If
    End Sub

#End Region

#Region "Ayuda en línea "

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover

        ToolTip.SetToolTip(CBProveedor, "Seleccione el proveedor a actualizar.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNNuevaListaCompra_MouseHover(sender As Object, e As EventArgs) Handles BTNNuevaListaCompra.MouseHover

        ToolTip.SetToolTip(BTNNuevaListaCompra, "Haga clic aquí para ingresar una nueva lista de compras.")
        ToolTip.ToolTipTitle = "Nueva Lista Compra"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNGuardarCambioCompra_MouseHover(sender As Object, e As EventArgs) Handles BTNGuardarCambioCompra.MouseHover

        ToolTip.SetToolTip(BTNGuardarCambioCompra, "Haga clic aquí para guardar los cambios.")
        ToolTip.ToolTipTitle = "Guardar Cambios"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region

End Class