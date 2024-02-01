Imports Datos
Imports System.Windows.Forms
Public Class Cl_horario
    Dim cfun As New cFuncionesDB
    Sub listarhorario(ByRef lista As ListView)
        Dim csql As String = "select COD_TURNO,horainicio,horafin,descripcion from turnos where estado='TRUE'"
        cfun.FillListview(csql, lista)
    End Sub
    Public Function Altahorario(ByVal docide As String, ByVal codturno As String) As Boolean
        Try
            Dim csql As String = "Insert into detalle_horario(nrodocidentidad,estado,cod_turno) values ('" + docide.ToString + "','True','" + codturno.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            ' Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            'pregunta = MessageBox.Show("Desea dar de Alta este tipo Personal", "Insercion de tipo Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If pregunta = DialogResult.Yes Then
            db.ConfirmarTransaccion()
            'MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            'Else
            ' db.CancelarTransaccion()
            'Return False
            'End If
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show("Error Alta tipo Personal" + ex.ToString, " tipo Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deletehorario(ByVal doc As String) As Boolean
        Try
            Dim csql As String = "UPDATE detalle_horario SET estado='False' WHERE nrodocidentidad='" + doc.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            ' Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            'pregunta = MessageBox.Show("Desea dar de Alta este tipo Personal", "Insercion de tipo Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            'If pregunta = DialogResult.Yes Then
            db.ConfirmarTransaccion()
            'MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            'Else
            ' db.CancelarTransaccion()
            'Return False
            'End If
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show("Error Alta tipo Personal" + ex.ToString, " tipo Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
