using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClothingStoreAgain.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c6c3988d-9285-4569-bb8a-9eff133165da", "c6c3988d-9285-4569-bb8a-9eff133165da", "Admin", "ADMIN" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5b6a84bc-2fcd-4291-b32f-85b1a4254f1b", "AQAAAAIAAYagAAAAEFx7imR8TPtiD610keMiNYNgJ7WfF6ubhtlhIOSXyUdn+MO92Uexw7MkrNzYTGdu1g==", "e4b82aa7-e030-4716-b971-a58a30800d64" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 11, 6, 23, 13, 14, 569, DateTimeKind.Local).AddTicks(4002));

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "c6c3988d-9285-4569-bb8a-9eff133165da", "e484920a-cb22-45bf-9ace-843a04361194" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "c6c3988d-9285-4569-bb8a-9eff133165da", "e484920a-cb22-45bf-9ace-843a04361194" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "c6c3988d-9285-4569-bb8a-9eff133165da");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "e484920a-cb22-45bf-9ace-843a04361194",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "15b4b648-3d06-4162-8340-0aac85ea7a12", "AQAAAAIAAYagAAAAEHPby/CP1AY9zowRxNlcOyeJukcKuyJZkfqIEyRmGEfFpyFpnINjDhSL3c0vtciTdQ==", "a058a75f-4612-4fae-9065-5b83474aba05" });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: 1,
                column: "DateWhenOrdered",
                value: new DateTime(2024, 10, 20, 21, 14, 58, 403, DateTimeKind.Local).AddTicks(518));
        }
    }
}
