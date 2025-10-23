Imports BLL_TECNICA
Imports BE
Imports INTERFACES

Public Class FormNuevoIdioma

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

    Private _FormIdioma As FormIdioma
    Public Property FormIdioma() As FormIdioma
        Get
            Return _FormIdioma
        End Get
        Set(ByVal value As FormIdioma)
            _FormIdioma = value
        End Set
    End Property

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevoIdioma")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormNuevoIdioma").MensajeTraducido
        Me.lbNombre.Text = vDiccionario("lbNombre").MensajeTraducido
        Me.BtnAceptar.Text = vDiccionario("BtnAceptar").MensajeTraducido

    End Sub

    Private Sub BtnAceptar_Click(sender As Object, e As EventArgs) Handles BtnAceptar.Click
        If TbNombreIdioma.Text <> "" Then
            Dim vIdiomaTEC As New Idioma_TEC
            Dim vIdioma As New Idioma
            vIdioma.Nombre = TbNombreIdioma.Text
            vIdiomaTEC.Alta(vIdioma)
            MsgBox("El idioma ha sido dado de alta con éxito.")
            FormIdioma.ActualizarIdiomas()
            FormIdioma.LimpiarDGV()
            Me.Close()
        Else
            MsgBox("Ingrese el nombre del idioma a cargar.")
        End If
    End Sub

    Private Sub FormNuevoIdioma_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BtnAceptar_MouseHover(sender As Object, e As EventArgs) Handles BtnAceptar.MouseHover

        ToolTip.SetToolTip(BtnAceptar, "Haga clic aquí para crear el nuevo idioma.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TbNombreIdioma_MouseHover(sender As Object, e As EventArgs) Handles TbNombreIdioma.MouseHover

        ToolTip.SetToolTip(TbNombreIdioma, "Ingrese aquí el idioma a crear.")
        ToolTip.ToolTipTitle = "Nombre"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

End Class