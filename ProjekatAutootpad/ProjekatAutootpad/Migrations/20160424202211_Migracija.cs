using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatAutootpadMigrations
{
    public partial class Migracija : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
            migration.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    KorisnikId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    email = table.Column(type: "TEXT", nullable: true),
                    imePrezime = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.KorisnikId);
                });
            migration.CreateTable(
                name: "NarudžbaDijela",
                columns: table => new
                {
                    NarudžbaDijelaId = table.Column(type: "INTEGER", nullable: false),
                        //.Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column(type: "TEXT", nullable: true),
                    NazivDijela = table.Column(type: "TEXT", nullable: true),
                    Prihvaćena = table.Column(type: "INTEGER", nullable: false),
                    Proizvođač = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudžbaDijela", x => x.NarudžbaDijelaId);
                });
            migration.CreateTable(
               name: "Dio",
               columns: table => new
               {
                   DioID = table.Column(type: "INTEGER", nullable: false),
                    //.Annotation("Sqlite:Autoincrement", true),
                   NabavnaCijena = table.Column(type: "REAL", nullable: true),
                   ProdajnaCijena = table.Column(type: "REAL", nullable: true),
                   Model = table.Column(type: "TEXT", nullable: false),
                   Proizvodjac = table.Column(type: "TEXT", nullable: true)
               },
               constraints: table =>
               {
                   table.PrimaryKey("PK_Dio", x => x.DioID);
               });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("Korisnik");
            migration.DropTable("NarudžbaDijela");
            migration.DropTable("Dio");
        }
    }
}
