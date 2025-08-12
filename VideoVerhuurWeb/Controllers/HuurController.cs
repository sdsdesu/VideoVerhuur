
using Microsoft.AspNetCore.Mvc;
using VideoVerhuurServices;
using VideoVerhuurWeb.Models;

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
            string winkelmand = HttpContext.Session.GetString("Winkelmand");
            bool winkelmandLeeg = string.IsNullOrEmpty(winkelmand);
            GenreViewModel viewModel = new GenreViewModel
            {
                Genres = genres.ToList(),
                heeftWinkelmand = !winkelmandLeeg
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
            var filmVoorwinkelmandSession = filmService.GetFilmVoorWinkelmand(id);
            string winkelmand = HttpContext.Session.GetString("Winkelmand");
            if (string.IsNullOrEmpty(winkelmand))
            {
                winkelmand = $"{filmVoorwinkelmandSession.FilmId}";
            }
            else
            {
                winkelmand += $",{filmVoorwinkelmandSession.FilmId}";
            }
            HttpContext.Session.SetString("Winkelmand", winkelmand);
            return RedirectToAction("Winkelmand");

        }

        public IActionResult Winkelmand()
        {
            string winkelmand = HttpContext.Session.GetString("Winkelmand");
            if (string.IsNullOrEmpty(winkelmand))
            {
                return RedirectToAction(nameof(Index));
            }
            var filmIds = winkelmand.Split(',').Select(int.Parse);
            var films = filmService.GetFilms(filmIds);
            return View(films);
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
            string oudeWinkelmand = HttpContext.Session.GetString("Winkelmand");
            IEnumerable<int> filmIds = oudeWinkelmand.Split(',').Select(int.Parse);
            string nieuweWinkelmand = string.Empty;
            foreach (var filmId in filmIds)
            {
                if (filmId != verwijderen.Id)
                {
                    if (!string.IsNullOrEmpty(nieuweWinkelmand))
                    {
                        nieuweWinkelmand += ",";
                    }
                    nieuweWinkelmand += $"{filmId}";
                }
            }



            HttpContext.Session.SetString("Winkelmand", nieuweWinkelmand);
            return RedirectToAction(nameof(Winkelmand));
        }

        public IActionResult Huuren()
        {
            string winkelmand = HttpContext.Session.GetString("Winkelmand");
            IEnumerable<int> filmIds = winkelmand.Split(',').Select(int.Parse);
            var films = filmService.GetFilms(filmIds);
            var klantId = HttpContext.Session.GetInt32("KlantId");
            var klant = klantService.GetKlant((int)klantId);

            filmService.ToevoegenAanVerhuringen(filmIds, (int)klantId);

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
            HttpContext.Session.Remove("KlantNaam");
            HttpContext.Session.Remove("KlantId");
            HttpContext.Session.Remove("Winkelmand");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
