Imports BE
Imports INTERFACES
Imports BLL_TECNICA
Imports AcroPDFLib
Imports AxAcroPDFLib
Imports System.IO
Imports BLL_NEGOCIO

Public Class FormAyuda

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim pdf As New AxAcroPDFLib.AxAcroPDF
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
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormAyuda")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormAyuda").MensajeTraducido
        Me.TreeView1.Nodes("NCompras").Text = vDiccionario("NCompras").MensajeTraducido
        Me.TreeView1.Nodes("NCompras").Nodes("NProveedores").Text = vDiccionario("NProveedores").MensajeTraducido
        Me.TreeView1.Nodes("NCompras").Nodes("NArticulos").Text = vDiccionario("NArticulos").MensajeTraducido
        Me.TreeView1.Nodes("NCompras").Nodes("NNotasDePedido").Text = vDiccionario("NNotasDePedido").MensajeTraducido
        Me.TreeView1.Nodes("NCompras").Nodes("NRemitos").Text = vDiccionario("NRemitos").MensajeTraducido
        Me.TreeView1.Nodes("NVentas").Text = vDiccionario("NVentas").MensajeTraducido
        Me.TreeView1.Nodes("NVentas").Nodes("NClientes").Text = vDiccionario("NClientes").MensajeTraducido
        Me.TreeView1.Nodes("NVentas").Nodes("NPedidosDeClientes").Text = vDiccionario("NPedidosDeClientes").MensajeTraducido
        Me.TreeView1.Nodes("NVentas").Nodes("NEnvios").Text = vDiccionario("NEnvios").MensajeTraducido
        Me.TreeView1.Nodes("NContabilidad").Text = vDiccionario("NContabilidad").MensajeTraducido
        Me.TreeView1.Nodes("NContabilidad").Nodes("NValorizarMercaderia").Text = vDiccionario("NValorizarMercaderia").MensajeTraducido
        Me.TreeView1.Nodes("NContabilidad").Nodes("NListaDePrecios").Text = vDiccionario("NListaDePrecios").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Text = vDiccionario("NSistema").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Nodes("NGestionDePermisos").Text = vDiccionario("NGestionDePermisos").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Nodes("NGenerarBackUp").Text = vDiccionario("NGenerarBackUp").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Nodes("NRestaurarBaseDeDatos").Text = vDiccionario("NRestaurarBaseDeDatos").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Nodes("NVerificarIntegridad").Text = vDiccionario("NVerificarIntegridad").MensajeTraducido
        Me.TreeView1.Nodes("NSistema").Nodes("NBitacoraDeAuditoria").Text = vDiccionario("NBitacoraDeAuditoria").MensajeTraducido
        Me.TreeView1.Nodes("NIdioma").Text = vDiccionario("NIdioma").MensajeTraducido
        Me.TreeView1.Nodes("NIdioma").Nodes("NActualizarIdioma").Text = vDiccionario("NActualizarIdioma").MensajeTraducido
        Me.TreeView1.Nodes("NIdioma").Nodes("NCambiarIdioma").Text = vDiccionario("NCambiarIdioma").MensajeTraducido
        Me.TreeView1.Nodes("NInformes").Text = vDiccionario("NInformes").MensajeTraducido
        Me.TreeView1.Nodes("NInformes").Nodes("NMovimientos").Text = vDiccionario("NMovimientos").MensajeTraducido
        Me.TreeView1.Nodes("NInformes").Nodes("NMovimientos2").Text = vDiccionario("NMovimientos2").MensajeTraducido

    End Sub

    Private Shared ReadOnly LocalEncoding As System.Text.Encoding = System.Text.Encoding.UTF8
    Private Sub FormAyuda_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Actualizar(Me.Idioma)

        Dim vDocumento As New Documento With {
            .Nombre = "Ayuda"
        }
        Dim vDocumento_NEG As New Documento_NEG
        vDocumento_NEG.Consulta(vDocumento)
        'Prueba
        Dim directorioArchivo As String
        directorioArchivo = System.AppDomain.CurrentDomain.BaseDirectory() & "temp.pdf"

        Dim bytes() As Byte
        bytes = vDocumento.Cuerpo
        BytesAArchivo(bytes, directorioArchivo)
        AxAcroPDF2.src = directorioArchivo
        AxAcroPDF2.Show()
        'My.Computer.FileSystem.DeleteFile(directorioArchivo)

    End Sub

    Private Sub TreeView1_NodeMouseClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles TreeView1.NodeMouseClick

        Select Case e.Node.Name
            Case "NCompras"
                AxAcroPDF2.setCurrentPage(5)
            Case "NProveedores"
                AxAcroPDF2.setCurrentPage(5)
            Case "NArticulos"
                AxAcroPDF2.setCurrentPage(10)
            Case "NNotasDePedido"
                AxAcroPDF2.setCurrentPage(16)
            Case "NRemitos"
                AxAcroPDF2.setCurrentPage(19)
            Case "NVentas"
                AxAcroPDF2.setCurrentPage(23)
            Case "NClientes"
                AxAcroPDF2.setCurrentPage(23)
            Case "NPedidosDeClientes"
                AxAcroPDF2.setCurrentPage(27)
            Case "NEnvios"
                AxAcroPDF2.setCurrentPage(31)
            Case "NContabilidad"
                AxAcroPDF2.setCurrentPage(35)
            Case "NValorizarMercaderia"
                AxAcroPDF2.setCurrentPage(35)
            Case "NListaDePrecios"
                AxAcroPDF2.setCurrentPage(37)
            Case "NSistema"
                AxAcroPDF2.setCurrentPage(39)
            Case "NGestionDePermisos"
                AxAcroPDF2.setCurrentPage(40)
            Case "NGenerarBackUp"
                AxAcroPDF2.setCurrentPage(44)
            Case "NRestaurarBaseDeDatos"
                AxAcroPDF2.setCurrentPage(45)
            Case "NVerificarIntegridad"
                AxAcroPDF2.setCurrentPage(45)
            Case "NBitacoraDeAuditoria"
                AxAcroPDF2.setCurrentPage(45)
            Case "NIdioma"
                AxAcroPDF2.setCurrentPage(46)
            Case "NActualizarIdioma"
                AxAcroPDF2.setCurrentPage(46)
            Case "NCambiarIdioma"
                AxAcroPDF2.setCurrentPage(47)
            Case "NInformes"
                AxAcroPDF2.setCurrentPage(48)
            Case "NMovimientos"
                AxAcroPDF2.setCurrentPage(48)
            Case "NMovimientos2"
                AxAcroPDF2.setCurrentPage(48)
        End Select

    End Sub

    Private Sub BytesAArchivo(ByVal bytes() As Byte, ByVal Path As String)
        Dim K As Long
        If bytes Is Nothing Then Exit Sub
        Try
            K = UBound(bytes)
            Dim fs As New FileStream(Path, FileMode.OpenOrCreate, FileAccess.ReadWrite)
            fs.Write(bytes, 0, K)
            fs.Close()
        Catch ex As Exception
            Throw New Exception(ex.Message, ex)
        End Try
    End Sub

End Class