using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class Coments : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateTime",
                table: "Comments",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Comments",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

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
                columns: new[] { "DateTime", "ProductItemId", "UserId" },
                values: new object[] { new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4170), 4, "e484920a-cb22-45bf-9ace-843a04361194" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateTime", "UserId" },
                values: new object[] { new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4207), "e484920a-cb22-45bf-9ace-843a04361194" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "DateTime", "UserId" },
                values: new object[] { new DateTime(2024, 11, 9, 19, 22, 42, 301, DateTimeKind.Local).AddTicks(4211), "e484920a-cb22-45bf-9ace-843a04361194" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 9, 19, 22, 42, 571, DateTimeKind.Local).AddTicks(1665));

            migrationBuilder.CreateIndex(
                name: "IX_Comments_UserId",
                table: "Comments",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_AspNetUsers_UserId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_UserId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "DateTime",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Comments");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b6a84bc-2fcd-4291-b32f-85b1a4254f1b", "AQAAAAIAAYagAAAAEFx7imR8TPtiD610keMiNYNgJ7WfF6ubhtlhIOSXyUdn+MO92Uexw7MkrNzYTGdu1g==", "e4b82aa7-e030-4716-b971-a58a30800d64" });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "Id",
                keyValue: 1,
                column: "ProductItemId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 6, 23, 13, 14, 569, DateTimeKind.Local).AddTicks(4002));
        }
    }
}
