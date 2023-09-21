using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace weapi.Event_.Migrations
{
    /// <inheritdoc />
    public partial class BD2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "CHAR(60)",
                maxLength: 60,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(100)",
                oldMaxLength: 100);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Senha",
                table: "Usuario",
                type: "CHAR(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "CHAR(60)",
                oldMaxLength: 60);
        }
    }
}
