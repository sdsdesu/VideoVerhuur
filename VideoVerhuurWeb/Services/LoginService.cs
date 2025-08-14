using NuGet.Protocol;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;
using VideoVerhuurData.Repositories;

namespace VideoVerhuurWeb.Services
{
    public class LoginService(ILoginRepository loginRepository, IHttpContextAccessor httpContextAccessor)
    {
        public void login(string naam, string postcode) {
                            var klant = loginRepository.GetKlant(naam, postcode);
                string klantNaam = $"{klant.Voornaam} {klant.Naam}";
                int klantId = klant.KlantId;
                httpContextAccessor.HttpContext?.Session.SetString("KlantNaam", klantNaam);
                httpContextAccessor.HttpContext?.Session.SetInt32("KlantId", klantId);
                 
        }
        public void logout() {
            httpContextAccessor.HttpContext?.Session.Remove("KlantNaam");
            httpContextAccessor.HttpContext?.Session.Remove("KlantId");
            httpContextAccessor.HttpContext?.Session.Remove("Winkelmand");
        }
        public bool ValidateLogin(string naam, string postcode)
        {
            return loginRepository.ValidateLogin(naam, postcode);
        }/*
        public Klant GetKlant(string naam, string postcode)
        {
            return loginRepository.GetKlant(naam, postcode);
        }*/
        public Klant GetKlant() {
        var klantId = httpContextAccessor.HttpContext?.Session.GetInt32("KlantId");
        return loginRepository.GetKlant((int)klantId);
        }

        public Klant GetKlant(int klantId)
        {
            return loginRepository.GetKlant(klantId);
        }
    }
}
