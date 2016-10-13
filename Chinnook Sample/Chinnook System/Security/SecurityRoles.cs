using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chinnook_System.Security
{
    internal static class SecurityRoles
    {
        public const string WebSiteAdmins = "Website Admins";
        public const string RegisterUser = "Registered Users";
        public const string Staff = "Staff";
        public const string Auditor = "Government Auditor";

        // read-only
        public static List<string> StartupSecurityRoles
        {
            get
            {
                List<string> roleList = new List<string>();
                roleList.Add(WebSiteAdmins);
                roleList.Add(RegisterUser);
                roleList.Add(Staff);
                roleList.Add(Auditor);
                return roleList;
            }
        }
    }
}
