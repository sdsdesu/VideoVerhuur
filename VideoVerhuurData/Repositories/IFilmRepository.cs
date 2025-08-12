using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;

namespace VideoVerhuurData.Repositories
{
    public interface IFilmRepository
    {
        public IEnumerable<Genre> GetGenres();
        public IEnumerable<Film> GetFilms(int genreId);
        public IEnumerable<Film> GetFilms(IEnumerable<int> filmIds);
        public bool FilmInVoorraad(int filmId);
        public Film GetFilmVoorWinkelmand(int id);
        public void ToevoegenAanVerhuringen(IEnumerable<int> filmIds, int klantId);
        public string GetGenreNaam(int genreId);
    }
}
