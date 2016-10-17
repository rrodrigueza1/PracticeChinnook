using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity; // Getting Role Manager
using Microsoft.AspNet.Identity.EntityFramework; // Getting IdentityRole, RoleStore
#endregion

namespace Chinnook_System.Security
{
    public class RoleManager : RoleManager<IdentityRole>
    {
        public  RoleManager() : base (new RoleStore<IdentityRole>(new ApplicationDbContext()))
        {

        }
        //this method will be executed when the application starts up
        //under IIS
        public void AddStartupRoles()
        {
            foreach (string roleName in SecurityRoles.StartupSecurityRoles)
            {
                //check if the roles already exists in the Security Tables
                //located in the database
                if (!Roles.Any(r => r.Name.Equals(roleName)))
                {
                    //role is not currently on the database
                    this.Create(new IdentityRole(roleName));
                }
            }
        }
    }
}
