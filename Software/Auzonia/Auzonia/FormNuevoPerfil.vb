Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports BE

Public Class FormNuevoPerfil

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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevoPerfil")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Text = vDiccionario("FormNuevoPerfil").MensajeTraducido
        lbCodigo.Text = vDiccionario("lbCodigo").MensajeTraducido
        lbNombre.Text = vDiccionario("lbNombre").MensajeTraducido
        BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido
        BTNCancelar.Text = vDiccionario("BTNCancelar").MensajeTraducido

    End Sub

    Private Sub BTNCancelar_Click(sender As Object, e As EventArgs) Handles BTNCancelar.Click
        Me.Close()
    End Sub

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click

        If TBCodigo.Text <> "" And TBNombre.Text <> "" Then
            Try
                Dim vGestorPerfiles As New GestorPermisos_TEC
                Dim nuevoPerfil As New Familia_SEG
                nuevoPerfil.Codigo = TBCodigo.Text
                nuevoPerfil.Nombre = TBNombre.Text
                vGestorPerfiles.Alta(nuevoPerfil)
                MsgBox("El perfil se ha dado de alta.")
                Me.Close()
            Catch ex As Exception
                MsgBox("Ocurrió un error inesperado.")
            End Try
        Else
            MsgBox("Debe completar todos los campos.")
        End If

    End Sub

    Private Sub TBCodigo_MouseHover(sender As Object, e As EventArgs) Handles TBCodigo.MouseHover

        ToolTip.SetToolTip(TBCodigo, "Ingrese el código del perfil a crear aquí.")
        ToolTip.ToolTipTitle = "Código"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBNombre_MouseHover(sender As Object, e As EventArgs) Handles TBNombre.MouseHover

        ToolTip.SetToolTip(TBNombre, "Ingrese el nombre del perfil a crear aquí.")
        ToolTip.ToolTipTitle = "Nombre"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNAceptar_MouseHover(sender As Object, e As EventArgs) Handles BTNAceptar.MouseHover

        ToolTip.SetToolTip(BTNAceptar, "Haga clic aquí para generar el nuevo perfil.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

End Class