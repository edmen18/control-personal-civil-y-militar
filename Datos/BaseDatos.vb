﻿Imports System.Data.Common
Imports System.Data
Imports System.Configuration
Imports System.Data.SqlClient

''' <summary>
''' Representa la base de datos en el sistema.
''' Ofrece los métodos de acceso a misma.
''' </summary>
Public Class BaseDatos
    Private _adaptador As DbDataAdapter
    Private _ds As New DataSet

    Private _Conexion As DbConnection = Nothing
    Private _Comando As DbCommand = Nothing
    Private _Transaccion As DbTransaction = Nothing
    Private _parametro As DbParameter = Nothing

    Private _CadenaConexion As String

    Private Shared _Factory As DbProviderFactory = Nothing

    ''' <summary>
    ''' Crea una instancia del acceso a la base de datos.
    ''' </summary>
    Public Sub New()
        Configurar()
    End Sub

    ''' <summary>
    ''' Configura el acceso a la base de datos para su utilización.
    ''' </summary>
    ''' <exception cref="BaseDatosException">Si existe un error al cargar la configuración.</exception>
    Private Sub Configurar()
        Try
            Dim proveedor As String = ConfigurationManager.AppSettings.Get("PROVEEDOR_ADO")
            Me._CadenaConexion = ConfigurationManager.AppSettings.Get("CADENA_CONEXION")
            BaseDatos._Factory = DbProviderFactories.GetFactory(proveedor)
        Catch ex As ConfigurationErrorsException
            Throw New BaseDatosException("Error al cargar la configuración del acceso a datos.", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Permite desconectarse de la base de datos.
    ''' </summary>
    Public Sub Desconectar()
        If Me._Conexion.State.Equals(ConnectionState.Open) Then
            Me._Conexion.Close()
        End If
    End Sub

    ''' <summary>
    ''' Se concecta con la base de datos.
    ''' </summary>
    ''' <exception cref="BaseDatosException">Si existe un error al conectarse.</exception> 
    Public Sub Conectar()
        If Not Me._Conexion Is Nothing Then
            If Me._Conexion.State.Equals(ConnectionState.Closed) Then
                Throw New BaseDatosException("La conexión ya se encuentra abierta.")
            End If
        End If

        Try
            If Me._Conexion Is Nothing Then
                Me._Conexion = _Factory.CreateConnection()
                Me._Conexion.ConnectionString = _CadenaConexion
            End If
            Me._Conexion.Open()
        Catch ex As DataException
            Throw New BaseDatosException("Error al conectarse.")
        End Try
    End Sub

    ''' <summary>
    ''' Crea un comando en base a una sentencia SQL.Ejemplo:
    ''' <code>SELECT * FROM Tabla WHERE campo1=@campo1, campo2=@campo2</code>
    ''' Guarda el comando para el seteo de parámetros y la posterior ejecución.
    ''' </summary>
    ''' <param name="sentenciaSQL">La sentencia SQL con el formato: SENTENCIA [param = @param,]</param>
    Public Sub CrearComando(ByVal sentenciaSQL As String)
        Me._Comando = _Factory.CreateCommand()
        Me._Comando.Connection = Me._Conexion
        Me._Comando.CommandType = CommandType.Text
        Me._Comando.CommandText = sentenciaSQL
        If Not Me._Transaccion Is Nothing Then
            Me._Comando.Transaction = Me._Transaccion
        End If
    End Sub

    ''' <summary>
    ''' Crea un comando para Ejecutar Proc Almacenado en base a una sentencia SQL.Ejemplo:
    ''' <code>SELECT * FROM Tabla WHERE campo1=@campo1, campo2=@campo2</code>
    ''' Guarda el comando para el seteo de parámetros y la posterior ejecución.
    ''' </summary>
    ''' <param name="nombreProcedimiento">La sentencia SQL con el formato: SENTENCIA [param = @param,]</param>
    Public Sub CrearStoreProcedure(ByVal nombreProcedimiento As String)
        Me._Comando = _Factory.CreateCommand()
        Me._Comando.Connection = Me._Conexion
        Me._Comando.CommandType = CommandType.StoredProcedure
        Me._Comando.CommandText = nombreProcedimiento
        If Not Me._Transaccion Is Nothing Then
            Me._Comando.Transaction = Me._Transaccion
        End If
    End Sub

    ''' <summary>
    ''' Setea un parámetro como nulo del comando creado.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro cuyo valor será nulo.</param>
    Public Sub AsignarParametroNulo(ByVal nombre As String)
        AsignarParametro(nombre, "", "NULL")
    End Sub

    ''' <summary>
    ''' Asigna un parámetro de tipo cadena al comando creado.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro.</param>
    ''' <param name="valor">El valor del parámetro.</param>
    Public Sub AsignarParametroCadena(ByVal nombre As String, ByVal valor As String)
        AsignarParametro(nombre, "'", valor)
    End Sub

    ''' <summary>
    ''' Asigna un parámetro de tipo entero al comando creado.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro.</param>
    ''' <param name="valor">El valor del parámetro.</param>
    Public Sub AsignarParametroEntero(ByVal nombre As String, ByVal valor As Integer)
        AsignarParametro(nombre, "", valor.ToString())
    End Sub

    ''' <summary>
    ''' Asigna un parámetro al comando creado.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro.</param>
    ''' <param name="separador">El separador que será agregado al valor del parámetro.</param>
    ''' <param name="valor">El valor del parámetro.</param>
    Private Sub AsignarParametro(ByVal nombre As String, ByVal separador As String, ByVal valor As String)
        Dim indice As Integer = Me._Comando.CommandText.IndexOf(nombre)
        Dim prefijo As String = Me._Comando.CommandText.Substring(0, indice)
        Dim sufijo As String = Me._Comando.CommandText.Substring(indice + nombre.Length)
        Me._Comando.CommandText = prefijo + separador + valor + separador + sufijo
    End Sub

    ''' <summary>
    ''' Asigna un parámetro de tipo fecha al comando creado.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro.</param>
    ''' <param name="valor">El valor del parámetro.</param>
    Public Sub AsignarParametroFecha(ByVal nombre As String, ByVal valor As DateTime)
        AsignarParametro(nombre, "'", valor.ToString())
    End Sub

    ''' <summary>
    ''' Asigna un parámetro de tipo Imagen al comando creado.
    ''' </summary>
    ''' <param name="Parametros">El nombre del parámetro.</param>

    Public Sub AsignarParametrosPA(ByVal ParamArray Parametros() As Object)
        Dim contador As Integer
        Dim n As String = ""
        Me._Comando.CommandType = CommandType.StoredProcedure
        For contador = 0 To UBound(Parametros)
            n = "@" & Parametros(contador).ToString
            contador += 1
            ' Este if es para saber si hay que asignarle un valor al parametro
            ' de tipo varbinary o Image
            If Parametros(contador) = 1 Then
                contador += 1
                Me._Comando.Parameters.Add(New SqlParameter(n, Parametros(contador), Parametros(contador + 1)))
                contador += 1
            Else
                contador += 1
                Me._Comando.Parameters.Add(New SqlParameter(n, Parametros(contador)))
            End If
            contador += 1
            Me._Comando.Parameters(n).Value = Parametros(contador)
        Next
    End Sub



    ''' <summary>
    ''' Ejecuta el comando creado y retorna el resultado de la consulta.
    ''' </summary>
    ''' <returns>El resultado de la consulta.</returns>
    ''' <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
    Public Function EjecutarConsulta() As DbDataReader
        Return Me._Comando.ExecuteReader()
    End Function

    ''' <summary>
    ''' Ejecuta el comando creado y retorna un escalar.
    ''' </summary>
    ''' <returns>El escalar que es el resultado del comando.</returns>
    ''' <exception cref="BaseDatosException">Si ocurre un error al ejecutar el comando.</exception>
    Public Function EjecutarEscalar() As Integer
        Dim escalar As Integer = 0
        Try
            escalar = Integer.Parse(Me._Comando.ExecuteScalar().ToString())
        Catch ex As InvalidCastException
            Throw New BaseDatosException("Error al ejecutar un escalar.", ex)
        End Try
        Return escalar
    End Function
    ''' <summary>
    ''' Ejecuta el comando creado y retorna un escalar de tipo String.
    ''' </summary>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Function EjecutarEscalarSring() As String
        Dim escalar As String = ""
        Try
            escalar = Me._Comando.ExecuteScalar().ToString()
        Catch ex As InvalidCastException
            Throw New BaseDatosException("Error al ejecutar un escalar.", ex)
        End Try
        Return escalar
    End Function


    ''' <summary>
    ''' Ejecuta el comando creado.
    ''' </summary>
    Public Sub EjecutarComando()
        Try
            Me._Comando.ExecuteNonQuery()
        Catch ex As Exception
            Throw New BaseDatosException("JODETE", ex)
        End Try
    End Sub

    ''' <summary>
    ''' Comienza una transacción en base a la conexion abierta.
    ''' Todo lo que se ejecute luego de esta ionvocación estará 
    ''' dentro de una tranasacción.
    ''' </summary>
    Public Sub ComenzarTransaccion()
        If Me._Transaccion Is Nothing Then
            Me._Transaccion = Me._Conexion.BeginTransaction()
        End If
    End Sub

    ''' <summary>
    ''' Cancela la ejecución de una transacción.
    ''' Todo lo ejecutado entre ésta invocación y su 
    ''' correspondiente <c>ComenzarTransaccion</c> será perdido.
    ''' </summary>
    ''' <remarks></remarks>
    Public Sub CancelarTransaccion()
        If Not Me._Transaccion Is Nothing Then
            Me._Transaccion.Rollback()
        End If
    End Sub

    ''' <summary>
    ''' Confirma todo los comandos ejecutados entre el <c>ComanzarTransaccion</c>
    ''' y ésta invocación.
    ''' </summary>
    Public Sub ConfirmarTransaccion()

        If Not Me._Transaccion Is Nothing Then
            Me._Transaccion.Commit()
        End If

    End Sub
    Public Function Mapeadataset(ByVal cadsql As String, ByVal ntabla As String) As DataSet
        _Comando = _Factory.CreateCommand
        _adaptador = _Factory.CreateDataAdapter
        _Comando.Connection = _Conexion
        _Comando.CommandText = cadsql
        _adaptador.SelectCommand = _Comando
        _adaptador.Fill(_ds, ntabla)
        Return _ds
    End Function


End Class
