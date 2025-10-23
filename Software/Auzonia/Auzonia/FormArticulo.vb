Imports BE
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES

Public Class FormArticulo

    Implements IObservadores

    Dim vProveedorActual As Proveedor
    Dim vArticuloActual As ArticuloStock
    Dim vContexto As ContextoArticulo = ContextoArticulo.NuevaBusqueda
    Dim vArticuloNEG As New Articulo_NEG
    Dim vProveedorNEG As New Proveedor_NEG
    Dim vListaArticulos As List(Of ArticuloStock)
    Dim vListaProveedores As New List(Of Proveedor)
    Dim vListaDeTraducciones As New List(Of Traduccion)

    Enum ContextoArticulo

        NuevaBusqueda
        ArticuloSeleccionado
        ModicarArticulo
        CrearArticulo

    End Enum

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

#Region "Buttons"

    Private Sub BTNCrearArticulo_Click(sender As Object, e As EventArgs) Handles BTNCrearArticulo.Click

        If vContexto = ContextoArticulo.CrearArticulo Then
            Dim vNuevoArticulo As New ArticuloStock
            If TBCodigo.Text <> "" And TBDescripcion.Text <> "" And TBPuntoDeReposicion.Text <> "" And TBStockDeSeguridad.Text <> "" And TBStockFisico.Text <> "" Then
                Try
                    vNuevoArticulo.Codigo = TBCodigo.Text
                    vNuevoArticulo.Descripcion = TBDescripcion.Text
                    vNuevoArticulo.PuntoDeReposicion = TBPuntoDeReposicion.Text
                    vNuevoArticulo.StockDeSeguridad = TBStockDeSeguridad.Text
                    vNuevoArticulo.StockFisico = TBStockFisico.Text
                    vNuevoArticulo.IDProveedor = vProveedorActual.ID
                    vArticuloNEG.Alta(vNuevoArticulo)
                    MsgBox("El Artículo ha sido ingresado con éxito.")
                    ContextoNuevaBusqueda()
                Catch ex As Exception
                    MsgBox(ex.Message)
                End Try
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoArticulo.ModicarArticulo Then
            Dim vArticuloModificado As New ArticuloStock
            If TBCodigo.Text <> "" And TBDescripcion.Text <> "" And TBPuntoDeReposicion.Text <> "" And TBStockDeSeguridad.Text <> "" And TBStockFisico.Text <> "" Then
                vArticuloModificado.ID = vArticuloActual.ID
                vArticuloModificado.Codigo = TBCodigo.Text
                vArticuloModificado.Descripcion = TBDescripcion.Text
                vArticuloModificado.PuntoDeReposicion = TBPuntoDeReposicion.Text
                vArticuloModificado.StockDeSeguridad = TBStockDeSeguridad.Text
                vArticuloModificado.StockFisico = TBStockFisico.Text
                vArticuloModificado.IDProveedor = vProveedorActual.ID
                vArticuloNEG.Modificacion(vArticuloModificado)
                MsgBox("El articulo ha sido modificado con éxito.")
                LimpiarCamposArticulo()
                ContextoNuevaBusqueda()
            Else
                MsgBox("Debe completar todos los campos.")
            End If
        ElseIf vContexto = ContextoArticulo.NuevaBusqueda Or vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ContextoCrearArticulo()
        End If

    End Sub

    Private Sub BTNEliminar_Click(sender As Object, e As EventArgs) Handles BTNEliminar.Click
        Dim vRespuesta As MsgBoxResult
        vRespuesta = MsgBox("Está a punto de eliminar este artículo. ¿Desea continuar?", MsgBoxStyle.YesNo, "Borrar Articulo")
        If vRespuesta = MsgBoxResult.Yes Then
            Dim vArticulo As New ArticuloStock
            vArticulo.ID = DGVArticulos.SelectedRows(0).Cells(0).Value
            vArticuloNEG.Baja(vArticulo)
            MsgBox("El articulo fue eliminado exitosamente.")
            ContextoNuevaBusqueda()
        End If
    End Sub

    Private Sub BTNBuscar_Click(sender As Object, e As EventArgs) Handles BTNBuscar.Click

        If vContexto = ContextoArticulo.NuevaBusqueda Then

            Dim vNuevoArticulo As New ArticuloStock
            If TBCodigo.Text <> "" Then
                vNuevoArticulo.Codigo = TBCodigo.Text
            End If
            If TBDescripcion.Text <> "" Then
                vNuevoArticulo.Descripcion = TBDescripcion.Text
            End If
            If TBPuntoDeReposicion.Text <> "" Then
                vNuevoArticulo.PuntoDeReposicion = CInt(TBPuntoDeReposicion.Text)
            End If
            If TBStockDeSeguridad.Text <> "" Then
                vNuevoArticulo.StockDeSeguridad = CInt(TBStockDeSeguridad.Text)
            End If
            If TBStockFisico.Text <> "" Then
                vNuevoArticulo.StockFisico = CInt(TBStockFisico.Text)
            End If
            If Not vProveedorActual Is Nothing Then
                vNuevoArticulo.IDProveedor = vProveedorActual.ID
            End If
            ActualizarDGVArticulos(vNuevoArticulo)
        ElseIf vContexto = ContextoArticulo.CrearArticulo Then
            ContextoNuevaBusqueda()
        ElseIf vContexto = ContextoArticulo.ArticuloSeleccionado Or vContexto = ContextoArticulo.ModicarArticulo Then

            ContextoNuevaBusqueda()
            ContextoNuevaBusqueda()

        End If

    End Sub

    Private Sub BTNModificar_Click(sender As Object, e As EventArgs) Handles BTNModificar.Click

        If vArticuloActual Is Nothing Then
            MsgBox("Debe seleccionar al artículo que desea modificar. Haga clic en el botón Nueva Búsqueda.")
        Else
            ContextoModificarArticulo()
        End If

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

