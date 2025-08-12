using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoVerhuurData.Models;

namespace VideoVerhuurData.Repositories
{
    public class SQLLoginRepository : ILoginRepository
    {
        private readonly VideoVerhuurDbContext context;
        public SQLLoginRepository(VideoVerhuurDbContext context)
        {
            this.context = context;
        }

        public Klant GetKlant(int klantId)
        {
            return context.Klanten
                .FirstOrDefault(k => k.KlantId == klantId);
        }

        public Klant GetKlant(string naam, string postcode)
        {
            return context.Klanten
                .FirstOrDefault(k => k.Naam.ToUpper() == naam.ToUpper() && k.Postcode == postcode);
        }

        public bool ValidateLogin(string naam, string postcode)
        {

            

            return context.Klanten.Any(k => k.Naam.ToUpper() == naam.ToUpper());;
        }
    }
}
