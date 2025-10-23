Imports BE
Imports BLL_NEGOCIO
Imports INTERFACES
Imports BLL_TECNICA

Public Class FormNuevaListaCompras

    Implements IObservadores

    Dim vListaDeTraducciones As New List(Of Traduccion)

    Private _Proveedor As Proveedor
    Public Property Proveedor() As Proveedor
        Get
            Return _Proveedor
        End Get
        Set(ByVal value As Proveedor)
            _Proveedor = value
        End Set
    End Property

    Private _FormListaDePrecios As FormListaDePrecios
    Public Property FormListaDePrecios() As FormListaDePrecios
        Get
            Return _FormListaDePrecios
        End Get
        Set(ByVal value As FormListaDePrecios)
            _FormListaDePrecios = value
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

#Region "Procedimientos"

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormNuevaListaCompras")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormNuevaListaCompras").MensajeTraducido
        Me.lbNumero.Text = vDiccionario("lbNumero").MensajeTraducido
        Me.lbVigenciaDesde.Text = vDiccionario("lbVigenciaDesde").MensajeTraducido
        Me.BTNAceptar.Text = vDiccionario("BTNAceptar").MensajeTraducido

    End Sub

#End Region

#Region "Eventos"

    Private Sub FormNuevaListaCompras_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Actualizar(Me.Idioma)
    End Sub

    Private Sub BTNAceptar_Click(sender As Object, e As EventArgs) Handles BTNAceptar.Click

        If TBNumero.Text <> Nothing Then
            Dim vNuevaListaCompra As New ListaDePreciosCompra
            Dim vListaDePreciosVentaNEG As New ListaDePreciosCompra_NEG
            vNuevaListaCompra.Numero = TBNumero.Text
            vNuevaListaCompra.FechaDeInicioVigencia = DTPFechaInicioVigencia.Value
            vNuevaListaCompra.Proveedor = Me.Proveedor
            vListaDePreciosVentaNEG.Alta(vNuevaListaCompra)
            MsgBox("La nueva lista ha sido dada de alta con éxito.")
            Me.FormListaDePrecios.ActualizarListaDePreciosCompra()
            Me.Close()
        Else
            MsgBox("Ingrese el número de lista.")
        End If

    End Sub

#Region "Ayuda en línea"

    Private Sub BTNAceptar_MouseHover(sender As Object, e As EventArgs) Handles BTNAceptar.MouseHover
        ToolTip.SetToolTip(BTNAceptar, "Haga clic aquí para confirmar la nueva lista de compras.")
        ToolTip.ToolTipTitle = "Aceptar"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TBNumero_MouseHover(sender As Object, e As EventArgs) Handles TBNumero.MouseHover
        ToolTip.SetToolTip(TBNumero, "Ingrese aquí el número de la nueva lista de compras.")
        ToolTip.ToolTipTitle = "Número"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

#End Region

#End Region

End Class