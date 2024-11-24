using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class RestrictedCommentDeleteion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductItems_ProductItemId",
                table: "Comments");

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

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 18, 22, 34, 16, 893, DateTimeKind.Local).AddTicks(2399));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductItems_ProductItemId",
                table: "Comments",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_ProductItems_ProductItemId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "658b9a0b-f31e-4ec2-85ac-b6460c2cec14", "AQAAAAIAAYagAAAAEK9vyPQfJ+/rsHVQEybHw23NDwBaSIYfzuyARC5ZMMS4rGeUlYmoNb03ee7Pxd9QDg==", "67e4ce74-93ef-4b28-ae19-da66f05966e4" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1417));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1450));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1454));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 11, 20, 22, 53, 266, DateTimeKind.Local).AddTicks(6582));

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_ProductItems_ProductItemId",
                table: "Comments",
                column: "ProductItemId",
                principalTable: "ProductItems",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
