Public Class NuevosFormsPPNegocio

    Private Shared _instancia As NuevosFormsPPNegocio = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase NuevosFormsPPNegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As NuevosFormsPPNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New NuevosFormsPPNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ' Busca las inscripciones de Productor Primario en la base de datos que coincidan con la sesión Región y que estén en el rol de dirección de AEO
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function AEOcargarInscripPP(ByVal region As String) As Collection
        Return NuevosFormsPPDAO.Instancia.AEOcargarInscripPP(region)
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que coincidan con la sesión Región y que estén en el rol de dirección regional
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function DirecRegCargarInscripPP(ByVal region As String) As Collection
        Return NuevosFormsPPDAO.Instancia.DirecRegCargarInscripPP(region)
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que estén en el rol de dirección de mercadeo
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function DirecMercCargarInscripPP() As Collection
        Return NuevosFormsPPDAO.Instancia.DirecMercCargarInscripPP()
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que estén en el rol de comercialización
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function ComerCargarInscripPP() As Collection
        Return NuevosFormsPPDAO.Instancia.ComerCargarInscripPP()
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que coincidan con lo que digitó el usuario en el espacio de búsqueda.
    ''' <param name="busqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function buscarInscripcionPP(ByVal busqueda As String) As Collection
        Return NuevosFormsPPDAO.Instancia.buscarInscripcionPP(busqueda)
    End Function

    ' Busca las inscripciones del archivo de Productor Primario en la base de datos que coincidan con lo que digitó el usuario en el espacio de búsqueda.
    ''' <param name="busqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function buscarArchivoPP(ByVal busqueda As String) As Collection
        Return NuevosFormsPPDAO.Instancia.buscarArchivoPP(busqueda)
    End Function

    ' Busca las inscripciones de Productor Primario en la base de datos que coincidan con la sesión Región, 
    ' que estén en el rol de dirección de AEO o Director Regional y que estén aprovadas o rechazadas
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function RegArchivoPP(ByVal region As String) As Collection
        Return NuevosFormsPPDAO.Instancia.RegArchivoPP(region)
    End Function


    ' Busca las inscripciones de Productor Primario en la base de datos que estén en el rol de comercialización o mercadeo y que estén aprovadas o rechazadas 
    ''' <returns>Una colección de objetos Inscripciones de los productores primarios.</returns>
    Public Function ArchivosPP() As Collection
        Return NuevosFormsPPDAO.Instancia.ArchivosPP()
    End Function
End Class
