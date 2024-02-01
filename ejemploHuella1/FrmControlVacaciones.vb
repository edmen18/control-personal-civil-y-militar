Imports Reglas
Public Class FrmControlVacaciones
    Dim VAC As New Cl_Controlvacaciones
    Dim flg As Integer = 0
    Private Sub FrmControlVacaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        VAC.ListarACTIVOS(Me.GridControl1)
        Me.GroupBox1.Enabled = False
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.txtdescripcion.ResetText()
        Me.GroupBox1.Enabled = True
        flg = 0
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.txtdescripcion.Text = "" Then
        Else
            If flg = 0 Then

                VAC.AltaVacaciones(Now.Date.Year, CInt(Me.txtdescripcion.Text))
            Else
                VAC.updateVacaciones(Me.lblcodigo.Text, CInt(Me.txtdescripcion.Text))
            End If
        End If
        btncancelar.PerformClick()

    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.txtdescripcion.ResetText()
        Me.lblcodigo.ResetText()
        Me.GroupBox1.Enabled = False
        VAC.ListarACTIVOS(Me.GridControl1)
        flg = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If flg = 1 Then
            If CInt(VAC.consultardatos(Me.lblcodigo.Text)) <= 0 Then
                VAC.deleteVacaciones(Me.lblcodigo.Text)
                btncancelar.PerformClick()
            Else
                MsgBox("No es posible eliminar estos datos ya que están en uso", MsgBoxStyle.Critical)
            End If
                    Else
            MsgBox("seleccione un item", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        Me.lblcodigo.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(0).ToString)
        Me.txtdescripcion.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(1).ToString)
        flg = 1
    End Sub
End Class