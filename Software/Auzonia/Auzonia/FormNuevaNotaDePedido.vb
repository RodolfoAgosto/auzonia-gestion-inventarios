Imports BE
Imports BLL_NEGOCIO
Imports INTERFACES
Imports BLL_TECNICA
Imports System.Text.Json
Imports System.Text.Json.Serialization
Imports System.IO

Public Class FormNuevaNotaDePedido

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG
    Dim vListaArticuloNotaDePedido As List(Of ArticuloNotaDePedido)
    Dim vArticuloNotaDePedidoActual As ArticuloNotaDePedido
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

#Region "Procedimientos"

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevaNotaDePedido")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Text = vDiccionario("FormNuevaNotaDePedido").MensajeTraducido
        lbProveedor.Text = vDiccionario("lbProveedor").MensajeTraducido
        GBDetallePedido.Text = vDiccionario("GBDetallePedido").MensajeTraducido
        BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido
        BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

    Private Sub ActualizarArticulos()

        vProveedorActual = CBProveedor.SelectedItem
        Dim vArticuloDeConsulta As New ArticuloNotaDePedido
        vArticuloDeConsulta.IDProveedor = vProveedorActual.ID
        DGVArticuloNotaDePedido.DataSource = Nothing
        vListaArticuloNotaDePedido = vArticuloNEG.ConsultaVarios(vArticuloDeConsulta)
        DGVArticuloNotaDePedido.DataSource = vListaArticuloNotaDePedido
        DGVArticuloNotaDePedido.Columns("Codigo").DisplayIndex = 0
        DGVArticuloNotaDePedido.Columns("Codigo").Width = 110
        DGVArticuloNotaDePedido.Columns("Codigo").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("Codigo").HeaderText = "Código"
        DGVArticuloNotaDePedido.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Descripcion").DisplayIndex = 1
        DGVArticuloNotaDePedido.Columns("Descripcion").Width = 265
        DGVArticuloNotaDePedido.Columns("Descripcion").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticuloNotaDePedido.Columns("ID").Visible = False
        DGVArticuloNotaDePedido.Columns("IDProveedor").Visible = False
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").DisplayIndex = 2
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").HeaderText = "Punto de Reposición"
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").Width = 70
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("PuntoDeReposicion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").DisplayIndex = 3
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").HeaderText = "Stock de Seguridad"
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").Width = 70
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("StockDeSeguridad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("StockFisico").DisplayIndex = 4
        DGVArticuloNotaDePedido.Columns("StockFisico").HeaderText = "Stock Físico"
        DGVArticuloNotaDePedido.Columns("StockFisico").Width = 70
        DGVArticuloNotaDePedido.Columns("StockFisico").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("StockFisico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("StockFisico").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Reservadas").DisplayIndex = 5
        DGVArticuloNotaDePedido.Columns("Reservadas").Width = 70
        DGVArticuloNotaDePedido.Columns("Reservadas").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("Reservadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Reservadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").DisplayIndex = 6
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").HeaderText = "Pendientes de Entrega"
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").Width = 70
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("PendientesDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").DisplayIndex = 7
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").HeaderText = "Pendientes de Ingreso"
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").Width = 70
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("PendientesDeIngreso").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Disponible").DisplayIndex = 8
        DGVArticuloNotaDePedido.Columns("Disponible").Width = 70
        DGVArticuloNotaDePedido.Columns("Disponible").ReadOnly = True
        DGVArticuloNotaDePedido.Columns("Disponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Disponible").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Solicitadas").DisplayIndex = 9
        DGVArticuloNotaDePedido.Columns("Solicitadas").Width = 70
        DGVArticuloNotaDePedido.Columns("Solicitadas").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
        DGVArticuloNotaDePedido.Columns("Solicitadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Solicitadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDePedido.Columns("Pendientes").Visible = False

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormNuevaNotaDePedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
        Actualizar(Me.Idioma)

    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged

        ActualizarArticulos()

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click

        Me.Close()

    End Sub

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click

        Dim vNuevaNotaDePedido As New NotaDePedido
        Dim vNotaDePedidoNEG As New NotaDePedido_NEG
        vNuevaNotaDePedido.Proveedor = vProveedorActual
        Dim vListaDeArticulosAsignar As New List(Of ArticuloNotaDePedido)
        For Each vArticulo As ArticuloNotaDePedido In vListaArticuloNotaDePedido
            If vArticulo.Solicitadas > 0 Then
                vListaDeArticulosAsignar.Add(vArticulo)
            End If
        Next
        vNuevaNotaDePedido.ListaDeArticulos = vListaDeArticulosAsignar
        vNotaDePedidoNEG.Alta(vNuevaNotaDePedido)

        Dim writerXML As System.Xml.Serialization.XmlSerializer = New System.Xml.Serialization.XmlSerializer(GetType(NotaDePedido))
        Dim path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NotaDePedido.xml"
        Dim file As System.IO.FileStream = System.IO.File.Create(path)
        writerXML.Serialize(file, vNuevaNotaDePedido)
        file.Close()

        Dim jsonString As String
        Dim pathJson = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\NotaDePedido.json"
        jsonString = JsonSerializer.Serialize(vNuevaNotaDePedido)
        System.IO.File.WriteAllText(pathJson, jsonString)

        MsgBox("La nota de pedido ha sido ingresada con éxito. Debe enviar el archivo XML para que el proveedor ingrese el pedido en su sistema. Verifique los siguientes directorios: " & path & " " & pathJson)
        Me.Close()

    End Sub

    Private Sub FormNuevaNotaDePedido_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        ActualizarArticulos()
    End Sub

    Private Sub FormNuevaNotaDePedido_Validated(sender As Object, e As EventArgs) Handles Me.Validated
        ActualizarArticulos()
    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloNotaDePedido_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVArticuloNotaDePedido.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub DGVArticuloNotaDePedido_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloNotaDePedido.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
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

#End Region

#End Region

#Region "Ayuda en línea"

    Private Sub BTNAceptar_MouseHover(sender As Object, e As EventArgs) Handles BTNAceptar.MouseHover
        ToolTip.SetToolTip(BTNAceptar, "Haga clic aquí para generar la nueva nota de pedido.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover
        ToolTip.SetToolTip(CBProveedor, "Seleccione el proveedor de la nueva nota de pedido.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub DGVArticuloNotaDePedido_CellMouseMove(sender As Object, e As DataGridViewCellMouseEventArgs) Handles DGVArticuloNotaDePedido.CellMouseMove

        If e.RowIndex = -1 Then
            If e.ColumnIndex = 2 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Punto de Reposición es la cantidad mínima de existencia de un artículo, de modo que cuando el stock llegue a esa cantidad, el artículo debe reordenarse."
                ToolTip.ToolTipTitle = "Punto de Reposición"
            ElseIf e.ColumnIndex = 3 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Stock de Seguridad es un término utilizado para describir el nivel extra de existencias que se mantienen en el depósito para hacer frente a las variaciones de la demanda, suministro o producción."
                ToolTip.ToolTipTitle = "Stock de Seguridad"
            ElseIf e.ColumnIndex = 4 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Stock Físico que marca el inventario y lo que debería haber realmente en el depósito. Debería ser siempre positivo o cero, y si es negativo es síntoma de un error (faltan entradas o sobran salidas)"
                ToolTip.ToolTipTitle = "Stock Físico"
            ElseIf e.ColumnIndex = 5 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Cantidad comprometida para los clientes que se encuentran separadas en el depósito."
                ToolTip.ToolTipTitle = "Reservadas"
            ElseIf e.ColumnIndex = 6 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Cantidad solicitadas por los clientes que están pendientes de entrega (Sumatoria de Pedidos de Clientes)."
                ToolTip.ToolTipTitle = "Pendientes de Entrega"
            ElseIf e.ColumnIndex = 7 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Cantidad que ya ha sido solicitada y se encuentra pendiente de ingreso (Sumatoria por cantidad de Notas de Pedido pendientes)."
                ToolTip.ToolTipTitle = "Pendientes de Ingreso"
            ElseIf e.ColumnIndex = 8 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Cantidad disponible para la venta (Stock Físico - Reservadas)."
                ToolTip.ToolTipTitle = "Disponibles"
            ElseIf e.ColumnIndex = 0 Then
                DGVArticuloNotaDePedido.Columns(e.ColumnIndex).HeaderCell.ToolTipText = "Cantidad final que se le solicitará al proveedor en la presente Nota de Pedido (Stock de Seguridad - Stock Físico + Reservadas + Pendientes de Entrega - Pendientes de Ingreso)."
                ToolTip.ToolTipTitle = "Solicitadas"
            End If
        End If
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

End Class