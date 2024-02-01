Imports Reglas
Public Class FrmHorarios
    Dim per As New Cl_personal
    Dim h As New Cl_horario
    Dim i As Integer = 0
    Private Sub rbtodos_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbtodos.CheckedChanged
        If Me.rbtodos.Checked = True Then
            Me.ListView1.CheckBoxes = False
        Else
            Me.ListView1.CheckBoxes = True
        End If
    End Sub

    Private Sub rbpersonal_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbpersonal.CheckedChanged
        If Me.rbpersonal.Checked = True Then
            Me.ListView1.CheckBoxes = True
        Else
            Me.ListView1.CheckBoxes = False
        End If
    End Sub

    Private Sub FrmHorarios_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        per.listar("", ListView1)
        h.listarhorario(Me.ListView2)
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub
    Private Sub ListView2_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView2.DoubleClick
        Me.LBLCODIGO.Text = Me.ListView2.SelectedItems(0).SubItems(0).Text
        Me.LBLINGRESO.Text = Me.ListView2.SelectedItems(0).SubItems(1).Text
        Me.LBLSALIDA.Text = Me.ListView2.SelectedItems(0).SubItems(2).Text
        Me.LBLDESCRIPCION.Text = Me.ListView2.SelectedItems(0).SubItems(3).Text
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If rbtodos.Checked = True Then
            If MsgBox("¿Desea aplicar este mismo horario para todo el personal?", vbYesNo) = DialogResult.Yes Then
                For i = 0 To Me.ListView1.Items.Count - 1
                    h.deletehorario(Me.ListView1.Items(i).SubItems(0).Text)
                Next
                For i = 0 To Me.ListView1.Items.Count - 1
                    h.Altahorario(Me.ListView1.Items(i).SubItems(0).Text, Me.LBLCODIGO.Text)
                Next
            End If
           
        ElseIf rbpersonal.Checked = True Then
            If MsgBox("¿Desea aplicar este mismo horario para el personal seleccionado?", vbYesNo) = DialogResult.Yes Then
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items(i).Checked = True Then
                        h.deletehorario(Me.ListView1.Items(i).SubItems(0).Text)
                    End If
                Next
                For i = 0 To Me.ListView1.Items.Count - 1
                    If Me.ListView1.Items(i).Checked = True Then
                        h.Altahorario(Me.ListView1.Items(i).SubItems(0).Text, Me.LBLCODIGO.Text)
                    End If
                Next
            End If
        End If
    End Sub
End Class