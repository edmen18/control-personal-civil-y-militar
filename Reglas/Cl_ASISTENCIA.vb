Imports Datos
Imports System.Windows.Forms
Public Class Cl_ASISTENCIA
    Dim cfun As New cFuncionesDB

    Public Function AltaASISTENCIACompleta(ByVal NRODOCIDENTIDAD As String, ByVal HORAINGRESO As String, ByVal HORASALIDA As String, ByVal FECHA As String, ByVal TURNO As String, ByVal fechasalida As String) As Boolean
        Try
            Dim csql As String = "INSERT INTO dbo.ASISTENCIA (NRODOCIDENTIDAD,HORAINGRESO,HORASALIDA,FECHA,COD_TURNO,fechasal)VALUES ('" + NRODOCIDENTIDAD.ToString + "','" + HORAINGRESO.ToString + "','" + HORASALIDA.ToString + "','" + CDate(FECHA.ToString) + "','" + TURNO.ToString + "','" + CStr(fechasalida.ToString) + "')"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            db.ConfirmarTransaccion()
            'MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            db.Desconectar()
        Catch ex As Exception
            Dim db As BaseDatos = New BaseDatos()
            db.CancelarTransaccion()
            db.Desconectar()
            MessageBox.Show("Error Alta Personal" + ex.ToString, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function







    Public Function AltaASISTENCIA(ByVal NRODOCIDENTIDAD As String, ByVal HORAINGRESO As String, ByVal HORASALIDA As String, ByVal FECHA As String, ByVal TURNO As String) As Boolean
        Try
            Dim csql As String = "INSERT INTO dbo.ASISTENCIA (NRODOCIDENTIDAD,HORAINGRESO,HORASALIDA,FECHA,COD_TURNO)VALUES ('" + NRODOCIDENTIDAD.ToString + "','" + HORAINGRESO.ToString + "','" + HORASALIDA.ToString + "','" + CDate(FECHA.ToString) + "','" + TURNO.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            db.ConfirmarTransaccion()
            'MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            db.Desconectar()
        Catch ex As Exception
            Dim db As BaseDatos = New BaseDatos()
            db.CancelarTransaccion()
            db.Desconectar()
            MessageBox.Show("Error Alta Personal" + ex.ToString, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdateASISTENCIA(ByVal NRODOCIDENTIDAD As String, ByVal HORASALIDA As String, ByVal FECHA As String) As Boolean
        Try
            Dim csql As String = "update dbo.ASISTENCIA set HORASALIDA='" + HORASALIDA.ToString + "' where NRODOCIDENTIDAD='" + NRODOCIDENTIDAD.ToString + "' and fecha='" + CDate(FECHA.ToString) + "' and HORAINGRESO = HORASALIDA"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            db.ConfirmarTransaccion()
            ' MessageBox.Show("Los datos se almacenaron satisfactoriamente", "SHD", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Return True
            db.Desconectar()
        Catch ex As Exception
            Dim db As BaseDatos = New BaseDatos()
            db.CancelarTransaccion()
            db.Desconectar()
            MessageBox.Show("Error Alta Personal" + ex.ToString, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Sub VERIFICARASISTENCIADELDIA(ByVal PERSONAL As String, ByVal FECHA As Date, ByRef FECH As Label)
        Dim CSQL As String = "SELECT HORAINGRESO FROM dbo.ASISTENCIA WHERE NRODOCIDENTIDAD='" + PERSONAL + "' AND FECHA='" + FECHA + "'"
        FECH.Text = cfun.ConsultaUnDato(CSQL, 0)
    End Sub
    Sub CONTARCUANTOSHAY(ByVal PERSONAL As String, ByVal FECHA As Date, ByRef FECH As Label)
        Dim CSQL As String = "SELECT COUNT(*) FROM dbo.ASISTENCIA WHERE NRODOCIDENTIDAD='" + PERSONAL + "' AND FECHA='" + FECHA + "' and HORAINGRESO = HORASALIDA"
        FECH.Text = cfun.ConsultaUnDato(CSQL, 0)
    End Sub
    Sub GETTURNO(ByRef HORARIO As Label, ByVal PER As String)
        Dim CSQL As String = "SELECT T.COD_TURNO FROM dbo.DETALLE_HORARIO DH INNER JOIN dbo.TURNOS T ON DH.COD_TURNO=T.COD_TURNO WHERE DH.ESTADO='1' AND NRODOCIDENTIDAD='" + PER + "' AND HORAMARCADO<=CONVERT(TIME,GETDATE()) AND HORAFIN>=CONVERT(TIME,GETDATE())"
        HORARIO.Text = cfun.ConsultaUnDato(CSQL, 0)
    End Sub
    Public Function GETTURNOCOMPLETO(ByVal PER As String, ByVal HORAINGRESO As String) As String
        Dim CSQL As String = "SELECT T.COD_TURNO FROM dbo.DETALLE_HORARIO DH INNER JOIN dbo.TURNOS T ON DH.COD_TURNO=T.COD_TURNO WHERE DH.ESTADO='1' AND NRODOCIDENTIDAD='" + PER + "' AND HORAMARCADO<=CONVERT(TIME,'" + HORAINGRESO.ToString + "') AND HORAFIN>=CONVERT(TIME,'" + HORAINGRESO.ToString + "')"
        Return cfun.ConsultaUnDato(CSQL, 0)
    End Function
    Public Function REPORTEFECHAS(ByRef FECHADEL As Date, ByRef FECHAAL As Date, ByVal per As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL WHERE p.NRODOCIDENTIDAD='" + per + "'   and FECHA>='" + FECHADEL + "' and FECHA<='" + FECHAAL + "' UNION SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,'Vacaciones','Vacaciones',CONVERT(CHAR(10),FECHADEL,103)+' AL '+CONVERT(CHAR(10),FECHAAL,103) as fecha,'' as fechasal FROM dbo.vacaciones a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL WHERE p.NRODOCIDENTIDAD='" + per + "' and FECHADEL>='" + FECHADEL + "' and  FECHAAL<='" + FECHAAL + "' UNION SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO, 'Permiso','Permiso',CONVERT(CHAR(10),FECHADEL,103)+' AL '+CONVERT(CHAR(10),FECHAAL,103) as fecha,'' as fechasal  FROM dbo.PERMISOS a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  WHERE p.NRODOCIDENTIDAD='" + per + "' and FECHADEL>='" + FECHADEL + "' and  FECHAAL<='" + FECHAAL + "' ORDER BY FECHA "
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_asistencias")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function REPORTEFECHAStodos(ByRef FECHADEL As Date, ByRef FECHAAL As Date) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL WHERE FECHA>='" + FECHADEL + "' and FECHA<='" + FECHAAL + "' UNION SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,'Vacaciones','Vacaciones',CONVERT(CHAR(10),FECHADEL,103)+' AL '+CONVERT(CHAR(10),FECHAAL,103) as fecha,'' as fechasal FROM dbo.vacaciones a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL WHERE FECHADEL>='" + FECHADEL + "' and  FECHAAL<='" + FECHAAL + "' UNION SELECT DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO, 'Permiso','Permiso',CONVERT(CHAR(10),FECHADEL,103)+' AL '+CONVERT(CHAR(10),FECHAAL,103) as fecha,'' as fechasal  FROM dbo.PERMISOS a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  WHERE FECHADEL>='" + FECHADEL + "' and  FECHAAL<='" + FECHAAL + "'ORDER BY FECHA "
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_asistencias")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function REPORTEtardanzaanioymes(ByVal mes As String, ByVal anio As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DISTINCT TP.DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,LEFT(HORAINICIO,5) AS HORAINI, LEFT(HORAFIN,5) AS HORAFI,CONVERT(TIME,(CONVERT(DATETIME,HORAINGRESO)-CONVERT(DATETIME,HORAINICIO)))as tardanza,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  INNER JOIN dbo.DETALLE_HORARIO DH ON DH.NRODOCIDENTIDAD=P.NRODOCIDENTIDAD  INNER JOIN dbo.TURNOS T ON T.COD_TURNO=DH.COD_TURNO and a.COD_TURNO=t.COD_TURNO WHERE YEAR(FECHA)='" + anio + "' and MONTH(FECHA)='" + mes + "' AND (CONVERT(DATETIME,HORAINGRESO)>CONVERT(DATETIME,HORAINICIO))"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_tya")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function REPORTEtardanzaaniomesPERSONA(ByVal mes As String, ByVal anio As String, ByVal per As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DISTINCT TP.DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,LEFT(HORAINICIO,5) AS HORAINI, LEFT(HORAFIN,5) AS HORAFI,CONVERT(TIME,(CONVERT(DATETIME,HORAINGRESO)-CONVERT(DATETIME,HORAINICIO)))as tardanza,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  INNER JOIN dbo.DETALLE_HORARIO DH ON DH.NRODOCIDENTIDAD=P.NRODOCIDENTIDAD  INNER JOIN dbo.TURNOS T ON T.COD_TURNO=DH.COD_TURNO and a.COD_TURNO=t.COD_TURNO WHERE YEAR(FECHA)='" + anio + "' and MONTH(FECHA)='" + mes + "' AND (CONVERT(DATETIME,HORAINGRESO)>CONVERT(DATETIME,HORAINICIO)) and p.NRODOCIDENTIDAD='" + per.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_tya")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function graficotardanzas(ByVal anio As String, ByVal mes As String) As DataTable
        Dim db As BaseDatos = New BaseDatos()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            db.Conectar()
            db.CrearComando("SELECT DISTINCT NOMBRES+' '+APELLIDOPATERNO+' '+APELLIDOMATERNO as persona,COUNT(*)as numero  FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD   inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  INNER JOIN dbo.DETALLE_HORARIO DH  ON DH.NRODOCIDENTIDAD=P.NRODOCIDENTIDAD  INNER JOIN dbo.TURNOS T ON T.COD_TURNO=DH.COD_TURNO  and a.COD_TURNO=t.COD_TURNO WHERE YEAR(FECHA)='" + anio + "'  and MONTH(FECHA)='" + mes + "' AND (CONVERT(DATETIME,HORAINGRESO)>CONVERT(DATETIME,HORAINICIO))  group by TP.DESCRIPCION ,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO")
            Try
                dt.Load(db.EjecutarConsulta())
            Catch ex As Exception
                MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            End Try
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
            db.CancelarTransaccion()
            db.Desconectar()
        End Try
        Return dt
    End Function
    Public Function REPORTEadicionalesanioymes(ByVal mes As String, ByVal anio As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DISTINCT TP.DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,LEFT(HORAINICIO,5) AS HORAINI, LEFT(HORAFIN,5) AS HORAFI,CONVERT(TIME,(CONVERT(DATETIME,HORASALIDA)-CONVERT(DATETIME,HORAFIN)))as adicional,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  INNER JOIN dbo.DETALLE_HORARIO DH ON DH.NRODOCIDENTIDAD=P.NRODOCIDENTIDAD  INNER JOIN dbo.TURNOS T ON T.COD_TURNO=DH.COD_TURNO and a.COD_TURNO=t.COD_TURNO WHERE YEAR(FECHA)='" + anio + "' and MONTH(FECHA)='" + mes + "' AND (CONVERT(DATETIME,HORASALIDA)>CONVERT(DATETIME,HORAFIN)) ORDER BY FECHA"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_tya")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function REPORTEadicionalaniomesPERSONA(ByVal mes As String, ByVal anio As String, ByVal per As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String = "SELECT DISTINCT TP.DESCRIPCION as DESCRIPCIO,p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,HORAINGRESO,HORASALIDA,CONVERT(CHAR(10),FECHA,103) as fecha,LEFT(HORAINICIO,5) AS HORAINI, LEFT(HORAFIN,5) AS HORAFI,CONVERT(TIME,(CONVERT(DATETIME,HORASALIDA)-CONVERT(DATETIME,HORAFIN)))as adicional,convert(char(10),fechasal,103) as fechasal FROM dbo.ASISTENCIA a inner join dbo.PERSONAL p on p.NRODOCIDENTIDAD=a.NRODOCIDENTIDAD  inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL  INNER JOIN dbo.DETALLE_HORARIO DH ON DH.NRODOCIDENTIDAD=P.NRODOCIDENTIDAD  INNER JOIN dbo.TURNOS T ON T.COD_TURNO=DH.COD_TURNO and a.COD_TURNO=t.COD_TURNO WHERE YEAR(FECHA)='" + anio + "' and MONTH(FECHA)='" + mes + "' AND (CONVERT(DATETIME,HORASALIDA)>CONVERT(DATETIME,HORAFIN)) and p.NRODOCIDENTIDAD='" + per.ToString + "'"
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_tya")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
End Class
