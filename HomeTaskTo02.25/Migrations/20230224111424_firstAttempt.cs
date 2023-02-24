using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTaskTo02._25.Migrations
{
    public partial class firstAttempt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AuthorsTable",
                columns: table => new
                {
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorsTable", x => x.AuthorId);
                });

            migrationBuilder.CreateTable(
                name: "BooksTable",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PurchasedDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(2023, 2, 24, 15, 14, 24, 872, DateTimeKind.Local).AddTicks(743)),
                    AuthorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BooksTable", x => x.BookId);
                    table.ForeignKey(
                        name: "FK_BooksTable_AuthorsTable_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AuthorsTable",
                        principalColumn: "AuthorId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorsTable_AuthorId",
                table: "AuthorsTable",
                column: "AuthorId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BooksTable_AuthorId",
                table: "BooksTable",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_BooksTable_BookId",
                table: "BooksTable",
                column: "BookId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BooksTable");

            migrationBuilder.DropTable(
                name: "AuthorsTable");
        }
    }
}
