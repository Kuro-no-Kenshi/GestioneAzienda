using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneAzienda.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeesDocument",
                columns: table => new
                {
                    EmployeeDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeesDocument", x => x.EmployeeDocumentId);
                });

            migrationBuilder.CreateTable(
                name: "ProfessionalLevels",
                columns: table => new
                {
                    ProfessionalLevelId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProfessionalLevels", x => x.ProfessionalLevelId);
                });

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

            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupplierId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupplierId);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    VehicleTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.VehicleTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BirthDate = table.Column<DateOnly>(type: "date", nullable: false),
                    BirthPlace = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FiscalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HiringDate = table.Column<DateOnly>(type: "date", nullable: false),
                    IsPermanentContract = table.Column<bool>(type: "bit", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProfessionalLevelId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_ProfessionalLevels_ProfessionalLevelId",
                        column: x => x.ProfessionalLevelId,
                        principalTable: "ProfessionalLevels",
                        principalColumn: "ProfessionalLevelId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberPlate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SerialNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Registration = table.Column<DateOnly>(type: "date", nullable: false),
                    Industry4 = table.Column<bool>(type: "bit", nullable: false),
                    FinancingSabatini = table.Column<bool>(type: "bit", nullable: false),
                    TypeVehicleTypeId = table.Column<int>(type: "int", nullable: false),
                    Inspection = table.Column<DateOnly>(type: "date", nullable: false),
                    RoadTaxes = table.Column<DateOnly>(type: "date", nullable: false),
                    Insurance = table.Column<DateOnly>(type: "date", nullable: false),
                    Company = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                    table.ForeignKey(
                        name: "FK_Vehicles_VehicleTypes_TypeVehicleTypeId",
                        column: x => x.TypeVehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "VehicleTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesDocument",
                columns: table => new
                {
                    VehicleDocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Document = table.Column<byte[]>(type: "varbinary(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesDocument", x => x.VehicleDocumentId);
                    table.ForeignKey(
                        name: "FK_VehiclesDocument_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehiclesMaintenance",
                columns: table => new
                {
                    VehicleMaintenanceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehiclesId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    UsageHours = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InvoiceDate = table.Column<DateOnly>(type: "date", nullable: false),
                    SupplierId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceCost = table.Column<double>(type: "float", nullable: false),
                    Invoice = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    VehicleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehiclesMaintenance", x => x.VehicleMaintenanceId);
                    table.ForeignKey(
                        name: "FK_VehiclesMaintenance_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "VehicleId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProfessionalLevelId",
                table: "Employees",
                column: "ProfessionalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_TypeVehicleTypeId",
                table: "Vehicles",
                column: "TypeVehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDocument_VehicleId",
                table: "VehiclesDocument",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesMaintenance_VehicleId",
                table: "VehiclesMaintenance",
                column: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "EmployeesDocument");

            migrationBuilder.DropTable(
                name: "Suppliers");

            migrationBuilder.DropTable(
                name: "VehiclesDocument");

            migrationBuilder.DropTable(
                name: "VehiclesMaintenance");

            migrationBuilder.DropTable(
                name: "ProfessionalLevels");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Vehicles");

            migrationBuilder.DropTable(
                name: "VehicleTypes");
        }
    }
}
