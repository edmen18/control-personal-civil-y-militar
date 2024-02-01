Imports Reglas
Imports DevExpress.XtraCharts
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraCharts.Wizard
Public Class FrmEstadisticoPermisos
    Dim v As New Cl_permisos
    Private Sub FrmEstadisticoPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChartControl1.DataSource = v.graficoPermisos(lblanio.Text, lblmes.Text)
    End Sub
End Class