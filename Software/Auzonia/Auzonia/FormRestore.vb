Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports BE

Public Class FormRestore

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vDirectorio As String = ""
    Dim vListaDirectorios As List(Of Restaurador_SEG)

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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormRestore")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormRestore").MensajeTraducido
        Me.lbDirectorio.Text = vDiccionario("lbDirectorio").MensajeTraducido
        Me.lbResguardos.Text = vDiccionario("lbResguardos").MensajeTraducido
        Me.BTNRestaurar.Text = vDiccionario("BTNRestaurar").MensajeTraducido

    End Sub

    Private Sub ActualizarDGVResguardos()
        Dim vGestorBUTEC As New GestorBackUp_TEC
        vListaDirectorios = vGestorBUTEC.ListarDirectorios()
        DGVResguardos.DataSource = Nothing
        DGVResguardos.DataSource = vListaDirectorios
        DGVResguardos.Columns("Directorio").Width = 462
        DGVResguardos.Columns("Fecha").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVResguardos.Columns("Fecha").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVResguardos.Columns("Nombre").Visible = False

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormRestore_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarDGVResguardos()
        DGVResguardos.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BTNDirectorio_Click(sender As Object, e As EventArgs) Handles BTNDirectorio.Click
        If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
            TBDirectorio.Text = OpenFileDialog1.FileName
        End If
    End Sub

    Private Sub BTNRestaurar_Click(sender As Object, e As EventArgs) Handles BTNRestaurar.Click
        If TBDirectorio.Text = "" Then
            MsgBox("Debe completar todos los campos.")
        Else
            Try
                vDirectorio = ""
                vDirectorio = TBDirectorio.Text
                Dim vBackUpSEG As New Restaurador_SEG
                vBackUpSEG.Directorio = vDirectorio
                Dim vGestorBUTEC As New GestorBackUp_TEC
                vGestorBUTEC.RestaurarBaseDeDatos(vBackUpSEG)
                MsgBox("La restauración se realizó con éxito: " & vDirectorio)
            Catch ex As Exception
                MsgBox("No se pudo restaurar la base. Consulte con el administrador.")
            End Try
            Me.Close()
        End If
    End Sub

    Private Sub DGVResguardos_SelectionChanged(sender As Object, e As EventArgs) Handles DGVResguardos.SelectionChanged
        If DGVResguardos.SelectedRows.Count > 0 Then
            TBDirectorio.Text = DGVResguardos.SelectedRows(0).Cells(0).Value
        End If
    End Sub

#Region "Ayuda en línea"

    Private Sub BTNDirectorio_MouseHover(sender As Object, e As EventArgs) Handles BTNDirectorio.MouseHover
        ToolTip.SetToolTip(BTNDirectorio, "Haga clic aquí para seleccionar el directorio donde se encuentra el archivo BackUp.")
        ToolTip.ToolTipTitle = "Directorio"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub BTNRestaurar_MouseHover(sender As Object, e As EventArgs) Handles BTNRestaurar.MouseHover
        ToolTip.SetToolTip(BTNRestaurar, "Haga clic aquí para iniciar la restauración.")
        ToolTip.ToolTipTitle = "Restaurar"
        ToolTip.ToolTipIcon = ToolTipIcon.Warning
    End Sub

    Private Sub DGVResguardos_MouseHover(sender As Object, e As EventArgs) Handles DGVResguardos.MouseHover
        ToolTip.SetToolTip(DGVResguardos, "Haga clic aquí para iniciar la restauración.")
        ToolTip.ToolTipTitle = "Puede seleccionar los directorios recientes del listado."
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

#End Region

End Class