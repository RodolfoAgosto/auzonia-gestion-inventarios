<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBackUp
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBackUp))
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.LbDirectorio = New System.Windows.Forms.Label()
        Me.TBDirectorio = New System.Windows.Forms.TextBox()
        Me.LbNombreDeArchivo = New System.Windows.Forms.Label()
        Me.TBNombreArchivo = New System.Windows.Forms.TextBox()
        Me.BTNDirectorio = New System.Windows.Forms.Button()
        Me.BTNGenerarBackUp = New System.Windows.Forms.Button()
        Me.LbDestino = New System.Windows.Forms.Label()
        Me.LbDestino1 = New System.Windows.Forms.Label()
        Me.lb = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'LbDirectorio
        '
        Me.LbDirectorio.AutoSize = True
        Me.LbDirectorio.Location = New System.Drawing.Point(12, 9)
        Me.LbDirectorio.Name = "LbDirectorio"
        Me.LbDirectorio.Size = New System.Drawing.Size(55, 13)
        Me.LbDirectorio.TabIndex = 3
        Me.LbDirectorio.Text = "Directorio:"
        '
        'TBDirectorio
        '
        Me.TBDirectorio.BackColor = System.Drawing.SystemColors.InactiveCaption
        Me.TBDirectorio.Enabled = False
        Me.TBDirectorio.Location = New System.Drawing.Point(15, 25)
        Me.TBDirectorio.Name = "TBDirectorio"
        Me.TBDirectorio.Size = New System.Drawing.Size(412, 20)
        Me.TBDirectorio.TabIndex = 6
        '
        'LbNombreDeArchivo
        '
        Me.LbNombreDeArchivo.AutoSize = True
        Me.LbNombreDeArchivo.Location = New System.Drawing.Point(12, 48)
        Me.LbNombreDeArchivo.Name = "LbNombreDeArchivo"
        Me.LbNombreDeArchivo.Size = New System.Drawing.Size(103, 13)
        Me.LbNombreDeArchivo.TabIndex = 7
        Me.LbNombreDeArchivo.Text = "Nombre del Archivo:"
        '
        'TBNombreArchivo
        '
        Me.TBNombreArchivo.Location = New System.Drawing.Point(15, 63)
        Me.TBNombreArchivo.Name = "TBNombreArchivo"
        Me.TBNombreArchivo.Size = New System.Drawing.Size(185, 20)
        Me.TBNombreArchivo.TabIndex = 8
        '
        'BTNDirectorio
        '
        Me.BTNDirectorio.Location = New System.Drawing.Point(433, 24)
        Me.BTNDirectorio.Name = "BTNDirectorio"
        Me.BTNDirectorio.Size = New System.Drawing.Size(35, 22)
        Me.BTNDirectorio.TabIndex = 9
        Me.BTNDirectorio.Text = "..."
        Me.BTNDirectorio.UseVisualStyleBackColor = True
        '
        'BTNGenerarBackUp
        '
        Me.BTNGenerarBackUp.Location = New System.Drawing.Point(394, 125)
        Me.BTNGenerarBackUp.Name = "BTNGenerarBackUp"
        Me.BTNGenerarBackUp.Size = New System.Drawing.Size(75, 23)
        Me.BTNGenerarBackUp.TabIndex = 10
        Me.BTNGenerarBackUp.Text = "Generar"
        Me.BTNGenerarBackUp.UseVisualStyleBackColor = True
        '
        'LbDestino
        '
        Me.LbDestino.AutoSize = True
        Me.LbDestino.ForeColor = System.Drawing.Color.Red
        Me.LbDestino.Location = New System.Drawing.Point(17, 106)
        Me.LbDestino.Name = "LbDestino"
        Me.LbDestino.Size = New System.Drawing.Size(0, 13)
        Me.LbDestino.TabIndex = 11
        '
        'LbDestino1
        '
        Me.LbDestino1.AutoSize = True
        Me.LbDestino1.Location = New System.Drawing.Point(14, 89)
        Me.LbDestino1.Name = "LbDestino1"
        Me.LbDestino1.Size = New System.Drawing.Size(46, 13)
        Me.LbDestino1.TabIndex = 12
        Me.LbDestino1.Text = "Destino:"
        '
        'lb
        '
        Me.lb.AutoSize = True
        Me.lb.Location = New System.Drawing.Point(14, 107)
        Me.lb.Name = "lb"
        Me.lb.Size = New System.Drawing.Size(0, 13)
        Me.lb.TabIndex = 13
        '
        'FormBackUp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(479, 156)
        Me.Controls.Add(Me.lb)
        Me.Controls.Add(Me.LbDestino1)
        Me.Controls.Add(Me.LbDestino)
        Me.Controls.Add(Me.BTNGenerarBackUp)
        Me.Controls.Add(Me.BTNDirectorio)
        Me.Controls.Add(Me.TBNombreArchivo)
        Me.Controls.Add(Me.LbNombreDeArchivo)
        Me.Controls.Add(Me.TBDirectorio)
        Me.Controls.Add(Me.LbDirectorio)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBackUp"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Generar BackUp"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents LbDirectorio As System.Windows.Forms.Label
    Friend WithEvents TBDirectorio As System.Windows.Forms.TextBox
    Friend WithEvents LbNombreDeArchivo As System.Windows.Forms.Label
    Friend WithEvents TBNombreArchivo As System.Windows.Forms.TextBox
    Friend WithEvents BTNDirectorio As System.Windows.Forms.Button
    Friend WithEvents BTNGenerarBackUp As System.Windows.Forms.Button
    Friend WithEvents LbDestino As System.Windows.Forms.Label
    Friend WithEvents LbDestino1 As System.Windows.Forms.Label
    Friend WithEvents lb As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
