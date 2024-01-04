using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BethanysPieShopHRM.Api.Migrations
{
    public partial class n : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "jvalue",
                table: "JobCategories");

            migrationBuilder.DropColumn(
                name: "cvalue",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "jvalue",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "cvalue",
                table: "Countries");

            migrationBuilder.AddColumn<string>(
                name: "JobCategoryName",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "JobCategoryName",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Employees");

            migrationBuilder.AddColumn<string>(
                name: "jvalue",
                table: "JobCategories",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cvalue",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "jvalue",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "cvalue",
                table: "Countries",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 1,
                column: "cvalue",
                value: "Belgium");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 2,
                column: "cvalue",
                value: "Germany");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 3,
                column: "cvalue",
                value: "Netherlands");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 4,
                column: "cvalue",
                value: "USA");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 5,
                column: "cvalue",
                value: "Japan");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 6,
                column: "cvalue",
                value: "China");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 7,
                column: "cvalue",
                value: "UK");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 8,
                column: "cvalue",
                value: "France");

            migrationBuilder.UpdateData(
                table: "Countries",
                keyColumn: "CountryId",
                keyValue: 9,
                column: "cvalue",
                value: "Brazil");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "cvalue", "jvalue" },
                values: new object[] { "Belgium", "Pie research" });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "cvalue", "jvalue" },
                values: new object[] { "Belgium", "Pie research" });

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 1,
                column: "jvalue",
                value: "Pie research");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 2,
                column: "jvalue",
                value: "Sales");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 3,
                column: "jvalue",
                value: "Management");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 4,
                column: "jvalue",
                value: "Store staff");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 5,
                column: "jvalue",
                value: "Finance");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 6,
                column: "jvalue",
                value: "QA");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 7,
                column: "jvalue",
                value: "IT");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 8,
                column: "jvalue",
                value: "Cleaning");

            migrationBuilder.UpdateData(
                table: "JobCategories",
                keyColumn: "JobCategoryId",
                keyValue: 9,
                column: "jvalue",
                value: "Bakery");
        }
    }
}
