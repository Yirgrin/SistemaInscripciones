Public Class NuevosFormsSANegocio

    Private Shared _instancia As NuevosFormsSANegocio = Nothing
    ''' <summary>
    ''' Propiedad de solo lectura para obtener una instancia única de la clase NuevosFormsSANegocio.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As NuevosFormsSANegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New NuevosFormsSANegocio()
            End If
            Return _instancia
        End Get
    End Property


    ' Busca las inscripciones de Suplidores de Acopio en la base de datos que coincidan con la sesión Región y paso de revision AEO.
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function AEOcargarInscripSA(ByVal region As String) As Collection
        Return NuevosFormsSADAO.Instancia.AEOcargarInscripSA(region)
    End Function

    ' Busca las inscripciones de Suplidores de Acopio en la base de datos que coincidan con la sesión Región y paso de revision Direc Regional.
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function DirecRegCargarInscripSA(ByVal region As String) As Collection
        Return NuevosFormsSADAO.Instancia.DirecRegCargarInscripSA(region)
    End Function

    ' Busca las inscripciones de Suplidores de Acopio en la base de datos que coincidan con lo que digitó el usuario en el espacio de búsqueda.
    ''' <param name="busqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function buscarInscripcionSA(ByVal busqueda As String) As Collection
        Return NuevosFormsSADAO.Instancia.buscarInscripcionSA(busqueda)
    End Function

    ' Busca las inscripciones del archivo de Suplidor de acopio en la base de datos que coincidan con lo que digitó el usuario en el espacio de búsqueda.
    ''' <param name="busqueda">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function buscarArchivoSA(ByVal busqueda As String) As Collection
        Return NuevosFormsSADAO.Instancia.buscarArchivoSA(busqueda)
    End Function

    ' Busca las inscripciones de Suplidores de Acopio en la base de datos que estén en el rol de dirección de mercadeo
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function DirecMercCargarInscripSA() As Collection
        Return NuevosFormsSADAO.Instancia.DirecMercCargarInscripSA()
    End Function

    ' Busca las inscripciones de Suplidores de Acopio en la base de datos que estén en el rol de comercialización
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function ComerCargarInscripSA() As Collection
        Return NuevosFormsSADAO.Instancia.ComerCargarInscripSA()
    End Function

    ' Busca las inscripciones de Suplidores de acopio en la base de datos que coincidan con la sesión Región, 
    ' que estén en el rol de dirección de AEO o Director Regional y que estén aprovadas o rechazadas
    ''' <param name="region">La region con la cual deben coincidir las inscripciones que se van a mostrar.</param>
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function RegArchivoSA(ByVal region As String) As Collection
        Return NuevosFormsSADAO.Instancia.RegArchivoSA(region)
    End Function

    ' Busca las inscripciones de Suplidores de acopio en la base de datos que estén en el rol de comercialización o mercadeo y que estén aprovadas o rechazadas 
    ''' <returns>Una colección de objetos Inscripciones de los suplidores de acopio.</returns>
    Public Function ArchivosSA() As Collection
        Return NuevosFormsSADAO.Instancia.ArchivosSA()
    End Function
End Class
