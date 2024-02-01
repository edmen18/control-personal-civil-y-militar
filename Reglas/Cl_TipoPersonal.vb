Imports Datos
Imports System.Windows.Forms
Public Class Cl_TipoPersonal
    Dim cfun As New cFuncionesDB
    Private _codtipo As Integer
    Public Property CodTipoPersonal() As Integer
        Get
            Return _codtipo
        End Get
        Set(ByVal value As Integer)
            _codtipo = value
        End Set
    End Property
    Private _descripcion As String
    Public Property Descripcion() As String
        Get
            Return _descripcion
        End Get
        Set(ByVal value As String)
            _descripcion = value
        End Set
    End Property
    Sub cargartipos(ByRef combo As ComboBox)
        Dim csql As String = "select cod_tipopersonal, descripcion from tipo_personal where estado='1'"
        cfun.FillListaOrCombo(csql, combo, "descripcion", "cod_tipopersonal")
    End Sub
    Public Function cargartiposdgv(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select cod_tipopersonal, descripcion from tipo_personal where estado='1' order by descripcion")

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
    Public Function AltaPersonal() As Boolean
        Try
            Dim csql As String = "Insert into tipo_personal(cod_tipopersonal,descripcion,estado) values ('" + Me.CodTipoPersonal.ToString + "','" + Me.Descripcion.ToString + "','true')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta este tipo Personal", "Insercion de tipo Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta tipo Personal" + ex.ToString, " tipo Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdatePersonal(ByVal CODIGO As String, ByVal DESC As String) As Boolean
        Try
            Dim csql As String = "UPDATE tipo_personal SET descripcion='" + Me.Descripcion.ToString + "' WHERE cod_tipopersonal='" + Me.CodTipoPersonal.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta este tipo Personal", "Insercion de tipo Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta tipo Personal" + ex.ToString, " tipo Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deletePersonal() As Boolean
        Try
            Dim csql As String = "UPDATE tipo_personal SET estado='False' WHERE cod_tipopersonal='" + Me.CodTipoPersonal.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea eliminar este tipo Personal", "Tipo Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta tipo Personal" + ex.ToString, " tipo Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Sub generar(ByVal la As Label)
        Dim csql As String = "select count(*) from tipo_personal"
        la.Text = CInt(cfun.ConsultaUnDato(csql, 0)) + 1
    End Sub

End Class
