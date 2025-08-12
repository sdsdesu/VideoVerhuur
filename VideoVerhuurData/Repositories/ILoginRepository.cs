using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;

namespace VideoVerhuurData.Repositories
{
    public interface ILoginRepository
    {
        public bool ValidateLogin(string naam, string postcode);
        public Klant GetKlant(string naam, string postcode);
        public Klant GetKlant(int klantId);
    }
}
