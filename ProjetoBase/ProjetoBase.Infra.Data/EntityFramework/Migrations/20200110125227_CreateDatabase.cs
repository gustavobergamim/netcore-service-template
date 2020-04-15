using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoBase.Infra.Data.EntityFramework.Migrations
{
    public partial class CreateDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "usuario",
                schema: "dbo",
                columns: table => new
                {
                    cd_usuario = table.Column<Guid>(nullable: false),
                    nm_usuario = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.cd_usuario);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "usuario",
                schema: "dbo");
        }
    }
}
