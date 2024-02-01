Imports Reglas
Imports Reportes
Public Class Frmvpersona
    Dim ASI As New Cl_vacaciones
    Dim per As New Cl_personal
    Dim cimp As New C_imprime
    Private Sub Frmvpersona_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim cr As New XRVacacionesxpersona
        cimp.reporte(ASI.REPORTEPersonal(Me.lbldni.Text, Me.NumericUpDown1.Value.ToString), cr, "", RbPrincipal)
    End Sub
End Class