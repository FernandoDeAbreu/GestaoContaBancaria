using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infra.DBContext
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<ContaBancaria> ContaBancaria { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Usuario>().ToTable("Asp.NetUsers").HasKey(t => t.Id);
            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=localhost\\SQLEXPRESS01; Initial Catalog=NovaBaseTeste;;Integrated Security=False;User ID=sa;Password=fdas*2018;Connect Timeout=15;Encrypt=False;TrustServerCertificate=False";
        }
    }
}