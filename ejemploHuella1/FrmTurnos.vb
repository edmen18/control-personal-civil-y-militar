Imports Reglas
Public Class FrmTurnos
    Dim horarios As New Cl_Turno
    Dim flg As Integer = 0
    Private Sub FrmTurnos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        horarios.ListarACTIVOS(Me.GridControl1)
        Me.GroupBox1.Enabled = False
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.txtdescripcion.ResetText()
        Me.GroupBox1.Enabled = True
        flg = 0
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.txtdescripcion.Text = "" Or Me.txtmarcado.Text = "" Or Me.txtinicio.Text = "" Or Me.txtfin.Text = "" Then
        Else
            If flg = 0 Then
                horarios.AltaHorario(Me.txtinicio.Text, txtfin.Text, txtmarcado.Text, Me.txtdescripcion.Text)
            End If
        End If
        btncancelar.PerformClick()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.txtdescripcion.ResetText()
        Me.lblcodigo.ResetText()
        Me.txtfin.ResetText()
        Me.txtinicio.ResetText()
        Me.txtmarcado.ResetText()
        Me.GroupBox1.Enabled = False
        horarios.ListarACTIVOS(Me.GridControl1)
        flg = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If flg = 1 Then
            horarios.deleteTurno(Me.lblcodigo.Text)
            btncancelar.PerformClick()
        Else
            MsgBox("seleccione un item", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Me.lblcodigo.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(0).ToString)
        Me.txtdescripcion.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(1).ToString)
        Me.txtinicio.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(2).ToString)
        Me.txtfin.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(3).ToString)
        Me.txtmarcado.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(4).ToString)
        flg = 1
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub
End Class