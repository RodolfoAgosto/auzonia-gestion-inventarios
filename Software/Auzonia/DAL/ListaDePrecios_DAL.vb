Imports BE
Imports INTERFACES
Imports DAL
Public Class ListaDePrecios_DAL
    Implements Iabmc(Of ListaDePreciosCompra)

    Public Sub Alta(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Alta
        Try
            Dim vListaParametros As New List(Of DatosParametros)
            vListaParametros.AddRange({
                                      New DatosParametros("@LisPre_ID_Proveedor", SqlDbType.Int, pObjeto.Proveedor.ID), _
                                      New DatosParametros("@LisPre_Numero", SqlDbType.VarChar, pObjeto.Numero), _
                                      New DatosParametros("@LisPre_FechaDeInicio", SqlDbType.Date, pObjeto.FechaDeInicioVigencia)
                                      })
            Dim vdt As DataTable
            vdt = Comando.EjecucionRetornoDataTable("AltaListaDePreciosCompra", vListaParametros)
            pObjeto.ID = vdt.Rows(0).Item(0)
            Dim vArticuloDAL As New Articulo_DAL
            vArticuloDAL.CrearArticulos(pObjeto)
        Catch ex As Exception

        End Try
    End Sub

    Public Sub Baja(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Consulta

    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As ListaDePreciosCompra, ByRef pObjeto2 As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).ConsultaVarios
        Dim vListaListaDePreciosCompra As New List(Of ListaDePreciosCompra)
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@LisPreCom_ID", SqlDbType.Int, pObjeto.ID), _
                                      New DatosParametros("@LisPreCom_IDProveedor", SqlDbType.Int, Nothing), _
                                      New DatosParametros("@LisPreCom_Numero", SqlDbType.Int, pObjeto.Numero), _
                                      New DatosParametros("@LisPreCom_FechaDeInicioVigencia", SqlDbType.Date, pObjeto.FechaDeInicioVigencia)
                                     })
        If pObjeto.ID = 0 Then
            vListaParametros.Item(0).Valor = Nothing
        End If
        If Not pObjeto.Proveedor Is Nothing Then
            vListaParametros.Item(1).Valor = pObjeto.Proveedor.ID
            If pObjeto.Proveedor.ID = 0 Then
                vListaParametros.Item(1).Valor = Nothing
            End If
        End If
        If pObjeto.Numero = 0 Then
            vListaParametros.Item(2).Valor = Nothing
        End If
        If vListaParametros.Item(3).Valor = "0:00:00" Then
            vListaParametros.Item(3).Valor = Nothing
        End If
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaListaListaDePreciosCompra", vListaParametros)

        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                Dim vNuevaListaDePreciosCompra As New ListaDePreciosCompra(row.Item(0), row.Item(2), row.Item(3))
                If Not pObjeto.Proveedor Is Nothing Then
                    vNuevaListaDePreciosCompra.Proveedor = pObjeto.Proveedor
                Else
                    Dim vProveedorDAL As New Proveedor_DAL
                    Dim vNuevoProveedor As New Proveedor
                    vNuevoProveedor.ID = row.Item(1)
                    vProveedorDAL.Consulta(vNuevoProveedor)
                End If
                vListaListaDePreciosCompra.Add(vNuevaListaDePreciosCompra)
            Next
        End If

        Return vListaListaDePreciosCompra

    End Function

    Public Function ConsultaVariosLPDCArticulo(ByRef pObjeto As ListaDePreciosCompra) As List(Of ListaDePreciosCompra)
        Dim vListaListaDePreciosCompra As List(Of ListaDePreciosCompra)
        vListaListaDePreciosCompra = Me.ConsultaVarios(pObjeto)
        Dim vArticulo As New Articulo_DAL
        For Each vLPC As ListaDePreciosCompra In vListaListaDePreciosCompra
            vArticulo.ConsultaVarios(vLPC)
        Next
        Return vListaListaDePreciosCompra

    End Function

    Public Sub Modificacion(ByRef pObjeto As ListaDePreciosCompra) Implements Iabmc(Of ListaDePreciosCompra).Modificacion
        If Not pObjeto.ListaDeArticulos Is Nothing Then
            Dim vArticuloListaDePrecioDeComprasProveedorDAL As New Articulo_DAL
            For Each vArticuloListaDePrecioDeCompras As ArticuloListaDePrecios In pObjeto.ListaDeArticulos
                vArticuloListaDePrecioDeComprasProveedorDAL.Modificacion(vArticuloListaDePrecioDeCompras, pObjeto)
            Next
        End If

    End Sub

    Public Function ConsultarPrecio(ByVal pIDArticulo As Integer, ByVal pIDListaDePrecios As Integer) As Double
        Dim vPrecio As Double
        Dim vListaParametros As New List(Of DatosParametros)
        vListaParametros.AddRange({
                                      New DatosParametros("@Art_ID_ListaDePrecios", SqlDbType.Int, pIDListaDePrecios), _
                                      New DatosParametros("@ID_Articulo", SqlDbType.Int, pIDArticulo)
                                   })
        Dim vDataTable As DataTable
        vDataTable = Comando.EjecucionRetornoDataTable("ConsultaPrecioCompra", vListaParametros)
        If vDataTable.Rows.Count > 0 Then
            For Each row As DataRow In vDataTable.Rows
                vPrecio = CDbl(row.Item(0))
            Next
        End If
        Return vPrecio
    End Function

End Class
