using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO_App.Migrations
{
    public partial class IzvrsiteljIdUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci");

            migrationBuilder.DropIndex(
                name: "IX_Zadaci_IzvrsiteljZadatkaId",
                table: "Zadaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik");

            migrationBuilder.DropColumn(
                name: "IzvrsiteljZadatkaId",
                table: "Zadaci");

            migrationBuilder.RenameTable(
                name: "Korisnik",
                newName: "Korisnici");

            migrationBuilder.AddColumn<int>(
                name: "KorisnikId",
                table: "Zadaci",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci");

            migrationBuilder.DropIndex(
                name: "IX_Zadaci_KorisnikId",
                table: "Zadaci");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Korisnici",
                table: "Korisnici");

            migrationBuilder.DropColumn(
                name: "KorisnikId",
                table: "Zadaci");

            migrationBuilder.RenameTable(
                name: "Korisnici",
                newName: "Korisnik");

            migrationBuilder.AddColumn<int>(
                name: "IzvrsiteljZadatkaId",
                table: "Zadaci",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Korisnik",
                table: "Korisnik",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Zadaci_IzvrsiteljZadatkaId",
                table: "Zadaci",
                column: "IzvrsiteljZadatkaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci",
                column: "IzvrsiteljZadatkaId",
                principalTable: "Korisnik",
                principalColumn: "Id");
        }
    }
}
