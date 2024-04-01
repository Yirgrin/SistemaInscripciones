Imports System.Data.SqlClient

''' <summary>
''' Clase para interactuar con la base de datos y realizar operaciones relacionadas con la información general.
''' </summary>
Public Class InformacionGralDAO

    Private Shared _instancia As InformacionGralDAO = Nothing

    ''' <summary>
    ''' Propiedad de solo lectura que implementa el patrón Singleton para asegurar una única instancia de la clase.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As InformacionGralDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New InformacionGralDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Busca y retorna una colección de tipos de cédulas desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos TipoCedula.</returns>
    Public Function buscarColeccionTipoCedulas() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPO_CEDULA "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New TipoCedula
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function


    ''' <summary>
    ''' Busca y retorna una colección de tipos de certificado desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos TipoCertificado.</returns>
    Public Function buscarTipoCertifica() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPO_CERTIFICADO"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New TipoCertificado
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Busca y retorna una colección de tipos de certificado desde la base de datos.
    ' <returns> Una colección de objetos TipoCertificado. </returns>
    Public Function buscarCertSuplidores() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPO_CERTIFICADO_SUPLIDORES"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New TipoCertificado
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de producción desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos TipoProduccion.</returns>
    Public Function buscarColeccionTipoProduccion() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPO_PRODUCCION "
            sql = sql + " Order by DETALLE"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New TipoProduccion
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de provincias desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos General.</returns>
    Public Function buscarProvincias() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [GC_TERRITORIO_PROVINCIA] Order by [DES_PROVINCIA]"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New General
                modelo.codProvincia = dr(0).ToString
                modelo.desProvincia = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de cantones de una provincia específica desde la base de datos.
    ''' </summary>
    ''' <param name="provincia">El código de la provincia.</param>
    ''' <returns>Una colección de objetos General.</returns>
    Public Function buscarCanton(ByVal provincia As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [GC_TERRITORIO_CANTON] Where [COD_PROVINCIA]=@VALOR1 Order by [DES_CANTON]"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", provincia)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New General
                modelo.codCanton = dr(0).ToString
                modelo.desCanton = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de distritos de un cantón específico desde la base de datos.
    ''' </summary>
    ''' <param name="canton">El código del cantón.</param>
    ''' <returns>Una colección de objetos General.</returns>
    Public Function buscarDistrito(ByVal canton As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [GC_TERRITORIO_DISTRITO] WHERE [COD_CANTON]=@VALOR1 Order by [DES_DISTRITO]"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", canton)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New General
                modelo.codDistrito = dr(0).ToString
                modelo.desDistrito = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function


    ''' <summary>
    ''' Busca y retorna el codigo de la region a la que pertenece el distrito especifico.
    ''' </summary>
    ''' <param name="distrito">El código del distrito.</param>
    ''' <returns>El codigo de la region.</returns>
    Public Function buscarRegion(ByVal distrito As String) As String
        Dim codRegion = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select [COD_REGION] From [GC_TERRITORIO_DISTRITO] WHERE [COD_DISTRITO]=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", distrito)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                codRegion = dr(0).ToString
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codRegion
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos tipos de etnias desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos.</returns>
    Public Function buscarEtnias() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ETNIA "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Etnias
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos tipos de estados civiles desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos.</returns>
    Public Function buscarEstadoCivil() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ESTADO_CIVIL "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New EstadoCivil
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de escolaridades desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos.</returns>
    Public Function buscarEscolaridad() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ESCOLARIDAD "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Escolaridad
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de discapacidades desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos.</returns>
    Public Function buscarDiscapacidad() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPOS_DISCAPACIDAD "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Discapacidad
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de estados CCSS desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos.</returns>
    Public Function buscarEstadosCCSS() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_ESTADOS_CCSS "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New EstadoCCSS
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' Busca y retorna una colección de tipos de productores desde la base de datos.
    ''' <returns>Una colección de objetos TipoProductor.</returns>
    Public Function buscarColeccionTipoProductor() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_TIPO_PRODUCTOR "
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New TipoProductor
                modelo.codigo = dr(0).ToString
                modelo.detalle = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Añade una nueva opción a la lista de discapacidades
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto Discapacidad que contiene los datos.</returns>
    Public Function agregarDiscapacidad(ByVal nuevaOpcion As Discapacidad) As Discapacidad
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_TIPOS_DISCAPACIDAD (DETALLE)"
            sql = sql + " Values (@VALOR1)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nuevaOpcion.detalle)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return nuevaOpcion
    End Function

    ' Añade una nueva opción a la lista de certificaciones
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto Discapacidad que contiene los datos.</returns>
    Public Function nuevoTipoCertificacion(ByVal nuevaOpcion As Certificaciones) As Certificaciones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_TIPO_CERTIFICADO (DETALLE, NUMERO, FECHA_EMISION, FECHA_VENCIMIENTO)"
            sql = sql + " Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nuevaOpcion.tipoCertificado)
            cmd.Parameters.AddWithValue("@VALOR2", 0)
            cmd.Parameters.AddWithValue("@VALOR3", 0)
            cmd.Parameters.AddWithValue("@VALOR4", 0)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return nuevaOpcion
    End Function


End Class
