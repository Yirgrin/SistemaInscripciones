''' <summary>
''' Clase que representa la lógica de negocio relacionada con los productores.
''' </summary>
Public Class ProductorNegocio

    Private Shared _instancia As ProductorNegocio = Nothing

    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase ProductorNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As ProductorNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New ProductorNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Actualiza el estado de una inscripción de productor en la base de datos.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción a actualizar.</param>
    ''' <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
    Function actualizarEstadoInscripcion(ByVal inscripcion As String) As Boolean
        Return ProductorDAO.Instancia.actualizarEstadoInscripcion(inscripcion)
    End Function

    ''' <summary>
    ''' Inserta una nueva inscripción de productor en la base de datos.
    ''' </summary>
    ''' <param name="tipoCedula">Tipo de cédula del productor.</param>
    ''' <param name="cedula">Número de cédula del productor.</param>
    ''' <param name="nombre">Nombre del productor.</param>
    ''' <param name="genero">Género del productor.</param>
    ''' <param name="telefono">Teléfono fijo del productor.</param>
    ''' <param name="celular">Teléfono móvil del productor.</param>
    ''' <param name="correo">Correo electrónico del productor.</param>
    ''' <param name="distrito">Distrito de residencia del productor.</param>
    ''' <param name="direccion">Dirección de residencia del productor.</param>
    ''' <param name="tipoProductor">Tipo de productor.</param>
    ''' <param name="empresa">Empresa asociada al productor.</param>
    ''' <param name="ccss">Estado en la caja.</param>
    ''' <param name="provincia">Provincia de residencia del productor.</param>
    ''' <param name="canton">Cantón de residencia del productor.</param>
    ''' 
    ''' <returns>Número de inscripción o un mensaje que indica si la inserción fue exitosa.</returns>
    Public Function insertarInscripcionProductor(ByVal tipoCedula As String, ByVal cedula As String,
                                                 ByVal nombre As String, ByVal genero As String,
                                                 ByVal telefono As String, ByVal celular As String,
                                                 ByVal correo As String, ByVal distrito As String,
                                                 ByVal region As String, ByVal direccion As String,
                                                 ByVal tipoProductor As String, ByVal empresa As String,
                                                 ByVal ccss As String, ByVal etnia As String,
                                                 ByVal ingresosPropios As String, ByVal soloAgricola As String,
                                                 ByVal dependientes As String, ByVal estadoCivil As String,
                                                 ByVal hijosMenores As String, ByVal escolaridad As String,
                                                 ByVal discapacidad As String, ByVal conapdis As String,
                                                 ByVal provincia As String, ByVal canton As String,
                                                 ByVal checkMH As String, ByVal checkMAG As String, ByVal fecha As String) As String

        Dim modelo As New Productor
        modelo.tipoCedula = tipoCedula
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.genero = genero
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.email = correo
        modelo.codDistrito = distrito
        modelo.codRegion = region
        modelo.direccionResidencia = direccion
        modelo.tipoProductor = tipoProductor
        modelo.empresaAsociada = empresa
        modelo.ccss = ccss

        modelo.etnia = etnia
        modelo.IngresosPropios = ingresosPropios
        modelo.SoloAgricola = soloAgricola
        modelo.Dependientes = dependientes
        modelo.EstadoCivil = estadoCivil
        modelo.HijosMenores = hijosMenores
        modelo.Escolaridad = escolaridad
        modelo.Discapacidad = discapacidad
        modelo.Conapdis = conapdis
        modelo.codProvincia = provincia
        modelo.codCanton = canton
        modelo.checkMH = checkMH
        modelo.checkMAG = checkMAG
        modelo.fecha_envio = fecha
        Return ProductorDAO.Instancia.insertarInscripcionProductor(modelo)
    End Function

    ''' <summary>
    ''' Actualiza la inscripción de un productor existente en la base de datos.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del productor a actualizar.</param>
    ''' <param name="tipoCedula">Tipo de cédula del productor.</param>
    ''' <param name="cedula">Número de cédula del productor.</param>
    ''' <param name="nombre">Nombre del productor.</param>
    ''' <param name="genero">Género del productor.</param>
    ''' <param name="telefono">Teléfono fijo del productor.</param>
    ''' <param name="celular">Teléfono móvil del productor.</param>
    ''' <param name="correo">Correo electrónico del productor.</param>
    ''' <param name="distrito">Distrito de residencia del productor.</param>
    ''' <param name="direccion">Dirección de residencia del productor.</param> ByVal provincia As String, ByVal canton As String
    ''' <param name="tipoProductor">Tipo de productor.</param>
    ''' <param name="empresa">Empresa asociada al productor.</param>
    ''' <param name="provincia">Provincia de residencia del productor.</param>
    ''' <param name="canton">Cantón de residencia del productor.</param>
    ''' <returns>Un objeto Productor actualizado.</returns>
    Public Function actualizarInscripcionProductor(ByVal inscripcion As String, ByVal tipoCedula As String, ByVal cedula As String,
                                                   ByVal nombre As String, ByVal genero As String, ByVal telefono As String,
                                                   ByVal celular As String, ByVal correo As String, ByVal distrito As String,
                                                   ByVal region As String, ByVal direccion As String, ByVal tipoProductor As String,
                                                   ByVal empresa As String, ByVal ccss As String, ByVal etnia As String,
                                                   ByVal ingresosPropios As String, ByVal soloAgricola As String,
                                                   ByVal dependientes As String, ByVal estadoCivil As String,
                                                   ByVal hijosMenores As String, ByVal escolaridad As String,
                                                   ByVal discapacidad As String, ByVal conapdis As String,
                                                   ByVal provincia As String, ByVal canton As String,
                                                   ByVal checkMH As String, ByVal checkMAG As String, ByVal fecha As String) As Productor
        Dim modelo As New Productor
        modelo.tipoCedula = tipoCedula
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.genero = genero
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.email = correo
        modelo.codDistrito = distrito
        modelo.codRegion = region
        modelo.direccionResidencia = direccion
        modelo.tipoProductor = tipoProductor
        modelo.empresaAsociada = empresa
        modelo.ccss = ccss

        modelo.etnia = etnia
        modelo.IngresosPropios = ingresosPropios
        modelo.SoloAgricola = soloAgricola
        modelo.Dependientes = dependientes
        modelo.EstadoCivil = estadoCivil
        modelo.HijosMenores = hijosMenores
        modelo.Escolaridad = escolaridad
        modelo.Discapacidad = discapacidad
        modelo.Conapdis = conapdis
        modelo.codProvincia = provincia
        modelo.codCanton = canton
        modelo.checkMH = checkMH
        modelo.checkMAG = checkMAG
        modelo.fecha_envio = fecha

        Return ProductorDAO.Instancia.actualizarInscripcionProductor(inscripcion, modelo)
    End Function

    ''' <summary>
    ''' Obtiene los datos de un productor basados en su número de inscripción.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor con los detalles del productor.</returns>
    Function traerDatosProductor(ByRef inscripcion As String) As Productor
        Return ProductorDAO.Instancia.traerDatosProductor(inscripcion)
    End Function

    ''' <summary>
    ''' Obtiene los datos del historial de un productor basados en su número de cédula.
    ''' </summary>
    ''' <param name="cedula">Número de cédula del productor.</param>
    ''' <returns>Un objeto Productor con los detalles del historial.</returns>
    Function traerHistorial(ByVal cedula As String) As List(Of Productor)
        Return ProductorDAO.Instancia.traerHistorial(cedula)
    End Function

    ''' <summary>
    ''' Obtiene una lista de estados de inscripción de un productor a partir de su número de cédula.
    ''' </summary>
    ''' <param name="cedula">El número de cédula del productor.</param>
    ''' <returns>Una lista de objetos EstadosInscripcion.</returns>
    Function buscarEstadosInscripcion(ByVal cedula As String) As List(Of EstadosInscripcion)
        Return ProductorDAO.Instancia.buscarEstadosInscripcion(cedula)
    End Function

End Class
