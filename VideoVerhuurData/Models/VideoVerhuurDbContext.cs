using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VideoVerhuurData.Models
{
    public class VideoVerhuurDbContext : DbContext
    {
        public VideoVerhuurDbContext(DbContextOptions<VideoVerhuurDbContext> options) : base(options)
        {
        }

        public DbSet<Film> Films { get; set; }
        public DbSet<Klant> Klanten { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Verhuring> Verhuringen { get; set; }





    }
}
