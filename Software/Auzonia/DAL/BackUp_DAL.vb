Imports SEGURIDAD
Public Class BackUp_DAL

    Public Sub RealizarBackUp(ByVal pDestino As String)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                  New DatosParametros("@Destino", SqlDbType.VarChar, pDestino)
                                  })
            Comando.Ejecucion("RealizarBackup", vListaParametros)
            Comando.Ejecucion("RegistrarBackUp", vListaParametros)
        Catch ex As Exception
            Dim vBitacora As New Bitacora With {
                .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                .CodigoBitacora = "0006",
                .Informacion = ex.Message,
                .TiporDeObjeto = "BackUp",
                .IdentificadorDeObjeto = "BackUp_DAL"
            }
            Dim vBitacoraDAL As New Bitacora_DAL
            vBitacoraDAL.Alta(vBitacora)
            Throw New Exception()
        Finally

        End Try
    End Sub

    Public Sub RestaurarBaseDeDatos(ByVal pOrigen As String)
        'Dim vListaParametros As New List(Of DatosParametros)
        'vListaParametros.AddRange({
        '                          New DatosParametros("@Origen", SqlDbType.VarChar, pOrigen)
        '                          })
        'Comando.Ejecucion("RestaurarBaseAuzonia", vListaParametros)
        Dim comm As New SqlClient.SqlCommand With {
            .Connection = Conexion.ObjetoConexionMaster,
            .CommandType = CommandType.Text,
            .CommandText = "USE [master] ALTER DATABASE AUZONIA SET SINGLE_USER WITH ROLLBACK IMMEDIATE;RESTORE DATABASE AUZONIA FROM DISK = @Origen WITH REPLACE,RECOVERY; ALTER DATABASE AUZONIA SET MULTI_USER WITH ROLLBACK IMMEDIATE;"
        }
        Dim nuevoParametro As New SqlClient.SqlParameter With {
            .SqlDbType = SqlDbType.VarChar,
            .ParameterName = "@Origen",
            .Value = pOrigen
        }
        comm.Parameters.Add(nuevoParametro)
        Try
            If comm.Connection.State <> ConnectionState.Open Then
                comm.Connection.Open()
            End If
            comm.ExecuteNonQuery()
            comm.Connection.Close()
        Catch ex As Exception
            comm.Connection.Close()
            Dim vBitacora As New Bitacora With {
                .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                .CodigoBitacora = "0007",
                .Informacion = ex.Message,
                .TiporDeObjeto = "Restore",
                .IdentificadorDeObjeto = "BackUp_DAL"
            }
            Dim vBitacoraDAL As New Bitacora_DAL
            vBitacoraDAL.Alta(vBitacora)
            comm.Connection.Close()
            Throw New Exception
        End Try
    End Sub

    Public Function ListarDirectorios() As List(Of SEGURIDAD.Restaurador_SEG)
        Dim vListaDirectorios As New List(Of SEGURIDAD.Restaurador_SEG)
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaRestaurador", Nothing)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim nuevoRestaurador As New SEGURIDAD.Restaurador_SEG With {
                    .Directorio = row.Item(1),
                    .Fecha = (CDate(row.Item(2)))
                }
                vListaDirectorios.Add(nuevoRestaurador)
            Next
        End If
        Return vListaDirectorios

    End Function

End Class
