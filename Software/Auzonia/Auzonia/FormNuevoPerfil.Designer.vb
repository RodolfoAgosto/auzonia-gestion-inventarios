<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevoPerfil
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevoPerfil))
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.BTNCancelar = New System.Windows.Forms.Button()
        Me.TBCodigo = New System.Windows.Forms.TextBox()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.lbCodigo = New System.Windows.Forms.Label()
        Me.lbNombre = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(83, 80)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAceptar.TabIndex = 0
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'BTNCancelar
        '
        Me.BTNCancelar.Location = New System.Drawing.Point(161, 80)
        Me.BTNCancelar.Name = "BTNCancelar"
        Me.BTNCancelar.Size = New System.Drawing.Size(75, 23)
        Me.BTNCancelar.TabIndex = 1
        Me.BTNCancelar.Text = "Cancelar"
        Me.BTNCancelar.UseVisualStyleBackColor = True
        '
        'TBCodigo
        '
        Me.TBCodigo.Location = New System.Drawing.Point(63, 18)
        Me.TBCodigo.Name = "TBCodigo"
        Me.TBCodigo.Size = New System.Drawing.Size(100, 20)
        Me.TBCodigo.TabIndex = 2
        '
        'TBNombre
        '
        Me.TBNombre.Location = New System.Drawing.Point(63, 48)
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(160, 20)
        Me.TBNombre.TabIndex = 3
        '
        'lbCodigo
        '
        Me.lbCodigo.AutoSize = True
        Me.lbCodigo.Location = New System.Drawing.Point(18, 21)
        Me.lbCodigo.Name = "lbCodigo"
        Me.lbCodigo.Size = New System.Drawing.Size(43, 13)
        Me.lbCodigo.TabIndex = 4
        Me.lbCodigo.Text = "Código:"
        '
        'lbNombre
        '
        Me.lbNombre.AutoSize = True
        Me.lbNombre.Location = New System.Drawing.Point(11, 52)
        Me.lbNombre.Name = "lbNombre"
        Me.lbNombre.Size = New System.Drawing.Size(50, 13)
        Me.lbNombre.TabIndex = 5
        Me.lbNombre.Text = "Nombre :"
        '
        'FormNuevoPerfil
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(255, 119)
        Me.Controls.Add(Me.lbNombre)
        Me.Controls.Add(Me.lbCodigo)
        Me.Controls.Add(Me.TBNombre)
        Me.Controls.Add(Me.TBCodigo)
        Me.Controls.Add(Me.BTNCancelar)
        Me.Controls.Add(Me.BTNAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevoPerfil"
        Me.Text = "Nuevo Perfil"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents BTNCancelar As System.Windows.Forms.Button
    Friend WithEvents TBCodigo As System.Windows.Forms.TextBox
    Friend WithEvents TBNombre As System.Windows.Forms.TextBox
    Friend WithEvents lbCodigo As System.Windows.Forms.Label
    Friend WithEvents lbNombre As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
