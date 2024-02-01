Imports Datos
Imports System.Windows.Forms
Public Class Cl_vacaciones
    Dim cfun As New cFuncionesDB
    Sub listarvacaciones(ByRef lista As ListView, ByVal per As String, ByVal codigo As String)
        lista.Items.Clear()
        Dim csql As String = "select FECHADEL,FECHAAL,DIAS from dbo.VACACIONES where NRODOCIDENTIDAD='" + per.ToString + "' and codigo='" + codigo.ToString + "'"
        cfun.FillListview(csql, lista)
    End Sub
    Sub limitevacaciones(ByRef codigo As Label, ByRef dias As Label, ByVal cod As String)
        Dim csql As String = "select codigo,numerodias from control_vacaciones where codigo='" + cod + "'"
        dias.Text = cfun.ConsultaUnDato(csql, 1)
        codigo.Text = cfun.ConsultaUnDato(csql, 0)
    End Sub

    Public Function Altavacaciones(ByVal codigo As String, ByVal dni As String, ByVal fechaini As Date, ByVal fechafin As Date, ByVal dias As String) As Boolean
        Try
            Dim csql As String = "INSERT INTO dbo.vacaciones (codigo,NRODOCIDENTIDAD,fechadel,fechaal,dias)VALUES ('" + codigo.ToString + "','" + dni.ToString + "','" + CDate(fechaini.ToString) + "','" + CDate(fechafin.ToString) + "','" + dias.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta estas vacaciones", "Insercion de vacaciones", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta vacaciones" + ex.ToString, "vacaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function UpdateDiasVacaciones(ByVal dni As String, ByVal annio As String, ByVal diassaldo As Integer, ByVal diastomados As Integer) As Boolean
        Dim csql As String
        Dim band As String
        Dim csqlbuscar As String = "select NRODOCIDENTIDAD from contador where NRODOCIDENTIDAD='" + dni + "' and CODIGO='" + annio + "'"
        band = cfun.ConsultaUnDato(csqlbuscar, 0)
        MsgBox(band)
        If band = "" Then
            csql = "INSERT INTO contador (codigo,NRODOCIDENTIDAD,diassaldo,diastomados)VALUES ('" + annio.ToString + "','" + dni.ToString + "','" + diassaldo.ToString + "','" + diastomados.ToString + "')"
        Else
            csql = "update contador set diassaldo='" + diassaldo.ToString + "',diastomados='" + diastomados.ToString + "' where codigo='" + annio.ToString + "' and NRODOCIDENTIDAD='" + dni.ToString + "'"
        End If
        Dim db As BaseDatos = New BaseDatos()
        Try
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            db.ConfirmarTransaccion()
            Return True
            db.Desconectar()
        Catch ex As Exception
            db.CancelarTransaccion()
            MessageBox.Show("Error Alta vacaciones" + ex.ToString, "vacaciones", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function

    Public Function REPORTEPersonal(ByVal per As String, ByVal anio As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "select p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,FECHADEL,FECHAAL,DIAS,numerodias,annio as Año from dbo.VACACIONES v inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=v.NRODOCIDENTIDAD inner join  dbo.CONTROL_VACACIONES cv on cv.CODIGO=v.CODIGO where p.NRODOCIDENTIDAD='" + per.ToString + "' and YEAR(fechadel)='" + anio.ToString + "' and YEAR(fechaal)='" + anio.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_vacaciones")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function

    Public Function REPORTEanio(ByVal per As String, ByVal anio As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "select p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,convert(char(10),FECHADEL,103)as fechadel,convert(char(10),FECHAAL,103) as fechaal,DIAS,numerodias,annio as Año from dbo.VACACIONES v inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=v.NRODOCIDENTIDAD inner join  dbo.CONTROL_VACACIONES cv on cv.CODIGO=v.CODIGO where YEAR(fechadel)='" + anio.ToString + "' and YEAR(fechaal)='" + anio.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_vacaciones")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function REPORTESaldos(ByVal annio As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String
            If annio = "" Then
                csql = "select p.nrodocidentidad,NOMBRES+' '+APELLIDOPATERNO+' '+APELLIDOMATERNO as personal,numerodias,diassaldo,diastomados,annio from CONTADOR c inner join PERSONAL p on c.NRODOCIDENTIDAD=p.NRODOCIDENTIDAD inner join CONTROL_VACACIONES cv on cv.CODIGO=c.CODIGO order by p.NRODOCIDENTIDAD,ANNIO"
            Else
                csql = "select p.nrodocidentidad,NOMBRES+' '+APELLIDOPATERNO+' '+APELLIDOMATERNO as personal,numerodias,diassaldo,diastomados,annio from CONTADOR c inner join PERSONAL p on c.NRODOCIDENTIDAD=p.NRODOCIDENTIDAD inner join CONTROL_VACACIONES cv on cv.CODIGO=c.CODIGO  where annio='" + annio + "' order by p.NRODOCIDENTIDAD,ANNIO"
            End If
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_saldosvacaciones")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
End Class
