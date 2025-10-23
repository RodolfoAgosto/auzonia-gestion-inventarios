Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports BE

Public Class FormBitacora

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormBitacora")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormBitacora").MensajeTraducido
        Me.GPTipo.Text = vDiccionario("GPTipo").MensajeTraducido
        Me.RBActualizacion.Text = vDiccionario("RBActualizacion").MensajeTraducido
        Me.RBEvento.Text = vDiccionario("RBEvento").MensajeTraducido
        Me.RBExcepción.Text = vDiccionario("RBExcepción").MensajeTraducido
        Me.RBTodos.Text = vDiccionario("RBTodos").MensajeTraducido
        Me.LBCodigoUsuario.Text = vDiccionario("LBCodigoUsuario").MensajeTraducido
        Me.LBCodigoBitacora.Text = vDiccionario("LBCodigoBitacora").MensajeTraducido
        Me.LBTipoDeObjeto.Text = vDiccionario("LBTipoDeObjeto").MensajeTraducido
        Me.LBIdentificadorDeObjeto.Text = vDiccionario("LBIdentificadorDeObjeto").MensajeTraducido
        Me.LbDesde.Text = vDiccionario("LbDesde").MensajeTraducido
        Me.LbHasta.Text = vDiccionario("LbHasta").MensajeTraducido
        Me.BTNBuscar.Text = vDiccionario("BTNBuscar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

#Region "Eventos"

    Private Sub FormBitacora_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DTPDesde.Value = DateTime.Now.AddMonths(-12)
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

        Dim vBitacora As New Bitacora
        Dim vBitacoraTEC As New Bitacora_TEC
        Dim vListaDeBitacoras As List(Of Bitacora)

        vBitacora.Fecha = DTPDesde.Value
        If RBActualizacion.Checked Then
            vBitacora.Tipo = "Actualizacion"
        ElseIf RBEvento.Checked Then
            vBitacora.Tipo = "Evento"
        ElseIf RBExcepción.Checked Then
            vBitacora.Tipo = "Excepción"
        ElseIf RBTodos.Checked Then
            vBitacora.Tipo = ""
        End If
        vBitacora.CodigoUsuario = TBCodigoUsuario.Text
        vBitacora.CodigoBitacora = TBCodigoBitacora.Text
        vBitacora.TiporDeObjeto = TBTipoDeObjeto.Text
        vBitacora.IdentificadorDeObjeto = TBIdenticidadorDeObjeto.Text

        vListaDeBitacoras = vBitacoraTEC.ListarBitacoras(vBitacora, DTPHasta.Value)

        DGVBitacora.DataSource = Nothing
        DGVBitacora.DataSource = vListaDeBitacoras

        'ID
        DGVBitacora.Columns("ID").Visible = False
        'CodigoUsuario
        DGVBitacora.Columns("CodigoUsuario").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("CodigoUsuario").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("CodigoUsuario").HeaderText = "Código Usuario"
        DGVBitacora.Columns("CodigoUsuario").Width = 60
        'Fecha
        DGVBitacora.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Fecha").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Fecha").HeaderText = "Fecha"
        DGVBitacora.Columns("Fecha").Width = 100
        'Tipo
        DGVBitacora.Columns("Tipo").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Tipo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Tipo").HeaderText = "Tipo"
        DGVBitacora.Columns("Tipo").Width = 80
        'CodigoBitacora
        DGVBitacora.Columns("CodigoBitacora").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("CodigoBitacora").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("CodigoBitacora").HeaderText = "Código Bitácora"
        DGVBitacora.Columns("CodigoBitacora").Width = 70
        'Detalle
        DGVBitacora.Columns("Detalle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Detalle").Width = 100
        'Informacion
        DGVBitacora.Columns("Informacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("Informacion").HeaderText = "Información"
        DGVBitacora.Columns("Informacion").Width = 277
        'TipoDeObjeto
        DGVBitacora.Columns("TiporDeObjeto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("TiporDeObjeto").HeaderText = "Objeto"
        DGVBitacora.Columns("TiporDeObjeto").Width = 70
        'IdentificadorDeObjeto
        DGVBitacora.Columns("IdentificadorDeObjeto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVBitacora.Columns("IdentificadorDeObjeto").HeaderText = "Identificador"
        DGVBitacora.Columns("IdentificadorDeObjeto").Width = 70



    End Sub

#Region "Ayuda en línea"

    Private Sub RBActualizacion_MouseHover(sender As Object, e As EventArgs) Handles RBActualizacion.MouseHover

        ToolTip.SetToolTip(RBActualizacion, "Seleccione este punto para filtran las modificaciones realizadas.")
        ToolTip.ToolTipTitle = "Actualizacion"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub RBEvento_MouseHover(sender As Object, e As EventArgs) Handles RBEvento.MouseHover

        ToolTip.SetToolTip(RBEvento, "Seleccione este punto para filtrar los eventos del sistema.")
        ToolTip.ToolTipTitle = "Evento"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub RBExcepción_MouseHover(sender As Object, e As EventArgs) Handles RBExcepción.MouseHover

        ToolTip.SetToolTip(RBExcepción, "Seleccione este punto para filtrar las excepciones del sistema.")
        ToolTip.ToolTipTitle = "Excepción"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub RBTodos_MouseHover(sender As Object, e As EventArgs) Handles RBTodos.MouseHover

        ToolTip.SetToolTip(RBTodos, "Seleccione este punto para omitir el filtro de tipo de elemento.")
        ToolTip.ToolTipTitle = "Todos"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNBuscar_MouseHover(sender As Object, e As EventArgs) Handles BTNBuscar.MouseHover

        ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para actualizar la búsqueda.")
        ToolTip.ToolTipTitle = "Buscar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region


End Class