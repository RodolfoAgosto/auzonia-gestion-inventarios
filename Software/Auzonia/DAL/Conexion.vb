Imports System.Configuration
Imports System.Data.SqlClient
Public Class Conexion
    'Provee la conexión a la base de datos.
    Private Shared _objetoConexion As SqlConnection
    Shared Function ObjetoConexion(Optional ByVal pStringDeConexion As String = "Data Source=.\SQLEXPRESS;Initial Catalog=Auzonia;Integrated Security=True") As SqlConnection
        If _objetoConexion Is Nothing Then _objetoConexion = New SqlConnection(pStringDeConexion)
        If _objetoConexion.State = ConnectionState.Closed Then _objetoConexion.Open()
        Return _objetoConexion
    End Function
    Shared Function ObjetoConexionMaster(Optional ByVal pStringDeConexion As String = "Data Source=.\SQLEXPRESS;Initial Catalog=Auzonia;Integrated Security=True") As SqlConnection
        If _objetoConexion Is Nothing Then _objetoConexion = New SqlConnection(pStringDeConexion)
        If _objetoConexion.State = ConnectionState.Closed Then _objetoConexion.Open()
        Return _objetoConexion
    End Function

End Class
