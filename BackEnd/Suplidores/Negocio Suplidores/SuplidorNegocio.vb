' Clase que representa la lógica de negocio relacionada con los suplidores.

Public Class SuplidorNegocio


    Private Shared _instancia As SuplidorNegocio = Nothing

    ' Propiedad de solo lectura para obtener una instancia única de la clase SuplidorNegocio.
    Public Shared ReadOnly Property Instancia As SuplidorNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New SuplidorNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ' Inserta una nueva inscripción de un suplidor en la base de datos.
    ''' <param name="cedula">Número de cédula del suplidor.</param>
    ''' <param name="nombre">Nombre del suplidor.</param>
    ''' <param name="tipoCedula">Tipo de cédula del suplidor.</param>
    ''' <param name="correo">Correo electrónico del suplidor.</param>
    ''' <param name="telefono">Teléfono fijo del suplidor.</param>
    ''' <param name="celular">Teléfono móvil del suplidor.</param>
    ''' <param name="actividadHM">Actividad registrada en Ministerio de Hacienda.</param>
    ''' <param name="direccion">Dirección de residencia del suplidor.</param>
    ''' <param name="distrito">Distrito del suplidor.</param>
    ''' <param name="region">Region donde reside el suplidor.</param>
    ''' <returns>Número de inscripción o un mensaje que indica si la inserción fue exitosa.</returns>
    Public Function insertarInscripcionSuplidor(ByVal cedula As String, ByVal nombre As String,
                                                ByVal tipoCedula As String, ByVal genero As String, ByVal correo As String,
                                                ByVal telefono As String, ByVal celular As String,
                                                ByVal actividadHM As String, ByVal direccion As String,
                                                ByVal distrito As String, ByVal region As String, ByVal fecha As String,
                                                ByVal provincia As String, ByVal canton As String) As String


        Dim modelo As New Suplidor
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.tipoCedula = tipoCedula
        modelo.genero = genero
        modelo.email = correo
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.ActividadHM = actividadHM
        modelo.direccionResidencia = direccion
        modelo.codDistrito = distrito
        modelo.codRegion = region
        modelo.fecha_envio = fecha
        modelo.codProvincia = provincia
        modelo.codCanton = canton

        Return SuplidorDAO.Instancia.insertarInscripcionSuplidor(modelo)
    End Function


    ' Actualiza la inscripción de un suplidor existente en la base de datos.
    ''' <param name="cedula">Número de cédula del suplidor.</param>
    ''' <param name="nombre">Nombre del suplidor.</param>
    ''' <param name="tipoCedula">Tipo de cédula del suplidor.</param>
    ''' <param name="correo">Correo electrónico del suplidor.</param>
    ''' <param name="telefono">Teléfono fijo del suplidor.</param>
    ''' <param name="celular">Teléfono móvil del suplidor.</param>
    ''' <param name="actividadHM">Actividad registrada en Ministerio de Hacienda.</param>
    ''' <param name="direccion">Dirección de residencia del suplidor.</param>
    ''' <param name="distrito">Distrito del suplidor.</param>
    ''' <param name="region">Region donde reside el suplidor.</param>
    ''' <returns>Número de inscripción o un mensaje que indica si la inserción fue exitosa.</returns>
    Public Function actualizarInscripcionSuplidor(ByVal inscripcion As String, ByVal cedula As String, ByVal nombre As String,
                                                ByVal tipoCedula As String, ByVal genero As String, ByVal correo As String,
                                                ByVal telefono As String, ByVal celular As String,
                                                ByVal actividadHM As String, ByVal direccion As String,
                                                ByVal distrito As String, ByVal region As String, ByVal fecha As String,
                                                ByVal provincia As String, ByVal canton As String) As Suplidor
        Dim modelo As New Suplidor
        modelo.cedula = cedula
        modelo.nombre = nombre
        modelo.tipoCedula = tipoCedula
        modelo.genero = genero
        modelo.email = correo
        modelo.telefonoFijo = telefono
        modelo.telefonoMovil = celular
        modelo.ActividadHM = actividadHM
        modelo.direccionResidencia = direccion
        modelo.codDistrito = distrito
        modelo.codRegion = region
        modelo.fecha_envio = fecha
        modelo.codProvincia = provincia
        modelo.codCanton = canton

        Return SuplidorDAO.Instancia.actualizarInscripcionSuplidor(inscripcion, modelo)
    End Function

    ' Obtiene una lista de estados de inscripción de un suplidor a partir de su número de cédula.
    ''' <param name="cedula">El número de cédula del suplidor.</param>
    ''' <returns>Una lista de objetos EstadosInscripcion.</returns>
    Function buscarEstadosInscripcion(ByVal cedula As String) As List(Of EstadosInscripcion)
        Return SuplidorDAO.Instancia.buscarEstadosInscripcion(cedula)
    End Function

    ' Obtiene los datos de un suplidor basados en su número de inscripción.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor con los detalles del suplidor.</returns>
    Function cargarDatosSuplidor(ByRef inscripcion As String) As Suplidor
        Return SuplidorDAO.Instancia.cargarDatosSuplidor(inscripcion)
    End Function

    ' Actualiza el estado de una inscripción de productor en la base de datos.
    ''' <param name="inscripcion">Número de inscripción a actualizar.</param>
    ''' <returns>True si la actualización fue exitosa, False en caso contrario.</returns>
    Function actualizarEstadoInscripcion(ByVal inscripcion As String) As Boolean
        Return SuplidorDAO.Instancia.actualizarEstadoInscripcion(inscripcion)
    End Function

    ''' <summary>
    ''' Obtiene los datos del historial de un suplidor basados en su número de cédula.
    ''' </summary>
    ''' <param name="cedula">Número de cédula del suplidor.</param>
    ''' <returns>Un objeto Suplidor con los detalles del historial.</returns>
    Function traerHistorial(ByVal cedula As String) As List(Of Suplidor)
        Return SuplidorDAO.Instancia.traerHistorial(cedula)
    End Function

End Class
