using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinnook_System.Security
{
    public enum UnRegisteredUserType { Undefined, Employee, Customer }
    public class UnregisteredUserProfile
    {
        public string UserId { get; set; } // generated
        public string UserName { get; set; } // collected
        public string FirstName { get; set; } // comes from the user table
        public string LastName { get; set; } // comes from the user table
        public string EmailAddress { get; set; } // collected
        public UnRegisteredUserType UserType { get; set; }
    }
}
