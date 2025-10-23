Imports INTERFACES
Imports BLL_TECNICA
Imports BE
Imports Microsoft.Reporting.WinForms
Imports System.ComponentModel

Public Class FormInformesMovimientos

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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormInformeMovimientos")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormInformeMovimientos").MensajeTraducido

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub FormInformesMovimientos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'AuzoniaDataSet.MovimientoSalidas' Puede moverla o quitarla según sea necesario.
        Dim _objetoConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=Auzonia;Integrated Security=True")
        Me.MovimientoSalidasTableAdapter.Connection = _objetoConexion
        Me.MovimientoSalidasTableAdapter.Fill(Me.AuzoniaDataSet.MovimientoSalidas)
        Actualizar(Me.Idioma)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub ReportViewer1_ReportRefresh(sender As Object, e As CancelEventArgs) Handles ReportViewer1.ReportRefresh
        Me.MovimientoSalidasTableAdapter.Fill(Me.AuzoniaDataSet.MovimientoSalidas)
        Me.ReportViewer1.RefreshReport()
    End Sub

End Class