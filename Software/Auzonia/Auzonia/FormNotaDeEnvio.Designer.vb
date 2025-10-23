<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotaDeEnvio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNotaDeEnvio))
        Me.GBPedidos = New System.Windows.Forms.GroupBox()
        Me.DGVPedidoDeCliente = New System.Windows.Forms.DataGridView()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DGVClientes = New System.Windows.Forms.DataGridView()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.BTNCancelarPedidoDeCliente = New System.Windows.Forms.Button()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBIDCliente = New System.Windows.Forms.TextBox()
        Me.lbIDCliente = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.lbFechaDeEntrega = New System.Windows.Forms.Label()
        Me.DTPFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.BTNAgregar = New System.Windows.Forms.Button()
        Me.DGVArticuloPedidoDeCliente = New System.Windows.Forms.DataGridView()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.TC = New System.Windows.Forms.TabControl()
        Me.TPTrabajoEnCurso = New System.Windows.Forms.TabPage()
        Me.CBVendedor = New System.Windows.Forms.ComboBox()
        Me.lbAdvertencia = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TBComentarios = New System.Windows.Forms.TextBox()
        Me.lbComentarios = New System.Windows.Forms.Label()
        Me.DTPFentregaNE = New System.Windows.Forms.DateTimePicker()
        Me.lbDetalleEstado = New System.Windows.Forms.Label()
        Me.TBComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.BTNGenerarEnvio = New System.Windows.Forms.Button()
        Me.DGVArticuloNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.TPPendiente = New System.Windows.Forms.TabPage()
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.TBPendienteComentarios = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.BTNTrabajoEnCurso = New System.Windows.Forms.Button()
        Me.DTPPendienteFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TBPendienteComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.BTNVerificarDisponibilidad = New System.Windows.Forms.Button()
        Me.DGVPendienteDetalleArticuloNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.GroupBox4 = New System.Windows.Forms.GroupBox()
        Me.DGVPendienteNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.TPSujetaADisponibilidad = New System.Windows.Forms.TabPage()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.TBSujetaADisponibilidadComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.DTPSujetaADisponibilidadFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TBSujetaADisponibilidadComentarios = New System.Windows.Forms.TextBox()
        Me.BTNRevisada = New System.Windows.Forms.Button()
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.DGVSujetaADisponibilidadNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.TPRevisada = New System.Windows.Forms.TabPage()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.TBRevisadaComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.DTPRevisadaFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TBRevisadaComentarios = New System.Windows.Forms.TextBox()
        Me.BTNConfirmar = New System.Windows.Forms.Button()
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.GroupBox9 = New System.Windows.Forms.GroupBox()
        Me.DGVRevisadaNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.TPConfirmada = New System.Windows.Forms.TabPage()
        Me.GroupBox10 = New System.Windows.Forms.GroupBox()
        Me.TBConfirmadaComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.DTPConfirmadaFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBConfirmadaComentarios = New System.Windows.Forms.TextBox()
        Me.BTNEntregada = New System.Windows.Forms.Button()
        Me.c = New System.Windows.Forms.DataGridView()
        Me.GroupBox11 = New System.Windows.Forms.GroupBox()
        Me.DGVConfirmadaNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.TPEntregada = New System.Windows.Forms.TabPage()
        Me.GroupBox12 = New System.Windows.Forms.GroupBox()
        Me.TBEntregadaComentariosHistorial = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.DTPEntregadaFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.GroupBox13 = New System.Windows.Forms.GroupBox()
        Me.DGVEntregadaNotaDeEnvio = New System.Windows.Forms.DataGridView()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBPedidos.SuspendLayout()
        CType(Me.DGVPedidoDeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.DGVArticuloPedidoDeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TC.SuspendLayout()
        Me.TPTrabajoEnCurso.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.DGVArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPPendiente.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.DGVPendienteDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.DGVPendienteNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPSujetaADisponibilidad.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.DGVSujetaADisponibilidadNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPRevisada.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.DGVRevisadaDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox9.SuspendLayout()
        CType(Me.DGVRevisadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPConfirmada.SuspendLayout()
        Me.GroupBox10.SuspendLayout()
        CType(Me.c, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox11.SuspendLayout()
        CType(Me.DGVConfirmadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPEntregada.SuspendLayout()
        Me.GroupBox12.SuspendLayout()
        CType(Me.DGVEntregadaDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox13.SuspendLayout()
        CType(Me.DGVEntregadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GBPedidos
        '
        Me.GBPedidos.Controls.Add(Me.DGVPedidoDeCliente)
        Me.GBPedidos.Location = New System.Drawing.Point(417, 31)
        Me.GBPedidos.Name = "GBPedidos"
        Me.GBPedidos.Size = New System.Drawing.Size(353, 131)
        Me.GBPedidos.TabIndex = 6
        Me.GBPedidos.TabStop = False
        Me.GBPedidos.Text = "Pedidos"
        '
        'DGVPedidoDeCliente
        '
        Me.DGVPedidoDeCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPedidoDeCliente.Location = New System.Drawing.Point(7, 19)
        Me.DGVPedidoDeCliente.MultiSelect = False
        Me.DGVPedidoDeCliente.Name = "DGVPedidoDeCliente"
        Me.DGVPedidoDeCliente.ReadOnly = True
        Me.DGVPedidoDeCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPedidoDeCliente.Size = New System.Drawing.Size(340, 106)
        Me.DGVPedidoDeCliente.TabIndex = 1
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.DGVClientes)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 31)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(408, 131)
        Me.GroupBox1.TabIndex = 5
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Clientes"
        '
        'DGVClientes
        '
        Me.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVClientes.Location = New System.Drawing.Point(6, 19)
        Me.DGVClientes.MultiSelect = False
        Me.DGVClientes.Name = "DGVClientes"
        Me.DGVClientes.ReadOnly = True
        Me.DGVClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVClientes.Size = New System.Drawing.Size(397, 106)
        Me.DGVClientes.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BTNCancelarPedidoDeCliente)
        Me.GroupBox3.Controls.Add(Me.TBRazonSocial)
        Me.GroupBox3.Controls.Add(Me.TBIDCliente)
        Me.GroupBox3.Controls.Add(Me.lbIDCliente)
        Me.GroupBox3.Controls.Add(Me.lbRazonSocial)
        Me.GroupBox3.Controls.Add(Me.lbFechaDeEntrega)
        Me.GroupBox3.Controls.Add(Me.DTPFechaDeEntrega)
        Me.GroupBox3.Controls.Add(Me.BTNAgregar)
        Me.GroupBox3.Controls.Add(Me.DGVArticuloPedidoDeCliente)
        Me.GroupBox3.Location = New System.Drawing.Point(6, 166)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(764, 321)
        Me.GroupBox3.TabIndex = 8
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Detalle Pedido"
        '
        'BTNCancelarPedidoDeCliente
        '
        Me.BTNCancelarPedidoDeCliente.Location = New System.Drawing.Point(505, 288)
        Me.BTNCancelarPedidoDeCliente.Name = "BTNCancelarPedidoDeCliente"
        Me.BTNCancelarPedidoDeCliente.Size = New System.Drawing.Size(121, 23)
        Me.BTNCancelarPedidoDeCliente.TabIndex = 22
        Me.BTNCancelarPedidoDeCliente.Text = "Cancelar"
        Me.BTNCancelarPedidoDeCliente.UseVisualStyleBackColor = True
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Enabled = False
        Me.TBRazonSocial.Location = New System.Drawing.Point(113, 33)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(317, 20)
        Me.TBRazonSocial.TabIndex = 20
        '
        'TBIDCliente
        '
        Me.TBIDCliente.Enabled = False
        Me.TBIDCliente.Location = New System.Drawing.Point(5, 33)
        Me.TBIDCliente.Name = "TBIDCliente"
        Me.TBIDCliente.Size = New System.Drawing.Size(100, 20)
        Me.TBIDCliente.TabIndex = 19
        '
        'lbIDCliente
        '
        Me.lbIDCliente.AutoSize = True
        Me.lbIDCliente.Location = New System.Drawing.Point(8, 18)
        Me.lbIDCliente.Name = "lbIDCliente"
        Me.lbIDCliente.Size = New System.Drawing.Size(59, 13)
        Me.lbIDCliente.TabIndex = 18
        Me.lbIDCliente.Text = "ID Cliente :"
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.AutoSize = True
        Me.lbRazonSocial.Location = New System.Drawing.Point(116, 18)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.lbRazonSocial.TabIndex = 17
        Me.lbRazonSocial.Text = "Razón Social: "
        '
        'lbFechaDeEntrega
        '
        Me.lbFechaDeEntrega.AutoSize = True
        Me.lbFechaDeEntrega.Location = New System.Drawing.Point(442, 17)
        Me.lbFechaDeEntrega.Name = "lbFechaDeEntrega"
        Me.lbFechaDeEntrega.Size = New System.Drawing.Size(97, 13)
        Me.lbFechaDeEntrega.TabIndex = 16
        Me.lbFechaDeEntrega.Text = "Fecha de entrega :"
        '
        'DTPFechaDeEntrega
        '
        Me.DTPFechaDeEntrega.Enabled = False
        Me.DTPFechaDeEntrega.Location = New System.Drawing.Point(439, 32)
        Me.DTPFechaDeEntrega.Name = "DTPFechaDeEntrega"
        Me.DTPFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaDeEntrega.TabIndex = 15
        '
        'BTNAgregar
        '
        Me.BTNAgregar.Location = New System.Drawing.Point(633, 288)
        Me.BTNAgregar.Name = "BTNAgregar"
        Me.BTNAgregar.Size = New System.Drawing.Size(121, 23)
        Me.BTNAgregar.TabIndex = 2
        Me.BTNAgregar.Text = "Agregar"
        Me.BTNAgregar.UseVisualStyleBackColor = True
        '
        'DGVArticuloPedidoDeCliente
        '
        Me.DGVArticuloPedidoDeCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloPedidoDeCliente.Location = New System.Drawing.Point(6, 59)
        Me.DGVArticuloPedidoDeCliente.Name = "DGVArticuloPedidoDeCliente"
        Me.DGVArticuloPedidoDeCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloPedidoDeCliente.Size = New System.Drawing.Size(752, 223)
        Me.DGVArticuloPedidoDeCliente.TabIndex = 1
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(1182, 527)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 22)
        Me.BTNSalir.TabIndex = 9
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'TC
        '
        Me.TC.Controls.Add(Me.TPTrabajoEnCurso)
        Me.TC.Controls.Add(Me.TPPendiente)
        Me.TC.Controls.Add(Me.TPSujetaADisponibilidad)
        Me.TC.Controls.Add(Me.TPRevisada)
        Me.TC.Controls.Add(Me.TPConfirmada)
        Me.TC.Controls.Add(Me.TPEntregada)
        Me.TC.Location = New System.Drawing.Point(3, 1)
        Me.TC.Name = "TC"
        Me.TC.SelectedIndex = 0
        Me.TC.Size = New System.Drawing.Size(1270, 520)
        Me.TC.TabIndex = 10
        '
        'TPTrabajoEnCurso
        '
        Me.TPTrabajoEnCurso.Controls.Add(Me.CBVendedor)
        Me.TPTrabajoEnCurso.Controls.Add(Me.lbAdvertencia)
        Me.TPTrabajoEnCurso.Controls.Add(Me.GroupBox2)
        Me.TPTrabajoEnCurso.Controls.Add(Me.GroupBox3)
        Me.TPTrabajoEnCurso.Controls.Add(Me.GroupBox1)
        Me.TPTrabajoEnCurso.Controls.Add(Me.GBPedidos)
        Me.TPTrabajoEnCurso.Location = New System.Drawing.Point(4, 22)
        Me.TPTrabajoEnCurso.Name = "TPTrabajoEnCurso"
        Me.TPTrabajoEnCurso.Padding = New System.Windows.Forms.Padding(3)
        Me.TPTrabajoEnCurso.Size = New System.Drawing.Size(1262, 494)
        Me.TPTrabajoEnCurso.TabIndex = 0
        Me.TPTrabajoEnCurso.Text = "Trabajo en Curso"
        Me.TPTrabajoEnCurso.UseVisualStyleBackColor = True
        '
        'CBVendedor
        '
        Me.CBVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVendedor.FormattingEnabled = True
        Me.CBVendedor.Location = New System.Drawing.Point(11, 6)
        Me.CBVendedor.Name = "CBVendedor"
        Me.CBVendedor.Size = New System.Drawing.Size(238, 21)
        Me.CBVendedor.TabIndex = 10
        '
        'lbAdvertencia
        '
        Me.lbAdvertencia.AutoSize = True
        Me.lbAdvertencia.Font = New System.Drawing.Font("Microsoft Tai Le", 15.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbAdvertencia.ForeColor = System.Drawing.Color.Red
        Me.lbAdvertencia.Location = New System.Drawing.Point(497, 4)
        Me.lbAdvertencia.Name = "lbAdvertencia"
        Me.lbAdvertencia.Size = New System.Drawing.Size(0, 26)
        Me.lbAdvertencia.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TBComentarios)
        Me.GroupBox2.Controls.Add(Me.lbComentarios)
        Me.GroupBox2.Controls.Add(Me.DTPFentregaNE)
        Me.GroupBox2.Controls.Add(Me.lbDetalleEstado)
        Me.GroupBox2.Controls.Add(Me.TBComentariosHistorial)
        Me.GroupBox2.Controls.Add(Me.BTNGenerarEnvio)
        Me.GroupBox2.Controls.Add(Me.DGVArticuloNotaDeEnvio)
        Me.GroupBox2.Location = New System.Drawing.Point(775, 31)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(482, 456)
        Me.GroupBox2.TabIndex = 7
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Nota de Envio"
        '
        'TBComentarios
        '
        Me.TBComentarios.Location = New System.Drawing.Point(7, 355)
        Me.TBComentarios.Multiline = True
        Me.TBComentarios.Name = "TBComentarios"
        Me.TBComentarios.Size = New System.Drawing.Size(469, 56)
        Me.TBComentarios.TabIndex = 15
        '
        'lbComentarios
        '
        Me.lbComentarios.AutoSize = True
        Me.lbComentarios.Location = New System.Drawing.Point(10, 265)
        Me.lbComentarios.Name = "lbComentarios"
        Me.lbComentarios.Size = New System.Drawing.Size(68, 13)
        Me.lbComentarios.TabIndex = 14
        Me.lbComentarios.Text = "Comentarios:"
        '
        'DTPFentregaNE
        '
        Me.DTPFentregaNE.AllowDrop = True
        Me.DTPFentregaNE.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPFentregaNE.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPFentregaNE.Location = New System.Drawing.Point(274, 252)
        Me.DTPFentregaNE.Name = "DTPFentregaNE"
        Me.DTPFentregaNE.Size = New System.Drawing.Size(200, 20)
        Me.DTPFentregaNE.TabIndex = 13
        '
        'lbDetalleEstado
        '
        Me.lbDetalleEstado.AutoSize = True
        Me.lbDetalleEstado.Location = New System.Drawing.Point(58, 20)
        Me.lbDetalleEstado.Name = "lbDetalleEstado"
        Me.lbDetalleEstado.Size = New System.Drawing.Size(0, 13)
        Me.lbDetalleEstado.TabIndex = 12
        '
        'TBComentariosHistorial
        '
        Me.TBComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBComentariosHistorial.Location = New System.Drawing.Point(7, 281)
        Me.TBComentariosHistorial.Multiline = True
        Me.TBComentariosHistorial.Name = "TBComentariosHistorial"
        Me.TBComentariosHistorial.ReadOnly = True
        Me.TBComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBComentariosHistorial.Size = New System.Drawing.Size(469, 75)
        Me.TBComentariosHistorial.TabIndex = 0
        '
        'BTNGenerarEnvio
        '
        Me.BTNGenerarEnvio.Location = New System.Drawing.Point(373, 426)
        Me.BTNGenerarEnvio.Name = "BTNGenerarEnvio"
        Me.BTNGenerarEnvio.Size = New System.Drawing.Size(101, 23)
        Me.BTNGenerarEnvio.TabIndex = 10
        Me.BTNGenerarEnvio.Text = "Enviar"
        Me.BTNGenerarEnvio.UseVisualStyleBackColor = True
        '
        'DGVArticuloNotaDeEnvio
        '
        Me.DGVArticuloNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloNotaDeEnvio.Location = New System.Drawing.Point(7, 20)
        Me.DGVArticuloNotaDeEnvio.MultiSelect = False
        Me.DGVArticuloNotaDeEnvio.Name = "DGVArticuloNotaDeEnvio"
        Me.DGVArticuloNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloNotaDeEnvio.Size = New System.Drawing.Size(469, 223)
        Me.DGVArticuloNotaDeEnvio.TabIndex = 1
        '
        'TPPendiente
        '
        Me.TPPendiente.Controls.Add(Me.GroupBox5)
        Me.TPPendiente.Controls.Add(Me.GroupBox4)
        Me.TPPendiente.Location = New System.Drawing.Point(4, 22)
        Me.TPPendiente.Name = "TPPendiente"
        Me.TPPendiente.Padding = New System.Windows.Forms.Padding(3)
        Me.TPPendiente.Size = New System.Drawing.Size(1262, 494)
        Me.TPPendiente.TabIndex = 1
        Me.TPPendiente.Text = "Pendiente"
        Me.TPPendiente.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TBPendienteComentarios)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.BTNTrabajoEnCurso)
        Me.GroupBox5.Controls.Add(Me.DTPPendienteFechaDeEntrega)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.TBPendienteComentariosHistorial)
        Me.GroupBox5.Controls.Add(Me.BTNVerificarDisponibilidad)
        Me.GroupBox5.Controls.Add(Me.DGVPendienteDetalleArticuloNotaDeEnvio)
        Me.GroupBox5.Location = New System.Drawing.Point(585, 3)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(665, 485)
        Me.GroupBox5.TabIndex = 8
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Detalle"
        '
        'TBPendienteComentarios
        '
        Me.TBPendienteComentarios.Location = New System.Drawing.Point(7, 388)
        Me.TBPendienteComentarios.Multiline = True
        Me.TBPendienteComentarios.Name = "TBPendienteComentarios"
        Me.TBPendienteComentarios.Size = New System.Drawing.Size(652, 63)
        Me.TBPendienteComentarios.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(10, 276)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(68, 13)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Comentarios:"
        '
        'BTNTrabajoEnCurso
        '
        Me.BTNTrabajoEnCurso.Location = New System.Drawing.Point(425, 455)
        Me.BTNTrabajoEnCurso.Name = "BTNTrabajoEnCurso"
        Me.BTNTrabajoEnCurso.Size = New System.Drawing.Size(101, 23)
        Me.BTNTrabajoEnCurso.TabIndex = 14
        Me.BTNTrabajoEnCurso.Text = "Trabajo en Curso"
        Me.BTNTrabajoEnCurso.UseVisualStyleBackColor = True
        '
        'DTPPendienteFechaDeEntrega
        '
        Me.DTPPendienteFechaDeEntrega.AllowDrop = True
        Me.DTPPendienteFechaDeEntrega.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPPendienteFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPPendienteFechaDeEntrega.Location = New System.Drawing.Point(450, 265)
        Me.DTPPendienteFechaDeEntrega.Name = "DTPPendienteFechaDeEntrega"
        Me.DTPPendienteFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPPendienteFechaDeEntrega.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(58, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 12
        '
        'TBPendienteComentariosHistorial
        '
        Me.TBPendienteComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBPendienteComentariosHistorial.Location = New System.Drawing.Point(7, 291)
        Me.TBPendienteComentariosHistorial.Multiline = True
        Me.TBPendienteComentariosHistorial.Name = "TBPendienteComentariosHistorial"
        Me.TBPendienteComentariosHistorial.ReadOnly = True
        Me.TBPendienteComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBPendienteComentariosHistorial.Size = New System.Drawing.Size(652, 98)
        Me.TBPendienteComentariosHistorial.TabIndex = 0
        '
        'BTNVerificarDisponibilidad
        '
        Me.BTNVerificarDisponibilidad.Location = New System.Drawing.Point(530, 455)
        Me.BTNVerificarDisponibilidad.Name = "BTNVerificarDisponibilidad"
        Me.BTNVerificarDisponibilidad.Size = New System.Drawing.Size(125, 23)
        Me.BTNVerificarDisponibilidad.TabIndex = 10
        Me.BTNVerificarDisponibilidad.Text = "Verificar Disponibilidad"
        Me.BTNVerificarDisponibilidad.UseVisualStyleBackColor = True
        '
        'DGVPendienteDetalleArticuloNotaDeEnvio
        '
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.Location = New System.Drawing.Point(7, 20)
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.MultiSelect = False
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.Name = "DGVPendienteDetalleArticuloNotaDeEnvio"
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.ReadOnly = True
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.Size = New System.Drawing.Size(652, 240)
        Me.DGVPendienteDetalleArticuloNotaDeEnvio.TabIndex = 1
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.DGVPendienteNotaDeEnvio)
        Me.GroupBox4.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(573, 485)
        Me.GroupBox4.TabIndex = 6
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Nota de Envío"
        '
        'DGVPendienteNotaDeEnvio
        '
        Me.DGVPendienteNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPendienteNotaDeEnvio.Location = New System.Drawing.Point(4, 19)
        Me.DGVPendienteNotaDeEnvio.MultiSelect = False
        Me.DGVPendienteNotaDeEnvio.Name = "DGVPendienteNotaDeEnvio"
        Me.DGVPendienteNotaDeEnvio.ReadOnly = True
        Me.DGVPendienteNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPendienteNotaDeEnvio.Size = New System.Drawing.Size(563, 460)
        Me.DGVPendienteNotaDeEnvio.TabIndex = 0
        '
        'TPSujetaADisponibilidad
        '
        Me.TPSujetaADisponibilidad.Controls.Add(Me.GroupBox6)
        Me.TPSujetaADisponibilidad.Controls.Add(Me.GroupBox7)
        Me.TPSujetaADisponibilidad.Location = New System.Drawing.Point(4, 22)
        Me.TPSujetaADisponibilidad.Name = "TPSujetaADisponibilidad"
        Me.TPSujetaADisponibilidad.Size = New System.Drawing.Size(1262, 494)
        Me.TPSujetaADisponibilidad.TabIndex = 2
        Me.TPSujetaADisponibilidad.Text = "Sujeta a Disponibilidad"
        Me.TPSujetaADisponibilidad.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TBSujetaADisponibilidadComentariosHistorial)
        Me.GroupBox6.Controls.Add(Me.Label7)
        Me.GroupBox6.Controls.Add(Me.DTPSujetaADisponibilidadFechaDeEntrega)
        Me.GroupBox6.Controls.Add(Me.Label2)
        Me.GroupBox6.Controls.Add(Me.TBSujetaADisponibilidadComentarios)
        Me.GroupBox6.Controls.Add(Me.BTNRevisada)
        Me.GroupBox6.Controls.Add(Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio)
        Me.GroupBox6.Location = New System.Drawing.Point(586, 2)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(665, 485)
        Me.GroupBox6.TabIndex = 10
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Detalle"
        '
        'TBSujetaADisponibilidadComentariosHistorial
        '
        Me.TBSujetaADisponibilidadComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBSujetaADisponibilidadComentariosHistorial.Location = New System.Drawing.Point(7, 293)
        Me.TBSujetaADisponibilidadComentariosHistorial.Multiline = True
        Me.TBSujetaADisponibilidadComentariosHistorial.Name = "TBSujetaADisponibilidadComentariosHistorial"
        Me.TBSujetaADisponibilidadComentariosHistorial.ReadOnly = True
        Me.TBSujetaADisponibilidadComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBSujetaADisponibilidadComentariosHistorial.Size = New System.Drawing.Size(652, 98)
        Me.TBSujetaADisponibilidadComentariosHistorial.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(10, 277)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(68, 13)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Comentarios:"
        '
        'DTPSujetaADisponibilidadFechaDeEntrega
        '
        Me.DTPSujetaADisponibilidadFechaDeEntrega.AllowDrop = True
        Me.DTPSujetaADisponibilidadFechaDeEntrega.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPSujetaADisponibilidadFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPSujetaADisponibilidadFechaDeEntrega.Location = New System.Drawing.Point(450, 267)
        Me.DTPSujetaADisponibilidadFechaDeEntrega.Name = "DTPSujetaADisponibilidadFechaDeEntrega"
        Me.DTPSujetaADisponibilidadFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPSujetaADisponibilidadFechaDeEntrega.TabIndex = 13
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(58, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(0, 13)
        Me.Label2.TabIndex = 12
        '
        'TBSujetaADisponibilidadComentarios
        '
        Me.TBSujetaADisponibilidadComentarios.Location = New System.Drawing.Point(7, 390)
        Me.TBSujetaADisponibilidadComentarios.Multiline = True
        Me.TBSujetaADisponibilidadComentarios.Name = "TBSujetaADisponibilidadComentarios"
        Me.TBSujetaADisponibilidadComentarios.Size = New System.Drawing.Size(652, 63)
        Me.TBSujetaADisponibilidadComentarios.TabIndex = 0
        '
        'BTNRevisada
        '
        Me.BTNRevisada.Location = New System.Drawing.Point(525, 457)
        Me.BTNRevisada.Name = "BTNRevisada"
        Me.BTNRevisada.Size = New System.Drawing.Size(125, 23)
        Me.BTNRevisada.TabIndex = 10
        Me.BTNRevisada.Text = "Revisada"
        Me.BTNRevisada.UseVisualStyleBackColor = True
        '
        'DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio
        '
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Location = New System.Drawing.Point(7, 20)
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.MultiSelect = False
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Name = "DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio"
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.ReadOnly = True
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.Size = New System.Drawing.Size(652, 240)
        Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio.TabIndex = 1
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.DGVSujetaADisponibilidadNotaDeEnvio)
        Me.GroupBox7.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(573, 485)
        Me.GroupBox7.TabIndex = 9
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "NotaDeEnvio"
        '
        'DGVSujetaADisponibilidadNotaDeEnvio
        '
        Me.DGVSujetaADisponibilidadNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSujetaADisponibilidadNotaDeEnvio.Location = New System.Drawing.Point(4, 19)
        Me.DGVSujetaADisponibilidadNotaDeEnvio.MultiSelect = False
        Me.DGVSujetaADisponibilidadNotaDeEnvio.Name = "DGVSujetaADisponibilidadNotaDeEnvio"
        Me.DGVSujetaADisponibilidadNotaDeEnvio.ReadOnly = True
        Me.DGVSujetaADisponibilidadNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSujetaADisponibilidadNotaDeEnvio.Size = New System.Drawing.Size(563, 460)
        Me.DGVSujetaADisponibilidadNotaDeEnvio.TabIndex = 0
        '
        'TPRevisada
        '
        Me.TPRevisada.Controls.Add(Me.GroupBox8)
        Me.TPRevisada.Controls.Add(Me.GroupBox9)
        Me.TPRevisada.Location = New System.Drawing.Point(4, 22)
        Me.TPRevisada.Name = "TPRevisada"
        Me.TPRevisada.Size = New System.Drawing.Size(1262, 494)
        Me.TPRevisada.TabIndex = 3
        Me.TPRevisada.Text = "Revisada"
        Me.TPRevisada.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.TBRevisadaComentariosHistorial)
        Me.GroupBox8.Controls.Add(Me.Label8)
        Me.GroupBox8.Controls.Add(Me.DTPRevisadaFechaDeEntrega)
        Me.GroupBox8.Controls.Add(Me.Label3)
        Me.GroupBox8.Controls.Add(Me.TBRevisadaComentarios)
        Me.GroupBox8.Controls.Add(Me.BTNConfirmar)
        Me.GroupBox8.Controls.Add(Me.DGVRevisadaDetalleArticuloNotaDeEnvio)
        Me.GroupBox8.Location = New System.Drawing.Point(584, 3)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(665, 485)
        Me.GroupBox8.TabIndex = 12
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Detalle de Envío"
        '
        'TBRevisadaComentariosHistorial
        '
        Me.TBRevisadaComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBRevisadaComentariosHistorial.Location = New System.Drawing.Point(7, 291)
        Me.TBRevisadaComentariosHistorial.Multiline = True
        Me.TBRevisadaComentariosHistorial.Name = "TBRevisadaComentariosHistorial"
        Me.TBRevisadaComentariosHistorial.ReadOnly = True
        Me.TBRevisadaComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBRevisadaComentariosHistorial.Size = New System.Drawing.Size(652, 98)
        Me.TBRevisadaComentariosHistorial.TabIndex = 17
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(10, 275)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(68, 13)
        Me.Label8.TabIndex = 15
        Me.Label8.Text = "Comentarios:"
        '
        'DTPRevisadaFechaDeEntrega
        '
        Me.DTPRevisadaFechaDeEntrega.AllowDrop = True
        Me.DTPRevisadaFechaDeEntrega.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPRevisadaFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPRevisadaFechaDeEntrega.Location = New System.Drawing.Point(453, 264)
        Me.DTPRevisadaFechaDeEntrega.Name = "DTPRevisadaFechaDeEntrega"
        Me.DTPRevisadaFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPRevisadaFechaDeEntrega.TabIndex = 13
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(58, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 12
        '
        'TBRevisadaComentarios
        '
        Me.TBRevisadaComentarios.Location = New System.Drawing.Point(7, 388)
        Me.TBRevisadaComentarios.Multiline = True
        Me.TBRevisadaComentarios.Name = "TBRevisadaComentarios"
        Me.TBRevisadaComentarios.Size = New System.Drawing.Size(652, 63)
        Me.TBRevisadaComentarios.TabIndex = 0
        '
        'BTNConfirmar
        '
        Me.BTNConfirmar.Location = New System.Drawing.Point(535, 456)
        Me.BTNConfirmar.Name = "BTNConfirmar"
        Me.BTNConfirmar.Size = New System.Drawing.Size(125, 23)
        Me.BTNConfirmar.TabIndex = 10
        Me.BTNConfirmar.Text = "Confirmar"
        Me.BTNConfirmar.UseVisualStyleBackColor = True
        '
        'DGVRevisadaDetalleArticuloNotaDeEnvio
        '
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.Location = New System.Drawing.Point(7, 20)
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.MultiSelect = False
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.Name = "DGVRevisadaDetalleArticuloNotaDeEnvio"
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.ReadOnly = True
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.Size = New System.Drawing.Size(652, 240)
        Me.DGVRevisadaDetalleArticuloNotaDeEnvio.TabIndex = 1
        '
        'GroupBox9
        '
        Me.GroupBox9.Controls.Add(Me.DGVRevisadaNotaDeEnvio)
        Me.GroupBox9.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox9.Name = "GroupBox9"
        Me.GroupBox9.Size = New System.Drawing.Size(573, 485)
        Me.GroupBox9.TabIndex = 11
        Me.GroupBox9.TabStop = False
        Me.GroupBox9.Text = "Nota de Envío"
        '
        'DGVRevisadaNotaDeEnvio
        '
        Me.DGVRevisadaNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVRevisadaNotaDeEnvio.Location = New System.Drawing.Point(4, 19)
        Me.DGVRevisadaNotaDeEnvio.MultiSelect = False
        Me.DGVRevisadaNotaDeEnvio.Name = "DGVRevisadaNotaDeEnvio"
        Me.DGVRevisadaNotaDeEnvio.ReadOnly = True
        Me.DGVRevisadaNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVRevisadaNotaDeEnvio.Size = New System.Drawing.Size(563, 460)
        Me.DGVRevisadaNotaDeEnvio.TabIndex = 0
        '
        'TPConfirmada
        '
        Me.TPConfirmada.Controls.Add(Me.GroupBox10)
        Me.TPConfirmada.Controls.Add(Me.GroupBox11)
        Me.TPConfirmada.Location = New System.Drawing.Point(4, 22)
        Me.TPConfirmada.Name = "TPConfirmada"
        Me.TPConfirmada.Size = New System.Drawing.Size(1262, 494)
        Me.TPConfirmada.TabIndex = 4
        Me.TPConfirmada.Text = "Confirmada"
        Me.TPConfirmada.UseVisualStyleBackColor = True
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.TBConfirmadaComentariosHistorial)
        Me.GroupBox10.Controls.Add(Me.Label9)
        Me.GroupBox10.Controls.Add(Me.DTPConfirmadaFechaDeEntrega)
        Me.GroupBox10.Controls.Add(Me.Label4)
        Me.GroupBox10.Controls.Add(Me.TBConfirmadaComentarios)
        Me.GroupBox10.Controls.Add(Me.BTNEntregada)
        Me.GroupBox10.Controls.Add(Me.c)
        Me.GroupBox10.Location = New System.Drawing.Point(583, 3)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(665, 485)
        Me.GroupBox10.TabIndex = 12
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Detalle de Envío"
        '
        'TBConfirmadaComentariosHistorial
        '
        Me.TBConfirmadaComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBConfirmadaComentariosHistorial.Location = New System.Drawing.Point(7, 289)
        Me.TBConfirmadaComentariosHistorial.Multiline = True
        Me.TBConfirmadaComentariosHistorial.Name = "TBConfirmadaComentariosHistorial"
        Me.TBConfirmadaComentariosHistorial.ReadOnly = True
        Me.TBConfirmadaComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBConfirmadaComentariosHistorial.Size = New System.Drawing.Size(652, 98)
        Me.TBConfirmadaComentariosHistorial.TabIndex = 18
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(10, 270)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(68, 13)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Comentarios:"
        '
        'DTPConfirmadaFechaDeEntrega
        '
        Me.DTPConfirmadaFechaDeEntrega.AllowDrop = True
        Me.DTPConfirmadaFechaDeEntrega.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPConfirmadaFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPConfirmadaFechaDeEntrega.Location = New System.Drawing.Point(450, 266)
        Me.DTPConfirmadaFechaDeEntrega.Name = "DTPConfirmadaFechaDeEntrega"
        Me.DTPConfirmadaFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPConfirmadaFechaDeEntrega.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(58, 20)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 12
        '
        'TBConfirmadaComentarios
        '
        Me.TBConfirmadaComentarios.Location = New System.Drawing.Point(7, 386)
        Me.TBConfirmadaComentarios.Multiline = True
        Me.TBConfirmadaComentarios.Name = "TBConfirmadaComentarios"
        Me.TBConfirmadaComentarios.Size = New System.Drawing.Size(652, 63)
        Me.TBConfirmadaComentarios.TabIndex = 0
        '
        'BTNEntregada
        '
        Me.BTNEntregada.Location = New System.Drawing.Point(531, 455)
        Me.BTNEntregada.Name = "BTNEntregada"
        Me.BTNEntregada.Size = New System.Drawing.Size(125, 23)
        Me.BTNEntregada.TabIndex = 10
        Me.BTNEntregada.Text = "Entregada"
        Me.BTNEntregada.UseVisualStyleBackColor = True
        '
        'c
        '
        Me.c.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.c.Location = New System.Drawing.Point(7, 20)
        Me.c.MultiSelect = False
        Me.c.Name = "c"
        Me.c.ReadOnly = True
        Me.c.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.c.Size = New System.Drawing.Size(652, 240)
        Me.c.TabIndex = 1
        '
        'GroupBox11
        '
        Me.GroupBox11.Controls.Add(Me.DGVConfirmadaNotaDeEnvio)
        Me.GroupBox11.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox11.Name = "GroupBox11"
        Me.GroupBox11.Size = New System.Drawing.Size(573, 485)
        Me.GroupBox11.TabIndex = 11
        Me.GroupBox11.TabStop = False
        Me.GroupBox11.Text = "Nota de Envío"
        '
        'DGVConfirmadaNotaDeEnvio
        '
        Me.DGVConfirmadaNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVConfirmadaNotaDeEnvio.Location = New System.Drawing.Point(4, 19)
        Me.DGVConfirmadaNotaDeEnvio.MultiSelect = False
        Me.DGVConfirmadaNotaDeEnvio.Name = "DGVConfirmadaNotaDeEnvio"
        Me.DGVConfirmadaNotaDeEnvio.ReadOnly = True
        Me.DGVConfirmadaNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVConfirmadaNotaDeEnvio.Size = New System.Drawing.Size(563, 460)
        Me.DGVConfirmadaNotaDeEnvio.TabIndex = 0
        '
        'TPEntregada
        '
        Me.TPEntregada.Controls.Add(Me.GroupBox12)
        Me.TPEntregada.Controls.Add(Me.GroupBox13)
        Me.TPEntregada.Location = New System.Drawing.Point(4, 22)
        Me.TPEntregada.Name = "TPEntregada"
        Me.TPEntregada.Size = New System.Drawing.Size(1262, 494)
        Me.TPEntregada.TabIndex = 5
        Me.TPEntregada.Text = "Entregada"
        Me.TPEntregada.UseVisualStyleBackColor = True
        '
        'GroupBox12
        '
        Me.GroupBox12.Controls.Add(Me.TBEntregadaComentariosHistorial)
        Me.GroupBox12.Controls.Add(Me.Label10)
        Me.GroupBox12.Controls.Add(Me.DTPEntregadaFechaDeEntrega)
        Me.GroupBox12.Controls.Add(Me.Label5)
        Me.GroupBox12.Controls.Add(Me.DGVEntregadaDetalleArticuloNotaDeEnvio)
        Me.GroupBox12.Location = New System.Drawing.Point(582, 3)
        Me.GroupBox12.Name = "GroupBox12"
        Me.GroupBox12.Size = New System.Drawing.Size(665, 485)
        Me.GroupBox12.TabIndex = 12
        Me.GroupBox12.TabStop = False
        Me.GroupBox12.Text = "Nota de Envio"
        '
        'TBEntregadaComentariosHistorial
        '
        Me.TBEntregadaComentariosHistorial.BackColor = System.Drawing.SystemColors.ControlLight
        Me.TBEntregadaComentariosHistorial.Location = New System.Drawing.Point(7, 287)
        Me.TBEntregadaComentariosHistorial.Multiline = True
        Me.TBEntregadaComentariosHistorial.Name = "TBEntregadaComentariosHistorial"
        Me.TBEntregadaComentariosHistorial.ReadOnly = True
        Me.TBEntregadaComentariosHistorial.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBEntregadaComentariosHistorial.Size = New System.Drawing.Size(652, 183)
        Me.TBEntregadaComentariosHistorial.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 271)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 13)
        Me.Label10.TabIndex = 15
        Me.Label10.Text = "Comentarios:"
        '
        'DTPEntregadaFechaDeEntrega
        '
        Me.DTPEntregadaFechaDeEntrega.AllowDrop = True
        Me.DTPEntregadaFechaDeEntrega.CustomFormat = "dd' de ' MMMM'a las ' HH:mm"
        Me.DTPEntregadaFechaDeEntrega.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPEntregadaFechaDeEntrega.Location = New System.Drawing.Point(452, 264)
        Me.DTPEntregadaFechaDeEntrega.Name = "DTPEntregadaFechaDeEntrega"
        Me.DTPEntregadaFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPEntregadaFechaDeEntrega.TabIndex = 13
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(58, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 12
        '
        'DGVEntregadaDetalleArticuloNotaDeEnvio
        '
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.Location = New System.Drawing.Point(7, 20)
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.MultiSelect = False
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.Name = "DGVEntregadaDetalleArticuloNotaDeEnvio"
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.ReadOnly = True
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.Size = New System.Drawing.Size(652, 240)
        Me.DGVEntregadaDetalleArticuloNotaDeEnvio.TabIndex = 1
        '
        'GroupBox13
        '
        Me.GroupBox13.Controls.Add(Me.DGVEntregadaNotaDeEnvio)
        Me.GroupBox13.Location = New System.Drawing.Point(6, 3)
        Me.GroupBox13.Name = "GroupBox13"
        Me.GroupBox13.Size = New System.Drawing.Size(573, 485)
        Me.GroupBox13.TabIndex = 11
        Me.GroupBox13.TabStop = False
        Me.GroupBox13.Text = "Vendedores"
        '
        'DGVEntregadaNotaDeEnvio
        '
        Me.DGVEntregadaNotaDeEnvio.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVEntregadaNotaDeEnvio.Location = New System.Drawing.Point(4, 19)
        Me.DGVEntregadaNotaDeEnvio.MultiSelect = False
        Me.DGVEntregadaNotaDeEnvio.Name = "DGVEntregadaNotaDeEnvio"
        Me.DGVEntregadaNotaDeEnvio.ReadOnly = True
        Me.DGVEntregadaNotaDeEnvio.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVEntregadaNotaDeEnvio.Size = New System.Drawing.Size(563, 460)
        Me.DGVEntregadaNotaDeEnvio.TabIndex = 0
        '
        'FormNotaDeEnvio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1274, 556)
        Me.Controls.Add(Me.TC)
        Me.Controls.Add(Me.BTNSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNotaDeEnvio"
        Me.Text = "Nota de Envío"
        Me.GBPedidos.ResumeLayout(False)
        CType(Me.DGVPedidoDeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.DGVArticuloPedidoDeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TC.ResumeLayout(False)
        Me.TPTrabajoEnCurso.ResumeLayout(False)
        Me.TPTrabajoEnCurso.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.DGVArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPPendiente.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.DGVPendienteDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.DGVPendienteNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPSujetaADisponibilidad.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.DGVSujetaADisponibilidadNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPRevisada.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        CType(Me.DGVRevisadaDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox9.ResumeLayout(False)
        CType(Me.DGVRevisadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPConfirmada.ResumeLayout(False)
        Me.GroupBox10.ResumeLayout(False)
        Me.GroupBox10.PerformLayout()
        CType(Me.c, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox11.ResumeLayout(False)
        CType(Me.DGVConfirmadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPEntregada.ResumeLayout(False)
        Me.GroupBox12.ResumeLayout(False)
        Me.GroupBox12.PerformLayout()
        CType(Me.DGVEntregadaDetalleArticuloNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox13.ResumeLayout(False)
        CType(Me.DGVEntregadaNotaDeEnvio, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GBPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents DGVPedidoDeCliente As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVClientes As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNCancelarPedidoDeCliente As System.Windows.Forms.Button
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbIDCliente As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lbFechaDeEntrega As System.Windows.Forms.Label
    Friend WithEvents DTPFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNAgregar As System.Windows.Forms.Button
    Friend WithEvents DGVArticuloPedidoDeCliente As System.Windows.Forms.DataGridView
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents TC As System.Windows.Forms.TabControl
    Friend WithEvents TPTrabajoEnCurso As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPFentregaNE As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbDetalleEstado As System.Windows.Forms.Label
    Friend WithEvents TBComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents BTNGenerarEnvio As System.Windows.Forms.Button
    Friend WithEvents DGVArticuloNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents TPPendiente As System.Windows.Forms.TabPage
    Friend WithEvents lbAdvertencia As System.Windows.Forms.Label
    Friend WithEvents TPSujetaADisponibilidad As System.Windows.Forms.TabPage
    Friend WithEvents TPRevisada As System.Windows.Forms.TabPage
    Friend WithEvents TPConfirmada As System.Windows.Forms.TabPage
    Friend WithEvents TPEntregada As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNTrabajoEnCurso As System.Windows.Forms.Button
    Friend WithEvents DTPPendienteFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TBPendienteComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents BTNVerificarDisponibilidad As System.Windows.Forms.Button
    Friend WithEvents DGVPendienteDetalleArticuloNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVPendienteNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPSujetaADisponibilidadFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TBSujetaADisponibilidadComentarios As System.Windows.Forms.TextBox
    Friend WithEvents BTNRevisada As System.Windows.Forms.Button
    Friend WithEvents DGVSujetaADisponibilidadDetalleArticuloNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVSujetaADisponibilidadNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPRevisadaFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TBRevisadaComentarios As System.Windows.Forms.TextBox
    Friend WithEvents BTNConfirmar As System.Windows.Forms.Button
    Friend WithEvents DGVRevisadaDetalleArticuloNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox9 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVRevisadaNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPConfirmadaFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TBConfirmadaComentarios As System.Windows.Forms.TextBox
    Friend WithEvents BTNEntregada As System.Windows.Forms.Button
    Friend WithEvents c As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox11 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVConfirmadaNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox12 As System.Windows.Forms.GroupBox
    Friend WithEvents DTPEntregadaFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DGVEntregadaDetalleArticuloNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox13 As System.Windows.Forms.GroupBox
    Friend WithEvents DGVEntregadaNotaDeEnvio As System.Windows.Forms.DataGridView
    Friend WithEvents lbComentarios As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents TBPendienteComentarios As System.Windows.Forms.TextBox
    Friend WithEvents TBComentarios As System.Windows.Forms.TextBox
    Friend WithEvents CBVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents TBSujetaADisponibilidadComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents TBRevisadaComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents TBConfirmadaComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents TBEntregadaComentariosHistorial As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As ToolTip
End Class
