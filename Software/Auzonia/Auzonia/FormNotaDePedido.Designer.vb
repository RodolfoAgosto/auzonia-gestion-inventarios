<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNotaDePedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNotaDePedido))
        Me.lbProveedor = New System.Windows.Forms.Label()
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.GBNotasDePedido = New System.Windows.Forms.GroupBox()
        Me.DGVNotasDePedido = New System.Windows.Forms.DataGridView()
        Me.GBDetallePedido = New System.Windows.Forms.GroupBox()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBIDNotaDePedido = New System.Windows.Forms.TextBox()
        Me.lbIDNotaDePedido = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.lbFechaDeEntrega = New System.Windows.Forms.Label()
        Me.DTPFechaDeEntrega = New System.Windows.Forms.DateTimePicker()
        Me.DGVArticuloNotaDePedido = New System.Windows.Forms.DataGridView()
        Me.BTNGenerarPedido = New System.Windows.Forms.Button()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBNotasDePedido.SuspendLayout()
        CType(Me.DGVNotasDePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBDetallePedido.SuspendLayout()
        CType(Me.DGVArticuloNotaDePedido, System.ComponentModel.ISupportInitialize).BeginInit()
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
        'GBNotasDePedido
        '
        Me.GBNotasDePedido.Controls.Add(Me.DGVNotasDePedido)
        Me.GBNotasDePedido.Location = New System.Drawing.Point(5, 44)
        Me.GBNotasDePedido.Name = "GBNotasDePedido"
        Me.GBNotasDePedido.Size = New System.Drawing.Size(384, 341)
        Me.GBNotasDePedido.TabIndex = 6
        Me.GBNotasDePedido.TabStop = False
        Me.GBNotasDePedido.Text = "Notas de Pedido"
        '
        'DGVNotasDePedido
        '
        Me.DGVNotasDePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVNotasDePedido.Location = New System.Drawing.Point(6, 19)
        Me.DGVNotasDePedido.MultiSelect = False
        Me.DGVNotasDePedido.Name = "DGVNotasDePedido"
        Me.DGVNotasDePedido.ReadOnly = True
        Me.DGVNotasDePedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVNotasDePedido.Size = New System.Drawing.Size(372, 314)
        Me.DGVNotasDePedido.TabIndex = 0
        '
        'GBDetallePedido
        '
        Me.GBDetallePedido.Controls.Add(Me.TBRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.TBIDNotaDePedido)
        Me.GBDetallePedido.Controls.Add(Me.lbIDNotaDePedido)
        Me.GBDetallePedido.Controls.Add(Me.lbRazonSocial)
        Me.GBDetallePedido.Controls.Add(Me.lbFechaDeEntrega)
        Me.GBDetallePedido.Controls.Add(Me.DTPFechaDeEntrega)
        Me.GBDetallePedido.Controls.Add(Me.DGVArticuloNotaDePedido)
        Me.GBDetallePedido.Location = New System.Drawing.Point(397, 19)
        Me.GBDetallePedido.Name = "GBDetallePedido"
        Me.GBDetallePedido.Size = New System.Drawing.Size(561, 366)
        Me.GBDetallePedido.TabIndex = 9
        Me.GBDetallePedido.TabStop = False
        Me.GBDetallePedido.Text = "Detalle Pedido"
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Enabled = False
        Me.TBRazonSocial.Location = New System.Drawing.Point(143, 70)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(317, 20)
        Me.TBRazonSocial.TabIndex = 20
        '
        'TBIDNotaDePedido
        '
        Me.TBIDNotaDePedido.Enabled = False
        Me.TBIDNotaDePedido.Location = New System.Drawing.Point(8, 70)
        Me.TBIDNotaDePedido.Name = "TBIDNotaDePedido"
        Me.TBIDNotaDePedido.Size = New System.Drawing.Size(129, 20)
        Me.TBIDNotaDePedido.TabIndex = 19
        '
        'lbIDNotaDePedido
        '
        Me.lbIDNotaDePedido.AutoSize = True
        Me.lbIDNotaDePedido.Location = New System.Drawing.Point(11, 55)
        Me.lbIDNotaDePedido.Name = "lbIDNotaDePedido"
        Me.lbIDNotaDePedido.Size = New System.Drawing.Size(104, 13)
        Me.lbIDNotaDePedido.TabIndex = 18
        Me.lbIDNotaDePedido.Text = "Nro Nota de Pedido:"
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
        Me.lbFechaDeEntrega.Size = New System.Drawing.Size(102, 13)
        Me.lbFechaDeEntrega.TabIndex = 16
        Me.lbFechaDeEntrega.Text = "Fecha de creación :"
        '
        'DTPFechaDeEntrega
        '
        Me.DTPFechaDeEntrega.Enabled = False
        Me.DTPFechaDeEntrega.Location = New System.Drawing.Point(8, 32)
        Me.DTPFechaDeEntrega.Name = "DTPFechaDeEntrega"
        Me.DTPFechaDeEntrega.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaDeEntrega.TabIndex = 15
        '
        'DGVArticuloNotaDePedido
        '
        Me.DGVArticuloNotaDePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloNotaDePedido.Location = New System.Drawing.Point(6, 103)
        Me.DGVArticuloNotaDePedido.Name = "DGVArticuloNotaDePedido"
        Me.DGVArticuloNotaDePedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloNotaDePedido.Size = New System.Drawing.Size(550, 255)
        Me.DGVArticuloNotaDePedido.TabIndex = 1
        '
        'BTNGenerarPedido
        '
        Me.BTNGenerarPedido.Location = New System.Drawing.Point(777, 390)
        Me.BTNGenerarPedido.Name = "BTNGenerarPedido"
        Me.BTNGenerarPedido.Size = New System.Drawing.Size(101, 23)
        Me.BTNGenerarPedido.TabIndex = 10
        Me.BTNGenerarPedido.Text = "Generar Pedido"
        Me.BTNGenerarPedido.UseVisualStyleBackColor = True
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(883, 390)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 11
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormNotaDePedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(964, 424)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.BTNGenerarPedido)
        Me.Controls.Add(Me.GBDetallePedido)
        Me.Controls.Add(Me.lbProveedor)
        Me.Controls.Add(Me.CBProveedor)
        Me.Controls.Add(Me.GBNotasDePedido)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNotaDePedido"
        Me.Text = "Nota de Pedido"
        Me.GBNotasDePedido.ResumeLayout(False)
        CType(Me.DGVNotasDePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBDetallePedido.ResumeLayout(False)
        Me.GBDetallePedido.PerformLayout()
        CType(Me.DGVArticuloNotaDePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbProveedor As System.Windows.Forms.Label
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GBNotasDePedido As System.Windows.Forms.GroupBox
    Friend WithEvents DGVNotasDePedido As System.Windows.Forms.DataGridView
    Friend WithEvents GBDetallePedido As System.Windows.Forms.GroupBox
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBIDNotaDePedido As System.Windows.Forms.TextBox
    Friend WithEvents lbIDNotaDePedido As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents lbFechaDeEntrega As System.Windows.Forms.Label
    Friend WithEvents DTPFechaDeEntrega As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGVArticuloNotaDePedido As System.Windows.Forms.DataGridView
    Friend WithEvents BTNGenerarPedido As System.Windows.Forms.Button
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
