Public Class CertificacionesNegocio

    Private Shared _instancia As CertificacionesNegocio = Nothing

    ' Obtiene una instancia única de la clase CertificacionesNegocio utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As CertificacionesNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New CertificacionesNegocio()
            End If
            Return _instancia
        End Get
    End Property


    ' Inserta un certificado de inscripción en la base de datos.
    ''' <param name="inscripcion">La inscripción del productor.</param>
    ''' <param name="tipoCertificado">El tipo de certificado.</param>
    ''' <param name="numeroC">El número del certificado.</param>
    ''' <param name="rutaArch">La ruta del archivo del certificado.</param>
    ''' <param name="extension">La extensión del archivo del certificado.</param>
    ''' <param name="fechaEmision">La fecha de emisión del certificado.</param>
    ''' <param name="fechaVence">La fecha de vencimiento del certificado.</param>
    ''' <param name="estado">El estado del certificado.</param>
    ''' <returns>El objeto Certificacion insertado.</returns>
    Public Function insertarCertificado(ByVal inscripcion As String, ByVal tipoCertificado As String, ByVal numeroC As String,
                                       ByVal rutaArch As String, ByVal extension As String,
                                       ByVal fechaEmision As String, ByVal fechaVence As String,
                                       ByVal estado As String, ByVal cuentaIBAN As String, ByVal banco As String) As Certificaciones
        Dim modelo As New Certificaciones
        modelo.suplidor = inscripcion
        modelo.tipoCertificado = tipoCertificado
        modelo.numero = numeroC
        modelo.archivo = rutaArch
        modelo.extencion = extension
        modelo.fechaEmision = fechaEmision
        modelo.fechaVencimiento = fechaVence
        modelo.estado = estado
        modelo.cuentaIBAN = cuentaIBAN
        modelo.codigoBanco = banco
        Return CertificacionesDAO.Instancia.insertarCertificado(modelo)
    End Function

    ' Busca los certificados de inscripción de un suplidor en la base de datos y los devuelve en una colección.
    ''' <param name="inscripcion">La inscripción del suplidor cuyos certificados se buscan.</param>
    ''' <returns>Una colección de objetos Certificacion que representan los certificados de inscripción.</returns>
    Public Function buscarCertificacionInscripcion(ByVal inscripcion As String) As Collection
        Return CertificacionesDAO.Instancia.buscarCertifiInscripcion(inscripcion)
    End Function

    ' Elimina un certificado de inscripción de la base de datos.
    ''' <param name="codigo">El código del certificado a eliminar.</param>
    ''' <returns>El código del certificado eliminado.</returns>
    Public Function eliminarCertificacion(ByVal codigo As String) As String
        Return CertificacionesDAO.Instancia.eliminarCertificacion(codigo)
    End Function

    ''' Trae la lista de campos requeridos para el certificado especifico.
    ''' <param name="documento">El código del certificado.</param>
    ''' <returns>El modelo con los campos requeridos.</returns>
    Public Function buscarCamposDocumento(ByVal documento As String) As TipoCertificado
        Return CertificacionesDAO.Instancia.buscarCamposDocumento(documento)
    End Function

    ' Busca y retorna una colección de tipos de banco.
    ''' <returns>Una colección de objetos de tipos de certificaciones.</returns>
    Public Function buscarListaBancos() As Collection
        Return CertificacionesDAO.Instancia.buscarListaBancos()
    End Function
End Class
