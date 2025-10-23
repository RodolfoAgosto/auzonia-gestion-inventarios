Imports System.Data.SqlClient
Imports SEGURIDAD

Public Class Comando
    'Provee la responsabilidad de administrar los SqlCommand que necesiten para la efectiva ejecución de las acciones en la base de datos.

    'La siguiente funcion privada permite obtener un objeto comando.
    'Es llamada por otros métodos de esta clase.
    Private Shared _objetoComando As SqlCommand
    Private Shared Function obtenerComando(ByVal pNombreProcedimiento As String, ByVal pConexion As SqlConnection, ByVal pParametros _
                                         As List(Of DatosParametros)) As SqlCommand
        _objetoComando = New SqlCommand With {
            .CommandText = pNombreProcedimiento,
            .Connection = pConexion,
            .CommandType = CommandType.StoredProcedure
        }
        If Not pParametros Is Nothing Then
            For Each vParam As DatosParametros In pParametros
                Dim vNuevoParametro As New SqlParameter With {
                    .SqlDbType = vParam.TipoParametro,
                    .ParameterName = vParam.NombreParametro,
                    .Value = vParam.Valor
                }
                _objetoComando.Parameters.Add(vNuevoParametro)
            Next
        End If
        Return _objetoComando
    End Function

    'Para listar varios registro, devuelve un objeto DataTable.
    Shared Function EjecucionRetornoDataTable(ByVal pNombreProcedimiento As String, ByVal pParametros As List(Of DatosParametros)) As DataTable
        'Creo el DataAdapter pasandole el objeto Comando al constructor. Para ellos debo llamar a la funcion obtenerComando de esta clase.
        Dim vDataAdapter As New SqlDataAdapter(obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexion, pParametros))
        Dim vDataTable As New DataTable
        vDataAdapter.Fill(vDataTable)
        Return vDataTable
    End Function

    Shared Function EjecucionRetornoDataTable(ByVal pNombreProcedimiento As String, ByVal pParametros As List(Of DatosParametros), ByRef pTransaccion As SqlTransaction) As DataTable
        'Creo el DataAdapter pasandole el objeto Comando al constructor. Para ellos debo llamar a la funcion obtenerComando de esta clase.
        Dim vComando As SqlCommand
        vComando = obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexion(Nothing), pParametros)
        vComando.Transaction = pTransaccion
        Dim vDataAdapter As New SqlDataAdapter(vComando)
        Dim vDataTable As New DataTable
        vDataAdapter.Fill(vDataTable)
        Return vDataTable
    End Function

    Shared Sub Ejecucion(ByVal pNombreProcedimiento As String, ByVal pParametros As List(Of DatosParametros))
        Try
            If pNombreProcedimiento = "RestaurarBaseAuzonia" Then
                obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexionMaster, pParametros).ExecuteNonQuery()
            Else
                obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexion, pParametros).ExecuteNonQuery()
            End If
        Catch ex As Exception
            Dim vBitacora As New Bitacora With {
                .CodigoUsuario = Sesion_SEG.SesionActual.UsuarioSEG.Codigo,
                .CodigoBitacora = "0006",
                .Informacion = ex.Message,
                .TiporDeObjeto = "Generico",
                .IdentificadorDeObjeto = "Comando"
            }
            Dim vBitacoraDAL As New Bitacora_DAL
            vBitacoraDAL.Alta(vBitacora)
            Throw New Exception()
        End Try
    End Sub

    Shared Function EjecucionScalar(ByVal pNombreProcedimiento As String, ByVal pParametros As List(Of DatosParametros)) As String
        Try
            Return obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexion, pParametros).ExecuteScalar()
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Shared Sub Ejecucion(ByVal pNombreProcedimiento As String, ByVal pParametros As List(Of DatosParametros), ByRef pTransaccion As SqlTransaction)
        Try
            Dim vComando As SqlCommand
            vComando = obtenerComando(pNombreProcedimiento, Conexion.ObjetoConexion(Nothing), pParametros)
            vComando.Transaction = pTransaccion
            vComando.ExecuteNonQuery()
        Catch ex As Exception

        End Try
    End Sub

End Class
