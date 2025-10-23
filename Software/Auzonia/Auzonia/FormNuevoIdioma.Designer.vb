<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevoIdioma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoIdioma))
        Me.BtnAceptar = New System.Windows.Forms.Button()
        Me.TbNombreIdioma = New System.Windows.Forms.TextBox()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BtnAceptar
        '
        Me.BtnAceptar.Location = New System.Drawing.Point(231, 54)
        Me.BtnAceptar.Name = "BtnAceptar"
        Me.BtnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BtnAceptar.TabIndex = 0
        Me.BtnAceptar.Text = "Aceptar"
        Me.BtnAceptar.UseVisualStyleBackColor = True
        '
        'TbNombreIdioma
        '
        Me.TbNombreIdioma.Location = New System.Drawing.Point(12, 28)
        Me.TbNombreIdioma.Name = "TbNombreIdioma"
        Me.TbNombreIdioma.Size = New System.Drawing.Size(294, 20)
        Me.TbNombreIdioma.TabIndex = 1
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(15, 12)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(47, 13)
        Me.lbNombre.TabIndex = 2
        Me.lbNombre.Text = "Nombre:"
        '
        'FormNuevoIdioma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(318, 87)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.TbNombreIdioma)
        Me.Controls.Add(Me.BtnAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevoIdioma"
        Me.Text = "Nuevo Idioma"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BtnAceptar As System.Windows.Forms.Button
    Friend WithEvents TbNombreIdioma As System.Windows.Forms.TextBox
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
