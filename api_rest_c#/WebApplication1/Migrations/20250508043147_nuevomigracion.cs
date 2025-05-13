using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebApplication1.Migrations
{
    /// <inheritdoc />
    public partial class nuevomigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_Mandril_MandrilId",
                table: "Habilidades");

            migrationBuilder.AlterColumn<int>(
                name: "MandrilId",
                table: "Habilidades",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_Mandril_MandrilId",
                table: "Habilidades",
                column: "MandrilId",
                principalTable: "Mandril",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Habilidades_Mandril_MandrilId",
                table: "Habilidades");

            migrationBuilder.AlterColumn<int>(
                name: "MandrilId",
                table: "Habilidades",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_Habilidades_Mandril_MandrilId",
                table: "Habilidades",
                column: "MandrilId",
                principalTable: "Mandril",
                principalColumn: "Id");
        }
    }
}
