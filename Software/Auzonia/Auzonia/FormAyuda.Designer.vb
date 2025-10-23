<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormAyuda
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
        Dim TreeNode1 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Proveedores")
        Dim TreeNode2 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Artículos")
        Dim TreeNode3 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Notas de Pedido")
        Dim TreeNode4 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Remitos")
        Dim TreeNode5 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Compras", New System.Windows.Forms.TreeNode() {TreeNode1, TreeNode2, TreeNode3, TreeNode4})
        Dim TreeNode6 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Clientes")
        Dim TreeNode7 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Pedidos de Clientes")
        Dim TreeNode8 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Envios")
        Dim TreeNode9 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Ventas", New System.Windows.Forms.TreeNode() {TreeNode6, TreeNode7, TreeNode8})
        Dim TreeNode10 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Valorizar Mercadería")
        Dim TreeNode11 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Lista de Precios")
        Dim TreeNode12 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Contabilidad", New System.Windows.Forms.TreeNode() {TreeNode10, TreeNode11})
        Dim TreeNode13 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Gestion de Permisos")
        Dim TreeNode14 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Generar BackUp")
        Dim TreeNode15 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Restaurar Base de Datos")
        Dim TreeNode16 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Verificar Integridad")
        Dim TreeNode17 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Bitácora de Auditoría")
        Dim TreeNode18 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Sistema", New System.Windows.Forms.TreeNode() {TreeNode13, TreeNode14, TreeNode15, TreeNode16, TreeNode17})
        Dim TreeNode19 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Actualizar Idioma")
        Dim TreeNode20 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Cambiar Idioma")
        Dim TreeNode21 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Idioma", New System.Windows.Forms.TreeNode() {TreeNode19, TreeNode20})
        Dim TreeNode22 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimientos")
        Dim TreeNode23 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Movimientos Salida Por Fecha")
        Dim TreeNode24 As System.Windows.Forms.TreeNode = New System.Windows.Forms.TreeNode("Informes", New System.Windows.Forms.TreeNode() {TreeNode22, TreeNode23})
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAyuda))
        Me.TreeView1 = New System.Windows.Forms.TreeView()
        Me.AxAcroPDF2 = New AxAcroPDFLib.AxAcroPDF()
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TreeView1
        '
        Me.TreeView1.Location = New System.Drawing.Point(12, 12)
        Me.TreeView1.Name = "TreeView1"
        TreeNode1.Name = "NProveedores"
        TreeNode1.Text = "Proveedores"
        TreeNode2.Name = "NArticulos"
        TreeNode2.Text = "Artículos"
        TreeNode3.Name = "NNotasDePedido"
        TreeNode3.Text = "Notas de Pedido"
        TreeNode4.Name = "NRemitos"
        TreeNode4.Text = "Remitos"
        TreeNode5.Name = "NCompras"
        TreeNode5.Text = "Compras"
        TreeNode6.Name = "NClientes"
        TreeNode6.Text = "Clientes"
        TreeNode7.Name = "NPedidosDeClientes"
        TreeNode7.Text = "Pedidos de Clientes"
        TreeNode8.Name = "NEnvios"
        TreeNode8.Text = "Envios"
        TreeNode9.Name = "NVentas"
        TreeNode9.Text = "Ventas"
        TreeNode10.Name = "NValorizarMercaderia"
        TreeNode10.Text = "Valorizar Mercadería"
        TreeNode11.Name = "NListaDePrecios"
        TreeNode11.Text = "Lista de Precios"
        TreeNode12.Name = "NContabilidad"
        TreeNode12.Text = "Contabilidad"
        TreeNode13.Name = "NGestionDePermisos"
        TreeNode13.Text = "Gestion de Permisos"
        TreeNode14.Name = "NGenerarBackUp"
        TreeNode14.Text = "Generar BackUp"
        TreeNode15.Name = "NRestaurarBaseDeDatos"
        TreeNode15.Text = "Restaurar Base de Datos"
        TreeNode16.Name = "NVerificarIntegridad"
        TreeNode16.Text = "Verificar Integridad"
        TreeNode17.Name = "NBitacoraDeAuditoria"
        TreeNode17.Text = "Bitácora de Auditoría"
        TreeNode18.Name = "NSistema"
        TreeNode18.Text = "Sistema"
        TreeNode19.Name = "NActualizarIdioma"
        TreeNode19.Text = "Actualizar Idioma"
        TreeNode20.Name = "NCambiarIdioma"
        TreeNode20.Text = "Cambiar Idioma"
        TreeNode21.Name = "NIdioma"
        TreeNode21.Text = "Idioma"
        TreeNode22.Name = "NMovimientos"
        TreeNode22.Text = "Movimientos"
        TreeNode23.Name = "NMovimientos2"
        TreeNode23.Text = "Movimientos Salida Por Fecha"
        TreeNode24.Name = "NInformes"
        TreeNode24.Text = "Informes"
        Me.TreeView1.Nodes.AddRange(New System.Windows.Forms.TreeNode() {TreeNode5, TreeNode9, TreeNode12, TreeNode18, TreeNode21, TreeNode24})
        Me.TreeView1.Size = New System.Drawing.Size(255, 491)
        Me.TreeView1.TabIndex = 0
        '
        'AxAcroPDF2
        '
        Me.AxAcroPDF2.Enabled = True
        Me.AxAcroPDF2.Location = New System.Drawing.Point(273, 12)
        Me.AxAcroPDF2.Name = "AxAcroPDF2"
        Me.AxAcroPDF2.OcxState = CType(resources.GetObject("AxAcroPDF2.OcxState"), System.Windows.Forms.AxHost.State)
        Me.AxAcroPDF2.Size = New System.Drawing.Size(718, 491)
        Me.AxAcroPDF2.TabIndex = 2
        '
        'FormAyuda
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1003, 515)
        Me.Controls.Add(Me.AxAcroPDF2)
        Me.Controls.Add(Me.TreeView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAyuda"
        Me.Text = "Ayuda"
        CType(Me.AxAcroPDF2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TreeView1 As System.Windows.Forms.TreeView
    Friend WithEvents AxAcroPDF2 As AxAcroPDFLib.AxAcroPDF
End Class
