Imports Reglas
Imports Reportes
Public Class FrmTodos
    Dim ASI As New Cl_ASISTENCIA
    Dim per As New Cl_personal
    Dim cimp As New C_imprime
    Private Sub FrmTodos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cr As New XtraReport2
        cimp.reporte(ASI.REPORTEFECHAStodos(Me.DateTimePicker1.Value.Date, Me.DateTimePicker2.Value.Date), cr, "", RbPrincipal)

    End Sub
End Class