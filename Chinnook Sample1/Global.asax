<%@ Application Language="C#" %>
<%@ Import Namespace="Chinnook_Sample" %>
<%@ Import Namespace="System.Web.Optimization" %>
<%@ Import Namespace="System.Web.Routing" %>
<%@ Import Namespace ="Chinnook_System.Security" %>
<script runat="server">

    void Application_Start(object sender, EventArgs e)
    {
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        BundleConfig.RegisterBundles(BundleTable.Bundles);

        // Load the start-up roles for Chinook
        var roleManager = new RoleManager();
        roleManager.AddStartupRoles();

        // Load the webMaster for Chinook
        var userManager = new UserManager();
        userManager.AddWebmaster();

    }

</script>
