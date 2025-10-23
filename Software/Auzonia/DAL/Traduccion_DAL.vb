Imports BE
Imports System.Data.SqlClient

Public Class Traduccion_DAL

    Private _Transaccion As SqlTransaction
    Public Property Transaccion() As SqlTransaction
        Get
            Return _Transaccion
        End Get
        Set(ByVal value As SqlTransaction)
            _Transaccion = value
        End Set
    End Property

    Public Sub CrearTraducciones(ByVal pIdioma As Idioma)
        Try
            Dim vDTMensajes As DataTable
            Dim vParametros As New List(Of DatosParametros)
            vDTMensajes = Comando.EjecucionRetornoDataTable("ListarMensajes", vParametros)
            For Each vMensaje As DataRow In vDTMensajes.Rows
                vParametros.Clear()
                vParametros.AddRange({
                 New DatosParametros("@Tra_IDIdioma", SqlDbType.Int, pIdioma.ID),
                 New DatosParametros("@Tra_IDMensaje", SqlDbType.Int, vMensaje.Item(0)),
                 New DatosParametros("@Tra_MensajeTraducido", SqlDbType.NVarChar, vMensaje.Item(2))
                             })
                Comando.Ejecucion("AltaTraduccion", vParametros)
            Next
        Catch ex As Exception

            MsgBox("Ocurrio un error no pudieron cargarse las traducciones.")
        End Try

    End Sub

    Public Function ListarTraducciones(ByVal pIdioma As Idioma) As List(Of Traduccion)
        Dim vlistaTraducciones As New List(Of Traduccion)
        Dim dt As DataTable
        Dim vParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Tra_IDIdioma", SqlDbType.BigInt, pIdioma.ID)
        }
        dt = Comando.EjecucionRetornoDataTable("ListarTraduccionesPorIdioma", vParametros)
        If dt.Rows.Count > 0 Then
            For Each vRow As DataRow In dt.Rows
                vlistaTraducciones.Add(New Traduccion(vRow(0), vRow(1), vRow(2), vRow(3), vRow(4)))
            Next
            Return vlistaTraducciones
        End If
        Return Nothing
    End Function

    Public Function ListarTraducciones(ByVal pIdioma As Idioma, ByVal pPropietario As String) As List(Of Traduccion)
        Dim vlistaTraducciones As New List(Of Traduccion)
        Dim dt As DataTable
        Dim vParametros As New List(Of DatosParametros) From {
            New DatosParametros("@Tra_IDIdioma", SqlDbType.BigInt, pIdioma.ID),
            New DatosParametros("@Men_Propietario", SqlDbType.VarChar, pPropietario)
        }
        dt = Comando.EjecucionRetornoDataTable("ListarTraduccionesPorPropietario", vParametros)
        If dt.Rows.Count > 0 Then
            For Each vRow As DataRow In dt.Rows
                vlistaTraducciones.Add(New Traduccion(vRow(0), vRow(1), vRow(2), vRow(3), vRow(4)))
            Next
            Return vlistaTraducciones
        End If
        Return Nothing
    End Function

    Public Sub IniciarTransaccion()
        Dim _conexion As SqlConnection = Conexion.ObjetoConexion
        Me.Transaccion = _conexion.BeginTransaction
    End Sub

    Public Sub Commit()
        Me.Transaccion.Commit()
    End Sub

    Public Sub RollBack()
        Me.Transaccion.Rollback()
    End Sub

End Class
