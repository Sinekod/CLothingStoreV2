using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedOrders : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_DeliveryToAddresses_DeliveryToAddressId",
                table: "Orders");
            
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_ProductItems_ProductItemId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "DeliveryToAddresses");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DeliveryToAddressId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_ProductItemId",
                table: "Orders");

            migrationBuilder.DeleteData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "DeliveryToAddressId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ProductItemId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Tottal",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "DateWhenOrdered",
                table: "Orders",
                newName: "OrderedDate");

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PaymentMethod",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ShippimgAdress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    ProductItemId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrderItems_ProductItems_ProductItemId",
                        column: x => x.ProductItemId,
                        principalTable: "ProductItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "12cc227d-9f7e-4a97-a972-24ea8751a8d6", "AQAAAAIAAYagAAAAEG1kuzHQhguRxFuM8KM1GZOW+JA9ePbUUf2CJOlVLE5IjsgFCR4k4MOvd4A1KlGJew==", "23ebf81d-b9da-49e7-939f-fa0126ecac10" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 27, 16, 46, 29, 516, DateTimeKind.Local).AddTicks(8275));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 11, 27, 16, 46, 29, 516, DateTimeKind.Local).AddTicks(8322));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 11, 27, 16, 46, 29, 516, DateTimeKind.Local).AddTicks(8327));

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_ProductItemId",
                table: "OrderItems",
                column: "ProductItemId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PaymentMethod",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "ShippimgAdress",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "OrderedDate",
                table: "Orders",
                newName: "DateWhenOrdered");

            migrationBuilder.AddColumn<int>(
                name: "DeliveryToAddressId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductItemId",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Tottal",
                table: "Orders",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "DeliveryToAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "int", nullable: false),
                    CityName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DeliveryToAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DeliveryToAddresses_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "cf1be300-fd94-4438-af67-65e5c40ebaf5", "AQAAAAIAAYagAAAAENqvCq63gyfHi86XAUF8N4YEOlDZUZCOSbJ8s+cltTgzdqnyaLNp/38nNWg6ALYLqw==", "0d2a311a-2be3-4337-a902-668c703a12a2" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 18, 22, 34, 16, 737, DateTimeKind.Local).AddTicks(9353));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 11, 18, 22, 34, 16, 737, DateTimeKind.Local).AddTicks(9385));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 11, 18, 22, 34, 16, 737, DateTimeKind.Local).AddTicks(9388));

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Id", "DateWhenOrdered", "DeliveryToAddressId", "ProductItemId", "Quantity", "Tottal", "UserId" },
                values: new object[] { 1, new DateTime(2024, 11, 18, 22, 34, 16, 893, DateTimeKind.Local).AddTicks(2399), null, 1, 2, 0m, "e484920a-cb22-45bf-9ace-843a04361194" });

            migrationBuilder.InsertData(
                table: "DeliveryToAddresses",
                columns: new[] { "Id", "CityName", "Number", "OrderId", "PhoneNumber", "StreetName" },
                values: new object[] { 1, "Sofia", 5, 1, "089 236 7845", "Ivan Vazov" });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DeliveryToAddressId",
                table: "Orders",
                column: "DeliveryToAddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_ProductItemId",
                table: "Orders",
                column: "ProductItemId");

            migrationBuilder.CreateIndex(
                name: "IX_DeliveryToAddresses_OrderId",
                table: "DeliveryToAddresses",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_DeliveryToAddresses_DeliveryToAddressId",
                table: "Orders",
                column: "DeliveryToAddressId",
                principalTable: "DeliveryToAddresses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_ProductItems_ProductItemId",
                table: "Orders",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
