Imports Datos
Imports System.Windows.Forms
Public Class Cl_permisos
    Dim cfun As New cFuncionesDB

    Public Function AltaPermiso(ByVal nrodocidentidad As String, ByVal fechadel As Date, ByVal fechaal As Date, ByVal cantidad As String, ByVal motivo As String, ByVal horasalida As String) As Boolean
        Try
            Dim csql As String = "Insert into permisos(nrodocidentidad,fechadel,fechaal,cantidad,motivo,horasalida) values ('" + nrodocidentidad.ToString + "','" + CDate(fechadel.ToString) + "','" + CDate(fechaal.ToString) + "','" + cantidad.ToString + "','" + motivo.ToString + "','" + horasalida.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta este Permiso", "Insercion de Permiso", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Permiso" + ex.ToString, "Permiso", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Function CONSULTAVACACIONES(ByVal PER As String, ByVal FECHADEL As Date, ByVal FECHAAL As Date)
        Dim IND As String = ""
        Dim CSQL As String = "select CODIGO from dbo.VACACIONES where NRODOCIDENTIDAD='" + PER + "' AND (('" + FECHADEL + "'>=FECHADEL and '" + FECHAAL + "'<=FECHAAL) OR ('" + FECHADEL + "'>=FECHADEL and '" + FECHADEL + "'<=FECHAAL) OR ('" + FECHAAL + "'>=FECHADEL and '" + FECHAAL + "'<=FECHAAL))"
        IND = cfun.ConsultaUnDato(CSQL, 0)
        Return IND
    End Function
    Public Function REPORTEpermisostodos(ByVal mes As String, ByVal anio As String, ByVal per As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String
            If per = "" Then
                csql = "select p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,convert(char(10),FECHADEL,103)as fechadel,convert(char(10),FECHAAL,103)as fechaal,CANTIDAD,MOTIVO,HORASALIDA from dbo.PERMISOS p inner join dbo.PERSONAL per on p.NRODOCIDENTIDAD=per.NRODOCIDENTIDAD where year(FECHADEL)='" + anio + "' and month(FECHADEL)='" + mes + "'"
            Else
                csql = "select p.NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,convert(char(10),FECHADEL,103)as fechadel,convert(char(10),FECHAAL,103)as fechaal,CANTIDAD,MOTIVO,HORASALIDA from dbo.PERMISOS p inner join dbo.PERSONAL per on p.NRODOCIDENTIDAD=per.NRODOCIDENTIDAD where year(FECHADEL)='" + anio + "' and month(FECHADEL)='" + mes + "' and p.nrodocidentidad='" + per + "'"
            End If
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "dt_permisos")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
    Public Function graficoPermisos(ByVal anio As String, ByVal mes As String) As DataTable
        Dim db As BaseDatos = New BaseDatos()
        Dim ds As New DataSet
        Dim dt As New DataTable
        Try
            db.Conectar()
            db.CrearComando("SELECT NOMBRES+' '+APELLIDOPATERNO+' '+APELLIDOMATERNO AS PERSONA,sum(CONVERT(INT,(FECHAAL-FECHADEL)+1))AS NUMERO FROM PERMISOS PR INNER JOIN PERSONAL P ON P.NRODOCIDENTIDAD=PR.NRODOCIDENTIDAD WHERE MONTH(FECHADEL)='" + mes + "' and YEAR(FECHADEL)='" + anio + "' group by NOMBRES+' '+APELLIDOPATERNO+' '+APELLIDOMATERNO")
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
End Class
