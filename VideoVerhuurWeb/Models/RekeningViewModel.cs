using VideoVerhuurData.Models;

namespace VideoVerhuurWeb.Models
{
    public class RekeningViewModel
    {
        public IEnumerable<Film> Films { get; set; }
        public string Naam { get; set; }
        public string Adres { get; set; }
        public string Gemeente { get; set; }
        public decimal TotaalPrijs => Films?.Sum(film => film.Prijs) ?? 0;
    }
}
