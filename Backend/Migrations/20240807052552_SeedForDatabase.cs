using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentTask.Migrations
{
    /// <inheritdoc />
    public partial class SeedForDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Personal" },
                    { 2, "Business" },
                    { 3, "Other" }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[] { 1, "test@test.com", "$2a$11$CcoleKoLGIDchqqPt3P6i.mQFy4X/UilynKTnOIbTt8zXtuVYVyae", "admin" });

            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "BirthDate", "Category", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "SubCategory", "UserId" },
                values: new object[,]
                {
                    { 1, new DateTime(1957, 2, 6, 3, 25, 48, 0, DateTimeKind.Utc), "Personal", "wandacarter@yahoo.com", "Robin", "Crane", "&jNraKMIa5", "001-265-432-9150", "", 1 },
                    { 2, new DateTime(1950, 5, 5, 14, 37, 12, 0, DateTimeKind.Utc), "Other", "rgreen@gmail.com", "Monique", "Moran", "(4#GAV_hYb", "0118807176", "civil", 1 },
                    { 3, new DateTime(1958, 2, 13, 22, 49, 1, 0, DateTimeKind.Utc), "Business", "mgoodman@mccall.com", "Christine", "Pena", "U9G5v(tt_l", "001-516-329-1903x568", "Boss", 1 },
                    { 4, new DateTime(1928, 11, 22, 9, 15, 30, 0, DateTimeKind.Utc), "Business", "howardmichele@hotmail.com", "Benjamin", "Nichols", "&9U*Soq(Xe", "805-736-4268x6968", "Client", 1 }
                });

            migrationBuilder.InsertData(
                table: "SubCategory",
                columns: new[] { "Id", "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, 2, "Boss" },
                    { 2, 2, "Client" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SubCategory",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
