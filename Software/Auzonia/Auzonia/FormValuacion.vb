Imports BE
Imports BLL_NEGOCIO
Imports INTERFACES
Imports BLL_TECNICA

Public Class FormValuacion

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)

    ' Permite actualizar el ComboBox de los proveedores.
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vProveedorActual As Proveedor
    Dim vProveedorNEG As New BLL_NEGOCIO.Proveedor_NEG
    Dim vListaArticuloValuacion As List(Of ArticuloValuacion)

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

    Private Sub CalcularValuacion()
        vProveedorActual = CBProveedor.SelectedItem
        Dim vValuacionNEG As New Valuacion_NEG
        DGVArticulosValuacion.DataSource = Nothing
        lbTotalFIFO.Text = ""
        lbTotalLIFO.Text = ""
        vListaArticuloValuacion = vValuacionNEG.CalcularValuacion(vProveedorActual)
        DGVArticulosValuacion.DataSource = vListaArticuloValuacion
        DGVArticulosValuacion.Columns("Articulo").Visible = False
        DGVArticulosValuacion.Columns("IDProveedor").Visible = False
        DGVArticulosValuacion.Columns("CantidadLIFO").Visible = False
        DGVArticulosValuacion.Columns("CantidadFIFO").Visible = False
        DGVArticulosValuacion.Columns("Precio").Visible = False
        DGVArticulosValuacion.Columns("IDListaDePrecios").Visible = False
        DGVArticulosValuacion.Columns("ID").Visible = False
        DGVArticulosValuacion.Columns("Codigo").DisplayIndex = 1
        DGVArticulosValuacion.Columns("Codigo").HeaderText = "Código"
        DGVArticulosValuacion.Columns("Codigo").Width = 177
        DGVArticulosValuacion.Columns("Descripcion").DisplayIndex = 2
        DGVArticulosValuacion.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticulosValuacion.Columns("Descripcion").Width = 300

        DGVArticulosValuacion.Columns("ValuacionLIFO").HeaderText = "Valuación LIFO"
        DGVArticulosValuacion.Columns("ValuacionLIFO").Width = 105
        DGVArticulosValuacion.Columns("ValuacionLIFO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulosValuacion.Columns("ValuacionLIFO").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticulosValuacion.Columns("ValuacionFIFO").HeaderText = "Valuación FIFO"
        DGVArticulosValuacion.Columns("ValuacionFIFO").Width = 105
        DGVArticulosValuacion.Columns("ValuacionFIFO").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulosValuacion.Columns("ValuacionFIFO").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        lbTotalFIFO.Text = " $" & TOTALFIFO(vListaArticuloValuacion)
        lbTotalLIFO.Text = " $" & TOTALLIFO(vListaArticuloValuacion)

    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormValuacion")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormValuacion").MensajeTraducido
        Me.LbProveedor.Text = vDiccionario("LbProveedor").MensajeTraducido
        Me.GBResultados.Text = vDiccionario("GBResultados").MensajeTraducido
        Me.lbFIFO.Text = vDiccionario("lbFIFO").MensajeTraducido
        Me.lbLIFO.Text = vDiccionario("lbLIFO").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

#End Region

#Region "Funciones"

    Private Function TOTALFIFO(ByRef pListaArticuloValuacion As List(Of ArticuloValuacion)) As Integer
        Dim total As Integer = 0
        For Each vAV As ArticuloValuacion In pListaArticuloValuacion
            total = vAV.ValuacionFIFO + total
        Next
        Return total
    End Function

    Private Function TOTALLIFO(ByRef pListaArticuloValuacion As List(Of ArticuloValuacion)) As Integer
        Dim total As Integer = 0
        For Each vAV As ArticuloValuacion In pListaArticuloValuacion
            total = vAV.ValuacionLIFO + total
        Next
        Return total
    End Function

#End Region

#Region "Eventos"

    Private Sub FormValuacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar(Me.Idioma)
        CargarProveedores()
    End Sub

    Private Sub FormValuacion_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        CalcularValuacion()
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged
        CalcularValuacion()
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#Region "Ayuda en línea"

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover

        ToolTip.SetToolTip(CBProveedor, "Seleccione el proveedor a valuar.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region

End Class