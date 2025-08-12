using System.ComponentModel.DataAnnotations;

namespace VideoVerhuurWeb.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Naam is een verpicht veld")]
        public string Naam { get; set; }
        [Required(ErrorMessage = "Naam is een verpicht veld")]
        public string Postcode { get; set; }
    }
}
