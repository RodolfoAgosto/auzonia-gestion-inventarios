Imports SEGURIDAD
Imports BE

Public Class NotaDeEnvio_DAL

    Implements INTERFACES.Iabmc(Of NotaDeEnvio)

    Public Sub Alta(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Alta
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@NotEnv_FechaDeEntrega", SqlDbType.Date, pObjeto.FechaDeEntrega),
                                      New DatosParametros("@NotEnv_Comentarios", SqlDbType.VarChar, pObjeto.Comentarios),
                                      New DatosParametros("@NotEnv_ID_Vendedor", SqlDbType.Int, pObjeto.IDVendedor)
                                      })
            pObjeto.ID = Comando.EjecucionScalar("AltaNotaDeEnvio", vListaParametros)
            Dim vArticuloDAL As New Articulo_DAL
            For Each vANE As ArticuloNotaDeEnvio In pObjeto.ListaDeArticuloDeEnvio
                vArticuloDAL.Alta(vANE, pObjeto)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Consulta
        Dim vListaDeNotaDeEnvio As List(Of NotaDeEnvio)
        vListaDeNotaDeEnvio = Me.ConsultaVarios(pObjeto)
        If Not vListaDeNotaDeEnvio Is Nothing Then
            If vListaDeNotaDeEnvio.Count > 0 Then
                pObjeto = vListaDeNotaDeEnvio.Item(0)
                Dim vArticuloDAL As New Articulo_DAL
                vArticuloDAL.ConsultaVarios(pObjeto)
            End If
        End If
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As NotaDeEnvio, ByRef pObjeto2 As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaVarios

        Dim vListaNotaDeEnvio As New List(Of NotaDeEnvio)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@NotEnv_ID", SqlDbType.Int, pObjeto.ID), _
                                      New DatosParametros("@NotEnv_FechaDeCreacion", SqlDbType.Date, pObjeto.FechaDeCreacion), _
                                      New DatosParametros("@NotEnv_FechaDeEntrega", SqlDbType.Date, pObjeto.FechaDeEntrega), _
                                      New DatosParametros("@NotEnv_Estado", SqlDbType.VarChar, pObjeto.Estado), _
                                      New DatosParametros("@NotEnv_ID_Vendedor", SqlDbType.Int, pObjeto.IDVendedor)
                                   })
        If pObjeto.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pObjeto.IDVendedor = 0 Then
            vListaParametros.Item(4).Valor = Nothing
        End If
        If vListaParametros.Item(1).Valor = "0:00:00" Then
            vListaParametros.Item(1).Valor = Nothing
        End If
        If vListaParametros.Item(2).Valor = "0:00:00" Then
            vListaParametros.Item(2).Valor = Nothing
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaNotaDeEnvio", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim vNuevaNotaDeEnvio As New NotaDeEnvio(CInt(row.Item(0)), CDate(row.Item(1)), CDate(row.Item(2)), CStr(row.Item(3)), CStr(row.Item(4)), CInt(row.Item(5)))
                vListaNotaDeEnvio.Add(vNuevaNotaDeEnvio)
            Next
        End If
        Return vListaNotaDeEnvio

    End Function

    Public Function ConsultaVariosNEArticuloNotaDeEnvio(ByRef pNotaDeEnvio As NotaDeEnvio) As List(Of NotaDeEnvio)

        Dim vListaNotaDeEnvio As List(Of NotaDeEnvio)
        vListaNotaDeEnvio = Me.ConsultaVarios(pNotaDeEnvio)
        Dim vArticuloDAL As New Articulo_DAL
        For Each vNotaDeEnvio As NotaDeEnvio In vListaNotaDeEnvio
            vArticuloDAL.ConsultaVarios(vNotaDeEnvio)
        Next
        Return vListaNotaDeEnvio

    End Function

    Public Sub Modificacion(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Modificacion
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@NotEnv_ID", SqlDbType.Int, pObjeto.ID), _
                                      New DatosParametros("@NotEnv_FechaDeEntrega", SqlDbType.Date, pObjeto.FechaDeEntrega), _
                                      New DatosParametros("@NotEnv_Estado", SqlDbType.VarChar, pObjeto.Estado), _
                                      New DatosParametros("@NotEnv_Comentarios", SqlDbType.VarChar, pObjeto.Comentarios)
                                   })
        Comando.Ejecucion("ModificarNotaDeEnvio", vListaParametros)
        If Not pObjeto.ListaDeArticuloDeEnvio Is Nothing Then
            Dim vArticuloNotaDeEnvioDAL As New Articulo_DAL
            For Each vArticuloNotaDeEnvioActual As ArticuloNotaDeEnvio In pObjeto.ListaDeArticuloDeEnvio
                vArticuloNotaDeEnvioDAL.Modificacion(vArticuloNotaDeEnvioActual, pObjeto)
            Next
        End If
    End Sub

    Public Function NotaDeEnvioEnCurso(ByVal IDVendedor As Integer) As Boolean
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@NotEnv_ID_Vendedor", SqlDbType.Int, IDVendedor)
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaNotaDeEnvioEnCurso", vListaParametros)
        If vDataTable.Rows.Count > 0 Then
            Return True
        Else
            Return False
        End If

    End Function

    Public Sub NotaDeEnvioTrabajoEnCurso(ByRef pNotaDeEnvio As NotaDeEnvio)
        Dim vListaNotaDeEnvio As New List(Of NotaDeEnvio)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({New DatosParametros("@NotEnv_Estado", SqlDbType.VarChar, "TrabajoEnCurso"), _
                                   New DatosParametros("@NotEnv_ID_Vendedor", SqlDbType.Int, pNotaDeEnvio.IDVendedor)
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaNotaDeEnvio", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            pNotaDeEnvio.ID = CInt(vDataTable.Rows(0).Item(0))
            pNotaDeEnvio.FechaDeCreacion = CDate(vDataTable.Rows(0).Item(1))
            pNotaDeEnvio.FechaDeEntrega = CDate(vDataTable.Rows(0).Item(2))
            pNotaDeEnvio.Estado = CStr(vDataTable.Rows(0).Item(3))
            pNotaDeEnvio.Comentarios = CStr(vDataTable.Rows(0).Item(4))
        End If

    End Sub

End Class
