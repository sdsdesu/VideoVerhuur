using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;

namespace VideoVerhuurData.Repositories
{
    public class SQLFilmRepository : IFilmRepository
    {
        private readonly VideoVerhuurDbContext context;
        public SQLFilmRepository(VideoVerhuurDbContext context)
        {
            this.context = context;
        }

        public bool FilmInVoorraad(int filmId)
        {
           return context.Films
                .Where(f => f.FilmId == filmId)
                .Select(f => f.InVoorraad > 0)
                .FirstOrDefault();
        }


        public IEnumerable<Film> GetFilms(int genreId)
        {
            return context.Films
                .Where(f => f.GenreId == genreId)
                .OrderBy(f => f.Titel)
                .ToList();
        }

        public IEnumerable<Film> GetFilms(IEnumerable<int> filmIds)
        {
            return context.Films
                .Where(f => filmIds.Contains(f.FilmId))
                .ToList();
        }

        public Film GetFilmVoorWinkelmand(int id)
        {
            return context.Films.Find(id);
        }

        public IEnumerable<Genre> GetGenres()
        {
            return context.Genres.AsNoTracking();
        }

        public void ToevoegenAanVerhuringen(IEnumerable<int> filmIds, int klantId)
        {
            throw new NotImplementedException();
        }

        public string GetGenreNaam(int genreId)
        {
            return context.Genres
                .Where(g => g.GenreId == genreId)
                .Select(g => g.GenreNaam)
                .FirstOrDefault();
        }
    }
}
