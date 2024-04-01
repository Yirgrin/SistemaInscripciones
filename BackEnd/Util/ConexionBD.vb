Public Class ConexionBD

    Public Shared Function cadenaConexionInscripciones()
        Dim servidor As String = "192.168.36.83\DESARROLLO, 49403"
        Dim BD As String = "INSCRIPCIONES"
        Dim seguridad As String = "Yes"

        Return String.Format("Server={0};Database={1};uid=user_web;pwd=userWeb2024$#", servidor, BD, seguridad)

        'viejita
        'Return String.Format("Server={0};Database={1};uid=user_web;pwd=At$iCnp9028*%", servidor, BD, seguridad)

    End Function

    Public Shared Function cadenaConexionSIFCNP()

        'Dim servidor As String = "CNP57211"
        'Dim servidor As String = "192.168.36.67\PRODUCCION"
        Dim servidor As String = "192.168.36.83\DESARROLLO"
        Dim BD As String = "SIFCNP"
        'Dim BD As String = "SIF_PRUEBAS"
        'Dim BD As String = "SID_PRD"

        Dim seguridad As String = "Yes"


        'Return String.Format("Server={0};Database={1};Integrated Security={2}", servidor, BD, seguridad)
        Return String.Format("Server={0};Database={1};uid=user_web;pwd=userWeb2024$#", servidor, BD, seguridad)
        'Return String.Format("Server={0};Database={1};uid=test;pwd=q-KnMFfH8XtqzIBTest", servidor, BD, seguridad)

    End Function

    'Public Shared Function cadenaConexion()

    '    'Dim servidor As String = "CNP57211"
    '    'Dim servidor As String = "192.168.36.67\PRODUCCION"
    '    Dim servidor As String = "PRODUCCION.cnp.go.cr, 49349"
    '    Dim BD As String = "SIFCNP"
    '    'Dim BD As String = "SIF_PRUEBAS"
    '    'Dim BD As String = "SID_PRD"

    '    Dim seguridad As String = "Yes"


    '    'Return String.Format("Server={0};Database={1};Integrated Security={2}", servidor, BD, seguridad)
    '    Return String.Format("Server={0};Database={1};uid=user_web;pwd=q-KnMFfH8XtqzIB", servidor, BD, seguridad)
    '    'Return String.Format("Server={0};Database={1};uid=test;pwd=q-KnMFfH8XtqzIBTest", servidor, BD, seguridad)

    'End Function

    Public Shared Function cadenaConexionHistoricos()
        'Dim servidor As String = "192.168.36.67\PRODUCCION"
        Dim servidor As String = "PRODUCCION, 49349"
        'Dim servidor As String = "192.168.36.67\DESARROLLO"
        'Dim servidor As String = "CNP56017"
        Dim BD As String = "CLAUSULA"
        Dim seguridad As String = "Yes"

        Return String.Format("Server={0};Database={1};uid=user_claudes;pwd=G>$U-0+M", servidor, BD, seguridad)
        'Return String.Format("Server={0};Database={1};uid=user_claudes;pwd=123", servidor, BD, seguridad)

    End Function

    Public Shared Function Bdatos()
        Dim BD As String = "CLAUDES"
        Return BD
    End Function

    Public Shared Function BdatosHist()
        Dim BDHist As String = "CLAUSULA"
        Return BDHist
    End Function
    Public Shared Function servidor()

        'Dim instancia As String = "192.168.36.67\PRODUCCION"
        Dim instancia As String = "PRODUCCION, 49349"

        Return instancia
    End Function
    Public Shared Function user()

        Dim userdb As String = "user_claudes"
        Return userdb
    End Function
    Public Shared Function pass()

        Dim clave As String = "G>$U-0+M"
        Return clave
    End Function
End Class
