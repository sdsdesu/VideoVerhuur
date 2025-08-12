using Microsoft.AspNetCore.Mvc;
using VideoVerhuurData.Models;

namespace VideoVerhuurWeb.ViewComponents
{
    public class Begroeting : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            
            if (HttpContext.Session.GetString("KlantNaam") == null)
                return View("");
            else
            {
                string klantNaam = HttpContext.Session.GetString("KlantNaam");
                return View("",klantNaam);
            }
        }
        
    }

}

