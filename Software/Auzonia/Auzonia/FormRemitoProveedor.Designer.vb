<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRemitoProveedor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRemitoProveedor))
        Me.lbProveedor = New System.Windows.Forms.Label()
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.GBRemitoProveedor = New System.Windows.Forms.GroupBox()
        Me.DGVRemitoProveedor = New System.Windows.Forms.DataGridView()
        Me.GBDetallePedido = New System.Windows.Forms.GroupBox()
        Me.BTNCancelarPedidoDeCliente = New System.Windows.Forms.Button()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBIDRemitoProveedor = New System.Windows.Forms.TextBox()
        Me.lbIDRemitoProveedor = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.lbFechaDeEntrega = New System.Windows.Forms.Label()
        Me.DTPFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.BTNGuardarCambios = New System.Windows.Forms.Button()
        Me.DGVArticuloRemitoProveedor = New System.Windows.Forms.DataGridView()
        Me.BTNGenerarRemito = New System.Windows.Forms.Button()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBRemitoProveedor.SuspendLayout()
        CType(Me.DGVRemitoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBDetallePedido.SuspendLayout()
        CType(Me.DGVArticuloRemitoProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbProveedor
        '
        Me.lbProveedor.AutoSize = True
        Me.lbProveedor.Location = New System.Drawing.Point(9, 4)
        Me.lbProveedor.Name = "lbProveedor"
        Me.lbProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbProveedor.TabIndex = 8
        Me.lbProveedor.Text = "Proveedor"
        '
        'CBProveedor
        '
        Me.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProveedor.FormattingEnabled = True
        Me.CBProveedor.Location = New System.Drawing.Point(6, 19)
        Me.CBProveedor.Name = "CBProveedor"
        Me.CBProveedor.Size = New System.Drawing.Size(283, 21)
        Me.CBProveedor.TabIndex = 7
        '
        'GBRemitoProveedor
        '
        Me.GBRemitoProveedor.Controls.Add(Me.DGVRemitoProveedor)
        Me.GBRemitoProveedor.Location = New System.Drawing.Point(5, 44)
        Me.GBRemitoProveedor.Name = "GBRemitoProveedor"
        Me.GBRemitoProveedor.Size = New System.Drawing.Size(454, 341)
        Me.GBRemitoProveedor.TabIndex = 6
        Me.GBRemitoProveedor.TabStop = False
        Me.GBRemitoProveedor.Text = "Remito Proveedor"
        '
        'DGVRemitoProveedor
        '
        Me.DGVRemitoProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVRemitoProveedor.Location = New System.Drawing.Point(6, 19)
        Me.DGVRemitoProveedor.MultiSelect = False
        Me.DGVRemitoProveedor.Name = "DGVRemitoProveedor"
        Me.DGVRemitoProveedor.ReadOnly = True
        Me.DGVRemitoProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVRemitoProveedor.Size = New System.Drawing.Size(442, 314)
        Me.DGVRemitoProveedor.TabIndex = 0
        '
        'GBDetallePedido
        '
        Me.GBDetallePedido.Controls.Add(Me.BTNCancelarPedidoDeCliente)
        Me.GBDetallePedido.Controls.Add(Me.TBRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.TBIDRemitoProveedor)
        Me.GBDetallePedido.Controls.Add(Me.lbIDRemitoProveedor)
        Me.GBDetallePedido.Controls.Add(Me.lbRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.lbFechaDeEntrega)
        Me.GBDetallePedido.Controls.Add(Me.DTPFechaDeEntrega)
        Me.GBDetallePedido.Controls.Add(Me.BTNGuardarCambios)
        Me.GBDetallePedido.Controls.Add(Me.DGVArticuloRemitoProveedor)
        Me.GBDetallePedido.Location = New System.Drawing.Point(465, 19)
        Me.GBDetallePedido.Name = "GBDetallePedido"
        Me.GBDetallePedido.Size = New System.Drawing.Size(643, 366)
        Me.GBDetallePedido.TabIndex = 9
        Me.GBDetallePedido.TabStop = False
        Me.GBDetallePedido.Text = "Detalle Pedido"
        '
        'BTNCancelarPedidoDeCliente
        '
        Me.BTNCancelarPedidoDeCliente.Location = New System.Drawing.Point(306, 335)
        Me.BTNCancelarPedidoDeCliente.Name = "BTNCancelarPedidoDeCliente"
        Me.BTNCancelarPedidoDeCliente.Size = New System.Drawing.Size(151, 23)
        Me.BTNCancelarPedidoDeCliente.TabIndex = 22
        Me.BTNCancelarPedidoDeCliente.Text = "Cancelar"
        Me.BTNCancelarPedidoDeCliente.UseVisualStyleBackColor = True
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Enabled = False
        Me.TBRazonSocial.Location = New System.Drawing.Point(143, 70)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(317, 20)
        Me.TBRazonSocial.TabIndex = 20
        '
        'TBIDRemitoProveedor
        '
        Me.TBIDRemitoProveedor.Enabled = False
        Me.TBIDRemitoProveedor.Location = New System.Drawing.Point(8, 70)
        Me.TBIDRemitoProveedor.Name = "TBIDRemitoProveedor"
        Me.TBIDRemitoProveedor.Size = New System.Drawing.Size(129, 20)
        Me.TBIDRemitoProveedor.TabIndex = 19
        '
        'lbIDRemitoProveedor
        '
        Me.lbIDRemitoProveedor.AutoSize = True
        Me.lbIDRemitoProveedor.Location = New System.Drawing.Point(11, 55)
        Me.lbIDRemitoProveedor.Name = "lbIDRemitoProveedor"
        Me.lbIDRemitoProveedor.Size = New System.Drawing.Size(104, 13)
        Me.lbIDRemitoProveedor.TabIndex = 18
        Me.lbIDRemitoProveedor.Text = "Nro Nota de Pedido:"
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.AutoSize = True
        Me.lbRazonSocial.Location = New System.Drawing.Point(146, 55)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.lbRazonSocial.TabIndex = 17
        Me.lbRazonSocial.Text = "Razón Social: "
        '
        'lbFechaDeEntrega
        '
        Me.lbFechaDeEntrega.AutoSize = True
        Me.lbFechaDeEntrega.Location = New System.Drawing.Point(11, 16)
        Me.lbFechaDeEntrega.Name = "lbFechaDeEntrega"
        Me.lbFechaDeEntrega.Size = New System.Drawing.Size(97, 13)
        Me.lbFechaDeEntrega.TabIndex = 16
        Me.lbFechaDeEntrega.Text = "Fecha de entrega :"
        '
        'DTPFechaDeEntrega
        '
        Me.DTPFechaDeEntrega.Enabled = False
        Me.DTPFechaDeEntrega.Location = New System.Drawing.Point(8, 32)
        Me.DTPFechaDeEntrega.Name = "DTPFechaDeEntrega"
        Me.DTPFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaDeEntrega.TabIndex = 15
        '
        'BTNGuardarCambios
        '
        Me.BTNGuardarCambios.Location = New System.Drawing.Point(463, 335)
        Me.BTNGuardarCambios.Name = "BTNGuardarCambios"
        Me.BTNGuardarCambios.Size = New System.Drawing.Size(122, 23)
        Me.BTNGuardarCambios.TabIndex = 2
        Me.BTNGuardarCambios.Text = "Guardar Cambios"
        Me.BTNGuardarCambios.UseVisualStyleBackColor = True
        '
        'DGVArticuloRemitoProveedor
        '
        Me.DGVArticuloRemitoProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloRemitoProveedor.Location = New System.Drawing.Point(6, 103)
        Me.DGVArticuloRemitoProveedor.Name = "DGVArticuloRemitoProveedor"
        Me.DGVArticuloRemitoProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloRemitoProveedor.Size = New System.Drawing.Size(627, 226)
        Me.DGVArticuloRemitoProveedor.TabIndex = 1
        '
        'BTNGenerarRemito
        '
        Me.BTNGenerarRemito.Location = New System.Drawing.Point(805, 391)
        Me.BTNGenerarRemito.Name = "BTNGenerarRemito"
        Me.BTNGenerarRemito.Size = New System.Drawing.Size(101, 23)
        Me.BTNGenerarRemito.TabIndex = 10
        Me.BTNGenerarRemito.Text = "Generar Remito"
        Me.BTNGenerarRemito.UseVisualStyleBackColor = True
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(911, 391)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 11
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormRemitoProveedor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1115, 424)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.BTNGenerarRemito)
        Me.Controls.Add(Me.GBDetallePedido)
        Me.Controls.Add(Me.lbProveedor)
        Me.Controls.Add(Me.CBProveedor)
        Me.Controls.Add(Me.GBRemitoProveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormRemitoProveedor"
        Me.Text = "Remito Proveedor"
        Me.GBRemitoProveedor.ResumeLayout(False)
        CType(Me.DGVRemitoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBDetallePedido.ResumeLayout(False)
        Me.GBDetallePedido.PerformLayout()
        CType(Me.DGVArticuloRemitoProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbProveedor As System.Windows.Forms.Label
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GBRemitoProveedor As System.Windows.Forms.GroupBox
    Friend WithEvents DGVRemitoProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents GBDetallePedido As System.Windows.Forms.GroupBox
    Friend WithEvents BTNCancelarPedidoDeCliente As System.Windows.Forms.Button
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBIDRemitoProveedor As System.Windows.Forms.TextBox
    Friend WithEvents lbIDRemitoProveedor As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lbFechaDeEntrega As System.Windows.Forms.Label
    Friend WithEvents DTPFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNGuardarCambios As System.Windows.Forms.Button
    Friend WithEvents DGVArticuloRemitoProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents BTNGenerarRemito As System.Windows.Forms.Button
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
