Imports BE
Imports System.Data
Imports System.Data.SqlClient

Public Class Idioma_DAL

    Private _Transaccion As SqlTransaction
    Public Property Transaccion() As SqlTransaction
        Get
            Return _Transaccion
        End Get
        Set(ByVal value As SqlTransaction)
            _Transaccion = value
        End Set
    End Property

    Public Sub Alta(ByRef pIdioma As Idioma)

        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                New DatosParametros("@Idi_Nombre", SqlDbType.VarChar, pIdioma.Nombre)
             })
            Comando.Ejecucion("AltaIdioma", vListaParametros)
            Dim vdt As DataTable
            vdt = Comando.EjecucionRetornoDataTable("ConsultarIDIdioma", vListaParametros)
            pIdioma.ID = vdt.Rows(0).Item(0)
            Dim vTraduccionDAL As New Traduccion_DAL
            vTraduccionDAL.CrearTraducciones(pIdioma)
        Catch ex As Exception
            MsgBox("Ocurrio un error para cargar el idioma.")
        End Try

    End Sub

    Public Function ConsultaTodos() As List(Of Idioma)

        Dim vListaIdioma As New List(Of Idioma)
        Dim vListaParametros As New List(Of DatosParametros)
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaIdiomas", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vListaIdioma.Add(New BE.Idioma(row.Item(0), row.Item(1)))
            Next
        End If

        Return vListaIdioma

    End Function

    Public Sub Actualizar(ByVal pIdioma As Idioma)
        Try

            Dim vListaParametros As New List(Of DatosParametros)
            Dim vTraduccionDAL As New Traduccion_DAL
            For Each vTraduccion As Traduccion In pIdioma.ListaTraducciones
                vListaParametros.Clear()
                vListaParametros.Add(New DatosParametros("@Tra_IDIdioma", SqlDbType.BigInt, pIdioma.ID))
                vListaParametros.Add(New DatosParametros("@Tra_IDMensaje", SqlDbType.BigInt, vTraduccion.IDMensaje))
                vListaParametros.Add(New DatosParametros("@Tra_MensajeTraducido", SqlDbType.VarChar, vTraduccion.MensajeTraducido))
                Comando.Ejecucion("ModificacionTraduccion", vListaParametros)
            Next
            MsgBox("El idioma ha sido actualizado correctamente.", MsgBoxStyle.Information, "Auzonia")
        Catch ex As Exception

        End Try
    End Sub

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
