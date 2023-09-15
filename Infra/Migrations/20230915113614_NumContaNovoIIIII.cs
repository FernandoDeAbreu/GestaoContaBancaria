using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class NumContaNovoIIIII : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ContaBancaria_Asp.NetUsers_UsuarioId1",
                table: "ContaBancaria");

            migrationBuilder.DropIndex(
                name: "IX_ContaBancaria_UsuarioId1",
                table: "ContaBancaria");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "ContaBancaria");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UsuarioId1",
                table: "ContaBancaria",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_ContaBancaria_UsuarioId1",
                table: "ContaBancaria",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_ContaBancaria_Asp.NetUsers_UsuarioId1",
                table: "ContaBancaria",
                column: "UsuarioId1",
                principalTable: "Asp.NetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
