Imports Reglas
Public Class FrmAsistencia
    Dim personal As New Cl_personal
    Dim xrow As Integer
    Dim i As Integer
    Dim asi As New Cl_ASISTENCIA
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        personal.ListarParaAsistencia(Me.GridControl1, Me.dtfecha.Value.Date)
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        Dim bandera As Integer = 0
        For i = 0 To GridView1.RowCount - 1
            If IsDBNull(GridView1.GetRowCellValue(i, "FECHA_SALIDA")) Then
                If asi.AltaASISTENCIACompleta(GridView1.GetRowCellValue(i, "NRODOCIDENTIDAD"), GridView1.GetRowCellValue(i, "ENTRADA"), GridView1.GetRowCellValue(i, "SALIDA"), Me.dtfecha.Value.Date, asi.GETTURNOCOMPLETO(GridView1.GetRowCellValue(i, "NRODOCIDENTIDAD"), GridView1.GetRowCellValue(i, "ENTRADA")), dtfecha.Text) = True Then
                Else
                    MsgBox("Los datos no se pudieron grabar", MsgBoxStyle.Critical)
                    bandera = 1
                    Exit For
                End If
            Else
                If asi.AltaASISTENCIACompleta(GridView1.GetRowCellValue(i, "NRODOCIDENTIDAD"), GridView1.GetRowCellValue(i, "ENTRADA"), GridView1.GetRowCellValue(i, "SALIDA"), Me.dtfecha.Value.Date, asi.GETTURNOCOMPLETO(GridView1.GetRowCellValue(i, "NRODOCIDENTIDAD"), GridView1.GetRowCellValue(i, "ENTRADA")), GridView1.GetRowCellValue(i, "FECHA_SALIDA")) = True Then
                Else
                    MsgBox("Los datos no se pudieron grabar", MsgBoxStyle.Critical)
                    bandera = 1
                    Exit For
                End If
            End If
            
        Next
        If bandera = 0 Then
            MsgBox("Los datos datos se grabaron satisfactoriamente", MsgBoxStyle.Information)
        End If
    End Sub
End Class