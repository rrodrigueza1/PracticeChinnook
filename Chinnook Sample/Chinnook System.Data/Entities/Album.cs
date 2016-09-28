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
    [Table("Albums")]
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId {get; set;}
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }

        // Naviagation property for use by Linq
        // This properties will be of type virtual
        // There are two types of naviagation properties 
        // Properties that point to "childred" use ICollection<T>
        // Properties that point to "parent" use ParentName as the DataType
        public virtual ICollection<Tracks> Tracks { get; set; }
        public virtual Artist Artists { get; set; }
    }
}
