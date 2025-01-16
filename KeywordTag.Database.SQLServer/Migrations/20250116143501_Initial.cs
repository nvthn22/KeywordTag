using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KeywordTag.Database.SQLServer.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "kt");

            migrationBuilder.CreateTable(
                name: "Checkins",
                schema: "kt",
                columns: table => new
                {
                    code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code_device = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code_keyword = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    checkintime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Checkins", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Devices",
                schema: "kt",
                columns: table => new
                {
                    email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    email_pin = table.Column<int>(type: "int", nullable: false),
                    code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    list_keyword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    list_keyword_tagged = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.email);
                });

            migrationBuilder.CreateTable(
                name: "Keywords",
                schema: "kt",
                columns: table => new
                {
                    code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    confirm = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keywords", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                schema: "kt",
                columns: table => new
                {
                    code = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.code);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                schema: "kt",
                columns: table => new
                {
                    code = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code_keyword = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    code_message = table.Column<int>(type: "int", nullable: false),
                    tagtime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.code);
                });

            migrationBuilder.InsertData(
                schema: "kt",
                table: "Messages",
                columns: new[] { "code", "name" },
                values: new object[,]
                {
                    { 1, "Message 1" },
                    { 2, "Message 2" },
                    { 3, "Message 3" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Checkins",
                schema: "kt");

            migrationBuilder.DropTable(
                name: "Devices",
                schema: "kt");

            migrationBuilder.DropTable(
                name: "Keywords",
                schema: "kt");

            migrationBuilder.DropTable(
                name: "Messages",
                schema: "kt");

            migrationBuilder.DropTable(
                name: "Tags",
                schema: "kt");
        }
    }
}
