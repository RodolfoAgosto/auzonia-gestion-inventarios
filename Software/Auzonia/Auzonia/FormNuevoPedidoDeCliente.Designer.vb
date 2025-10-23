<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevoPedidoDeCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoPedidoDeCliente))
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.CBVendedor = New System.Windows.Forms.ComboBox()
        Me.lbVendedor = New System.Windows.Forms.Label()
        Me.GBDetallePedido = New System.Windows.Forms.GroupBox()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.GBComentarios = New System.Windows.Forms.GroupBox()
        Me.TBComentarios = New System.Windows.Forms.TextBox()
        Me.TBIDCliente = New System.Windows.Forms.TextBox()
        Me.lbIDCliente = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.DGVDetallePedido = New System.Windows.Forms.DataGridView()
        Me.lbFechaDeEntrega = New System.Windows.Forms.Label()
        Me.DTPFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.DGVClientes = New System.Windows.Forms.DataGridView()
        Me.GBClientes = New System.Windows.Forms.GroupBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBDetallePedido.SuspendLayout()
        Me.GBComentarios.SuspendLayout()
        CType(Me.DGVDetallePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBClientes.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(764, 526)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 3
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'CBVendedor
        '
        Me.CBVendedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBVendedor.FormattingEnabled = True
        Me.CBVendedor.Location = New System.Drawing.Point(9, 22)
        Me.CBVendedor.Name = "CBVendedor"
        Me.CBVendedor.Size = New System.Drawing.Size(337, 21)
        Me.CBVendedor.TabIndex = 5
        '
        'lbVendedor
        '
        Me.lbVendedor.AutoSize = True
        Me.lbVendedor.Location = New System.Drawing.Point(12, 6)
        Me.lbVendedor.Name = "lbVendedor"
        Me.lbVendedor.Size = New System.Drawing.Size(53, 13)
        Me.lbVendedor.TabIndex = 6
        Me.lbVendedor.Text = "Vendedor"
        '
        'GBDetallePedido
        '
        Me.GBDetallePedido.Controls.Add(Me.TBRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.BTNAceptar)
        Me.GBDetallePedido.Controls.Add(Me.GBComentarios)
        Me.GBDetallePedido.Controls.Add(Me.TBIDCliente)
        Me.GBDetallePedido.Controls.Add(Me.lbIDCliente)
        Me.GBDetallePedido.Controls.Add(Me.lbRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.DGVDetallePedido)
        Me.GBDetallePedido.Controls.Add(Me.lbFechaDeEntrega)
        Me.GBDetallePedido.Controls.Add(Me.DTPFechaDeEntrega)
        Me.GBDetallePedido.Location = New System.Drawing.Point(9, 193)
        Me.GBDetallePedido.Name = "GBDetallePedido"
        Me.GBDetallePedido.Size = New System.Drawing.Size(829, 327)
        Me.GBDetallePedido.TabIndex = 7
        Me.GBDetallePedido.TabStop = False
        Me.GBDetallePedido.Text = "Detalle Pedido"
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Enabled = False
        Me.TBRazonSocial.Location = New System.Drawing.Point(120, 34)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(317, 20)
        Me.TBRazonSocial.TabIndex = 14
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(730, 298)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(83, 23)
        Me.BTNAceptar.TabIndex = 2
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'GBComentarios
        '
        Me.GBComentarios.Controls.Add(Me.TBComentarios)
        Me.GBComentarios.Location = New System.Drawing.Point(6, 200)
        Me.GBComentarios.Name = "GBComentarios"
        Me.GBComentarios.Size = New System.Drawing.Size(813, 96)
        Me.GBComentarios.TabIndex = 8
        Me.GBComentarios.TabStop = False
        Me.GBComentarios.Text = "Comentarios"
        '
        'TBComentarios
        '
        Me.TBComentarios.Location = New System.Drawing.Point(6, 17)
        Me.TBComentarios.Multiline = True
        Me.TBComentarios.Name = "TBComentarios"
        Me.TBComentarios.Size = New System.Drawing.Size(801, 67)
        Me.TBComentarios.TabIndex = 0
        '
        'TBIDCliente
        '
        Me.TBIDCliente.Enabled = False
        Me.TBIDCliente.Location = New System.Drawing.Point(12, 34)
        Me.TBIDCliente.Name = "TBIDCliente"
        Me.TBIDCliente.Size = New System.Drawing.Size(100, 20)
        Me.TBIDCliente.TabIndex = 13
        '
        'lbIDCliente
        '
        Me.lbIDCliente.AutoSize = True
        Me.lbIDCliente.Location = New System.Drawing.Point(15, 19)
        Me.lbIDCliente.Name = "lbIDCliente"
        Me.lbIDCliente.Size = New System.Drawing.Size(59, 13)
        Me.lbIDCliente.TabIndex = 12
        Me.lbIDCliente.Text = "ID Cliente :"
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.AutoSize = True
        Me.lbRazonSocial.Location = New System.Drawing.Point(123, 19)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.lbRazonSocial.TabIndex = 11
        Me.lbRazonSocial.Text = "Razón Social: "
        '
        'DGVDetallePedido
        '
        Me.DGVDetallePedido.AllowUserToAddRows = False
        Me.DGVDetallePedido.AllowUserToDeleteRows = False
        Me.DGVDetallePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDetallePedido.Location = New System.Drawing.Point(9, 58)
        Me.DGVDetallePedido.MultiSelect = False
        Me.DGVDetallePedido.Name = "DGVDetallePedido"
        Me.DGVDetallePedido.Size = New System.Drawing.Size(810, 137)
        Me.DGVDetallePedido.TabIndex = 1
        '
        'lbFechaDeEntrega
        '
        Me.lbFechaDeEntrega.AutoSize = True
        Me.lbFechaDeEntrega.Location = New System.Drawing.Point(449, 18)
        Me.lbFechaDeEntrega.Name = "lbFechaDeEntrega"
        Me.lbFechaDeEntrega.Size = New System.Drawing.Size(97, 13)
        Me.lbFechaDeEntrega.TabIndex = 10
        Me.lbFechaDeEntrega.Text = "Fecha de entrega :"
        '
        'DTPFechaDeEntrega
        '
        Me.DTPFechaDeEntrega.Location = New System.Drawing.Point(446, 33)
        Me.DTPFechaDeEntrega.Name = "DTPFechaDeEntrega"
        Me.DTPFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaDeEntrega.TabIndex = 9
        '
        'DGVClientes
        '
        Me.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVClientes.Location = New System.Drawing.Point(9, 20)
        Me.DGVClientes.MultiSelect = False
        Me.DGVClientes.Name = "DGVClientes"
        Me.DGVClientes.ReadOnly = True
        Me.DGVClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVClientes.Size = New System.Drawing.Size(810, 112)
        Me.DGVClientes.TabIndex = 1
        '
        'GBClientes
        '
        Me.GBClientes.Controls.Add(Me.DGVClientes)
        Me.GBClientes.Location = New System.Drawing.Point(9, 49)
        Me.GBClientes.Name = "GBClientes"
        Me.GBClientes.Size = New System.Drawing.Size(829, 138)
        Me.GBClientes.TabIndex = 11
        Me.GBClientes.TabStop = False
        Me.GBClientes.Text = "Clientes"
        '
        'FormNuevoPedidoDeCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(848, 553)
        Me.Controls.Add(Me.GBClientes)
        Me.Controls.Add(Me.GBDetallePedido)
        Me.Controls.Add(Me.lbVendedor)
        Me.Controls.Add(Me.CBVendedor)
        Me.Controls.Add(Me.BTNSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevoPedidoDeCliente"
        Me.Text = "Pedido de Cliente"
        Me.GBDetallePedido.ResumeLayout(False)
        Me.GBDetallePedido.PerformLayout()
        Me.GBComentarios.ResumeLayout(False)
        Me.GBComentarios.PerformLayout()
        CType(Me.DGVDetallePedido, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBClientes.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents CBVendedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbVendedor As System.Windows.Forms.Label
    Friend WithEvents GBDetallePedido As System.Windows.Forms.GroupBox
    Friend WithEvents DGVDetallePedido As System.Windows.Forms.DataGridView
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents GBComentarios As System.Windows.Forms.GroupBox
    Friend WithEvents TBComentarios As System.Windows.Forms.TextBox
    Friend WithEvents DTPFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbFechaDeEntrega As System.Windows.Forms.Label
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBIDCliente As System.Windows.Forms.TextBox
    Friend WithEvents lbIDCliente As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents DGVClientes As System.Windows.Forms.DataGridView
    Friend WithEvents GBClientes As System.Windows.Forms.GroupBox
    Friend WithEvents ToolTip As ToolTip
End Class
