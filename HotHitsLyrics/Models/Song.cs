using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Song
    {
        //Primary Key
        public int SongId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        public string Genre { get; set; }

        [DataType(DataType.Time)]
        public DateTime Length { get; set; }

        public string Songwriter { get; set; }

        [Required]
        public string Lyrics { get; set; }

        //Foreign Key
        public int AlbumId { get; set; }

        //parent ref
        public Album Album { get; set; }
    }
}
