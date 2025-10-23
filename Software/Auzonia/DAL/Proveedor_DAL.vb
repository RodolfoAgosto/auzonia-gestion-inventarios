Imports BE

Public Class Proveedor_DAL

    Public Sub Alta(ByRef pProveedor As Proveedor)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@Pro_RazonSocial", SqlDbType.VarChar, pProveedor.RazonSocial),
                                      New DatosParametros("@Pro_Calle", SqlDbType.VarChar, pProveedor.Calle),
                                      New DatosParametros("@Pro_Numero", SqlDbType.VarChar, pProveedor.Altura),
                                      New DatosParametros("@Pro_Telefono", SqlDbType.VarChar, pProveedor.Telefono),
                                      New DatosParametros("@Pro_CUIT", SqlDbType.VarChar, pProveedor.CUIT),
                                      New DatosParametros("@Pro_Email", SqlDbType.VarChar, pProveedor.Email),
                                      New DatosParametros("@Pro_Contacto", SqlDbType.VarChar, pProveedor.NombreContacto)
                                     })
            Comando.Ejecucion("AltaProveedor", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pProveedor As Proveedor)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Pro_ID", SqlDbType.Int, pProveedor.ID)
        }
        Comando.Ejecucion("BajaProveedor", vListaParametros)
    End Sub

    Public Sub Consulta(ByRef pProveedor As Proveedor)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Pro_ID", SqlDbType.Int, pProveedor.ID)
        }
        Dim vDataTable As DataTable = Comando.EjecucionRetornoDataTable("ConsultaProveedor", vListaParametros)
        If vDataTable.Rows.Count <> 0 Then
            pProveedor.ID = vDataTable.Rows(0).Item("ID")
            pProveedor.RazonSocial = vDataTable.Rows(0).Item("RazonSocial")
            pProveedor.Calle = vDataTable.Rows(0).Item("Calle")
            pProveedor.Altura = vDataTable.Rows(0).Item("Numero")
            pProveedor.Telefono = vDataTable.Rows(0).Item("Telefono")
            pProveedor.CUIT = vDataTable.Rows(0).Item("CUIT")
            pProveedor.Email = vDataTable.Rows(0).Item("Email")
            pProveedor.NombreContacto = vDataTable.Rows(0).Item("Contacto")
        Else
            'Si no existe pongo el codigo como vacio=""
            pProveedor.ID = ""
        End If

    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As Proveedor) As List(Of Proveedor)
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As Proveedor, ByRef pObjeto2 As Proveedor) As List(Of Proveedor)
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pProveedor As Proveedor) As List(Of Proveedor)

        Dim vListaProveedores As New List(Of Proveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Pro_ID", SqlDbType.Int, pProveedor.ID), _
                                      New DatosParametros("@Pro_RazonSocial", SqlDbType.VarChar, pProveedor.RazonSocial), _
                                      New DatosParametros("@Pro_Calle", SqlDbType.VarChar, pProveedor.Calle), _
                                      New DatosParametros("@Pro_Numero", SqlDbType.VarChar, pProveedor.Altura), _
                                      New DatosParametros("@Pro_Telefono", SqlDbType.VarChar, pProveedor.Telefono), _
                                      New DatosParametros("@Pro_CUIT", SqlDbType.VarChar, pProveedor.CUIT), _
                                      New DatosParametros("@Pro_Email", SqlDbType.VarChar, pProveedor.Email), _
                                      New DatosParametros("@Pro_Contacto", SqlDbType.VarChar, pProveedor.NombreContacto)
                                     })
        If pProveedor.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaProveedores", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaProveedores.Add(New Proveedor(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7)))
            Next
        End If

        Return vListaProveedores

    End Function

    Public Sub Modificacion(ByRef pProveedor As Proveedor)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Pro_ID", SqlDbType.Int, pProveedor.ID), _
                                      New DatosParametros("@Pro_RazonSocial", SqlDbType.VarChar, pProveedor.RazonSocial), _
                                      New DatosParametros("@Pro_Calle", SqlDbType.VarChar, pProveedor.Calle), _
                                      New DatosParametros("@Pro_Numero", SqlDbType.VarChar, pProveedor.Altura), _
                                      New DatosParametros("@Pro_Telefono", SqlDbType.VarChar, pProveedor.Telefono), _
                                      New DatosParametros("@Pro_CUIT", SqlDbType.VarChar, pProveedor.CUIT), _
                                      New DatosParametros("@Pro_Email", SqlDbType.VarChar, pProveedor.Email), _
                                      New DatosParametros("@Pro_Contacto", SqlDbType.VarChar, pProveedor.NombreContacto)
                                  })
        Comando.Ejecucion("ModificarProveedor", vListaParametros)
    End Sub

End Class
