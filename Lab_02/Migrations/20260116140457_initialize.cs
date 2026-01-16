using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Lab_02.Migrations
{
    /// <inheritdoc />
    public partial class initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Authors__3214EC274A3321D9", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Costumers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Costumer__3214EC270DA0E6BC", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Publishe__3214EC27E8DB943B", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Stores__3214EC270BBFD00D", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISBN = table.Column<long>(type: "bigint", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true, defaultValue: "English"),
                    Price = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0),
                    ReleaseDate = table.Column<DateOnly>(type: "date", nullable: true),
                    PublisherID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Books__447D36EB9A512187", x => x.ISBN);
                    table.ForeignKey(
                        name: "FK_PublisherID",
                        column: x => x.PublisherID,
                        principalTable: "Publishers",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateOnly>(type: "date", nullable: true),
                    WorkPlaceID = table.Column<int>(type: "int", nullable: true),
                    Salary = table.Column<double>(type: "float", nullable: true, defaultValue: 0.0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Employee__3214EC27D51EC65A", x => x.ID);
                    table.ForeignKey(
                        name: "FK_WorkPlaceID",
                        column: x => x.WorkPlaceID,
                        principalTable: "Stores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "BookAuthor",
                columns: table => new
                {
                    AuthorID = table.Column<int>(type: "int", nullable: true),
                    ISBN = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_AuthorID",
                        column: x => x.AuthorID,
                        principalTable: "Authors",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_ISBN",
                        column: x => x.ISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN");
                });

            migrationBuilder.CreateTable(
                name: "StockStatus",
                columns: table => new
                {
                    StoreID = table.Column<int>(type: "int", nullable: false),
                    BookID = table.Column<long>(type: "bigint", nullable: false),
                    InStock = table.Column<int>(type: "int", nullable: true, defaultValue: 0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockStatus", x => new { x.StoreID, x.BookID });
                    table.ForeignKey(
                        name: "FK_BookID",
                        column: x => x.BookID,
                        principalTable: "Books",
                        principalColumn: "ISBN");
                    table.ForeignKey(
                        name: "FK_StoreID",
                        column: x => x.StoreID,
                        principalTable: "Stores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeID = table.Column<int>(type: "int", nullable: true),
                    CostumerID = table.Column<int>(type: "int", nullable: false),
                    StoreCode = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Orders__CAC5E742D485D3A0", x => x.OrderNumber);
                    table.ForeignKey(
                        name: "FK_CostumerID",
                        column: x => x.CostumerID,
                        principalTable: "Costumers",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "Employees",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK_StoreCode",
                        column: x => x.StoreCode,
                        principalTable: "Stores",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    OrderNumber = table.Column<int>(type: "int", nullable: false),
                    ItemISBN = table.Column<long>(type: "bigint", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK_ItemISBN",
                        column: x => x.ItemISBN,
                        principalTable: "Books",
                        principalColumn: "ISBN");
                    table.ForeignKey(
                        name: "FK_OrderNumber",
                        column: x => x.OrderNumber,
                        principalTable: "Orders",
                        principalColumn: "OrderNumber");
                });

            migrationBuilder.InsertData(
                table: "Publishers",
                columns: new[] { "ID", "Adress", "Name" },
                values: new object[,]
                {
                    { 1, null, "Allen Unwin" },
                    { 2, null, "Tiptree Book Service" },
                    { 3, null, "Grantham Book Service" },
                    { 4, null, "Little Brown Book Group" },
                    { 5, null, "Headline Publishing Group" },
                    { 6, null, "Penguin Books Ltd." }
                });

            migrationBuilder.InsertData(
                table: "Stores",
                columns: new[] { "ID", "Adress", "Name" },
                values: new object[,]
                {
                    { 1, "Krokegårdsgatan 5, Göteborg", "Göteborg Backaplan" },
                    { 2, "Prästvägen 1, Halmstad", "Halmstad Hallarna" },
                    { 3, "Hantverkaregatan 1, Karlskrona", "Karlskrona" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISBN", "Language", "Price", "PublisherID", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 9780241714348L, "English", 215.0, 6, new DateOnly(2025, 9, 23), "Alchemised" },
                    { 9780349437057L, "English", 142.0, 4, new DateOnly(2024, 11, 19), "Iron Flame" },
                    { 9780349437071L, "English", 210.0, 4, new DateOnly(2025, 1, 21), "Onyx Storm" },
                    { 9781035414505L, "English", 147.0, 5, new DateOnly(2024, 1, 18), "The Book of Azrael" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_AuthorID",
                table: "BookAuthor",
                column: "AuthorID");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthor_ISBN",
                table: "BookAuthor",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Books_PublisherID",
                table: "Books",
                column: "PublisherID");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_WorkPlaceID",
                table: "Employees",
                column: "WorkPlaceID");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ItemISBN",
                table: "OrderItems",
                column: "ItemISBN");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderNumber",
                table: "OrderItems",
                column: "OrderNumber");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CostumerID",
                table: "Orders",
                column: "CostumerID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_EmployeeID",
                table: "Orders",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StoreCode",
                table: "Orders",
                column: "StoreCode");

            migrationBuilder.CreateIndex(
                name: "IX_StockStatus_BookID",
                table: "StockStatus",
                column: "BookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookAuthor");

            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "StockStatus");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Costumers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Stores");
        }
    }
}
