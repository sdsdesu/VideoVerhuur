using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;
using VideoVerhuurData.Repositories;
using VideoVerhuurServices;

namespace VideoVerhuurWeb.Services
{
    public class FilmService(IFilmRepository filmRepository, IHttpContextAccessor httpContextAccessor)
    {
        public bool HeeftWinkelmand()
        {
            return httpContextAccessor.HttpContext?.Session.GetString("Winkelmand") != null;
        }
        public void Huren(int id)
        {
            var filmVoorwinkelmandSession = GetFilmVoorWinkelmand(id);
            string winkelmand = httpContextAccessor.HttpContext?.Session.GetString("Winkelmand");
            if (string.IsNullOrEmpty(winkelmand))
            {
                winkelmand = $"{filmVoorwinkelmandSession.FilmId}";
            }
            else
            {
                winkelmand += $",{filmVoorwinkelmandSession.FilmId}";
            }
            httpContextAccessor.HttpContext?.Session.SetString("Winkelmand", winkelmand);
        }
        public IEnumerable<Film> GetFilmsInWinkelmand()
        {
            string winkelmand = httpContextAccessor.HttpContext?.Session.GetString("Winkelmand");
            if (winkelmand == null || winkelmand == string.Empty)
            {
                return null;
            }
            else
            {
                var filmIds = winkelmand.Split(',').Select(int.Parse);
                var films = filmRepository.GetFilms(filmIds);
                return films;
            }



        }
        public void VerwijderVanWinkelmand(int id)
        {
            string oudeWinkelmand = httpContextAccessor.HttpContext.Session.GetString("Winkelmand");
            IEnumerable<int> filmIds = oudeWinkelmand.Split(',').Select(int.Parse);
            string nieuweWinkelmand = string.Empty;
            foreach (var filmId in filmIds)
            {
                if (filmId != id)
                {
                    if (!string.IsNullOrEmpty(nieuweWinkelmand))
                    {
                        nieuweWinkelmand += ",";
                    }
                    nieuweWinkelmand += $"{filmId}";
                }
            }
            if (!string.IsNullOrEmpty(nieuweWinkelmand))
                httpContextAccessor.HttpContext.Session.SetString("Winkelmand", nieuweWinkelmand);
            else
                httpContextAccessor.HttpContext.Session.Remove("Winkelmand");

        }
        public void AllesWinkelmandVerhuren(int klantId)
        {
            string winkelmand = httpContextAccessor.HttpContext?.Session.GetString("Winkelmand");
            IEnumerable<int> filmIds = winkelmand.Split(',').Select(int.Parse);
            filmRepository.ToevoegenAanVerhuringen(filmIds, klantId);
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
