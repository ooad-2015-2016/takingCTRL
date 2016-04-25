using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatAutootpad.Baza.Models;

namespace ProjekatAutootpadMigrations
{
    [ContextType(typeof(OtpadDbContext))]
    partial class OtpadDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatAutootpad.Baza.Models.Korisnik", b =>
                {
                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("email");

                    b.Property<string>("imePrezime");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.Key("KorisnikId");
                });

            builder.Entity("ProjekatAutootpad.Baza.Models.NarudžbaDijela", b =>
                {
                    b.Property<int>("NarudžbaDijelaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Model");

                    b.Property<string>("NazivDijela");

                    b.Property<bool>("Prihvaćena");

                    b.Property<string>("Proizvođač");

                    b.Key("NarudžbaDijelaId");
                });
            builder.Entity("ProjekatAutootpad.Baza.Models.NarudžbaDijela", b =>
            {
                b.Property<int>("DioID")
                    .ValueGeneratedOnAdd();

                b.Property<decimal>("NabavnaCijena");

                b.Property<decimal>("ProdajnaCijena");

                b.Property<string>("Model");

                b.Property<string>("Proizvodjac");

                b.Key("DioID");
            });
        }
    }
}
