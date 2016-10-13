using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
// For IdentityUser
using Microsoft.AspNet.Identity.EntityFramework; //Getting the UserStore
using Microsoft.AspNet.Identity; // Getting User Manager
#endregion

namespace Chinnook_System.Security
{
    public class UserManager : UserManager<ApplicationUser>
    {
        public UserManager()
            : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
        {
        }
    }
}
