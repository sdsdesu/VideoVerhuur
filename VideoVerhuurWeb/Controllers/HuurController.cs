
using Microsoft.AspNetCore.Mvc;
using VideoVerhuurWeb.Services;
using VideoVerhuurWeb.Models;
using VideoVerhuurData.Models;

namespace VideoVerhuurWeb.Controllers
{
    public class HuurController : Controller
    {
        private readonly FilmService filmService;
        private readonly LoginService klantService;

        public HuurController(FilmService filmService, LoginService klantService)
        {
            this.filmService = filmService;
            this.klantService = klantService;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var genres = filmService.GetGenres();
            
            GenreViewModel viewModel = new GenreViewModel
            {
                Genres = genres.ToList(),
                heeftWinkelmand = !filmService.HeeftWinkelmand()
            };



            return View(viewModel);
        }
        /*public IActionResult Films(int id) {
            string genreNaam = filmService.getGenreNaam(id);
            var films = filmService.GetFilms(id);
            SelecteerFilmViewModel viewModel = new SelecteerFilmViewModel
            {
                Genre = genreNaam,
                Films = films.ToList()
            };
            return View(viewModel);
        }*/
        public IActionResult Films(string genreNaam)
        {
            var films = filmService.GetFilms(genreNaam);
            SelecteerFilmViewModel viewModel = new SelecteerFilmViewModel
            {
                Genre = genreNaam,
                Films = films.ToList()
            };
            return View(viewModel);
        }




        public IActionResult Huren(int id)
        {
            filmService.Huren(id);
            return RedirectToAction("Winkelmand");

        }

        public IActionResult Winkelmand()
        {
            
            if (!filmService.HeeftWinkelmand())
            {
                return RedirectToAction(nameof(Index));
            }
            else
                return View(filmService.GetFilmsInWinkelmand());
        }

        public IActionResult VerwijderPagina(int id)
        {
            var film = filmService.GetFilmVoorWinkelmand(id);

            VerwijderenViewModel viewModel = new VerwijderenViewModel
            {
                Id = film.FilmId,
                Title = film.Titel
            };
            return View(viewModel);

        }
        [HttpPost]
        public IActionResult Verwijderen(VerwijderenViewModel verwijderen)
        {
            filmService.VerwijderVanWinkelmand(verwijderen.Id);
            return RedirectToAction(nameof(Winkelmand));
        }

        public IActionResult Huuren()
        {
            Klant klant = klantService.GetKlant();
            var films = filmService.GetFilmsInWinkelmand();
            filmService.AllesWinkelmandVerhuren(klant.KlantId);

            RekeningViewModel viewModel = new RekeningViewModel()
            {
                Naam = klant.Naam,
                Films = films.ToList(),
                Adres = klant.Straat_Nr,
                Gemeente = klant.Gemeente
            };



            HttpContext.Session.Remove("Winkelmand");



            return View(viewModel);


        }
        public IActionResult Logout()
        {
            klantService.logout();
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
