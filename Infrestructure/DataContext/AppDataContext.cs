using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrestructure.DataContext
{
    public class AppDataContext : DbContext
    {
        public AppDataContext(DbContextOptions<AppDataContext> options) : base(options)
        {

        }
        public virtual DbSet<Job> Jobs { get; set; }
        public virtual DbSet<Ejucation> Ejucations { get; set; }
        public virtual DbSet<CitiesLatAndLang> CitiesLatAndLangs { get; set; }
    }
}
