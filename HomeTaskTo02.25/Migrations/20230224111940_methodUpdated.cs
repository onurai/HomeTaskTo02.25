using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HomeTaskTo02._25.Migrations
{
    public partial class methodUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedDate",
                table: "BooksTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 15, 19, 40, 152, DateTimeKind.Local).AddTicks(457),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 24, 15, 14, 24, 872, DateTimeKind.Local).AddTicks(743));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "PurchasedDate",
                table: "BooksTable",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 2, 24, 15, 14, 24, 872, DateTimeKind.Local).AddTicks(743),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 2, 24, 15, 19, 40, 152, DateTimeKind.Local).AddTicks(457));
        }
    }
}
