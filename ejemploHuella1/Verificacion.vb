Imports System.Text
Imports System.IO
Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.SqlTypes
Imports DPFP
Imports Reglas
Public Class Verificacion
    Dim cn As New SqlConnection("Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDPRUEBA;Data Source=EDGAR-PC\SQLEXPRESS")
    Public TempRecuperada As Byte() = Nothing
    Dim cm As New SqlCommand
    Dim i As Integer
    Dim ASI As New CL_ASISTENCIA
    'Private Sub VerificationControl_OnComplete(ByVal Control As Object, ByVal FeatureSet As DPFP.FeatureSet, ByRef EventHandlerStatus As DPFP.Gui.EventHandlerStatus) Handles VerificationControl.OnComplete
    '    Dim ver As New DPFP.Verification.Verification()
    '    Dim res As New DPFP.Verification.Verification.Result()
    '    Dim tempRec As DPFP.Template
    '    Dim tama As Integer
    '    Dim strConnect As String
    '    Dim ret As New DataSet
    '    Dim tamaño As Integer
    '    tempRec = New DPFP.Template()
    '    For i = 0 To Me.lsthuella.Items.Count - 1
    '        Me.LBLDATO.ResetText()
    '        ret.Clear()
    '        strConnect = "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BDPRUEBA;Data Source=EDGAR-PC\SQLEXPRESS"
    '        Dim conn As SqlConnection = New SqlConnection(strConnect)
    '        Dim Str_consulta As String = "select nombres+' '+apellidopaterno+' '+apellidomaterno,huelladigital,NroDocIdentidad from PERSONAL where NroDocIdentidad= '" + Me.lsthuella.Items(i).SubItems(0).Text + "'"
    '        Dim myCommand As SqlCommand = New SqlCommand(Str_consulta, conn)
    '        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''
    '        Try
    '            conn.Open()
    '            Dim AdaptadorSQL As New SqlDataAdapter

    '            myCommand.CommandTimeout = 600
    '            AdaptadorSQL.SelectCommand = myCommand
    '            AdaptadorSQL.Fill(ret)

    '            If Not (ret.Tables(0).Rows.Count = 0) Then
    '                TempRecuperada = ret.Tables(0).Rows(0).Item(1)
    '                tamaño = TempRecuperada.Length
    '                Me.LBLDATO.Text = ret.Tables(0).Rows(0).Item(0)
    '                Me.lblcodigo.Text = ret.Tables(0).Rows(0).Item(2)
    '            Else
    '                Me.LBLDATO.Text = ""
    '                Me.lblcodigo.Text = ""
    '                Me.lblnhc.Text = ""
    '            End If
    '            conn.Close()

    '        Catch SQLexc As SqlException
    '            MsgBox(SQLexc.ToString)
    '        End Try
    '        If Not (TempRecuperada Is Nothing) Then
    '            tempRec.DeSerialize(TempRecuperada)
    '            tama = tempRec.Size
    '            If Not tempRec Is Nothing Then                     '   Get template from storage.
    '                ver.Verify(FeatureSet, tempRec, res)           '   Compare feature set with particular template.
    '                If res.Verified Then
    '                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Success
    '                    LBLDATO.Text = ret.Tables(0).Rows(0).Item(0)
    '                    Me.lblcodigo.Text = ret.Tables(0).Rows(0).Item(2)
    '                    verificar()
    '                    Exit For
    '                Else
    '                    EventHandlerStatus = DPFP.Gui.EventHandlerStatus.Failure
    '                    Me.LBLDATO.Text = ""
    '                    Me.lblcodigo.Text = ""
    '                    Me.lblnhc.Text = ""
    '                End If
    '            End If
    '        End If
    '    Next
    '    If lblcodigo.Text = "" Or Me.LBLDATO.Text = "" Then
    '        Me.Label1.Text = "ERROR: INTENTE DE NUEVO POR FAVOR"
    '        Me.Label1.BackColor = Color.Red
    '    End If
    'End Sub
    Sub verificar()
        ASI.GETTURNO(Me.LBLTURNO, Me.lblcodigo.Text)
        ASI.VERIFICARASISTENCIADELDIA(Me.lblcodigo.Text, Now.Date, Me.LBLHORA)
        If Me.LBLHORA.Text = "" Then
            If LBLTURNO.Text = "" Then
                Me.Label1.Text = "ERROR: INTENTE MAS TARDE POR FAVOR...AUN NO ES HORA DE MARCAR"
            Else
                If ASI.AltaASISTENCIA(Me.lblcodigo.Text, Microsoft.VisualBasic.Left(Now.TimeOfDay.ToString, 8), Microsoft.VisualBasic.Left(Now.TimeOfDay.ToString, 8), Now.Date.ToString, Me.LBLTURNO.Text) = True Then
                    Me.Label1.Text = "DATOS ALMACENADOS SATISFACTORIAMNETE"
                    Me.Label1.BackColor = Color.Blue
                Else
                    Me.Label1.Text = "ERROR: INTENTE DE NUEVO POR FAVOR"
                    Me.Label1.BackColor = Color.Red
                End If
            End If
        Else
            ASI.CONTARCUANTOSHAY(Me.lblcodigo.Text, Now.Date, Me.LBLHORA)
            If CInt(Me.LBLHORA.Text) = 1 Then
                If ASI.UpdateASISTENCIA(Me.lblcodigo.Text, Microsoft.VisualBasic.Left(Now.TimeOfDay.ToString, 8), Now.Date.ToString) = True Then
                    Me.Label1.Text = "DATOS ALMACENADOS SATISFACTORIAMNETE"
                    Me.Label1.BackColor = Color.Blue
                Else
                    Me.Label1.Text = "ERROR: INTENTE DE NUEVO POR FAVOR"
                    Me.Label1.BackColor = Color.Red
                End If
            ElseIf CInt(Me.LBLHORA.Text) = 0 Then
                If LBLTURNO.Text = "" Then
                    Me.Label1.Text = "ERROR: INTENTE MAS TARDE POR FAVOR...AUN NO ES HORA DE MARCAR"
                Else
                    If ASI.AltaASISTENCIA(Me.lblcodigo.Text, Microsoft.VisualBasic.Left(Now.TimeOfDay.ToString, 8), Microsoft.VisualBasic.Left(Now.TimeOfDay.ToString, 8), Now.Date.ToString, Me.LBLTURNO.Text) = True Then
                        Me.Label1.Text = "DATOS ALMACENADOS SATISFACTORIAMNETE"
                        Me.Label1.BackColor = Color.Blue
                    Else
                        Me.Label1.Text = "ERROR: INTENTE DE NUEVO POR FAVOR"
                        Me.Label1.BackColor = Color.Red
                    End If
                End If
            End If
        End If

    End Sub
    Private Sub Verificacion_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.lsthuella.Visible = True
        Try
            Me.lsthuella.Items.Clear()
            Dim datar As SqlClient.SqlDataReader
            cn.Open()
            cm.Connection = cn
            cm.CommandText = "select NroDocIdentidad from dbo.PERSONAL"
            cm.CommandType = CommandType.Text
            datar = cm.ExecuteReader
            Dim I As Integer = 0
            If datar.HasRows Then
                While datar.Read
                    Me.lsthuella.Items.Add(CStr((datar(0))), 1)
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

    Private Sub btnenviar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub
End Class