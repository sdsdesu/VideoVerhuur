using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurData.Models
{
    [Table("Verhuringen")]
    public class Verhuring
    {
        [Key]
        public int VerhuurId { get; set; }
        [ForeignKey("Klant")]
        public int KlantId { get; set; }
        [ForeignKey("Film")]
        public int FilmId { get; set; }
        public DateTime VerhuurDatum { get; set; }

        public Klant Klant { get; set; }
        public Film Film { get; set; }

    }
}
