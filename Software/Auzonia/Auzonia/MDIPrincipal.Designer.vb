<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MDIPrincipal
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MDIPrincipal))
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.tsslUsuario = New System.Windows.Forms.ToolStripStatusLabel()
        Me.menuItemInicio = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiIniciarSesion = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemCompras = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiProveedores = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiArticulos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiNotasDePedido = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRemitos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemVentas = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiClientes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPedidosDeCliente = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiEnvios = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemContabilidad = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiValorizarMercaderia = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiListaDePrecios = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemSistema = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiPermisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiGenerarBackup = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiRestaurarBD = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiVerificarIntegridad = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiBitácoraDeAuditoria = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiÁrbolDePermisos = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemIdioma = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiActualizarIdiomas = New System.Windows.Forms.ToolStripMenuItem()
        Me.ITSMItemCambiarIdioma = New System.Windows.Forms.ToolStripMenuItem()
        Me.menuItemAyuda = New System.Windows.Forms.ToolStripMenuItem()
        Me.AyudaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AcercaDeToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.menuItemInformes = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMovimientos = New System.Windows.Forms.ToolStripMenuItem()
        Me.tsmiMovimientosSalidaPorFecha = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip.SuspendLayout()
        Me.SuspendLayout()
        '
        'StatusStrip
        '
        Me.StatusStrip.BackColor = System.Drawing.SystemColors.MenuBar
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslUsuario})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 499)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(1152, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'tsslUsuario
        '
        Me.tsslUsuario.Name = "tsslUsuario"
        Me.tsslUsuario.Size = New System.Drawing.Size(0, 17)
        '
        'menuItemInicio
        '
        Me.menuItemInicio.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiIniciarSesion})
        Me.menuItemInicio.Image = CType(resources.GetObject("menuItemInicio.Image"), System.Drawing.Image)
        Me.menuItemInicio.ImageTransparentColor = System.Drawing.SystemColors.ActiveBorder
        Me.menuItemInicio.Name = "menuItemInicio"
        Me.menuItemInicio.Size = New System.Drawing.Size(70, 26)
        Me.menuItemInicio.Text = "&Inicio"
        '
        'tsmiIniciarSesion
        '
        Me.tsmiIniciarSesion.Name = "tsmiIniciarSesion"
        Me.tsmiIniciarSesion.Size = New System.Drawing.Size(143, 22)
        Me.tsmiIniciarSesion.Text = "&Iniciar Sesion"
        '
        'menuItemCompras
        '
        Me.menuItemCompras.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiProveedores, Me.tsmiArticulos, Me.tsmiNotasDePedido, Me.tsmiRemitos})
        Me.menuItemCompras.Enabled = False
        Me.menuItemCompras.Image = CType(resources.GetObject("menuItemCompras.Image"), System.Drawing.Image)
        Me.menuItemCompras.Name = "menuItemCompras"
        Me.menuItemCompras.Size = New System.Drawing.Size(89, 26)
        Me.menuItemCompras.Text = "&Compras"
        Me.menuItemCompras.Visible = False
        '
        'tsmiProveedores
        '
        Me.tsmiProveedores.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsmiProveedores.Name = "tsmiProveedores"
        Me.tsmiProveedores.Size = New System.Drawing.Size(161, 22)
        Me.tsmiProveedores.Text = "&Proveedores"
        '
        'tsmiArticulos
        '
        Me.tsmiArticulos.ImageTransparentColor = System.Drawing.Color.Black
        Me.tsmiArticulos.Name = "tsmiArticulos"
        Me.tsmiArticulos.Size = New System.Drawing.Size(161, 22)
        Me.tsmiArticulos.Text = "&Artículos"
        '
        'tsmiNotasDePedido
        '
        Me.tsmiNotasDePedido.Name = "tsmiNotasDePedido"
        Me.tsmiNotasDePedido.Size = New System.Drawing.Size(161, 22)
        Me.tsmiNotasDePedido.Text = "&Notas de Pedido"
        '
        'tsmiRemitos
        '
        Me.tsmiRemitos.Name = "tsmiRemitos"
        Me.tsmiRemitos.Size = New System.Drawing.Size(161, 22)
        Me.tsmiRemitos.Text = "&Remitos"
        '
        'menuItemVentas
        '
        Me.menuItemVentas.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiClientes, Me.tsmiPedidosDeCliente, Me.tsmiEnvios})
        Me.menuItemVentas.Enabled = False
        Me.menuItemVentas.Image = CType(resources.GetObject("menuItemVentas.Image"), System.Drawing.Image)
        Me.menuItemVentas.Name = "menuItemVentas"
        Me.menuItemVentas.Size = New System.Drawing.Size(75, 26)
        Me.menuItemVentas.Text = "&Ventas"
        Me.menuItemVentas.Visible = False
        '
        'tsmiClientes
        '
        Me.tsmiClientes.Name = "tsmiClientes"
        Me.tsmiClientes.Size = New System.Drawing.Size(177, 22)
        Me.tsmiClientes.Text = "&Clientes"
        '
        'tsmiPedidosDeCliente
        '
        Me.tsmiPedidosDeCliente.Name = "tsmiPedidosDeCliente"
        Me.tsmiPedidosDeCliente.Size = New System.Drawing.Size(177, 22)
        Me.tsmiPedidosDeCliente.Text = "&Pedidos de Clientes"
        '
        'tsmiEnvios
        '
        Me.tsmiEnvios.Name = "tsmiEnvios"
        Me.tsmiEnvios.Size = New System.Drawing.Size(177, 22)
        Me.tsmiEnvios.Text = "&Envios"
        '
        'menuItemContabilidad
        '
        Me.menuItemContabilidad.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiValorizarMercaderia, Me.tsmiListaDePrecios})
        Me.menuItemContabilidad.Enabled = False
        Me.menuItemContabilidad.Image = CType(resources.GetObject("menuItemContabilidad.Image"), System.Drawing.Image)
        Me.menuItemContabilidad.Name = "menuItemContabilidad"
        Me.menuItemContabilidad.Size = New System.Drawing.Size(109, 26)
        Me.menuItemContabilidad.Text = "C&ontabilidad"
        Me.menuItemContabilidad.Visible = False
        '
        'tsmiValorizarMercaderia
        '
        Me.tsmiValorizarMercaderia.Name = "tsmiValorizarMercaderia"
        Me.tsmiValorizarMercaderia.Size = New System.Drawing.Size(180, 22)
        Me.tsmiValorizarMercaderia.Text = "&Valorizar Mercadería"
        '
        'tsmiListaDePrecios
        '
        Me.tsmiListaDePrecios.Name = "tsmiListaDePrecios"
        Me.tsmiListaDePrecios.Size = New System.Drawing.Size(180, 22)
        Me.tsmiListaDePrecios.Text = "&Lista de Precios"
        '
        'menuItemSistema
        '
        Me.menuItemSistema.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiPermisos, Me.tsmiGenerarBackup, Me.tsmiRestaurarBD, Me.tsmiVerificarIntegridad, Me.tsmiBitácoraDeAuditoria, Me.tsmiÁrbolDePermisos})
        Me.menuItemSistema.Image = CType(resources.GetObject("menuItemSistema.Image"), System.Drawing.Image)
        Me.menuItemSistema.Name = "menuItemSistema"
        Me.menuItemSistema.Size = New System.Drawing.Size(82, 26)
        Me.menuItemSistema.Text = "&Sistema"
        Me.menuItemSistema.Visible = False
        '
        'tsmiPermisos
        '
        Me.tsmiPermisos.BackColor = System.Drawing.SystemColors.Control
        Me.tsmiPermisos.Name = "tsmiPermisos"
        Me.tsmiPermisos.Size = New System.Drawing.Size(199, 22)
        Me.tsmiPermisos.Text = "&Gestión de Permisos"
        '
        'tsmiGenerarBackup
        '
        Me.tsmiGenerarBackup.Name = "tsmiGenerarBackup"
        Me.tsmiGenerarBackup.Size = New System.Drawing.Size(199, 22)
        Me.tsmiGenerarBackup.Text = "G&enerar BackUp"
        '
        'tsmiRestaurarBD
        '
        Me.tsmiRestaurarBD.Name = "tsmiRestaurarBD"
        Me.tsmiRestaurarBD.Size = New System.Drawing.Size(199, 22)
        Me.tsmiRestaurarBD.Text = "&Restaurar Base de Datos"
        '
        'tsmiVerificarIntegridad
        '
        Me.tsmiVerificarIntegridad.Name = "tsmiVerificarIntegridad"
        Me.tsmiVerificarIntegridad.Size = New System.Drawing.Size(199, 22)
        Me.tsmiVerificarIntegridad.Text = "&Verificar Integridad"
        '
        'tsmiBitácoraDeAuditoria
        '
        Me.tsmiBitácoraDeAuditoria.Name = "tsmiBitácoraDeAuditoria"
        Me.tsmiBitácoraDeAuditoria.Size = New System.Drawing.Size(199, 22)
        Me.tsmiBitácoraDeAuditoria.Text = "&Bitácora de Auditoria"
        '
        'tsmiÁrbolDePermisos
        '
        Me.tsmiÁrbolDePermisos.Name = "tsmiÁrbolDePermisos"
        Me.tsmiÁrbolDePermisos.Size = New System.Drawing.Size(199, 22)
        Me.tsmiÁrbolDePermisos.Text = "Árbol de Permisos"
        '
        'menuItemIdioma
        '
        Me.menuItemIdioma.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiActualizarIdiomas, Me.ITSMItemCambiarIdioma})
        Me.menuItemIdioma.Image = CType(resources.GetObject("menuItemIdioma.Image"), System.Drawing.Image)
        Me.menuItemIdioma.Name = "menuItemIdioma"
        Me.menuItemIdioma.Size = New System.Drawing.Size(78, 26)
        Me.menuItemIdioma.Text = "I&dioma"
        '
        'tsmiActualizarIdiomas
        '
        Me.tsmiActualizarIdiomas.Name = "tsmiActualizarIdiomas"
        Me.tsmiActualizarIdiomas.Size = New System.Drawing.Size(159, 22)
        Me.tsmiActualizarIdiomas.Text = "&Actualizar"
        Me.tsmiActualizarIdiomas.Visible = False
        '
        'ITSMItemCambiarIdioma
        '
        Me.ITSMItemCambiarIdioma.ImageTransparentColor = System.Drawing.Color.Black
        Me.ITSMItemCambiarIdioma.Name = "ITSMItemCambiarIdioma"
        Me.ITSMItemCambiarIdioma.Size = New System.Drawing.Size(159, 22)
        Me.ITSMItemCambiarIdioma.Text = "&Cambiar Idioma"
        '
        'menuItemAyuda
        '
        Me.menuItemAyuda.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AyudaToolStripMenuItem, Me.AcercaDeToolStripMenuItem})
        Me.menuItemAyuda.Image = CType(resources.GetObject("menuItemAyuda.Image"), System.Drawing.Image)
        Me.menuItemAyuda.Name = "menuItemAyuda"
        Me.menuItemAyuda.Size = New System.Drawing.Size(75, 26)
        Me.menuItemAyuda.Text = "&Ayuda"
        '
        'AyudaToolStripMenuItem
        '
        Me.AyudaToolStripMenuItem.Name = "AyudaToolStripMenuItem"
        Me.AyudaToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AyudaToolStripMenuItem.Text = "&Ver la Ayuda"
        Me.AyudaToolStripMenuItem.Visible = False
        '
        'AcercaDeToolStripMenuItem
        '
        Me.AcercaDeToolStripMenuItem.Name = "AcercaDeToolStripMenuItem"
        Me.AcercaDeToolStripMenuItem.Size = New System.Drawing.Size(180, 22)
        Me.AcercaDeToolStripMenuItem.Text = "A&cerca de Auzonia"
        '
        'MenuStrip
        '
        Me.MenuStrip.AutoSize = False
        Me.MenuStrip.BackColor = System.Drawing.SystemColors.Highlight
        Me.MenuStrip.ImageScalingSize = New System.Drawing.Size(22, 22)
        Me.MenuStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.menuItemInicio, Me.menuItemCompras, Me.menuItemVentas, Me.menuItemContabilidad, Me.menuItemSistema, Me.menuItemIdioma, Me.menuItemInformes, Me.menuItemAyuda})
        Me.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.MdiWindowListItem = Me.menuItemAyuda
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(1152, 30)
        Me.MenuStrip.TabIndex = 7
        Me.MenuStrip.Text = "MenuStrip"
        '
        'menuItemInformes
        '
        Me.menuItemInformes.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsmiMovimientos, Me.tsmiMovimientosSalidaPorFecha})
        Me.menuItemInformes.Image = CType(resources.GetObject("menuItemInformes.Image"), System.Drawing.Image)
        Me.menuItemInformes.Name = "menuItemInformes"
        Me.menuItemInformes.Size = New System.Drawing.Size(88, 26)
        Me.menuItemInformes.Text = "I&nformes"
        Me.menuItemInformes.Visible = False
        '
        'tsmiMovimientos
        '
        Me.tsmiMovimientos.Name = "tsmiMovimientos"
        Me.tsmiMovimientos.Size = New System.Drawing.Size(233, 22)
        Me.tsmiMovimientos.Text = "&Movimientos"
        '
        'tsmiMovimientosSalidaPorFecha
        '
        Me.tsmiMovimientosSalidaPorFecha.Name = "tsmiMovimientosSalidaPorFecha"
        Me.tsmiMovimientosSalidaPorFecha.Size = New System.Drawing.Size(233, 22)
        Me.tsmiMovimientosSalidaPorFecha.Text = "Movimientos Salida Por Fecha"
        '
        'MDIPrincipal
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.BackgroundImage = Global.UI.My.Resources.Resources.AuzoniaFondo
        Me.ClientSize = New System.Drawing.Size(1152, 521)
        Me.Controls.Add(Me.MenuStrip)
        Me.Controls.Add(Me.StatusStrip)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "MDIPrincipal"
        Me.Text = "Auzonia"
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip.ResumeLayout(False)
        Me.MenuStrip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents tsslUsuario As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents menuItemInicio As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiIniciarSesion As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemCompras As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiProveedores As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiArticulos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemVentas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiClientes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiPedidosDeCliente As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemContabilidad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiValorizarMercaderia As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemSistema As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiPermisos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiGenerarBackup As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRestaurarBD As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemIdioma As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiActualizarIdiomas As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ITSMItemCambiarIdioma As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemAyuda As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiVerificarIntegridad As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiBitácoraDeAuditoria As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiNotasDePedido As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiRemitos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiEnvios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AyudaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AcercaDeToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiListaDePrecios As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents menuItemInformes As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiMovimientos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiMovimientosSalidaPorFecha As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents tsmiÁrbolDePermisos As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MenuStrip As MenuStrip
End Class
