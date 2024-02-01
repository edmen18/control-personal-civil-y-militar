Imports Reglas
Imports Reportes
Public Class FrmReporteAsistencia
    Dim ASI As New Cl_ASISTENCIA
    Dim per As New Cl_personal
    Dim cimp As New C_imprime
    Private Sub FrmReporteAsistencia_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListView1.Visible = False

    End Sub

    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Me.ListView1.Visible = True
        per.listar(Me.txtdato.Text, ListView1)
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Me.txtdato.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text + Me.ListView1.SelectedItems(0).SubItems(2).Text + Me.ListView1.SelectedItems(0).SubItems(3).Text
        Me.lbldni.Text = Me.ListView1.SelectedItems(0).SubItems(0).Text
        Me.ListView1.Visible = False
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cr As New XtraReport1
        cimp.reporte(ASI.REPORTEFECHAS(Me.DateTimePicker1.Value.Date, Me.DateTimePicker2.Value.Date, lbldni.Text), cr, "Reporte de Personal", RbPrincipal)
    End Sub
End Class