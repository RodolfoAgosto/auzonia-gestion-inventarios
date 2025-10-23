<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCambiarIdioma
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCambiarIdioma))
        Me.CBIdiomas = New System.Windows.Forms.ComboBox()
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'CBIdiomas
        '
        Me.CBIdiomas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBIdiomas.FormattingEnabled = True
        Me.CBIdiomas.Location = New System.Drawing.Point(12, 21)
        Me.CBIdiomas.Name = "CBIdiomas"
        Me.CBIdiomas.Size = New System.Drawing.Size(310, 21)
        Me.CBIdiomas.TabIndex = 0
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(243, 53)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAceptar.TabIndex = 1
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'FormCambiarIdioma
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(335, 96)
        Me.Controls.Add(Me.BTNAceptar)
        Me.Controls.Add(Me.CBIdiomas)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCambiarIdioma"
        Me.Text = "Cambiar Idioma"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents CBIdiomas As System.Windows.Forms.ComboBox
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
