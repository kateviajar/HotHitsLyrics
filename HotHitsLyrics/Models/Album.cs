using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Released Year")]
        [Range(1900, 2050)]
        public int ReleasedYear { get; set; }

        public string Photo { get; set; }

        //Foreign Key
        [Display(Name = "Artist")]
        public int ArtistId { get; set; }

        //parent ref
        public Artist Artist { get; set; }

        //child ref
        public List<Song> Songs { get; set; }

        //For uploading the photo file
        [NotMapped] //not generate a column in the database
        [Display(Name ="Upload Photo")]
        public IFormFile PhotoFile { get; set; }
    }
}
