<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormListaDePrecios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormListaDePrecios))
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.LbProveedor = New System.Windows.Forms.Label()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.TabPCompra = New System.Windows.Forms.TabPage()
        Me.GBDetalleArticulosCompra = New System.Windows.Forms.GroupBox()
        Me.BTNGuardarCambioCompra = New System.Windows.Forms.Button()
        Me.DGVDetalleListaCompra = New System.Windows.Forms.DataGridView()
        Me.GBListaCompra = New System.Windows.Forms.GroupBox()
        Me.BTNNuevaListaCompra = New System.Windows.Forms.Button()
        Me.DGVListaCompra = New System.Windows.Forms.DataGridView()
        Me.TBCompras = New System.Windows.Forms.TabControl()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabPCompra.SuspendLayout()
        Me.GBDetalleArticulosCompra.SuspendLayout()
        CType(Me.DGVDetalleListaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBListaCompra.SuspendLayout()
        CType(Me.DGVListaCompra, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TBCompras.SuspendLayout()
        Me.SuspendLayout()
        '
        'CBProveedor
        '
        Me.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProveedor.FormattingEnabled = True
        Me.CBProveedor.Location = New System.Drawing.Point(16, 23)
        Me.CBProveedor.Name = "CBProveedor"
        Me.CBProveedor.Size = New System.Drawing.Size(274, 21)
        Me.CBProveedor.TabIndex = 1
        '
        'LbProveedor
        '
        Me.LbProveedor.AutoSize = True
        Me.LbProveedor.Location = New System.Drawing.Point(13, 7)
        Me.LbProveedor.Name = "LbProveedor"
        Me.LbProveedor.Size = New System.Drawing.Size(56, 13)
        Me.LbProveedor.TabIndex = 2
        Me.LbProveedor.Text = "Proveedor"
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(685, 465)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(104, 23)
        Me.BTNSalir.TabIndex = 3
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'TabPCompra
        '
        Me.TabPCompra.Controls.Add(Me.GBDetalleArticulosCompra)
        Me.TabPCompra.Controls.Add(Me.GBListaCompra)
        Me.TabPCompra.Location = New System.Drawing.Point(4, 22)
        Me.TabPCompra.Name = "TabPCompra"
        Me.TabPCompra.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPCompra.Size = New System.Drawing.Size(775, 385)
        Me.TabPCompra.TabIndex = 0
        Me.TabPCompra.Text = "Compra"
        Me.TabPCompra.UseVisualStyleBackColor = True
        '
        'GBDetalleArticulosCompra
        '
        Me.GBDetalleArticulosCompra.Controls.Add(Me.BTNGuardarCambioCompra)
        Me.GBDetalleArticulosCompra.Controls.Add(Me.DGVDetalleListaCompra)
        Me.GBDetalleArticulosCompra.Location = New System.Drawing.Point(244, 6)
        Me.GBDetalleArticulosCompra.Name = "GBDetalleArticulosCompra"
        Me.GBDetalleArticulosCompra.Size = New System.Drawing.Size(523, 373)
        Me.GBDetalleArticulosCompra.TabIndex = 2
        Me.GBDetalleArticulosCompra.TabStop = False
        Me.GBDetalleArticulosCompra.Text = "Artículos"
        '
        'BTNGuardarCambioCompra
        '
        Me.BTNGuardarCambioCompra.Location = New System.Drawing.Point(397, 343)
        Me.BTNGuardarCambioCompra.Name = "BTNGuardarCambioCompra"
        Me.BTNGuardarCambioCompra.Size = New System.Drawing.Size(111, 23)
        Me.BTNGuardarCambioCompra.TabIndex = 1
        Me.BTNGuardarCambioCompra.Text = "Guardar Cambios"
        Me.BTNGuardarCambioCompra.UseVisualStyleBackColor = True
        '
        'DGVDetalleListaCompra
        '
        Me.DGVDetalleListaCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDetalleListaCompra.Location = New System.Drawing.Point(8, 22)
        Me.DGVDetalleListaCompra.Name = "DGVDetalleListaCompra"
        Me.DGVDetalleListaCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVDetalleListaCompra.Size = New System.Drawing.Size(507, 316)
        Me.DGVDetalleListaCompra.TabIndex = 0
        '
        'GBListaCompra
        '
        Me.GBListaCompra.Controls.Add(Me.BTNNuevaListaCompra)
        Me.GBListaCompra.Controls.Add(Me.DGVListaCompra)
        Me.GBListaCompra.Location = New System.Drawing.Point(6, 6)
        Me.GBListaCompra.Name = "GBListaCompra"
        Me.GBListaCompra.Size = New System.Drawing.Size(234, 373)
        Me.GBListaCompra.TabIndex = 1
        Me.GBListaCompra.TabStop = False
        Me.GBListaCompra.Text = "Listas"
        '
        'BTNNuevaListaCompra
        '
        Me.BTNNuevaListaCompra.Location = New System.Drawing.Point(111, 344)
        Me.BTNNuevaListaCompra.Name = "BTNNuevaListaCompra"
        Me.BTNNuevaListaCompra.Size = New System.Drawing.Size(111, 23)
        Me.BTNNuevaListaCompra.TabIndex = 2
        Me.BTNNuevaListaCompra.Text = "Nueva Lista"
        Me.BTNNuevaListaCompra.UseVisualStyleBackColor = True
        '
        'DGVListaCompra
        '
        Me.DGVListaCompra.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVListaCompra.Location = New System.Drawing.Point(6, 22)
        Me.DGVListaCompra.Name = "DGVListaCompra"
        Me.DGVListaCompra.ReadOnly = True
        Me.DGVListaCompra.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVListaCompra.Size = New System.Drawing.Size(222, 316)
        Me.DGVListaCompra.TabIndex = 0
        '
        'TBCompras
        '
        Me.TBCompras.Controls.Add(Me.TabPCompra)
        Me.TBCompras.Location = New System.Drawing.Point(12, 50)
        Me.TBCompras.Name = "TBCompras"
        Me.TBCompras.SelectedIndex = 0
        Me.TBCompras.Size = New System.Drawing.Size(783, 411)
        Me.TBCompras.TabIndex = 0
        '
        'FormListaDePrecios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(806, 492)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.LbProveedor)
        Me.Controls.Add(Me.CBProveedor)
        Me.Controls.Add(Me.TBCompras)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormListaDePrecios"
        Me.Text = "Lista de Precios"
        Me.TabPCompra.ResumeLayout(False)
        Me.GBDetalleArticulosCompra.ResumeLayout(False)
        CType(Me.DGVDetalleListaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBListaCompra.ResumeLayout(False)
        CType(Me.DGVListaCompra, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TBCompras.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents LbProveedor As System.Windows.Forms.Label
    Friend WithEvents BTNSalir As Button
    Friend WithEvents TabPCompra As TabPage
    Friend WithEvents GBDetalleArticulosCompra As GroupBox
    Friend WithEvents BTNGuardarCambioCompra As Button
    Friend WithEvents DGVDetalleListaCompra As DataGridView
    Friend WithEvents GBListaCompra As GroupBox
    Friend WithEvents BTNNuevaListaCompra As Button
    Friend WithEvents DGVListaCompra As DataGridView
    Friend WithEvents TBCompras As TabControl
    Friend WithEvents ToolTip As ToolTip
End Class
