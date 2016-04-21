using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatAutootpad.Baza.Models;

namespace ProjekatAutootpadMigrations
{
    [ContextType(typeof(NarudžbaDijelaDbContext))]
    partial class InitialMigration
    {
        public override string Id
        {
            get { return "20160421135504_InitialMigration"; }
        }

        public override string ProductVersion
        {
            get { return "7.0.0-beta6-13815"; }
        }

        public override void BuildTargetModel(ModelBuilder builder)
        {
            builder
                .Annotation("ProductVersion", "7.0.0-beta6-13815");

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
        }
    }
}
