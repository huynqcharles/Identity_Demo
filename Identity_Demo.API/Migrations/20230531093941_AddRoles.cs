using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity_Demo.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0f236076-a263-44b0-b032-a77a5a143f67", "50141a3b-9bf3-498e-b73b-16e6d4639fd3", "User", "USER" },
                    { "19bb6714-80e4-44fd-ad9b-b9a2956c592f", "d054713e-b0ef-4510-8886-1df73c9f9db1", "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0f236076-a263-44b0-b032-a77a5a143f67");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "19bb6714-80e4-44fd-ad9b-b9a2956c592f");
        }
    }
}
