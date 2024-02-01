Imports System.Data
Imports System.Data.SqlClient
Public Class Form1
   
    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnver.Click
        Dim cn As New SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDPRUEBA;Data Source=EDGAR-PC\SQLEXPRESS")
        Dim cm As New SqlCommand
        Me.lstpaciente.Visible = True
        Try
            Me.lstpaciente.Items.Clear()
            Dim datar As SqlClient.SqlDataReader
            cn.Open()
            cm.Connection = cn
            If Me.RbDoc.Checked = True Then
                cm.CommandText = "select NroDocIdentidad,Nombres,ApellidoPaterno,ApellidoMaterno from dbo.PERSONAL where NroDocIdentidad like '%" & Me.TXTDATO.Text & "%'"
            ElseIf Rbna.Checked = True Then
                cm.CommandText = "select NroDocIdentidad,Nombres,ApellidoPaterno,ApellidoMaterno from dbo.PERSONAL where Nombres+' '+ApellidoPaterno+' '+ApellidoMaterno like '%" & Me.TXTDATO.Text & "%'"
            End If
            cm.CommandType = CommandType.Text
            datar = cm.ExecuteReader
            Dim I As Integer = 0
            If datar.HasRows Then
                While datar.Read
                    Me.lstpaciente.Items.Add(CStr((datar(0))), 1)
                    Me.lstpaciente.Items(I).SubItems.Add(CStr(datar(1).ToString))
                    Me.lstpaciente.Items(I).SubItems.Add(CStr(datar(2).ToString))
                    Me.lstpaciente.Items(I).SubItems.Add(CStr(datar(3).ToString))
                    ' Me.lstpaciente.Items(I).SubItems.Add(CStr(datar(4).ToString))
                    I += 1
                End While
            End If
            datar.Close()
            cn.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical)
            cn.Close()
        End Try
    End Sub

    Private Sub lstpaciente_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstpaciente.DoubleClick
        If Me.lstpaciente.SelectedItems.Count > 0 Then
            Me.lblcodigo.Text = Me.lstpaciente.SelectedItems(0).SubItems(0).Text
            Me.lblnombre.Text = Me.lstpaciente.SelectedItems(0).SubItems(1).Text
            Me.lblpaterno.Text = Me.lstpaciente.SelectedItems(0).SubItems(2).Text
            Me.lblmaterno.Text = Me.lstpaciente.SelectedItems(0).SubItems(3).Text
        End If
    End Sub

    'Private Sub EnrollmentControl_OnEnroll(ByVal Control As Object, ByVal FingerMask As Integer, ByVal Template As DPFP.Template, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles EnrollmentControl.OnEnroll
    '    If Me.lblcodigo.Text = "" Then
    '        MessageBox.Show("Complete los datos antes de continuar", "SHC", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Else
    '        Dim temBytes As Byte() = Nothing
    '        Template.Serialize(temBytes)
    '        Me.guardar(temBytes)
    '    End If
    '    cancelar()
    'End Sub

    Sub guardar(ByVal TemplateBytes As Byte())
        Dim strConnect As String
        strConnect = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDPRUEBA;Data Source=EDGAR-PC\SQLEXPRESS"
        Dim conn As SqlConnection = New SqlConnection(strConnect)

        Dim strSql As String = "update PERSONAL set HuellaDigital=@Temple where NroDocIdentidad='" + Me.lblcodigo.Text + "'"

        Dim cmd As SqlCommand = New SqlCommand(strSql, conn)

        ' aqui coloco el parametro de template
        Dim Temple As SqlParameter = New SqlParameter("@Temple", SqlDbType.Binary)
        Temple.Value = TemplateBytes
        cmd.Parameters.Add(Temple)

        Try
            conn.Open()
            cmd.ExecuteNonQuery()
            conn.Close()
            MessageBox.Show("Huella Digital Registrada Con exito", "SHC")
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString(), "Data Error")
            Exit Sub
        End Try
    End Sub
    Sub cancelar()
        Me.TXTDATO.ResetText()
        Me.lblcodigo.ResetText()
        Me.lblidentidad.ResetText()
        Me.lblmaterno.ResetText()
        Me.lblnombre.ResetText()
        Me.lblpaterno.ResetText()
        Me.lstpaciente.Items.Clear()
    End Sub

    Private Sub btncancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btncancelar.Click
        cancelar()
    End Sub
End Class
