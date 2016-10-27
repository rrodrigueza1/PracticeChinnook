using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

#region Additional Namespace
using Chinnook_System.Security;
#endregion
public partial class Admin_Security_WebMasterPage : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void RefreshAll(object sender, EventArgs e)
    {
        DataBind();
    }

    protected void UnregisteredUsersGridView_SelectedIndexChanging(object sender, GridViewSelectEventArgs e)
    {
        //Position the gridview to the selected index that is the (row) that cause the postback
        UnregisteredUsersGridView.SelectedIndex = e.NewSelectedIndex;

        //setup a variable that will be the physical pointer to the selected row
        GridViewRow row = UnregisteredUsersGridView.SelectedRow;

        // you can always check a pointer to see if something has been obtained
        if (row != null)
        {
            // access information contained in a textbox on the gridview row
            // use the method .FindControl("ControlID") as ControlType
            // once you have a pointer to the control, you can access the data content of the control using
            // the contro's access method
            string assignedUsername = "";
            TextBox inputControl = row.FindControl("AssignedUsernane") as TextBox;
            if (inputControl != null)
            {
                assignedUsername = inputControl.Text;
            }
            string assignedEmail = (row.FindControl("AssignedEmail") as TextBox).Text;

            // create the unregistered user instance
            // during creation, I will pass to it the needed data to load the instance attribute

            // accessing boindfields on a gridview row uses .Cells[index].Text
            // index represents the column of the grid
            // columns are index (starting at 0)
            UnregisteredUserProfile unreguser = new UnregisteredUserProfile()
            {
                UserId = UnregisteredUsersGridView.SelectedDataKey.Value.ToString(),
                UserType = (UnRegisteredUserType)Enum.Parse(typeof(UnRegisteredUserType), row.Cells[1].Text),
                FirstName = row.Cells[2].Text,
                LastName = row.Cells[3].Text,
                UserName = assignedUsername,
                EmailAddress = assignedEmail

            };
            // register the user via Chinnook UserManager controller
            UserManager sysmgr = new UserManager();
            sysmgr.RegisterUser(unreguser);

            // we can assume successful creation of a user 
            // refresh the form

            DataBind();
        }
    }

    protected void UserListView_ItemInserting(object sender, ListViewInsertEventArgs e)
    {
        // one needs to walk through the chechboxlist
        // create the RoleMembership Lists<string> of selected roles
        var addtoroles = new List<string>();

        // point to the physical checkboxlist control
        var roles = e.Item.FindControl("RoleMemberships") as CheckBoxList;

        // does the control exists? -- safety check
        if(roles != null)
        {
            //cycle through the checkboxlist 
            // find which roles have been selected(checked) add to the List<string> and assign the List<string>
            // to the inserting instance represented by e
            foreach(ListItem role in roles.Items)
            {
                if(role.Selected)
                {
                    addtoroles.Add(role.Value);
                }
                e.Values["RoleMemberships"] = addtoroles;
            }
        }
    }
}