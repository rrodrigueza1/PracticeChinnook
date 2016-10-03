using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region
using System.ComponentModel;
using Chinnook_System.Data.Entities;
using Chinnook_System.Data.POCO;
using Chinnook_System.DAL;
#endregion
namespace Chinnook_System.BLL
{
    [DataObject]
    public class CustomerController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<CheckCustomer> CustomerRepresentative(int employeeid)
        {          
            using (var context = new Chinookcontext())
            {
                var result = from x in context.Customers
                             where x.Employee.EmployeeId == employeeid
                             select new CheckCustomer
                             {
                                 Name = x.LastName + ", " + x.FirstName,
                                 City = x.City,
                                 State = x.State,
                                 Phone = x.Phone,
                                 Email = x.Email
                             };
                return result.ToList();
            }
        }
    }
}
