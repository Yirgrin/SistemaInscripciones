''' <summary>
''' Clase que representa la lógica de negocio relacionada con los Representantes Legales.
''' </summary>
Public Class RepLegalNegocio

    Private Shared _instancia As RepLegalNegocio = Nothing

    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase RepLegalNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As RepLegalNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New RepLegalNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta un Representante Legal en una inscripción de productor.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="cedula">Cédula del Representante Legal.</param>
    ''' <param name="nombre">Nombre del Representante Legal.</param>
    ''' <param name="genero">Género del Representante Legal.</param>
    ''' <param name="telefono">Teléfono fijo del Representante Legal.</param>
    ''' <param name="celular">Teléfono móvil del Representante Legal.</param>
    ''' <param name="correo">Correo electrónico del Representante Legal.</param>
    ''' <returns>Un objeto RepresentanteLegal que representa el Representante Legal insertado.</returns>
    Public Function insertarRepLegal(ByVal inscripcion As String, ByVal cedula As String, ByVal nombre As String, ByVal genero As String,
                                     ByVal telefono As String, ByVal celular As String, ByVal correo As String, ByVal check As String) As RepresentanteLegal
        Dim modelo As New RepresentanteLegal
        modelo.inscripcion = inscripcion
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.genero = genero
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.email = correo
        modelo.sinRepLegal = check
        Return RepLegalDAO.Instancia.insertarRepLegal(modelo)
    End Function

    ''' <summary>
    ''' Obtiene los datos del Representante Legal asociado a una inscripción de productor.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto RepresentanteLegal que contiene los datos del Representante Legal.</returns>
    Function traerDatosRepLegal(ByRef inscripcion As String) As RepresentanteLegal
        Return RepLegalDAO.Instancia.traerDatosRepLegal(inscripcion)
    End Function


    ' Obtiene los datos del Representante Legal asociado a una inscripción de productor.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto RepresentanteLegal que contiene los datos del Representante Legal.</returns>
    Function cargarRLSuplidor(ByRef inscripcion As String) As RepresentanteLegal
        Return RepLegalDAO.Instancia.cargarRLSuplidor(inscripcion)
    End Function


    ' Inserta un Representante Legal en una inscripción de productor.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="cedula">Cédula del Representante Legal.</param>
    ''' <param name="nombre">Nombre del Representante Legal.</param>
    ''' <param name="genero">Género del Representante Legal.</param>
    ''' <param name="telefono">Teléfono fijo del Representante Legal.</param>
    ''' <param name="celular">Teléfono móvil del Representante Legal.</param>
    ''' <param name="correo">Correo electrónico del Representante Legal.</param>
    ''' <returns>Un objeto RepresentanteLegal que representa el Representante Legal insertado.</returns>
    Public Function insertarRLSuplidor(ByVal inscripcion As String, ByVal cedula As String, ByVal nombre As String, ByVal genero As String,
                                     ByVal telefono As String, ByVal celular As String, ByVal correo As String, ByVal check As String) As RepresentanteLegal
        Dim modelo As New RepresentanteLegal
        modelo.inscripcion = inscripcion
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.genero = genero
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.email = correo
        modelo.sinRepLegal = check
        Return RepLegalDAO.Instancia.insertarRLSuplidor(modelo)
    End Function
End Class
