<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInformeMovimientosSalidaPorFecha
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
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformeMovimientosSalidaPorFecha))
        Me.MovimientoSalidasPorFechaBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AuzoniaDataSet1 = New UI.AuzoniaDataSet1()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        Me.DTPFDesde = New System.Windows.Forms.DateTimePicker()
        Me.DTPFHasta = New System.Windows.Forms.DateTimePicker()
        Me.BTNActualizar = New System.Windows.Forms.Button()
        Me.lbDesde = New System.Windows.Forms.Label()
        Me.lbHasta = New System.Windows.Forms.Label()
        Me.MovimientoSalidasPorFechaTableAdapter = New UI.AuzoniaDataSet1TableAdapters.MovimientoSalidasPorFechaTableAdapter()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.MovimientoSalidasPorFechaBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuzoniaDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MovimientoSalidasPorFechaBindingSource
        '
        Me.MovimientoSalidasPorFechaBindingSource.DataMember = "MovimientoSalidasPorFecha"
        Me.MovimientoSalidasPorFechaBindingSource.DataSource = Me.AuzoniaDataSet1
        '
        'AuzoniaDataSet1
        '
        Me.AuzoniaDataSet1.DataSetName = "AuzoniaDataSet1"
        Me.AuzoniaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'ReportViewer1
        '
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.MovimientoSalidasPorFechaBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.ReportSalidasPorFecha.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(12, 39)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.ShowRefreshButton = False
        Me.ReportViewer1.Size = New System.Drawing.Size(783, 494)
        Me.ReportViewer1.TabIndex = 0
        '
        'DTPFDesde
        '
        Me.DTPFDesde.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFDesde.Location = New System.Drawing.Point(92, 12)
        Me.DTPFDesde.Name = "DTPFDesde"
        Me.DTPFDesde.Size = New System.Drawing.Size(97, 20)
        Me.DTPFDesde.TabIndex = 1
        '
        'DTPFHasta
        '
        Me.DTPFHasta.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DTPFHasta.Location = New System.Drawing.Point(285, 12)
        Me.DTPFHasta.Name = "DTPFHasta"
        Me.DTPFHasta.Size = New System.Drawing.Size(97, 20)
        Me.DTPFHasta.TabIndex = 2
        '
        'BTNActualizar
        '
        Me.BTNActualizar.Location = New System.Drawing.Point(404, 10)
        Me.BTNActualizar.Name = "BTNActualizar"
        Me.BTNActualizar.Size = New System.Drawing.Size(100, 23)
        Me.BTNActualizar.TabIndex = 3
        Me.BTNActualizar.Text = "Actualizar"
        Me.BTNActualizar.UseVisualStyleBackColor = True
        '
        'lbDesde
        '
        Me.lbDesde.AutoSize = True
        Me.lbDesde.Location = New System.Drawing.Point(12, 18)
        Me.lbDesde.Name = "lbDesde"
        Me.lbDesde.Size = New System.Drawing.Size(74, 13)
        Me.lbDesde.TabIndex = 4
        Me.lbDesde.Text = "Fecha Desde:"
        '
        'lbHasta
        '
        Me.lbHasta.AutoSize = True
        Me.lbHasta.Location = New System.Drawing.Point(205, 16)
        Me.lbHasta.Name = "lbHasta"
        Me.lbHasta.Size = New System.Drawing.Size(71, 13)
        Me.lbHasta.TabIndex = 5
        Me.lbHasta.Text = "Fecha Hasta:"
        '
        'MovimientoSalidasPorFechaTableAdapter
        '
        Me.MovimientoSalidasPorFechaTableAdapter.ClearBeforeFill = True
        '
        'FormInformeMovimientosSalidaPorFecha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(808, 545)
        Me.Controls.Add(Me.lbHasta)
        Me.Controls.Add(Me.lbDesde)
        Me.Controls.Add(Me.BTNActualizar)
        Me.Controls.Add(Me.DTPFHasta)
        Me.Controls.Add(Me.DTPFDesde)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformeMovimientosSalidaPorFecha"
        Me.Text = "Informe Movimientos Salida Por Fecha"
        CType(Me.MovimientoSalidasPorFechaBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuzoniaDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DTPFDesde As System.Windows.Forms.DateTimePicker
    Friend WithEvents DTPFHasta As System.Windows.Forms.DateTimePicker
    Friend WithEvents BTNActualizar As System.Windows.Forms.Button
    Friend WithEvents lbDesde As System.Windows.Forms.Label
    Friend WithEvents lbHasta As System.Windows.Forms.Label
    Friend WithEvents MovimientoSalidasPorFechaBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AuzoniaDataSet1 As UI.AuzoniaDataSet1
    Friend WithEvents MovimientoSalidasPorFechaTableAdapter As UI.AuzoniaDataSet1TableAdapters.MovimientoSalidasPorFechaTableAdapter
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
    Friend WithEvents ToolTip As ToolTip
End Class
