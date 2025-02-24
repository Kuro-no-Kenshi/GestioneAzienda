﻿// <auto-generated />
using System;
using GestioneAzienda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneAzienda.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    partial class CompanyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GestioneAzienda.Data.Company", b =>
                {
                    b.Property<int>("CompanyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CompanyId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CompanyId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Contract", b =>
                {
                    b.Property<int>("ContractId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ContractId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ContractId");

                    b.ToTable("Contracts");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Course", b =>
                {
                    b.Property<int>("CourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseId"));

                    b.Property<int>("CourseDuration")
                        .HasColumnType("int");

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseType")
                        .HasColumnType("int");

                    b.Property<int?>("ProfessionId")
                        .HasColumnType("int");

                    b.HasKey("CourseId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Employee", b =>
                {
                    b.Property<int>("EmployeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeId"));

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("BirthPlace")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("ContractEnd")
                        .HasColumnType("date");

                    b.Property<int>("ContractId")
                        .HasColumnType("int");

                    b.Property<int?>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateOnly?>("CourseStart")
                        .HasColumnType("date");

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("HiringDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionId")
                        .HasColumnType("int");

                    b.Property<int>("ProfessionalLevelId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.EmployeeDocument", b =>
                {
                    b.Property<int>("EmployeeDocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmployeeDocumentId"));

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeDocumentId");

                    b.ToTable("EmployeeDocuments");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.MedicalExamination", b =>
                {
                    b.Property<int>("MedicalExaminationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MedicalExaminationId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateOnly>("MedicalDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MedicalExaminationId");

                    b.HasIndex("EmployeeId");

                    b.ToTable("MedicalExaminations");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Profession", b =>
                {
                    b.Property<int>("ProfessionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionId"));

                    b.Property<string>("ProfessionName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessionId");

                    b.ToTable("Professions");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.ProfessionalLevel", b =>
                {
                    b.Property<int>("ProfessionalLevelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ProfessionalLevelId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProfessionalLevelId");

                    b.ToTable("ProfessionalLevels");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.Supplier", b =>
                {
                    b.Property<int>("SupplierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SupplierId"));

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SupplierId");

                    b.ToTable("Suppliers");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleId"));

                    b.Property<int>("CompanyId")
                        .HasColumnType("int");

                    b.Property<bool>("FinancingSabatini")
                        .HasColumnType("bit");

                    b.Property<bool>("Industry4")
                        .HasColumnType("bit");

                    b.Property<DateOnly>("Inspection")
                        .HasColumnType("date");

                    b.Property<DateOnly>("Insurance")
                        .HasColumnType("date");

                    b.Property<string>("NumberPlate")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("Registration")
                        .HasColumnType("date");

                    b.Property<DateOnly>("RoadTaxes")
                        .HasColumnType("date");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleDocument", b =>
                {
                    b.Property<int>("VehicleDocumentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleDocumentId"));

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("VehicleDocumentId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleDocuments");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleMaintenance", b =>
                {
                    b.Property<int>("VehicleMaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleMaintenanceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("InvoiceDate")
                        .HasColumnType("date");

                    b.Property<string>("InvoiceFileName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoiceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("MaintenanceCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateOnly>("MaintenanceDate")
                        .HasColumnType("date");

                    b.Property<int>("SupplierId")
                        .HasColumnType("int");

                    b.Property<int>("UsageHours")
                        .HasColumnType("int");

                    b.Property<int>("VehicleId")
                        .HasColumnType("int");

                    b.HasKey("VehicleMaintenanceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehicleMaintenances");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleType", b =>
                {
                    b.Property<int>("VehicleTypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleTypeId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("VehicleTypeId");

                    b.ToTable("VehicleTypes");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.MedicalExamination", b =>
                {
                    b.HasOne("GestioneAzienda.Data.Employees.Employee", null)
                        .WithMany("Examination")
                        .HasForeignKey("EmployeeId");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleDocument", b =>
                {
                    b.HasOne("GestioneAzienda.Data.Vehicles.Vehicle", null)
                        .WithMany("Document")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleMaintenance", b =>
                {
                    b.HasOne("GestioneAzienda.Data.Vehicles.Vehicle", null)
                        .WithMany("Maintenance")
                        .HasForeignKey("VehicleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Employee", b =>
                {
                    b.Navigation("Examination");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.Vehicle", b =>
                {
                    b.Navigation("Document");

                    b.Navigation("Maintenance");
                });
#pragma warning restore 612, 618
        }
    }
}
