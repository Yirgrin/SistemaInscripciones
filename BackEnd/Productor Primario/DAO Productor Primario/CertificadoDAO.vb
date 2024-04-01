Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con la certificación de productores.
''' </summary>
Public Class CertificadoDAO
    Private Shared _instancia As CertificadoDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase CertificadoDAO utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As CertificadoDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New CertificadoDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta un certificado en la base de datos.
    ''' </summary>
    ''' <param name="modelo">El objeto Certificacion que contiene los datos del certificado.</param>
    ''' <returns>El objeto Certificacion insertado.</returns>
    Public Function insertarCertificado(ByVal modelo As Certificacion) As Certificacion
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql = "Insert Into GC_CERTIFICACION(PRODUCTOR, TIPO_CERTIFICADO, NUMERO, ARCHIVO, EXTENCION, FECHA_EMISION, FECHA_VENCIMIENTO, ESTADO)"
            sql = sql + " Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.productor)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.tipoCertificado)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.numero)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.archivo)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.extencion)

            ' Verificar y asignar null si la fecha de emisión es una cadena vacía
            If String.IsNullOrEmpty(modelo.fechaEmision) Then
                cmd.Parameters.AddWithValue("@VALOR6", DBNull.Value)
            Else
                Dim fechaEmision As Date = Date.Parse(modelo.fechaEmision)
                cmd.Parameters.AddWithValue("@VALOR6", fechaEmision)
            End If

            ' Verificar y asignar null si la fecha de vencimiento es una cadena vacía
            If String.IsNullOrEmpty(modelo.fechaVencimiento) Then
                cmd.Parameters.AddWithValue("@VALOR7", DBNull.Value)
            Else
                Dim fechaVencimiento As Date = Date.Parse(modelo.fechaVencimiento)
                cmd.Parameters.AddWithValue("@VALOR7", fechaVencimiento)
            End If

            cmd.Parameters.AddWithValue("@VALOR8", modelo.estado)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ''' <summary>
    ''' Busca los certificados de inscripción de un productor en la base de datos y los devuelve en una colección.
    ''' </summary>
    ''' <param name="inscripcion">La inscripción del productor cuyos certificados se buscan.</param>
    ''' <returns>Una colección de objetos Certificacion que representan los certificados de inscripción.</returns>
    Public Function buscarCertifiInscripcion(ByVal inscripcion As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * from VW_GC_CERTIFICACION_PROD"
            sql = sql + " Where 1=1 "
            If inscripcion <> "" Then
                sql = sql + " AND  PRODUCTOR=@VALOR1"
            End If
            sql = sql + " Order By DETALLE"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Certificacion
                modelo.codigo = dr(0).ToString
                modelo.productor = dr(1).ToString
                modelo.tipoCertificado = dr(2).ToString
                modelo.numero = dr(3).ToString
                modelo.archivo = dr(4).ToString
                modelo.extencion = dr(5).ToString

                ' Convertir fecha de emisión y quitar la hora
                Dim fechaEmision As DateTime
                If DateTime.TryParse(dr(6).ToString, fechaEmision) Then
                    modelo.fechaEmision = fechaEmision.ToString("yyyy/MM/dd")
                Else
                    modelo.fechaEmision = String.Empty ' o manejar el error de conversión según sea necesario
                End If

                ' Convertir fecha de vencimiento y quitar la hora
                Dim fechaVencimiento As DateTime
                If DateTime.TryParse(dr(7).ToString, fechaVencimiento) Then
                    modelo.fechaVencimiento = fechaVencimiento.ToString("yyyy/MM/dd")
                Else
                    modelo.fechaVencimiento = String.Empty ' o manejar el error de conversión según sea necesario
                End If

                modelo.estado = dr(8).ToString
                modelo.desCertifica = dr(9).ToString

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
    ''' Elimina un certificado de inscripción primario de la base de datos.
    ''' </summary>
    ''' <param name="codigo">El código del certificado a eliminar.</param>
    ''' <returns>El código del certificado eliminado.</returns>
    Public Function eliminarCertificaInnPrimario(ByVal codigo As String) As String
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql = "Delete From GC_CERTIFICACION where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", codigo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codigo
    End Function

    ''' <summary>
    ''' Busca los campos requeridos para el documento especifico.
    ''' </summary>
    ''' <param name="documento">El codigo del certificado o documento que se necesita buscar.</param>
    ''' <returns>un modelo con los campos necesarios para ese documento.</returns>
    Public Function buscarCamposDocumento(ByVal documento As String) As TipoCertificado
        Dim campos As New TipoCertificado
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * from [GC_TIPO_CERTIFICADO] WHERE [CODIGO] = @DOCUMENTO"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@DOCUMENTO", documento)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                campos.campoNumero = dr(2)
                campos.campoFechaEmision = dr(3)
                campos.campoFechaVencimiento = dr(4)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return campos
    End Function

End Class
