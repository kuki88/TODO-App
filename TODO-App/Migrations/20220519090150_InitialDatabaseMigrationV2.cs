using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TODO_App.Migrations
{
    public partial class InitialDatabaseMigrationV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci");

            migrationBuilder.AlterColumn<int>(
                name: "IzvrsiteljZadatkaId",
                table: "Zadaci",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci",
                column: "IzvrsiteljZadatkaId",
                principalTable: "Korisnik",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci");

            migrationBuilder.AlterColumn<int>(
                name: "IzvrsiteljZadatkaId",
                table: "Zadaci",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Zadaci_Korisnik_IzvrsiteljZadatkaId",
                table: "Zadaci",
                column: "IzvrsiteljZadatkaId",
                principalTable: "Korisnik",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
