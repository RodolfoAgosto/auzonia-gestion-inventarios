Imports BE
Imports SEGURIDAD
Imports BLL_NEGOCIO
Imports BLL_TECNICA
Imports INTERFACES


Public Class FormNotaDeEnvio

    Implements IObservadores

    Enum Contexto
        Inicio
        NotaDeEnvioEnCurso
        NuevaNotaDeEnvio
    End Enum


#Region "Trabajo en Curso"

    'Contexto
    Dim vContexto As Contexto

    'Vendedor
    Dim vListaDeVendedores As List(Of Usuario_SEG)
    Dim vVendedorSeleccionado As Usuario_SEG
    Dim vVendedorTEC As New Usuario_TEC

    'Cliente
    Dim vDictionaryClientes As New Dictionary(Of Integer, Cliente)
    Dim vListaDeClientes As List(Of Cliente)
    Dim vClienteSeleccionado As Cliente
    Dim vClienteNEG As New Cliente_NEG

    'Pedido de Cliene
    Dim vDictionaryPedidoDeCliente As New Dictionary(Of Integer, PedidoDeCliente)
    Dim vListaDePedidoDeCliente As List(Of PedidoDeCliente)
    Dim vPedidoDeClienteSeleccionado As PedidoDeCliente
    Dim vPedidoDeClienteNEG As New PedidoDeCliente_NEG

    'Articulos
    Dim vDictionaryArticuloDePedidoDeCliente As New Dictionary(Of Integer, ArticuloPedidoDeCliente)
    Dim vListaArticulos As List(Of ArticuloPedidoDeCliente)
    Dim vArticulo_NEG As New Articulo_NEG

    'Nota de Envio
    Private _NotaDeEnvio As NotaDeEnvio
    Public Property NotaDeEnvio() As NotaDeEnvio
        Get
            Return _NotaDeEnvio
        End Get
        Set(ByVal value As NotaDeEnvio)
            _NotaDeEnvio = value
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

    Dim vNotaDeEnvioNEG As New NotaDeEnvio_NEG

    Private Sub FormNotaDeEnvio_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        vContexto = Contexto.Inicio
        'Actualiza el Combobox con todos los vendedores
        ActualizarCBVendedor()

    End Sub

    Private Sub ActualizarCBVendedor()
        Dim vVendedor As New Usuario_SEG
        vListaDeVendedores = vVendedorTEC.ConsultaVarios(vVendedor)
        CBVendedor.DataSource = vListaDeVendedores
        CBVendedor.DisplayMember = "NombreCompleto"
    End Sub

    Private Sub SeleccionarVendedor()

        'Actualiza la variables del vendedor actual.
        vVendedorSeleccionado = CBVendedor.SelectedItem
        ' Actualiza el DGVClientes y selecciona el cliente
        ActualizarDGVClientes()
        SeleccionarCliente()

        Dim vDeshabilitarEdicionNE As Boolean = False
        vDeshabilitarEdicionNE = vNotaDeEnvioNEG.NotaDeEnvioEnCurso(vVendedorSeleccionado)

        If vDeshabilitarEdicionNE Then
            vContexto = Contexto.NotaDeEnvioEnCurso
            If TC.SelectedIndex = 0 Then
                MsgBox("El vendedor actual posee una nota de envio en curso. No podrá generar una nueva hasta finalizar la gestión.")
            End If
            lbAdvertencia.Text = "Nota de envio en curso."
            TBComentarios.Enabled = False
            BTNGenerarEnvio.Enabled = False
            DGVArticuloPedidoDeCliente.Columns("Enviar").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.BackColor = Color.White
            BTNAgregar.Enabled = False
            BTNCancelarPedidoDeCliente.Enabled = False
            DTPFentregaNE.Enabled = False
        Else
            vContexto = Contexto.NuevaNotaDeEnvio
            DGVArticuloPedidoDeCliente.Columns("Enviar").ReadOnly = False
            DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
            BTNAgregar.Enabled = True
            BTNCancelarPedidoDeCliente.Enabled = True
            TBComentarios.Enabled = True
            BTNGenerarEnvio.Enabled = True
            lbAdvertencia.Text = ""
            DTPFentregaNE.Enabled = True
        End If
        BTNAgregar_Click(Nothing, Nothing)
    End Sub

    Private Sub ActualizarDGVClientes()
        ' Actualiza el DGVClientes con los clientes del vendedor seleccionado.
        ' Devuelve la lista de clientes con sus pedidos y sus pedidos con sus artículos.
        Dim vCliente As New Cliente
        If Not vVendedorSeleccionado Is Nothing Then
            vCliente.IDVendedor = vVendedorSeleccionado.ID
            vListaDeClientes = vClienteNEG.ConsultaVarios(vCliente)
            For Each v1Cliente As Cliente In vListaDeClientes
                Dim vPedidoDeCliente As New PedidoDeCliente
                vPedidoDeCliente.Cliente = v1Cliente
                v1Cliente.ListaPedidoDeCliente = vPedidoDeClienteNEG.ConsultaVarios(vPedidoDeCliente)
                'Completa los articulos del pedido de cliente.
                For Each v1PedidoDeCliente As PedidoDeCliente In v1Cliente.ListaPedidoDeCliente
                    vPedidoDeClienteNEG.Consulta(v1PedidoDeCliente)
                Next
            Next
            'Carla el diccionario de clientes.
            vDictionaryClientes.Clear()
            For Each vC As Cliente In vListaDeClientes
                vDictionaryClientes.Add(vC.ID, vC)
            Next
            DGVClientes.DataSource = Nothing
            DGVClientes.DataSource = vListaDeClientes
            'ID
            DGVClientes.Columns("ID").Width = 50
            DGVClientes.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Razón Social
            DGVClientes.Columns("RazonSocial").HeaderText = "Razón Social"
            DGVClientes.Columns("RazonSocial").Width = 110
            DGVClientes.Columns("RazonSocial").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'CUIT
            DGVClientes.Columns("CUIT").Width = 80
            DGVClientes.Columns("CUIT").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("CUIT").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Calle
            DGVClientes.Columns("Calle").Width = 100
            DGVClientes.Columns("Calle").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Número
            DGVClientes.Columns("Numero").HeaderText = "Número"
            DGVClientes.Columns("Numero").Width = 60
            DGVClientes.Columns("Numero").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("Numero").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Teléfono
            DGVClientes.Columns("Telefono").HeaderText = "Teléfono"
            DGVClientes.Columns("Telefono").Width = 80
            DGVClientes.Columns("Telefono").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Email
            DGVClientes.Columns("Email").Width = 110
            DGVClientes.Columns("Email").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'Nombre Contacto
            DGVClientes.Columns("NombreContacto").HeaderText = "Nombre Contacto"
            DGVClientes.Columns("NombreContacto").Width = 115
            DGVClientes.Columns("NombreContacto").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            'ID Vendedor
            DGVClientes.Columns("IDVendedor").HeaderText = "ID Vendedor"
            DGVClientes.Columns("IDVendedor").Width = 90
            DGVClientes.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
            DGVClientes.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter

        End If
    End Sub

    Private Sub SeleccionarCliente()
        If DGVClientes.SelectedRows.Count > 0 Then
            vClienteSeleccionado = vDictionaryClientes(CInt(DGVClientes.SelectedRows(0).Cells(0).Value))
            TBIDCliente.Text = vClienteSeleccionado.ID
            TBRazonSocial.Text = vClienteSeleccionado.RazonSocial
        Else
            vClienteSeleccionado = Nothing
            vPedidoDeClienteSeleccionado = Nothing
        End If
        ActualizarDGVPedidoDeCliente()
    End Sub

    Private Sub ActualizarDGVPedidoDeCliente()

        'Actualiza el DGVPedidosDeCliente con los pedidos del cliente seleccionado.
        DGVPedidoDeCliente.DataSource = Nothing
        If Not vClienteSeleccionado Is Nothing Then
            If Not vClienteSeleccionado.ListaPedidoDeCliente Is Nothing Then
                vListaDePedidoDeCliente = vClienteSeleccionado.ListaPedidoDeCliente
                DGVPedidoDeCliente.ClearSelection()
                DGVPedidoDeCliente.DataSource = vClienteSeleccionado.ListaPedidoDeCliente
                'Carga el diccionario de clientes.
                vDictionaryPedidoDeCliente.Clear()
                For Each vPC As PedidoDeCliente In vClienteSeleccionado.ListaPedidoDeCliente
                    vDictionaryPedidoDeCliente.Add(vPC.ID, vPC)
                Next
            Else
                Dim vListaPedidoDeCliente As New List(Of PedidoDeCliente)
                DGVPedidoDeCliente.DataSource = vListaPedidoDeCliente
            End If
        Else
            Dim vListaPedidoDeCliente As New List(Of PedidoDeCliente)
            DGVPedidoDeCliente.DataSource = vListaPedidoDeCliente
        End If
        DGVPedidoDeCliente.Columns(0).Width = 40
        DGVPedidoDeCliente.Columns(1).Visible = False
        DGVPedidoDeCliente.Columns(4).Visible = False
        'ID
        DGVPedidoDeCliente.Columns("ID").Width = 50
        DGVPedidoDeCliente.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVPedidoDeCliente.Columns("FechaDeCreacion").Width = 80
        DGVPedidoDeCliente.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVPedidoDeCliente.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVPedidoDeCliente.Columns("FechaDeEntrega").Width = 80
        DGVPedidoDeCliente.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVPedidoDeCliente.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Estado
        DGVPedidoDeCliente.Columns("Estado").Width = 87
        DGVPedidoDeCliente.Columns("Estado").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPedidoDeCliente.Columns("Estado").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        SeleccionarPedidoDeCliente()

    End Sub

    Private Sub SeleccionarPedidoDeCliente()
        If DGVPedidoDeCliente.SelectedRows.Count > 0 Then
            vPedidoDeClienteSeleccionado = vDictionaryPedidoDeCliente(CInt(DGVPedidoDeCliente.SelectedRows(0).Cells(0).Value))
            DTPFechaDeEntrega.Value = vPedidoDeClienteSeleccionado.FechaDeEntrega
        Else
            vPedidoDeClienteSeleccionado = Nothing
        End If
        ActualizarListaDeArticulos()
    End Sub

    Private Sub ActualizarListaDeArticulos()

        DGVArticuloPedidoDeCliente.DataSource = Nothing

        If Not vPedidoDeClienteSeleccionado Is Nothing Then
            If Not vPedidoDeClienteSeleccionado.ListaDeArticulos Is Nothing Then
                DGVArticuloPedidoDeCliente.DataSource = vPedidoDeClienteSeleccionado.ListaDeArticulos
                'Carga el diccionario de artículos.
                vDictionaryArticuloDePedidoDeCliente.Clear()
                For Each vAPC As ArticuloPedidoDeCliente In vPedidoDeClienteSeleccionado.ListaDeArticulos
                    vDictionaryArticuloDePedidoDeCliente.Add(vAPC.ID, vAPC)
                Next
            Else
                Dim vListaArticuloPedidoDeCliente As New List(Of ArticuloPedidoDeCliente)
                DGVArticuloPedidoDeCliente.DataSource = vListaArticuloPedidoDeCliente
            End If
        Else
            Dim vListaArticuloPedidoDeCliente As New List(Of ArticuloPedidoDeCliente)
            DGVArticuloPedidoDeCliente.DataSource = vListaArticuloPedidoDeCliente
        End If

        'ID
        DGVArticuloPedidoDeCliente.Columns("ID").DisplayIndex = 0
        DGVArticuloPedidoDeCliente.Columns("ID").Width = 44
        DGVArticuloPedidoDeCliente.Columns("ID").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloPedidoDeCliente.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Codigo
        DGVArticuloPedidoDeCliente.Columns("Codigo").DisplayIndex = 1
        DGVArticuloPedidoDeCliente.Columns("Codigo").Width = 150
        DGVArticuloPedidoDeCliente.Columns("Codigo").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("Codigo").HeaderText = "Código"
        'Descripción
        DGVArticuloPedidoDeCliente.Columns("Descripcion").DisplayIndex = 2
        DGVArticuloPedidoDeCliente.Columns("Descripcion").Width = 254
        DGVArticuloPedidoDeCliente.Columns("Descripcion").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("Descripcion").HeaderText = "Descripción"
        'Solicitadas
        DGVArticuloPedidoDeCliente.Columns("Solicitadas").DisplayIndex = 3
        DGVArticuloPedidoDeCliente.Columns("Solicitadas").Width = 65
        DGVArticuloPedidoDeCliente.Columns("Solicitadas").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("Solicitadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloPedidoDeCliente.Columns("Solicitadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Reservadas
        DGVArticuloPedidoDeCliente.Columns("Reservadas").DisplayIndex = 4
        DGVArticuloPedidoDeCliente.Columns("Reservadas").Width = 65
        DGVArticuloPedidoDeCliente.Columns("Reservadas").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("Reservadas").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloPedidoDeCliente.Columns("Reservadas").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Pendientes
        DGVArticuloPedidoDeCliente.Columns("Pendientes").DisplayIndex = 5
        DGVArticuloPedidoDeCliente.Columns("Pendientes").Width = 65
        DGVArticuloPedidoDeCliente.Columns("Pendientes").ReadOnly = True
        DGVArticuloPedidoDeCliente.Columns("Pendientes").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloPedidoDeCliente.Columns("Pendientes").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Enviar
        DGVArticuloPedidoDeCliente.Columns("Enviar").DisplayIndex = 6
        DGVArticuloPedidoDeCliente.Columns("Enviar").Width = 66
        DGVArticuloPedidoDeCliente.Columns("Enviar").ReadOnly = False
        DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
        DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloPedidoDeCliente.Columns("Enviar").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        If vContexto = Contexto.NotaDeEnvioEnCurso Then
            DGVArticuloPedidoDeCliente.Columns("Enviar").ReadOnly = True
            DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.BackColor = Color.White
            DTPFentregaNE.Enabled = False
        Else
            DGVArticuloPedidoDeCliente.Columns("Enviar").ReadOnly = False
            DGVArticuloPedidoDeCliente.Columns("Enviar").DefaultCellStyle.BackColor = Color.FromArgb(210, 227, 252)
            DTPFentregaNE.Enabled = True
        End If

        DGVArticuloPedidoDeCliente.Columns("IDProveedor").Visible = False

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub CBVendedor_SelectedValueChanged1(sender As Object, e As EventArgs) Handles CBVendedor.SelectedValueChanged
        If Not vContexto = Contexto.Inicio Then
            TBIDCliente.Text = ""
            TBRazonSocial.Text = ""
            TBComentariosHistorial.Text = ""
            TBComentarios.Text = ""
            DGVClientes.DataSource = Nothing
            DGVPedidoDeCliente.DataSource = Nothing
            DGVArticuloPedidoDeCliente.DataSource = Nothing
            SeleccionarVendedor()
        Else
            vContexto = Contexto.NuevaNotaDeEnvio
        End If
    End Sub

    Private Sub DGVClientes_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVClientes.CellClick

    End Sub

    Private Sub DGVPedidoDeCliente_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DGVPedidoDeCliente.CellClick
        SeleccionarPedidoDeCliente()
    End Sub

    Private Sub BTNAgregar_Click(sender As Object, e As EventArgs) Handles BTNAgregar.Click

        Me.NotaDeEnvio = New NotaDeEnvio
        Me.NotaDeEnvio.ListaDeArticuloDeEnvio = New List(Of ArticuloNotaDeEnvio)
        Me.NotaDeEnvio.ListaDeArticuloDeEnvio.Clear()
        vNotaDeEnvioNEG.CompletarArticulos(vListaDeClientes, Me.NotaDeEnvio)
        Me.NotaDeEnvio.IDVendedor = vVendedorSeleccionado.ID
        vNotaDeEnvioNEG.NotaDeEnvioTrabajoEnCurso(Me.NotaDeEnvio)
        TBComentariosHistorial.Text = Me.NotaDeEnvio.Comentarios
        DGVArticuloNotaDeEnvio.DataSource = Nothing
        DGVArticuloNotaDeEnvio.DataSource = Me.NotaDeEnvio.ListaDeArticuloDeEnvio

        DGVArticuloNotaDeEnvio.Columns("ID").DisplayIndex = 0
        DGVArticuloNotaDeEnvio.Columns("ID").Width = 46
        DGVArticuloNotaDeEnvio.Columns("ID").ReadOnly = True
        DGVArticuloNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloNotaDeEnvio.Columns("Codigo").DisplayIndex = 1
        DGVArticuloNotaDeEnvio.Columns("Codigo").Width = 102
        DGVArticuloNotaDeEnvio.Columns("Codigo").ReadOnly = True
        DGVArticuloNotaDeEnvio.Columns("Codigo").HeaderText = "Código"
        DGVArticuloNotaDeEnvio.Columns("Codigo").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloNotaDeEnvio.Columns("Descripcion").DisplayIndex = 2
        DGVArticuloNotaDeEnvio.Columns("Descripcion").Width = 228
        DGVArticuloNotaDeEnvio.Columns("Descripcion").ReadOnly = True
        DGVArticuloNotaDeEnvio.Columns("Descripcion").HeaderText = "Descripción"
        DGVArticuloNotaDeEnvio.Columns("Descripcion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloNotaDeEnvio.Columns("Cantidad").DisplayIndex = 3
        DGVArticuloNotaDeEnvio.Columns("Cantidad").Width = 50
        DGVArticuloNotaDeEnvio.Columns("Cantidad").ReadOnly = True
        DGVArticuloNotaDeEnvio.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVArticuloNotaDeEnvio.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVArticuloNotaDeEnvio.Columns("IDProveedor").Visible = False

    End Sub

    Private Sub BTNCancelarPedidoDeCliente_Click(sender As Object, e As EventArgs) Handles BTNCancelarPedidoDeCliente.Click
        If Not vPedidoDeClienteSeleccionado Is Nothing Then
            For Each vArticuloPedidoDeCliente As ArticuloPedidoDeCliente In vPedidoDeClienteSeleccionado.ListaDeArticulos
                vArticuloPedidoDeCliente.Enviar = 0
            Next
            BTNAgregar_Click(Nothing, Nothing)
            ActualizarListaDeArticulos()
        Else
            MsgBox("Seleccione un Pedido de Cliente.")
        End If

    End Sub

    Private Sub BTNGenerarEnvio_Click(sender As Object, e As EventArgs) Handles BTNGenerarEnvio.Click
        BTNAgregar_Click(Nothing, Nothing)
        If Not Me.NotaDeEnvio Is Nothing And Not vListaDeClientes Is Nothing Then
            Me.NotaDeEnvio.FechaDeEntrega = DTPFentregaNE.Value
            Me.NotaDeEnvio.Comentarios = Me.NotaDeEnvio.Comentarios & Environment.NewLine & "------------------------------------- Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBComentarios.Text
            Me.NotaDeEnvio.IDVendedor = vVendedorSeleccionado.ID

            If Me.NotaDeEnvio.Estado = "TrabajoEnCurso" Then
                Me.NotaDeEnvio.Estado = "Pendiente"
                vNotaDeEnvioNEG.Modificacion(Me.NotaDeEnvio)
                Me.NotaDeEnvio = Nothing
            Else
                vNotaDeEnvioNEG.Alta(Me.NotaDeEnvio)
                Me.NotaDeEnvio = Nothing
            End If
            For Each vCliente As Cliente In vListaDeClientes
                For Each vPedidoDeCliente As PedidoDeCliente In vCliente.ListaPedidoDeCliente
                    vPedidoDeClienteNEG.Modificacion(vPedidoDeCliente)
                Next
            Next
            Me.FormNotaDeEnvio_Load(Nothing, Nothing)
        End If
        MsgBox("La nota de envio ha sido generada.")
        CBVendedor_SelectedValueChanged1(Nothing, Nothing)

    End Sub

#End Region

#Region "Pendiente"

    'Vendedor
    Dim vListaDeVendedoresPendiente As List(Of Usuario_SEG)
    Dim vVendedorTECPendiente As New Usuario_TEC
    Dim vVendedorSeleccionadoPendiente As Usuario_SEG

    'Nota de Envio
    Dim vListaDeNotaDeEnvioPendiente As List(Of NotaDeEnvio)
    Dim vNotaDeEnvioNEGPendiente As New NotaDeEnvio_NEG
    Dim vNotaDeEnvioSeleccionadoPendiente As NotaDeEnvio

    Private Sub CargarVendedoresPendiente()
        Dim vVendedorDeConsulta As New Usuario_SEG
        vListaDeVendedoresPendiente = vVendedorTECPendiente.ConsultaVarios(vVendedorDeConsulta)
    End Sub

    Private Sub CargarDGVNotaDeEnvioPendiente()

        vListaDeVendedoresPendiente.Clear()
        vVendedorSeleccionado = Nothing
        If Not vListaDeNotaDeEnvioPendiente Is Nothing Then
            vListaDeNotaDeEnvioPendiente.Clear()
        End If
        vListaDeNotaDeEnvioPendiente = Nothing
        DGVPendienteNotaDeEnvio.DataSource = Nothing
        DGVPendienteDetalleArticuloNotaDeEnvio.DataSource = Nothing

        Dim vNotaDeEnvioDeConsulta As New NotaDeEnvio
        vNotaDeEnvioDeConsulta.Estado = "Pendiente"
        vListaDeNotaDeEnvioPendiente = vNotaDeEnvioNEG.ConsultaVarios(vNotaDeEnvioDeConsulta)
        DGVPendienteNotaDeEnvio.DataSource = vListaDeNotaDeEnvioPendiente
        'ID
        DGVPendienteNotaDeEnvio.Columns("ID").Width = 100
        DGVPendienteNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPendienteNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVPendienteNotaDeEnvio.Columns("FechaDeCreacion").Width = 160
        DGVPendienteNotaDeEnvio.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVPendienteNotaDeEnvio.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPendienteNotaDeEnvio.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVPendienteNotaDeEnvio.Columns("FechaDeEntrega").Width = 160
        DGVPendienteNotaDeEnvio.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVPendienteNotaDeEnvio.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPendienteNotaDeEnvio.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'ID Vendedor
        DGVPendienteNotaDeEnvio.Columns("IDVendedor").Width = 100
        DGVPendienteNotaDeEnvio.Columns("IDVendedor").HeaderText = "ID Vendedor"
        DGVPendienteNotaDeEnvio.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVPendienteNotaDeEnvio.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVPendienteNotaDeEnvio.Columns("Diccionario").Visible = False
        DGVPendienteNotaDeEnvio.Columns("Comentarios").Visible = False
        DGVPendienteNotaDeEnvio.Columns("Estado").Visible = False
    End Sub

    Private Sub CargarDetalleArticuloNotaDeEnvioPendiente()

        If Not vNotaDeEnvioSeleccionadoPendiente Is Nothing Then
            vNotaDeEnvioNEGPendiente.Consulta(vNotaDeEnvioSeleccionadoPendiente)
            If Not vNotaDeEnvioSeleccionadoPendiente.ListaDeArticuloDeEnvio Is Nothing Then
                DGVPendienteDetalleArticuloNotaDeEnvio.DataSource = vNotaDeEnvioSeleccionadoPendiente.ListaDeArticuloDeEnvio
                DTPPendienteFechaDeEntrega.Value = vNotaDeEnvioSeleccionadoPendiente.FechaDeEntrega
                TBPendienteComentariosHistorial.Text = vNotaDeEnvioSeleccionadoPendiente.Comentarios

                If DGVPendienteDetalleArticuloNotaDeEnvio.Columns.Count > 0 Then

                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("ID").DisplayIndex = 0
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("ID").Width = 60
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("ID").ReadOnly = True
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Codigo").DisplayIndex = 1
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Codigo").Width = 200
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Codigo").ReadOnly = True
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Codigo").HeaderText = "Código"

                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Descripcion").DisplayIndex = 2
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Descripcion").Width = 284
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Descripcion").ReadOnly = True
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Descripcion").HeaderText = "Descripción"

                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Cantidad").DisplayIndex = 3
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Cantidad").Width = 65
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Cantidad").ReadOnly = True
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVPendienteDetalleArticuloNotaDeEnvio.Columns("IDProveedor").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub DGVPendienteNotaDeEnvio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVPendienteNotaDeEnvio.SelectionChanged
        If DGVPendienteNotaDeEnvio.SelectedRows.Count > 0 Then
            vNotaDeEnvioSeleccionadoPendiente = New NotaDeEnvio
            vNotaDeEnvioSeleccionadoPendiente.ID = DGVPendienteNotaDeEnvio.SelectedRows(0).Cells(1).Value
            CargarDetalleArticuloNotaDeEnvioPendiente()
        End If
    End Sub

    Private Sub BTNTrabajoEnCurso_Click(sender As Object, e As EventArgs) Handles BTNTrabajoEnCurso.Click
        If TBPendienteComentarios.Text = "Debe actualizar los comentarios." Then
            MsgBox("")
        Else
            vNotaDeEnvioSeleccionadoPendiente.Comentarios = vNotaDeEnvioSeleccionadoPendiente.Comentarios & Environment.NewLine & "------------------------------------- Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBPendienteComentarios.Text
            vNotaDeEnvioSeleccionadoPendiente.FechaDeEntrega = DTPPendienteFechaDeEntrega.Value
            vNotaDeEnvioSeleccionadoPendiente.Estado = "TrabajoEnCurso"
            vNotaDeEnvioNEG.Modificacion(vNotaDeEnvioSeleccionadoPendiente)
            MsgBox("La nota de envío ha sido actualizada con éxito.")
            CargarDetalleArticuloNotaDeEnvioPendiente()
            CargarDGVNotaDeEnvioPendiente()
            CBVendedor_SelectedValueChanged1(Nothing, Nothing)
            TBPendienteComentarios.Text = ""
            TBPendienteComentariosHistorial.Text = ""
        End If
    End Sub

    Private Sub BTNVerificarDisponibilidad_Click(sender As Object, e As EventArgs) Handles BTNVerificarDisponibilidad.Click
        If TBPendienteComentarios.Text = "" Then
            MsgBox("Debe actualizar los comentarios.")
        Else
            vNotaDeEnvioSeleccionadoPendiente.Comentarios = vNotaDeEnvioSeleccionadoPendiente.Comentarios & Environment.NewLine & "------------------------------------- Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBPendienteComentarios.Text
            vNotaDeEnvioSeleccionadoPendiente.FechaDeEntrega = DTPPendienteFechaDeEntrega.Value
            vNotaDeEnvioSeleccionadoPendiente.Estado = "SujetaADisponibilidad"
            vNotaDeEnvioNEG.Modificacion(vNotaDeEnvioSeleccionadoPendiente)
            MsgBox("La nota de envío ha sido actualizada con éxito.")
            TBPendienteComentarios.Text = ""
            CargarDetalleArticuloNotaDeEnvioPendiente()
            CargarDGVNotaDeEnvioPendiente()
        End If
    End Sub

#End Region

#Region "Sujeta a disponibilidad"


    'Vendedor
    Dim vListaDeVendedoresSujetaADisponibilidad As List(Of Usuario_SEG)
    Dim vVendedorTECSujetaADisponibilidad As New Usuario_TEC
    Dim vVendedorSeleccionadoSujetaADisponibilidad As Usuario_SEG

    'Nota de Envio
    Dim vListaDeNotaDeEnvioSujetaADisponibilidad As List(Of NotaDeEnvio)
    Dim vNotaDeEnvioNEGSujetaADisponibilidad As New NotaDeEnvio_NEG
    Dim vNotaDeEnvioSeleccionadoSujetaADisponibilidad As NotaDeEnvio

    Private Sub CargarVendedoresSujetaADisponibilidad()
        Dim vVendedorDeConsulta As New Usuario_SEG
        vListaDeVendedoresSujetaADisponibilidad = vVendedorTECSujetaADisponibilidad.ConsultaVarios(vVendedorDeConsulta)
    End Sub

    Private Sub CargarDGVNotaDeEnvioSujetaADisponibilidad()

        vListaDeVendedoresSujetaADisponibilidad.Clear()
        vVendedorSeleccionado = Nothing
        If Not vListaDeNotaDeEnvioSujetaADisponibilidad Is Nothing Then
            vListaDeNotaDeEnvioSujetaADisponibilidad.Clear()
        End If
        vListaDeNotaDeEnvioSujetaADisponibilidad = Nothing
        DGVSujetaADisponibilidadNotaDeEnvio.DataSource = Nothing
        DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.DataSource = Nothing

        Dim vNotaDeEnvioDeConsulta As New NotaDeEnvio
        vNotaDeEnvioDeConsulta.Estado = "SujetaADisponibilidad"
        vListaDeNotaDeEnvioSujetaADisponibilidad = vNotaDeEnvioNEG.ConsultaVarios(vNotaDeEnvioDeConsulta)
        DGVSujetaADisponibilidadNotaDeEnvio.DataSource = vListaDeNotaDeEnvioSujetaADisponibilidad
        'ID
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("ID").Width = 100
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeCreacion").Width = 160
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeEntrega").Width = 160
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'ID Vendedor
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("IDVendedor").Width = 100
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("IDVendedor").HeaderText = "ID Vendedor"
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVSujetaADisponibilidadNotaDeEnvio.Columns("Diccionario").Visible = False
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("Comentarios").Visible = False
        DGVSujetaADisponibilidadNotaDeEnvio.Columns("Estado").Visible = False

    End Sub

    Private Sub CargarDetalleArticuloNotaDeEnvioSujetaADisponibilidad()

        If Not vNotaDeEnvioSeleccionadoSujetaADisponibilidad Is Nothing Then
            vNotaDeEnvioNEGSujetaADisponibilidad.Consulta(vNotaDeEnvioSeleccionadoSujetaADisponibilidad)
            If Not vNotaDeEnvioSeleccionadoSujetaADisponibilidad.ListaDeArticuloDeEnvio Is Nothing Then
                DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.DataSource = vNotaDeEnvioSeleccionadoSujetaADisponibilidad.ListaDeArticuloDeEnvio
                DTPSujetaADisponibilidadFechaDeEntrega.Value = vNotaDeEnvioSeleccionadoSujetaADisponibilidad.FechaDeEntrega
                TBSujetaADisponibilidadComentariosHistorial.Text = vNotaDeEnvioSeleccionadoSujetaADisponibilidad.Comentarios

                If DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns.Count > 0 Then

                    'ID
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("ID").DisplayIndex = 0
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("ID").Width = 60
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("ID").ReadOnly = True
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'Código
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Codigo").DisplayIndex = 1
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Codigo").Width = 200
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Codigo").ReadOnly = True
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Codigo").HeaderText = "Código"
                    'Descripción
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Descripcion").DisplayIndex = 2
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Descripcion").Width = 284
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Descripcion").ReadOnly = True
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Descripcion").HeaderText = "Descripción"
                    'Cantidad
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Cantidad").DisplayIndex = 3
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Cantidad").Width = 65
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Cantidad").ReadOnly = True
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Columns("IDProveedor").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub DGVSujetaADisponibilidadNotaDeEnvio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVSujetaADisponibilidadNotaDeEnvio.SelectionChanged
        If DGVSujetaADisponibilidadNotaDeEnvio.SelectedRows.Count > 0 Then
            vNotaDeEnvioSeleccionadoSujetaADisponibilidad = New NotaDeEnvio
            vNotaDeEnvioSeleccionadoSujetaADisponibilidad.ID = DGVSujetaADisponibilidadNotaDeEnvio.SelectedRows(0).Cells(1).Value
            CargarDetalleArticuloNotaDeEnvioSujetaADisponibilidad()
        End If
    End Sub

    Private Sub BTNRevisada_Click(sender As Object, e As EventArgs) Handles BTNRevisada.Click
        If TBSujetaADisponibilidadComentarios.Text = "Debe actualizar los comentarios." Then
            MsgBox("")
        Else
            vNotaDeEnvioSeleccionadoSujetaADisponibilidad.Comentarios = vNotaDeEnvioSeleccionadoSujetaADisponibilidad.Comentarios & Environment.NewLine & "------------------------------------- Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBSujetaADisponibilidadComentarios.Text
            vNotaDeEnvioSeleccionadoSujetaADisponibilidad.FechaDeEntrega = DTPSujetaADisponibilidadFechaDeEntrega.Value
            vNotaDeEnvioSeleccionadoSujetaADisponibilidad.Estado = "Revisada"
            vNotaDeEnvioNEG.Modificacion(vNotaDeEnvioSeleccionadoSujetaADisponibilidad)
            MsgBox("La nota de envío ha sido actualizada con éxito.")
            CargarDetalleArticuloNotaDeEnvioSujetaADisponibilidad()
            CargarDGVNotaDeEnvioSujetaADisponibilidad()
            TBSujetaADisponibilidadComentarios.Text = ""
            TBSujetaADisponibilidadComentariosHistorial.Text = ""
        End If
    End Sub

#End Region

#Region "Revisada"

    'Vendedor
    Dim vListaDeVendedoresRevisada As List(Of Usuario_SEG)
    Dim vVendedorTECRevisada As New Usuario_TEC
    Dim vVendedorSeleccionadoRevisada As Usuario_SEG

    'Nota de Envio
    Dim vListaDeNotaDeEnvioRevisada As List(Of NotaDeEnvio)
    Dim vNotaDeEnvioNEGRevisada As New NotaDeEnvio_NEG
    Dim vNotaDeEnvioSeleccionadoRevisada As NotaDeEnvio

    Private Sub CargarVendedoresRevisada()
        Dim vVendedorDeConsulta As New Usuario_SEG
        vListaDeVendedoresRevisada = vVendedorTECRevisada.ConsultaVarios(vVendedorDeConsulta)
    End Sub

    Private Sub CargarDGVNotaDeEnvioRevisada()
        vListaDeVendedoresRevisada.Clear()
        vVendedorSeleccionadoRevisada = Nothing
        If Not vListaDeNotaDeEnvioRevisada Is Nothing Then
            vListaDeNotaDeEnvioRevisada.Clear()
        End If
        vListaDeNotaDeEnvioRevisada = Nothing
        DGVRevisadaNotaDeEnvio.DataSource = Nothing
        DGVRevisadaDetalleArticuloNotaDeEnvio.DataSource = Nothing

        Dim vNotaDeEnvioDeConsulta As New NotaDeEnvio
        vNotaDeEnvioDeConsulta.Estado = "Revisada"
        vListaDeNotaDeEnvioRevisada = vNotaDeEnvioNEG.ConsultaVariosNEArticuloNotaDeEnvio(vNotaDeEnvioDeConsulta)
        DGVRevisadaNotaDeEnvio.DataSource = vListaDeNotaDeEnvioRevisada
        'ID
        DGVRevisadaNotaDeEnvio.Columns("ID").Width = 100
        DGVRevisadaNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVRevisadaNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVRevisadaNotaDeEnvio.Columns("FechaDeCreacion").Width = 160
        DGVRevisadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVRevisadaNotaDeEnvio.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVRevisadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVRevisadaNotaDeEnvio.Columns("FechaDeEntrega").Width = 160
        DGVRevisadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVRevisadaNotaDeEnvio.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVRevisadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'ID Vendedor
        DGVRevisadaNotaDeEnvio.Columns("IDVendedor").Width = 100
        DGVRevisadaNotaDeEnvio.Columns("IDVendedor").HeaderText = "ID Vendedor"
        DGVRevisadaNotaDeEnvio.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVRevisadaNotaDeEnvio.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVRevisadaNotaDeEnvio.Columns("Diccionario").Visible = False
        DGVRevisadaNotaDeEnvio.Columns("Comentarios").Visible = False
        DGVRevisadaNotaDeEnvio.Columns("Estado").Visible = False

    End Sub

    Private Sub CargarDetalleArticuloNotaDeEnvioRevisada()

        If Not vNotaDeEnvioSeleccionadoRevisada Is Nothing Then
            vNotaDeEnvioNEGRevisada.Consulta(vNotaDeEnvioSeleccionadoRevisada)
            If Not vNotaDeEnvioSeleccionadoRevisada.ListaDeArticuloDeEnvio Is Nothing Then
                DGVRevisadaDetalleArticuloNotaDeEnvio.DataSource = vNotaDeEnvioSeleccionadoRevisada.ListaDeArticuloDeEnvio
                DTPRevisadaFechaDeEntrega.Value = vNotaDeEnvioSeleccionadoRevisada.FechaDeEntrega
                TBRevisadaComentariosHistorial.Text = vNotaDeEnvioSeleccionadoRevisada.Comentarios

                If DGVRevisadaDetalleArticuloNotaDeEnvio.Columns.Count > 0 Then

                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("ID").DisplayIndex = 0
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("ID").Width = 60
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("ID").ReadOnly = True
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Codigo").DisplayIndex = 1
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Codigo").Width = 200
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Codigo").ReadOnly = True
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Codigo").HeaderText = "Código"

                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").DisplayIndex = 2
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").Width = 284
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").ReadOnly = True
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").HeaderText = "Descripción"

                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").DisplayIndex = 3
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").Width = 65
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").ReadOnly = True
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVRevisadaDetalleArticuloNotaDeEnvio.Columns("IDProveedor").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub DGVRevisadaNotaDeEnvio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVRevisadaNotaDeEnvio.SelectionChanged
        If DGVRevisadaNotaDeEnvio.SelectedRows.Count > 0 Then
            vNotaDeEnvioSeleccionadoRevisada = New NotaDeEnvio
            vNotaDeEnvioSeleccionadoRevisada.ID = DGVRevisadaNotaDeEnvio.SelectedRows(0).Cells(1).Value
            CargarDetalleArticuloNotaDeEnvioRevisada()
        End If
    End Sub

    Private Sub BTNConfirmar_Click(sender As Object, e As EventArgs) Handles BTNConfirmar.Click
        If TBRevisadaComentarios.Text = "Debe actualizar los comentarios." Then
            MsgBox("")
        Else
            Dim vRemitoNEG As New Remito_NEG
            vRemitoNEG.GenerarRemito(vNotaDeEnvioSeleccionadoRevisada)

            vNotaDeEnvioSeleccionadoRevisada.Comentarios = vNotaDeEnvioSeleccionadoRevisada.Comentarios _
                                                           & Environment.NewLine & "------------------------------------- Usuario: " &
                                                           Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto &
                                                           " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
                                                           & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBRevisadaComentarios.Text

            vNotaDeEnvioSeleccionadoRevisada.FechaDeEntrega = DTPRevisadaFechaDeEntrega.Value
            vNotaDeEnvioSeleccionadoRevisada.Estado = "Confirmada"
            vNotaDeEnvioNEG.Modificacion(vNotaDeEnvioSeleccionadoRevisada)
            MsgBox("La nota de envío ha sido actualizada con éxito.")
            CargarDetalleArticuloNotaDeEnvioRevisada()
            CargarDGVNotaDeEnvioRevisada()
            TBRevisadaComentarios.Text = ""
            TBRevisadaComentariosHistorial.Text = ""
        End If
    End Sub

#End Region

#Region "Confirmada"

    'Vendedor
    Dim vListaDeVendedoresConfirmada As List(Of Usuario_SEG)
    Dim vVendedorTECConfirmada As New Usuario_TEC
    Dim vVendedorSeleccionadoConfirmada As Usuario_SEG

    'Nota de Envio
    Dim vListaDeNotaDeEnvioConfirmada As List(Of NotaDeEnvio)
    Dim vNotaDeEnvioNEGConfirmada As New NotaDeEnvio_NEG
    Dim vNotaDeEnvioSeleccionadoConfirmada As NotaDeEnvio

    Private Sub CargarVendedoresConfirmada()
        Dim vVendedorDeConsulta As New Usuario_SEG
        vListaDeVendedoresConfirmada = vVendedorTECConfirmada.ConsultaVarios(vVendedorDeConsulta)
    End Sub

    Private Sub CargarDGVNotaDeEnvioConfirmada()

        vListaDeVendedoresConfirmada.Clear()
        vVendedorSeleccionado = Nothing
        If Not vListaDeNotaDeEnvioConfirmada Is Nothing Then
            vListaDeNotaDeEnvioConfirmada.Clear()
        End If
        vListaDeNotaDeEnvioConfirmada = Nothing
        DGVConfirmadaNotaDeEnvio.DataSource = Nothing
        c.DataSource = Nothing

        Dim vNotaDeEnvioDeConsulta As New NotaDeEnvio
        vNotaDeEnvioDeConsulta.Estado = "Confirmada"
        vListaDeNotaDeEnvioConfirmada = vNotaDeEnvioNEG.ConsultaVarios(vNotaDeEnvioDeConsulta)
        DGVConfirmadaNotaDeEnvio.DataSource = vListaDeNotaDeEnvioConfirmada
        'ID
        DGVConfirmadaNotaDeEnvio.Columns("ID").Width = 100
        DGVConfirmadaNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVConfirmadaNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeCreacion").Width = 160
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeEntrega").Width = 160
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVConfirmadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'ID Vendedor
        DGVConfirmadaNotaDeEnvio.Columns("IDVendedor").Width = 100
        DGVConfirmadaNotaDeEnvio.Columns("IDVendedor").HeaderText = "ID Vendedor"
        DGVConfirmadaNotaDeEnvio.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVConfirmadaNotaDeEnvio.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVConfirmadaNotaDeEnvio.Columns("Diccionario").Visible = False
        DGVConfirmadaNotaDeEnvio.Columns("Comentarios").Visible = False
        DGVConfirmadaNotaDeEnvio.Columns("Estado").Visible = False

    End Sub

    Private Sub CargarDetalleArticuloNotaDeEnvioConfirmada()

        If Not vNotaDeEnvioSeleccionadoConfirmada Is Nothing Then
            vNotaDeEnvioNEGConfirmada.Consulta(vNotaDeEnvioSeleccionadoConfirmada)
            If Not vNotaDeEnvioSeleccionadoConfirmada.ListaDeArticuloDeEnvio Is Nothing Then
                c.DataSource = vNotaDeEnvioSeleccionadoConfirmada.ListaDeArticuloDeEnvio
                DTPConfirmadaFechaDeEntrega.Value = vNotaDeEnvioSeleccionadoConfirmada.FechaDeEntrega
                TBConfirmadaComentariosHistorial.Text = vNotaDeEnvioSeleccionadoConfirmada.Comentarios

                If c.Columns.Count > 0 Then

                    'ID
                    c.Columns("ID").DisplayIndex = 0
                    c.Columns("ID").Width = 60
                    c.Columns("ID").ReadOnly = True
                    c.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    c.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
                    'Codigo                   
                    c.Columns("Codigo").DisplayIndex = 1
                    c.Columns("Codigo").Width = 200
                    c.Columns("Codigo").ReadOnly = True
                    c.Columns("Codigo").HeaderText = "Código"
                    'Descripción
                    c.Columns("Descripcion").DisplayIndex = 2
                    c.Columns("Descripcion").Width = 284
                    c.Columns("Descripcion").ReadOnly = True
                    c.Columns("Descripcion").HeaderText = "Descripción"
                    'Cantidad
                    c.Columns("Cantidad").DisplayIndex = 3
                    c.Columns("Cantidad").Width = 65
                    c.Columns("Cantidad").ReadOnly = True
                    c.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    c.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    c.Columns("IDProveedor").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub DGVConfirmadaNotaDeEnvio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVConfirmadaNotaDeEnvio.SelectionChanged
        If DGVConfirmadaNotaDeEnvio.SelectedRows.Count > 0 Then
            vNotaDeEnvioSeleccionadoConfirmada = New NotaDeEnvio
            vNotaDeEnvioSeleccionadoConfirmada.ID = DGVConfirmadaNotaDeEnvio.SelectedRows(0).Cells(1).Value
            CargarDetalleArticuloNotaDeEnvioConfirmada()
        End If
    End Sub

    Private Sub BTNEntregada_Click(sender As Object, e As EventArgs) Handles BTNEntregada.Click
        If TBConfirmadaComentarios.Text = "Debe actualizar los comentarios." Then
            MsgBox("")
        Else
            vNotaDeEnvioSeleccionadoConfirmada.Comentarios = vNotaDeEnvioSeleccionadoConfirmada.Comentarios & Environment.NewLine & "------------------------------------- Usuario: " &
        Sesion_SEG.SesionActual.UsuarioSEG.NombreCompleto & " - " & Sesion_SEG.SesionActual.UsuarioSEG.Codigo _
        & " - " & Date.Now & " ------------------------------------- " & Environment.NewLine & TBConfirmadaComentarios.Text
            vNotaDeEnvioSeleccionadoConfirmada.FechaDeEntrega = DTPConfirmadaFechaDeEntrega.Value
            vNotaDeEnvioSeleccionadoConfirmada.Estado = "Entregada"
            vNotaDeEnvioNEG.Modificacion(vNotaDeEnvioSeleccionadoConfirmada)
            MsgBox("La nota de envío ha sido actualizada con éxito.")
            CargarDetalleArticuloNotaDeEnvioConfirmada()
            CargarDGVNotaDeEnvioConfirmada()
            TBConfirmadaComentarios.Text = ""
            TBConfirmadaComentariosHistorial.Text = ""
        End If
    End Sub



#End Region

#Region "Entregada"

    'Nota de Envio
    Dim vListaDeNotaDeEnvioEntregada As List(Of NotaDeEnvio)
    Dim vNotaDeEnvioNEGEntregada As New NotaDeEnvio_NEG
    Dim vNotaDeEnvioSeleccionadoEntregada As NotaDeEnvio


    Private Sub CargarDGVNotaDeEnvioEntregada()

        If Not vListaDeNotaDeEnvioEntregada Is Nothing Then
            vListaDeNotaDeEnvioEntregada.Clear()
        End If
        vListaDeNotaDeEnvioEntregada = Nothing
        DGVEntregadaNotaDeEnvio.DataSource = Nothing
        DGVEntregadaDetalleArticuloNotaDeEnvio.DataSource = Nothing

        Dim vNotaDeEnvioDeConsulta As New NotaDeEnvio
        vNotaDeEnvioDeConsulta.Estado = "Entregada"
        vListaDeNotaDeEnvioEntregada = vNotaDeEnvioNEG.ConsultaVarios(vNotaDeEnvioDeConsulta)
        DGVEntregadaNotaDeEnvio.DataSource = vListaDeNotaDeEnvioEntregada
        'ID
        DGVEntregadaNotaDeEnvio.Columns("ID").Width = 100
        DGVEntregadaNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVEntregadaNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Creación
        DGVEntregadaNotaDeEnvio.Columns("FechaDeCreacion").Width = 160
        DGVEntregadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderText = "Fecha de Creación"
        DGVEntregadaNotaDeEnvio.Columns("FechaDeCreacion").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVEntregadaNotaDeEnvio.Columns("FechaDeCreacion").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'Fecha de Entrega
        DGVEntregadaNotaDeEnvio.Columns("FechaDeEntrega").Width = 160
        DGVEntregadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderText = "Fecha de Entrega"
        DGVEntregadaNotaDeEnvio.Columns("FechaDeEntrega").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVEntregadaNotaDeEnvio.Columns("FechaDeEntrega").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter
        'ID Vendedor
        DGVEntregadaNotaDeEnvio.Columns("IDVendedor").Width = 100
        DGVEntregadaNotaDeEnvio.Columns("IDVendedor").HeaderText = "ID Vendedor"
        DGVEntregadaNotaDeEnvio.Columns("IDVendedor").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVEntregadaNotaDeEnvio.Columns("IDVendedor").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

        DGVEntregadaNotaDeEnvio.Columns("Diccionario").Visible = False
        DGVEntregadaNotaDeEnvio.Columns("Comentarios").Visible = False
        DGVEntregadaNotaDeEnvio.Columns("Estado").Visible = False
    End Sub

    Private Sub CargarDetalleArticuloNotaDeEnvioEntregada()

        If Not vNotaDeEnvioSeleccionadoEntregada Is Nothing Then
            vNotaDeEnvioNEGEntregada.Consulta(vNotaDeEnvioSeleccionadoEntregada)
            If Not vNotaDeEnvioSeleccionadoEntregada.ListaDeArticuloDeEnvio Is Nothing Then
                DGVEntregadaDetalleArticuloNotaDeEnvio.DataSource = vNotaDeEnvioSeleccionadoEntregada.ListaDeArticuloDeEnvio
                DTPEntregadaFechaDeEntrega.Value = vNotaDeEnvioSeleccionadoEntregada.FechaDeEntrega
                TBEntregadaComentariosHistorial.Text = vNotaDeEnvioSeleccionadoEntregada.Comentarios

                If DGVEntregadaDetalleArticuloNotaDeEnvio.Columns.Count > 0 Then

                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("ID").DisplayIndex = 0
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("ID").Width = 60
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("ID").ReadOnly = True
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("ID").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("ID").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Codigo").DisplayIndex = 1
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Codigo").Width = 200
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Codigo").ReadOnly = True
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Codigo").HeaderText = "Código"

                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").DisplayIndex = 2
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").Width = 284
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").ReadOnly = True
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Descripcion").HeaderText = "Descripción"

                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").DisplayIndex = 3
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").Width = 65
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").ReadOnly = True
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("Cantidad").HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter

                    DGVEntregadaDetalleArticuloNotaDeEnvio.Columns("IDProveedor").Visible = False

                End If
            End If
        End If
    End Sub

    Private Sub DGVEntregadaNotaDeEnvio_SelectionChanged(sender As Object, e As EventArgs) Handles DGVEntregadaNotaDeEnvio.SelectionChanged
        If DGVEntregadaNotaDeEnvio.SelectedRows.Count > 0 Then
            vNotaDeEnvioSeleccionadoEntregada = New NotaDeEnvio
            vNotaDeEnvioSeleccionadoEntregada.ID = DGVEntregadaNotaDeEnvio.SelectedRows(0).Cells(1).Value
            CargarDetalleArticuloNotaDeEnvioEntregada()
        End If
    End Sub


#End Region

    Private Sub TC_Selected(sender As Object, e As TabControlEventArgs) Handles TC.Selected
        CargarVendedoresPendiente()
        CargarDGVNotaDeEnvioPendiente()
        CargarVendedoresSujetaADisponibilidad()
        CargarDGVNotaDeEnvioSujetaADisponibilidad()
        CargarVendedoresRevisada()
        CargarDGVNotaDeEnvioRevisada()
        CargarVendedoresConfirmada()
        CargarDGVNotaDeEnvioConfirmada()
        CargarDGVNotaDeEnvioEntregada()
    End Sub

    Private Sub TC_MouseHover(sender As Object, e As EventArgs) Handles TC.MouseHover
        ToolTip.SetToolTip(TC, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Estado"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPConfirmada_MouseHover(sender As Object, e As EventArgs) Handles TPConfirmada.MouseHover
        ToolTip.SetToolTip(TPConfirmada, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Confirmadas"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPTrabajoEnCurso_MouseHover(sender As Object, e As EventArgs) Handles TPTrabajoEnCurso.MouseHover
        ToolTip.SetToolTip(TPTrabajoEnCurso, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Trabajo en Curso"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPPendiente_MouseHover(sender As Object, e As EventArgs) Handles TPPendiente.MouseHover
        ToolTip.SetToolTip(TPPendiente, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Pendiente"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPSujetaADisponibilidad_MouseHover(sender As Object, e As EventArgs) Handles TPSujetaADisponibilidad.MouseHover
        ToolTip.SetToolTip(TPSujetaADisponibilidad, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Sujeta a disponibilidad"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPRevisada_MouseHover(sender As Object, e As EventArgs) Handles TPRevisada.MouseHover
        ToolTip.SetToolTip(TC, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Estado"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Private Sub TPEntregada_MouseHover(sender As Object, e As EventArgs) Handles TPEntregada.MouseHover
        ToolTip.SetToolTip(TC, "Haga clic en las solapas para ver las notas de pedido según el estado.")
        ToolTip.ToolTipTitle = "Estado"
        ToolTip.ToolTipIcon = ToolTipIcon.Info
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

    End Sub

#Region "solo numeros"

    Private Sub DGVArticuloPedidoDeCliente_DataError(sender As Object, e As DataGridViewDataErrorEventArgs) Handles DGVArticuloPedidoDeCliente.DataError
        If e.Context.GetType Is Nothing Then
            MsgBox("Error")
        End If
    End Sub

    Private Sub DGVArticuloPedidoDeCliente_EditingControlShowing(ByVal sender As Object, ByVal e As DataGridViewEditingControlShowingEventArgs) Handles DGVArticuloPedidoDeCliente.EditingControlShowing
        ' referencia a la celda 
        Dim validar As TextBox = CType(e.Control, TextBox)
        validar.MaxLength = 3
        ' agregar el controlador de eventos para el KeyPress 
        AddHandler validar.KeyPress, AddressOf validar_Keypress
    End Sub

    Private Sub validar_Keypress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        Try
            ' Obtener caracter 
            Dim caracter As Char = e.KeyChar
            ' comprobar si el caracter es un número o el retroceso 
            If Not Char.IsNumber(caracter) And (caracter = ChrW(Keys.Back)) = False Then
                'Me.Text = e.KeyChar 
                e.KeyChar = Chr(0)
            End If
        Catch ex As Exception
            MsgBox("El valor no puede ser nulo.")
        End Try
    End Sub

    Private Sub DGVClientes_SelectionChanged(sender As Object, e As EventArgs) Handles DGVClientes.SelectionChanged
        SeleccionarCliente()
        ActualizarDGVPedidoDeCliente()
        SeleccionarPedidoDeCliente()
    End Sub

#End Region



End Class