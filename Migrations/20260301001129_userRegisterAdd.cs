using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaEscolar.API.Migrations
{
    /// <inheritdoc />
    public partial class userRegisterAdd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Telefone",
                table: "Users",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Telefone",
                table: "Users");
        }
    }
}
