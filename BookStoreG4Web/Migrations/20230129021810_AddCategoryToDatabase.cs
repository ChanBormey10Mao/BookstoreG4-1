using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookStoreG4Web.Migrations
{
    /// <inheritdoc />
    public partial class AddCategoryToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsReserved = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CusId = table.Column<string>(name: "Cus_Id", type: "nvarchar(450)", nullable: false),
                    CusName = table.Column<string>(name: "Cus_Name", type: "nvarchar(max)", nullable: false),
                    CusEmail = table.Column<string>(name: "Cus_Email", type: "nvarchar(max)", nullable: false),
                    CusPassword = table.Column<string>(name: "Cus_Password", type: "nvarchar(max)", nullable: false),
                    IsLogin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CusId);
                });

            migrationBuilder.CreateTable(
                name: "Reservations",
                columns: table => new
                {
                    ReserveId = table.Column<int>(name: "Reserve_Id", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BookId = table.Column<string>(name: "Book_Id", type: "nvarchar(max)", nullable: false),
                    CusId = table.Column<string>(name: "Cus_Id", type: "nvarchar(max)", nullable: false),
                    ReservedTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturn = table.Column<bool>(type: "bit", nullable: false),
                    ReturnedTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservations", x => x.ReserveId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Reservations");
        }
    }
}
