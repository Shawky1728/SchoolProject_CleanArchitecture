using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SchoolProject.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedDefaultUsersAndRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "IsDeleted", "Name", "NormalizedName" },
                values: new object[] { "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2", "d9b1c8e75a3e4c9f9b2e1a2b3c4d5e6f", false, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "Address", "City", "ConcurrencyStamp", "Country", "Email", "EmailConfirmed", "IsDeleted", "LockoutEnabled", "LockoutEnd", "NameAr", "NameEn", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2", 0, null, null, "d9b1c8e75a3e4c9f9b2e1a2b3c4d5e6f", null, "admin@gmail.com", true, false, false, null, "مدير النظام", "System Administrator", "ADMIN@GMAIL.COM", "ADMIN@GMAIL.COM", "AQAAAAIAAYagAAAAEIh3rwDPaB43mBoNndvyFPnnsTVatUDP9R5FPwEGOr/imKzbYhKVsr8pIxVQK/c+nw==", null, false, "a81c03643bd74bdc831d9ad20610a58b", false, "admin@gmail.com" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[] { "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2", "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "7d671dfa-c431-4f2c-8a27-3c1c7553eaf2");
        }
    }
}
