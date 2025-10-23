<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormRestore
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormRestore))
        Me.BTNDirectorio = New System.Windows.Forms.Button()
        Me.lbDirectorio = New System.Windows.Forms.Label()
        Me.BTNRestaurar = New System.Windows.Forms.Button()
        Me.TBDirectorio = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.DGVResguardos = New System.Windows.Forms.DataGridView()
        Me.lbResguardos = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DGVResguardos, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNDirectorio
        '
        Me.BTNDirectorio.Location = New System.Drawing.Point(599, 21)
        Me.BTNDirectorio.Name = "BTNDirectorio"
        Me.BTNDirectorio.Size = New System.Drawing.Size(35, 21)
        Me.BTNDirectorio.TabIndex = 0
        Me.BTNDirectorio.Text = "..."
        Me.BTNDirectorio.UseVisualStyleBackColor = True
        '
        'lbDirectorio
        '
        Me.lbDirectorio.AutoSize = True
        Me.lbDirectorio.Location = New System.Drawing.Point(12, 7)
        Me.lbDirectorio.Name = "lbDirectorio"
        Me.lbDirectorio.Size = New System.Drawing.Size(55, 13)
        Me.lbDirectorio.TabIndex = 2
        Me.lbDirectorio.Text = "Directorio:"
        '
        'BTNRestaurar
        '
        Me.BTNRestaurar.Location = New System.Drawing.Point(563, 302)
        Me.BTNRestaurar.Name = "BTNRestaurar"
        Me.BTNRestaurar.Size = New System.Drawing.Size(75, 23)
        Me.BTNRestaurar.TabIndex = 4
        Me.BTNRestaurar.Text = "Restaurar"
        Me.BTNRestaurar.UseVisualStyleBackColor = True
        '
        'TBDirectorio
        '
        Me.TBDirectorio.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TBDirectorio.Enabled = False
        Me.TBDirectorio.Location = New System.Drawing.Point(16, 21)
        Me.TBDirectorio.Name = "TBDirectorio"
        Me.TBDirectorio.Size = New System.Drawing.Size(577, 20)
        Me.TBDirectorio.TabIndex = 5
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.Red
        Me.Label3.Location = New System.Drawing.Point(13, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(0, 13)
        Me.Label3.TabIndex = 14
        '
        'DGVResguardos
        '
        Me.DGVResguardos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVResguardos.Location = New System.Drawing.Point(15, 71)
        Me.DGVResguardos.MultiSelect = False
        Me.DGVResguardos.Name = "DGVResguardos"
        Me.DGVResguardos.ReadOnly = True
        Me.DGVResguardos.Size = New System.Drawing.Size(623, 222)
        Me.DGVResguardos.TabIndex = 15
        '
        'lbResguardos
        '
        Me.lbResguardos.AutoSize = True
        Me.lbResguardos.Location = New System.Drawing.Point(12, 55)
        Me.lbResguardos.Name = "lbResguardos"
        Me.lbResguardos.Size = New System.Drawing.Size(67, 13)
        Me.lbResguardos.TabIndex = 16
        Me.lbResguardos.Text = "Resguardos:"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'FormRestore
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(650, 334)
        Me.Controls.Add(Me.lbResguardos)
        Me.Controls.Add(Me.DGVResguardos)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.TBDirectorio)
        Me.Controls.Add(Me.BTNRestaurar)
        Me.Controls.Add(Me.lbDirectorio)
        Me.Controls.Add(Me.BTNDirectorio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormRestore"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Restaurar Sistema"
        CType(Me.DGVResguardos, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNDirectorio As System.Windows.Forms.Button
    Friend WithEvents lbDirectorio As System.Windows.Forms.Label
    Friend WithEvents BTNRestaurar As System.Windows.Forms.Button
    Friend WithEvents TBDirectorio As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents DGVResguardos As System.Windows.Forms.DataGridView
    Friend WithEvents lbResguardos As System.Windows.Forms.Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents ToolTip As ToolTip
End Class
