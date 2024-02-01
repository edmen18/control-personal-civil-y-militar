Imports CrystalDecisions
Imports System.IO
Public Class C_imprime
    Dim frmrep As New FrmReportes
    Sub reporte(ByVal dsobj As System.Data.DataSet, ByVal report As Object, ByVal titulo As String, ByRef principal As Object)
        Try
            Dim frmrepDev As New FrmReportes
            report.DataSource = dsobj
            report.CreateDocument()
            frmrepDev.Text = titulo
            frmrepDev.PrintControl1.PrintingSystem = report.PrintingSystem
            frmrepDev.MdiParent = principal
            frmrepDev.Show()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
