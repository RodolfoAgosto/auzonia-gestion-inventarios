<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormIniciarSesion
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormIniciarSesion))
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.lbUsuario = New System.Windows.Forms.Label()
        Me.lbContraseña = New System.Windows.Forms.Label()
        Me.TBUsuario = New System.Windows.Forms.TextBox()
        Me.TBContraseña = New System.Windows.Forms.TextBox()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(133, 97)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAceptar.TabIndex = 0
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'lbUsuario
        '
        Me.lbUsuario.AutoSize = True
        Me.lbUsuario.Location = New System.Drawing.Point(15, 10)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(46, 13)
        Me.lbUsuario.TabIndex = 1
        Me.lbUsuario.Text = "Usuario:"
        '
        'lbContraseña
        '
        Me.lbContraseña.AutoSize = True
        Me.lbContraseña.Location = New System.Drawing.Point(15, 48)
        Me.lbContraseña.Name = "lbContraseña"
        Me.lbContraseña.Size = New System.Drawing.Size(64, 13)
        Me.lbContraseña.TabIndex = 2
        Me.lbContraseña.Text = "Contraseña:"
        '
        'TBUsuario
        '
        Me.TBUsuario.Location = New System.Drawing.Point(12, 25)
        Me.TBUsuario.Name = "TBUsuario"
        Me.TBUsuario.Size = New System.Drawing.Size(196, 20)
        Me.TBUsuario.TabIndex = 3
        '
        'TBContraseña
        '
        Me.TBContraseña.Location = New System.Drawing.Point(12, 64)
        Me.TBContraseña.Name = "TBContraseña"
        Me.TBContraseña.Size = New System.Drawing.Size(196, 20)
        Me.TBContraseña.TabIndex = 4
        Me.TBContraseña.UseSystemPasswordChar = True
        '
        'FormIniciarSesion
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(220, 134)
        Me.Controls.Add(Me.TBContraseña)
        Me.Controls.Add(Me.TBUsuario)
        Me.Controls.Add(Me.lbContraseña)
        Me.Controls.Add(Me.lbUsuario)
        Me.Controls.Add(Me.BTNAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormIniciarSesion"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inicio de Sesión"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents lbContraseña As System.Windows.Forms.Label
    Friend WithEvents TBUsuario As System.Windows.Forms.TextBox
    Friend WithEvents TBContraseña As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip As ToolTip
End Class
