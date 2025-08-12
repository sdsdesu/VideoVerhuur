using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;
using VideoVerhuurData.Repositories;

namespace VideoVerhuurServices
{
    public class FilmService
    {
        private readonly IFilmRepository filmRepository;
        public FilmService(IFilmRepository filmRepository)
        {
            this.filmRepository = filmRepository;
        }
        public IEnumerable<Genre> GetGenres()
        {
            return filmRepository.GetGenres();
        }
        public IEnumerable<Film> GetFilms(int genreId)
        {
            return filmRepository.GetFilms(genreId);
        }
        public IEnumerable<Film> GetFilms(string genreNaam)
        {
            return filmRepository.GetFilms(genreNaam);
        }
        public IEnumerable<Film> GetFilms(IEnumerable<int> filmIds)
        {
            return filmRepository.GetFilms(filmIds);
        }
        public Film GetFilmVoorWinkelmand(int id)
        {
            return filmRepository.GetFilmVoorWinkelmand(id);
        }
        public void ToevoegenAanVerhuringen(IEnumerable<int> filmIds, int klantId)
        {
            filmRepository.ToevoegenAanVerhuringen(filmIds, klantId);
        }
        public bool FilmInVoorraad(int filmId)
        {
            return filmRepository.FilmInVoorraad(filmId);

        }
        public string getGenreNaam(int id)
        {
            return filmRepository.GetGenreNaam(id);
        }
    }
}
