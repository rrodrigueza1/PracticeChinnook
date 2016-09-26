using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#region Additional Namespaces
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endregion

namespace Chinnook_System.Data.Entities
{
    [Table("MediaTypes", Schema = "dbo")]
    public class MediaType
    {
        public int MediaTypeId { get; set; }
        public string Name { get; set; }
    }
}
