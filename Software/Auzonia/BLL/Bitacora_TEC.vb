Imports SEGURIDAD
Imports DAL

Public Class Bitacora_TEC

    Public Function ListarBitacoras(ByVal pBitacora As Bitacora, ByVal pFechaHasta As DateTime) As List(Of Bitacora)
        Dim vBitacoraDAL As New Bitacora_DAL
        Return vBitacoraDAL.ListarBitacoras(pBitacora, pFechaHasta)
    End Function

    Public Sub RegistrarEnBitacora(ByVal pBitacora As Bitacora)
        Dim vBitacoraDAL As New Bitacora_DAL
        vBitacoraDAL.Alta(pBitacora)
    End Sub

End Class
