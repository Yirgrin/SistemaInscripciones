Imports System.Data.SqlClient

''' <summary>
''' Clase que proporciona métodos para interactuar con la base de datos relacionados con parámetros.
''' </summary>
Public Class ParametroDAO
    Private Shared _instancia As ParametroDAO = Nothing

    ''' <summary>
    ''' Obtiene una instancia única de la clase ParametroDAO utilizando el patrón Singleton.
    ''' </summary>
    Public Shared ReadOnly Property Instancia As ParametroDAO
        Get
            If _instancia Is Nothing Then
                _instancia = New ParametroDAO()
            End If
            Return _instancia
        End Get
    End Property

    ''' <summary>
    ''' Trae el valor de un parámetro de la base de datos dado su nombre.
    ''' </summary>
    ''' <param name="nombre">El nombre del parámetro cuyo valor se busca.</param>
    ''' <returns>El valor del parámetro.</returns>
    Public Function traerParametros(ByVal nombre As String) As String
        Try
            Dim cn As New SqlConnection(ConexionBD.cadenaConexionSIFCNP)
            cn.Open()

            Dim sql = "Select VALOR From GP_PARAMETRO Where NOMBRE=@VALOR1"

            Dim cmd As New SqlCommand(sql, cn)
            cmd.Parameters.AddWithValue("@VALOR1", nombre)

            Dim dr As SqlDataReader
            dr = cmd.ExecuteReader()

            While dr.Read
                nombre = dr(0).ToString
            End While

            dr.Close()
            cn.Close()

        Catch ex As SqlException
            Throw New DAOExcepcion(ex.ToString)
        End Try

        Return nombre

    End Function
End Class
