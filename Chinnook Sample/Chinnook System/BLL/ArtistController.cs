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
    public class ArtistController
    {
        //dump the entire artist entity
        // this will use Entity Framework access 
        //Entity Classes will be use to define the data
        [DataObjectMethod(DataObjectMethodType.Select, false)]
        public List<Artist> Artist_ListAll()
        {
            //setup transaction area
            using (var context = new Chinookcontext())
            {
                return context.Artists.ToList();
            }
        }

        // report a data set containing data from 
        // mulitple tables/entities
        // this will use Linq to Entity Access
        // POCO Classes will be use to define the data
        public List<ArtistsAlbum> ArtistAlbums_Get()
        {
            //setup transaction area
            using (var context = new Chinookcontext())
            {
                // when you bring your query from linqpad to your program you must change the referenc(s)
                // to the data source
                // you may also need to change your navigation referencing use in linqpad to the navigation
                // properties you stated in the entity class definition
                var results = from x in context.Albums
                              where x.ReleaseYear == 2008
                              orderby x.Artists.Name, x.Title
                              select new ArtistsAlbum
                              {
                                 // Name and Title are POCO class property name
                                 Name =  x.Artists.Name,
                                 Title = x.Title
                              };
                // the following requires the query data in memory
                // .ToList()
                return results.ToList();
            }
        }
    }
}
