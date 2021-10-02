using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Album
    {
        //Primary Key
        public int AlbumId { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; }

        [Range(1900, 2050)]
        public int ReleasedYear { get; set; }

        public string Photo { get; set; }

        //Foreign Key
        public int ArtistId { get; set; }

        //parent ref
        public Artist Artist { get; set; }

        //child ref
        public List<Song> Songs { get; set; }
    }
}
