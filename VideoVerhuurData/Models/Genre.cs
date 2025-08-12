using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurData.Models
{
    [Table("Genres")]
    public class Genre
    {
        [Key]
        public int GenreId { get; set; }
        public string GenreNaam { get; set; }
        
    }
}
