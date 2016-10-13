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
        // This method will be executed when the application starts up under IIS
        public void AddStartupRoles()
        {
            // check if the roles already exists in the Secrity Tables
            // located in the database
            foreach(string roleName in SecurityRoles.StartupSecurityRoles)
            {
                // role os not currently in the database
                if (!Roles.Any(Random => roleName.Equals(roleName)))
                {
                    this.Create(new IdentityRole(roleName));
                }
            }
        }
    }
}