#End Region

#Region "Configuracion de contextos"

    Private Sub ContextoNuevaBusqueda()

        ' Cambia la variable del contexto. 
        vContexto = ContextoArticulo.NuevaBusqueda

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearArticulo.Visible = True
        BTNCrearArticulo.Text = "Crear Articulo"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Buscar"

        ' Adapta la variable al nuevo contexto.
        vArticuloActual = Nothing

        LimpiarCamposArticulo()
        HabilitarCamposArticulo()
        DGVArticulos.DataSource = Nothing

    End Sub

    Private Sub ContextoCrearArticulo()

        ' Cambia la variable del contexto. 
        vContexto = ContextoArticulo.CrearArticulo

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearArticulo.Visible = True
        BTNCrearArticulo.Text = "Guardar"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        ' Adapta la variable al nuevo contexto.
        vArticuloActual = Nothing

        LimpiarCamposArticulo()
        HabilitarCamposArticulo()

    End Sub

    Private Sub ContextoArticuloSeleccionado()

        ' Cambia la variable del contexto. 
        vContexto = ContextoArticulo.ArticuloSeleccionado

        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = True
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = True
        BTNEliminar.Text = "Eliminar"
        BTNCrearArticulo.Visible = True
        BTNCrearArticulo.Text = "Crear Articulo"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Nueva Búsqueda"

        ' Adapta la variable al nuevo contexto.
        SeleccionarArticulo()

        LimpiarCamposArticulo()
        CompletarCamposArticulo()

    End Sub

    Private Sub ContextoModificarArticulo()

        ' Cambia la variable del contexto. 
        vContexto = ContextoArticulo.ModicarArticulo
        ' Adapta los botones al nuevo contexto.
        BTNModificar.Visible = False
        BTNModificar.Text = "Modificar"
        BTNEliminar.Visible = False
        BTNEliminar.Text = "Eliminar"
        BTNCrearArticulo.Visible = True
        BTNCrearArticulo.Text = "Guardar Cambios"
        BTNBuscar.Visible = True
        BTNBuscar.Text = "Cancelar"

        HabilitarCamposArticulo()

    End Sub

