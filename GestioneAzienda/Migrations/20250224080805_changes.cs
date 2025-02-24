using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneAzienda.Migrations
{
    /// <inheritdoc />
    public partial class changes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_ProfessionalLevels_ProfessionalLevelId",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_CourseId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProfessionalLevelId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_ProfessionId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DocumentId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleMaintenanceId",
                table: "Vehicles");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VehicleMaintenances",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AddColumn<int>(
                name: "VehicleId",
                table: "VehicleMaintenances",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMaintenances_VehicleId",
                table: "VehicleMaintenances",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleDocuments_VehicleId",
                table: "VehicleDocuments",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleDocuments_Vehicles_VehicleId",
                table: "VehicleDocuments",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMaintenances_Vehicles_VehicleId",
                table: "VehicleMaintenances",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "VehicleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleDocuments_Vehicles_VehicleId",
                table: "VehicleDocuments");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMaintenances_Vehicles_VehicleId",
                table: "VehicleMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_VehicleMaintenances_VehicleId",
                table: "VehicleMaintenances");

            migrationBuilder.DropIndex(
                name: "IX_VehicleDocuments_VehicleId",
                table: "VehicleDocuments");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehicleMaintenances");

            migrationBuilder.AddColumn<string>(
                name: "DocumentId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VehicleMaintenanceId",
                table: "Vehicles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "VehicleMaintenances",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_CourseId",
                table: "Employees",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProfessionalLevelId",
                table: "Employees",
                column: "ProfessionalLevelId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProfessionId",
                table: "Employees",
                column: "ProfessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Courses_CourseId",
                table: "Employees",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "CourseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_ProfessionalLevels_ProfessionalLevelId",
                table: "Employees",
                column: "ProfessionalLevelId",
                principalTable: "ProfessionalLevels",
                principalColumn: "ProfessionalLevelId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Professions_ProfessionId",
                table: "Employees",
                column: "ProfessionId",
                principalTable: "Professions",
                principalColumn: "ProfessionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
