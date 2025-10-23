Imports SEGURIDAD
Imports BE
Imports DAL

Public Class NotaDeEnvio_NEG

    Implements INTERFACES.Iabmc(Of NotaDeEnvio)

    Public Sub CompletarArticulos(ByRef vListaDeClientes As List(Of Cliente), ByRef vNotaDeEnvio As NotaDeEnvio)
        For Each vCliente As Cliente In vListaDeClientes
            For Each vPedidoDeCliente As PedidoDeCliente In vCliente.ListaPedidoDeCliente
                For Each vArticuloPedidoDeCliente As ArticuloPedidoDeCliente In vPedidoDeCliente.ListaDeArticulos
                    Me.Sumar(vArticuloPedidoDeCliente, vNotaDeEnvio)
                Next
            Next
        Next
    End Sub

    Public Sub Sumar(ByRef vArticuloPedidoDeCliente As ArticuloPedidoDeCliente, ByRef vNotaDeEnvio As NotaDeEnvio)
        If vArticuloPedidoDeCliente.Enviar > 0 Then
            If vNotaDeEnvio.Diccionario.ContainsKey(vArticuloPedidoDeCliente.ID) Then
                vNotaDeEnvio.Diccionario(vArticuloPedidoDeCliente.ID).Cantidad = vNotaDeEnvio.Diccionario(vArticuloPedidoDeCliente.ID).Cantidad + vArticuloPedidoDeCliente.Enviar
            Else
                Dim vNuevoArticulo As New ArticuloNotaDeEnvio
                vNuevoArticulo.ID = vArticuloPedidoDeCliente.ID
                vNuevoArticulo.Codigo = vArticuloPedidoDeCliente.Codigo
                vNuevoArticulo.Descripcion = vArticuloPedidoDeCliente.Descripcion
                vNuevoArticulo.IDProveedor = vArticuloPedidoDeCliente.IDProveedor
                vNuevoArticulo.Cantidad = vArticuloPedidoDeCliente.Enviar
                vNotaDeEnvio.ListaDeArticuloDeEnvio.Add(vNuevoArticulo)
                vNotaDeEnvio.Diccionario.Add(vNuevoArticulo.ID, vNuevoArticulo)
            End If
        End If
    End Sub

    Public Sub Alta(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Alta
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        vNotaDeEnvioDAL.Alta(pObjeto)
    End Sub

    Public Sub Baja(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Consulta
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        vNotaDeEnvioDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As NotaDeEnvio, ByRef pObjeto2 As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As NotaDeEnvio) As List(Of NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).ConsultaVarios
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        Return vNotaDeEnvioDAL.ConsultaVarios(pObjeto)
    End Function

    Public Function ConsultaVariosNEArticuloNotaDeEnvio(ByRef pNotaDeEnvio As NotaDeEnvio) As List(Of NotaDeEnvio)
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        Return vNotaDeEnvioDAL.ConsultaVariosNEArticuloNotaDeEnvio(pNotaDeEnvio)
    End Function

    Public Sub Modificacion(ByRef pObjeto As NotaDeEnvio) Implements INTERFACES.Iabmc(Of NotaDeEnvio).Modificacion
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        vNotaDeEnvioDAL.Modificacion(pObjeto)
    End Sub

    Public Function NotaDeEnvioEnCurso(ByVal pVendedor As Usuario_SEG) As Boolean
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        Return vNotaDeEnvioDAL.NotaDeEnvioEnCurso(pVendedor.ID)
    End Function

    Public Sub NotaDeEnvioTrabajoEnCurso(ByRef pNotaDeEnvio As NotaDeEnvio)
        Dim vNotaDeEnvioDAL As New NotaDeEnvio_DAL
        vNotaDeEnvioDAL.NotaDeEnvioTrabajoEnCurso(pNotaDeEnvio)
    End Sub

End Class
