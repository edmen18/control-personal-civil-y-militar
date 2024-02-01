Imports Reglas
Public Class FrmEspecialidad
    Dim tipo As New Cl_Especialidad
    Dim flg As Integer = 0
    Private Sub FrmEspecialidad_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tipo.cargarESPECIALIDADdgv(Me.GridControl1)
        Me.GroupBox1.Enabled = False
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        tipo.generar(Me.lblcodigo)
        Me.txtdescripcion.ResetText()
        Me.GroupBox1.Enabled = True
        flg = 0
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.txtdescripcion.Text = "" Or Me.lblcodigo.Text = "" Then
        Else
            tipo.CodEspecialidad = Me.lblcodigo.Text
            tipo.Especialidad = Me.txtdescripcion.Text
            tipo.Abreviatura = Me.txtabreviatura.Text
            If flg = 0 Then
                tipo.AltaESPECIALIDAD()
            Else
                tipo.UpdateESPECIALIDAD()
            End If
        End If
        btncancelar.PerformClick()
    End Sub
    Private Sub GridControl1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GridControl1.Click
        flg = 1
        Me.GroupBox1.Enabled = True
        Me.lblcodigo.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(0).ToString)
        Me.txtdescripcion.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(1).ToString)
        Me.txtabreviatura.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(2).ToString)
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.txtdescripcion.ResetText()
        Me.lblcodigo.ResetText()
        Me.txtabreviatura.ResetText()
        Me.GroupBox1.Enabled = False
        tipo.cargarESPECIALIDADdgv(Me.GridControl1)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If flg = 1 Then
            tipo.CodEspecialidad = Me.lblcodigo.Text
            tipo.Especialidad = Me.txtdescripcion.Text
            tipo.Abreviatura = Me.txtabreviatura.Text
            tipo.deleteespecialidad()
            btncancelar.PerformClick()
        Else
            MsgBox("seleccione un item", MsgBoxStyle.Critical)
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

  
End Class