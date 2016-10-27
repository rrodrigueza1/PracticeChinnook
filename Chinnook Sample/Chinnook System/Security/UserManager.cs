using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
// For IdentityUser
using Microsoft.AspNet.Identity.EntityFramework; //Getting the UserStore
using Microsoft.AspNet.Identity; // Getting User Manager
using System.ComponentModel; // For ODS
using System.ComponentModel.DataAnnotations;
using Chinnook_System.DAL;                          // For Context Class
using Chinnook_System.Data.Entities;                // Entity Classes
#endregion

namespace Chinnook_System.Security
{
    [DataObject]
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
        }// eo AddWebmaster

        // create a CRUD methods for adding a user to the secujrity User Table
        // read of data to display on gridView
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UnregisteredUserProfile> ListAllUnregisteredUsers()
        {

            using (var context = new Chinookcontext())
            {
                // The data needs to be in MEMORY FOR EXECUTION BY THE NEXT QUERY
                // to accomplish this use .ToList() which will force the query to execute

                //List() set containing the list of employeeid
                var registeredEmployees = (from emp in Users
                                           where emp.EmployeeID.HasValue
                                           select emp.EmployeeID).ToList();

                // compare the IEnumerable set to the user data table employees
                var unregisteredEmployees = (from emp in context.Employees
                                             where !registeredEmployees.Any(eid => emp.EmployeeId == eid)
                                             select new UnregisteredUserProfile()
                                             {
                                                 UserId = emp.EmployeeId.ToString(),
                                                 FirstName = emp.FirstName,
                                                 LastName = emp.LastName,
                                                 UserType = UnRegisteredUserType.Employee
                                             }).ToList();
                //List() set containing the list of customerid
                var registeredCustomer = (from emp in Users
                                          where emp.CustomerID.HasValue
                                          select emp.CustomerID).ToList();
                // compare the List() set to the user data table customer
                var unregisteredCustomer = (from cus in context.Customers
                                            where !registeredCustomer.Any(cid => cus.CustomerId == cid)
                                            select new UnregisteredUserProfile()
                                            {
                                                UserId = cus.CustomerId.ToString(),
                                                FirstName = cus.FirstName,
                                                LastName = cus.LastName,
                                                UserType = UnRegisteredUserType.Customer
                                            }).ToList();
                // combine the two physically identical layout datasets 
                return unregisteredEmployees.Union(unregisteredCustomer).ToList();
            }

        }// eo ListAllUnregisteredUsers


        // Register a user to the User Table (GridView)
        public void RegisterUser(UnregisteredUserProfile user)
        {
            // The basic information needed for the security user record
            // Password, emailaddress and username
            // you could randomly generate a password, we will use the default password
            // The instance of the required user is based on our application user
            var newUserAccount = new ApplicationUser()
            {
                UserName = user.UserName,
                Email = user.EmailAddress
            };
            // set the customer of employeeid
            switch (user.UserType)
            {
                case UnRegisteredUserType.Customer:
                    {
                        newUserAccount.Id = user.UserId;
                        break;
                    }
                case UnRegisteredUserType.Employee:
                    {
                        newUserAccount.Id = user.UserId;
                        break;
                    }
            }
            // Create the actual ASPNet User record
            this.Create(newUserAccount, STR_DEFAULT_PASSWORD);

            // Assign user to an appropriate role
            switch (user.UserType)
            {
                case UnRegisteredUserType.Customer:
                    {
                        this.AddToRole(newUserAccount.Id, SecurityRoles.RegisterUser);
                        break;
                    }
                case UnRegisteredUserType.Employee:
                    {
                        this.AddToRole(newUserAccount.Id, SecurityRoles.Staff);
                        newUserAccount.Id = user.UserId.ToString();
                        break;
                    }
            }
        }// eo RegisterUser

        // List all current users
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<UserProfile> ListAllUsers()
        {
            // We will be using the role manager to get roles
            var rm = new RoleManager();

            // Get the current users off the user security table
            var results = from person in Users.ToList()
                          select new UserProfile
                          {
                              UserId = int.Parse(person.Id),
                              UserName = person.UserName,
                              EmailAddress = person.Email,
                              EmailConfirmed = person.EmailConfirmed,
                              CustomerID = person.CustomerID,
                              EmployeeId = person.EmployeeID,
                              RoleMembership = person.Roles.Select(r => rm.FindById(r.RoleId).Name)
                          };
            // using our own data table, gather the user FirstName and LastName
            using (var context = new Chinookcontext())
            {
                Employee etemp;
                Customer ctemp;
                foreach (var person in results)
                {
                    if (person.EmployeeId.HasValue)
                    {
                        etemp = context.Employees.Find(person.EmployeeId);
                        person.FirstName = etemp.FirstName;
                        person.LastName = etemp.LastName;
                    }
                    else if (person.CustomerID.HasValue)
                    {
                        ctemp = context.Customers.Find(person.CustomerID);
                        person.FirstName = ctemp.FirstName;
                        person.LastName = ctemp.LastName;
                    }
                    else
                    {
                        person.FirstName = "Unknown";
                        person.LastName = "";
                    }
                }
            }
            return results.ToList();

        }

        //Add a user to the User Table
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddUser(UserProfile userinfo)
        {
            //create an instance representing the new user
            var usserAccount = new ApplicationUser()
            {
                UserName = userinfo.UserName,
                Email = userinfo.EmailAddress
            };

            // Create the new user on the physical users table
            this.Create(usserAccount, STR_DEFAULT_PASSWORD);

            // Create the user roles which were choosen at insert time
            foreach(var rolename in userinfo.RoleMembership)
            {
                this.AddToRole(usserAccount.Id, rolename);
            }

        }
        // Delete a user from the user TAble (ListView)
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void RemoveUser(UserProfile userinfo)
        {
            //Business rule
            // The WebMaster cannot be deleted

            // Realize that the only information that you have at this point in time is the DataKeyName value
            // which is the user ID. on the user security table the field is ID

            // obtain the username from the security user table using the user id

            string username = this.Users.Where(u => u.Id == userinfo.UserId.ToString()).Select(y => y.UserName)
                              .SingleOrDefault().ToString();

            // remove the user
            if(username.Equals(STR_WEBMASTER_USERNAME))
            {
                throw new Exception("The webmaster account cannot be removed.");
            }
            this.Delete(this.FindById(userinfo.UserId.ToString()));

        }
    }//eoc
}//eon 
