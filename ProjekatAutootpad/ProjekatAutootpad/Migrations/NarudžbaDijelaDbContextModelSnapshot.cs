using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations.Infrastructure;
using ProjekatAutootpad.Baza.Models;

namespace ProjekatAutootpadMigrations
{
    [ContextType(typeof(NarudžbaDijelaDbContext))]
    partial class NarudžbaDijelaDbContextModelSnapshot : ModelSnapshot
    {
        public override void BuildModel(ModelBuilder builder)
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
