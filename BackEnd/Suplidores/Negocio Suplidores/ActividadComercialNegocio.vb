' clase que contiene métodos para comunicarse con la BD sobre la actividad comercial de la empresa.

Public Class ActividadComercialNegocio

    Private Shared _instancia As ActividadComercialNegocio = Nothing
    ' Instancia única de la clase ActividadComercialNegocio utilizando el patrón Singleton.
    Public Shared ReadOnly Property Instancia As ActividadComercialNegocio
        Get
            If _instancia Is Nothing Then
                _instancia = New ActividadComercialNegocio()
            End If
            Return _instancia
        End Get
    End Property

    Public Function InsertarActividadComercial(ByVal Session As String, ByVal categoria As String,
                                               ByVal clasificacion As String) As ActividadComercial

        Dim modelo As New ActividadComercial

        modelo.inscripcion = Session
        modelo.categoria = categoria
        modelo.codigoProduccion = clasificacion

        Return ActividadComercialDAO.Instancia.InsertarActividadComercial(modelo)
    End Function


    ' Obtiene una colección de líneas de abastecimiento asociados a un productor.
    ''' <param name="Inscripcion">Código del suplidor.</param>
    ''' <returns>Una colección de objetos líneas de abastecimiento asociados al suplidor.</returns>
    Public Function preCargarActividades(ByVal Inscripcion As String) As Collection
        Return ActividadComercialDAO.Instancia.preCargarActividades(Inscripcion)
    End Function

    ' Elimina una actividad comercial de la base de datos.
    ''' <param name="Codigo">Código de la actividad comercial a eliminar.</param>
    ''' <returns>El código de la actividad comercial eliminado.</returns>
    Public Function eliminarActividadComercial(ByVal Codigo As String) As String
        Return ActividadComercialDAO.Instancia.eliminarActividadComercial(Codigo)
    End Function


End Class
