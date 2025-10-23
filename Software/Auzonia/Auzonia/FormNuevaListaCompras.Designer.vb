<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormNuevaListaCompras
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormNuevaListaCompras))
        Me.BTNAceptar = New System.Windows.Forms.Button()
        Me.DTPFechaInicioVigencia = New System.Windows.Forms.DateTimePicker()
        Me.lbNumero = New System.Windows.Forms.Label()
        Me.TBNumero = New System.Windows.Forms.TextBox()
        Me.lbVigenciaDesde = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.SuspendLayout()
        '
        'BTNAceptar
        '
        Me.BTNAceptar.Location = New System.Drawing.Point(125, 102)
        Me.BTNAceptar.Name = "BTNAceptar"
        Me.BTNAceptar.Size = New System.Drawing.Size(88, 23)
        Me.BTNAceptar.TabIndex = 0
        Me.BTNAceptar.Text = "Aceptar"
        Me.BTNAceptar.UseVisualStyleBackColor = True
        '
        'DTPFechaInicioVigencia
        '
        Me.DTPFechaInicioVigencia.Location = New System.Drawing.Point(15, 73)
        Me.DTPFechaInicioVigencia.Name = "DTPFechaInicioVigencia"
        Me.DTPFechaInicioVigencia.Size = New System.Drawing.Size(200, 20)
        Me.DTPFechaInicioVigencia.TabIndex = 1
        '
        'lbNumero
        '
        Me.lbNumero.AutoSize = True
        Me.lbNumero.Location = New System.Drawing.Point(12, 9)
        Me.lbNumero.Name = "lbNumero"
        Me.lbNumero.Size = New System.Drawing.Size(47, 13)
        Me.lbNumero.TabIndex = 2
        Me.lbNumero.Text = "Número:"
        '
        'TBNumero
        '
        Me.TBNumero.Location = New System.Drawing.Point(15, 25)
        Me.TBNumero.MaxLength = 16
        Me.TBNumero.Name = "TBNumero"
        Me.TBNumero.Size = New System.Drawing.Size(134, 20)
        Me.TBNumero.TabIndex = 3
        '
        'lbVigenciaDesde
        '
        Me.lbVigenciaDesde.AutoSize = True
        Me.lbVigenciaDesde.Location = New System.Drawing.Point(12, 57)
        Me.lbVigenciaDesde.Name = "lbVigenciaDesde"
        Me.lbVigenciaDesde.Size = New System.Drawing.Size(85, 13)
        Me.lbVigenciaDesde.TabIndex = 4
        Me.lbVigenciaDesde.Text = "Vigencia Desde:"
        '
        'FormNuevaListaCompras
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(222, 136)
        Me.Controls.Add(Me.lbVigenciaDesde)
        Me.Controls.Add(Me.TBNumero)
        Me.Controls.Add(Me.lbNumero)
        Me.Controls.Add(Me.DTPFechaInicioVigencia)
        Me.Controls.Add(Me.BTNAceptar)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormNuevaListaCompras"
        Me.Text = "Lista de Compras"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNAceptar As System.Windows.Forms.Button
    Friend WithEvents DTPFechaInicioVigencia As System.Windows.Forms.DateTimePicker
    Friend WithEvents lbNumero As System.Windows.Forms.Label
    Friend WithEvents TBNumero As System.Windows.Forms.TextBox
    Friend WithEvents lbVigenciaDesde As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
