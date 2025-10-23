Imports BE
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormNuevoRemitoProveedor

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG
    Dim vListaArticuloRemitoProveedor As List(Of ArticuloRemitoProveedor)
    Dim vArticuloArticuloRemitoProveedorActual As ArticuloRemitoProveedor
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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevoRemitoProveedor")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next
        Text = vDiccionario("FormNuevoRemitoProveedor").MensajeTraducido
        lbProveedor.Text = vDiccionario("lbProveedor").MensajeTraducido
        lbNumero.Text = vDiccionario("lbNumero").MensajeTraducido
        GBDetallePedido.Text = vDiccionario("GBDetallePedido").MensajeTraducido
        BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido
        BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormNuevaNotaDePedido_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged

        vProveedorActual = CBProveedor.SelectedItem
        Dim vArticuloRemitoProveedorDeConsulta As New ArticuloRemitoProveedor
        vArticuloRemitoProveedorDeConsulta.IDProveedor = vProveedorActual.ID
        DGVArticuloRemito.DataSource = Nothing
        vListaArticuloRemitoProveedor = vArticuloNEG.ConsultaVarios(vArticuloRemitoProveedorDeConsulta)
        DGVArticuloRemito.DataSource = vListaArticuloRemitoProveedor
        DGVArticuloRemito.Columns("Codigo").DisplayIndex = 0
        DGVArticuloRemito.Columns("Codigo").Width = 180
        DGVArticuloRemito.Columns("Codigo").ReadOnly = True
        DGVArticuloRemito.Columns("Codigo").HeaderText = "Código"
        DGVArticuloRemito.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemito.Columns("Descripcion").DisplayIndex = 1
        DGVArticuloRemito.Columns("Descripcion").Width = 330
        DGVArticuloRemito.Columns("Descripcion").ReadOnly = True
        DGVArticuloRemito.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticuloRemito.Columns("Descripcion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemito.Columns("ID").Visible = False
        DGVArticuloRemito.Columns("IDProveedor").Visible = False
        DGVArticuloRemito.Columns("Cantidad").DisplayIndex = 2
        DGVArticuloRemito.Columns("Cantidad").Width = 100
        DGVArticuloRemito.Columns("Cantidad").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
        DGVArticuloRemito.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloRemito.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloRemito.Columns("CantidadIngresada").Visible = False

    End Sub

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click
        If tbNumero.Text <> "" Then
            Dim vNuevoRemitoProveedor As New RemitoProveedor
            Dim vRemitoProveedorNEG As New RemitoProveedor_NEG
            vNuevoRemitoProveedor.Proveedor = vProveedorActual
            vNuevoRemitoProveedor.Numero = tbNumero.Text
            Dim vListaDeArticulosAsignar As New List(Of ArticuloRemitoProveedor)
            For Each vArticuloRemitoProveedor As ArticuloRemitoProveedor In vListaArticuloRemitoProveedor
                If vArticuloRemitoProveedor.Cantidad > 0 Then
                    vListaDeArticulosAsignar.Add(vArticuloRemitoProveedor)
                End If
            Next
            vNuevoRemitoProveedor.ListaDeArticulos = vListaDeArticulosAsignar
            vRemitoProveedorNEG.Alta(vNuevoRemitoProveedor)
            MsgBox("El remito ha sido ingresado con éxito.")
            Me.Close()
        Else
            MsgBox("Debe completar todos los campos.")
        End If
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloPedidoDeCliente_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVArticuloRemito.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub DGVArticuloRemito_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloRemito.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
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

#End Region

#End Region

#Region "Ayuda en línea"

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover
        ToolTip.SetToolTip(CBProveedor, "Ingrese el proveedor asociado.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub tbNumero_MouseHover(sender As Object, e As EventArgs) Handles tbNumero.MouseHover
        ToolTip.SetToolTip(tbNumero, "Ingrese el número de remito del proveedor.")
        ToolTip.ToolTipTitle = "Número"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNAceptar_MouseHover(sender As Object, e As EventArgs) Handles BTNAceptar.MouseHover
        ToolTip.SetToolTip(BTNAceptar, "Haga clic aquí para ingresar el nuevo remito.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

End Class