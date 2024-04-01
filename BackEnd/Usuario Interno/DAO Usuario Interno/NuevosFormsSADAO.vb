Imports System.Data.SqlClient
Public Class NuevosFormsSADAO

    Private Shared _instancia As NuevosFormsSADAO = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase NuevosFormsSADAO.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As NuevosFormsSADAO
        Get
            If _instancia Is Nothing Then
                _instancia = New NuevosFormsSADAO()
            End If
            Return _instancia
        End Get
    End Property


    '' Busca las inscripción de suplidores en la base de datos y los devuelve en una colección.
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function AEOcargarInscripSA(ByVal region As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CODIGO, CEDULA, NOMBRE, FECHA_ENVIO from GC_SUPLIDORES WHERE REGION = @VALOR1 AND AREA_REVISION = 1"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", region)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.cedula = dr(1).ToString
                modelo.nombre = dr(2).ToString
                modelo.fecha_envio = dr(3).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    '' Busca las inscripción de suplidores en la base de datos y los devuelve en una colección.
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function DirecRegCargarInscripSA(ByVal region As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CODIGO, CEDULA, NOMBRE, FECHA_ENVIO from GC_SUPLIDORES WHERE REGION = @VALOR1 AND AREA_REVISION = 2"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", region)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.cedula = dr(1).ToString
                modelo.nombre = dr(2).ToString
                modelo.fecha_envio = dr(3).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    '' Busca las inscripción de suplidores de acopio en la base de datos y los devuelve en una colección.
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function DirecMercCargarInscripSA() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CODIGO, NOMBRE, CEDULA, FECHA_ENVIO from GC_SUPLIDORES WHERE AREA_REVISION = 3"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.cedula = dr(2).ToString
                modelo.fecha_envio = dr(3).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    '' Busca las inscripción de suplidores de acopio en la base de datos y los devuelve en una colección.
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function ComerCargarInscripSA() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select CODIGO, NOMBRE, CEDULA, FECHA_ENVIO from GC_SUPLIDORES WHERE AREA_REVISION = 4"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.cedula = dr(2).ToString
                modelo.fecha_envio = dr(3).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    '' Busca las inscripción de suplidores de acopio en la base de datos y los devuelve en una colección.
    ''' <param name="terminoBusqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function buscarInscripcionSA(ByVal terminoBusqueda As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()

            ' Modificamos la consulta SQL para buscar por inscripción, nombre o cédula 
            Dim sql = "SELECT CODIGO, NOMBRE, CEDULA FROM GC_SUPLIDORES WHERE CODIGO LIKE @TERMINO OR NOMBRE LIKE @TERMINO OR CEDULA LIKE @TERMINO"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@TERMINO", "%" & terminoBusqueda & "%") ' Usamos % para permitir búsquedas parciales

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.cedula = dr(2).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que coincidan con la búsqueda realizada
    ''' <param name="terminoBusqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function buscarArchivoSA(ByVal terminoBusqueda As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT * FROM VW_GC_SA_HISTORIAL WHERE CODIGO LIKE @TERMINO OR NOMBRE LIKE @TERMINO OR CEDULA LIKE @TERMINO"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@TERMINO", "%" & terminoBusqueda & "%")
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Suplidor
                modelo.codigo = dr(0).ToString
                modelo.fecha_envio = dr(1).ToString
                modelo.estado_form = dr(2).ToString
                modelo.cedula = dr(3).ToString
                modelo.fecha_devolucion = dr(4).ToString
                modelo.observaciones = dr(5).ToString
                modelo.nombre = dr(6).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Busca las inscripciones de Suplidores de acopio en la base de datos que coincidan con la sesión Región, 
    ' que estén en el rol de dirección de AEO o Director Regional y que estén aprovadas o rechazadas
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function RegArchivoSA(ByVal region As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT * FROM VW_GC_SA_HISTORIAL WHERE REGION = @VALOR1 AND COD_ESTADO IN (4, 5)"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", region)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Productor
                modelo.codigo = dr(0).ToString
                modelo.fecha_envio = dr(1).ToString
                modelo.estado_form = dr(2).ToString
                modelo.cedula = dr(3).ToString
                modelo.fecha_devolucion = dr(4).ToString
                modelo.observaciones = dr(5).ToString
                modelo.nombre = dr(6).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Busca las inscripciones de Suplidores de acopio en la base de datos que estén en el rol de comercialización o mercadeo y que estén aprovadas o rechazadas 
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function ArchivosSA() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "SELECT * FROM VW_GC_SA_HISTORIAL WHERE COD_ESTADO IN (4, 5)"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Productor
                modelo.codigo = dr(0).ToString
                modelo.fecha_envio = dr(1).ToString
                modelo.estado_form = dr(3).ToString
                modelo.cedula = dr(2).ToString
                modelo.fecha_devolucion = dr(4).ToString
                modelo.observaciones = dr(5).ToString
                modelo.nombre = dr(6).ToString
                modelo.codEstado = dr(8).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function


End Class
