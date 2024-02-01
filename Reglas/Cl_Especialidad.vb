Imports Datos
Imports System.Windows.Forms
Public Class Cl_Especialidad
    Dim cfun As New cFuncionesDB
    Private _codespecialidad As Integer
    Public Property CodEspecialidad() As Integer
        Get
            Return _codespecialidad
        End Get
        Set(ByVal value As Integer)
            _codespecialidad = value
        End Set
    End Property
    Private _especialidad As String
    Public Property Especialidad() As String
        Get
            Return _especialidad
        End Get
        Set(ByVal value As String)
            _especialidad = value
        End Set
    End Property
    Private _abreviatura As String
    Public Property Abreviatura() As String
        Get
            Return _abreviatura
        End Get
        Set(ByVal value As String)
            _abreviatura = value
        End Set
    End Property
    Sub cargarespecialidades(ByRef combo As ComboBox)
        Dim csql As String = "select cod_especialidad, descripcion from especialidades"
        cfun.FillListaOrCombo(csql, combo, "descripcion", "cod_especialidad")
    End Sub
    Public Function cargarESPECIALIDADdgv(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select cod_ESPECIALIDAD, descripcion,ABREVIATURA from ESPECIALIDADes where estado='1' order by descripcion")

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

    Public Function AltaESPECIALIDAD() As Boolean
        Try
            Dim csql As String = "Insert into ESPECIALIDADes(cod_ESPECIALIDAD,descripcion,ABREVIATURA,estado) values ('" + Me.CodEspecialidad.ToString + "','" + Me.Especialidad.ToString + "','" + Abreviatura.ToString + "','true')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta esta Especialidad", "Insercion de Especialidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Especialidad" + ex.ToString, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateESPECIALIDAD() As Boolean
        Try
            Dim csql As String = "UPDATE ESPECIALIDADES SET descripcion='" + Me.Especialidad.ToString + "',ABREVIATURA='" + Me.Abreviatura + "' WHERE cod_ESPECIALIDAD='" + Me.CodEspecialidad.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Actualizar esta Especialidad", "Insercion de Especialidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Especialidad" + ex.ToString, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deleteespecialidad() As Boolean
        Try
            Dim csql As String = "UPDATE ESPECIALIDADES SET estado='False' WHERE cod_ESPECIALIDAD='" + Me.CodEspecialidad.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea eliminar esta especialidad", "Especialidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
            If pregunta = DialogResult.Yes Then
                db.ConfirmarTransaccion()
                MessageBox.Show("Los datos se borraron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Return True
            Else
                db.CancelarTransaccion()
                Return False
            End If
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show("Error Alta Especialidad" + ex.ToString, "Especialidad", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Sub generar(ByVal la As Label)
        Dim csql As String = "select count(*) from especialidades"
        la.Text = CInt(cfun.ConsultaUnDato(csql, 0)) + 1
    End Sub
End Class
