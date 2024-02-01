Imports Datos
Imports System.Data
Imports System.Windows.Forms
Public Class Cl_personal
    Dim CFUN As New cFuncionesDB
    Private _docidentidad As String
    Public Property DocIdentidad() As String
        Get
            Return _docidentidad
        End Get
        Set(ByVal value As String)
            _docidentidad = value
        End Set
    End Property
    Private _nombres As String
    Public Property Nombres() As String
        Get
            Return _nombres
        End Get
        Set(ByVal value As String)
            _nombres = value
        End Set
    End Property
    Private _apellidopaterno As String
    Public Property ApellidoPaterno() As String
        Get
            Return _apellidopaterno
        End Get
        Set(ByVal value As String)
            _apellidopaterno = value
        End Set
    End Property
    Private _apellidomaterno As String
    Public Property ApellidoMaterno() As String
        Get
            Return _apellidomaterno
        End Get
        Set(ByVal value As String)
            _apellidomaterno = value
        End Set
    End Property
    Private _especialidad As Integer
    Public Property Especialidad() As Integer
        Get
            Return _especialidad
        End Get
        Set(ByVal value As Integer)
            _especialidad = value
        End Set
    End Property
    Private _subtipo As Integer
    Public Property Subtipo() As Integer
        Get
            Return _subtipo
        End Get
        Set(ByVal value As Integer)
            _subtipo = value
        End Set
    End Property
    Private _area As Integer
    Public Property Area() As Integer
        Get
            Return _area
        End Get
        Set(ByVal value As Integer)
            _area = value
        End Set
    End Property

    Public Function cargarpersonalcmb(ByRef oCombo As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select nrodocidentidad, nombres+' '+apellidopaterno+' '+apellidomaterno as persona from personal where estado='1'")
            Try
                dt.Load(db.EjecutarConsulta())
                oCombo.Edit.DataSource = dt
                oCombo.Edit.ValueMember = "nrodocidentidad"
                oCombo.Edit.DisplayMember = "persona"

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

    Public Function ListarACTIVOS(ByVal oDgv As Object) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,e.COD_ESPECIALIDAD,e.DESCRIPCION AS ESPECIALIDAD,tp.COD_TIPOPERSONAL,tp.DESCRIPCION as TIPO,A.cod_area as CodArea,descripcion_a as Area  from dbo.PERSONAL p inner join dbo.ESPECIALIDADES e on e.COD_ESPECIALIDAD=p.COD_ESPECIALIDAD inner join dbo.TIPO_PERSONAL tp on tp.COD_TIPOPERSONAL=p.COD_TIPOPERSONAL inner join area a on a.cod_area=p.cod_area WHERE P.ESTADO=1 order by 1")

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


    Public Function ListarParaAsistencia(ByVal oDgv As Object, ByVal fecha As Date) As Boolean
        Dim db As BaseDatos = New BaseDatos()
        Dim dt As New Data.DataTable
        Try
            db.Conectar()
            db.CrearComando("select NRODOCIDENTIDAD,APELLIDOPATERNO,APELLIDOMATERNO,NOMBRES,CAMPO1  as ENTRADA,CAMPO2  AS SALIDA,CAMPO3 AS FECHA_SALIDA  from dbo.PERSONAL where NRODOCIDENTIDAD not in (select NRODOCIDENTIDAD from dbo.ASISTENCIA where FECHA='" + fecha + "') AND NRODOCIDENTIDAD not in (select NRODOCIDENTIDAD from dbo.PERMISOS where FECHADEL<='" + fecha + "' AND FECHAAL>='" + fecha + "' ) AND NRODOCIDENTIDAD not in (select NRODOCIDENTIDAD from dbo.VACACIONES where FECHADEL<='" + fecha + "' AND FECHAAL>='" + fecha + "' )")

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
            Dim csql As String = "Insert into personal(NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,COD_ESPECIALIDAD,COD_TIPOPERSONAL,ESTADO,cod_area) values ('" + Me.DocIdentidad + "','" + Me.Nombres + "','" + Me.ApellidoPaterno + "','" + Me.ApellidoMaterno + "','" + Me.Especialidad.ToString + "','" + Me.Subtipo.ToString + "','1','" + Area.ToString + "')"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea dar de Alta este Personal", "Insercion de Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Alta Personal" + ex.ToString, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Public Function UpdatePersonal() As Boolean
        Try
            Dim csql As String = "update personal set NOMBRES='" + Me.Nombres + "',APELLIDOPATERNO='" + Me.ApellidoPaterno + "',APELLIDOMATERNO='" + Me.ApellidoMaterno + "',COD_ESPECIALIDAD='" + Me.Especialidad.ToString + "',COD_TIPOPERSONAL='" + Me.Subtipo.ToString + "',cod_area='" + Area.ToString + "'  where NRODOCIDENTIDAD='" + Me.DocIdentidad + "'"
            Dim db As BaseDatos = New BaseDatos()
            Dim pregunta As DialogResult
            db.Conectar()
            db.ComenzarTransaccion()
            db.CrearComando(csql)
            db.EjecutarComando()
            pregunta = MessageBox.Show("Desea Editar este Personal", "Edicion de Personal", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
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
            MessageBox.Show("Error Edicion Personal" + ex.ToString, "Personal", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return False
        End Try
    End Function
    Sub listar(ByVal dato As String, ByRef lista As ListView)
        Dim csql As String = "select nrodocidentidad,nombres,apellidopaterno,apellidomaterno from personal where nombres+' '+apellidopaterno+' '+apellidomaterno like '%" + dato + "%' "
        CFUN.FillListview(csql, lista)
    End Sub

    Public Function REPORTEPERSONALXAREA(ByVal area As String) As DataSet
        Dim dset As New DataSet
        Try
            Dim csql As String
            If area = "" Then
                csql = "select NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,DESCRIPCION_A AS AREA,DESCRIPCION as ESPECIALIDAD from dbo.PERSONAL p inner join dbo.AREA a on p.COD_AREA=a.COD_AREA inner join dbo.ESPECIALIDADES e on e.COD_ESPECIALIDAD=p.COD_ESPECIALIDAD where p.ESTADO='1' and a.ESTADO='1'"
            Else
                csql = "select NRODOCIDENTIDAD,NOMBRES,APELLIDOPATERNO,APELLIDOMATERNO,DESCRIPCION_A AS AREA,DESCRIPCION as ESPECIALIDAD from dbo.PERSONAL p inner join dbo.AREA a on p.COD_AREA=a.COD_AREA inner join dbo.ESPECIALIDADES e on e.COD_ESPECIALIDAD=p.COD_ESPECIALIDAD where p.ESTADO='1' and a.ESTADO='1' and a.cod_area='" + area.ToString + "'"
            End If
            Dim db As BaseDatos = New BaseDatos()
            db.Conectar()
            dset = db.Mapeadataset(csql, "DT_PERSONAL")
            db.Desconectar()
        Catch ex As Exception
            MessageBox.Show(ex.ToString, "Error ", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
        Return dset
    End Function
End Class
