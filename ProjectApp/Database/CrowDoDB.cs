using Entities;
using Microsoft.EntityFrameworkCore;


namespace ProjectApp.Database
{
    class CrowDoDB : DbContext
    {
        public DbSet<ProjectItem> Projects { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Funding> Fundings { get; set; }
        public DbSet<PackageItemAsking> PackagesAsking { get; set; }
        public DbSet<PackageItemReceived> PackagesReceived { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connString1 = "Server =localhost ; Database =Crowdo; Integrated Security = SSPI; Persist Security Info=False;";
            optionsBuilder.UseSqlServer(connString1);
        }


    }
}
