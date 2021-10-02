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

        //Only represent Date
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(100)]
        public string Nationality { get; set; }

    }
}
