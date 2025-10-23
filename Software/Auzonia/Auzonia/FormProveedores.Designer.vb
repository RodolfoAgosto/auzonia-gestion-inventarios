<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProveedores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProveedores))
        Me.LbAltura = New System.Windows.Forms.Label()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBCalle = New System.Windows.Forms.TextBox()
        Me.TBCUIT = New System.Windows.Forms.TextBox()
        Me.TBAltura = New System.Windows.Forms.TextBox()
        Me.TBID = New System.Windows.Forms.TextBox()
        Me.LbCUIT = New System.Windows.Forms.Label()
        Me.LbCalle = New System.Windows.Forms.Label()
        Me.LbRazonSocial = New System.Windows.Forms.Label()
        Me.LbUsuario = New System.Windows.Forms.Label()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.BTNCrearProveedor = New System.Windows.Forms.Button()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.DGVProveedor = New System.Windows.Forms.DataGridView()
        Me.GBResultados = New System.Windows.Forms.GroupBox()
        Me.TBTelefono = New System.Windows.Forms.TextBox()
        Me.LbTelefono = New System.Windows.Forms.Label()
        Me.TBContacto = New System.Windows.Forms.TextBox()
        Me.LbContacto = New System.Windows.Forms.Label()
        Me.TBEmail = New System.Windows.Forms.TextBox()
        Me.LbEmail = New System.Windows.Forms.Label()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        CType(Me.DGVProveedor, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBResultados.SuspendLayout()
        Me.SuspendLayout()
        '
        'LbAltura
        '
        Me.LbAltura.AutoSize = True
        Me.LbAltura.Location = New System.Drawing.Point(408, 35)
        Me.LbAltura.Name = "LbAltura"
        Me.LbAltura.Size = New System.Drawing.Size(30, 13)
        Me.LbAltura.TabIndex = 19
        Me.LbAltura.Text = "Nro :"
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Location = New System.Drawing.Point(16, 50)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(204, 20)
        Me.TBRazonSocial.TabIndex = 18
        '
        'TBCalle
        '
        Me.TBCalle.Location = New System.Drawing.Point(229, 50)
        Me.TBCalle.Name = "TBCalle"
        Me.TBCalle.Size = New System.Drawing.Size(170, 20)
        Me.TBCalle.TabIndex = 17
        '
        'TBCUIT
        '
        Me.TBCUIT.Location = New System.Drawing.Point(16, 91)
        Me.TBCUIT.MaxLength = 13
        Me.TBCUIT.Name = "TBCUIT"
        Me.TBCUIT.Size = New System.Drawing.Size(204, 20)
        Me.TBCUIT.TabIndex = 16
        '
        'TBAltura
        '
        Me.TBAltura.Location = New System.Drawing.Point(405, 50)
        Me.TBAltura.Name = "TBAltura"
        Me.TBAltura.Size = New System.Drawing.Size(94, 20)
        Me.TBAltura.TabIndex = 15
        '
        'TBID
        '
        Me.TBID.Location = New System.Drawing.Point(41, 10)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(69, 20)
        Me.TBID.TabIndex = 14
        '
        'LbCUIT
        '
        Me.LbCUIT.AutoSize = True
        Me.LbCUIT.Location = New System.Drawing.Point(19, 76)
        Me.LbCUIT.Name = "LbCUIT"
        Me.LbCUIT.Size = New System.Drawing.Size(35, 13)
        Me.LbCUIT.TabIndex = 13
        Me.LbCUIT.Text = "CUIT:"
        '
        'LbCalle
        '
        Me.LbCalle.AutoSize = True
        Me.LbCalle.Location = New System.Drawing.Point(232, 35)
        Me.LbCalle.Name = "LbCalle"
        Me.LbCalle.Size = New System.Drawing.Size(36, 13)
        Me.LbCalle.TabIndex = 12
        Me.LbCalle.Text = "Calle :"
        '
        'LbRazonSocial
        '
        Me.LbRazonSocial.AutoSize = True
        Me.LbRazonSocial.Location = New System.Drawing.Point(19, 35)
        Me.LbRazonSocial.Name = "LbRazonSocial"
        Me.LbRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.LbRazonSocial.TabIndex = 11
        Me.LbRazonSocial.Text = "Razón Social :"
        '
        'LbUsuario
        '
        Me.LbUsuario.AutoSize = True
        Me.LbUsuario.Location = New System.Drawing.Point(19, 14)
        Me.LbUsuario.Name = "LbUsuario"
        Me.LbUsuario.Size = New System.Drawing.Size(21, 13)
        Me.LbUsuario.TabIndex = 10
        Me.LbUsuario.Text = "ID:"
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(692, 72)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(122, 23)
        Me.BTNModificar.TabIndex = 24
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        Me.BTNModificar.Visible = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(692, 101)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(122, 23)
        Me.BTNEliminar.TabIndex = 23
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        Me.BTNEliminar.Visible = False
        '
        'BTNCrearProveedor
        '
        Me.BTNCrearProveedor.Location = New System.Drawing.Point(692, 14)
        Me.BTNCrearProveedor.Name = "BTNCrearProveedor"
        Me.BTNCrearProveedor.Size = New System.Drawing.Size(122, 23)
        Me.BTNCrearProveedor.TabIndex = 22
        Me.BTNCrearProveedor.Text = "Crear Proveedor"
        Me.BTNCrearProveedor.UseVisualStyleBackColor = True
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(692, 43)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(122, 23)
        Me.BTNBuscar.TabIndex = 20
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'DGVProveedor
        '
        Me.DGVProveedor.AllowUserToAddRows = False
        Me.DGVProveedor.AllowUserToDeleteRows = False
        Me.DGVProveedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVProveedor.Location = New System.Drawing.Point(7, 20)
        Me.DGVProveedor.MultiSelect = False
        Me.DGVProveedor.Name = "DGVProveedor"
        Me.DGVProveedor.ReadOnly = True
        Me.DGVProveedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVProveedor.Size = New System.Drawing.Size(795, 100)
        Me.DGVProveedor.TabIndex = 16
        '
        'GBResultados
        '
        Me.GBResultados.Controls.Add(Me.DGVProveedor)
        Me.GBResultados.Location = New System.Drawing.Point(12, 131)
        Me.GBResultados.Name = "GBResultados"
        Me.GBResultados.Size = New System.Drawing.Size(808, 127)
        Me.GBResultados.TabIndex = 21
        Me.GBResultados.TabStop = False
        Me.GBResultados.Text = "Resultados"
        '
        'TBTelefono
        '
        Me.TBTelefono.Location = New System.Drawing.Point(508, 51)
        Me.TBTelefono.Name = "TBTelefono"
        Me.TBTelefono.Size = New System.Drawing.Size(170, 20)
        Me.TBTelefono.TabIndex = 26
        '
        'LbTelefono
        '
        Me.LbTelefono.AutoSize = True
        Me.LbTelefono.Location = New System.Drawing.Point(511, 36)
        Me.LbTelefono.Name = "LbTelefono"
        Me.LbTelefono.Size = New System.Drawing.Size(55, 13)
        Me.LbTelefono.TabIndex = 25
        Me.LbTelefono.Text = "Teléfono :"
        '
        'TBContacto
        '
        Me.TBContacto.Location = New System.Drawing.Point(508, 91)
        Me.TBContacto.Name = "TBContacto"
        Me.TBContacto.Size = New System.Drawing.Size(170, 20)
        Me.TBContacto.TabIndex = 28
        '
        'LbContacto
        '
        Me.LbContacto.AutoSize = True
        Me.LbContacto.Location = New System.Drawing.Point(511, 76)
        Me.LbContacto.Name = "LbContacto"
        Me.LbContacto.Size = New System.Drawing.Size(56, 13)
        Me.LbContacto.TabIndex = 27
        Me.LbContacto.Text = "Contacto :"
        '
        'TBEmail
        '
        Me.TBEmail.Location = New System.Drawing.Point(230, 91)
        Me.TBEmail.Name = "TBEmail"
        Me.TBEmail.Size = New System.Drawing.Size(269, 20)
        Me.TBEmail.TabIndex = 30
        '
        'LbEmail
        '
        Me.LbEmail.AutoSize = True
        Me.LbEmail.Location = New System.Drawing.Point(233, 76)
        Me.LbEmail.Name = "LbEmail"
        Me.LbEmail.Size = New System.Drawing.Size(38, 13)
        Me.LbEmail.TabIndex = 29
        Me.LbEmail.Text = "Email :"
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(730, 264)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 31
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormProveedores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(835, 293)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.TBEmail)
        Me.Controls.Add(Me.LbEmail)
        Me.Controls.Add(Me.TBContacto)
        Me.Controls.Add(Me.LbContacto)
        Me.Controls.Add(Me.TBTelefono)
        Me.Controls.Add(Me.LbTelefono)
        Me.Controls.Add(Me.BTNModificar)
        Me.Controls.Add(Me.BTNEliminar)
        Me.Controls.Add(Me.BTNCrearProveedor)
        Me.Controls.Add(Me.BTNBuscar)
        Me.Controls.Add(Me.GBResultados)
        Me.Controls.Add(Me.LbAltura)
        Me.Controls.Add(Me.TBRazonSocial)
        Me.Controls.Add(Me.TBCalle)
        Me.Controls.Add(Me.TBCUIT)
        Me.Controls.Add(Me.TBAltura)
        Me.Controls.Add(Me.TBID)
        Me.Controls.Add(Me.LbCUIT)
        Me.Controls.Add(Me.LbCalle)
        Me.Controls.Add(Me.LbRazonSocial)
        Me.Controls.Add(Me.LbUsuario)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormProveedores"
        Me.Text = "Proveedores"
        CType(Me.DGVProveedor, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBResultados.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LbAltura As System.Windows.Forms.Label
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBCalle As System.Windows.Forms.TextBox
    Friend WithEvents TBCUIT As System.Windows.Forms.TextBox
    Friend WithEvents TBAltura As System.Windows.Forms.TextBox
    Friend WithEvents TBID As System.Windows.Forms.TextBox
    Friend WithEvents LbCUIT As System.Windows.Forms.Label
    Friend WithEvents LbCalle As System.Windows.Forms.Label
    Friend WithEvents LbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    Friend WithEvents BTNModificar As System.Windows.Forms.Button
    Friend WithEvents BTNEliminar As System.Windows.Forms.Button
    Friend WithEvents BTNCrearProveedor As System.Windows.Forms.Button
    Friend WithEvents BTNBuscar As System.Windows.Forms.Button
    Friend WithEvents DGVProveedor As System.Windows.Forms.DataGridView
    Friend WithEvents GBResultados As System.Windows.Forms.GroupBox
    Friend WithEvents TBTelefono As System.Windows.Forms.TextBox
    Friend WithEvents LbTelefono As System.Windows.Forms.Label
    Friend WithEvents TBContacto As System.Windows.Forms.TextBox
    Friend WithEvents LbContacto As System.Windows.Forms.Label
    Friend WithEvents TBEmail As System.Windows.Forms.TextBox
    Friend WithEvents LbEmail As System.Windows.Forms.Label
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents ToolTip As ToolTip
End Class
