using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;
using VideoVerhuurData.Repositories;

namespace VideoVerhuurServices
{
    public class LoginService
    {
        readonly ILoginRepository loginRepository;
        public LoginService(ILoginRepository loginRepository)
        {
            this.loginRepository = loginRepository;
        }
        public bool ValidateLogin(string naam, string postcode)
        {
            return loginRepository.ValidateLogin(naam, postcode);
        }
        public Klant GetKlant(string naam, string postcode)
        {
            return loginRepository.GetKlant(naam, postcode);
        }
        public Klant GetKlant(int klantId)
        {
            return loginRepository.GetKlant(klantId);
        }
    }
}
