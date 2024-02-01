Imports Reglas
Imports DevExpress.XtraCharts
Imports System.Collections.Generic
Imports System.Data
Imports DevExpress.XtraCharts.Wizard
Public Class Form2
    Dim v As New Cl_ASISTENCIA
  
    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ChartControl1.DataSource = v.graficotardanzas(lblannio.Text, lblmes.Text)
    End Sub
End Class