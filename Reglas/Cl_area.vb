Imports Datos
Imports System.Windows.Forms
Public Class Cl_area
    Dim cfun As New cFuncionesDB
    Sub cargararea(ByRef dgv As ComboBox)
        Dim csql As String = "select cod_area, descripcion_a from area where estado='1'"
        cfun.FillListaOrCombo(csql, dgv, "descripcion_a", "cod_area")
    End Sub
    Public Function cargarareacmb(ByRef oCombo As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select cod_area, descripcion_a from area where estado='1'")
            Try
                dt.Load(db.EjecutarConsulta())
                oCombo.Edit.DataSource = dt
                oCombo.Edit.ValueMember = "cod_area"
                oCombo.Edit.DisplayMember = "descripcion_a"

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
    Public Function cargarareadgv(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select cod_area as Codigo, descripcion_a as Area from area where estado='1' ORDER BY DESCRIPCION_A")

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
    Public Function AltaArea(ByVal codigo As String, ByVal area As String) As Boolean
        Try
            Dim csql As String = "Insert into area(cod_area,descripcion_a,estado) values ('" + codigo.ToString + "','" + area.ToString + "','true')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta esta Area", "Insercion de Area", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Area" + ex.ToString, "Area", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateArea(ByVal codigo As String, ByVal area As String) As Boolean
        Try
            Dim csql As String = "UPDATE Area SET descripcion_a='" + area.ToString + "' WHERE cod_area='" + codigo.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Actualizar esta Area", "Insercion de Area", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Area" + ex.ToString, "Area", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function deleteespecialidad(ByVal codigo As String) As Boolean
        Try
            Dim csql As String = "UPDATE Area SET estado='False' WHERE cod_Area='" + codigo.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea eliminar esta Area", "Area", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Area" + ex.ToString, "Area", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Sub generar(ByVal la As Label)
        Dim csql As String = "select count(*) from Area"
        la.Text = CInt(cfun.ConsultaUnDato(csql, 0)) + 1
    End Sub
End Class
