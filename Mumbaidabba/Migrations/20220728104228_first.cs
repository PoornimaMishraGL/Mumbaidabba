using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mumbaidabba.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "contact",
                columns: table => new
                {
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contact", x => x.Name);
                });

            migrationBuilder.CreateTable(
                name: "dabbaCategory",
                columns: table => new
                {
                    DabbaCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DabbaCategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DabbaCategoryDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dabbaCategory", x => x.DabbaCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "dabbawala",
                columns: table => new
                {
                    dabbawalaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdProof = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdNumber = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dabbawalaName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dabbawalaDesc = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dabbawala", x => x.dabbawalaId);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mobile = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserType = table.Column<bool>(type: "bit", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "booking",
                columns: table => new
                {
                    BookingDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookingNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DbCtgId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    usrid = table.Column<int>(type: "int", nullable: false),
                    OrderDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_booking", x => x.BookingDetailsId);
                    table.ForeignKey(
                        name: "FK_booking_dabbaCategory_DbCtgId",
                        column: x => x.DbCtgId,
                        principalTable: "dabbaCategory",
                        principalColumn: "DabbaCategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "carts",
                columns: table => new
                {
                    CartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DbCtgId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    usrid = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<float>(type: "real", nullable: false),
                    timeStamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carts", x => x.CartId);
                    table.ForeignKey(
                        name: "FK_carts_dabbaCategory_DbCtgId",
                        column: x => x.DbCtgId,
                        principalTable: "dabbaCategory",
                        principalColumn: "DabbaCategoryId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_carts_user_usrid",
                        column: x => x.usrid,
                        principalTable: "user",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_booking_DbCtgId",
                table: "booking",
                column: "DbCtgId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_DbCtgId",
                table: "carts",
                column: "DbCtgId");

            migrationBuilder.CreateIndex(
                name: "IX_carts_usrid",
                table: "carts",
                column: "usrid");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "booking");

            migrationBuilder.DropTable(
                name: "carts");

            migrationBuilder.DropTable(
                name: "contact");

            migrationBuilder.DropTable(
                name: "dabbawala");

            migrationBuilder.DropTable(
                name: "dabbaCategory");

            migrationBuilder.DropTable(
                name: "user");
        }
    }
}
