Public Interface Iabmc(Of T)

    Sub Alta(ByRef pObjeto As T)
    Sub Baja(ByRef pObjeto As T)
    Sub Modificacion(ByRef pObjeto As T)
    Sub Consulta(ByRef pObjeto As T)
    Function ConsultaRango(ByRef pObjeto1 As T, ByRef pObjeto2 As T) As List(Of T)
    Function ConsultaIncremental(ByRef pObjeto As T) As List(Of T)
    Function ConsultaVarios(ByRef pObjeto As T) As List(Of T)

End Interface
