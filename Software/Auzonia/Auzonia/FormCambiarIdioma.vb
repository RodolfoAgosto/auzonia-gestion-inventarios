Imports BE
Imports BLL_TECNICA
Imports INTERFACES
Public Class FormCambiarIdioma

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vListaIdiomas As List(Of Idioma)

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click
        Dim vMDI As MDIPrincipal = Me.MdiParent
        vMDI.IdiomaActual = CBIdiomas.SelectedItem
        Me.Close()
    End Sub

    Public Sub ActualizarIdiomas()
        If Not IsNothing(vListaIdiomas) Then
            vListaIdiomas.Clear()
        End If
        Dim vIdioma_TEC As New Idioma_TEC
        vListaIdiomas = vIdioma_TEC.ListarIdiomas
        CBIdiomas.Items.Clear()
        For Each vIdioma As BE.Idioma In vListaIdiomas
            CBIdiomas.Items.Add(vIdioma)
        Next
        CBIdiomas.DisplayMember = "Nombre"
    End Sub

    Private Sub FormCambiarIdioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarIdiomas()
        Actualizar(Me.Idioma)
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormCambiarIdioma")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next
        Me.Text = vDiccionario("FormCambiarIdioma_Text").MensajeTraducido
        Me.BTNAceptar.Text = vDiccionario("FormCambiarIdioma_BTNAceptar").MensajeTraducido
    End Sub

    Private Sub CBIdiomas_MouseHover(sender As Object, e As EventArgs) Handles CBIdiomas.MouseHover

        ToolTip.SetToolTip(CBIdiomas, "Haga clic aquí para cambiar el idioma.")
        ToolTip.ToolTipTitle = "Cambiar Idioma"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private _Idioma As Idioma
    Public Property Idioma() As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property



End Class