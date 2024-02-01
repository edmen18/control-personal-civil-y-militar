Imports Datos
Imports System.Windows.Forms
Public Class Cl_Controlvacaciones
    Dim cfun As New cFuncionesDB
    Public Function consultardatos(ByVal codigo As String)
        Dim csql As String = "select count(*) from vacaciones where codigo='" + codigo.ToString + "'"
        Return cfun.ConsultaUnDato(csql, 0)
    End Function
    Public Function ListarACTIVOS(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select * from control_vacaciones where annio=year(getdate())")

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

    Public Function AltaVacaciones(ByVal annio As String, ByVal numerodias As Integer) As Boolean
        Try
            Dim csql As String = "Insert into control_vacaciones (codigo,numerodias,annio) values ((select max(codigo)+1 from control_vacaciones),'" + numerodias.ToString + "','" + annio.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta estos Datos", "Insercion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta" + ex.ToString, "Vacaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function updateVacaciones(ByVal codigo As String, ByVal numerodias As Integer) As Boolean
        Try
            Dim csql As String = "UPDATE control_vacaciones SET numerodias='" + numerodias.ToString + "' WHERE codigo='" + codigo.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Actualizar estos Datos", "Actualizacion de Datos", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta" + ex.ToString, "Vacaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deleteVacaciones(ByVal codigo As String) As Boolean
        Try
            Dim csql As String = "DELETE control_vacaciones WHERE codigo='" + codigo.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Eliminar estos Datos", "Eliminacion", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error" + ex.ToString, "SHD", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function cargarvacacionescmb(ByRef oCombo As Object, ByVal dni As String) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select c.codigo AS CODIGO, v.annio as AÑO,diassaldo AS SALDO from CONTROL_VACACIONES v inner join CONTADOR c on  v.CODIGO=c.CODIGO where NRODOCIDENTIDAD='" + dni + "' and DIASSALDO >0 order by ANNIO desc")
            Try
                dt.Load(db.EjecutarConsulta())
                oCombo.Properties.DataSource = dt
                oCombo.Properties.ValueMember = "CODIGO"
                oCombo.Properties.DisplayMember = "SALDO"
                oCombo.Properties.DisplayMember = "AÑO"

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

End Class
