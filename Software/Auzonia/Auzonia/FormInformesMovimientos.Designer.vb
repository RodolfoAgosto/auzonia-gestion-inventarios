<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormInformesMovimientos
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim ReportDataSource1 As Microsoft.Reporting.WinForms.ReportDataSource = New Microsoft.Reporting.WinForms.ReportDataSource()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInformesMovimientos))
        Me.MovimientoSalidasBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AuzoniaDataSet = New UI.AuzoniaDataSet()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.MovimientoSalidasTableAdapter = New UI.AuzoniaDataSetTableAdapters.MovimientoSalidasTableAdapter()
        Me.ReportViewer1 = New Microsoft.Reporting.WinForms.ReportViewer()
        CType(Me.MovimientoSalidasBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AuzoniaDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MovimientoSalidasBindingSource
        '
        Me.MovimientoSalidasBindingSource.DataMember = "MovimientoSalidas"
        Me.MovimientoSalidasBindingSource.DataSource = Me.AuzoniaDataSet
        '
        'AuzoniaDataSet
        '
        Me.AuzoniaDataSet.DataSetName = "AuzoniaDataSet"
        Me.AuzoniaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(810, 386)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 1
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'MovimientoSalidasTableAdapter
        '
        Me.MovimientoSalidasTableAdapter.ClearBeforeFill = True
        '
        'ReportViewer1
        '
        Me.ReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        ReportDataSource1.Name = "DataSet1"
        ReportDataSource1.Value = Me.MovimientoSalidasBindingSource
        Me.ReportViewer1.LocalReport.DataSources.Add(ReportDataSource1)
        Me.ReportViewer1.LocalReport.ReportEmbeddedResource = "UI.Report1.rdlc"
        Me.ReportViewer1.Location = New System.Drawing.Point(0, 0)
        Me.ReportViewer1.Name = "ReportViewer1"
        Me.ReportViewer1.Size = New System.Drawing.Size(914, 429)
        Me.ReportViewer1.TabIndex = 2
        '
        'FormInformesMovimientos
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(914, 429)
        Me.Controls.Add(Me.ReportViewer1)
        Me.Controls.Add(Me.BTNSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormInformesMovimientos"
        Me.Text = "FormInformesMovimientos"
        CType(Me.MovimientoSalidasBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AuzoniaDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents MovimientoSalidasBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AuzoniaDataSet As UI.AuzoniaDataSet
    Friend WithEvents MovimientoSalidasTableAdapter As UI.AuzoniaDataSetTableAdapters.MovimientoSalidasTableAdapter
    Private WithEvents ReportViewer1 As Microsoft.Reporting.WinForms.ReportViewer
End Class
