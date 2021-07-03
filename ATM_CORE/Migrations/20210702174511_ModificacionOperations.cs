using Microsoft.EntityFrameworkCore.Migrations;

namespace ATM_CORE.Migrations
{
    public partial class ModificacionOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cards_CardsId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "NumberOperacion",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "CardsId",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cards_CardsId",
                table: "Operations",
                column: "CardsId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_Cards_CardsId",
                table: "Operations");

            migrationBuilder.AlterColumn<int>(
                name: "CardsId",
                table: "Operations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "NumberOperacion",
                table: "Operations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_Cards_CardsId",
                table: "Operations",
                column: "CardsId",
                principalTable: "Cards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
