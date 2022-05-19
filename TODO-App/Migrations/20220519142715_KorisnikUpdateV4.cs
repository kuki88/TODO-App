using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO_App.Migrations
{
    public partial class KorisnikUpdateV4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Zadaci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci");

            migrationBuilder.AlterColumn<int>(
                name: "KorisnikId",
                table: "Zadaci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnici_KorisnikId",
                table: "Zadaci",
                column: "KorisnikId",
                principalTable: "Korisnici",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
