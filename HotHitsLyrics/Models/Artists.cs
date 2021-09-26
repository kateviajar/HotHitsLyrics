using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Artists
    {
        //Create Primary Key and related fields of Artists
        public int ArtistsId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}
