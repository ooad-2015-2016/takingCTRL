using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;
using Microsoft.Data.Entity.Migrations.Builders;
using Microsoft.Data.Entity.Migrations.Operations;

namespace ProjekatAutootpadMigrations
{
    public partial class InitialMigration : Migration
    {
        public override void Up(MigrationBuilder migration)
        {
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
        }

        public override void Down(MigrationBuilder migration)
        {
            migration.DropTable("NarudžbaDijela");
        }
    }
}
