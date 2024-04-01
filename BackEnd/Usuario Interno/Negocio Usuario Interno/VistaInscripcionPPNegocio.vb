Public Class VistaInscripcionPPNegocio


    Private Shared _instancia As VistaInscripcionPPNegocio = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase VistaIncripcionPPNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As VistaInscripcionPPNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New VistaInscripcionPPNegocio()
            End If
            Return _instancia
        End Get
    End Property


    ''' <summary>
    ''' Obtiene los datos de un productor basados en su número de inscripción.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor con los detalles del productor.</returns>
    Function traerDatosProductor(ByRef inscripcion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.traerDatosProductor(inscripcion)
    End Function

    ' Obtiene la ruta del archivo pdf.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Function buscarRutaArchivo(ByRef inscripcion As String) As Certificacion
        Return VistaInscripcionPPDAO.Instancia.buscarRutaArchivo(inscripcion)
    End Function

    ' Actualiza la condición de la verificación en campo a verdadera.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="codigo">codigo de la línea de datos a actualizar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function verificacionCampo(ByRef inscripcion As String, ByRef codigo As String) As DatosFormulario
        Return VistaInscripcionPPDAO.Instancia.verificacionCampo(inscripcion, codigo)
    End Function

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function buscarVerificacionCampo(ByRef inscripcion As String) As DatosFormulario
        Return VistaInscripcionPPDAO.Instancia.buscarVerificacionCampo(inscripcion)
    End Function

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="observacion">datos a insertar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function agregarObservaciones(ByRef observacion As String, ByRef inscripcion As String) As DatosFormulario
        Return VistaInscripcionPPDAO.Instancia.agregarObservaciones(observacion, inscripcion)
    End Function

    ' Actualiza el area de revision del formulario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="areaRevision">estado del area de revision.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function enviarSolicitud(ByRef areaRevision As String, ByRef inscripcion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.enviarSolicitud(areaRevision, inscripcion)
    End Function

    ' Obtiene las observaciones agregadas en las lineas de abastecimiento.
    ''' <param name="Productor">Código del productor.</param>
    ''' <returns>Una colección de objetos líneas de abastecimiento asociados al productor.</returns>
    Public Function traerObservaciones(ByVal Productor As String) As DatosFormulario
        Return VistaInscripcionPPDAO.Instancia.traerObservaciones(Productor)
    End Function

    ' Subsana la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function subsanarSoliPP(ByRef inscripcion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.subsanarSoliPP(inscripcion)
    End Function

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="observacion">datos a insertar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function actualizarProductorSubs(ByRef inscripcion As String, ByRef numResolucion As String, ByRef observacion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.actualizarProductorSubs(inscripcion, numResolucion, observacion)
    End Function

    ' Actualiza la información de resolución de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <param name="numResolucion">Número de resolución agregado por un UI.</param>
    ''' <param name="fechaResolucion">fecha de devolución del formulario.</param>
    ''' <param name="condicion">condicion rechazada o aceptada del formulario.</param>
    ''' <param name="observaciones">observaciones opcionales agregadas por el funcionario.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function actualizarInscripPP(ByRef inscripcion As String, ByRef numResolucion As String, ByRef fechaResolucion As String, ByRef condicion As String, ByRef observaciones As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.actualizarInscripPP(inscripcion, numResolucion, fechaResolucion, condicion, observaciones)
    End Function

    ' Elimina los datos de la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarInfoPP(ByRef inscripcion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.borrarInfoPP(inscripcion)
    End Function

    ' Elimina los datos deL representante legal de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarRLPP(ByRef inscripcion As String) As RepresentanteLegal
        Return VistaInscripcionPPDAO.Instancia.borrarRLPP(inscripcion)
    End Function

    ' Elimina los datos de la información contable de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarLineaAbPP(ByRef inscripcion As String) As LineaAbastecimiento
        Return VistaInscripcionPPDAO.Instancia.borrarLineaAbPP(inscripcion)
    End Function

    ' Elimina los datos de la información sobre certificaciones de un usuario.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarCertPP(ByRef inscripcion As String) As Certificacion
        Return VistaInscripcionPPDAO.Instancia.borrarCertPP(inscripcion)
    End Function

    ' Obtiene los datos de la resolución de una inscripción de un productor.
    ''' <param name="inscripcion">Número de inscripción del productor.</param>
    ''' <returns>Un objeto Productor con los detalles del productor.</returns>
    Function cargarResolucion(ByRef inscripcion As String) As Productor
        Return VistaInscripcionPPDAO.Instancia.cargarResolucion(inscripcion)
    End Function
End Class
