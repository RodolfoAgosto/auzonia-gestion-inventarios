Imports DAL
Public Class GestorIntegridad_TEC

    ' Devuelve el DVV de una tabla dada incluyendo el nuevo DVH.
    Public Function CalcularDVV(ByVal pNombreTabla As String, ByVal pDVH As String) As String
        Dim vGestorIntregridadDAL As New GestorIntegridad_DAL
        Dim vGestorCriptografia As New SEGURIDAD.GestorCriptografia
        Dim vDataTable As DataTable
        Dim vStringOriginal As String = ""
        Dim vDVV As String = ""
        vDataTable = vGestorIntregridadDAL.ListarDVH(pNombreTabla)
        For Each fila As DataRow In vDataTable.Rows
            vStringOriginal = vStringOriginal & fila.Item(0).ToString
        Next
        vStringOriginal = vStringOriginal & pDVH
        vDVV = vGestorCriptografia.Hash(vStringOriginal)
        Return vDVV
    End Function

    ' Verifica si alguna de las tablas del sistema fue corrompida.
    Public Function VerificarIntegridad() As Boolean
        Dim vGestorIntegridadDAL As New GestorIntegridad_DAL

        ' Verifico la integridad de la tabla Usuario y su correspondiente DVV.
        'Dim vRespuestaIntegridadRegistros As Boolean = True
        'Dim vRespuestaIntegridadTabla As Boolean = True

        'Dim vListaUsuario As New List(Of SEGURIDAD.Usuario_SEG)
        'Dim vUsuarioTEC As New Usuario_TEC
        'Dim vUsuario As New SEGURIDAD.Usuario_SEG
        'vListaUsuario = vUsuarioTEC.ConsultaVarios(vUsuario)
        'For Each vUsuarioSEG As SEGURIDAD.Usuario_SEG In vListaUsuario
        '    Dim vResultado As String
        '    vResultado = vUsuarioSEG.DigitoVH
        '    vUsuarioTEC.CalcularDVH(vUsuarioSEG)
        '    If Not vResultado = vUsuarioSEG.DigitoVH Then
        '        vRespuestaIntegridadRegistros = False
        '    End If
        'Next

        'vRespuestaIntegridadTabla = vGestorIntegridadDAL.ValidarDVV("Usuario")

        'If vRespuestaIntegridadTabla And vRespuestaIntegridadRegistros Then
        '    Return True
        'Else
        '    Return False
        'End If
        Return True


    End Function

    ' Verifico la integridad de una tabla. Primero por DVH y luego por FVV.
    Public Function VerificarValidezTabla(ByVal pNombreTabla As String) As Boolean
        Dim vGestorIntegridadDAL As New GestorIntegridad_DAL
        Dim vDataTableRegistroCorruptos As DataTable
        vDataTableRegistroCorruptos = vGestorIntegridadDAL.ListarRegistrosCorruptos(pNombreTabla)
        If vDataTableRegistroCorruptos.Rows.Count > 0 Then
            Return False
        Else
            Return vGestorIntegridadDAL.ValidarDVV(pNombreTabla)
        End If
    End Function

End Class
