using VideoVerhuurData.Models;

namespace VideoVerhuurWeb.Models
{
    public class GenreViewModel
    {
        public bool heeftWinkelmand { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}
