Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports BE

Public Class FormBackUp
    Implements IObservadores

    Dim vNombreBase As String = ""
    Dim vDirectorio As String = ""
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

#Region "Procedimientos"

    Private Sub FormBackUp_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar(Me.Idioma)
    End Sub

    Private Sub ActualizaLbDestino()

        If TBNombreArchivo.Text = "" Or TBDirectorio.Text = "" Then
            LbDestino.Text = ""
        Else
            If TBDirectorio.Text.Length > 0 Then
                If TBDirectorio.Text.Last <> "\" Then
                    LbDestino.Text = TBDirectorio.Text & "\" & TBNombreArchivo.Text & ".bak"
                Else
                    LbDestino.Text = TBDirectorio.Text & TBNombreArchivo.Text & ".bak"
                End If
            End If
        End If
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormBackUp")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormBackUp").MensajeTraducido
        Me.LbDirectorio.Text = vDiccionario("LbDirectorio").MensajeTraducido
        Me.LbNombreDeArchivo.Text = vDiccionario("LbNombreDeArchivo").MensajeTraducido
        Me.LbDestino1.Text = vDiccionario("LbDestino1").MensajeTraducido
        Me.BTNGenerarBackUp.Text = vDiccionario("BTNGenerarBackUp").MensajeTraducido

    End Sub

#End Region

#Region "Eventos"

    Private Sub BTNDirectorio_Click(sender As Object, e As EventArgs) Handles BTNDirectorio.Click

        If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
            TBDirectorio.Text = FolderBrowserDialog1.SelectedPath
            ActualizaLbDestino()
        End If
    End Sub

    Private Sub BTNGenerarBackUp_Click(sender As Object, e As EventArgs) Handles BTNGenerarBackUp.Click
        If TBNombreArchivo.Text = "" Or TBDirectorio.Text = "" Then
            MsgBox("Debe completar todos los campos.")
        Else
            Try
                vDirectorio = LbDestino.Text
                Dim vBackUpSEG As New Restaurador_SEG
                vBackUpSEG.Nombre = vNombreBase
                vBackUpSEG.Directorio = vDirectorio
                Dim vGestorBUTEC As New GestorBackUp_TEC
                vGestorBUTEC.RealizarBackUp(vBackUpSEG)
                MsgBox("El BackUp se realizó con éxito: " & vDirectorio)
            Catch ex As Exception
                Dim vBitacora As New Bitacora
                vBitacora.CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
                vBitacora.CodigoBitacora = "0006"
                vBitacora.Informacion = ex.Message
                vBitacora.TiporDeObjeto = "BackUp"
                vBitacora.IdentificadorDeObjeto = "FormBackUp"
                Dim vBitacoraTEC As New Bitacora_TEC
                vBitacoraTEC.RegistrarEnBitacora(vBitacora)
                MsgBox("No se puedo realizar el BackUp. Verifique los permisos de seguridad de la carpeta destino.")
            Finally
                Me.Close()
            End Try
        End If
    End Sub

    Private Sub TBNombreArchivo_TextChanged(sender As Object, e As EventArgs) Handles TBNombreArchivo.TextChanged
        ActualizaLbDestino()
    End Sub

#Region "Ayuda en línea"

    Private Sub TBDirectorio_MouseHover(sender As Object, e As EventArgs) Handles TBDirectorio.MouseHover

        ToolTip.SetToolTip(TBDirectorio, "Haga clic en los tres puntos (...) para seleccionar la carpeta destino del archivo BackUp.")
        ToolTip.ToolTipTitle = "Directorio"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBNombreArchivo_MouseHover(sender As Object, e As EventArgs) Handles TBNombreArchivo.MouseHover

        ToolTip.SetToolTip(TBNombreArchivo, "Ingrese el nombre del archivo BackUp.")
        ToolTip.ToolTipTitle = "Nombre Archivo"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNGenerarBackUp_MouseHover(sender As Object, e As EventArgs) Handles BTNGenerarBackUp.MouseHover

        ToolTip.SetToolTip(BTNGenerarBackUp, "Haga clic aquí para generar el BackUp.")
        ToolTip.ToolTipTitle = "Generar Backup"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub BTNDirectorio_MouseHover(sender As Object, e As EventArgs) Handles BTNDirectorio.MouseHover

        ToolTip.SetToolTip(BTNDirectorio, "Haga clic aquí para seleccionar el directorio.")
        ToolTip.ToolTipTitle = "Directorio"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

#End Region

#End Region

End Class