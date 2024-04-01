Imports System.Data.SqlClient

' Clase que proporciona métodos para interactuar con la base de datos relacionados con la certificación de suplidores.

Public Class CertificacionesDAO

    Private Shared _instancia As CertificacionesDAO = Nothing

    ' Obtiene una instancia única de la clase CertificadoDAO utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As CertificacionesDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New CertificacionesDAO()
            End If
            Return _instancia
        End Get
    End Property


    ' Inserta un certificado en la base de datos.
    ''' <param name="modelo">El objeto Certificacion que contiene los datos del certificado.</param>
    ''' <returns>El objeto Certificacion insertado.</returns>
    Public Function insertarCertificado(ByVal modelo As Certificaciones) As Certificaciones
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql = "Insert Into GC_CERTIFICACION_SUPLIDORES(SUPLIDOR, TIPO_CERTIFICADO, NUMERO, 
                        ARCHIVO, EXTENSION, FECHA_EMISION, FECHA_VENCIMIENTO, ESTADO, CUENTA_IBAN, COD_BANCO)"
            sql = sql + " Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9, @VALOR10)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.suplidor)
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
            cmd.Parameters.AddWithValue("@VALOR9", modelo.cuentaIBAN)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.codigoBanco)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    '' Busca los certificados de inscripción de un suplidor en la base de datos y los devuelve en una colección.
    ''' <param name="inscripcion">La inscripción del suplidor cuyos certificados se buscan.</param>
    ''' <returns>Una colección de objetos Certificacion que representan los certificados de inscripción.</returns>
    Public Function buscarCertifiInscripcion(ByVal inscripcion As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * from VW_GC_CERTIFICACION_SUPLIDOR WHERE SUPLIDOR =@VALOR1"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Certificaciones
                modelo.tipoCertificado = dr(0).ToString
                modelo.codigo = dr(1).ToString

                ' Convertir fecha de emisión y quitar la hora
                Dim fechaEmision As DateTime
                If DateTime.TryParse(dr(2).ToString, fechaEmision) Then
                    modelo.fechaEmision = fechaEmision.ToString("yyyy/MM/dd")
                Else
                    modelo.fechaEmision = String.Empty ' o manejar el error de conversión según sea necesario
                End If

                ' Convertir fecha de vencimiento y quitar la hora
                Dim fechaVencimiento As DateTime
                If DateTime.TryParse(dr(3).ToString, fechaVencimiento) Then
                    modelo.fechaVencimiento = fechaVencimiento.ToString("yyyy/MM/dd")
                Else
                    modelo.fechaVencimiento = String.Empty ' o manejar el error de conversión según sea necesario
                End If

                modelo.numero = dr(4).ToString
                modelo.cuentaIBAN = dr(5).ToString

                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' Elimina un certificado de inscripción primario de la base de datos.
    ''' <param name="codigo">El código del certificado a eliminar.</param>
    ''' <returns>El código del certificado eliminado.</returns>
    Public Function eliminarCertificacion(ByVal codigo As String) As String
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones())
            cn.Open()
            Dim sql = "Delete From GC_CERTIFICACION_SUPLIDORES where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", codigo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return codigo
    End Function

    ''' Busca los campos requeridos para el documento especifico.
    ''' <param name="documento">El codigo del certificado o documento que se necesita buscar.</param>
    ''' <returns>un modelo con los campos necesarios para ese documento.</returns>
    Public Function buscarCamposDocumento(ByVal documento As String) As TipoCertificado
        Dim campos As New TipoCertificado
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * from GC_TIPO_CERTIFICADO_SUPLIDORES WHERE CODIGO = @DOCUMENTO"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@DOCUMENTO", documento)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                campos.campoNumero = dr(3)
                campos.campoFechaEmision = dr(4)
                campos.campoFechaVencimiento = dr(5)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return campos
    End Function

    ' Busca y retorna una colección de tipos de certificado desde la base de datos.
    ' <returns> Una colección de objetos Certificaciones. </returns>
    Public Function buscarListaBancos() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_BANCOS"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New Certificaciones
                modelo.codigoBanco = dr(0).ToString
                modelo.detalleBanco = dr(1).ToString
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
