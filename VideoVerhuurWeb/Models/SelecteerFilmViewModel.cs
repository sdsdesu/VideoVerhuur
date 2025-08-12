using VideoVerhuurData.Models;

namespace VideoVerhuurWeb.Models
{
    public class SelecteerFilmViewModel
    {
        public string Genre { get; set; }
        public IEnumerable<Film> Films { get; set; }

    }
}
