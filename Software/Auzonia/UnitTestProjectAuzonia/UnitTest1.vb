Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports SEGURIDAD

<TestClass()> Public Class UnitTest1

    <TestMethod()> Public Sub TestHash()
        'Arrange
        Dim Ingreso As String = "a"
        Dim resultado As String = "CgS5cbA9pgfObEVRhAN7Zgyon3g="
        Dim l As New SEGURIDAD.GestorCriptografia
        'Act
        Dim result As String
        result = l.Hash(Ingreso)
        'Assert
        Assert.AreEqual(resultado, result)
    End Sub

End Class