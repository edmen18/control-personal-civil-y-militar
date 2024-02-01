Imports Datos
Imports System.Windows.Forms
Public Class Cl_Turno
    Dim cfun As New cFuncionesDB
    Public Function ListarACTIVOS(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select COD_TURNO,DESCRIPCION,left(HORAINICIO,5)as HORA_INICIO,left(HORAFIN,5) as HORA_FIN,left(HORAMARCADO,5)AS HORA_MARCADO from dbo.TURNOS where ESTADO='true'")
            Try
                dt.Load(db.EjecutarConsulta())
                oDgv.DataSource = dt
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
            db.Desconectar()
            Return True

        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            db.CancelarTransaccion()
            db.Desconectar()
            Return False
        End Try
    End Function
    Public Function AltaHorario(ByVal horainicio As String, ByVal horafin As String, ByVal horamarcado As String, ByVal descripcion As String) As Boolean
        Try
            Dim csql As String = "Insert into TURNOS (COD_TURNO,HORAINICIO,HORAFIN,HORAMARCADO,ESTADO,DESCRIPCION) VALUES ((SELECT MAX(COD_TURNO)+1 FROM TURNOS),'" + horainicio.ToString + "','" + horafin.ToString + "','" + horamarcado.ToString + "','TRUE','" + descripcion.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta este Horario", "Insercion de Horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If pregunta = DialogResult.Yes Then
                db.ConfirmarTransaccion()
                MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                db.CancelarTransaccion()
                Return False
            End If
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show("Error Alta Horario" + ex.ToString, "Horario", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deleteTurno(ByVal codigo As Integer) As Boolean
        Try
            Dim csql As String = "update TURNOS set ESTADO='FALSE' where COD_TURNO='" + codigo.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Eliminar este Horario", "Eliminacion de Horario", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If pregunta = DialogResult.Yes Then
                db.ConfirmarTransaccion()
                MessageBox.Show("Los datos se eliminaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                db.CancelarTransaccion()
                Return False
            End If
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show("Error Eliminacion Horario" + ex.ToString, "Horario", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
End Class
