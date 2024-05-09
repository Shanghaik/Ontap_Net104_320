using Microsoft.EntityFrameworkCore;
using Ontap_Net104_320.Configurations;
using System.Reflection;

namespace Ontap_Net104_320.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(){}
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        // Khai báo các DbSet
        public DbSet<Account> Accounts { get; set; } // Mỗi DbSet sẽ thường đại diện 1 bảng trong CSDL

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=SHANGHAIK;Initial Catalog=Ontap320;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        // Thực hiện override các phương thức cấu hình

    }
}
