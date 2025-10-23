<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormAdmPerfilesUsuarios
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormAdmPerfilesUsuarios))
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TPUsuarios = New System.Windows.Forms.TabPage()
        Me.BTNCambiarContraseña = New System.Windows.Forms.Button()
        Me.BTNDesbloquear = New System.Windows.Forms.Button()
        Me.BTNBitacora = New System.Windows.Forms.Button()
        Me.BTNModificar = New System.Windows.Forms.Button()
        Me.BTNEliminar = New System.Windows.Forms.Button()
        Me.GPPermisosDisponiblesUsuarios = New System.Windows.Forms.GroupBox()
        Me.DGVPermisosDisponiblesUsuario = New System.Windows.Forms.DataGridView()
        Me.BTNAsignar = New System.Windows.Forms.Button()
        Me.BTNCrearUsuario = New System.Windows.Forms.Button()
        Me.GBResultados = New System.Windows.Forms.GroupBox()
        Me.DGVUsuarios = New System.Windows.Forms.DataGridView()
        Me.GPPermisosAsignadosUsuarios = New System.Windows.Forms.GroupBox()
        Me.DGVPermisosAsignadosUsuario = New System.Windows.Forms.DataGridView()
        Me.BTNDesasignar = New System.Windows.Forms.Button()
        Me.BTNBuscar = New System.Windows.Forms.Button()
        Me.LbEmail = New System.Windows.Forms.Label()
        Me.TBNombre = New System.Windows.Forms.TextBox()
        Me.TBApellido = New System.Windows.Forms.TextBox()
        Me.TBDNI = New System.Windows.Forms.TextBox()
        Me.TBEMail = New System.Windows.Forms.TextBox()
        Me.TBUsuario = New System.Windows.Forms.TextBox()
        Me.LbDNI = New System.Windows.Forms.Label()
        Me.LbApellido = New System.Windows.Forms.Label()
        Me.LbNombre = New System.Windows.Forms.Label()
        Me.LbUsuario = New System.Windows.Forms.Label()
        Me.TPPerfiles = New System.Windows.Forms.TabPage()
        Me.GBPermisosDisponiblesPerfiles = New System.Windows.Forms.GroupBox()
        Me.DGVPermisosDisponiblesPerfil = New System.Windows.Forms.DataGridView()
        Me.GBPermisosAsignadosPerfiles = New System.Windows.Forms.GroupBox()
        Me.DGVPermisosAsignadosPerfil = New System.Windows.Forms.DataGridView()
        Me.BTNDesasignarPermiso = New System.Windows.Forms.Button()
        Me.CBPerfiles = New System.Windows.Forms.ComboBox()
        Me.BTNAsignarPermiso = New System.Windows.Forms.Button()
        Me.BTNEliminarPerfil = New System.Windows.Forms.Button()
        Me.BTNGuardarCambios = New System.Windows.Forms.Button()
        Me.BTNCrearPerfil = New System.Windows.Forms.Button()
        Me.LbPerfil = New System.Windows.Forms.Label()
        Me.BTNSalir = New System.Windows.Forms.Button()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1.SuspendLayout()
        Me.TPUsuarios.SuspendLayout()
        Me.GPPermisosDisponiblesUsuarios.SuspendLayout()
        CType(Me.DGVPermisosDisponiblesUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBResultados.SuspendLayout()
        CType(Me.DGVUsuarios, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GPPermisosAsignadosUsuarios.SuspendLayout()
        CType(Me.DGVPermisosAsignadosUsuario, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TPPerfiles.SuspendLayout()
        Me.GBPermisosDisponiblesPerfiles.SuspendLayout()
        CType(Me.DGVPermisosDisponiblesPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GBPermisosAsignadosPerfiles.SuspendLayout()
        CType(Me.DGVPermisosAsignadosPerfil, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TPUsuarios)
        Me.TabControl1.Controls.Add(Me.TPPerfiles)
        Me.TabControl1.Location = New System.Drawing.Point(12, 12)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(1055, 367)
        Me.TabControl1.TabIndex = 0
        '
        'TPUsuarios
        '
        Me.TPUsuarios.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TPUsuarios.Controls.Add(Me.BTNCambiarContraseña)
        Me.TPUsuarios.Controls.Add(Me.BTNDesbloquear)
        Me.TPUsuarios.Controls.Add(Me.BTNBitacora)
        Me.TPUsuarios.Controls.Add(Me.BTNModificar)
        Me.TPUsuarios.Controls.Add(Me.BTNEliminar)
        Me.TPUsuarios.Controls.Add(Me.GPPermisosDisponiblesUsuarios)
        Me.TPUsuarios.Controls.Add(Me.BTNCrearUsuario)
        Me.TPUsuarios.Controls.Add(Me.GBResultados)
        Me.TPUsuarios.Controls.Add(Me.GPPermisosAsignadosUsuarios)
        Me.TPUsuarios.Controls.Add(Me.BTNBuscar)
        Me.TPUsuarios.Controls.Add(Me.LbEmail)
        Me.TPUsuarios.Controls.Add(Me.TBNombre)
        Me.TPUsuarios.Controls.Add(Me.TBApellido)
        Me.TPUsuarios.Controls.Add(Me.TBDNI)
        Me.TPUsuarios.Controls.Add(Me.TBEMail)
        Me.TPUsuarios.Controls.Add(Me.TBUsuario)
        Me.TPUsuarios.Controls.Add(Me.LbDNI)
        Me.TPUsuarios.Controls.Add(Me.LbApellido)
        Me.TPUsuarios.Controls.Add(Me.LbNombre)
        Me.TPUsuarios.Controls.Add(Me.LbUsuario)
        Me.TPUsuarios.Location = New System.Drawing.Point(4, 22)
        Me.TPUsuarios.Name = "TPUsuarios"
        Me.TPUsuarios.Padding = New System.Windows.Forms.Padding(3)
        Me.TPUsuarios.Size = New System.Drawing.Size(1047, 341)
        Me.TPUsuarios.TabIndex = 1
        Me.TPUsuarios.Text = "Usuarios"
        '
        'BTNCambiarContraseña
        '
        Me.BTNCambiarContraseña.Location = New System.Drawing.Point(2, 121)
        Me.BTNCambiarContraseña.Name = "BTNCambiarContraseña"
        Me.BTNCambiarContraseña.Size = New System.Drawing.Size(75, 23)
        Me.BTNCambiarContraseña.TabIndex = 19
        Me.BTNCambiarContraseña.Text = "Contraseña"
        Me.BTNCambiarContraseña.UseVisualStyleBackColor = True
        Me.BTNCambiarContraseña.Visible = False
        '
        'BTNDesbloquear
        '
        Me.BTNDesbloquear.Location = New System.Drawing.Point(78, 121)
        Me.BTNDesbloquear.Name = "BTNDesbloquear"
        Me.BTNDesbloquear.Size = New System.Drawing.Size(84, 23)
        Me.BTNDesbloquear.TabIndex = 17
        Me.BTNDesbloquear.Text = "Desbloquear"
        Me.BTNDesbloquear.UseVisualStyleBackColor = True
        Me.BTNDesbloquear.Visible = False
        '
        'BTNBitacora
        '
        Me.BTNBitacora.Location = New System.Drawing.Point(164, 121)
        Me.BTNBitacora.Name = "BTNBitacora"
        Me.BTNBitacora.Size = New System.Drawing.Size(170, 23)
        Me.BTNBitacora.TabIndex = 18
        Me.BTNBitacora.Text = "Historial de Cambios"
        Me.BTNBitacora.UseVisualStyleBackColor = True
        Me.BTNBitacora.Visible = False
        '
        'BTNModificar
        '
        Me.BTNModificar.Location = New System.Drawing.Point(2, 95)
        Me.BTNModificar.Name = "BTNModificar"
        Me.BTNModificar.Size = New System.Drawing.Size(75, 23)
        Me.BTNModificar.TabIndex = 17
        Me.BTNModificar.Text = "Modificar"
        Me.BTNModificar.UseVisualStyleBackColor = True
        Me.BTNModificar.Visible = False
        '
        'BTNEliminar
        '
        Me.BTNEliminar.Location = New System.Drawing.Point(78, 95)
        Me.BTNEliminar.Name = "BTNEliminar"
        Me.BTNEliminar.Size = New System.Drawing.Size(84, 23)
        Me.BTNEliminar.TabIndex = 16
        Me.BTNEliminar.Text = "Eliminar"
        Me.BTNEliminar.UseVisualStyleBackColor = True
        Me.BTNEliminar.Visible = False
        '
        'GPPermisosDisponiblesUsuarios
        '
        Me.GPPermisosDisponiblesUsuarios.Controls.Add(Me.DGVPermisosDisponiblesUsuario)
        Me.GPPermisosDisponiblesUsuarios.Controls.Add(Me.BTNAsignar)
        Me.GPPermisosDisponiblesUsuarios.Location = New System.Drawing.Point(703, 5)
        Me.GPPermisosDisponiblesUsuarios.Name = "GPPermisosDisponiblesUsuarios"
        Me.GPPermisosDisponiblesUsuarios.Size = New System.Drawing.Size(338, 142)
        Me.GPPermisosDisponiblesUsuarios.TabIndex = 12
        Me.GPPermisosDisponiblesUsuarios.TabStop = False
        Me.GPPermisosDisponiblesUsuarios.Text = "Permisos Disponibles"
        '
        'DGVPermisosDisponiblesUsuario
        '
        Me.DGVPermisosDisponiblesUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPermisosDisponiblesUsuario.Location = New System.Drawing.Point(6, 16)
        Me.DGVPermisosDisponiblesUsuario.MultiSelect = False
        Me.DGVPermisosDisponiblesUsuario.Name = "DGVPermisosDisponiblesUsuario"
        Me.DGVPermisosDisponiblesUsuario.ReadOnly = True
        Me.DGVPermisosDisponiblesUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPermisosDisponiblesUsuario.Size = New System.Drawing.Size(324, 94)
        Me.DGVPermisosDisponiblesUsuario.TabIndex = 18
        '
        'BTNAsignar
        '
        Me.BTNAsignar.Location = New System.Drawing.Point(250, 113)
        Me.BTNAsignar.Name = "BTNAsignar"
        Me.BTNAsignar.Size = New System.Drawing.Size(75, 23)
        Me.BTNAsignar.TabIndex = 14
        Me.BTNAsignar.Text = "Asignar"
        Me.BTNAsignar.UseVisualStyleBackColor = True
        '
        'BTNCrearUsuario
        '
        Me.BTNCrearUsuario.Location = New System.Drawing.Point(164, 95)
        Me.BTNCrearUsuario.Name = "BTNCrearUsuario"
        Me.BTNCrearUsuario.Size = New System.Drawing.Size(84, 23)
        Me.BTNCrearUsuario.TabIndex = 15
        Me.BTNCrearUsuario.Text = "Crear Usuario"
        Me.BTNCrearUsuario.UseVisualStyleBackColor = True
        '
        'GBResultados
        '
        Me.GBResultados.Controls.Add(Me.DGVUsuarios)
        Me.GBResultados.Location = New System.Drawing.Point(6, 147)
        Me.GBResultados.Name = "GBResultados"
        Me.GBResultados.Size = New System.Drawing.Size(1035, 188)
        Me.GBResultados.TabIndex = 12
        Me.GBResultados.TabStop = False
        Me.GBResultados.Text = "Resultados"
        '
        'DGVUsuarios
        '
        Me.DGVUsuarios.AllowUserToAddRows = False
        Me.DGVUsuarios.AllowUserToDeleteRows = False
        Me.DGVUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVUsuarios.Location = New System.Drawing.Point(6, 19)
        Me.DGVUsuarios.MultiSelect = False
        Me.DGVUsuarios.Name = "DGVUsuarios"
        Me.DGVUsuarios.ReadOnly = True
        Me.DGVUsuarios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVUsuarios.Size = New System.Drawing.Size(1021, 163)
        Me.DGVUsuarios.TabIndex = 16
        '
        'GPPermisosAsignadosUsuarios
        '
        Me.GPPermisosAsignadosUsuarios.Controls.Add(Me.DGVPermisosAsignadosUsuario)
        Me.GPPermisosAsignadosUsuarios.Controls.Add(Me.BTNDesasignar)
        Me.GPPermisosAsignadosUsuarios.Location = New System.Drawing.Point(361, 5)
        Me.GPPermisosAsignadosUsuarios.Name = "GPPermisosAsignadosUsuarios"
        Me.GPPermisosAsignadosUsuarios.Size = New System.Drawing.Size(336, 142)
        Me.GPPermisosAsignadosUsuarios.TabIndex = 11
        Me.GPPermisosAsignadosUsuarios.TabStop = False
        Me.GPPermisosAsignadosUsuarios.Text = "Permisos Asignados"
        '
        'DGVPermisosAsignadosUsuario
        '
        Me.DGVPermisosAsignadosUsuario.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPermisosAsignadosUsuario.Location = New System.Drawing.Point(6, 16)
        Me.DGVPermisosAsignadosUsuario.MultiSelect = False
        Me.DGVPermisosAsignadosUsuario.Name = "DGVPermisosAsignadosUsuario"
        Me.DGVPermisosAsignadosUsuario.ReadOnly = True
        Me.DGVPermisosAsignadosUsuario.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPermisosAsignadosUsuario.Size = New System.Drawing.Size(324, 94)
        Me.DGVPermisosAsignadosUsuario.TabIndex = 17
        '
        'BTNDesasignar
        '
        Me.BTNDesasignar.Location = New System.Drawing.Point(251, 113)
        Me.BTNDesasignar.Name = "BTNDesasignar"
        Me.BTNDesasignar.Size = New System.Drawing.Size(75, 23)
        Me.BTNDesasignar.TabIndex = 13
        Me.BTNDesasignar.Text = "Desasignar"
        Me.BTNDesasignar.UseVisualStyleBackColor = True
        '
        'BTNBuscar
        '
        Me.BTNBuscar.Location = New System.Drawing.Point(250, 95)
        Me.BTNBuscar.Name = "BTNBuscar"
        Me.BTNBuscar.Size = New System.Drawing.Size(84, 23)
        Me.BTNBuscar.TabIndex = 10
        Me.BTNBuscar.Text = "Buscar"
        Me.BTNBuscar.UseVisualStyleBackColor = True
        '
        'LbEmail
        '
        Me.LbEmail.AutoSize = True
        Me.LbEmail.Location = New System.Drawing.Point(184, 45)
        Me.LbEmail.Name = "LbEmail"
        Me.LbEmail.Size = New System.Drawing.Size(38, 13)
        Me.LbEmail.TabIndex = 9
        Me.LbEmail.Text = "Email :"
        '
        'TBNombre
        '
        Me.TBNombre.Location = New System.Drawing.Point(81, 22)
        Me.TBNombre.MaxLength = 30
        Me.TBNombre.Name = "TBNombre"
        Me.TBNombre.Size = New System.Drawing.Size(100, 20)
        Me.TBNombre.TabIndex = 8
        '
        'TBApellido
        '
        Me.TBApellido.Location = New System.Drawing.Point(187, 22)
        Me.TBApellido.MaxLength = 30
        Me.TBApellido.Name = "TBApellido"
        Me.TBApellido.Size = New System.Drawing.Size(125, 20)
        Me.TBApellido.TabIndex = 7
        '
        'TBDNI
        '
        Me.TBDNI.Location = New System.Drawing.Point(81, 60)
        Me.TBDNI.MaxLength = 9
        Me.TBDNI.Name = "TBDNI"
        Me.TBDNI.Size = New System.Drawing.Size(76, 20)
        Me.TBDNI.TabIndex = 6
        '
        'TBEMail
        '
        Me.TBEMail.Location = New System.Drawing.Point(187, 60)
        Me.TBEMail.MaxLength = 50
        Me.TBEMail.Name = "TBEMail"
        Me.TBEMail.Size = New System.Drawing.Size(168, 20)
        Me.TBEMail.TabIndex = 5
        '
        'TBUsuario
        '
        Me.TBUsuario.Location = New System.Drawing.Point(7, 22)
        Me.TBUsuario.MaxLength = 25
        Me.TBUsuario.Name = "TBUsuario"
        Me.TBUsuario.Size = New System.Drawing.Size(69, 20)
        Me.TBUsuario.TabIndex = 4
        Me.ToolTip.SetToolTip(Me.TBUsuario, "HOla" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "a")
        '
        'LbDNI
        '
        Me.LbDNI.AutoSize = True
        Me.LbDNI.Location = New System.Drawing.Point(78, 45)
        Me.LbDNI.Name = "LbDNI"
        Me.LbDNI.Size = New System.Drawing.Size(32, 13)
        Me.LbDNI.TabIndex = 3
        Me.LbDNI.Text = "DNI :"
        '
        'LbApellido
        '
        Me.LbApellido.AutoSize = True
        Me.LbApellido.Location = New System.Drawing.Point(184, 7)
        Me.LbApellido.Name = "LbApellido"
        Me.LbApellido.Size = New System.Drawing.Size(50, 13)
        Me.LbApellido.TabIndex = 2
        Me.LbApellido.Text = "Apellido :"
        '
        'LbNombre
        '
        Me.LbNombre.AutoSize = True
        Me.LbNombre.Location = New System.Drawing.Point(78, 7)
        Me.LbNombre.Name = "LbNombre"
        Me.LbNombre.Size = New System.Drawing.Size(50, 13)
        Me.LbNombre.TabIndex = 1
        Me.LbNombre.Text = "Nombre :"
        '
        'LbUsuario
        '
        Me.LbUsuario.AutoSize = True
        Me.LbUsuario.Location = New System.Drawing.Point(4, 7)
        Me.LbUsuario.Name = "LbUsuario"
        Me.LbUsuario.Size = New System.Drawing.Size(49, 13)
        Me.LbUsuario.TabIndex = 0
        Me.LbUsuario.Text = "Usuario :"
        '
        'TPPerfiles
        '
        Me.TPPerfiles.BackColor = System.Drawing.Color.LightSkyBlue
        Me.TPPerfiles.Controls.Add(Me.GBPermisosDisponiblesPerfiles)
        Me.TPPerfiles.Controls.Add(Me.GBPermisosAsignadosPerfiles)
        Me.TPPerfiles.Controls.Add(Me.BTNDesasignarPermiso)
        Me.TPPerfiles.Controls.Add(Me.CBPerfiles)
        Me.TPPerfiles.Controls.Add(Me.BTNAsignarPermiso)
        Me.TPPerfiles.Controls.Add(Me.BTNEliminarPerfil)
        Me.TPPerfiles.Controls.Add(Me.BTNGuardarCambios)
        Me.TPPerfiles.Controls.Add(Me.BTNCrearPerfil)
        Me.TPPerfiles.Controls.Add(Me.LbPerfil)
        Me.TPPerfiles.Location = New System.Drawing.Point(4, 22)
        Me.TPPerfiles.Name = "TPPerfiles"
        Me.TPPerfiles.Padding = New System.Windows.Forms.Padding(3)
        Me.TPPerfiles.Size = New System.Drawing.Size(1047, 341)
        Me.TPPerfiles.TabIndex = 0
        Me.TPPerfiles.Text = "Perfiles"
        '
        'GBPermisosDisponiblesPerfiles
        '
        Me.GBPermisosDisponiblesPerfiles.Controls.Add(Me.DGVPermisosDisponiblesPerfil)
        Me.GBPermisosDisponiblesPerfiles.Location = New System.Drawing.Point(412, 48)
        Me.GBPermisosDisponiblesPerfiles.Name = "GBPermisosDisponiblesPerfiles"
        Me.GBPermisosDisponiblesPerfiles.Size = New System.Drawing.Size(358, 227)
        Me.GBPermisosDisponiblesPerfiles.TabIndex = 17
        Me.GBPermisosDisponiblesPerfiles.TabStop = False
        Me.GBPermisosDisponiblesPerfiles.Text = "Permisos Disponibles"
        '
        'DGVPermisosDisponiblesPerfil
        '
        Me.DGVPermisosDisponiblesPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPermisosDisponiblesPerfil.Location = New System.Drawing.Point(5, 19)
        Me.DGVPermisosDisponiblesPerfil.Name = "DGVPermisosDisponiblesPerfil"
        Me.DGVPermisosDisponiblesPerfil.ReadOnly = True
        Me.DGVPermisosDisponiblesPerfil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPermisosDisponiblesPerfil.Size = New System.Drawing.Size(346, 202)
        Me.DGVPermisosDisponiblesPerfil.TabIndex = 14
        '
        'GBPermisosAsignadosPerfiles
        '
        Me.GBPermisosAsignadosPerfiles.Controls.Add(Me.DGVPermisosAsignadosPerfil)
        Me.GBPermisosAsignadosPerfiles.Location = New System.Drawing.Point(6, 48)
        Me.GBPermisosAsignadosPerfiles.Name = "GBPermisosAsignadosPerfiles"
        Me.GBPermisosAsignadosPerfiles.Size = New System.Drawing.Size(357, 227)
        Me.GBPermisosAsignadosPerfiles.TabIndex = 16
        Me.GBPermisosAsignadosPerfiles.TabStop = False
        Me.GBPermisosAsignadosPerfiles.Text = "Permisos Asignados"
        '
        'DGVPermisosAsignadosPerfil
        '
        Me.DGVPermisosAsignadosPerfil.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVPermisosAsignadosPerfil.Location = New System.Drawing.Point(5, 19)
        Me.DGVPermisosAsignadosPerfil.MultiSelect = False
        Me.DGVPermisosAsignadosPerfil.Name = "DGVPermisosAsignadosPerfil"
        Me.DGVPermisosAsignadosPerfil.ReadOnly = True
        Me.DGVPermisosAsignadosPerfil.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVPermisosAsignadosPerfil.Size = New System.Drawing.Size(346, 202)
        Me.DGVPermisosAsignadosPerfil.TabIndex = 15
        '
        'BTNDesasignarPermiso
        '
        Me.BTNDesasignarPermiso.Location = New System.Drawing.Point(369, 168)
        Me.BTNDesasignarPermiso.Name = "BTNDesasignarPermiso"
        Me.BTNDesasignarPermiso.Size = New System.Drawing.Size(37, 45)
        Me.BTNDesasignarPermiso.TabIndex = 12
        Me.BTNDesasignarPermiso.Text = ">>"
        Me.BTNDesasignarPermiso.UseVisualStyleBackColor = True
        '
        'CBPerfiles
        '
        Me.CBPerfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBPerfiles.FormattingEnabled = True
        Me.CBPerfiles.Location = New System.Drawing.Point(10, 19)
        Me.CBPerfiles.Name = "CBPerfiles"
        Me.CBPerfiles.Size = New System.Drawing.Size(269, 21)
        Me.CBPerfiles.TabIndex = 9
        '
        'BTNAsignarPermiso
        '
        Me.BTNAsignarPermiso.Location = New System.Drawing.Point(369, 119)
        Me.BTNAsignarPermiso.Name = "BTNAsignarPermiso"
        Me.BTNAsignarPermiso.Size = New System.Drawing.Size(37, 45)
        Me.BTNAsignarPermiso.TabIndex = 8
        Me.BTNAsignarPermiso.Text = "<<"
        Me.BTNAsignarPermiso.UseVisualStyleBackColor = True
        '
        'BTNEliminarPerfil
        '
        Me.BTNEliminarPerfil.Location = New System.Drawing.Point(507, 18)
        Me.BTNEliminarPerfil.Name = "BTNEliminarPerfil"
        Me.BTNEliminarPerfil.Size = New System.Drawing.Size(100, 23)
        Me.BTNEliminarPerfil.TabIndex = 7
        Me.BTNEliminarPerfil.Text = "Eliminar Perfil"
        Me.BTNEliminarPerfil.UseVisualStyleBackColor = True
        '
        'BTNGuardarCambios
        '
        Me.BTNGuardarCambios.Location = New System.Drawing.Point(395, 18)
        Me.BTNGuardarCambios.Name = "BTNGuardarCambios"
        Me.BTNGuardarCambios.Size = New System.Drawing.Size(100, 23)
        Me.BTNGuardarCambios.TabIndex = 6
        Me.BTNGuardarCambios.Text = "Guardar Cambios"
        Me.BTNGuardarCambios.UseVisualStyleBackColor = True
        '
        'BTNCrearPerfil
        '
        Me.BTNCrearPerfil.BackColor = System.Drawing.SystemColors.Control
        Me.BTNCrearPerfil.Location = New System.Drawing.Point(289, 18)
        Me.BTNCrearPerfil.Name = "BTNCrearPerfil"
        Me.BTNCrearPerfil.Size = New System.Drawing.Size(100, 23)
        Me.BTNCrearPerfil.TabIndex = 3
        Me.BTNCrearPerfil.Text = "Crear Perfil"
        Me.BTNCrearPerfil.UseVisualStyleBackColor = False
        '
        'LbPerfil
        '
        Me.LbPerfil.AutoSize = True
        Me.LbPerfil.Location = New System.Drawing.Point(7, 4)
        Me.LbPerfil.Name = "LbPerfil"
        Me.LbPerfil.Size = New System.Drawing.Size(30, 13)
        Me.LbPerfil.TabIndex = 0
        Me.LbPerfil.Text = "Perfil"
        '
        'BTNSalir
        '
        Me.BTNSalir.Location = New System.Drawing.Point(983, 385)
        Me.BTNSalir.Name = "BTNSalir"
        Me.BTNSalir.Size = New System.Drawing.Size(75, 22)
        Me.BTNSalir.TabIndex = 5
        Me.BTNSalir.Text = "Salir"
        Me.BTNSalir.UseVisualStyleBackColor = True
        '
        'FormAdmPerfilesUsuarios
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.BackColor = System.Drawing.SystemColors.MenuHighlight
        Me.ClientSize = New System.Drawing.Size(1074, 416)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.BTNSalir)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "FormAdmPerfilesUsuarios"
        Me.Text = "Administración de Perfiles de Usuarios"
        Me.TabControl1.ResumeLayout(False)
        Me.TPUsuarios.ResumeLayout(False)
        Me.TPUsuarios.PerformLayout()
        Me.GPPermisosDisponiblesUsuarios.ResumeLayout(False)
        CType(Me.DGVPermisosDisponiblesUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBResultados.ResumeLayout(False)
        CType(Me.DGVUsuarios, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GPPermisosAsignadosUsuarios.ResumeLayout(False)
        CType(Me.DGVPermisosAsignadosUsuario, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TPPerfiles.ResumeLayout(False)
        Me.TPPerfiles.PerformLayout()
        Me.GBPermisosDisponiblesPerfiles.ResumeLayout(False)
        CType(Me.DGVPermisosDisponiblesPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GBPermisosAsignadosPerfiles.ResumeLayout(False)
        CType(Me.DGVPermisosAsignadosPerfil, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TPPerfiles As System.Windows.Forms.TabPage
    Friend WithEvents TPUsuarios As System.Windows.Forms.TabPage
    Friend WithEvents TBNombre As System.Windows.Forms.TextBox
    Friend WithEvents TBApellido As System.Windows.Forms.TextBox
    Friend WithEvents TBDNI As System.Windows.Forms.TextBox
    Friend WithEvents TBEMail As System.Windows.Forms.TextBox
    Friend WithEvents TBUsuario As System.Windows.Forms.TextBox
    Friend WithEvents LbDNI As System.Windows.Forms.Label
    Friend WithEvents LbApellido As System.Windows.Forms.Label
    Friend WithEvents LbNombre As System.Windows.Forms.Label
    Friend WithEvents LbUsuario As System.Windows.Forms.Label
    Friend WithEvents LbEmail As System.Windows.Forms.Label
    Friend WithEvents BTNBuscar As System.Windows.Forms.Button
    Friend WithEvents GPPermisosDisponiblesUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents GBResultados As System.Windows.Forms.GroupBox
    Friend WithEvents GPPermisosAsignadosUsuarios As System.Windows.Forms.GroupBox
    Friend WithEvents BTNAsignar As System.Windows.Forms.Button
    Friend WithEvents BTNCrearUsuario As System.Windows.Forms.Button
    Friend WithEvents BTNDesasignar As System.Windows.Forms.Button
    Friend WithEvents DGVPermisosDisponiblesUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents DGVUsuarios As System.Windows.Forms.DataGridView
    Friend WithEvents DGVPermisosAsignadosUsuario As System.Windows.Forms.DataGridView
    Friend WithEvents CBPerfiles As System.Windows.Forms.ComboBox
    Friend WithEvents BTNAsignarPermiso As System.Windows.Forms.Button
    Friend WithEvents BTNEliminarPerfil As System.Windows.Forms.Button
    Friend WithEvents BTNGuardarCambios As System.Windows.Forms.Button
    Friend WithEvents BTNCrearPerfil As System.Windows.Forms.Button
    Friend WithEvents LbPerfil As System.Windows.Forms.Label
    Friend WithEvents BTNSalir As System.Windows.Forms.Button
    Friend WithEvents BTNDesasignarPermiso As System.Windows.Forms.Button
    Friend WithEvents DGVPermisosDisponiblesPerfil As System.Windows.Forms.DataGridView
    Friend WithEvents GBPermisosAsignadosPerfiles As System.Windows.Forms.GroupBox
    Friend WithEvents GBPermisosDisponiblesPerfiles As System.Windows.Forms.GroupBox
    Friend WithEvents BTNModificar As System.Windows.Forms.Button
    Friend WithEvents BTNEliminar As System.Windows.Forms.Button
    Friend WithEvents DGVPermisosAsignadosPerfil As System.Windows.Forms.DataGridView
    Friend WithEvents BTNBitacora As System.Windows.Forms.Button
    Friend WithEvents BTNDesbloquear As Button
    Friend WithEvents BTNCambiarContraseña As Button
    Friend WithEvents ToolTip As ToolTip
End Class
