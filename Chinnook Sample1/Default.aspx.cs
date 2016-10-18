using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional NameSpaces
using Chinnook_System.Security;
#endregion
public partial class _Default : Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        // Check if the user is Login
        if(!Request.IsAuthenticated)
        {
            Response.Redirect("~/Account/Login.aspx");
        }
        else
        {
            // Are you allowed to be on this page?
            if(!User.IsInRole(SecurityRoles.WebSiteAdmins))
            {
                Response.Redirect("~/SamplePages/Page2.aspx");
            }
        }
    }
}