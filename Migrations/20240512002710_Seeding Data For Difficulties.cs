using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NzApp.Migrations
{
    public partial class SeedingDataForDifficulties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f093595-67c5-4294-a41d-685968cbbcf0"), "Medium" },
                    { new Guid("3ae930c2-1f39-4d24-912f-6c864cf920b6"), "Hard" },
                    { new Guid("581f3df6-bf66-424d-ba58-b14ea2abde2f"), "Easy" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Image", "Name" },
                values: new object[] { new Guid("9b893b06-f42e-4322-ac4b-a4b340649d68"), "https://media.istockphoto.com/id/1437816897/photo/business-woman-manager-or-human-resources-portrait-for-career-success-company-we-are-hiring.jpg?s=612x612&w=is&k=20&c=tw9TuTigzhSlLA_b1Avy0X6GNF9ZFVvgTHIZ9i68Q0I=", null, "ALK" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1f093595-67c5-4294-a41d-685968cbbcf0"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("3ae930c2-1f39-4d24-912f-6c864cf920b6"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("581f3df6-bf66-424d-ba58-b14ea2abde2f"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9b893b06-f42e-4322-ac4b-a4b340649d68"));
        }
    }
}
