Public Class VistaInscripcionSANegocio

    Private Shared _instancia As VistaInscripcionSANegocio = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase VistaInscripcionSANegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As VistaInscripcionSANegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New VistaInscripcionSANegocio()
            End If
            Return _instancia
        End Get
    End Property


    ''' <summary>
    ''' Obtiene los datos de un suplidor basados en su número de inscripción.
    ''' </summary>
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Productor con los detalles del suplidor.</returns>
    Function traerDatosSuplidor(ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.traerDatosSuplidor(inscripcion)
    End Function

    ' Obtiene los datos de Información Contable asociado a una inscripción de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto ActividadContable que contiene los datos de Información Contable.</returns>
    Function cargarDatosContables(ByRef inscripcion As String) As ActividadContable
        Return VistaInscripcionSADAO.Instancia.cargarDatosContables(inscripcion)
    End Function

    ''' <summary>
    ''' Obtiene los datos para hacer la formula de clasificacion de suplidores.
    ''' </summary>
    ''' <returns>Un objeto FormulaClasificacion con los detalles de la formula.</returns>
    Function traerFormulaIndustria() As FormulaClasificacion
        Return VistaInscripcionSADAO.Instancia.traerFormulaIndustria()
    End Function

    ' Obtiene la ruta del archivo pdf.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la ruta.</returns>
    Function buscarRutaArchivo(ByRef inscripcion As String) As Certificaciones
        Return VistaInscripcionSADAO.Instancia.buscarRutaArchivo(inscripcion)
    End Function

    ' Obtiene la cuenta IBAN del usuario
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Certificacion que contiene los datos de la cuenta.</returns>
    Function buscarCuentaIBAN(ByRef inscripcion As String) As Certificaciones
        Return VistaInscripcionSADAO.Instancia.buscarCuentaIBAN(inscripcion)
    End Function

    ' Actualiza el area de revision del formulario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="areaRevision">estado del area de revision.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function enviarSolicitud(ByRef areaRevision As String, ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.enviarSolicitud(areaRevision, inscripcion)
    End Function

    ' Subsana la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function subsanarSoliPP(ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.subsanarSoliPP(inscripcion)
    End Function

    ' Busca y carga si la verificación en campo está completada.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="observacion">datos a insertar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function actualizarSuplidorSubs(ByRef inscripcion As String, ByRef numResolucion As String, ByRef observacion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.actualizarSuplidorSubs(inscripcion, numResolucion, observacion)
    End Function

    ' Guarda los datos de la inspección técnica
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="usuarioInterno">nombre del usuario interno</param>
    ''' <param name="fechaInspeccion">datos a insertar.</param>
    ''' <param name="numSolicitud">datos a insertar.</param>
    ''' <param name="fechaSolicitud">datos a insertar.</param>
    ''' <param name="numInforme">datos a insertar.</param>
    ''' <param name="fechaInforme">datos a insertar.</param>
    ''' <param name="resultadoMayor">datos a insertar.</param>
    ''' <param name="resultadoMenor">datos a insertar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function guardarInspeccion(ByRef inscripcion As String, ByRef usuarioInterno As String, ByRef fechaInspeccion As String,
                               ByRef numSolicitud As String, ByRef fechaSolicitud As String, ByRef numInforme As String,
                               ByRef fechaInforme As String, ByRef resultadoMayor As String, ByRef resultadoMenor As String) As String


        Dim modelo As New InspeccionTecnica
        modelo.suplidor = inscripcion
        modelo.realizadaPor = usuarioInterno
        modelo.fechaInspeccion = fechaInspeccion
        modelo.numSolicitud = numSolicitud
        modelo.fechaSolicitud = fechaSolicitud
        modelo.numOficio = numInforme
        modelo.fechaOficio = fechaInforme
        modelo.cumplimientoMayor = resultadoMayor
        modelo.cumplimientoMenor = resultadoMenor


        Return VistaInscripcionSADAO.Instancia.guardarInspeccion(modelo)
    End Function

    ' Actualiza la información de resolución de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="numResolucion">Número de resolución agregado por un UI.</param>
    ''' <param name="fechaResolucion">fecha de devolución del formulario.</param>
    ''' <param name="condicion">condicion rechazada o aceptada del formulario.</param>
    ''' <param name="observaciones">observaciones opcionales agregadas por el funcionario.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function actualizarInscripSA(ByRef inscripcion As String, ByRef numResolucion As String, ByRef fechaResolucion As String, ByRef condicion As String, ByRef observaciones As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.actualizarInscripSA(inscripcion, numResolucion, fechaResolucion, condicion, observaciones)
    End Function

    ' Elimina los datos de la inscripción de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarInfoSA(ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.borrarInfoSA(inscripcion)
    End Function

    ' Elimina los datos deL representante legal de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarRLSA(ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.borrarRLSA(inscripcion)
    End Function

    ' Elimina los datos de la información contable de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarInfoContaSA(ByRef inscripcion As String) As ActividadContable
        Return VistaInscripcionSADAO.Instancia.borrarInfoContaSA(inscripcion)
    End Function

    ' Elimina los datos de la información sobre certificaciones de un usuario.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Suplidor que contiene los datos.</returns>
    Function borrarCertSA(ByRef inscripcion As String) As Certificaciones
        Return VistaInscripcionSADAO.Instancia.borrarCertSA(inscripcion)
    End Function

    ' actualiza la información de inspección técnica.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <param name="usuarioInterno">nombre del usuario interno</param>
    ''' <param name="fechaInspeccion">datos a insertar.</param>
    ''' <param name="numSolicitud">datos a insertar.</param>
    ''' <param name="fechaSolicitud">datos a insertar.</param>
    ''' <param name="numInforme">datos a insertar.</param>
    ''' <param name="fechaInforme">datos a insertar.</param>
    ''' <param name="resultadoMayor">datos a insertar.</param>
    ''' <param name="resultadoMenor">datos a insertar.</param>
    ''' <returns>Un objeto DatosFormulario que contiene los datos.</returns>
    Function actualizarInspeccion(ByRef inscripcion As String, ByRef usuarioInterno As String, ByRef fechaInspeccion As String,
                               ByRef numSolicitud As String, ByRef fechaSolicitud As String, ByRef numInforme As String,
                               ByRef fechaInforme As String, ByRef resultadoMayor As String, ByRef resultadoMenor As String) As String


        Dim modelo As New InspeccionTecnica
        modelo.suplidor = inscripcion
        modelo.realizadaPor = usuarioInterno
        modelo.fechaInspeccion = fechaInspeccion
        modelo.numSolicitud = numSolicitud
        modelo.fechaSolicitud = fechaSolicitud
        modelo.numOficio = numInforme
        modelo.fechaOficio = fechaInforme
        modelo.cumplimientoMayor = resultadoMayor
        modelo.cumplimientoMenor = resultadoMenor


        Return VistaInscripcionSADAO.Instancia.actualizarInspeccion(modelo)
    End Function

    ' Obtiene los datos de la inspección técnica basados en su número de inscripción.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Productor con los detalles del suplidor.</returns>
    Function cargarInspeccion(ByRef inscripcion As String) As InspeccionTecnica
        Return VistaInscripcionSADAO.Instancia.cargarInspeccion(inscripcion)
    End Function

    ' Obtiene los datos de la resolucion de una inscripción de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto Productor con los detalles del suplidor.</returns>
    Function cargarResolucion(ByRef inscripcion As String) As Suplidor
        Return VistaInscripcionSADAO.Instancia.cargarResolucion(inscripcion)
    End Function
End Class
