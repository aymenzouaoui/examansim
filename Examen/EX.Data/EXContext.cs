using EX.Core.Domain;
using EX.Data.Configuration;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace EX.Data
{
    public class EXContext:DbContext
    {

        DbSet<Client> clients { get; set; }
        DbSet<Specialite> Specialites{ get; set; }
        DbSet<Presation> presations { get; set; }
        DbSet<Prestataire> prestataires { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(localdb)\mssqllocaldb;
                                        Initial Catalog = ZOUAOUIAYMENPRESTATION; 
                                        Integrated Security = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FluentApiConfiguration());

            modelBuilder.Entity<Client>().OwnsOne(a => a.Cooredonnnes);
            base.OnModelCreating(modelBuilder);
        }
    }
}