using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApplicationTestingMvcSkills.Migrations
{
    public partial class SeedingInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Employee ID", "Department ID", "Office Email", "Employee Name" },
                values: new object[,]
                {
                    { 1, 1, "iamtuseTheProgrammer@iamtuse.com", "iamtuse" },
                    { 2, 3, "wonkulahp@iamtuse.com", "Precious K Wonkulah" },
                    { 3, 4, "darious@iamtuse.com", "Darious F Wonkulah" },
                    { 4, 2, "dacious@iamtuse.com", "Dacious F Wonkulah" },
                    { 5, 3, "dad@iamtuse.com", "Dad S Wonkulah Sr" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee ID",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee ID",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee ID",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee ID",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Employee ID",
                keyValue: 5);
        }
    }
}
