Imports Reglas

Public Class FrmPermisos
    Dim per As New Cl_personal
    Dim P As New Cl_permisos
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Me.ListView1.Visible = True
        per.listar(Me.txtdato.Text, ListView1)
    End Sub

    Private Sub FrmPermisos_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListView1.Visible = False
        fechas()
        ' Me.txthorasalida.Enabled = False
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Me.txtdato.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text + Me.ListView1.SelectedItems(0).SubItems(2).Text + Me.ListView1.SelectedItems(0).SubItems(3).Text
        Me.lbldni.Text = Me.ListView1.SelectedItems(0).SubItems(0).Text
        Me.ListView1.Visible = False
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub dtal_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtal.ValueChanged
        fechas()
    End Sub
    Sub fechas()
        If Me.dtdel.Value.Date >= Now.Date And Me.dtal.Value.Date >= Now.Date Then
            If Me.dtdel.Value.Date <> Me.dtal.Value.Date Then
                Me.txtcantidad.Text = (dtal.Value.DayOfYear - dtdel.Value.DayOfYear) + 1 & " " & "dias"
            Else
                Me.txtcantidad.Text = "1" & " " & "dias"
            End If
        Else
            MsgBox("Ingrese un rango de fechas mayor o igual a la fecha actual", MsgBoxStyle.Exclamation)
            dtdel.Text = Now.Date
            dtal.Text = Now.Date
        End If
        If Me.txtcantidad.Text = "1" & " " & "dias" And Me.dtdel.Value.Date = Now.Date And Me.dtal.Value.Date = Now.Date Then
            Me.txthorasalida.Enabled = True
        Else
            Me.txthorasalida.Enabled = False
        End If
    End Sub

    Private Sub dtdel_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtdel.ValueChanged
        fechas()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.lbldni.Text = "" Or Me.txtcantidad.Text = "" Then
            MsgBox("Complete los datos antes de continuar", MsgBoxStyle.OkOnly, vbCritical)
        Else
            If Me.dtdel.Value.Date >= Now.Date And Me.dtal.Value.Date >= Now.Date Then
                If Me.dtdel.Value.Date > Me.dtal.Value.Date Then
                    MsgBox("Rango de fechas incorrecto", MsgBoxStyle.Exclamation)
                Else
                    If P.CONSULTAVACACIONES(Me.lbldni.Text, dtdel.Value.Date, dtal.Value.Date) = "" Then
                        P.AltaPermiso(Me.lbldni.Text, Me.dtdel.Value.Date, Me.dtal.Value.Date, Me.txtcantidad.Text, Me.txtmotivo.Text, Me.txthorasalida.Text)
                    Else
                        MsgBox("No es posible el registro de permisos ya que esta persona se encuentra de vacaciones", MsgBoxStyle.OkOnly, vbCritical)
                    End If
                End If
            Else
                MsgBox("Ingrese un rango de fechas mayor o igual a la fecha actual", MsgBoxStyle.Exclamation)
            End If
        End If
    End Sub
End Class