#End Region

    ' Limpia los campos del usuario en el formulario.
    Public Sub LimpiarCamposArticulo()

        TBCodigo.Text = ""
        TBDescripcion.Text = ""
        TBPuntoDeReposicion.Text = ""
        TBStockDeSeguridad.Text = ""
        TBStockFisico.Text = ""

    End Sub

    ' Habilita los campos del usuario en el formulario.
    Public Sub HabilitarCamposArticulo()

        TBCodigo.Enabled = True
        TBDescripcion.Enabled = True
        TBPuntoDeReposicion.Enabled = True
        TBStockDeSeguridad.Enabled = True
        TBStockFisico.Enabled = True

    End Sub

    ' Completa los campos del formulario con los datos del proveedor seleccionado en el DGV.
    Public Sub CompletarCamposArticulo()

        TBCodigo.Enabled = False
        TBDescripcion.Enabled = False
        TBPuntoDeReposicion.Enabled = False
        TBStockDeSeguridad.Enabled = False
        TBStockFisico.Enabled = False

        ' Recorre la lista de proveedores según el ID y asigna a la variable vArticuloSeleccionado el proveedor coincidente 
        ' con el proveedor seleccionado en DGVArticuloes.
        SeleccionarArticulo()

        If DGVArticulos.SelectedRows.Count > 0 Then
            TBCodigo.Text = DGVArticulos.SelectedRows(0).Cells(8).Value
            TBDescripcion.Text = DGVArticulos.SelectedRows(0).Cells(9).Value
            TBPuntoDeReposicion.Text = DGVArticulos.SelectedRows(0).Cells(0).Value
            TBStockDeSeguridad.Text = DGVArticulos.SelectedRows(0).Cells(1).Value
            TBStockFisico.Text = DGVArticulos.SelectedRows(0).Cells(2).Value
        End If

    End Sub

    ' Asigna a la varieble vArticuloSeleccionado el usuario seleccionado en DGVArticulos. 
    Public Sub SeleccionarArticulo()

        If DGVArticulos.SelectedRows.Count > 0 Then
            Dim vID As String = DGVArticulos.SelectedRows.Item(0).Cells.Item(7).Value.ToString
            If Not vListaArticulos Is Nothing Then
                For Each vArticulo As Articulo In vListaArticulos
                    If vArticulo.ID = vID Then
                        vArticuloActual = vArticulo
                    End If
                Next
            End If
        End If

    End Sub

    Private Sub ActualizarDGVArticulos(ByRef pArticulo As ArticuloStock)
        Dim vArticuloNEG As New Articulo_NEG()
        vListaArticulos = vArticuloNEG.ConsultaVarios(pArticulo)
        DGVArticulos.DataSource = Nothing
        DGVArticulos.DataSource = vListaArticulos
        DGVArticulos.Columns("Codigo").DisplayIndex = 0
        DGVArticulos.Columns("Codigo").Width = 116
        DGVArticulos.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Codigo").HeaderText = "Código"
        DGVArticulos.Columns("Descripcion").DisplayIndex = 1
        DGVArticulos.Columns("Descripcion").Width = 315
        DGVArticulos.Columns("Descripcion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticulos.Columns("ID").Visible = False
        DGVArticulos.Columns("IDProveedor").Visible = False
        DGVArticulos.Columns("PuntoDeReposicion").HeaderText = "Punto de Reposición"
        DGVArticulos.Columns("PuntoDeReposicion").Width = 70
        DGVArticulos.Columns("PuntoDeReposicion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("PuntoDeReposicion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("StockDeSeguridad").HeaderText = "Stock de Seguridad"
        DGVArticulos.Columns("StockDeSeguridad").Width = 70
        DGVArticulos.Columns("StockDeSeguridad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("StockDeSeguridad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("StockFisico").HeaderText = "Stock Físico"
        DGVArticulos.Columns("StockFisico").Width = 70
        DGVArticulos.Columns("StockFisico").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("StockFisico").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Reservadas").Width = 70
        DGVArticulos.Columns("Reservadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Reservadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("PendientesDeEntrega").HeaderText = "Pendientes de Entrega"
        DGVArticulos.Columns("PendientesDeEntrega").Width = 70
        DGVArticulos.Columns("PendientesDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("PendientesDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("PendientesDeIngreso").HeaderText = "Pendientes de Ingreso"
        DGVArticulos.Columns("PendientesDeIngreso").Width = 70
        DGVArticulos.Columns("PendientesDeIngreso").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("PendientesDeIngreso").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Disponible").Width = 70
        DGVArticulos.Columns("Disponible").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticulos.Columns("Disponible").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormArticulo")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormArticulo").MensajeTraducido
        Me.LbProveedor.Text = vDiccionario("LbProveedor").MensajeTraducido
        Me.LbCodigo.Text = vDiccionario("LbCodigo").MensajeTraducido
        Me.LbDescripcion.Text = vDiccionario("LbDescripcion").MensajeTraducido
        Me.GBResultados.Text = vDiccionario("GBResultados").MensajeTraducido
        Me.LbPuntoDeReposicion.Text = vDiccionario("LbPuntoDeReposicion").MensajeTraducido
        Me.LbStockDeSeguridad.Text = vDiccionario("LbStockDeSeguridad").MensajeTraducido
        Me.LbStockFisico.Text = vDiccionario("LbStockFisico").MensajeTraducido
        Me.BTNCrearArticulo.Text = vDiccionario("BTNCrearArticulo").MensajeTraducido
        Me.BTNBuscar.Text = vDiccionario("BTNBuscar").MensajeTraducido
        Me.BTNModificar.Text = vDiccionario("BTNModificar").MensajeTraducido
        Me.BTNEliminar.Text = vDiccionario("BTNEliminar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido


    End Sub

#End Region

#Region "Eventos"

    Private Sub TBPuntoDeReposicion_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBPuntoDeReposicion.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBStockDeSeguridad_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBStockDeSeguridad.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub TBStockFisico_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TBStockFisico.KeyPress
        If Not IsNumeric(e.KeyChar) And Not e.KeyChar = vbBack Then
            e.Handled = True
        End If
    End Sub

    Private Sub DGVArticulos_SelectionChanged(sender As Object, e As EventArgs) Handles DGVArticulos.SelectionChanged

        If DGVArticulos.SelectedRows IsNot Nothing Then
            ContextoArticuloSeleccionado()
        End If

    End Sub

    Private Sub FormArticulo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vContexto = ContextoArticulo.NuevaBusqueda
        Dim vProveedor As New Proveedor
        vListaProveedores = vProveedorNEG.ConsultaVarios(vProveedor)
        CBProveedor.DataSource = vListaProveedores
        CBProveedor.DisplayMember = "RazonSocial"
        Actualizar(Me.Idioma)
    End Sub

    Private Sub CBProveedor_SelectedValueChanged(sender As Object, e As EventArgs) Handles CBProveedor.SelectedValueChanged

        vProveedorActual = CBProveedor.SelectedItem
        Dim vArticuloDeConsulta As New ArticuloStock
        vArticuloDeConsulta.IDProveedor = vProveedorActual.ID
        ActualizarDGVArticulos(vArticuloDeConsulta)

    End Sub

#End Region

#Region "Ayuda en línea"

    Private Sub CBProveedor_MouseHover(sender As Object, e As EventArgs) Handles CBProveedor.MouseHover

        ToolTip.SetToolTip(CBProveedor, "Seleccione el proveedor que desea actualizar.")
        ToolTip.ToolTipTitle = "Proveedor"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

    Private Sub TBCodigo_MouseHover(sender As Object, e As EventArgs) Handles TBCodigo.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(TBCodigo, "Ingrese aquí el Código del artículo a buscar.")
            ToolTip.ToolTipTitle = "Código"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(TBCodigo, "No es posible modificar el Códio del artículo desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Código"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(TBCodigo, "Ingrese aquí el Código del artículo a modificar.")
            ToolTip.ToolTipTitle = "Código"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBCodigo, "Ingrese aquí el Código del artículo a crear.")
            ToolTip.ToolTipTitle = "Código"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBDescripcion_MouseHover(sender As Object, e As EventArgs) Handles TBDescripcion.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(TBDescripcion, "Ingrese aquí la Descripción del artículo a buscar.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(TBDescripcion, "No es posible modificar la Descripción del artículo desde el contexto actual. Para modificarlo haga clic en Modificar.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(TBDescripcion, "Ingrese aquí la Descripción del artículo a modificar.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBDescripcion, "Ingrese aquí la Descripción del artículo a crear.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBPuntoDeReposicion_MouseHover(sender As Object, e As EventArgs) Handles TBPuntoDeReposicion.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(TBPuntoDeReposicion, "El Punto de Reposición es la cantidad mínima de existencia de un artículo, de modo que cuando el stock llegue a esa cantidad, el artículo debe reordenarse.")
            ToolTip.ToolTipTitle = "Punto de Reposicion"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(TBPuntoDeReposicion, "El Punto de Reposición es la cantidad mínima de existencia de un artículo, de modo que cuando el stock llegue a esa cantidad, el artículo debe reordenarse.")
            ToolTip.ToolTipTitle = "Punto de Reposicion"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(TBPuntoDeReposicion, "El Punto de Reposición es la cantidad mínima de existencia de un artículo, de modo que cuando el stock llegue a esa cantidad, el artículo debe reordenarse.")
            ToolTip.ToolTipTitle = "Punto de Reposicion"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBDescripcion, "El Punto de Reposición es la cantidad mínima de existencia de un artículo, de modo que cuando el stock llegue a esa cantidad, el artículo debe reordenarse.")
            ToolTip.ToolTipTitle = "Punto de Reposicion"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBStockDeSeguridad_MouseHover(sender As Object, e As EventArgs) Handles TBStockDeSeguridad.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(TBStockDeSeguridad, "El Stock de Seguridad se calcula tomando en consideración la cantidad del artículo necesaria para cubrir una variación de la demanda y un riesgo proveedor.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(TBStockDeSeguridad, "El Stock de Seguridad se calcula tomando en consideración la cantidad del artículo necesaria para cubrir una variación de la demanda y un riesgo proveedor.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(TBStockDeSeguridad, "El Stock de Seguridad se calcula tomando en consideración la cantidad del artículo necesaria para cubrir una variación de la demanda y un riesgo proveedor.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBStockDeSeguridad, "El Stock de Seguridad se calcula tomando en consideración la cantidad del artículo necesaria para cubrir una variación de la demanda y un riesgo proveedor.")
            ToolTip.ToolTipTitle = "Descripción"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub TBStockFisico_MouseHover(sender As Object, e As EventArgs) Handles TBStockFisico.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(TBStockFisico, "Número de unidades de productos que se encuentran disponibles en el depósito.")
            ToolTip.ToolTipTitle = "Stock Físico"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(TBStockFisico, "Número de unidades de productos que se encuentran disponibles en el depósito.")
            ToolTip.ToolTipTitle = "Stock Físico"
            ToolTip.ToolTipIcon = ToolTipIcon.Error
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(TBStockFisico, "Número de unidades de productos que se encuentran disponibles en el depósito.")
            ToolTip.ToolTipTitle = "Stock Físico"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(TBStockFisico, "Número de unidades de productos que se encuentran disponibles en el depósito.")
            ToolTip.ToolTipTitle = "Stock Físico"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNCrearArticulo_MouseHover(sender As Object, e As EventArgs) Handles BTNCrearArticulo.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNCrearArticulo, "Haga clic aquí para crear un nuevo Artículo.")
            ToolTip.ToolTipTitle = "Crear Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(BTNCrearArticulo, "Haga clic aquí para crear un nuevo Artículo.")
            ToolTip.ToolTipTitle = "Crear Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(BTNCrearArticulo, "Haga clic aquí para guardar los cambios del Artículo seleccionado.")
            ToolTip.ToolTipTitle = "Crear Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNCrearArticulo, "Haga clic aquí para confirmar el alta del Artículo.")
            ToolTip.ToolTipTitle = "Crear Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNBuscar_MouseHover(sender As Object, e As EventArgs) Handles BTNBuscar.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para ejecturar la búsqueda.")
            ToolTip.ToolTipTitle = "Buscar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para realizar una nueva búsqueda.")
            ToolTip.ToolTipTitle = "Buscar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para cancelar los cambios.")
            ToolTip.ToolTipTitle = "Buscar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNBuscar, "Haga clic aquí para cancelar el alta del artículo.")
            ToolTip.ToolTipTitle = "Buscar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        End If

    End Sub

    Private Sub BTNModificar_MouseHover(sender As Object, e As EventArgs) Handles BTNModificar.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNModificar, "")
            ToolTip.ToolTipTitle = "Modificar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(BTNModificar, "Haga clic aquí para modificar el artículo seleccionado.")
            ToolTip.ToolTipTitle = "Modificar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(BTNModificar, "")
            ToolTip.ToolTipTitle = "Modificar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        Else
            ToolTip.SetToolTip(BTNModificar, "")
            ToolTip.ToolTipTitle = "Modificar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Info
        End If

    End Sub

    Private Sub BTNEliminar_MouseHover(sender As Object, e As EventArgs) Handles BTNEliminar.MouseHover

        If Me.vContexto = ContextoArticulo.NuevaBusqueda Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el Artículo seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        ElseIf Me.vContexto = ContextoArticulo.ArticuloSeleccionado Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el Artículo seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        ElseIf Me.vContexto = ContextoArticulo.ModicarArticulo Then
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el Artículo seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        Else
            ToolTip.SetToolTip(BTNEliminar, "Haga clic aquí para eliminar el Artículo seleccionado.")
            ToolTip.ToolTipTitle = "Eliminar Artículo"
            ToolTip.ToolTipIcon = ToolTipIcon.Warning
        End If

    End Sub

#End Region

End Class