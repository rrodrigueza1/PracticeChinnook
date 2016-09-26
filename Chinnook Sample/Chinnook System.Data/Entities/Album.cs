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
    [Table("Artists", Schema = "dbo")]
    public class Album
    {
        public int AlbumId { get; set; }
        public string Title { get; set; }
        public int ArtistId {get; set;}
        public int ReleaseYear { get; set; }
        public string ReleaseLabel { get; set; }
    }
}
