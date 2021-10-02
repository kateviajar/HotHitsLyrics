using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Artist
    {
        //Primary Key
        public int ArtistId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        //Only represent Date
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

        //child ref
        public List<Album> Albums { get; set; }
    }
}
