<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormValuacion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormValuacion))
        Me.LbProveedor = New System.Windows.Forms.Label()
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.GBResultados = New System.Windows.Forms.GroupBox()
        Me.lbTotalLIFO = New System.Windows.Forms.Label()
        Me.lbLIFO = New System.Windows.Forms.Label()
        Me.lbTotalFIFO = New System.Windows.Forms.Label()
        Me.lbFIFO = New System.Windows.Forms.Label()
        Me.DGVArticulosValuacion = New System.Windows.Forms.DataGridView()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBResultados.SuspendLayout()
        CType(Me.DGVArticulosValuacion, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LbProveedor
        '
        Me.LbProveedor.AutoSize = True
        Me.LbProveedor.Location = New System.Drawing.Point(12, 9)
        Me.LbProveedor.Name = "LbProveedor"
        Me.LbProveedor.Size = New System.Drawing.Size(56, 13)
        Me.LbProveedor.TabIndex = 3
        Me.LbProveedor.Text = "Proveedor"
        '
        'CBProveedor
        '
        Me.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProveedor.FormattingEnabled = True
        Me.CBProveedor.Location = New System.Drawing.Point(9, 24)
        Me.CBProveedor.Name = "CBProveedor"
        Me.CBProveedor.Size = New System.Drawing.Size(274, 21)
        Me.CBProveedor.TabIndex = 2
        '
        'GBResultados
        '
        Me.GBResultados.Controls.Add(Me.lbTotalLIFO)
        Me.GBResultados.Controls.Add(Me.lbLIFO)
        Me.GBResultados.Controls.Add(Me.lbTotalFIFO)
        Me.GBResultados.Controls.Add(Me.lbFIFO)
        Me.GBResultados.Controls.Add(Me.DGVArticulosValuacion)
        Me.GBResultados.Location = New System.Drawing.Point(5, 50)
        Me.GBResultados.Name = "GBResultados"
        Me.GBResultados.Size = New System.Drawing.Size(761, 326)
        Me.GBResultados.TabIndex = 41
        Me.GBResultados.TabStop = False
        Me.GBResultados.Text = "Resultados"
        '
        'lbTotalLIFO
        '
        Me.lbTotalLIFO.AutoSize = True
        Me.lbTotalLIFO.Location = New System.Drawing.Point(683, 300)
        Me.lbTotalLIFO.Name = "lbTotalLIFO"
        Me.lbTotalLIFO.Size = New System.Drawing.Size(0, 13)
        Me.lbTotalLIFO.TabIndex = 20
        '
        'lbLIFO
        '
        Me.lbLIFO.AutoSize = True
        Me.lbLIFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbLIFO.Location = New System.Drawing.Point(598, 300)
        Me.lbLIFO.Name = "lbLIFO"
        Me.lbLIFO.Size = New System.Drawing.Size(86, 13)
        Me.lbLIFO.TabIndex = 19
        Me.lbLIFO.Text = "TOTAL LIFO :"
        '
        'lbTotalFIFO
        '
        Me.lbTotalFIFO.AutoSize = True
        Me.lbTotalFIFO.Location = New System.Drawing.Point(522, 300)
        Me.lbTotalFIFO.Name = "lbTotalFIFO"
        Me.lbTotalFIFO.Size = New System.Drawing.Size(0, 13)
        Me.lbTotalFIFO.TabIndex = 18
        '
        'lbFIFO
        '
        Me.lbFIFO.AutoSize = True
        Me.lbFIFO.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbFIFO.Location = New System.Drawing.Point(435, 300)
        Me.lbFIFO.Name = "lbFIFO"
        Me.lbFIFO.Size = New System.Drawing.Size(86, 13)
        Me.lbFIFO.TabIndex = 17
        Me.lbFIFO.Text = "TOTAL FIFO :"
        '
        'DGVArticulosValuacion
        '
        Me.DGVArticulosValuacion.AllowUserToAddRows = False
        Me.DGVArticulosValuacion.AllowUserToDeleteRows = False
        Me.DGVArticulosValuacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticulosValuacion.Location = New System.Drawing.Point(7, 20)
        Me.DGVArticulosValuacion.MultiSelect = False
        Me.DGVArticulosValuacion.Name = "DGVArticulosValuacion"
        Me.DGVArticulosValuacion.ReadOnly = True
        Me.DGVArticulosValuacion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticulosValuacion.Size = New System.Drawing.Size(747, 270)
        Me.DGVArticulosValuacion.TabIndex = 16
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(686, 382)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 42
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormValuacion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(772, 416)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.GBResultados)
        Me.Controls.Add(Me.LbProveedor)
        Me.Controls.Add(Me.CBProveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormValuacion"
        Me.Text = "Valuacion"
        Me.GBResultados.ResumeLayout(False)
        Me.GBResultados.PerformLayout()
        CType(Me.DGVArticulosValuacion, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbProveedor As System.Windows.Forms.Label
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents GBResultados As System.Windows.Forms.GroupBox
    Friend WithEvents DGVArticulosValuacion As System.Windows.Forms.DataGridView
    Friend WithEvents lbTotalLIFO As System.Windows.Forms.Label
    Friend WithEvents lbLIFO As System.Windows.Forms.Label
    Friend WithEvents lbTotalFIFO As System.Windows.Forms.Label
    Friend WithEvents lbFIFO As System.Windows.Forms.Label
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
