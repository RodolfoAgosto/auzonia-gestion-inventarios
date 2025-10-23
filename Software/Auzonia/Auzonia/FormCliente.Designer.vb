<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormCliente
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCliente))
        Me.TBEmail = New System.Windows.Forms.TextBox()
        Me.LbEmail = New System.Windows.Forms.Label()
        Me.TBContacto = New System.Windows.Forms.TextBox()
        Me.LbContacto = New System.Windows.Forms.Label()
        Me.TBTelefono = New System.Windows.Forms.TextBox()
        Me.LbTelefono = New System.Windows.Forms.Label()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.BTNCrearCliente = New System.Windows.Forms.Button()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.GBResultados = New System.Windows.Forms.GroupBox()
        Me.DGVClientes = New System.Windows.Forms.DataGridView()
        Me.LbNumero = New System.Windows.Forms.Label()
        Me.TBRazonSocial = New System.Windows.Forms.TextBox()
        Me.TBCalle = New System.Windows.Forms.TextBox()
        Me.TBCUIT = New System.Windows.Forms.TextBox()
        Me.TBNumero = New System.Windows.Forms.TextBox()
        Me.LbCUIT = New System.Windows.Forms.Label()
        Me.LbCalle = New System.Windows.Forms.Label()
        Me.lbRazonSocial = New System.Windows.Forms.Label()
        Me.LbCliente = New System.Windows.Forms.Label()
        Me.TBID = New System.Windows.Forms.TextBox()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.CBUsuarios = New System.Windows.Forms.ComboBox()
        Me.lbUsuario = New System.Windows.Forms.Label()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.GBResultados.SuspendLayout()
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TBEmail
        '
        Me.TBEmail.Location = New System.Drawing.Point(224, 90)
        Me.TBEmail.Name = "TBEmail"
        Me.TBEmail.Size = New System.Drawing.Size(269, 20)
        Me.TBEmail.TabIndex = 51
        '
        'LbEmail
        '
        Me.LbEmail.AutoSize = True
        Me.LbEmail.Location = New System.Drawing.Point(227, 75)
        Me.LbEmail.Name = "LbEmail"
        Me.LbEmail.Size = New System.Drawing.Size(38, 13)
        Me.LbEmail.TabIndex = 50
        Me.LbEmail.Text = "Email :"
        '
        'TBContacto
        '
        Me.TBContacto.Location = New System.Drawing.Point(502, 90)
        Me.TBContacto.Name = "TBContacto"
        Me.TBContacto.Size = New System.Drawing.Size(170, 20)
        Me.TBContacto.TabIndex = 49
        '
        'LbContacto
        '
        Me.LbContacto.AutoSize = True
        Me.LbContacto.Location = New System.Drawing.Point(505, 75)
        Me.LbContacto.Name = "LbContacto"
        Me.LbContacto.Size = New System.Drawing.Size(56, 13)
        Me.LbContacto.TabIndex = 48
        Me.LbContacto.Text = "Contacto :"
        '
        'TBTelefono
        '
        Me.TBTelefono.Location = New System.Drawing.Point(502, 50)
        Me.TBTelefono.Name = "TBTelefono"
        Me.TBTelefono.Size = New System.Drawing.Size(170, 20)
        Me.TBTelefono.TabIndex = 47
        '
        'LbTelefono
        '
        Me.LbTelefono.AutoSize = True
        Me.LbTelefono.Location = New System.Drawing.Point(505, 35)
        Me.LbTelefono.Name = "LbTelefono"
        Me.LbTelefono.Size = New System.Drawing.Size(55, 13)
        Me.LbTelefono.TabIndex = 46
        Me.LbTelefono.Text = "Teléfono :"
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(686, 71)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(122, 23)
        Me.BTNModificar.TabIndex = 45
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        Me.BTNModificar.Visible = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(686, 100)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(122, 23)
        Me.BTNEliminar.TabIndex = 44
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        Me.BTNEliminar.Visible = False
        '
        'BTNCrearCliente
        '
        Me.BTNCrearCliente.Location = New System.Drawing.Point(686, 13)
        Me.BTNCrearCliente.Name = "BTNCrearCliente"
        Me.BTNCrearCliente.Size = New System.Drawing.Size(122, 23)
        Me.BTNCrearCliente.TabIndex = 43
        Me.BTNCrearCliente.Text = "Crear Cliente"
        Me.BTNCrearCliente.UseVisualStyleBackColor = True
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(686, 42)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(122, 23)
        Me.BTNBuscar.TabIndex = 41
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'GBResultados
        '
        Me.GBResultados.Controls.Add(Me.DGVClientes)
        Me.GBResultados.Location = New System.Drawing.Point(6, 130)
        Me.GBResultados.Name = "GBResultados"
        Me.GBResultados.Size = New System.Drawing.Size(808, 169)
        Me.GBResultados.TabIndex = 42
        Me.GBResultados.TabStop = False
        Me.GBResultados.Text = "Resultados"
        '
        'DGVClientes
        '
        Me.DGVClientes.AllowUserToAddRows = False
        Me.DGVClientes.AllowUserToDeleteRows = False
        Me.DGVClientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVClientes.Location = New System.Drawing.Point(7, 20)
        Me.DGVClientes.MultiSelect = False
        Me.DGVClientes.Name = "DGVClientes"
        Me.DGVClientes.ReadOnly = True
        Me.DGVClientes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVClientes.Size = New System.Drawing.Size(795, 143)
        Me.DGVClientes.TabIndex = 16
        '
        'LbNumero
        '
        Me.LbNumero.AutoSize = True
        Me.LbNumero.Location = New System.Drawing.Point(402, 34)
        Me.LbNumero.Name = "LbNumero"
        Me.LbNumero.Size = New System.Drawing.Size(30, 13)
        Me.LbNumero.TabIndex = 40
        Me.LbNumero.Text = "Nro :"
        '
        'TBRazonSocial
        '
        Me.TBRazonSocial.Location = New System.Drawing.Point(10, 49)
        Me.TBRazonSocial.Name = "TBRazonSocial"
        Me.TBRazonSocial.Size = New System.Drawing.Size(204, 20)
        Me.TBRazonSocial.TabIndex = 39
        '
        'TBCalle
        '
        Me.TBCalle.Location = New System.Drawing.Point(223, 49)
        Me.TBCalle.Name = "TBCalle"
        Me.TBCalle.Size = New System.Drawing.Size(170, 20)
        Me.TBCalle.TabIndex = 38
        '
        'TBCUIT
        '
        Me.TBCUIT.Location = New System.Drawing.Point(10, 90)
        Me.TBCUIT.MaxLength = 13
        Me.TBCUIT.Name = "TBCUIT"
        Me.TBCUIT.Size = New System.Drawing.Size(204, 20)
        Me.TBCUIT.TabIndex = 37
        '
        'TBNumero
        '
        Me.TBNumero.Location = New System.Drawing.Point(399, 49)
        Me.TBNumero.Name = "TBNumero"
        Me.TBNumero.Size = New System.Drawing.Size(94, 20)
        Me.TBNumero.TabIndex = 36
        '
        'LbCUIT
        '
        Me.LbCUIT.AutoSize = True
        Me.LbCUIT.Location = New System.Drawing.Point(13, 75)
        Me.LbCUIT.Name = "LbCUIT"
        Me.LbCUIT.Size = New System.Drawing.Size(35, 13)
        Me.LbCUIT.TabIndex = 34
        Me.LbCUIT.Text = "CUIT:"
        '
        'LbCalle
        '
        Me.LbCalle.AutoSize = True
        Me.LbCalle.Location = New System.Drawing.Point(226, 34)
        Me.LbCalle.Name = "LbCalle"
        Me.LbCalle.Size = New System.Drawing.Size(36, 13)
        Me.LbCalle.TabIndex = 33
        Me.LbCalle.Text = "Calle :"
        '
        'lbRazonSocial
        '
        Me.lbRazonSocial.AutoSize = True
        Me.lbRazonSocial.Location = New System.Drawing.Point(13, 34)
        Me.lbRazonSocial.Name = "lbRazonSocial"
        Me.lbRazonSocial.Size = New System.Drawing.Size(76, 13)
        Me.lbRazonSocial.TabIndex = 32
        Me.lbRazonSocial.Text = "Razón Social :"
        '
        'LbCliente
        '
        Me.LbCliente.AutoSize = True
        Me.LbCliente.Location = New System.Drawing.Point(13, 13)
        Me.LbCliente.Name = "LbCliente"
        Me.LbCliente.Size = New System.Drawing.Size(21, 13)
        Me.LbCliente.TabIndex = 31
        Me.LbCliente.Text = "ID:"
        '
        'TBID
        '
        Me.TBID.Location = New System.Drawing.Point(35, 9)
        Me.TBID.Name = "TBID"
        Me.TBID.Size = New System.Drawing.Size(69, 20)
        Me.TBID.TabIndex = 35
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(731, 305)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 23)
        Me.BTNSalir.TabIndex = 52
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'CBUsuarios
        '
        Me.CBUsuarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBUsuarios.FormattingEnabled = True
        Me.CBUsuarios.Location = New System.Drawing.Point(399, 8)
        Me.CBUsuarios.Name = "CBUsuarios"
        Me.CBUsuarios.Size = New System.Drawing.Size(273, 21)
        Me.CBUsuarios.TabIndex = 53
        '
        'lbUsuario
        '
        Me.lbUsuario.AutoSize = True
        Me.lbUsuario.Location = New System.Drawing.Point(348, 12)
        Me.lbUsuario.Name = "lbUsuario"
        Me.lbUsuario.Size = New System.Drawing.Size(49, 13)
        Me.lbUsuario.TabIndex = 54
        Me.lbUsuario.Text = "Usuario :"
        '
        'FormCliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(824, 333)
        Me.Controls.Add(Me.lbUsuario)
        Me.Controls.Add(Me.CBUsuarios)
        Me.Controls.Add(Me.BTNSalir)
        Me.Controls.Add(Me.TBEmail)
        Me.Controls.Add(Me.LbEmail)
        Me.Controls.Add(Me.TBContacto)
        Me.Controls.Add(Me.LbContacto)
        Me.Controls.Add(Me.TBTelefono)
        Me.Controls.Add(Me.LbTelefono)
        Me.Controls.Add(Me.BTNModificar)
        Me.Controls.Add(Me.BTNEliminar)
        Me.Controls.Add(Me.BTNCrearCliente)
        Me.Controls.Add(Me.BTNBuscar)
        Me.Controls.Add(Me.GBResultados)
        Me.Controls.Add(Me.LbNumero)
        Me.Controls.Add(Me.TBRazonSocial)
        Me.Controls.Add(Me.TBCalle)
        Me.Controls.Add(Me.TBCUIT)
        Me.Controls.Add(Me.TBNumero)
        Me.Controls.Add(Me.LbCUIT)
        Me.Controls.Add(Me.LbCalle)
        Me.Controls.Add(Me.lbRazonSocial)
        Me.Controls.Add(Me.LbCliente)
        Me.Controls.Add(Me.TBID)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormCliente"
        Me.Text = "Clientes"
        Me.GBResultados.ResumeLayout(False)
        CType(Me.DGVClientes, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents TBEmail As System.Windows.Forms.TextBox
    Friend WithEvents LbEmail As System.Windows.Forms.Label
    Friend WithEvents TBContacto As System.Windows.Forms.TextBox
    Friend WithEvents LbContacto As System.Windows.Forms.Label
    Friend WithEvents TBTelefono As System.Windows.Forms.TextBox
    Friend WithEvents LbTelefono As System.Windows.Forms.Label
    Friend WithEvents BTNModificar As System.Windows.Forms.Button
    Friend WithEvents BTNEliminar As System.Windows.Forms.Button
    Friend WithEvents BTNCrearCliente As System.Windows.Forms.Button
    Friend WithEvents BTNBuscar As System.Windows.Forms.Button
    Friend WithEvents GBResultados As System.Windows.Forms.GroupBox
    Friend WithEvents DGVClientes As System.Windows.Forms.DataGridView
    Friend WithEvents LbNumero As System.Windows.Forms.Label
    Friend WithEvents TBRazonSocial As System.Windows.Forms.TextBox
    Friend WithEvents TBCalle As System.Windows.Forms.TextBox
    Friend WithEvents TBCUIT As System.Windows.Forms.TextBox
    Friend WithEvents TBNumero As System.Windows.Forms.TextBox
    Friend WithEvents LbCUIT As System.Windows.Forms.Label
    Friend WithEvents LbCalle As System.Windows.Forms.Label
    Friend WithEvents lbRazonSocial As System.Windows.Forms.Label
    Friend WithEvents LbCliente As System.Windows.Forms.Label
    Friend WithEvents TBID As System.Windows.Forms.TextBox
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents CBUsuarios As System.Windows.Forms.ComboBox
    Friend WithEvents lbUsuario As System.Windows.Forms.Label
    Friend WithEvents ToolTip As ToolTip
End Class
