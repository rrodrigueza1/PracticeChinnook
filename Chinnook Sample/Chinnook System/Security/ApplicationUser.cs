using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
// For IdentityUser
using Microsoft.AspNet.Identity.EntityFramework;
#endregion

namespace Chinnook_System.Security
{   
    public class ApplicationUser : IdentityUser
    {
        public int? EmployeeID { get; set; }
        public int? CustomerID { get; set; }
    }
}
