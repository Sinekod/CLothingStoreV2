using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Added_something : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Size",
                table: "ProductItems");

            migrationBuilder.AddColumn<int>(
                name: "SizeId",
                table: "ProductItems",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Sizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sizes", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c51398-fd26-4f34-ae3d-6c7e898089b0", "AQAAAAIAAYagAAAAEFtmFqxtwHwkdVihi7kBDtMVCd0vJvqslGOKb6BBMdlj0Rs4t6YcJJ67BfPo4jJ2ow==", "f32b785f-9ea9-4325-b675-316d5f635d48" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 10, 15, 23, 19, 5, 375, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "SizeId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "SizeId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "SizeId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "NikeSocks");

            migrationBuilder.InsertData(
                table: "Sizes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "L" },
                    { 2, "M" },
                    { 3, "S" },
                    { 4, "42" },
                    { 5, "44" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems",
                column: "SizeId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems",
                column: "SizeId",
                principalTable: "Sizes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductItems_Sizes_SizeId",
                table: "ProductItems");

            migrationBuilder.DropTable(
                name: "Sizes");

            migrationBuilder.DropIndex(
                name: "IX_ProductItems_SizeId",
                table: "ProductItems");

            migrationBuilder.DropColumn(
                name: "SizeId",
                table: "ProductItems");

            migrationBuilder.AddColumn<string>(
                name: "Size",
                table: "ProductItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2b58fce6-d9ad-4034-bac8-4951f0ab343e", "AQAAAAIAAYagAAAAEGbwj15VvpkmJo2o5TARhYWYk4+Mb5Cb7u0TmcdaWVx8THS2aWTzApUJMasB7lMnvQ==", "525d2717-e645-4da4-b6da-368b9d3d75bd" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 10, 8, 22, 30, 58, 880, DateTimeKind.Local).AddTicks(2942));

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 1,
                column: "Size",
                value: "L");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 2,
                column: "Size",
                value: "42");

            migrationBuilder.UpdateData(
                table: "ProductItems",
                keyColumn: "Id",
                keyValue: 3,
                column: "Size",
                value: "40");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Product3");
        }
    }
}
