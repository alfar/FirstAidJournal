' Note: For instructions on enabling IIS6 or IIS7 classic mode, 
' visit http://go.microsoft.com/?LinkId=9394802

Public Class MvcApplication
    Inherits System.Web.HttpApplication

    Shared Sub RegisterGlobalFilters(ByVal filters As GlobalFilterCollection)
        filters.Add(New HandleErrorAttribute())
    End Sub

    Shared Sub RegisterRoutes(ByVal routes As RouteCollection)
        routes.IgnoreRoute("{resource}.axd/{*pathInfo}")

        ' MapRoute takes the following parameters, in order:
        ' (1) Route name
        ' (2) URL with parameters
        ' (3) Parameter defaults
        routes.MapRoute( _
            "Default", _
            "{controller}/{action}/{id}", _
            New With {.controller = "Team", .action = "Index", .id = UrlParameter.Optional} _
        )

    End Sub

    Sub Application_Start()
        AreaRegistration.RegisterAllAreas()

        RegisterGlobalFilters(GlobalFilters.Filters)
        RegisterRoutes(RouteTable.Routes)

        If Not Roles.RoleExists("Administrators") Then
            Roles.CreateRole("Administrators")
            Roles.AddUserToRole("arne", "Administrators")
            Roles.AddUserToRole("Thomas", "Administrators")
        End If
    End Sub

    Private Sub MvcApplication_BeginRequest(sender As Object, e As System.EventArgs) Handles Me.BeginRequest
        If Request.UserLanguages IsNot Nothing Then
            Threading.Thread.CurrentThread.CurrentUICulture = New System.Globalization.CultureInfo(Request.UserLanguages.First())
        End If
    End Sub
End Class
