using Microsoft.EntityFrameworkCore.Migrations;

namespace SimpleApplicationTestingMvcSkills.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeID = table.Column<int>(name: "Employee ID", type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeName = table.Column<string>(name: "Employee Name", type: "nvarchar(50)", nullable: false),
                    OfficeEmail = table.Column<string>(name: "Office Email", type: "nvarchar(50)", nullable: false),
                    DepartmentID = table.Column<int>(name: "Department ID", type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
