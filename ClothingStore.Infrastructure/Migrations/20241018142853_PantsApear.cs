using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class PantsApear : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Genders",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "1a6f27cf-d2c0-49c8-82d7-16f595ed0b73", "AQAAAAIAAYagAAAAEB8YHZUbjmSrq8cPtu7TC+2E7xT//bU0bEHjx6Z3TuSWwK4Ugmd9OM2ov4PjHTZLOA==", "7fcf7043-533a-4b84-bcec-9952b23b6a30" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenderId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 10, 18, 17, 28, 53, 119, DateTimeKind.Local).AddTicks(6246));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "44c51398-fd26-4f34-ae3d-6c7e898089b0", "AQAAAAIAAYagAAAAEFtmFqxtwHwkdVihi7kBDtMVCd0vJvqslGOKb6BBMdlj0Rs4t6YcJJ67BfPo4jJ2ow==", "f32b785f-9ea9-4325-b675-316d5f635d48" });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1,
                column: "GenderId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Genders",
                columns: new[] { "Id", "Name" },
                values: new object[] { 3, "Bisexual" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 10, 15, 23, 19, 5, 375, DateTimeKind.Local).AddTicks(5765));
        }
    }
}
