<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBitacoraCambios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBitacoraCambios))
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.DGVCambios = New System.Windows.Forms.DataGridView()
        CType(Me.DGVCambios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(539, 165)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 0
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'DGVCambios
        '
        Me.DGVCambios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVCambios.Location = New System.Drawing.Point(12, 12)
        Me.DGVCambios.Name = "DGVCambios"
        Me.DGVCambios.Size = New System.Drawing.Size(602, 150)
        Me.DGVCambios.TabIndex = 1
        '
        'FormBitacoraCambios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(621, 194)
        Me.Controls.Add(Me.DGVCambios)
        Me.Controls.Add(Me.BTNSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormBitacoraCambios"
        Me.Text = "Historial de Cambios"
        CType(Me.DGVCambios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents DGVCambios As System.Windows.Forms.DataGridView
End Class
