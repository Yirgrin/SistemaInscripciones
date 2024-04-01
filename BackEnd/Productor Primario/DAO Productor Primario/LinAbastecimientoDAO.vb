Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con la actividad de un productor.
''' </summary>
Public Class LinAbastecimientoDAO

    Private Shared _instancia As LinAbastecimientoDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase ActividadNegocio utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As LinAbastecimientoDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New LinAbastecimientoDAO()
            End If
            Return _instancia
        End Get
    End Property


    ''' Inserta una actividad de un productor en la base de datos.
    ''' <param  name="modelo"> El objeto DatosFormulario que contiene los datos de la actividad.</param>
    ''' <returns> El objeto modelo insertado.</returns>
    Public Function agregarLineaAb(ByVal modelo As DatosFormulario) As DatosFormulario
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_DATOS_LINEA_AB (INSCRIPCION, COD_LINEA,PROVINCIA,CANTON,DISTRITO,DIREC_EXACTA,AREA_TOTAL,KG_LECHE,
                        TOTAL_CABEZAS,CABEZAS_SEM,TOTAL_UNI,UNIDADES_SEM,TOTAL_PICOS,KG_POLLO,CARTONES_DIARIOS,KG_HUEVOS,
                        KG_TILAPIA,KG_OTROS, PRODUCTO_HORTO, UNIDAD_MEDIDA, CANTIDAD_PRODUCTO, FRECUENCIA_PRODUCCION, VERIFICACION_CAMPO)"
            sql = sql + "Values (@VALOR1, @VALOR2, @VALOR3, @VALOR4, @VALOR5, @VALOR6, @VALOR7, @VALOR8, @VALOR9, @VALOR10, @VALOR11, 
                        @VALOR12, @VALOR13, @VALOR14, @VALOR15, @VALOR16, @VALOR17, @VALOR18, @VALOR19, @VALOR20, @VALOR21, @VALOR22, @VALOR23)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.inscripcion)
            cmd.Parameters.AddWithValue("@VALOR2", modelo.codLinea)
            cmd.Parameters.AddWithValue("@VALOR3", modelo.provincia)
            cmd.Parameters.AddWithValue("@VALOR4", modelo.canton)
            cmd.Parameters.AddWithValue("@VALOR5", modelo.distrito)
            cmd.Parameters.AddWithValue("@VALOR6", modelo.direcExacta)
            cmd.Parameters.AddWithValue("@VALOR7", modelo.areaTotal)
            cmd.Parameters.AddWithValue("@VALOR8", modelo.LecheDia)
            cmd.Parameters.AddWithValue("@VALOR9", modelo.totalCabezas)
            cmd.Parameters.AddWithValue("@VALOR10", modelo.cabezasSem)
            cmd.Parameters.AddWithValue("@VALOR11", modelo.totalUni)
            cmd.Parameters.AddWithValue("@VALOR12", modelo.uniSem)
            cmd.Parameters.AddWithValue("@VALOR13", modelo.totalPicos)
            cmd.Parameters.AddWithValue("@VALOR14", modelo.kgPollo)
            cmd.Parameters.AddWithValue("@VALOR15", modelo.cartonesDia)
            cmd.Parameters.AddWithValue("@VALOR16", modelo.HuevosDia)
            cmd.Parameters.AddWithValue("@VALOR17", modelo.kgTilapia)
            cmd.Parameters.AddWithValue("@VALOR18", modelo.kgOtros)
            cmd.Parameters.AddWithValue("@VALOR19", modelo.cultivo)
            cmd.Parameters.AddWithValue("@VALOR20", modelo.unidadMedida)
            cmd.Parameters.AddWithValue("@VALOR21", modelo.cantidad)
            cmd.Parameters.AddWithValue("@VALOR22", modelo.frecuenciaProduccion)
            cmd.Parameters.AddWithValue("@VALOR23", modelo.verificacionCampo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function



    ''' <summary>
    ''' Obtiene una colección de líneas de abastecimiento asociados a un productor.
    ''' </summary>
    ''' <param name="Inscripcion">El código del productor.</param>
    ''' <returns>Una colección de objetos líneas de abastecimiento asociados al productor.</returns>
    Public Function traerLineasAb(ByVal Inscripcion As String) As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From [VW_GC_DATOS_LINEA_AB] "
            sql = sql + " Where INSCRIPCION=@VALOR1"
            sql = sql + " Order by [CODIGO]"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", Inscripcion)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New DatosFormulario
                modelo.codigo = dr(0).ToString
                modelo.codLinea = dr(1).ToString.ToUpper()
                modelo.provincia = dr(2).ToString
                modelo.canton = dr(3).ToString
                modelo.distrito = dr(4).ToString
                modelo.cultivo = dr(5).ToString.ToUpper()
                modelo.frecuenciaProduccion = dr(6).ToString
                modelo.unidadMedida = dr(7).ToString
                modelo.areaTotal = dr(8).ToString
                modelo.LecheDia = dr(9).ToString
                modelo.totalCabezas = dr(10).ToString
                modelo.cabezasSem = dr(11).ToString
                modelo.totalUni = dr(12).ToString
                modelo.uniSem = dr(13).ToString
                modelo.totalPicos = dr(14).ToString
                modelo.kgPollo = dr(15).ToString
                modelo.cartonesDia = dr(16).ToString
                modelo.HuevosDia = dr(17).ToString
                modelo.kgTilapia = dr(18).ToString
                modelo.kgOtros = dr(19).ToString
                modelo.region = dr(20).ToString
                modelo.cantidad = dr(21).ToString
                modelo.direcExacta = dr(23).ToString
                modelo.verificacionCampo = dr(24).ToString

                'Concatenar la informacón de la dirección del terreno donde desarrolla las actividades
                modelo.direccionGr = " <b>REGIÓN: </b> " & modelo.region & " <br> <b>PROVINCIA: </b>  " & modelo.provincia & " <br> <b>CANTÓN: </b> " & modelo.canton & " <br> <b>DISTRITO: </b> " & modelo.distrito & " <br> <b>DIRECCIÓN: </b> " & modelo.direcExacta.ToUpper()

                'Validar si los datos no son iguales a cero (sin información) antes de concatenar y mostrarlos en la columna de descripción
                Dim descripcionLinea As String = ""

                If modelo.LecheDia IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.LecheDia) AndAlso modelo.LecheDia <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>LITROS DIARIOS LECHE:</b> " & modelo.LecheDia.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>LITROS DIARIOS LECHE:</b> " & modelo.LecheDia.ToUpper()
                    End If
                End If
                If modelo.totalCabezas IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.totalCabezas) AndAlso modelo.totalCabezas <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>TOTAL DE CABEZAS:</b> " & modelo.totalCabezas.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>TOTAL DE CABEZAS:</b> " & modelo.totalCabezas.ToUpper()
                    End If
                End If
                If modelo.cabezasSem IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.cabezasSem) AndAlso modelo.cabezasSem <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>CABEZAS SEMANALES:</b> " & modelo.cabezasSem.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>CABEZAS SEMANALES:</b> " & modelo.cabezasSem.ToUpper()
                    End If
                End If
                If modelo.totalUni IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.totalUni) AndAlso modelo.totalUni <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>UNIDADES DE CERDO:</b> " & modelo.totalUni.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>UNIDADES DE CERDO:</b> " & modelo.totalUni.ToUpper()
                    End If
                End If
                If modelo.uniSem IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.uniSem) AndAlso modelo.uniSem <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>UNIDADES SEM DE CERDO:</b> " & modelo.uniSem.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>UNIDADES SEM DE CERDO:</b>" & modelo.uniSem.ToUpper()
                    End If
                End If
                If modelo.totalPicos IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.totalPicos) AndAlso modelo.totalPicos <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>TOTAL DE PICOS:</b> " & modelo.totalPicos.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>TOTAL DE PICOS:</b> " & modelo.totalPicos.ToUpper()
                    End If
                End If
                If modelo.kgPollo IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.kgPollo) AndAlso modelo.kgPollo <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>KG DE POLLO SEMANAL:</b> " & modelo.kgPollo.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>KG DE POLLO SEMANAL:</b> " & modelo.kgPollo.ToUpper()
                    End If
                End If
                If modelo.cartonesDia IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.cartonesDia) AndAlso modelo.cartonesDia <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>CARTONES DIARIOS:</b> " & modelo.cartonesDia.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>CARTONES DIARIOS:</b> " & modelo.cartonesDia.ToUpper()
                    End If
                End If
                If modelo.HuevosDia IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.HuevosDia) AndAlso modelo.HuevosDia <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>KG HUEVOS DIARIOS:</b> " & modelo.HuevosDia.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>KG HUEVOS DIARIOS:</b> " & modelo.HuevosDia.ToUpper()
                    End If
                End If
                If modelo.kgTilapia IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.kgTilapia) AndAlso modelo.kgTilapia <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>KG SEM DE TILAPIA:</b> " & modelo.kgTilapia.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>KG SEM DE TILAPIA:</b> " & modelo.kgTilapia.ToUpper()
                    End If
                End If
                If modelo.kgOtros IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.kgOtros) AndAlso modelo.kgOtros <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>KG SEM DE OTROS:</b> " & modelo.kgOtros.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>KG SEM DE OTROS:</b> " & modelo.kgOtros.ToUpper()
                    End If
                End If
                If modelo.cultivo IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.cultivo) AndAlso modelo.cultivo <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>CULTIVO:</b> " & modelo.cultivo.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>CULTIVO:</b> " & modelo.cultivo.ToUpper()
                    End If
                End If
                If modelo.unidadMedida IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.unidadMedida) AndAlso modelo.unidadMedida <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>UNIDAD MEDIDA:</b> " & modelo.unidadMedida.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>UNIDAD MEDIDA:</b> " & modelo.unidadMedida.ToUpper()
                    End If
                End If
                If modelo.cantidad IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.cantidad) AndAlso modelo.cantidad <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>CANTIDAD:</b> " & modelo.cantidad.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>CANTIDAD:</b> " & modelo.cantidad.ToUpper()
                    End If
                End If
                If modelo.frecuenciaProduccion IsNot Nothing AndAlso Not String.IsNullOrEmpty(modelo.frecuenciaProduccion) AndAlso modelo.frecuenciaProduccion <> "0" Then
                    If descripcionLinea <> "" Then
                        'Si ya hay información concatenada desde antes
                        descripcionLinea &= "<br> <b>FRECUENCIA:</b> " & modelo.frecuenciaProduccion.ToUpper()
                    Else
                        'si no, empieza como el primer dato en la línea que se va a concatenar
                        descripcionLinea = "<b>FRECUENCIA:</b> " & modelo.frecuenciaProduccion.ToUpper()
                    End If
                End If


                'asigno a la propiedad del modelo toda la información concatenada que recolectó la variable
                modelo.descripcionLinea = descripcionLinea
                modelo.areaTotal = modelo.areaTotal
                lista.Add(modelo)

            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function


    ''' <summary>
    ''' Elimina una línea de abastecimiento de la base de datos.
    ''' </summary>
    ''' <param name="Codigo">Código de la línea de abastecimiento a eliminar.</param>
    ''' <returns>El código de la línea de abastecimiento eliminado.</returns>
    Public Function eliminarLineaAb(ByVal Codigo As String) As String
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Delete from GC_DATOS_LINEA_AB Where CODIGO=@VALOR1"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", Codigo)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return Codigo
    End Function


    ''' <summary>
    ''' Busca y retorna una colección de categorías desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos LineaAbastecimiento.</returns>
    Public Function buscarCategoriasProducto() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_LINEA_ABASTECIMIENTO Order by DESCRIPCION"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New LineaAbastecimiento
                modelo.codClasificacion = dr(0).ToString
                modelo.desClasificacion = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de productos desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos LineaAbastecimiento.</returns>
    Public Function buscarProductosHorto() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_PRODUCTOS_HORTOFRUTICULAS"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New ProductosHorto
                modelo.codClasificacion = dr(0).ToString
                modelo.desClasificacion = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de unidades de medida desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos LineaAbastecimiento.</returns>
    Public Function cargarUnidadesMedida() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_UNIDAD_MEDIDA"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New UnidadesMedida
                modelo.codClasificacion = dr(0).ToString
                modelo.desClasificacion = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ''' <summary>
    ''' Busca y retorna una colección de unidades de medida desde la base de datos.
    ''' </summary>
    ''' <returns>Una colección de objetos LineaAbastecimiento.</returns>
    Public Function cargarFrecuencia() As Collection
        Dim lista As New Collection
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Select * From GC_FRECUENCIA"
            Dim cmd As New SqlCommand(sql, cn)
            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()
            While dr.Read
                Dim modelo As New FrecuenciaProduccion
                modelo.codClasificacion = dr(0).ToString
                modelo.desClasificacion = dr(1).ToString
                lista.Add(modelo)
            End While
            dr.Close()
            cn.Close()
        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return lista
    End Function

    ' Añade una nueva opción a la lista de lineas de abastecimiento
    ''' <param name="modelo">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto LineaAbastecimiento que contiene los datos.</returns>
    Public Function nuevaLineaAb(ByVal modelo As LineaAbastecimiento) As LineaAbastecimiento
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_LINEA_ABASTECIMIENTO (DESCRIPCION)"
            sql = sql + " Values (@VALOR1)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", modelo.desClasificacion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return modelo
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto ProductosHorto que contiene los datos.</returns>
    Public Function nuevoProductoHorto(ByVal nuevaOpcion As ProductosHorto) As ProductosHorto
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_PRODUCTOS_HORTOFRUTICULAS (PRODUCTO)"
            sql = sql + " Values (@VALOR1)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nuevaOpcion.desClasificacion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return nuevaOpcion
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto ProductosHorto que contiene los datos.</returns>
    Public Function nuevaUnidadMedida(ByVal nuevaOpcion As UnidadesMedida) As UnidadesMedida
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_UNIDAD_MEDIDA (UNIDAD)"
            sql = sql + " Values (@VALOR1)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nuevaOpcion.desClasificacion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return nuevaOpcion
    End Function

    ' Añade una nueva opción a la lista de productosHortofruticulas
    ''' <param name="nuevaOpcion">nueva opción para agregar a la base de datos.</param>
    ''' <returns>Un objeto ProductosHorto que contiene los datos.</returns>
    Public Function nuevaFrecuencia(ByVal nuevaOpcion As FrecuenciaProduccion) As FrecuenciaProduccion
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionInscripciones)
            cn.Open()
            Dim sql = "Insert Into GC_FRECUENCIA (DETALLE)"
            sql = sql + " Values (@VALOR1)"
            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nuevaOpcion.desClasificacion)
            cmd.ExecuteNonQuery()
            cn.Close()
        Catch ex As Exception
            Throw New DAOExcepcion(ex.ToString)
        End Try
        Return nuevaOpcion
    End Function

End Class
