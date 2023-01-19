using Microsoft.EntityFrameworkCore.Migrations;

namespace recruitmentmanagementsystem.Migrations
{
    public partial class firest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "04ef5c94-192d-402d-83ca-455742e7a9d2");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "5866facb-da77-4641-ba9e-35ababbc9799");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bf3fc2bd-15c4-4cc5-ba1a-c0e190716ccc");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "17a52fbc-cded-4a7e-b114-59af0a30122c", "f5e2255b-9ea7-4538-bf20-327df68c5434", "SUPER ADMIN", "SUPER ADMIN" },
                    { "8d4d0fde-9c2d-4203-acd4-fa7026b74de8", "0bebf673-53ae-474c-912e-7865d100e6b5", "HR", "HR" },
                    { "a7057060-bfeb-40ac-b3af-1f3be50752b5", "45f22397-10dd-47ea-b929-145ac84c86ce", "TALENT REQUISITION", "TALENT REQUISITION" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "17a52fbc-cded-4a7e-b114-59af0a30122c");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "8d4d0fde-9c2d-4203-acd4-fa7026b74de8");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "a7057060-bfeb-40ac-b3af-1f3be50752b5");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "5866facb-da77-4641-ba9e-35ababbc9799", "4401dbd4-9f22-47bb-b983-45f0989f6f5f", "SUPER ADMIN", "SUPER ADMIN" },
                    { "04ef5c94-192d-402d-83ca-455742e7a9d2", "1ef19cfa-e751-4637-a32d-7469f62ccba2", "HR", "HR" },
                    { "bf3fc2bd-15c4-4cc5-ba1a-c0e190716ccc", "26d28009-7131-4279-8828-a48718c1e9ba", "TALENT REQUISITION", "TALENT REQUISITION" }
                });
        }
    }
}
