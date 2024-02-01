Imports CrystalDecisions
Imports System.IO
Public Class Cl_imprime
    Dim frmrep As New Frmreport
    Sub reporte(ByVal dsobj As System.Data.DataSet, ByVal report As CrystalReports.Engine.ReportClass)
        report.SetDataSource(dsobj)
        report.Refresh()
        frmrep.CrystalReportViewer1.ReportSource = report
        frmrep.CrystalReportViewer1.RefreshReport()
        frmrep.ShowDialog()
    End Sub
End Class
