Imports Reglas
Public Class FrmAreas
    Dim ar As New Cl_area
    Dim flg As Integer = 0
    Private Sub FrmAreas_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ar.cargarareadgv(Me.GridControl1)
        Me.GroupBox1.Enabled = False
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        ar.generar(Me.lblcodigo)
        Me.txtdescripcion.ResetText()
        Me.GroupBox1.Enabled = True
        flg = 0
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.txtdescripcion.Text = "" Or Me.lblcodigo.Text = "" Then
        Else
            If flg = 0 Then
              
                ar.AltaArea(Me.lblcodigo.Text, Me.txtdescripcion.Text)
            Else
                ar.UpdateArea(Me.lblcodigo.Text, Me.txtdescripcion.Text)
            End If
        End If
        btncancelar.PerformClick()
    End Sub
    Private Sub GridControl1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GridControl1.DoubleClick
        flg = 1
        Me.GroupBox1.Enabled = True
        Me.lblcodigo.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(0).ToString)
        Me.txtdescripcion.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(1).ToString)
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.txtdescripcion.ResetText()
        Me.lblcodigo.ResetText()
        Me.GroupBox1.Enabled = False
        ar.cargarareadgv(Me.GridControl1)
        flg = 0
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If flg = 1 Then
            ar.deleteespecialidad(Me.lblcodigo.Text)
            btncancelar.PerformClick()
        Else
            MsgBox("seleccione un item", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

   
End Class