Imports DAL
Imports BE
Imports System.IO
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.Xml.Serialization
Public Class NotaDePedido_NEG

    Implements INTERFACES.Iabmc(Of NotaDePedido)

    Public Sub Alta(ByRef pObjeto As NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).Alta
        Dim vNotaDePedidoDAL As New NotaDePedido_DAL
        SerializarNotaDePedido(pObjeto)
        vNotaDePedidoDAL.Alta(pObjeto)
    End Sub

    Private Sub SerializarNotaDePedido(ByVal pNotaDePedido As NotaDePedido)
        'Dim miFileStream As Stream = File.Create("C:\Users\Rodol\Downloads\NotaDePedido.xml")
        'Dim serializador As XmlSerializer = New XmlSerializer(GetType(NotaDePedido))
        'serializador.Serialize(miFileStream, pNotaDePedido)
        'miFileStream.Close()
    End Sub

    Public Sub Baja(ByRef pObjeto As NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).Baja

    End Sub

    Public Sub Consulta(ByRef pObjeto As NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).Consulta
        Dim vNotaDePedidoDAL As New NotaDePedido_DAL
        vNotaDePedidoDAL.Consulta(pObjeto)
    End Sub

    Public Function ConsultaIncremental(ByRef pObjeto As NotaDePedido) As List(Of NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).ConsultaIncremental
        Return Nothing
    End Function

    Public Function ConsultaRango(ByRef pObjeto1 As NotaDePedido, ByRef pObjeto2 As NotaDePedido) As List(Of NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).ConsultaRango
        Return Nothing
    End Function

    Public Function ConsultaVarios(ByRef pObjeto As NotaDePedido) As List(Of NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).ConsultaVarios
        Dim vNotaDePedidoDAL As New NotaDePedido_DAL
        Return vNotaDePedidoDAL.ConsultaVarios(pObjeto)
    End Function

    Public Sub Modificacion(ByRef pObjeto As NotaDePedido) Implements INTERFACES.Iabmc(Of NotaDePedido).Modificacion
        Dim vNotaDePedidoDAL As New NotaDePedido_DAL
        vNotaDePedidoDAL.Modificacion(pObjeto)
    End Sub

End Class
