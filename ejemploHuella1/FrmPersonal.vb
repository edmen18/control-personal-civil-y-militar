Imports Reglas
Public Class FrmPersonal
    Dim esp As New Cl_Especialidad
    Dim tp As New Cl_TipoPersonal
    Dim p As New Cl_personal
    Dim ar As New Cl_area
    Dim FLG As Integer = 0
    Private Sub FrmPersonal_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        esp.cargarespecialidades(Me.cmbespecialidad)
        ar.cargararea(cmbarea)
        tp.cargartipos(cmbtipo)
        Me.GroupBox1.Enabled = False
        Me.GroupBox2.Enabled = False
        p.ListarACTIVOS(Me.GCPERSONAL)
    End Sub

    Private Sub cmbtipo_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbtipo.SelectedIndexChanged
      
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.txtdni.Text = "" Or Me.txtnombres.Text = "" Or Me.txtapematerno.Text = "" Or Me.txtapepaterno.Text = "" Then
            MessageBox.Show("Complete los datos antes de continuar", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            p.DocIdentidad = Me.txtdni.Text
            p.Nombres = Me.txtnombres.Text
            p.ApellidoPaterno = Me.txtapepaterno.Text
            p.ApellidoMaterno = Me.txtapematerno.Text
            p.Especialidad = Me.cmbespecialidad.SelectedValue.ToString
            p.Subtipo = Me.cmbtipo.SelectedValue.ToString
            p.Area = CInt(Me.cmbarea.SelectedValue.ToString)
            If FLG = 0 Then
                If p.AltaPersonal = True Then
                    CANCELAR()
                End If
            ElseIf FLG = 1 Then
                If p.UpdatePersonal = True Then
                    CANCELAR()
                End If
            End If
        End If
       
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.GroupBox1.Enabled = True
        Me.GroupBox2.Enabled = True
        FLG = 0
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        CANCELAR()
    End Sub
    Sub CANCELAR()
        Me.txtapematerno.ResetText()
        Me.txtapepaterno.ResetText()
        Me.txtdni.ResetText()
        Me.txtnombres.ResetText()
        Me.txtdni.Enabled = True
        p.ListarACTIVOS(Me.GCPERSONAL)
        Me.GroupBox1.Enabled = False
        Me.GroupBox2.Enabled = False
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub GCPERSONAL_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles GCPERSONAL.DoubleClick
        Me.txtdni.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(0).ToString)
        Me.txtnombres.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(1).ToString)
        Me.txtapepaterno.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(2).ToString)
        Me.txtapematerno.Text = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(3).ToString)
        Me.cmbespecialidad.SelectedValue = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(4).ToString)
        Me.cmbtipo.SelectedValue = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(6).ToString)
        Me.cmbarea.SelectedValue = GridView1.GetRowCellValue(GridView1.GetSelectedRows().GetValue(0), GridView1.Columns(8)).ToString
        Me.GroupBox1.Enabled = True
        Me.GroupBox2.Enabled = True
        Me.txtdni.Enabled = False
        FLG = 1
    End Sub
End Class