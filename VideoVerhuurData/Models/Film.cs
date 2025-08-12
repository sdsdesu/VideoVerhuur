using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurData.Models
{
    [Table("Films")]
    public class Film
    {
        [Key]
        public int FilmId { get; set; }
        public string Titel { get; set; }
        [ForeignKey("Genre")]
        public int GenreId { get; set; }
        public int InVoorraad { get; set; }
        public int UitVoorraad { get; set; }
        public decimal Prijs { get; set; }
        public int TotaalVerhuurd { get; set; }

        public virtual Genre Genre { get; set; }
    }
}
