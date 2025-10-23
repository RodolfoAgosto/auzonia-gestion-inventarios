<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevaNotaDePedido
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevaNotaDePedido))
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.lbProveedor = New System.Windows.Forms.Label()
        Me.GBDetallePedido = New System.Windows.Forms.GroupBox()
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.DGVArticuloNotaDePedido = New System.Windows.Forms.DataGridView()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBDetallePedido.SuspendLayout()
        CType(Me.DGVArticuloNotaDePedido, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBProveedor
        '
        Me.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProveedor.FormattingEnabled = True
        Me.CBProveedor.Location = New System.Drawing.Point(12, 25)
        Me.CBProveedor.Name = "CBProveedor"
        Me.CBProveedor.Size = New System.Drawing.Size(395, 21)
        Me.CBProveedor.TabIndex = 19
        '
        'lbProveedor
        '
        Me.lbProveedor.AutoSize = True
        Me.lbProveedor.Location = New System.Drawing.Point(15, 9)
        Me.lbProveedor.Name = "lbProveedor"
        Me.lbProveedor.Size = New System.Drawing.Size(56, 13)
        Me.lbProveedor.TabIndex = 18
        Me.lbProveedor.Text = "Proveedor"
        '
        'GBDetallePedido
        '
        Me.GBDetallePedido.Controls.Add(Me.BTNAceptar)
        Me.GBDetallePedido.Controls.Add(Me.DGVArticuloNotaDePedido)
        Me.GBDetallePedido.Location = New System.Drawing.Point(6, 53)
        Me.GBDetallePedido.Name = "GBDetallePedido"
        Me.GBDetallePedido.Size = New System.Drawing.Size(1009, 466)
        Me.GBDetallePedido.TabIndex = 20
        Me.GBDetallePedido.TabStop = False
        Me.GBDetallePedido.Text = "Detalle Pedido"
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(913, 433)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(83, 23)
        Me.BTNAceptar.TabIndex = 2
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'DGVArticuloNotaDePedido
        '
        Me.DGVArticuloNotaDePedido.AllowUserToAddRows = False
        Me.DGVArticuloNotaDePedido.AllowUserToDeleteRows = False
        Me.DGVArticuloNotaDePedido.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticuloNotaDePedido.Location = New System.Drawing.Point(8, 19)
        Me.DGVArticuloNotaDePedido.MultiSelect = False
        Me.DGVArticuloNotaDePedido.Name = "DGVArticuloNotaDePedido"
        Me.DGVArticuloNotaDePedido.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticuloNotaDePedido.Size = New System.Drawing.Size(995, 407)
        Me.DGVArticuloNotaDePedido.TabIndex = 1
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(933, 525)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(83, 23)
        Me.BTNSalir.TabIndex = 21
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormNuevaNotaDePedido
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1022, 554)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.GBDetallePedido)
        Me.Controls.Add(Me.CBProveedor)
        Me.Controls.Add(Me.lbProveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevaNotaDePedido"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "Nueva Nota de Pedido"
        Me.GBDetallePedido.ResumeLayout(False)
        CType(Me.DGVArticuloNotaDePedido, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents lbProveedor As System.Windows.Forms.Label
    Friend WithEvents GBDetallePedido As System.Windows.Forms.GroupBox
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents DGVArticuloNotaDePedido As System.Windows.Forms.DataGridView
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
