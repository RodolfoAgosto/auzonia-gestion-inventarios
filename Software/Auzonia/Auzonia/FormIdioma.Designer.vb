<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIdioma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIdioma))
        Me.CBIdioma = New System.Windows.Forms.ComboBox()
        Me.DGVTraducciones = New System.Windows.Forms.DataGridView()
        Me.GBTraducciones = New System.Windows.Forms.GroupBox()
        Me.LbIdioma = New System.Windows.Forms.Label()
        Me.BtnNuevoIdioma = New System.Windows.Forms.Button()
        Me.BtnGuardarCambios = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DGVTraducciones, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBTraducciones.SuspendLayout()
        Me.SuspendLayout()
        '
        'CBIdioma
        '
        Me.CBIdioma.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIdioma.FormattingEnabled = True
        Me.CBIdioma.Location = New System.Drawing.Point(11, 23)
        Me.CBIdioma.Name = "CBIdioma"
        Me.CBIdioma.Size = New System.Drawing.Size(218, 21)
        Me.CBIdioma.TabIndex = 0
        '
        'DGVTraducciones
        '
        Me.DGVTraducciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVTraducciones.Location = New System.Drawing.Point(6, 19)
        Me.DGVTraducciones.MultiSelect = False
        Me.DGVTraducciones.Name = "DGVTraducciones"
        Me.DGVTraducciones.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVTraducciones.Size = New System.Drawing.Size(919, 306)
        Me.DGVTraducciones.TabIndex = 1
        '
        'GBTraducciones
        '
        Me.GBTraducciones.Controls.Add(Me.DGVTraducciones)
        Me.GBTraducciones.Location = New System.Drawing.Point(10, 50)
        Me.GBTraducciones.Name = "GBTraducciones"
        Me.GBTraducciones.Size = New System.Drawing.Size(931, 335)
        Me.GBTraducciones.TabIndex = 2
        Me.GBTraducciones.TabStop = False
        Me.GBTraducciones.Text = "Traducciones"
        '
        'LbIdioma
        '
        Me.LbIdioma.AutoSize = True
        Me.LbIdioma.Location = New System.Drawing.Point(14, 9)
        Me.LbIdioma.Name = "LbIdioma"
        Me.LbIdioma.Size = New System.Drawing.Size(38, 13)
        Me.LbIdioma.TabIndex = 3
        Me.LbIdioma.Text = "Idioma"
        '
        'BtnNuevoIdioma
        '
        Me.BtnNuevoIdioma.Location = New System.Drawing.Point(234, 22)
        Me.BtnNuevoIdioma.Name = "BtnNuevoIdioma"
        Me.BtnNuevoIdioma.Size = New System.Drawing.Size(91, 23)
        Me.BtnNuevoIdioma.TabIndex = 4
        Me.BtnNuevoIdioma.Text = "Nuevo Idioma"
        Me.BtnNuevoIdioma.UseVisualStyleBackColor = True
        '
        'BtnGuardarCambios
        '
        Me.BtnGuardarCambios.Location = New System.Drawing.Point(810, 392)
        Me.BtnGuardarCambios.Name = "BtnGuardarCambios"
        Me.BtnGuardarCambios.Size = New System.Drawing.Size(132, 23)
        Me.BtnGuardarCambios.TabIndex = 5
        Me.BtnGuardarCambios.Text = "Guardar Cambios"
        Me.BtnGuardarCambios.UseVisualStyleBackColor = True
        '
        'FormIdioma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(953, 426)
        Me.Controls.Add(Me.BtnGuardarCambios)
        Me.Controls.Add(Me.BtnNuevoIdioma)
        Me.Controls.Add(Me.LbIdioma)
        Me.Controls.Add(Me.GBTraducciones)
        Me.Controls.Add(Me.CBIdioma)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormIdioma"
        Me.Text = "Actualizar Idioma"
        CType(Me.DGVTraducciones, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBTraducciones.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CBIdioma As System.Windows.Forms.ComboBox
    Friend WithEvents DGVTraducciones As System.Windows.Forms.DataGridView
    Friend WithEvents GBTraducciones As System.Windows.Forms.GroupBox
    Friend WithEvents LbIdioma As System.Windows.Forms.Label
    Friend WithEvents BtnNuevoIdioma As System.Windows.Forms.Button
    Friend WithEvents BtnGuardarCambios As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
