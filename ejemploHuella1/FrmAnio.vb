Imports Reglas
Imports Reportes
Public Class FrmAnio
    Dim cimp As New C_imprime
    Dim vac As New Cl_vacaciones
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cr As New XRAnnio
        cimp.reporte(vac.REPORTEanio("", Me.NumericUpDown1.Value.ToString), cr, "Reporte por año", RbPrincipal)
    End Sub
End Class