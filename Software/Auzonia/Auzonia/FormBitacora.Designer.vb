<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBitacora
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBitacora))
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.RBActualizacion = New System.Windows.Forms.RadioButton()
        Me.RBExcepción = New System.Windows.Forms.RadioButton()
        Me.RBEvento = New System.Windows.Forms.RadioButton()
        Me.DTPDesde = New System.Windows.Forms.DateTimePicker()
        Me.DTPHasta = New System.Windows.Forms.DateTimePicker()
        Me.DGVBitacora = New System.Windows.Forms.DataGridView()
        Me.RBTodos = New System.Windows.Forms.RadioButton()
        Me.LbDesde = New System.Windows.Forms.Label()
        Me.GPTipo = New System.Windows.Forms.GroupBox()
        Me.LbHasta = New System.Windows.Forms.Label()
        Me.TBCodigoUsuario = New System.Windows.Forms.TextBox()
        Me.TBIdenticidadorDeObjeto = New System.Windows.Forms.TextBox()
        Me.TBTipoDeObjeto = New System.Windows.Forms.TextBox()
        Me.TBCodigoBitacora = New System.Windows.Forms.TextBox()
        Me.LBCodigoUsuario = New System.Windows.Forms.Label()
        Me.LBCodigoBitacora = New System.Windows.Forms.Label()
        Me.LBTipoDeObjeto = New System.Windows.Forms.Label()
        Me.LBIdentificadorDeObjeto = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DGVBitacora, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPTipo.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(424, 66)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(75, 23)
        Me.BTNBuscar.TabIndex = 0
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(816, 305)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 1
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'RBActualizacion
        '
        Me.RBActualizacion.AutoSize = True
        Me.RBActualizacion.Location = New System.Drawing.Point(14, 18)
        Me.RBActualizacion.Name = "RBActualizacion"
        Me.RBActualizacion.Size = New System.Drawing.Size(88, 17)
        Me.RBActualizacion.TabIndex = 2
        Me.RBActualizacion.Text = "Actualización"
        Me.RBActualizacion.UseVisualStyleBackColor = True
        '
        'RBExcepción
        '
        Me.RBExcepción.AutoSize = True
        Me.RBExcepción.Location = New System.Drawing.Point(166, 18)
        Me.RBExcepción.Name = "RBExcepción"
        Me.RBExcepción.Size = New System.Drawing.Size(75, 17)
        Me.RBExcepción.TabIndex = 3
        Me.RBExcepción.Text = "Excepción"
        Me.RBExcepción.UseVisualStyleBackColor = True
        '
        'RBEvento
        '
        Me.RBEvento.AutoSize = True
        Me.RBEvento.Location = New System.Drawing.Point(104, 18)
        Me.RBEvento.Name = "RBEvento"
        Me.RBEvento.Size = New System.Drawing.Size(59, 17)
        Me.RBEvento.TabIndex = 4
        Me.RBEvento.Text = "Evento"
        Me.RBEvento.UseVisualStyleBackColor = True
        '
        'DTPDesde
        '
        Me.DTPDesde.Location = New System.Drawing.Point(12, 68)
        Me.DTPDesde.Name = "DTPDesde"
        Me.DTPDesde.Size = New System.Drawing.Size(200, 20)
        Me.DTPDesde.TabIndex = 5
        '
        'DTPHasta
        '
        Me.DTPHasta.Location = New System.Drawing.Point(218, 68)
        Me.DTPHasta.Name = "DTPHasta"
        Me.DTPHasta.Size = New System.Drawing.Size(200, 20)
        Me.DTPHasta.TabIndex = 6
        '
        'DGVBitacora
        '
        Me.DGVBitacora.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVBitacora.Location = New System.Drawing.Point(12, 106)
        Me.DGVBitacora.Name = "DGVBitacora"
        Me.DGVBitacora.ReadOnly = True
        Me.DGVBitacora.Size = New System.Drawing.Size(887, 192)
        Me.DGVBitacora.TabIndex = 7
        '
        'RBTodos
        '
        Me.RBTodos.AutoSize = True
        Me.RBTodos.Checked = True
        Me.RBTodos.Location = New System.Drawing.Point(244, 18)
        Me.RBTodos.Name = "RBTodos"
        Me.RBTodos.Size = New System.Drawing.Size(55, 17)
        Me.RBTodos.TabIndex = 8
        Me.RBTodos.TabStop = True
        Me.RBTodos.Text = "Todos"
        Me.RBTodos.UseVisualStyleBackColor = True
        '
        'LbDesde
        '
        Me.LbDesde.AutoSize = True
        Me.LbDesde.Location = New System.Drawing.Point(12, 52)
        Me.LbDesde.Name = "LbDesde"
        Me.LbDesde.Size = New System.Drawing.Size(41, 13)
        Me.LbDesde.TabIndex = 9
        Me.LbDesde.Text = "Desde:"
        '
        'GPTipo
        '
        Me.GPTipo.Controls.Add(Me.RBActualizacion)
        Me.GPTipo.Controls.Add(Me.RBTodos)
        Me.GPTipo.Controls.Add(Me.RBEvento)
        Me.GPTipo.Controls.Add(Me.RBExcepción)
        Me.GPTipo.Location = New System.Drawing.Point(9, 6)
        Me.GPTipo.Name = "GPTipo"
        Me.GPTipo.Size = New System.Drawing.Size(307, 43)
        Me.GPTipo.TabIndex = 10
        Me.GPTipo.TabStop = False
        Me.GPTipo.Text = "Tipo:"
        '
        'LbHasta
        '
        Me.LbHasta.AutoSize = True
        Me.LbHasta.Location = New System.Drawing.Point(218, 52)
        Me.LbHasta.Name = "LbHasta"
        Me.LbHasta.Size = New System.Drawing.Size(38, 13)
        Me.LbHasta.TabIndex = 11
        Me.LbHasta.Text = "Hasta:"
        '
        'TBCodigoUsuario
        '
        Me.TBCodigoUsuario.Location = New System.Drawing.Point(332, 24)
        Me.TBCodigoUsuario.Name = "TBCodigoUsuario"
        Me.TBCodigoUsuario.Size = New System.Drawing.Size(100, 20)
        Me.TBCodigoUsuario.TabIndex = 12
        '
        'TBIdenticidadorDeObjeto
        '
        Me.TBIdenticidadorDeObjeto.Location = New System.Drawing.Point(650, 24)
        Me.TBIdenticidadorDeObjeto.Name = "TBIdenticidadorDeObjeto"
        Me.TBIdenticidadorDeObjeto.Size = New System.Drawing.Size(100, 20)
        Me.TBIdenticidadorDeObjeto.TabIndex = 13
        '
        'TBTipoDeObjeto
        '
        Me.TBTipoDeObjeto.Location = New System.Drawing.Point(544, 24)
        Me.TBTipoDeObjeto.Name = "TBTipoDeObjeto"
        Me.TBTipoDeObjeto.Size = New System.Drawing.Size(100, 20)
        Me.TBTipoDeObjeto.TabIndex = 14
        '
        'TBCodigoBitacora
        '
        Me.TBCodigoBitacora.Location = New System.Drawing.Point(438, 24)
        Me.TBCodigoBitacora.Name = "TBCodigoBitacora"
        Me.TBCodigoBitacora.Size = New System.Drawing.Size(100, 20)
        Me.TBCodigoBitacora.TabIndex = 15
        '
        'LBCodigoUsuario
        '
        Me.LBCodigoUsuario.AutoSize = True
        Me.LBCodigoUsuario.Location = New System.Drawing.Point(329, 8)
        Me.LBCodigoUsuario.Name = "LBCodigoUsuario"
        Me.LBCodigoUsuario.Size = New System.Drawing.Size(85, 13)
        Me.LBCodigoUsuario.TabIndex = 16
        Me.LBCodigoUsuario.Text = "Codigo Usuario :"
        '
        'LBCodigoBitacora
        '
        Me.LBCodigoBitacora.AutoSize = True
        Me.LBCodigoBitacora.Location = New System.Drawing.Point(434, 9)
        Me.LBCodigoBitacora.Name = "LBCodigoBitacora"
        Me.LBCodigoBitacora.Size = New System.Drawing.Size(103, 13)
        Me.LBCodigoBitacora.TabIndex = 18
        Me.LBCodigoBitacora.Text = "Codigo de Bitacora :"
        '
        'LBTipoDeObjeto
        '
        Me.LBTipoDeObjeto.AutoSize = True
        Me.LBTipoDeObjeto.Location = New System.Drawing.Point(541, 8)
        Me.LBTipoDeObjeto.Name = "LBTipoDeObjeto"
        Me.LBTipoDeObjeto.Size = New System.Drawing.Size(83, 13)
        Me.LBTipoDeObjeto.TabIndex = 19
        Me.LBTipoDeObjeto.Text = "Tipo de Objeto :"
        '
        'LBIdentificadorDeObjeto
        '
        Me.LBIdentificadorDeObjeto.AutoSize = True
        Me.LBIdentificadorDeObjeto.Location = New System.Drawing.Point(647, 9)
        Me.LBIdentificadorDeObjeto.Name = "LBIdentificadorDeObjeto"
        Me.LBIdentificadorDeObjeto.Size = New System.Drawing.Size(120, 13)
        Me.LBIdentificadorDeObjeto.TabIndex = 20
        Me.LBIdentificadorDeObjeto.Text = "Identificador de Objeto :"
        '
        'FormBitacora
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(911, 332)
        Me.Controls.Add(Me.LBIdentificadorDeObjeto)
        Me.Controls.Add(Me.LBTipoDeObjeto)
        Me.Controls.Add(Me.LBCodigoBitacora)
        Me.Controls.Add(Me.LBCodigoUsuario)
        Me.Controls.Add(Me.TBCodigoBitacora)
        Me.Controls.Add(Me.TBTipoDeObjeto)
        Me.Controls.Add(Me.TBIdenticidadorDeObjeto)
        Me.Controls.Add(Me.TBCodigoUsuario)
        Me.Controls.Add(Me.LbHasta)
        Me.Controls.Add(Me.GPTipo)
        Me.Controls.Add(Me.LbDesde)
        Me.Controls.Add(Me.DGVBitacora)
        Me.Controls.Add(Me.DTPHasta)
        Me.Controls.Add(Me.DTPDesde)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.BTNBuscar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBitacora"
        Me.Text = "Bitacora"
        CType(Me.DGVBitacora, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPTipo.ResumeLayout(False)
        Me.GPTipo.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNBuscar As System.Windows.Forms.Button
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents RBActualizacion As System.Windows.Forms.RadioButton
    Friend WithEvents RBExcepción As System.Windows.Forms.RadioButton
    Friend WithEvents RBEvento As System.Windows.Forms.RadioButton
    Friend WithEvents DTPDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents DGVBitacora As System.Windows.Forms.DataGridView
    Friend WithEvents RBTodos As System.Windows.Forms.RadioButton
    Friend WithEvents LbDesde As System.Windows.Forms.Label
    Friend WithEvents GPTipo As System.Windows.Forms.GroupBox
    Friend WithEvents LbHasta As System.Windows.Forms.Label
    Friend WithEvents TBCodigoUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TBIdenticidadorDeObjeto As System.Windows.Forms.TextBox
    Friend WithEvents TBTipoDeObjeto As System.Windows.Forms.TextBox
    Friend WithEvents TBCodigoBitacora As System.Windows.Forms.TextBox
    Friend WithEvents LBCodigoUsuario As System.Windows.Forms.Label
    Friend WithEvents LBCodigoBitacora As System.Windows.Forms.Label
    Friend WithEvents LBTipoDeObjeto As System.Windows.Forms.Label
    Friend WithEvents LBIdentificadorDeObjeto As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
