Imports Reglas
Imports Reportes
Public Class FrmVacaciones
    Dim per As New Cl_personal
    Dim vac As New Cl_vacaciones
    Dim cvac As New Cl_Controlvacaciones
    Dim i As Integer
    Dim agregar As Integer = 0
    Private Sub btnbuscar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnbuscar.Click
        Me.ListView1.Visible = True
        per.listar(Me.txtdato.Text, ListView1)
    End Sub
    Sub sumardias(ByRef lbl As Label)
        lbl.Text = "0"
        lbl.Text = CInt(lbllimite.Text) - CInt(Me.LookUpEdit1.GetColumnValue("SALDO"))
    End Sub
    Private Sub FrmVacaciones_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.ListView1.Visible = False
        Me.GroupBox1.Enabled = False
        Me.GroupBox2.Enabled = False
        Me.GroupBox3.Enabled = False
        Me.GroupBox4.Enabled = False
    End Sub

    Private Sub ListView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListView1.DoubleClick
        Me.txtdato.Text = Me.ListView1.SelectedItems(0).SubItems(1).Text + Me.ListView1.SelectedItems(0).SubItems(2).Text + Me.ListView1.SelectedItems(0).SubItems(3).Text
        Me.lbldni.Text = Me.ListView1.SelectedItems(0).SubItems(0).Text
        Me.ListView1.Visible = False
        cvac.cargarvacacionescmb(Me.LookUpEdit1, Me.lbldni.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If Me.dtdel.Value.Date > Me.dtal.Value.Date Then
            MsgBox("la fecha de inicio debe ser menor o igual a la fecha de fin ", MsgBoxStyle.Exclamation)
        Else
            validar()
            If agregar = 1 Then
            Else
                Dim c As Integer
                c = Me.ListView2.Items.Count
                Me.ListView2.Items.Add(Me.dtdel.Text)
                Me.ListView2.Items(c).SubItems.Add(Me.dtal.Text)
                Me.ListView2.Items(c).SubItems.Add((Me.dtal.Value.DayOfYear) - (Me.dtdel.Value.DayOfYear) + 1)
                'sumardias(ListView2, Me.lbldiasportomar)
            End If
            totaldias()
        End If
    End Sub
    Sub validar()
        agregar = 0
        For i = 0 To Me.ListView3.Items.Count - 1
            If Me.dtdel.Value.Date >= CDate(Me.ListView3.Items(i).SubItems(0).Text) And Me.dtdel.Value.Date <= CDate(Me.ListView3.Items(i).SubItems(1).Text) Then
                MsgBox("Las fechas ingresadas no son validas ", MsgBoxStyle.Exclamation)
                agregar = 1
                Exit For
            End If
            If Me.dtal.Value.Date >= CDate(Me.ListView3.Items(i).SubItems(0).Text) And Me.dtal.Value.Date <= CDate(Me.ListView3.Items(i).SubItems(1).Text) Then
                MsgBox("Las fechas ingresadas no son validas ", MsgBoxStyle.Exclamation)
                agregar = 1
                Exit For
            End If
        Next
        For i = 0 To Me.ListView2.Items.Count - 1
            If Me.dtdel.Value.Date >= CDate(Me.ListView2.Items(i).SubItems(0).Text) And Me.dtdel.Value.Date <= CDate(Me.ListView2.Items(i).SubItems(1).Text) Then
                MsgBox("Las fechas ingresadas no son validas ", MsgBoxStyle.Exclamation)
                agregar = 1
                Exit For
            End If
            If Me.dtal.Value.Date >= CDate(Me.ListView2.Items(i).SubItems(0).Text) And Me.dtal.Value.Date <= CDate(Me.ListView2.Items(i).SubItems(1).Text) Then
                MsgBox("Las fechas ingresadas no son validas ", MsgBoxStyle.Exclamation)
                agregar = 1
                Exit For
            End If
        Next
    End Sub
    Sub totaldias()
        Me.lbldiasportomar.Text = "0"
        For i = 0 To Me.ListView2.Items.Count - 1
            Me.lbldiasportomar.Text = CInt(Me.lbldiasportomar.Text) + CInt(Me.ListView2.Items(i).SubItems(2).Text)
        Next
        Me.lbltotaldias.Text = CInt(Me.lbldiasportomar.Text) + CInt(Me.lbldiastomados.Text)
        Me.lblquedan.Text = CInt(Me.lbllimite.Text) - CInt(Me.lbltotaldias.Text)
        If CInt(Me.lblquedan.Text) < 0 Then
            MsgBox("Debe seleccionar un numero menor de dias", MsgBoxStyle.Exclamation)
            Me.ListView2.Items.Clear()
            Me.lbldiasportomar.Text = "0"
            Me.lbltotaldias.Text = "0"
            Me.lblquedan.Text = "0"
        End If
    End Sub

    Private Sub btnsalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnsalir.Click
        Me.Close()
    End Sub

    Private Sub btnnuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnnuevo.Click
        Me.GroupBox1.Enabled = True
        Me.GroupBox2.Enabled = True
        Me.GroupBox3.Enabled = True
        Me.GroupBox4.Enabled = True
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        Me.GroupBox1.Enabled = False
        Me.GroupBox2.Enabled = False
        Me.GroupBox3.Enabled = False
        Me.GroupBox4.Enabled = False
        Me.lbltotaldias.Text = "0"
        Me.lblquedan.Text = "0"
        Me.lbldni.ResetText()
        Me.lbldiastomados.Text = "0"
        Me.lbldiasportomar.Text = "0"
        Me.txtdato.ResetText()
        Me.ListView2.Items.Clear()
        Me.ListView3.Items.Clear()
    End Sub

    Private Sub btngrabar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btngrabar.Click
        If Me.lblcodlim.Text = "" Or Me.lbldni.Text = "" Then
        Else
            For i = 0 To Me.ListView2.Items.Count - 1
                vac.Altavacaciones(Me.lblcodlim.Text, Me.lbldni.Text, Me.ListView2.Items(i).SubItems(0).Text, Me.ListView2.Items(i).SubItems(1).Text, Me.ListView2.Items(i).SubItems(2).Text)
            Next
            vac.UpdateDiasVacaciones(Me.lbldni.Text, Me.LookUpEdit1.EditValue.ToString, CInt(Me.lblquedan.Text), CInt(Me.lbltotaldias.Text))
            Me.btncancelar.PerformClick()
        End If
    End Sub

    Private Sub ListView1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListView1.SelectedIndexChanged

    End Sub

    Private Sub LookUpEdit1_EditValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LookUpEdit1.EditValueChanged
        Me.ListView2.Items.Clear()
        Me.ListView3.Items.Clear()
        Me.lbldiasportomar.Text = "0"
        Me.lbltotaldias.Text = "0"
        Me.lblquedan.Text = "0"
        vac.listarvacaciones(Me.ListView3, Me.lbldni.Text, Me.LookUpEdit1.GetColumnValue("CODIGO"))
        vac.limitevacaciones(Me.lblcodlim, Me.lbllimite, Me.LookUpEdit1.GetColumnValue("CODIGO"))
        sumardias(Me.lbldiastomados)
    End Sub
End Class