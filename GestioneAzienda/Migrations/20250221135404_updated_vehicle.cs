using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneAzienda.Migrations
{
    /// <inheritdoc />
    public partial class updated_vehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeVehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesDocument_Vehicles_VehicleId",
                table: "VehiclesDocument");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesMaintenance_Vehicles_VehicleId",
                table: "VehiclesMaintenance");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_TypeVehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclesMaintenance",
                table: "VehiclesMaintenance");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesMaintenance_VehicleId",
                table: "VehiclesMaintenance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehiclesDocument",
                table: "VehiclesDocument");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesDocument_VehicleId",
                table: "VehiclesDocument");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeesDocument",
                table: "EmployeesDocument");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehiclesMaintenance");

            migrationBuilder.RenameTable(
                name: "VehiclesMaintenance",
                newName: "VehicleMaintenances");

            migrationBuilder.RenameTable(
                name: "VehiclesDocument",
                newName: "VehicleDocuments");

            migrationBuilder.RenameTable(
                name: "EmployeesDocument",
                newName: "EmployeeDocuments");

            migrationBuilder.RenameColumn(
                name: "TypeVehicleTypeId",
                table: "Vehicles",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "Employees",
                newName: "ProfessionId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                newName: "IX_Employees_ProfessionId");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "VehicleMaintenanceId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CourseStart",
                table: "Employees",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleMaintenances",
                table: "VehicleMaintenances",
                column: "VehicleMaintenanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehicleDocuments",
                table: "VehicleDocuments",
                column: "VehicleDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeDocuments",
                table: "EmployeeDocuments",
                column: "EmployeeDocumentId");

            migrationBuilder.CreateTable(
                name: "Companies",
                columns: table => new
                {
                    CompanyId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyId);
                });

            migrationBuilder.CreateTable(
                name: "Courses",
                columns: table => new
                {
                    CourseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CourseDuration = table.Column<int>(type: "int", nullable: false),
                    CourseType = table.Column<int>(type: "int", nullable: false),
                    ProfessionId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Courses", x => x.CourseId);
                });

            migrationBuilder.CreateTable(
                name: "Professions",
                columns: table => new
                {
                    ProfessionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProfessionName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professions", x => x.ProfessionId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CourseId",
                table: "Employees",
                column: "CourseId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees");

            migrationBuilder.DropTable(
                name: "Companies");

            migrationBuilder.DropTable(
                name: "Courses");

            migrationBuilder.DropTable(
                name: "Professions");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CourseId",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleMaintenances",
                table: "VehicleMaintenances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VehicleDocuments",
                table: "VehicleDocuments");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeDocuments",
                table: "EmployeeDocuments");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleMaintenanceId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CourseStart",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "VehicleMaintenances",
                newName: "VehiclesMaintenance");

            migrationBuilder.RenameTable(
                name: "VehicleDocuments",
                newName: "VehiclesDocument");

            migrationBuilder.RenameTable(
                name: "EmployeeDocuments",
                newName: "EmployeesDocument");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Vehicles",
                newName: "TypeVehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "ProfessionId",
                table: "Employees",
                newName: "RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_ProfessionId",
                table: "Employees",
                newName: "IX_Employees_RoleId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehiclesMaintenance",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclesMaintenance",
                table: "VehiclesMaintenance",
                column: "VehicleMaintenanceId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VehiclesDocument",
                table: "VehiclesDocument",
                column: "VehicleDocumentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeesDocument",
                table: "EmployeesDocument",
                column: "EmployeeDocumentId");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeVehicleTypeId",
                table: "Vehicles",
                column: "TypeVehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesMaintenance_VehicleId",
                table: "VehiclesMaintenance",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDocument_VehicleId",
                table: "VehiclesDocument",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Roles_RoleId",
                table: "Employees",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_TypeVehicleTypeId",
                table: "Vehicles",
                column: "TypeVehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "VehicleTypeId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesDocument_Vehicles_VehicleId",
                table: "VehiclesDocument",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesMaintenance_Vehicles_VehicleId",
                table: "VehiclesMaintenance",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }
    }
}
