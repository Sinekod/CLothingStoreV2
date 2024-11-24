using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class MoreCommentOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Likes",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Rating",
                table: "Comments",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
                columns: new[] { "DateTime", "Likes", "Rating" },
                values: new object[] { new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1417), 0, 5 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateTime", "Likes", "Rating" },
                values: new object[] { new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1450), 0, 3 });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "Likes", "Rating" },
                values: new object[] { new DateTime(2024, 11, 11, 20, 22, 53, 106, DateTimeKind.Local).AddTicks(1454), 0, 1 });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 11, 20, 22, 53, 266, DateTimeKind.Local).AddTicks(6582));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Likes",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "de83556b-0253-418e-a21c-c1803b0456e6", "AQAAAAIAAYagAAAAEIkKpnu3v/ZyIoE3PZtagN500bNu37AsebIRQS2xc+xL5GPGFPywWeKmz81CRbXdOQ==", "2d612a75-9f25-4d21-8681-3ce40e07db3c" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateTime",
                value: new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4170));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                column: "DateTime",
                value: new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4207));

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                column: "DateTime",
                value: new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4211));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 9, 19, 22, 42, 571, DateTimeKind.Local).AddTicks(1665));
        }
    }
}
