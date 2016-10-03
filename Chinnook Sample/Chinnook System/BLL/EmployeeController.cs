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
    public class EmployeeController
    {
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<EmployeeList> EmployeeNameList_Get()
        {
            using (var context = new Chinookcontext())
            {
                var results = from x in context.Employees
                              orderby x.LastName, x.FirstName
                              select new EmployeeList
                              {
                                  EmployeeId = x.EmployeeId,
                                  Name = x.FirstName + " " + x.LastName
                              };
                return results.ToList();
            }
        }
    }
}
