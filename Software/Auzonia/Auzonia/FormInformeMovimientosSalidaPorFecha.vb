Imports INTERFACES
Imports BLL_TECNICA
Imports BE

Public Class FormInformeMovimientosSalidaPorFecha

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
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormInformeMovimientosSalidaPorFecha")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormInformeMovimientosSalidaPorFecha").MensajeTraducido
        Me.lbDesde.Text = vDiccionario("lbDesde").MensajeTraducido
        Me.lbHasta.Text = vDiccionario("lbHasta").MensajeTraducido
        Me.BTNActualizar.Text = vDiccionario("BTNActualizar").MensajeTraducido

    End Sub

    Private Sub FormInformeMovimientosSalidaPorFecha_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: esta línea de código carga datos en la tabla 'AuzoniaDataSet1.MovimientoSalidasPorFecha' Puede moverla o quitarla según sea necesario.
        Dim _objetoConexion As SqlClient.SqlConnection = New SqlClient.SqlConnection("Data Source=.\SQLEXPRESS;Initial Catalog=Auzonia;Integrated Security=True")
        Me.MovimientoSalidasPorFechaTableAdapter.Connection = _objetoConexion
        Me.MovimientoSalidasPorFechaTableAdapter.Fill(Me.AuzoniaDataSet1.MovimientoSalidasPorFecha, DTPFDesde.Value, DTPFHasta.Value)
        Me.ReportViewer1.RefreshReport()
        Actualizar(Me.Idioma)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles BTNActualizar.Click
        Me.MovimientoSalidasPorFechaTableAdapter.Fill(Me.AuzoniaDataSet1.MovimientoSalidasPorFecha, DTPFDesde.Value, DTPFHasta.Value)
        Me.ReportViewer1.RefreshReport()
    End Sub

    Private Sub BTNActualizar_MouseHover(sender As Object, e As EventArgs) Handles BTNActualizar.MouseHover

        ToolTip.SetToolTip(BTNActualizar, "Haga clic aquí para actualizar el reporte.")
        ToolTip.ToolTipTitle = "Actualizar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

End Class