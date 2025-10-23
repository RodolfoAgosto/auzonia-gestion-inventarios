<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormArbolDePermisos
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormArbolDePermisos))
        Me.TreeViewPermisos = New System.Windows.Forms.TreeView()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.BTNActualizar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'TreeViewPermisos
        '
        Me.TreeViewPermisos.Location = New System.Drawing.Point(12, 12)
        Me.TreeViewPermisos.Name = "TreeViewPermisos"
        Me.TreeViewPermisos.Size = New System.Drawing.Size(496, 275)
        Me.TreeViewPermisos.TabIndex = 0
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(433, 293)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 1
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'BTNActualizar
        '
        Me.BTNActualizar.Location = New System.Drawing.Point(352, 293)
        Me.BTNActualizar.Name = "BTNActualizar"
        Me.BTNActualizar.Size = New System.Drawing.Size(75, 23)
        Me.BTNActualizar.TabIndex = 2
        Me.BTNActualizar.Text = "Actualizar"
        Me.BTNActualizar.UseVisualStyleBackColor = True
        '
        'FormArbolDePermisos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(520, 323)
        Me.Controls.Add(Me.BTNActualizar)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.TreeViewPermisos)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormArbolDePermisos"
        Me.Text = "Arbol De Permisos"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeViewPermisos As System.Windows.Forms.TreeView
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents BTNActualizar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
