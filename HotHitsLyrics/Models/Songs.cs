using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Songs
    {
        //Create Primary Key, Foreign Key and related fields of Songs
        public int SongsId { get; set; }
        public string SongName { get; set; }
        public string Genre { get; set; }
        public int ReleasedYear { get; set; }
        public int SingersId { get; set; }
    }
}
