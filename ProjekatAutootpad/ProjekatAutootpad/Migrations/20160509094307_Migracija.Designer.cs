using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatAutootpad.Autootpad.Models;

namespace ProjekatAutootpadMigrations
{
    [ContextType(typeof(OtpadDbContext))]
    partial class Migracija
    {
        public override string Id
        {
            get { return "20160509094307_Migracija"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

            builder.Entity("ProjekatAutootpad.Autootpad.Models.Dio", b =>
                {
                    b.Property<int>("DioID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Model");

                    b.Property<decimal>("NabavnaCijena");

                    b.Property<decimal>("ProdajnaCijena");

                    b.Property<string>("Proizvodjac");

                    b.Key("DioID");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.Kupac", b =>
                {
                    b.Property<int>("kupacId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("email");

                    b.Property<string>("imePrezime");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.Key("kupacId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.NarudzbaServisa", b =>
                {
                    b.Property<int>("NarudzbaServisaId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("dioZaServisiranjeDioID");

                    b.Property<int?>("narucilackupacId");

                    b.Property<string>("opisKvara");

                    b.Property<bool>("prihvacena");

                    b.Key("NarudzbaServisaId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.NarudžbaDijela", b =>
                {
                    b.Property<int>("NarudžbaDijelaId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Model");

                    b.Property<string>("NazivDijela");

                    b.Property<bool>("Prihvaćena");

                    b.Property<string>("Proizvođač");

                    b.Key("NarudžbaDijelaId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.Radnik", b =>
                {
                    b.Property<int>("radnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("KorisnikId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("datumRodjenja");

                    b.Property<string>("email");

                    b.Property<string>("imePrezime");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.Key("radnikId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.Servis", b =>
                {
                    b.Property<int>("servisId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("RadnikradnikId");

                    b.Property<decimal>("cijena");

                    b.Property<int?>("narudzbaNarudzbaServisaId");

                    b.Property<bool>("odraden");

                    b.Key("servisId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.NarudzbaServisa", b =>
                {
                    b.Reference("ProjekatAutootpad.Autootpad.Models.Dio")
                        .InverseCollection()
                        .ForeignKey("dioZaServisiranjeDioID");

                    b.Reference("ProjekatAutootpad.Autootpad.Models.Kupac")
                        .InverseCollection()
                        .ForeignKey("narucilackupacId");
                });

            builder.Entity("ProjekatAutootpad.Autootpad.Models.Servis", b =>
                {
                    b.Reference("ProjekatAutootpad.Autootpad.Models.Radnik")
                        .InverseCollection()
                        .ForeignKey("RadnikradnikId");

                    b.Reference("ProjekatAutootpad.Autootpad.Models.NarudzbaServisa")
                        .InverseCollection()
                        .ForeignKey("narudzbaNarudzbaServisaId");
                });
        }
    }
}
