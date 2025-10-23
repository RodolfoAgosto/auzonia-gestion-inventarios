Imports SEGURIDAD
Imports BE

Public Class RemitoProveedor_DAL

    Public Sub Alta(ByRef pRemitoProveedor As RemitoProveedor)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@RemPro_ID_Proveedor", SqlDbType.Int, pRemitoProveedor.Proveedor.ID),
                                      New DatosParametros("@RemPro_Numero", SqlDbType.VarChar, pRemitoProveedor.Numero)
                                      })
            pRemitoProveedor.ID = Comando.EjecucionScalar("AltaRemitoProveedor", vListaParametros)
            Dim vArticuloDAL As New Articulo_DAL
            For Each vARP As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
                vArticuloDAL.Alta(vARP, pRemitoProveedor)
            Next
        Catch ex As Exception

        End Try
    End Sub

    Public Function ConsultaVarios(ByRef pRemitoProveedor As RemitoProveedor) As List(Of RemitoProveedor)
        If Not pRemitoProveedor.Proveedor Is Nothing Then
            Dim vListaRemitoProveedor As New List(Of RemitoProveedor)
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                         New DatosParametros("@RemPro_ID", SqlDbType.Int, pRemitoProveedor.ID), _
                                         New DatosParametros("@RemPro_ID_Proveedor", SqlDbType.Int, pRemitoProveedor.Proveedor.ID), _
                                         New DatosParametros("@RemPro_Fecha", SqlDbType.Date, pRemitoProveedor.FechaDeCreacion), _
                                         New DatosParametros("@RemPro_Numero", SqlDbType.VarChar, pRemitoProveedor.Numero), _
                                         New DatosParametros("@RemPro_Estado", SqlDbType.VarChar, pRemitoProveedor.Estado)
                                       })
            If pRemitoProveedor.ID = 0 Then
                vListaParametros.Item(0).Valor = Nothing
            End If
            If Not pRemitoProveedor.Proveedor Is Nothing Then
                vListaParametros.Item(1).Valor = pRemitoProveedor.Proveedor.ID
                If pRemitoProveedor.Proveedor.ID = 0 Then
                    vListaParametros.Item(1).Valor = Nothing
                End If
            End If
            If vListaParametros.Item(2).Valor = "0:00:00" Then
                vListaParametros.Item(2).Valor = Nothing
            End If
            Dim vDataTable As DataTable
            vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaRemitoProveedor", vListaParametros)

            If vDataTable.Rows.Count > 0 Then
                For Each row As DataRow In vDataTable.Rows
                    Dim vNuevoRemitoProveedor As New RemitoProveedor(CInt(row.Item(0)), CDate(row.Item(2)), row.Item(3), row.Item(4))
                    Dim vProveedorDAL As New Proveedor_DAL
                    vProveedorDAL.Consulta(pRemitoProveedor.Proveedor)
                    vNuevoRemitoProveedor.Proveedor = pRemitoProveedor.Proveedor
                    vListaRemitoProveedor.Add(vNuevoRemitoProveedor)
                Next
            End If
            Return vListaRemitoProveedor
        Else
            Return Nothing
        End If
    End Function

    Public Sub Consulta(ByRef pRemitoProveedor As RemitoProveedor)
        Dim vRemitoProveedor As RemitoProveedor
        Dim vListaDeRemitoProveedor As List(Of RemitoProveedor)
        vListaDeRemitoProveedor = Me.ConsultaVarios(pRemitoProveedor)
        vRemitoProveedor = vListaDeRemitoProveedor.Item(0)
        Dim vArticuloDAL As New Articulo_DAL
        vArticuloDAL.ConsultaVarios(vRemitoProveedor)
        pRemitoProveedor.ListaDeArticulos = vRemitoProveedor.ListaDeArticulos
    End Sub

    Public Sub Modificacion(ByRef pRemitoProveedor As RemitoProveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@RemPro_ID", SqlDbType.Int, pRemitoProveedor.ID), _
                                      New DatosParametros("@RemPro_ID_Proveedor", SqlDbType.Int, pRemitoProveedor.Proveedor.ID), _
                                      New DatosParametros("@RemPro_Fecha", SqlDbType.Date, pRemitoProveedor.FechaDeCreacion), _
                                      New DatosParametros("@RemPro_Estado", SqlDbType.VarChar, pRemitoProveedor.Estado)
                                  })
        Comando.Ejecucion("ModificarRemitoProveedor", vListaParametros)
        If Not pRemitoProveedor.ListaDeArticulos Is Nothing Then
            Dim vArticuloRemitoProveedorDAL As New Articulo_DAL
            For Each vArticuloRemitoProveedor As ArticuloRemitoProveedor In pRemitoProveedor.ListaDeArticulos
                vArticuloRemitoProveedorDAL.Modificacion(vArticuloRemitoProveedor, pRemitoProveedor)
            Next
        End If
    End Sub

End Class
