Imports BE
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormAcerca
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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormAcerca")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Text = vDiccionario("FormAcerca").MensajeTraducido

    End Sub

    Private Sub FormAcerca_ContextMenuStripChanged(sender As Object, e As EventArgs) Handles Me.ContextMenuStripChanged
        Actualizar(Me.Idioma)
    End Sub

End Class