using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GestioneAzienda.Migrations
{
    /// <inheritdoc />
    public partial class employee_course_detail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CourseStart",
                table: "Employees");

            migrationBuilder.AddColumn<bool>(
                name: "HasEnd",
                table: "Contracts",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "EmployeeCourseDetails",
                columns: table => new
                {
                    EmployeeCourseDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    CompleteDate = table.Column<DateOnly>(type: "date", nullable: false),
                    RenewalDate = table.Column<DateOnly>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeCourseDetails", x => x.EmployeeCourseDetailId);
                    table.ForeignKey(
                        name: "FK_EmployeeCourseDetails_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeCourseDetails_EmployeeId",
                table: "EmployeeCourseDetails",
                column: "EmployeeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeCourseDetails");

            migrationBuilder.DropColumn(
                name: "HasEnd",
                table: "Contracts");

            migrationBuilder.AddColumn<int>(
                name: "CourseId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateOnly>(
                name: "CourseStart",
                table: "Employees",
                type: "date",
                nullable: true);
        }
    }
}
