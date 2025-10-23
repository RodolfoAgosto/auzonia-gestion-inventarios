<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPedidoDeCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPedidoDeCliente))
        Me.GBClientes = New System.Windows.Forms.GroupBox()
        Me.DGVClientes = New System.Windows.Forms.DataGridView()
        Me.GBPedidos = New System.Windows.Forms.GroupBox()
        Me.DGVPedidoDeCliente = New System.Windows.Forms.DataGridView()
        Me.GPDetallePedido = New System.Windows.Forms.GroupBox()
        Me.BTNCancelarPedidoDeCliente = New System.Windows.Forms.Button()
        Me.GBComentarios = New System.Windows.Forms.GroupBox()
        Me.TBNuevoComentario = New System.Windows.Forms.TextBox()
        Me.TBComentarios = New System.Windows.Forms.TextBox()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBIDCliente = New System.Windows.Forms.TextBox()
        Me.lbIDCliente = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.lbFechaDeEntrega = New System.Windows.Forms.Label()
        Me.DTPFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.BTNGuardarCambios = New System.Windows.Forms.Button()
        Me.DGVArticuloPedidoDeCliente = New System.Windows.Forms.DataGridView()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.BTNGenerarPedido = New System.Windows.Forms.Button()
        Me.CBVendedor = New System.Windows.Forms.ComboBox()
        Me.lbVendedor = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBClientes.SuspendLayout()
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPedidos.SuspendLayout()
        CType(Me.DGVPedidoDeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPDetallePedido.SuspendLayout()
        Me.GBComentarios.SuspendLayout()
        CType(Me.DGVArticuloPedidoDeCliente, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GBClientes
        '
        Me.GBClientes.Controls.Add(Me.DGVClientes)
        Me.GBClientes.Location = New System.Drawing.Point(12, 45)
        Me.GBClientes.Name = "GBClientes"
        Me.GBClientes.Size = New System.Drawing.Size(554, 131)
        Me.GBClientes.TabIndex = 0
        Me.GBClientes.TabStop = False
        Me.GBClientes.Text = "Clientes"
        '
        'DGVClientes
        '
        Me.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVClientes.Location = New System.Drawing.Point(5, 19)
        Me.DGVClientes.MultiSelect = False
        Me.DGVClientes.Name = "DGVClientes"
        Me.DGVClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVClientes.Size = New System.Drawing.Size(544, 106)
        Me.DGVClientes.TabIndex = 0
        '
        'GBPedidos
        '
        Me.GBPedidos.Controls.Add(Me.DGVPedidoDeCliente)
        Me.GBPedidos.Location = New System.Drawing.Point(575, 45)
        Me.GBPedidos.Name = "GBPedidos"
        Me.GBPedidos.Size = New System.Drawing.Size(382, 131)
        Me.GBPedidos.TabIndex = 1
        Me.GBPedidos.TabStop = False
        Me.GBPedidos.Text = "Pedidos"
        '
        'DGVPedidoDeCliente
        '
        Me.DGVPedidoDeCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPedidoDeCliente.Location = New System.Drawing.Point(6, 19)
        Me.DGVPedidoDeCliente.MultiSelect = False
        Me.DGVPedidoDeCliente.Name = "DGVPedidoDeCliente"
        Me.DGVPedidoDeCliente.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.DGVPedidoDeCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPedidoDeCliente.Size = New System.Drawing.Size(370, 106)
        Me.DGVPedidoDeCliente.TabIndex = 1
        '
        'GPDetallePedido
        '
        Me.GPDetallePedido.Controls.Add(Me.BTNCancelarPedidoDeCliente)
        Me.GPDetallePedido.Controls.Add(Me.GBComentarios)
        Me.GPDetallePedido.Controls.Add(Me.TBRazonSocial)
        Me.GPDetallePedido.Controls.Add(Me.TBIDCliente)
        Me.GPDetallePedido.Controls.Add(Me.lbIDCliente)
        Me.GPDetallePedido.Controls.Add(Me.lbRazonSocial)
        Me.GPDetallePedido.Controls.Add(Me.lbFechaDeEntrega)
        Me.GPDetallePedido.Controls.Add(Me.DTPFechaDeEntrega)
        Me.GPDetallePedido.Controls.Add(Me.BTNGuardarCambios)
        Me.GPDetallePedido.Controls.Add(Me.DGVArticuloPedidoDeCliente)
        Me.GPDetallePedido.Location = New System.Drawing.Point(12, 182)
        Me.GPDetallePedido.Name = "GPDetallePedido"
        Me.GPDetallePedido.Size = New System.Drawing.Size(946, 370)
        Me.GPDetallePedido.TabIndex = 1
        Me.GPDetallePedido.TabStop = False
        Me.GPDetallePedido.Text = "Detalle Pedido"
        '
        'BTNCancelarPedidoDeCliente
        '
        Me.BTNCancelarPedidoDeCliente.Location = New System.Drawing.Point(684, 337)
        Me.BTNCancelarPedidoDeCliente.Name = "BTNCancelarPedidoDeCliente"
        Me.BTNCancelarPedidoDeCliente.Size = New System.Drawing.Size(122, 23)
        Me.BTNCancelarPedidoDeCliente.TabIndex = 22
        Me.BTNCancelarPedidoDeCliente.Text = "Cancelar"
        Me.BTNCancelarPedidoDeCliente.UseVisualStyleBackColor = True
        '
        'GBComentarios
        '
        Me.GBComentarios.Controls.Add(Me.TBNuevoComentario)
        Me.GBComentarios.Controls.Add(Me.TBComentarios)
        Me.GBComentarios.Location = New System.Drawing.Point(7, 196)
        Me.GBComentarios.Name = "GBComentarios"
        Me.GBComentarios.Size = New System.Drawing.Size(933, 135)
        Me.GBComentarios.TabIndex = 21
        Me.GBComentarios.TabStop = False
        Me.GBComentarios.Text = "Comentarios"
        '
        'TBNuevoComentario
        '
        Me.TBNuevoComentario.Location = New System.Drawing.Point(6, 97)
        Me.TBNuevoComentario.Multiline = True
        Me.TBNuevoComentario.Name = "TBNuevoComentario"
        Me.TBNuevoComentario.Size = New System.Drawing.Size(921, 33)
        Me.TBNuevoComentario.TabIndex = 1
        '
        'TBComentarios
        '
        Me.TBComentarios.BackColor = System.Drawing.SystemColors.ScrollBar
        Me.TBComentarios.Location = New System.Drawing.Point(6, 18)
        Me.TBComentarios.Multiline = True
        Me.TBComentarios.Name = "TBComentarios"
        Me.TBComentarios.ReadOnly = True
        Me.TBComentarios.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TBComentarios.Size = New System.Drawing.Size(921, 81)
        Me.TBComentarios.TabIndex = 0
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
        Me.DTPFechaDeEntrega.Location = New System.Drawing.Point(439, 32)
        Me.DTPFechaDeEntrega.Name = "DTPFechaDeEntrega"
        Me.DTPFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaDeEntrega.TabIndex = 15
        '
        'BTNGuardarCambios
        '
        Me.BTNGuardarCambios.Location = New System.Drawing.Point(812, 337)
        Me.BTNGuardarCambios.Name = "BTNGuardarCambios"
        Me.BTNGuardarCambios.Size = New System.Drawing.Size(122, 23)
        Me.BTNGuardarCambios.TabIndex = 2
        Me.BTNGuardarCambios.Text = "Guardar Cambios"
        Me.BTNGuardarCambios.UseVisualStyleBackColor = True
        '
        'DGVArticuloPedidoDeCliente
        '
        Me.DGVArticuloPedidoDeCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloPedidoDeCliente.Location = New System.Drawing.Point(6, 59)
        Me.DGVArticuloPedidoDeCliente.Name = "DGVArticuloPedidoDeCliente"
        Me.DGVArticuloPedidoDeCliente.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloPedidoDeCliente.Size = New System.Drawing.Size(934, 131)
        Me.DGVArticuloPedidoDeCliente.TabIndex = 1
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(863, 558)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 21)
        Me.BTNSalir.TabIndex = 2
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'BTNGenerarPedido
        '
        Me.BTNGenerarPedido.Location = New System.Drawing.Point(758, 558)
        Me.BTNGenerarPedido.Name = "BTNGenerarPedido"
        Me.BTNGenerarPedido.Size = New System.Drawing.Size(101, 21)
        Me.BTNGenerarPedido.TabIndex = 3
        Me.BTNGenerarPedido.Text = "Generar Pedido"
        Me.BTNGenerarPedido.UseVisualStyleBackColor = True
        '
        'CBVendedor
        '
        Me.CBVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVendedor.FormattingEnabled = True
        Me.CBVendedor.Location = New System.Drawing.Point(13, 20)
        Me.CBVendedor.Name = "CBVendedor"
        Me.CBVendedor.Size = New System.Drawing.Size(283, 21)
        Me.CBVendedor.TabIndex = 4
        '
        'lbVendedor
        '
        Me.lbVendedor.AutoSize = True
        Me.lbVendedor.Location = New System.Drawing.Point(16, 5)
        Me.lbVendedor.Name = "lbVendedor"
        Me.lbVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lbVendedor.TabIndex = 5
        Me.lbVendedor.Text = "Vendedor"
        '
        'FormPedidoDeCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(970, 591)
        Me.Controls.Add(Me.lbVendedor)
        Me.Controls.Add(Me.CBVendedor)
        Me.Controls.Add(Me.BTNGenerarPedido)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.GPDetallePedido)
        Me.Controls.Add(Me.GBPedidos)
        Me.Controls.Add(Me.GBClientes)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormPedidoDeCliente"
        Me.Text = "Pedidos de clientes"
        Me.GBClientes.ResumeLayout(False)
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPedidos.ResumeLayout(False)
        CType(Me.DGVPedidoDeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPDetallePedido.ResumeLayout(False)
        Me.GPDetallePedido.PerformLayout()
        Me.GBComentarios.ResumeLayout(False)
        Me.GBComentarios.PerformLayout()
        CType(Me.DGVArticuloPedidoDeCliente, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GBClientes As System.Windows.Forms.GroupBox
    Friend WithEvents DGVClientes As System.Windows.Forms.DataGridView
    Friend WithEvents GBPedidos As System.Windows.Forms.GroupBox
    Friend WithEvents GPDetallePedido As System.Windows.Forms.GroupBox
    Friend WithEvents DGVPedidoDeCliente As System.Windows.Forms.DataGridView
    Friend WithEvents BTNGuardarCambios As System.Windows.Forms.Button
    Friend WithEvents DGVArticuloPedidoDeCliente As System.Windows.Forms.DataGridView
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents BTNGenerarPedido As System.Windows.Forms.Button
    Friend WithEvents CBVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbVendedor As System.Windows.Forms.Label
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbIDCliente As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lbFechaDeEntrega As System.Windows.Forms.Label
    Friend WithEvents DTPFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents GBComentarios As System.Windows.Forms.GroupBox
    Friend WithEvents TBComentarios As System.Windows.Forms.TextBox
    Friend WithEvents BTNCancelarPedidoDeCliente As System.Windows.Forms.Button
    Friend WithEvents TBNuevoComentario As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As ToolTip
End Class
