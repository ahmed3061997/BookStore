using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStore.Migrations
{
    public partial class AddRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5797fa4b-279c-44d5-ac44-fd242d615bee");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "ae870ca3-31e3-46e5-b400-146e40bc88fa");

            migrationBuilder.CreateTable(
                name: "RefreshToken",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExpiresOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime2", nullable: false),
                    RevokedOn = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshToken", x => new { x.UserId, x.Id });
                    table.ForeignKey(
                        name: "FK_RefreshToken_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2a97f2aa-7c9f-43c4-a080-6628ef54e567", "78c422d5-e664-4852-9eed-9d5b04894a23", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "d521e488-1d6a-46cb-806e-819f35286428", "22265c84-261e-4acf-9514-d94bb239abba", "Visitor", "VISITOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshToken");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2a97f2aa-7c9f-43c4-a080-6628ef54e567");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "d521e488-1d6a-46cb-806e-819f35286428");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "5797fa4b-279c-44d5-ac44-fd242d615bee", "f22a41c8-79c0-4307-97dd-0a4f3db74740", "Visitor", "VISITOR" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "ae870ca3-31e3-46e5-b400-146e40bc88fa", "74cc61e2-05f0-4d5b-99ee-3b962c516609", "Admin", "ADMIN" });
        }
    }
}
