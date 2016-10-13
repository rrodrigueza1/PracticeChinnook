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
    }
}
