using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using VideoVerhuurServices;
using VideoVerhuurWeb.Models;

namespace VideoVerhuurWeb.Controllers;

public class HomeController : Controller
{
    private readonly LoginService service;

    public HomeController(LoginService service)
    {
        this.service = service;
    }

    public IActionResult Index()
    {
        // HttpContext.Session.SetString("KlantNaam", "");
        return View();
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Index(LoginViewModel loginViewModel)
    {
        try
        {
            if (ModelState.IsValid)
            {

                if (service.ValidateLogin(loginViewModel.Naam, loginViewModel.Postcode))
                {
                    var klant = service.GetKlant(loginViewModel.Naam, loginViewModel.Postcode);
                    string klantNaam = $"{klant.Voornaam} {klant.Naam}";
                    int klantId = klant.KlantId;
                    HttpContext.Session.SetString("KlantNaam", klantNaam);
                    HttpContext.Session.SetInt32("KlantId", klantId);
                    return RedirectToAction("index", "Huur");
                }
                ModelState.AddModelError("", "Onbekende klant, probeer opnieuw.");
            }
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", $"Er is een fout opgetreden: {ex.Message}");
        }
        return View("Index");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
