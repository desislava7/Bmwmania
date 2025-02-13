using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bmwmania.Data
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<Automobile> Automobiles { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<EqLight> EqLights { get; set; }
        public DbSet<EqInterior> EqInteriors { get; set; }
        public DbSet<EqExterior> EqExteriors { get; set; }
        public DbSet<EqDigit> EqDigits { get; set; }
        public DbSet<Fuel> Fuels { get; set; }

    }
}
