Imports BLL_TECNICA
Imports SEGURIDAD
Imports INTERFACES
Imports BE

Public Class FormArbolDePermisos
    Implements IObservadores
    Dim vListaDeTraducciones As New List(Of Traduccion)

    Private _Idioma As Idioma
    Public Property Idioma As Idioma Implements IObservadores.Idioma
        Get
            Return _Idioma
        End Get
        Set(ByVal value As Idioma)
            _Idioma = value
        End Set

    End Property

    Private Sub FormArbolDePermisos_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ActualizarTreeView()
        Actualizar(Me.Idioma)
    End Sub

    Public Sub Actualizar(pIdioma As Idioma) Implements IObservadores.Actualizar
        vListaDeTraducciones.Clear()
        Dim vTraduccionTEC As New Traduccion_TEC
        vListaDeTraducciones = vTraduccionTEC.ListarTraducciones(pIdioma, "FormArbolDePermisos")
        Dim vDiccionario As New Dictionary(Of String, BE.Traduccion)
        For Each vTraduccion As Traduccion In vListaDeTraducciones
            vDiccionario.Add(vTraduccion.Codigo, vTraduccion)
        Next

        Me.Text = vDiccionario("FormArbolDePermisos").MensajeTraducido
        Me.BTNActualizar.Text = vDiccionario("BTNActualizar").MensajeTraducido
        Me.BTNSalir.Text = vDiccionario("BTNSalir").MensajeTraducido

    End Sub

    Private Sub BTNSalir_Click(sender As Object, e As EventArgs) Handles BTNSalir.Click
        Me.Close()
    End Sub

    Private Sub BTNActualizar_Click(sender As Object, e As EventArgs) Handles BTNActualizar.Click
        ActualizarTreeView()
    End Sub

    Private Sub ActualizarTreeView()
        Dim vPermisoTEC As New GestorPermisos_TEC
        Dim vListaDePermisos As List(Of Permiso_SEG)
        vListaDePermisos = vPermisoTEC.ConsultaTodos
        TreeViewPermisos.Nodes.Clear()
        For Each vPermiso As Permiso_SEG In vListaDePermisos
            Dim vNode As New TreeNode
            CargarTreeView(TreeViewPermisos, vNode, vPermiso)
        Next
    End Sub

    Private Sub CargarTreeView(ByRef pTreeView As TreeView, ByRef pTreeNode As TreeNode, ByVal pPermiso As Permiso_SEG)
        Dim vTexto As String = String.Format("{0} - {1}", pPermiso.Codigo, pPermiso.Nombre)
        Dim vNodo As TreeNode = New TreeNode(vTexto)
        If pTreeNode.Text = String.Empty Then
            pTreeView.Nodes.Add(vNodo)
        Else
            pTreeNode.Nodes.Add(vNodo)
        End If
        Dim vListaPermisos As List(Of Permiso_SEG) = pPermiso.ListarHijos
        If Not vListaPermisos Is Nothing Then
            For Each vPermiso In vListaPermisos
                CargarTreeView(pTreeView, vNodo, vPermiso)
            Next
        End If
    End Sub

    Private Sub TreeViewPermisos_MouseHover(sender As Object, e As EventArgs) Handles TreeViewPermisos.MouseHover

        ToolTip.SetToolTip(TreeViewPermisos, "Presione Actualizar para refrescar el árbol.")
        ToolTip.ToolTipTitle = "Árbol de Permisos"
        ToolTip.ToolTipIcon = ToolTipIcon.Info

    End Sub

End Class