Imports INTERFACES
Imports BLL_TECNICA
Imports BE

Public Class FormBitacoraCambios

    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)

    Private _Codigo As String
    Public Property Codigo() As String
        Get
            Return _Codigo
        End Get
        Set(ByVal value As String)
            _Codigo = value
        End Set
    End Property

    Private _NombreTabla As String
    Public Property NombreTabla() As String
        Get
            Return _NombreTabla
        End Get
        Set(ByVal value As String)
            _NombreTabla = value
        End Set
    End Property

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set
    End Property


    Private Sub FormBitacoraCambios_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If NombreTabla = "BitacoraUsuario" Then
            Dim vUsuarioTEC As New Usuario_TEC
            DGVCambios.DataSource = Nothing
            DGVCambios.DataSource = vUsuarioTEC.ConsultaCambios(Me.Codigo)
        End If
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormBitacoraCambios")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormBitacoraCambios").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

End Class