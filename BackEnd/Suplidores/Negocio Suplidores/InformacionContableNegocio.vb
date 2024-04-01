' clase que contiene métodos para comunicarse con la BD sobre la información contable de la empresa.

Public Class InformacionContableNegocio


    Private Shared _instancia As InformacionContableNegocio = Nothing
    ' Instancia única de la clase InformacionContableNegocio utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As InformacionContableNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New InformacionContableNegocio()
            End If
            Return _instancia
        End Get
    End Property


    Public Function cargarLineasProduccion() As Collection
        Return InformacionContableDAO.Instancia.cargarLineasProduccion()
    End Function


    Public Function InsertarInfoContable(ByVal Session As String, ByVal lineaProduc As String, ByVal cantEmpleados As String,
                                         ByVal ventasNetas As String, ByVal activosFijos As String, ByVal activosTotales As String,
                                         ByVal clasificacion As String, ByVal provincia As String, ByVal canton As String,
                                         ByVal distrito As String, ByVal direcExacta As String, ByVal region As String) As ActividadContable
        Dim modelo As New ActividadContable
        modelo.inscripcion = Session
        modelo.actividadPrincipal = lineaProduc
        modelo.cantidadEmpleados = cantEmpleados
        modelo.ventasNetas = ventasNetas
        modelo.activosFijos = activosFijos
        modelo.activosTotales = activosTotales
        modelo.codigoProduccion = clasificacion
        modelo.codProvincia = provincia
        modelo.codCanton = canton
        modelo.codDistrito = distrito
        modelo.direcExacta = direcExacta
        modelo.codregion = region
        Return InformacionContableDAO.Instancia.InsertarInfoContable(modelo)

    End Function

    Public Function ActualizarInfoContable(ByVal inscripcion As String, ByVal lineaProduc As String, ByVal cantEmpleados As String,
                                         ByVal ventasNetas As String, ByVal activosFijos As String, ByVal activosTotales As String,
                                         ByVal clasificacion As String, ByVal provincia As String, ByVal canton As String,
                                         ByVal distrito As String, ByVal direcExacta As String, ByVal region As String) As ActividadContable

        Dim modelo As New ActividadContable

        modelo.inscripcion = inscripcion
        modelo.actividadPrincipal = lineaProduc
        modelo.cantidadEmpleados = cantEmpleados
        modelo.ventasNetas = ventasNetas
        modelo.activosFijos = activosFijos
        modelo.activosTotales = activosTotales
        modelo.codigoProduccion = clasificacion
        modelo.codProvincia = provincia
        modelo.codCanton = canton
        modelo.codDistrito = distrito
        modelo.direcExacta = direcExacta
        modelo.codregion = region

        Return InformacionContableDAO.Instancia.ActualizarInfoContable(inscripcion, modelo)
    End Function

    ' Obtiene los datos de Información Contable asociado a una inscripción de un suplidor.
    ''' <param name="inscripcion">Número de inscripción del suplidor.</param>
    ''' <returns>Un objeto ActividadContable que contiene los datos de Información Contable.</returns>
    Function cargarDatosContables(ByRef inscripcion As String) As ActividadContable
        Return InformacionContableDAO.Instancia.cargarDatosContables(inscripcion)
    End Function


End Class
