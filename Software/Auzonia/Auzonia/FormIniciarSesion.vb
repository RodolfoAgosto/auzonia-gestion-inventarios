Imports INTERFACES
Imports BLL_TECNICA
Imports BE

Public Class FormIniciarSesion

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vContrasenaIngresada As String

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property


    Public Event DatosCorrectos(ByVal pCodigoUsuario As String, ByVal pContrasena As String)

    'Actualiza el idioma al cargar el formulario.
    Private Sub FormIniciarSesion_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Actualizar(Idioma)

    End Sub

    'Actualiza el idioma del formulario  .
    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormIniciarSesion")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Text = vDiccionario("FormIniciarSesion").MensajeTraducido
        lbUsuario.Text = vDiccionario("lbUsuario").MensajeTraducido
        lbContraseña.Text = vDiccionario("lbContraseña").MensajeTraducido
        BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido

    End Sub

    'Si los datos fueron completados correstamente inicia la validación para el inicio de sesión.
    Private Sub Aceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click

        If TBUsuario.Text = "" Or TBContraseña.Text = "" Then
            MsgBox("Debe completar todos los campos.")
        Else
            RaiseEvent DatosCorrectos(TBUsuario.Text, TBContraseña.Text)
            Close()
        End If

    End Sub

#Region "Ayuda en línea"

    Private Sub TBContraseña_MouseHover(sender As Object, e As EventArgs) Handles TBContraseña.MouseHover

        ToolTip.SetToolTip(TBContraseña, "Ingrese aquí su contraseña.")
        ToolTip.ToolTipTitle = "Contraseña"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBUsuario_MouseHover(sender As Object, e As EventArgs) Handles TBUsuario.MouseHover

        ToolTip.SetToolTip(TBUsuario, "Ingrese aquí su usuario.")
        ToolTip.ToolTipTitle = "Usuario"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

End Class