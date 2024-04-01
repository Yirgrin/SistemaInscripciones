''' <summary>
''' Clase que proporciona funcionalidades relacionadas con la información general del negocio.
''' </summary>
Public Class InformacionGralNegocio

    Private Shared _instancia As InformacionGralNegocio = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase InformacionGralNegocio utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As InformacionGralNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New InformacionGralNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Busca y retorna una colección de tipos de cédulas.
    ''' </summary>
    ''' <returns>Una colección de objetos de tipos de cédulas.</returns>
    Public Function buscarTipoCedulaColeccion() As Collection
        Return InformacionGralDAO.Instancia.buscarColeccionTipoCedulas()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de productores.
    ''' </summary>
    ''' <returns>Una colección de objetos de tipos de productores.</returns>
    Public Function buscarTipoProductorColeccion() As Collection
        Return InformacionGralDAO.Instancia.buscarColeccionTipoProductor()
    End Function


    ''' <summary>
    ''' Busca y retorna una colección de tipos de certificación.
    ''' </summary>
    ''' <returns>Una colección de objetos de tipos de certificación.</returns>
    Public Function buscarTipoCertificacion() As Collection
        'certificacion
        Return InformacionGralDAO.Instancia.buscarTipoCertifica()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de certificación.
    ''' </summary>
    ''' <returns>Una colección de objetos de tipos de certificación.</returns>
    Public Function buscarCertSuplidores() As Collection
        'certificacion
        Return InformacionGralDAO.Instancia.buscarCertSuplidores()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de provincias.
    ''' </summary>
    ''' <returns>Una colección de objetos de provincias.</returns>
    Public Function buscarProvincias() As Collection
        Return InformacionGralDAO.Instancia.buscarProvincias()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de cantones de una provincia específica.
    ''' </summary>
    ''' <param name="provincia">El código de provincia.</param>
    ''' <returns>Una colección de objetos de cantones.</returns>
    Public Function buscarCantones(ByVal provincia As String) As Collection
        Return InformacionGralDAO.Instancia.buscarCanton(provincia)
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de distritos de un cantón específico.
    ''' </summary>
    ''' <param name="canton">El código de cantón.</param>
    ''' <returns>Una colección de objetos de distritos.</returns>
    Public Function buscarDistritos(ByVal canton As String) As Collection
        Return InformacionGralDAO.Instancia.buscarDistrito(canton)
    End Function

    ''' <summary>
    ''' Busca y retorna la region de un distrito especifico.
    ''' </summary>
    ''' <returns>El codigo de la region a la que pertenece el distrito.</returns>
    Public Function buscarRegion(ByVal distrito As String) As String
        Return InformacionGralDAO.Instancia.buscarRegion(distrito)
    End Function

    '''' <summary>
    '''' Busca y retorna la la lista de etnias.
    '''' </summary>
    '''' <returns>una coleccion de objetos.</returns>
    Public Function buscarEtnias() As Collection
        Return InformacionGralDAO.Instancia.buscarEtnias()
    End Function

    '''' <summary>
    '''' Busca y retorna la la lista de estado civil.
    '''' </summary>
    '''' <returns>una coleccion de objetos.</returns>
    Public Function buscarEstadoCivil() As Collection
        Return InformacionGralDAO.Instancia.buscarEstadoCivil()
    End Function

    '''' <summary>
    '''' Busca y retorna la la lista de escolaridades.
    '''' </summary>
    '''' <returns>una coleccion de objetos.</returns>
    Public Function buscarEscolaridad() As Collection
        Return InformacionGralDAO.Instancia.buscarEscolaridad()
    End Function

    '''' <summary>
    '''' Busca y retorna la la lista de escolaridades.
    '''' </summary>
    '''' <returns>una coleccion de objetos.</returns>
    Public Function buscarDiscapacidad() As Collection
        Return InformacionGralDAO.Instancia.buscarDiscapacidad()
    End Function

    '''' <summary>
    '''' Busca y retorna la la lista de escolaridades.
    '''' </summary>
    '''' <returns>una coleccion de objetos.</returns>
    Public Function buscarEstadosCCSS() As Collection
        Return InformacionGralDAO.Instancia.buscarEstadosCCSS()
    End Function

    ' Añade una nueva opción a la lista de discapacidades
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto Discapacidad que contiene los datos.</returns>
    Function agregarDiscapacidad(ByRef nuevaOpcion As String) As Discapacidad
        Dim modelo As New Discapacidad
        modelo.detalle = nuevaOpcion

        Return InformacionGralDAO.Instancia.agregarDiscapacidad(modelo)
    End Function

    ' Añade una nueva opción a la lista de discapacidades
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto Discapacidad que contiene los datos.</returns>
    Function nuevoTipoCertificacion(ByRef nuevaOpcion As String) As Certificaciones
        Dim modelo As New Certificaciones
        modelo.tipoCertificado = nuevaOpcion

        Return InformacionGralDAO.Instancia.nuevoTipoCertificacion(modelo)
    End Function
End Class
