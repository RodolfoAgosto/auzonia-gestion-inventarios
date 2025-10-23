Imports System.Windows.Forms
Imports SEGURIDAD
Imports BLL_TECNICA
Imports INTERFACES
Imports BE

Public Class MDIPrincipal

    Implements IObservadores

    Dim WithEvents vFormAdmPerfilesUsuarios As FormAdmPerfilesUsuarios
    Dim WithEvents vFormNuevoPerfil As FormNuevoPerfil
    Dim WithEvents vFormIniciarSesion As FormIniciarSesion
    Dim WithEvents vFormBackUp As FormBackUp
    Dim WithEvents vFormRestore As FormRestore
    Dim WithEvents vFormIdioma As FormIdioma
    Dim WithEvents vFormCambiarIdioma As FormCambiarIdioma
    Dim WithEvents vFormBitacora As FormBitacora
    Dim WithEvents vFormProveedores As FormProveedores
    Dim WithEvents vFormArticulo As FormArticulo
    Dim WithEvents vFormCliente As FormCliente
    Dim WithEvents vFormPedidoDeCliente As FormPedidoDeCliente
    Dim WithEvents vFormNotaDePedido As FormNotaDePedido
    Dim WithEvents vFormRemitoProveedor As FormRemitoProveedor
    Dim WithEvents vFormNotaDeEnvio As FormNotaDeEnvio
    Dim WithEvents vFormAyuda As FormAyuda
    Dim WithEvents vFormListaDePrecios As FormListaDePrecios
    Dim WithEvents vFormValuacion As FormValuacion
    Dim WithEvents vFormInformesMovimientos As FormInformesMovimientos
    Dim WithEvents vFormMovimientosSalidaPorFecha As FormInformeMovimientosSalidaPorFecha
    Dim WithEvents vFormAcerca As FormAcerca

    Dim vListaDeFormularios As New List(Of Form)

    Private _observadores As New List(Of INTERFACES.IObservadores)

    Dim vSesion As Sesion_SEG
    Dim vSesionTEC As Sesion_TEC
    Dim vListaDeTraducciones As New List(Of Traduccion)
    Dim vSesionIniciada As Boolean = False

    Private _IdiomaActual As Idioma
    Public Property IdiomaActual() As Idioma
        Get
            Return _IdiomaActual
        End Get
        Set(ByVal value As Idioma)
            _IdiomaActual = value
            Me.ActualizarIdioma(value)
        End Set
    End Property

    Public Sub Agregar(ByVal pObservador As IObservadores)
        pObservador.Idioma = Me.IdiomaActual
        pObservador.Actualizar(Me.IdiomaActual)
        _observadores.Add(pObservador)
    End Sub

    Public Sub Quitar(ByVal pObservador As IObservadores)
        _observadores.Remove(pObservador)
    End Sub

    Public Sub ActualizarIdioma(ByVal pIdiomaActual As Idioma)
        If Not _observadores Is Nothing Then
            For Each vobservadores As IObservadores In _observadores
                vobservadores.Actualizar(pIdiomaActual)
            Next
        End If
    End Sub

    Private Sub TSMIPerfilesUsuarios_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsmiPermisos.Click
        If vFormAdmPerfilesUsuarios Is Nothing Then
            vFormAdmPerfilesUsuarios = New FormAdmPerfilesUsuarios
            vFormAdmPerfilesUsuarios.MdiParent = Me
        End If
        vFormAdmPerfilesUsuarios.LayoutMdi(MdiLayout.TileVertical)
        vListaDeFormularios.Add(vFormAdmPerfilesUsuarios)
        Me.Agregar(vFormAdmPerfilesUsuarios)
        vFormAdmPerfilesUsuarios.Show()
    End Sub

    Private m_ChildFormNumber As Integer

    Private Sub vFormAdmPerfilesUsuarios_CerrarForm() Handles vFormAdmPerfilesUsuarios.Closed
        Me.Quitar(vFormAdmPerfilesUsuarios)
        If vFormAdmPerfilesUsuarios.CerrarAplicacion Then
            Me.Close()
        End If
        vFormAdmPerfilesUsuarios = Nothing
    End Sub

    Private Sub tsmiIniciarSesion_Click(sender As Object, e As EventArgs) Handles tsmiIniciarSesion.Click
        If Not vSesionIniciada Then
            If vFormIniciarSesion Is Nothing Then
                vFormIniciarSesion = New FormIniciarSesion
                vFormIniciarSesion.MdiParent = Me
            End If
            Me.Agregar(vFormIniciarSesion)
            vFormIniciarSesion.Show()
        Else
            DesHabilitarPermisos()
            For Each vF As Form In vListaDeFormularios
                If Not vF Is Nothing Then
                    vF.Close()
                End If
            Next
            vSesionIniciada = False
            Dim vBitacora As New Bitacora
            vBitacora.CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
            vBitacora.CodigoBitacora = "0005"
            vBitacora.Informacion = "El usuario " + Sesion_SEG.SesionActual.UsuarioSEG.Codigo + " cerró sesión."
            vBitacora.TiporDeObjeto = "Sesion"
            vBitacora.IdentificadorDeObjeto = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
            Dim vBitacoraTEC As New Bitacora_TEC
            vBitacoraTEC.RegistrarEnBitacora(vBitacora)
            ActualizarIdioma(IdiomaActual)
            tsslUsuario.Text = ""
        End If
    End Sub

    Private Sub vFormIniciarSesion_DatosCorrectos(pCodigoUsuario As String, pContrasena As String) Handles vFormIniciarSesion.DatosCorrectos
        Dim vRespuestaAcceso As SEGURIDAD.RespuestaAcceso
        vRespuestaAcceso = vSesionTEC.IniciarSesion(pCodigoUsuario, pContrasena)
        If vRespuestaAcceso = RespuestaAcceso.UsuarioInexistente Then
            MsgBox("El usuario no se encuentra registrado. Intente nuevamente.")
            If vFormIniciarSesion Is Nothing Then
                vFormIniciarSesion = New FormIniciarSesion
                vFormIniciarSesion.MdiParent = Me
            End If
            vFormIniciarSesion.TBUsuario.Text = ""
            vFormIniciarSesion.TBContraseña.Text = ""
            vFormIniciarSesion.Show()
        ElseIf vRespuestaAcceso = RespuestaAcceso.UsuarioBloqueado Then
            MsgBox("El usuario se encuentra bloqueado. Esta sesión se cerrará. Consulte con el administrador del sistema.")
            Me.Close()
        ElseIf vRespuestaAcceso = RespuestaAcceso.Reintentar Then
            MsgBox("Contraseña incorrecta. Reintente.")
            If vFormIniciarSesion Is Nothing Then
                vFormIniciarSesion = New FormIniciarSesion
                vFormIniciarSesion.MdiParent = Me
            End If
            vFormIniciarSesion.TBUsuario.Text = ""
            vFormIniciarSesion.TBContraseña.Text = ""
            vFormIniciarSesion.Show()
        Else
            Dim vRespuestaIntegridad As Boolean = False
            Dim vGestorIntegridadTEC As New GestorIntegridad_TEC
            vRespuestaIntegridad = vGestorIntegridadTEC.VerificarIntegridad()
            If vRespuestaIntegridad Then
                vSesionIniciada = True
                ActualizarIdioma(Me.IdiomaActual)
                HabilitarPermisos()
                tsslUsuario.Text = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
            Else
                If vSesionTEC.EsValido("Restaurar BD") Then
                    MsgBox("La base de datos ha sido corrompida. Restaure la sesión desde el módulo del Sistema.")
                    vSesionIniciada = True
                    ActualizarIdioma(Me.IdiomaActual)
                    HabilitarPermisos()
                    tsslUsuario.Text = Sesion_SEG.SesionActual.UsuarioSEG.Codigo
                Else
                    MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                    Me.Close()
                End If
            End If
        End If
    End Sub

    Private Sub MDIPrincipal_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        ' De esta forma creo un idioma inical para la carga de traducciones. Quede pendiente persistir la configuracion en la pc local.
        Dim vIdiomaInicio As New Idioma
        vIdiomaInicio.Nombre = "Español"
        vIdiomaInicio.ID = 1037
        Me.IdiomaActual = vIdiomaInicio

        vSesion = Sesion_SEG.SesionActual
        vSesionTEC = New Sesion_TEC
        vSesionTEC.SesionSEG = vSesion
        Me._observadores = New List(Of IObservadores)
        Me.Agregar(Me)

    End Sub

    Public Sub HabilitarPermisos()

        Me.AyudaToolStripMenuItem.Visible = True

        Dim vHabilitado As Boolean = False

        vHabilitado = vSesionTEC.EsValido("Módulo Compras")
        Me.menuItemCompras.Enabled = vHabilitado
        Me.menuItemCompras.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Módulo Ventas")
        Me.menuItemVentas.Enabled = vHabilitado
        Me.menuItemVentas.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Módulo Contabilidad")
        Me.menuItemContabilidad.Enabled = vHabilitado
        Me.menuItemContabilidad.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Módulo Sistema")
        Me.menuItemSistema.Enabled = vHabilitado
        Me.menuItemSistema.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Módulo Informes")
        Me.menuItemInformes.Enabled = vHabilitado
        Me.menuItemInformes.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Proveedores")
        Me.tsmiProveedores.Enabled = vHabilitado
        Me.tsmiProveedores.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Artículos")
        Me.tsmiArticulos.Enabled = vHabilitado
        Me.tsmiArticulos.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Notas de Pedido")
        Me.tsmiNotasDePedido.Enabled = vHabilitado
        Me.tsmiNotasDePedido.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Remitos")
        Me.tsmiRemitos.Enabled = vHabilitado
        Me.tsmiRemitos.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Clientes")
        Me.tsmiClientes.Enabled = vHabilitado
        Me.tsmiClientes.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Pedidos de C.")
        Me.tsmiPedidosDeCliente.Enabled = vHabilitado
        Me.tsmiPedidosDeCliente.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Envíos")
        Me.tsmiEnvios.Enabled = vHabilitado
        Me.tsmiEnvios.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Valorizar Mercadería")
        Me.tsmiValorizarMercaderia.Enabled = vHabilitado
        Me.tsmiValorizarMercaderia.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Lista de Pcios.")
        Me.tsmiListaDePrecios.Enabled = vHabilitado
        Me.tsmiListaDePrecios.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Gestión de Perm")
        Me.tsmiPermisos.Enabled = vHabilitado
        Me.tsmiPermisos.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Generar BackUp")
        Me.tsmiGenerarBackup.Enabled = vHabilitado
        Me.tsmiGenerarBackup.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Restaurar BD")
        Me.tsmiRestaurarBD.Enabled = vHabilitado
        Me.tsmiRestaurarBD.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Verificar Integridad")
        Me.tsmiVerificarIntegridad.Enabled = vHabilitado
        Me.tsmiVerificarIntegridad.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Bitácora de Auditori")
        Me.tsmiBitácoraDeAuditoria.Enabled = vHabilitado
        Me.tsmiBitácoraDeAuditoria.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Arbol de Permisos")
        Me.tsmiÁrbolDePermisos.Enabled = vHabilitado
        Me.tsmiÁrbolDePermisos.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Adm. Idioma")
        Me.tsmiActualizarIdiomas.Enabled = vHabilitado
        Me.tsmiActualizarIdiomas.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Movimientos")
        Me.tsmiMovimientos.Enabled = vHabilitado
        Me.tsmiMovimientos.Visible = vHabilitado

        vHabilitado = vSesionTEC.EsValido("Mov. Salidas Fecha")
        Me.tsmiMovimientosSalidaPorFecha.Enabled = vHabilitado
        Me.tsmiMovimientosSalidaPorFecha.Visible = vHabilitado

    End Sub

    Public Sub DesHabilitarPermisos()

        Me.AyudaToolStripMenuItem.Visible = False

        Me.menuItemVentas.Enabled = False
        Me.menuItemVentas.Visible = False

        Me.menuItemCompras.Enabled = False
        Me.menuItemCompras.Visible = False

        Me.menuItemContabilidad.Enabled = False
        Me.menuItemContabilidad.Visible = False

        Me.menuItemSistema.Enabled = False
        Me.menuItemSistema.Visible = False

        Me.menuItemInformes.Enabled = False
        Me.menuItemInformes.Visible = False

        Me.tsmiActualizarIdiomas.Enabled = False
        Me.tsmiActualizarIdiomas.Visible = False

    End Sub

    Private Sub StripMItemGenerarBackup_Click(sender As Object, e As EventArgs) Handles tsmiGenerarBackup.Click
        If vFormBackUp Is Nothing Then
            vFormBackUp = New FormBackUp
            vFormBackUp.MdiParent = Me
            vListaDeFormularios.Add(vFormBackUp)
            Me.Agregar(vFormBackUp)
        End If
        vFormBackUp.Show()
    End Sub

    Private Sub StripMItemRestaurar_Click(sender As Object, e As EventArgs) Handles tsmiRestaurarBD.Click
        If vFormRestore Is Nothing Then
            vFormRestore = New FormRestore
            vFormRestore.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormRestore)
        Me.Agregar(vFormRestore)
        vFormRestore.Show()
    End Sub

    Private Sub VerificarIntegridadToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiVerificarIntegridad.Click
        Dim vRespuestaIntegridad As Boolean = False
        Dim vGestorIntegridadTEC As New GestorIntegridad_TEC
        vRespuestaIntegridad = vGestorIntegridadTEC.VerificarIntegridad()
        If vRespuestaIntegridad Then
            MsgBox("La base de datos no ha sido corrompida.")
        Else
            If vSesionTEC.EsValido("Restaurar BD") Then
                MsgBox("La base de datos ha sido corrompida. Restaure la sesión desde el módulo del Sistema.")
            Else
                MsgBox("La base de datos ha sido corrompida. Consulte con el administrador del sistema. Esta sesión se cerrará.")
                Me.Close()
            End If
        End If
    End Sub

    Private Sub ContToolSActualizarIdiomas_Click(sender As Object, e As EventArgs) Handles tsmiActualizarIdiomas.Click
        If vFormIdioma Is Nothing Then
            vFormIdioma = New FormIdioma
            vFormIdioma.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormIdioma)
        Me.Agregar(vFormIdioma)
        vFormIdioma.Show()
    End Sub

    Private Sub vFormIdioma_FormClosed(sender As Object, e As FormClosedEventArgs) Handles vFormIdioma.FormClosed
        Me.Quitar(FormIdioma)
        FormIdioma = Nothing
    End Sub

    Private Sub ITSMItemCambiarIdioma_Click(sender As Object, e As EventArgs) Handles ITSMItemCambiarIdioma.Click
        If IsNothing(vFormCambiarIdioma) Then
            vFormCambiarIdioma = New FormCambiarIdioma
            vFormCambiarIdioma.MdiParent = Me
        End If
        Me.Agregar(vFormCambiarIdioma)
        vFormCambiarIdioma.Show()
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar

        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "MDIPrincipal")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next
        menuItemInicio.Text = vDiccionario("MDIMain_menuItemInicio").MensajeTraducido
        menuItemCompras.Text = vDiccionario("MDIMain_menuItemCompras").MensajeTraducido
        menuItemVentas.Text = vDiccionario("MDIMain_menuItemVentas").MensajeTraducido
        menuItemContabilidad.Text = vDiccionario("MDIMain_menuItemContabilidad").MensajeTraducido
        menuItemSistema.Text = vDiccionario("MDIMain_menuItemSistema").MensajeTraducido
        menuItemIdioma.Text = vDiccionario("MDIMain_menuItemIdioma").MensajeTraducido
        menuItemAyuda.Text = vDiccionario("MDIMain_menuItemAyuda").MensajeTraducido
        If Not vSesionIniciada Then
            tsmiIniciarSesion.Text = vDiccionario("tsmiIniciarSesionIniciar").MensajeTraducido
        Else
            tsmiIniciarSesion.Text = vDiccionario("tsmiIniciarSesionCerrar").MensajeTraducido
        End If
        tsmiProveedores.Text = vDiccionario("tsmiProveedores").MensajeTraducido
        tsmiArticulos.Text = vDiccionario("tsmiArticulos").MensajeTraducido
        tsmiNotasDePedido.Text = vDiccionario("tsmiNotasDePedido").MensajeTraducido
        tsmiRemitos.Text = vDiccionario("tsmiRemitos").MensajeTraducido
        tsmiClientes.Text = vDiccionario("tsmiClientes").MensajeTraducido
        tsmiPedidosDeCliente.Text = vDiccionario("tsmiPedidosDeCliente").MensajeTraducido
        tsmiEnvios.Text = vDiccionario("tsmiEnvios").MensajeTraducido
        tsmiValorizarMercaderia.Text = vDiccionario("tsmiValorizarMercaderia").MensajeTraducido
        tsmiListaDePrecios.Text = vDiccionario("tsmiListaDePrecios").MensajeTraducido
        tsmiPermisos.Text = vDiccionario("tsmiPermisos").MensajeTraducido
        tsmiGenerarBackup.Text = vDiccionario("tsmiGenerarBackup").MensajeTraducido
        tsmiRestaurarBD.Text = vDiccionario("tsmiRestaurarBD").MensajeTraducido
        tsmiVerificarIntegridad.Text = vDiccionario("tsmiVerificarIntegridad").MensajeTraducido
        tsmiBitácoraDeAuditoria.Text = vDiccionario("tsmiBitácoraDeAuditoria").MensajeTraducido
        tsmiÁrbolDePermisos.Text = vDiccionario("tsmiÁrbolDePermisos").MensajeTraducido
        tsmiActualizarIdiomas.Text = vDiccionario("tsmiActualizarIdiomas").MensajeTraducido
        ITSMItemCambiarIdioma.Text = vDiccionario("ITSMItemCambiarIdioma").MensajeTraducido
        tsmiMovimientos.Text = vDiccionario("tsmiMovimientos").MensajeTraducido
        tsmiMovimientosSalidaPorFecha.Text = vDiccionario("tsmiMovimientosSalidaPorFecha").MensajeTraducido
        AyudaToolStripMenuItem.Text = vDiccionario("AyudaToolStripMenuItem").MensajeTraducido
        AcercaDeToolStripMenuItem.Text = vDiccionario("AcercaDeToolStripMenuItem").MensajeTraducido

    End Sub

    Private Sub vFormCambiarIdioma_FormClosed(sender As Object, e As FormClosedEventArgs) Handles vFormCambiarIdioma.FormClosed
        Quitar(vFormCambiarIdioma)
        vFormCambiarIdioma = Nothing
    End Sub

    Public Property Idioma As Idioma Implements IObservadores.Idioma

    Private Sub BitacoraDeAuditoriaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiBitácoraDeAuditoria.Click
        If vFormBitacora Is Nothing Then
            vFormBitacora = New FormBitacora
            vFormBitacora.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormBitacora)
        Me.Agregar(vFormBitacora)
        vFormBitacora.Show()
    End Sub

    Private Sub tsmiProveedores_Click(sender As Object, e As EventArgs) Handles tsmiProveedores.Click
        If vFormProveedores Is Nothing Then
            vFormProveedores = New FormProveedores
            vFormProveedores.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormProveedores)
        Me.Agregar(vFormProveedores)
        vFormProveedores.Show()
    End Sub

    Private Sub tsmiArticulos_Click(sender As Object, e As EventArgs) Handles tsmiArticulos.Click
        If vFormArticulo Is Nothing Then
            vFormArticulo = New FormArticulo
            vFormArticulo.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormArticulo)
        Me.Agregar(vFormArticulo)
        vFormArticulo.Show()
    End Sub

    Private Sub tbtsmiClientes_Click(sender As Object, e As EventArgs) Handles tsmiClientes.Click
        If vFormCliente Is Nothing Then
            vFormCliente = New FormCliente
            vFormCliente.MdiParent = Me
            vListaDeFormularios.Add(vFormCliente)
            Me.Agregar(vFormCliente)
        End If
        vFormCliente.Show()
    End Sub


    Private Sub sbtsmiPedidosDeCliente_Click(sender As Object, e As EventArgs) Handles tsmiPedidosDeCliente.Click
        If vFormPedidoDeCliente Is Nothing Then
            vFormPedidoDeCliente = New FormPedidoDeCliente
            vFormPedidoDeCliente.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormPedidoDeCliente)
        Me.Agregar(vFormPedidoDeCliente)
        vFormPedidoDeCliente.Show()
    End Sub

    Private Sub NotasDePedidoToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiNotasDePedido.Click
        If vFormNotaDePedido Is Nothing Then
            vFormNotaDePedido = New FormNotaDePedido
            vFormNotaDePedido.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormNotaDePedido)
        Me.Agregar(vFormNotaDePedido)
        vFormNotaDePedido.Show()

    End Sub

    Private Sub RemitosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiRemitos.Click
        If vFormRemitoProveedor Is Nothing Then
            vFormRemitoProveedor = New FormRemitoProveedor
            vFormRemitoProveedor.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormRemitoProveedor)
        Me.Agregar(vFormRemitoProveedor)
        vFormRemitoProveedor.Show()
    End Sub

    Private Sub EnvioToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiEnvios.Click
        If vFormNotaDeEnvio Is Nothing Then
            vFormNotaDeEnvio = New FormNotaDeEnvio
            vFormNotaDeEnvio.MdiParent = Me
            vListaDeFormularios.Add(vFormNotaDeEnvio)
            Me.Agregar(vFormNotaDeEnvio)
        End If
        vFormNotaDeEnvio.Show()
    End Sub


    Private Sub AyudaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AyudaToolStripMenuItem.Click
        If vFormAyuda Is Nothing Then
            vFormAyuda = New FormAyuda
            vFormAyuda.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormAyuda)
        Me.Agregar(vFormAyuda)
        vFormAyuda.Show()
    End Sub

    Private Sub ListaDePreciosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiListaDePrecios.Click
        If vFormListaDePrecios Is Nothing Then
            vFormListaDePrecios = New FormListaDePrecios
            vFormListaDePrecios.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormListaDePrecios)
        Me.Agregar(vFormListaDePrecios)
        vFormListaDePrecios.Show()
    End Sub

    Private Sub OptionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiValorizarMercaderia.Click
        If vFormValuacion Is Nothing Then
            vFormValuacion = New FormValuacion
            vFormValuacion.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormValuacion)
        Me.Agregar(vFormValuacion)
        vFormValuacion.Show()
    End Sub

    Private Sub MovimientosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiMovimientos.Click
        If vFormInformesMovimientos Is Nothing Then
            vFormInformesMovimientos = New FormInformesMovimientos
            vFormInformesMovimientos.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormInformesMovimientos)
        Me.Agregar(vFormInformesMovimientos)
        vFormInformesMovimientos.Show()
    End Sub

    Private Sub FormMovimientosSalidaPorFechaToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiMovimientosSalidaPorFecha.Click

        If vFormMovimientosSalidaPorFecha Is Nothing Then
            vFormMovimientosSalidaPorFecha = New FormInformeMovimientosSalidaPorFecha
            vFormMovimientosSalidaPorFecha.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormMovimientosSalidaPorFecha)
        Me.Agregar(vFormMovimientosSalidaPorFecha)
        vFormMovimientosSalidaPorFecha.Show()

    End Sub

    Dim WithEvents vFormArbolDePermisos As FormArbolDePermisos

    Private Sub ArbolDePermisosToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles tsmiÁrbolDePermisos.Click
        If vFormArbolDePermisos Is Nothing Then
            vFormArbolDePermisos = New FormArbolDePermisos
            vFormArbolDePermisos.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormArbolDePermisos)
        Me.Agregar(vFormArbolDePermisos)
        vFormArbolDePermisos.Show()
    End Sub

    Private Sub AcercaDeToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AcercaDeToolStripMenuItem.Click
        If vFormAcerca Is Nothing Then
            vFormAcerca = New FormAcerca
            vFormAcerca.MdiParent = Me
        End If
        vListaDeFormularios.Add(vFormAcerca)
        Me.Agregar(vFormAcerca)
        vFormAcerca.Actualizar(Idioma)
        vFormAcerca.Show()
    End Sub

    Private Sub vFormArbolDePermisos_Closed(sender As Object, e As EventArgs) Handles vFormArbolDePermisos.Closed
        Me.Quitar(vFormArbolDePermisos)
        vFormArbolDePermisos = Nothing
    End Sub

    Private Sub vFormArticulo_Closed(sender As Object, e As EventArgs) Handles vFormArticulo.Closed
        Me.Quitar(vFormArticulo)
        vFormArticulo = Nothing
    End Sub

    Private Sub vFormAyuda_Closed(sender As Object, e As EventArgs) Handles vFormAyuda.Closed
        Me.Quitar(vFormAyuda)
        vFormAyuda = Nothing
    End Sub

    Private Sub vFormBackUp_Closed(sender As Object, e As EventArgs) Handles vFormBackUp.Closed
        Me.Quitar(vFormBackUp)
        vFormBackUp = Nothing
    End Sub

    Private Sub vFormBitacora_Closed(sender As Object, e As EventArgs) Handles vFormBitacora.Closed
        Me.Quitar(vFormBitacora)
        vFormBitacora = Nothing
    End Sub

    Private Sub vFormCliente_Closed(sender As Object, e As EventArgs) Handles vFormCliente.Closed
        Me.Quitar(vFormCliente)
        vFormCliente = Nothing
    End Sub

    Private Sub vFormMovimientosSalidaPorFecha_Closed(sender As Object, e As EventArgs) Handles vFormMovimientosSalidaPorFecha.Closed
        Me.Quitar(vFormMovimientosSalidaPorFecha)
        vFormMovimientosSalidaPorFecha = Nothing
    End Sub

    Private Sub vFormInformesMovimientos_Closed(sender As Object, e As EventArgs) Handles vFormInformesMovimientos.Closed
        Me.Quitar(vFormInformesMovimientos)
        vFormInformesMovimientos = Nothing
    End Sub

    Private Sub vFormIniciarSesion_Closed(sender As Object, e As EventArgs) Handles vFormIniciarSesion.Closed
        Me.Quitar(vFormIniciarSesion)
        vFormIniciarSesion = Nothing
    End Sub

    Private Sub vFormListaDePrecios_Closed(sender As Object, e As EventArgs) Handles vFormListaDePrecios.Closed
        Me.Quitar(vFormListaDePrecios)
        vFormListaDePrecios = Nothing
    End Sub

    Private Sub vFormNotaDePedido_Closed(sender As Object, e As EventArgs) Handles vFormNotaDePedido.Closed
        Me.Quitar(vFormNotaDePedido)
        vFormNotaDePedido = Nothing
    End Sub

    Private Sub vFormValuacion_Closed(sender As Object, e As EventArgs) Handles vFormValuacion.Closed
        Me.Quitar(vFormValuacion)
        vFormValuacion = Nothing
    End Sub

    Private Sub vFormPedidoDeCliente_Closed(sender As Object, e As EventArgs) Handles vFormPedidoDeCliente.Closed
        Me.Quitar(vFormPedidoDeCliente)
        vFormPedidoDeCliente = Nothing
    End Sub

    Private Sub vFormRestore_Closed(sender As Object, e As EventArgs) Handles vFormRestore.Closed
        Me.Quitar(vFormRestore)
        vFormRestore = Nothing
    End Sub

    Private Sub vFormIdioma_Closed(sender As Object, e As EventArgs) Handles vFormIdioma.Closed
        Me.Quitar(vFormIdioma)
        vFormIdioma = Nothing
    End Sub

    Private Sub vFormProveedores_Closed(sender As Object, e As EventArgs) Handles vFormProveedores.Closed
        Me.Quitar(vFormProveedores)
        vFormProveedores = Nothing
    End Sub

    Private Sub vFormRemitoProveedor_Closed(sender As Object, e As EventArgs) Handles vFormRemitoProveedor.Closed
        Me.Quitar(vFormRemitoProveedor)
        vFormRemitoProveedor = Nothing
    End Sub

    Private Sub vFormNotaDeEnvio_Closed(sender As Object, e As EventArgs) Handles vFormNotaDeEnvio.Closed
        Me.Quitar(vFormNotaDeEnvio)
        vFormNotaDeEnvio = Nothing
    End Sub

    Private Sub vFormAcerca_Closed(sender As Object, e As EventArgs) Handles vFormAcerca.Closed
        Me.Quitar(vFormAcerca)
        vFormAcerca = Nothing
    End Sub

    Private Sub MenuStrip_ControlAdded(sender As Object, e As ControlEventArgs) Handles MenuStrip.ControlAdded
        e.Control.Height = 22
        e.Control.Width = 22

    End Sub

    Private Sub MenuStrip_ItemAdded(sender As Object, e As ToolStripItemEventArgs) Handles MenuStrip.ItemAdded

        e.Item.ImageScaling = ToolStripItemImageScaling.SizeToFit
        If e.Item.Image Is Nothing Then
            e.Item.Visible = False
        End If

    End Sub
End Class

