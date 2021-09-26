using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotHitsLyrics.Models
{
    public class Singers
    {
        //Create Primary Key and related fields of Singers
        public int SingersId { get; set; }
        public string Name { get; set; }
        public string Language { get; set; }
        public string Country { get; set; }
    }
}
