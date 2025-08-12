using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurData.Models
{
    [Table("Klanten")]
    public class Klant
    {
        [Key]
        public int KlantId { get; set; }
        public string Naam { get; set; }
        public string Voornaam { get; set; }

        public string Straat_Nr { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string KlantStat { get; set; }
        public int HuurAantal { get; set; }
        public DateTime DatumLid { get; set; }
        public bool Lidgeld { get; set; }
    }
}
