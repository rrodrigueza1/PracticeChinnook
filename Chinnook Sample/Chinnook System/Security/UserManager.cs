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
        // Setting up the default webMaster
        #region Constants
        private const string STR_DEFAULT_PASSWORD = "PA$$word1";
        private const string STR_USERNAME_FORMAT = "{0}.{1}";
        private const string STR_EMAIL_FORMAT = "{0}@Chinook.ca";
        private const string STR_WEBMASTER_USERNAME = "Webmaster";
        #endregion
        public void AddWebmaster()
        {
            if (!Users.Any(u => u.UserName.Equals(STR_WEBMASTER_USERNAME)))
            {
                var WebmasterAccount = new ApplicationUser()
                {
                    UserName = STR_WEBMASTER_USERNAME,
                    Email = string.Format(STR_EMAIL_FORMAT, STR_WEBMASTER_USERNAME)
                };
                // this.Create command is from the inherited UserManager class
                // this command creates a record on the security User Table (ASPNetUsers)
                this.Create(WebmasterAccount, STR_DEFAULT_PASSWORD);
                // this AddToRole command is from the inherited UserManager class
                // this command creates a record on the security UserRole table (ASPNetUserRoles)
                this.AddToRole(WebmasterAccount.Id, SecurityRoles.WebSiteAdmins);
            }
        }
        
    }//eoc
}//eon 
