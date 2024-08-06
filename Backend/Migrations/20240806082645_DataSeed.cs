using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RecruitmentTask.Migrations
{
    /// <inheritdoc />
    public partial class DataSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Contact",
                columns: new[] { "Id", "BirthDate", "Category", "Email", "FirstName", "LastName", "Password", "PhoneNumber", "SubCategory" },
                values: new object[,]
                {
                    { 1, new DateTime(1957, 2, 6, 3, 25, 48, 0, DateTimeKind.Utc), "Personal", "wandacarter@yahoo.com", "Robin", "Crane", "&jNraKMIa5", "001-265-432-9150", "" },
                    { 2, new DateTime(1950, 5, 5, 14, 37, 12, 0, DateTimeKind.Utc), "Other", "rgreen@gmail.com", "Monique", "Moran", "(4#GAV_hYb", "0118807176", "civil" },
                    { 3, new DateTime(1958, 2, 13, 22, 49, 1, 0, DateTimeKind.Utc), "Business", "mgoodman@mccall.com", "Christine", "Pena", "U9G5v(tt_l", "001-516-329-1903x568", "Boss" },
                    { 4, new DateTime(1928, 11, 22, 9, 15, 30, 0, DateTimeKind.Utc), "Business", "howardmichele@hotmail.com", "Benjamin", "Nichols", "&9U*Soq(Xe", "805-736-4268x6968", "Client" },
                    { 5, new DateTime(1938, 3, 17, 11, 55, 44, 0, DateTimeKind.Utc), "Other", "robertbraun@gmail.com", "Jodi", "Mclean", "0(08zLCd7H", "9085445089", "song" },
                    { 6, new DateTime(2017, 11, 15, 7, 42, 22, 0, DateTimeKind.Utc), "Personal", "charles97@hotmail.com", "Thomas", "Tyler", "&2CyModfq2", "837.087.5302x942", "" },
                    { 7, new DateTime(2010, 9, 20, 19, 30, 0, 0, DateTimeKind.Utc), "Business", "brenda52@hotmail.com", "Michael", "Williams", "*99$c8Keub", "923.241.4303x53037", "Client" },
                    { 8, new DateTime(1942, 3, 1, 23, 11, 5, 0, DateTimeKind.Utc), "Other", "johnsmary@everett.com", "Bradley", "Riley", "%fPMZco*@3", "001-995-809-8220x270", "hit" },
                    { 9, new DateTime(2010, 10, 19, 6, 22, 35, 0, DateTimeKind.Utc), "Business", "owilson@hughes-martinez.com", "Jacob", "Coleman", "*@y119L42q", "+1-195-972-2281x7606", "Boss" },
                    { 10, new DateTime(1923, 2, 28, 15, 18, 59, 0, DateTimeKind.Utc), "Other", "kthornton@yahoo.com", "Lindsay", "Gray", "&S1BX9gsH8", "245-124-6602x231", "movement" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                table: "Contact",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Contact",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
