''' <summary>
''' Clase que contiene métodos de negocio relacionados con la actividad de un productor.
''' </summary>
''' 
Public Class LinAbastecimientoNegocio

    Private Shared _instancia As LinAbastecimientoNegocio = Nothing
    ''' <summary>
    ''' Obtiene una instancia única de la clase Linea de abastecimiento utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As LinAbastecimientoNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New LinAbastecimientoNegocio()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Inserta una línea de abastecimiento a un productor en la base de datos.
    ''' </summary>
    ''' <param name="codLinea">codigo de la línea de abastecimiento</param>
    ''' <param name="provincia">provincia de donde se desarrollan las actividades.</param>
    ''' <param name="canton">canton de donde se desarrollan las actividades.</param>
    ''' <param name="distrito">Distrito de donde se desarrollan las actividades.</param>
    ''' <param name="direccion">direccion exacta de donde se desarrollan las actividades.</param>
    ''' <param name="Areatotal">Hectareas del terreno.</param>
    ''' <param name="LecheDia">Kg diarios de leche.</param>
    ''' <param name="totalCabezas">Total de cabezas, ganadería de carne.</param>
    ''' <param name="cabezasSemana">cabezas semanales, ganadería de carne.</param>
    ''' <param name="totalUnidades">Total unidades, ganadería de cerdo.</param>
    ''' <param name="unidadesSemana">Unidades semanales, ganadería de cerdo.</param>
    ''' <param name="totalPicos">total de picos, poduccion de pollos.</param>
    ''' <param name="kgdiaP">total de kg de pollos semanales, poduccion de pollos.</param>
    ''' <param name="cartonesDiarios">cartones de huevos diarios, poduccion de huevos.</param>
    ''' <param name="HuevosDia">total de kg de huevos semanales, poduccion de huevos.</param>
    ''' <param name="kgTilapia">total de kg de tilapia semanales, poduccion de pescado.</param>
    ''' <param name="kgOtros">total de kg de otro tipo de pescado semanales, poduccion de pescado.</param>
    ''' <param name="productoHorto">producto que produce el usuario.</param>
    ''' <param name="unidadMedida">unidad de medida del producto.</param>
    ''' <param name="frecuencia">frecuencia de producción del producto.</param>
    ''' <param name="cantidad">cantidad de producción del producto.</param>
    ''' <param name="inscripcion">numero de inscripción del productor </param>
    ''' <returns>Un objeto DatosFormulario que representa el terreno insertado.</returns>
    Public Function insertarLineaAB(ByVal inscripcion As String, ByVal codLinea As String, ByVal provincia As String, ByVal canton As String, ByVal distrito As String, ByVal direccion As String,
                                    ByVal Areatotal As String, ByVal LecheDia As String, ByVal totalCabezas As String,
                                    ByVal cabezasSemana As String, ByVal totalUnidades As String, ByVal unidadesSemana As String,
                                    ByVal totalPicos As String, ByVal kgdiaP As String, ByVal cartonesDiarios As String,
                                    ByVal HuevosDia As String, ByVal kgTilapia As String, ByVal kgOtros As String, ByVal productoHorto As String,
                                    ByVal unidadMedida As String, ByVal cantidad As String, ByVal frecuencia As String, ByVal verificacionCampo As String) As DatosFormulario
        Dim modelo As New DatosFormulario
        modelo.inscripcion = inscripcion
        modelo.codLinea = codLinea
        modelo.provincia = provincia
        modelo.canton = canton
        modelo.distrito = distrito
        modelo.direcExacta = direccion
        modelo.areaTotal = Areatotal
        modelo.LecheDia = LecheDia
        modelo.totalCabezas = totalCabezas
        modelo.cabezasSem = cabezasSemana
        modelo.totalUni = totalUnidades
        modelo.uniSem = unidadesSemana
        modelo.totalPicos = totalPicos
        modelo.kgPollo = kgdiaP
        modelo.cartonesDia = cartonesDiarios
        modelo.HuevosDia = HuevosDia
        modelo.kgTilapia = kgTilapia
        modelo.kgOtros = kgOtros
        modelo.cultivo = productoHorto
        modelo.unidadMedida = unidadMedida
        modelo.frecuenciaProduccion = frecuencia
        modelo.cantidad = cantidad
        modelo.verificacionCampo = verificacionCampo

        Return LinAbastecimientoDAO.Instancia.agregarLineaAb(modelo)
    End Function

    ''' <summary>
    ''' Obtiene una colección de líneas de abastecimiento asociados a un productor.
    ''' </summary>
    ''' <param name="Productor">Código del productor.</param>
    ''' <returns>Una colección de objetos líneas de abastecimiento asociados al productor.</returns>
    Public Function traerLineasAb(ByVal Productor As String) As Collection
        Return LinAbastecimientoDAO.Instancia.traerLineasAb(Productor)
    End Function

    ''' <summary>
    ''' Elimina una línea de abastecimiento de la base de datos.
    ''' </summary>
    ''' <param name="Codigo">Código de la línea de abastecimiento a eliminar.</param>
    ''' <returns>El código de la línea de abastecimiento eliminado.</returns>
    Public Function eliminarLineaAb(ByVal Codigo As String) As String
        Return LinAbastecimientoDAO.Instancia.eliminarLineaAb(Codigo)
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de tipos de producción.
    ''' </summary>
    ''' <returns>Una colección de objetos de tipos de producción.</returns>
    Public Function buscarTipoProduccionColeccion() As Collection
        Return InformacionGralDAO.Instancia.buscarColeccionTipoProduccion()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de categorías de producto.
    ''' </summary>
    ''' <returns>Una colección de objetos de categorías de producto.</returns>
    Public Function buscarCategoriasProducto() As Collection
        Return LinAbastecimientoDAO.Instancia.buscarCategoriasProducto()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de productos.
    ''' </summary>
    ''' <returns>Una colección de objetos de categorías de producto.</returns>
    Public Function buscarProductosHorto() As Collection
        Return LinAbastecimientoDAO.Instancia.buscarProductosHorto()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de unidades de medida.
    ''' </summary>
    ''' <returns>Una colección de objetos de categorías de producto.</returns>
    Public Function cargarUnidadesMedida() As Collection
        Return LinAbastecimientoDAO.Instancia.cargarUnidadesMedida()
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de frecuencias de producción.
    ''' </summary>
    ''' <returns>Una colección de objetos de categorías de producto.</returns>
    Public Function cargarFrecuencia() As Collection
        Return LinAbastecimientoDAO.Instancia.cargarFrecuencia()
    End Function

    ' Añade una nueva opción a la lista de lineas de abastecimiento
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto LineaAbastecimiento que contiene los datos.</returns>
    Function nuevaLineaAb(ByRef nuevaOpcion As String) As LineaAbastecimiento
        Dim modelo As New LineaAbastecimiento
        modelo.desClasificacion = nuevaOpcion

        Return LinAbastecimientoDAO.Instancia.nuevaLineaAb(modelo)
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto ProductosHorto que contiene los datos.</returns>
    Function nuevoProductoHorto(ByRef nuevaOpcion As String) As ProductosHorto
        Dim modelo As New ProductosHorto
        modelo.desClasificacion = nuevaOpcion

        Return LinAbastecimientoDAO.Instancia.nuevoProductoHorto(modelo)
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto ProductosHorto que contiene los datos.</returns>
    Function nuevaUnidadMedida(ByRef nuevaOpcion As String) As UnidadesMedida
        Dim modelo As New UnidadesMedida
        modelo.desClasificacion = nuevaOpcion

        Return LinAbastecimientoDAO.Instancia.nuevaUnidadMedida(modelo)
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto FrecuenciaProduccion que contiene los datos.</returns>
    Function nuevaFrecuencia(ByRef nuevaOpcion As String) As FrecuenciaProduccion
        Dim modelo As New FrecuenciaProduccion
        modelo.desClasificacion = nuevaOpcion

        Return LinAbastecimientoDAO.Instancia.nuevaFrecuencia(modelo)
    End Function

End Class
