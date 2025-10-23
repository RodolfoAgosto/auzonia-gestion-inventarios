Imports BE
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormIdioma

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim WithEvents vFormNuevoIdioma As FormNuevoIdioma
    Dim vListaIdiomas As List(Of Idioma)
    Dim vIdiomaActual As Idioma

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

    Public Sub ActualizarIdiomas()
        If Not IsNothing(vListaIdiomas) Then
            vListaIdiomas.Clear()
        End If
        Dim vIdioma_TEC As New Idioma_TEC
        vListaIdiomas = vIdioma_TEC.ListarIdiomas
        CBIdioma.Items.Clear()
        For Each vIdioma As BE.Idioma In vListaIdiomas
            CBIdioma.Items.Add(vIdioma)
        Next
        CBIdioma.DisplayMember = "Nombre"

    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormIdioma")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormIdioma").MensajeTraducido
        Me.LbIdioma.Text = vDiccionario("LbIdioma").MensajeTraducido
        Me.BtnNuevoIdioma.Text = vDiccionario("BtnNuevoIdioma").MensajeTraducido
        Me.GBTraducciones.Text = vDiccionario("GBTraducciones").MensajeTraducido
        Me.BtnGuardarCambios.Text = vDiccionario("BtnGuardarCambios").MensajeTraducido
        Idioma = pIdioma
        If Not vFormNuevoIdioma Is Nothing Then
            vFormNuevoIdioma.Actualizar(Me.Idioma)
        End If

    End Sub

    Public Sub LimpiarDGV()
        vIdiomaActual = Nothing
        DGVTraducciones.DataSource = Nothing
    End Sub

#End Region

#Region "Eventos"

    Private Sub FormIdioma_Load(sender As Object, e As EventArgs) Handles Me.Load
        ActualizarIdiomas()
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BtnNuevoIdioma_Click(sender As Object, e As EventArgs) Handles BtnNuevoIdioma.Click

        If vFormNuevoIdioma Is Nothing Then
            vFormNuevoIdioma = New FormNuevoIdioma
            vFormNuevoIdioma.MdiParent = Me.MdiParent
        End If
        vFormNuevoIdioma.Idioma = Me.Idioma
        vFormNuevoIdioma.Actualizar(Me.Idioma)
        vFormNuevoIdioma.FormIdioma = Me
        vFormNuevoIdioma.Show()

    End Sub

    Private Sub BtnGuardarCambios_Click(sender As Object, e As EventArgs) Handles BtnGuardarCambios.Click
        If Not IsNothing(vIdiomaActual) Then
            Dim vIdiomaTEC As New Idioma_TEC
            vIdiomaTEC.Actualizar(vIdiomaActual)
        Else
            MsgBox("Seleccione el idioma a actualizar.")
        End If
    End Sub

    Private Sub CBIdioma_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBIdioma.SelectedValueChanged
        Dim vTraducionTEC As New Traduccion_TEC
        vIdiomaActual = CBIdioma.SelectedItem
        vIdiomaActual.ListaTraducciones = vTraducionTEC.ListarTraducciones(vIdiomaActual)
        DGVTraducciones.DataSource = Nothing
        DGVTraducciones.DataSource = vIdiomaActual.ListaTraducciones

        If Not IsNothing(vIdiomaActual.ListaTraducciones) Then

            'Ajusta el tamaño de las columnas.
            DGVTraducciones.Columns(0).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DGVTraducciones.Columns(1).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DGVTraducciones.Columns(2).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            DGVTraducciones.Columns(3).AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells

            'Ajusta las columnas de tal forma que el usuario solo pueda editar la traducción.
            DGVTraducciones.Columns(0).ReadOnly = True
            DGVTraducciones.Columns(1).ReadOnly = True
            DGVTraducciones.Columns(2).ReadOnly = True
            DGVTraducciones.Columns(3).ReadOnly = True

            'IDMensaje
            DGVTraducciones.Columns("IDMensaje").HeaderText = "ID"
            DGVTraducciones.Columns("IDMensaje").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVTraducciones.Columns("IDMensaje").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Codigo
            DGVTraducciones.Columns("Codigo").HeaderText = "Código"
            DGVTraducciones.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Descipcion
            DGVTraducciones.Columns("Descripcion").HeaderText = "Descripción"
            DGVTraducciones.Columns("Descripcion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Propietario
            DGVTraducciones.Columns("Propietario").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'MensajeTraducido
            DGVTraducciones.Columns("MensajeTraducido").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVTraducciones.Columns("MensajeTraducido").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
            DGVTraducciones.Columns("MensajeTraducido").HeaderText = "Mensaje Traducido"
            DGVTraducciones.Columns("MensajeTraducido").Width = 228

        End If

    End Sub

    Private Sub vFormNuevoIdioma_FormClosed(sender As Object, e As FormClosedEventArgs) Handles vFormNuevoIdioma.FormClosed
        Me.ActualizarIdiomas()
    End Sub

    Private Sub vFormNuevoIdioma_Closed(sender As Object, e As EventArgs) Handles vFormNuevoIdioma.Closed
        vFormNuevoIdioma = Nothing
    End Sub

    Private Sub FormIdioma_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        If Not vFormNuevoIdioma Is Nothing Then
            vFormNuevoIdioma.Close()
        End If
    End Sub

#Region "Ayuda en línea"

    Private Sub CBIdioma_MouseHover(sender As Object, e As EventArgs) Handles CBIdioma.MouseHover

        ToolTip.SetToolTip(CBIdioma, "Haga clic aquí para seleccionar el idioma a actualizar.")
        ToolTip.ToolTipTitle = "Idioma"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BtnNuevoIdioma_MouseHover(sender As Object, e As EventArgs) Handles BtnNuevoIdioma.MouseHover

        ToolTip.SetToolTip(BtnNuevoIdioma, "Haga clic aquí para crear un nuevo idioma.")
        ToolTip.ToolTipTitle = "Nuevo Idioma"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BtnGuardarCambios_MouseHover(sender As Object, e As EventArgs) Handles BtnGuardarCambios.MouseHover

        ToolTip.SetToolTip(BtnGuardarCambios, "Haga clic aquí para guardar los cambios.")
        ToolTip.ToolTipTitle = "Guardar Cambios"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region

End Class