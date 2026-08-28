using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedingPermissions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoleClaims",
                columns: new[] { "Id", "ClaimType", "ClaimValue", "RoleId" },
                values: new object[,]
                {
                    { 1, "Permissions", "students.create", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 2, "Permissions", "students.update", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 3, "Permissions", "students.delete", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 4, "Permissions", "students.read", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 5, "Permissions", "departments.create", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 6, "Permissions", "departments.update", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 7, "Permissions", "departments.delete", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" },
                    { 8, "Permissions", "departments.read", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[] { "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2", "e9b1c8e75a3e4c9f9b2e1a2b3c4d5e6f", false, "Member", "MEMBER" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NameAr", "NameEn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2", 0, null, null, "e9b1c8e75a3e4c9f9b2e1a2b3c4d5e6f", null, "member@gmail.com", true, false, false, null, "عضو النظام", "System Member", "MEMBER@GMAIL.COM", "MEMBER@GMAIL.COM", "AQAAAAIAAYagAAAAEIh3rwDPaB43mBoNndvyFPnnsTVatUDP9R5FPwEGOr/imKzbYhKVsr8pIxVQK/c+nw==", null, false, "b81c03643bd74bdc831d9ad20610a58b", false, "member@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2", "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "AspNetRoleClaims",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2", "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e671dfa-c431-4f2c-8a27-3c1c7553eaf2");
        }
    }
}
