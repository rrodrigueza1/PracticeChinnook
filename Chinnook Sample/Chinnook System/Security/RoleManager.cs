using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using Microsoft.AspNet.Identity; // Getting Role Manager
using Microsoft.AspNet.Identity.EntityFramework; // Getting IdentityRole, RoleStore
using System.ComponentModel; // ODS
#endregion

namespace Chinnook_System.Security
{
    [DataObject]
    public class RoleManager : RoleManager<IdentityRole>
    {
        public RoleManager() : base(new RoleStore<IdentityRole>(new ApplicationDbContext()))
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
        }//eom
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<RoleProfile> ListAllRoles()
        {
            var um = new UserManager();
            // the data frim Roles need to be in memory for use by the query
            // use .ToList()
            var results = from role in Roles.ToList()
                          select new RoleProfile
                          {
                              RoleID = role.Id,         // from Security Tables
                              RoleName = role.Name,     // from Security Tables
                              Username = role.Users.Select(r => um.FindById(r.UserId).UserName)     // from Security Tables
                          };
            return results.ToList();

        }//eo ListAllRoles
        [DataObjectMethod(DataObjectMethodType.Insert, true)]
        public void AddRole(RoleProfile role)
        {
            // any business rules to consider
            // the role shoud not exists in the roles tables
            if(!this.RoleExists(role.RoleName))
            {
                this.Create(new IdentityRole(role.RoleName));
            }
        }
        [DataObjectMethod(DataObjectMethodType.Delete, true)]
        public void DeleteRole(RoleProfile role)
        {
            // any business rules to consider
            // the role shoud exists in the roles tables
            this.Delete(this.FindById(role.RoleID));
        }// eo DeleteRole

        // this method will produce a list of all role name
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<string> ListAllRoleNames()
        {
            return this.Roles.Select(r => r.Name).ToList();
        }// eo ListAllRoleNames

    }//eoc
}//eon
