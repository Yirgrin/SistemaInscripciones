''' <summary>
''' Clase que contiene métodos de negocio relacionados con la certificación de productores.
''' </summary>
Public Class CertificadoNegocio

    Private Shared _instancia As CertificadoNegocio = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase CertificadoNegocio utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As CertificadoNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New CertificadoNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta un certificado de inscripción en la base de datos.
    ''' </summary>
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
                                       ByVal fechaEmision As String, ByVal fechaVence As String, ByVal estado As String) As Certificacion
        Dim modelo As New Certificacion
        modelo.productor = inscripcion
        modelo.tipoCertificado = tipoCertificado
        modelo.numero = numeroC
        modelo.archivo = rutaArch
        modelo.extencion = extension
        modelo.fechaEmision = fechaEmision
        modelo.fechaVencimiento = fechaVence
        modelo.estado = estado
        Return CertificadoDAO.Instancia.insertarCertificado(modelo)
    End Function

    ''' <summary>
    ''' Busca los certificados de inscripción de un productor en la base de datos y los devuelve en una colección.
    ''' </summary>
    ''' <param name="inscripcion">La inscripción del productor cuyos certificados se buscan.</param>
    ''' <returns>Una colección de objetos Certificacion que representan los certificados de inscripción.</returns>
    Public Function buscarCertificacionInscripcion(ByVal inscripcion As String) As Collection
        Return CertificadoDAO.Instancia.buscarCertifiInscripcion(inscripcion)
    End Function

    ''' <summary>
    ''' Elimina un certificado de inscripción de la base de datos.
    ''' </summary>
    ''' <param name="codigo">El código del certificado a eliminar.</param>
    ''' <returns>El código del certificado eliminado.</returns>
    Public Function eliminarCertificadoInscripcion(ByVal codigo As String) As String
        Return CertificadoDAO.Instancia.eliminarCertificaInnPrimario(codigo)
    End Function

    ''' <summary>
    ''' Trae la lista de campos requeridos para el certificado especifico.
    ''' </summary>
    ''' <param name="documento">El código del certificado.</param>
    ''' <returns>El modelo con los campos requeridos.</returns>
    Public Function buscarCamposDocumento(ByVal documento As String) As TipoCertificado
        Return CertificadoDAO.Instancia.buscarCamposDocumento(documento)
    End Function

End Class
