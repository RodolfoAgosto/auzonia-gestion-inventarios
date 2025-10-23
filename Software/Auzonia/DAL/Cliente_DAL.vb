Imports SEGURIDAD
Imports BE

Public Class Cliente_DAL

    Public Sub Alta(ByRef pCliente As Cliente)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@Cli_RazonSocial", SqlDbType.VarChar, pCliente.RazonSocial), _
                                      New DatosParametros("@Cli_CUIT", SqlDbType.VarChar, pCliente.CUIT), _
                                      New DatosParametros("@Cli_Calle", SqlDbType.VarChar, pCliente.Calle), _
                                      New DatosParametros("@Cli_Numero", SqlDbType.VarChar, pCliente.Numero), _
                                      New DatosParametros("@Cli_Telefono", SqlDbType.VarChar, pCliente.Telefono), _
                                      New DatosParametros("@Cli_Email", SqlDbType.VarChar, pCliente.Email), _
                                      New DatosParametros("@Cli_Contacto", SqlDbType.VarChar, pCliente.NombreContacto), _
                                      New DatosParametros("@Cli_IDVendedor", SqlDbType.VarChar, pCliente.IDVendedor)
                                      })
            Comando.Ejecucion("AltaCliente", vListaParametros)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pCliente As Cliente)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Cli_ID", SqlDbType.Int, pCliente.ID)
        }
        Comando.Ejecucion("BajaCliente", vListaParametros)
    End Sub

    Public Sub Consulta(ByRef pCliente As Cliente)
        Dim vListaParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Cli_ID", SqlDbType.Int, pCliente.ID)
        }
        Dim vDataTable As DataTable = Comando.EjecucionRetornoDataTable("ConsultaCliente", vListaParametros)
        If vDataTable.Rows.Count <> 0 Then
            pCliente.ID = vDataTable.Rows(0).Item("ID")
            pCliente.RazonSocial = vDataTable.Rows(0).Item("RazonSocial")
            pCliente.CUIT = vDataTable.Rows(0).Item("CUIT")
            pCliente.Calle = vDataTable.Rows(0).Item("Calle")
            pCliente.Numero = vDataTable.Rows(0).Item("Numero")
            pCliente.Telefono = vDataTable.Rows(0).Item("Telefono")
            pCliente.Email = vDataTable.Rows(0).Item("Email")
            pCliente.NombreContacto = vDataTable.Rows(0).Item("NombreContacto")
            pCliente.IDVendedor = vDataTable.Rows(0).Item("IDVendedor")
        Else
            'Si no existe pongo el codigo como vacio=""
            pCliente.ID = ""
        End If

    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As Cliente) As List(Of Cliente)
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As Cliente, ByRef pObjeto2 As Cliente) As List(Of Cliente)
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pCliente As Cliente) As List(Of Cliente)

        Dim vListaClientes As New List(Of Cliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Cli_ID", SqlDbType.Int, CInt(pCliente.ID)), _
                                      New DatosParametros("@Cli_RazonSocial", SqlDbType.VarChar, pCliente.RazonSocial), _
                                      New DatosParametros("@Cli_CUIT", SqlDbType.VarChar, pCliente.CUIT), _
                                      New DatosParametros("@Cli_Calle", SqlDbType.VarChar, pCliente.Calle), _
                                      New DatosParametros("@Cli_Numero", SqlDbType.VarChar, pCliente.Numero), _
                                      New DatosParametros("@Cli_Telefono", SqlDbType.VarChar, pCliente.Telefono), _
                                      New DatosParametros("@Cli_Email", SqlDbType.VarChar, pCliente.Email), _
                                      New DatosParametros("@Cli_Contacto", SqlDbType.VarChar, pCliente.NombreContacto), _
                                      New DatosParametros("@Cli_IDVendedor", SqlDbType.Int, CInt(pCliente.IDVendedor))
                                   })
        If pCliente.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If pCliente.IDVendedor = 0 Then
            vListaParametros.Item(8).Valor = Nothing
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaClientes", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaClientes.Add(New Cliente(row.Item(0), row.Item(1), row.Item(2), row.Item(3), row.Item(4), row.Item(5), row.Item(6), row.Item(7), row.Item(8)))
            Next
        End If

        Return vListaClientes

    End Function

    Public Function ConsultaVariosCltePedidoDeClienteArticuloPedCiente(ByRef pCliente As Cliente) As List(Of Cliente)
        Dim vListaDeClientes As List(Of Cliente) = Me.ConsultaVarios(pCliente)
        Dim vPedidoDeClienteDAL As New PedidoDeCliente_DAL
        For Each vCliente As Cliente In vListaDeClientes
            Dim vPedidoDeCliente As New PedidoDeCliente With {
                .Cliente = vCliente
            }
            vCliente.ListaPedidoDeCliente = vPedidoDeClienteDAL.ConsultaVariosPCArticuloPedidoDeCliente(vPedidoDeCliente)
        Next

        Return vListaDeClientes
    End Function

    Public Sub Modificacion(ByRef pCliente As Cliente)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Cli_ID", SqlDbType.VarChar, pCliente.ID), _
                                      New DatosParametros("@Cli_RazonSocial", SqlDbType.VarChar, pCliente.RazonSocial), _
                                      New DatosParametros("@Cli_CUIT", SqlDbType.VarChar, pCliente.CUIT), _
                                      New DatosParametros("@Cli_Calle", SqlDbType.VarChar, pCliente.Calle), _
                                      New DatosParametros("@Cli_Numero", SqlDbType.VarChar, pCliente.Numero), _
                                      New DatosParametros("@Cli_Telefono", SqlDbType.VarChar, pCliente.Telefono), _
                                      New DatosParametros("@Cli_Email", SqlDbType.VarChar, pCliente.Email), _
                                      New DatosParametros("@Cli_Contacto", SqlDbType.VarChar, pCliente.NombreContacto), _
                                      New DatosParametros("@Cli_IDVendedor", SqlDbType.VarChar, pCliente.IDVendedor)
                                 })
        Comando.Ejecucion("ModificarCliente", vListaParametros)
    End Sub

End Class
