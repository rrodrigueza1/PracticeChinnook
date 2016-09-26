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
    //point to the sql table that this file maps
    [Table("Artists", Schema = "dbo")]
    public class Artist
    {
        //   "Key notations is optional if the sql pkey ends in ID or id"
        //     required if the default of entity is not identity
        //     required if pkey is compound

        // properties can be fully implemented or auto implemented
        // poperty names should use sql attribute name
        // properties should listed in the same order as sql table attributes for ease of maintenance
        [Key]

        public int ArtistsId { get; set; }
        public string Name { get; set; }
        
    }
}
