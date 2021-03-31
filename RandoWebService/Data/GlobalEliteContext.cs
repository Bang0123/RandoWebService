using Microsoft.EntityFrameworkCore;
using RandoWebService.Data.Models;

namespace RandoWebService.Data
{
    public class GlobalEliteContext : DbContext
    {
        public GlobalEliteContext(DbContextOptions<GlobalEliteContext> options) : base(options)
        {
        }

        public DbSet<EliteData> EliteDatas { get; set; }
        public DbSet<EliteRef> EliteRefs { get; set; }
    }
}
