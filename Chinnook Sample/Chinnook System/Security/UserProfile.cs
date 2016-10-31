using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinnook_System.Security
{
    public class UserProfile
    {
        public int UserId { get; set; } // from the AspNetUser Table
        public string UserName { get; set; } // from then AspNetUser Table
        public int? EmployeeId { get; set; } // from the AspNetUser Table
        public int? CustomerID { get; set; } // from the AspNetUser Table
        public string FirstName { get; set; } // from Employee or Customer table
        public string LastName { get; set; } // from Employee or Customer table
        public string EmailAddress { get; set; } // from AspNetUser Table
        public string EmailConfirmed { get; set; } // from AspNetUser Table
        public IEnumerable<string> RoleMembership { get; set; }

    } 
}
