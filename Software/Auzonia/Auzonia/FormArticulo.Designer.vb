<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArticulo
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormArticulo))
        Me.CBProveedor = New System.Windows.Forms.ComboBox()
        Me.LbProveedor = New System.Windows.Forms.Label()
        Me.GBResultados = New System.Windows.Forms.GroupBox()
        Me.DGVArticulos = New System.Windows.Forms.DataGridView()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.BTNCrearArticulo = New System.Windows.Forms.Button()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.TBCodigo = New System.Windows.Forms.TextBox()
        Me.TBPuntoDeReposicion = New System.Windows.Forms.TextBox()
        Me.TBDescripcion = New System.Windows.Forms.TextBox()
        Me.LbDescripcion = New System.Windows.Forms.Label()
        Me.LbPuntoDeReposicion = New System.Windows.Forms.Label()
        Me.LbCodigo = New System.Windows.Forms.Label()
        Me.TBStockDeSeguridad = New System.Windows.Forms.TextBox()
        Me.LbStockDeSeguridad = New System.Windows.Forms.Label()
        Me.TBStockFisico = New System.Windows.Forms.TextBox()
        Me.LbStockFisico = New System.Windows.Forms.Label()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBResultados.SuspendLayout()
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'CBProveedor
        '
        Me.CBProveedor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBProveedor.FormattingEnabled = True
        Me.CBProveedor.Location = New System.Drawing.Point(12, 23)
        Me.CBProveedor.Name = "CBProveedor"
        Me.CBProveedor.Size = New System.Drawing.Size(274, 21)
        Me.CBProveedor.TabIndex = 0
        '
        'LbProveedor
        '
        Me.LbProveedor.AutoSize = True
        Me.LbProveedor.Location = New System.Drawing.Point(15, 8)
        Me.LbProveedor.Name = "LbProveedor"
        Me.LbProveedor.Size = New System.Drawing.Size(56, 13)
        Me.LbProveedor.TabIndex = 1
        Me.LbProveedor.Text = "Proveedor"
        '
        'GBResultados
        '
        Me.GBResultados.Controls.Add(Me.DGVArticulos)
        Me.GBResultados.Location = New System.Drawing.Point(8, 143)
        Me.GBResultados.Name = "GBResultados"
        Me.GBResultados.Size = New System.Drawing.Size(998, 242)
        Me.GBResultados.TabIndex = 40
        Me.GBResultados.TabStop = False
        Me.GBResultados.Text = "Resultados"
        '
        'DGVArticulos
        '
        Me.DGVArticulos.AllowUserToAddRows = False
        Me.DGVArticulos.AllowUserToDeleteRows = False
        Me.DGVArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVArticulos.Location = New System.Drawing.Point(8, 20)
        Me.DGVArticulos.MultiSelect = False
        Me.DGVArticulos.Name = "DGVArticulos"
        Me.DGVArticulos.ReadOnly = True
        Me.DGVArticulos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVArticulos.Size = New System.Drawing.Size(982, 216)
        Me.DGVArticulos.TabIndex = 16
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(688, 84)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(122, 23)
        Me.BTNModificar.TabIndex = 43
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        Me.BTNModificar.Visible = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(688, 113)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(122, 23)
        Me.BTNEliminar.TabIndex = 42
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        Me.BTNEliminar.Visible = False
        '
        'BTNCrearArticulo
        '
        Me.BTNCrearArticulo.Location = New System.Drawing.Point(688, 26)
        Me.BTNCrearArticulo.Name = "BTNCrearArticulo"
        Me.BTNCrearArticulo.Size = New System.Drawing.Size(122, 23)
        Me.BTNCrearArticulo.TabIndex = 41
        Me.BTNCrearArticulo.Text = "Crear Artículo"
        Me.BTNCrearArticulo.UseVisualStyleBackColor = True
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(688, 55)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(122, 23)
        Me.BTNBuscar.TabIndex = 39
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'TBCodigo
        '
        Me.TBCodigo.Location = New System.Drawing.Point(12, 67)
        Me.TBCodigo.Name = "TBCodigo"
        Me.TBCodigo.Size = New System.Drawing.Size(194, 20)
        Me.TBCodigo.TabIndex = 37
        '
        'TBPuntoDeReposicion
        '
        Me.TBPuntoDeReposicion.Location = New System.Drawing.Point(573, 52)
        Me.TBPuntoDeReposicion.MaxLength = 3
        Me.TBPuntoDeReposicion.Name = "TBPuntoDeReposicion"
        Me.TBPuntoDeReposicion.Size = New System.Drawing.Size(69, 20)
        Me.TBPuntoDeReposicion.TabIndex = 36
        '
        'TBDescripcion
        '
        Me.TBDescripcion.Location = New System.Drawing.Point(12, 108)
        Me.TBDescripcion.Name = "TBDescripcion"
        Me.TBDescripcion.Size = New System.Drawing.Size(437, 20)
        Me.TBDescripcion.TabIndex = 35
        '
        'LbDescripcion
        '
        Me.LbDescripcion.AutoSize = True
        Me.LbDescripcion.Location = New System.Drawing.Point(15, 93)
        Me.LbDescripcion.Name = "LbDescripcion"
        Me.LbDescripcion.Size = New System.Drawing.Size(69, 13)
        Me.LbDescripcion.TabIndex = 33
        Me.LbDescripcion.Text = "Descripción :"
        '
        'LbPuntoDeReposicion
        '
        Me.LbPuntoDeReposicion.AutoSize = True
        Me.LbPuntoDeReposicion.Location = New System.Drawing.Point(459, 55)
        Me.LbPuntoDeReposicion.Name = "LbPuntoDeReposicion"
        Me.LbPuntoDeReposicion.Size = New System.Drawing.Size(112, 13)
        Me.LbPuntoDeReposicion.TabIndex = 32
        Me.LbPuntoDeReposicion.Text = "Punto de Reposición :"
        '
        'LbCodigo
        '
        Me.LbCodigo.AutoSize = True
        Me.LbCodigo.Location = New System.Drawing.Point(15, 52)
        Me.LbCodigo.Name = "LbCodigo"
        Me.LbCodigo.Size = New System.Drawing.Size(46, 13)
        Me.LbCodigo.TabIndex = 31
        Me.LbCodigo.Text = "Código :"
        '
        'TBStockDeSeguridad
        '
        Me.TBStockDeSeguridad.Location = New System.Drawing.Point(573, 80)
        Me.TBStockDeSeguridad.MaxLength = 3
        Me.TBStockDeSeguridad.Name = "TBStockDeSeguridad"
        Me.TBStockDeSeguridad.Size = New System.Drawing.Size(69, 20)
        Me.TBStockDeSeguridad.TabIndex = 45
        '
        'LbStockDeSeguridad
        '
        Me.LbStockDeSeguridad.AutoSize = True
        Me.LbStockDeSeguridad.Location = New System.Drawing.Point(464, 83)
        Me.LbStockDeSeguridad.Name = "LbStockDeSeguridad"
        Me.LbStockDeSeguridad.Size = New System.Drawing.Size(107, 13)
        Me.LbStockDeSeguridad.TabIndex = 44
        Me.LbStockDeSeguridad.Text = "Stock de Seguridad :"
        '
        'TBStockFisico
        '
        Me.TBStockFisico.Location = New System.Drawing.Point(573, 107)
        Me.TBStockFisico.MaxLength = 3
        Me.TBStockFisico.Name = "TBStockFisico"
        Me.TBStockFisico.Size = New System.Drawing.Size(69, 20)
        Me.TBStockFisico.TabIndex = 47
        '
        'LbStockFisico
        '
        Me.LbStockFisico.AutoSize = True
        Me.LbStockFisico.Location = New System.Drawing.Point(498, 110)
        Me.LbStockFisico.Name = "LbStockFisico"
        Me.LbStockFisico.Size = New System.Drawing.Size(73, 13)
        Me.LbStockFisico.TabIndex = 46
        Me.LbStockFisico.Text = "Stock Físico :"
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(898, 391)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 48
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormArticulo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1014, 420)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.TBStockFisico)
        Me.Controls.Add(Me.LbStockFisico)
        Me.Controls.Add(Me.TBStockDeSeguridad)
        Me.Controls.Add(Me.LbStockDeSeguridad)
        Me.Controls.Add(Me.GBResultados)
        Me.Controls.Add(Me.BTNModificar)
        Me.Controls.Add(Me.BTNEliminar)
        Me.Controls.Add(Me.BTNCrearArticulo)
        Me.Controls.Add(Me.BTNBuscar)
        Me.Controls.Add(Me.TBCodigo)
        Me.Controls.Add(Me.TBPuntoDeReposicion)
        Me.Controls.Add(Me.TBDescripcion)
        Me.Controls.Add(Me.LbDescripcion)
        Me.Controls.Add(Me.LbPuntoDeReposicion)
        Me.Controls.Add(Me.LbCodigo)
        Me.Controls.Add(Me.LbProveedor)
        Me.Controls.Add(Me.CBProveedor)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormArticulo"
        Me.Text = "Artículo"
        Me.GBResultados.ResumeLayout(False)
        CType(Me.DGVArticulos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBProveedor As System.Windows.Forms.ComboBox
    Friend WithEvents LbProveedor As System.Windows.Forms.Label
    Friend WithEvents GBResultados As System.Windows.Forms.GroupBox
    Friend WithEvents DGVArticulos As System.Windows.Forms.DataGridView
    Friend WithEvents BTNModificar As System.Windows.Forms.Button
    Friend WithEvents BTNEliminar As System.Windows.Forms.Button
    Friend WithEvents BTNCrearArticulo As System.Windows.Forms.Button
    Friend WithEvents BTNBuscar As System.Windows.Forms.Button
    Friend WithEvents TBCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TBPuntoDeReposicion As System.Windows.Forms.TextBox
    Friend WithEvents TBDescripcion As System.Windows.Forms.TextBox
    Friend WithEvents LbDescripcion As System.Windows.Forms.Label
    Friend WithEvents LbPuntoDeReposicion As System.Windows.Forms.Label
    Friend WithEvents LbCodigo As System.Windows.Forms.Label
    Friend WithEvents TBStockDeSeguridad As System.Windows.Forms.TextBox
    Friend WithEvents LbStockDeSeguridad As System.Windows.Forms.Label
    Friend WithEvents TBStockFisico As System.Windows.Forms.TextBox
    Friend WithEvents LbStockFisico As System.Windows.Forms.Label
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
