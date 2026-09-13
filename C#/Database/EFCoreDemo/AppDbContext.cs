using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo
{
    public class AppDbContext : DbContext
    {
        public DbSet<EFCoreItem> EFCoreItems { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=.\MSSQLSERVER01;Database=LearnDb;UID=SSMS21;PWD=YYYXUEBING;TrustServerCertificate=true;");
        }
    }
}
