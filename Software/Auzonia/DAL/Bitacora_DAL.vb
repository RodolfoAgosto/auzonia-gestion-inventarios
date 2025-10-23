Imports INTERFACES
Imports SEGURIDAD

Public Class Bitacora_DAL

    Implements Iabmc(Of Bitacora)

    Public Sub Alta(ByRef pObjeto As Bitacora) Implements Iabmc(Of Bitacora).Alta
        Try
            'Crea una instancia del tipo especificado usando el constructor predeterminado de ese tipo.
            Dim vBitacora As SEGURIDAD.Bitacora
            vBitacora = pObjeto
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
            New DatosParametros("@Bit_CodigoUsuario", SqlDbType.VarChar, vBitacora.CodigoUsuario),
            New DatosParametros("@Bit_CodigoBitacora", SqlDbType.VarChar, vBitacora.CodigoBitacora), _
            New DatosParametros("@Bit_Informacion", SqlDbType.VarChar, vBitacora.Informacion), _
            New DatosParametros("@Bit_TipoDeObjeto", SqlDbType.VarChar, vBitacora.TiporDeObjeto), _
            New DatosParametros("@Bit_IdentificadorDeObjeto", SqlDbType.VarChar, vBitacora.IdentificadorDeObjeto)
                                       })
            Comando.Ejecucion("RegistrarBitacora", vListaParametros)

        Catch ex As Exception

        End Try

    End Sub

    Public Sub Baja(ByRef pObjeto As Bitacora) Implements Iabmc(Of Bitacora).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As Bitacora) Implements Iabmc(Of Bitacora).Consulta

    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As Bitacora) As List(Of Bitacora) Implements Iabmc(Of Bitacora).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As Bitacora, ByRef pObjeto2 As Bitacora) As List(Of Bitacora) Implements Iabmc(Of Bitacora).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As Bitacora) As List(Of Bitacora) Implements Iabmc(Of Bitacora).ConsultaVarios
        Return Nothing
    End Function

    Public Sub Modificacion(ByRef pObjeto As Bitacora) Implements Iabmc(Of Bitacora).Modificacion

    End Sub

    Public Function ListarBitacoras(ByVal pBitacora As Bitacora, ByVal pFechaHasta As DateTime) As List(Of Bitacora)
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
            New DatosParametros("@Bit_FechaDesde", SqlDbType.DateTime, pBitacora.Fecha),
            New DatosParametros("@Bit_FechaHasta", SqlDbType.DateTime, pFechaHasta), _
            New DatosParametros("@Bit_CodigoUsuario", SqlDbType.VarChar, pBitacora.CodigoUsuario), _
            New DatosParametros("@Bit_TipoBitacora", SqlDbType.VarChar, pBitacora.Tipo), _
            New DatosParametros("@Bit_CodigoBitacora", SqlDbType.VarChar, pBitacora.CodigoBitacora), _
            New DatosParametros("@Bit_TipoDeObjeto", SqlDbType.VarChar, pBitacora.TiporDeObjeto), _
            New DatosParametros("@Bit_IdentificadorDeObjeto", SqlDbType.VarChar, pBitacora.IdentificadorDeObjeto)
                                                   })

            Dim vDataTable As DataTable
            vDataTable = Comando.EjecucionRetornoDataTable("ListarBitacora", vListaParametros)
            Dim vListaBitacora As New List(Of Bitacora)

            If vDataTable.Rows.Count > 0 Then
                For Each row As DataRow In vDataTable.Rows
                    Dim vNuevaBitacora As New Bitacora With {
                        .ID = row.Item(0).ToString,
                        .CodigoUsuario = row.Item(1).ToString,
                        .Fecha = row.Item(2).ToString,
                        .Tipo = row.Item(3).ToString,
                        .CodigoBitacora = row.Item(4).ToString,
                        .Detalle = row.Item(5).ToString,
                        .Informacion = row.Item(6).ToString,
                        .TiporDeObjeto = row.Item(7).ToString,
                        .IdentificadorDeObjeto = row.Item(8).ToString
                    }
                    vListaBitacora.Add(vNuevaBitacora)
                Next
            End If

            Return vListaBitacora
        Catch ex As Exception
            Return Nothing
        End Try

    End Function


End Class
