Public Class Familia_SEG
    
    Inherits Permiso_SEG

    Private _EstadoInicial As Familia_SEG
    Private Property EstadoInicial() As Familia_SEG
        Get
            Return _EstadoInicial
        End Get
        Set(ByVal value As Familia_SEG)
            _EstadoInicial = value
        End Set
    End Property

    Private _ListaHijos As List(Of Permiso_SEG)
    Public Property ListaHijos() As List(Of Permiso_SEG)
        Get
            Return _ListaHijos
        End Get
        Set(ByVal value As List(Of Permiso_SEG))
            _ListaHijos = value
        End Set
    End Property

    Public Overrides Sub AgregarHijo(ByRef pNuevoHijo As Permiso_SEG)
        If Not PermisoAsignado(pNuevoHijo) Then
            Me.ListaHijos.Add(pNuevoHijo)
        End If
    End Sub

    Public Overrides Function EsValido(pNombre As String) As Boolean
        Dim vEsValido As Boolean = False
        For Each vPermiso As Permiso_SEG In Me.ListaHijos
            If vPermiso.EsValido(pNombre) Then
                vEsValido = True
            End If
        Next
        If pNombre = Me.Nombre Then
            vEsValido = True
        End If
        Return vEsValido
    End Function

    Public Overrides Function ListarHijos() As List(Of Permiso_SEG)
        Return Me.ListaHijos
    End Function

    Public Overrides Sub QuitarHijo(ByRef pHijoAQuitar As Permiso_SEG)
        Me.ListaHijos.Remove(pHijoAQuitar)
    End Sub

    Public Overrides Function TieneHijos() As Boolean
        If Not IsNothing(Me.ListaHijos) Then
            If Me.ListaHijos.Count > 0 Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
        
    End Function

    Sub New()

    End Sub

    Sub New(ByVal pCodigo As String, ByVal pNombre As String)
        Me.Codigo = pCodigo
        Me.Nombre = pNombre
        Me.EsPerfil = True
    End Sub

    Public Function PermisoAsignado(ByVal vPermiso As Permiso_SEG) As Boolean
        Dim resultado As Boolean = False
        If vPermiso.Codigo = Me.Codigo Then
            resultado = True
        End If
        If Not Me.ListaHijos Is Nothing Then
            For Each vHijo As Permiso_SEG In Me.ListaHijos
                If vPermiso.Codigo = vHijo.Codigo Then
                    resultado = True
                End If
            Next
        End If
        Return resultado
    End Function

    Public Overrides Function Clone() As Object
        Dim vFamiliaClone As New Familia_SEG With {
            .Codigo = Me.Codigo,
            .EsPerfil = True,
            .Nombre = Me.Nombre,
            .ListaHijos = New List(Of Permiso_SEG)
        }

        If Me.TieneHijos Then
            For Each vPermiso As Permiso_SEG In Me.ListaHijos
                Dim vNuevoPermiso As Permiso_SEG = vPermiso.Clone
                vFamiliaClone.ListaHijos.Add(vNuevoPermiso)
            Next
        End If

        Return vFamiliaClone
    End Function

    Public Sub SetState()
        EstadoInicial = Me.Clone
    End Sub

    Public Sub RestartState()
        If Not IsNothing(EstadoInicial) Then
            Me.Codigo = EstadoInicial.Codigo
            Me.EsPerfil = True
            Me.Nombre = EstadoInicial.Nombre
            Me.ListaHijos = EstadoInicial.ListaHijos
            EstadoInicial = Nothing
        End If
    End Sub

End Class
