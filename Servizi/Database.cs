using Microsoft.EntityFrameworkCore;
using Scacchi.Modello;

namespace Scacchi.Servizi{
    public class DataBase : DbContext{
        public DataBase() : base()
        {
            this.Database.EnsureCreated();
        }
        public DbSet<Mossa> Mosse {get;set;}
         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
             optionsBuilder.UseSqlite(@"Data Source=..\..\..\Database.db");
         }
         protected override void OnModelCreating(ModelBuilder modelBuilder) {
             modelBuilder.Entity<Mossa>().ToTable("Mosse").HasKey(p => p.IdMossa);
         } 
    }
}