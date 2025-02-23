using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneAzienda.Migrations
{
    /// <inheritdoc />
    public partial class added_company : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Invoice",
                table: "VehiclesMaintenance");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "VehiclesDocument");

            migrationBuilder.DropColumn(
                name: "Document",
                table: "EmployeesDocument");

            migrationBuilder.RenameColumn(
                name: "Company",
                table: "Vehicles",
                newName: "CompanyId");

            migrationBuilder.AlterColumn<decimal>(
                name: "MaintenanceCost",
                table: "VehiclesMaintenance",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VehiclesMaintenance",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceFileName",
                table: "VehiclesMaintenance",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "VehiclesDocument",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FileName",
                table: "EmployeesDocument",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceFileName",
                table: "VehiclesMaintenance");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "VehiclesDocument");

            migrationBuilder.DropColumn(
                name: "FileName",
                table: "EmployeesDocument");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "CompanyId",
                table: "Vehicles",
                newName: "Company");

            migrationBuilder.AlterColumn<double>(
                name: "MaintenanceCost",
                table: "VehiclesMaintenance",
                type: "float",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VehiclesMaintenance",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<byte[]>(
                name: "Invoice",
                table: "VehiclesMaintenance",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                table: "VehiclesDocument",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "Document",
                table: "EmployeesDocument",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }
    }
}
