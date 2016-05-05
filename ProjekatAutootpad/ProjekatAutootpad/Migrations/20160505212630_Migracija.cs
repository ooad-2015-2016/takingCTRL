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
                name: "Dio",
                columns: table => new
                {
                    DioID = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Model = table.Column(type: "TEXT", nullable: true),
                    NabavnaCijena = table.Column(type: "TEXT", nullable: false),
                    ProdajnaCijena = table.Column(type: "TEXT", nullable: false),
                    Proizvodjac = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dio", x => x.DioID);
                });
            migration.CreateTable(
                name: "Kupac",
                columns: table => new
                {
                    kupacId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    email = table.Column(type: "TEXT", nullable: true),
                    imePrezime = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kupac", x => x.kupacId);
                });
            migration.CreateTable(
                name: "NarudžbaDijela",
                columns: table => new
                {
                    NarudžbaDijelaId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
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
                name: "Radnik",
                columns: table => new
                {
                    radnikId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    KorisnikId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    datumRodjenja = table.Column(type: "TEXT", nullable: false),
                    email = table.Column(type: "TEXT", nullable: true),
                    imePrezime = table.Column(type: "TEXT", nullable: true),
                    password = table.Column(type: "TEXT", nullable: true),
                    username = table.Column(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radnik", x => x.radnikId);
                });
            migration.CreateTable(
                name: "NarudzbaServisa",
                columns: table => new
                {
                    NarudzbaServisaId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    dioZaServisiranjeDioID = table.Column(type: "INTEGER", nullable: true),
                    narucilackupacId = table.Column(type: "INTEGER", nullable: true),
                    opisKvara = table.Column(type: "TEXT", nullable: true),
                    prihvacena = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NarudzbaServisa", x => x.NarudzbaServisaId);
                    table.ForeignKey(
                        name: "FK_NarudzbaServisa_Dio_dioZaServisiranjeDioID",
                        columns: x => x.dioZaServisiranjeDioID,
                        referencedTable: "Dio",
                        referencedColumn: "DioID");
                    table.ForeignKey(
                        name: "FK_NarudzbaServisa_Kupac_narucilackupacId",
                        columns: x => x.narucilackupacId,
                        referencedTable: "Kupac",
                        referencedColumn: "kupacId");
                });
            migration.CreateTable(
                name: "Servis",
                columns: table => new
                {
                    servisId = table.Column(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    RadnikradnikId = table.Column(type: "INTEGER", nullable: true),
                    cijena = table.Column(type: "TEXT", nullable: false),
                    narudzbaNarudzbaServisaId = table.Column(type: "INTEGER", nullable: true),
                    odraden = table.Column(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servis", x => x.servisId);
                    table.ForeignKey(
                        name: "FK_Servis_Radnik_RadnikradnikId",
                        columns: x => x.RadnikradnikId,
                        referencedTable: "Radnik",
                        referencedColumn: "radnikId");
                    table.ForeignKey(
                        name: "FK_Servis_NarudzbaServisa_narudzbaNarudzbaServisaId",
                        columns: x => x.narudzbaNarudzbaServisaId,
                        referencedTable: "NarudzbaServisa",
                        referencedColumn: "NarudzbaServisaId");
                });
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("NarudžbaDijela");
            migration.DropTable("Servis");
            migration.DropTable("Radnik");
            migration.DropTable("NarudzbaServisa");
            migration.DropTable("Dio");
            migration.DropTable("Kupac");
        }
    }
}
