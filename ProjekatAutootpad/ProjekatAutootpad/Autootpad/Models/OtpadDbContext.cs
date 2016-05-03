using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;

namespace ProjekatAutootpad.Autootpad.Models
{
    class OtpadDbContext : DbContext
    {
        public DbSet<NarudžbaDijela> NarudzbeDijelova { get; set; }
        public DbSet<Korisnik> Korisnici { get; set; }
        public DbSet<Dio> Dijelovi { get; set; }
        public DbSet<Servis> servisi { get; set; }
        public DbSet<NarudzbaServisa> narudzbeServisa { get; set; }
        public DbSet<Dio> ponudeniDijelovi { get; set; } // Dijelovi koje je korisnik ponudio da proda, id kojih radnik bira koje ce IbroAutootpad kupiti od korisnika sistema


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string databaseFilePath = "Otpadbaza.db";
            try
            {
                databaseFilePath = Path.Combine(ApplicationData.Current.LocalFolder.Path, databaseFilePath);
            }
            catch (InvalidOperationException) { }

            optionsBuilder.UseSqlite($"Data source={databaseFilePath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
