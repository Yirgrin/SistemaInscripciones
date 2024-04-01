Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con representantes legales.
''' </summary>
Public Class RepLegalDAO
    Private Shared _instancia As RepLegalDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase RepLegalDAO utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As RepLegalDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New RepLegalDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta o actualiza un representante legal en la base de datos.
    ''' </summary>
    ''' <param name="modelo">El objeto RepresentanteLegal a insertar o actualizar.</param>
    ''' <returns>El objeto RepresentanteLegal insertado o actualizado.</returns>
    Public Function insertarRepLegal(ByVal modelo As RepresentanteLegal) As RepresentanteLegal
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "MERGE INTO GC_REPRESENTANTE_LEGAL AS target
                            USING (SELECT @VALOR8 AS INSCRIPCION) AS source
                            ON target.INSCRIPCION = source.INSCRIPCION
                            WHEN MATCHED THEN
                                UPDATE SET NOMBRE = @VALOR1, GENERO = @VALOR2, CEDULA = @VALOR3, TELEFONO_FIJO = @VALOR4, TELEFONO_MOVIL = @VALOR5, EMAIL = @VALOR6, ESTADO = @VALOR7, CHK_SIN_RL = @VALOR9
                            WHEN NOT MATCHED THEN
                                INSERT (NOMBRE, GENERO, CEDULA, TELEFONO_FIJO, TELEFONO_MOVIL, EMAIL, ESTADO, INSCRIPCION, CHK_SIN_RL)
                                VALUES (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9);"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR7", 1)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.sinRepLegal)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ''' <summary>
    ''' Obtiene si la inscripción tiene o no un representante legal.
    ''' </summary>
    ''' <param name="modelo">trae la inscripción del productor.</param>

    Public Function sinRepLegal(ByVal modelo As RepresentanteLegal) As String
        Dim codigoNuevo As String = ""
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "UPDATE GC_REPRESENTANTE_LEGAL SET INSCRIPCION= @VALOR1, CHK_SIN_RL=@VALOR2"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.sinRepLegal)
            cmd.ExecuteNonQuery()

            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codigoNuevo
    End Function



    ''' <summary>
    ''' Obtiene los datos de un representante legal por su inscripción.
    ''' </summary>
    ''' <param name="inscripcion">La inscripción del representante legal.</param>
    ''' <returns>El objeto RepresentanteLegal correspondiente a la inscripción.</returns>
    Public Function traerDatosRepLegal(ByVal inscripcion As String) As RepresentanteLegal
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_REPRESENTANTE_LEGAL Where INSCRIPCION=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New RepresentanteLegal
            While dr.Read
                modelo.codigo = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.genero = dr(2).ToString
                modelo.cedula = dr(3).ToString
                modelo.telefonoFijo = dr(4).ToString
                modelo.telefonoMovil = dr(5).ToString
                modelo.email = dr(6).ToString
                modelo.sinRepLegal = dr(10).ToString
            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function

    ' Obtiene los datos de un representante legal por su inscripción.
    ''' <param name="inscripcion">La inscripción del representante legal.</param>
    ''' <returns>El objeto RepresentanteLegal correspondiente a la inscripción.</returns>
    Public Function cargarRLSuplidor(ByVal inscripcion As String) As RepresentanteLegal
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_RL_SUPLIDOR Where INSCRIPCION=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            Dim modelo As New RepresentanteLegal
            While dr.Read
                modelo.codigo = dr(0).ToString
                modelo.nombre = dr(1).ToString
                modelo.genero = dr(2).ToString
                modelo.cedula = dr(3).ToString
                modelo.telefonoFijo = dr(4).ToString
                modelo.telefonoMovil = dr(5).ToString
                modelo.email = dr(6).ToString
                modelo.sinRepLegal = dr(10).ToString
            End While
            dr.Close()
            cn.Close()
            Return modelo
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
    End Function


    ''' <summary>
    ''' Inserta o actualiza un representante legal en la base de datos.
    ''' </summary>
    ''' <param name="modelo">El objeto RepresentanteLegal a insertar o actualizar.</param>
    ''' <returns>El objeto RepresentanteLegal insertado o actualizado.</returns>
    Public Function insertarRLSuplidor(ByVal modelo As RepresentanteLegal) As RepresentanteLegal
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql As String = "MERGE INTO GC_RL_SUPLIDOR AS target
                            USING (SELECT @VALOR8 AS INSCRIPCION) AS source
                            ON target.INSCRIPCION = source.INSCRIPCION
                            WHEN MATCHED THEN
                                UPDATE SET NOMBRE = @VALOR1, GENERO = @VALOR2, CEDULA = @VALOR3, TELEFONO_FIJO = @VALOR4, TELEFONO_MOVIL = @VALOR5, EMAIL = @VALOR6, ESTADO = @VALOR7, CHK_SIN_RL = @VALOR9
                            WHEN NOT MATCHED THEN
                                INSERT (NOMBRE, GENERO, CEDULA, TELEFONO_FIJO, TELEFONO_MOVIL, EMAIL, ESTADO, INSCRIPCION, CHK_SIN_RL)
                                VALUES (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9);"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.nombre)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.genero)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.cedula)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.telefonoFijo)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.telefonoMovil)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.email)
            cmd.Parameters.AddWithValue("@VALOR7", 1)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.sinRepLegal)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function


End Class
