﻿// <auto-generated />
using System;
using GestioneAzienda.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GestioneAzienda.Migrations
{
    [DbContext(typeof(CompanyDbContext))]
    [Migration("20250214153034_added_company")]
    partial class added_company
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    b.Property<string>("FiscalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateOnly>("HiringDate")
                        .HasColumnType("date");

                    b.Property<bool>("IsPermanentContract")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProfessionalLevelId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<string>("SerialNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("EmployeeId");

                    b.HasIndex("ProfessionalLevelId");

                    b.HasIndex("RoleId");

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

                    b.ToTable("EmployeesDocument");
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

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
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

                    b.Property<int>("TypeVehicleTypeId")
                        .HasColumnType("int");

                    b.HasKey("VehicleId");

                    b.HasIndex("TypeVehicleTypeId");

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

                    b.ToTable("VehiclesDocument");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.VehicleMaintenance", b =>
                {
                    b.Property<int>("VehicleMaintenanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("VehicleMaintenanceId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

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

                    b.Property<int?>("VehicleId")
                        .HasColumnType("int");

                    b.Property<int>("VehiclesId")
                        .HasColumnType("int");

                    b.HasKey("VehicleMaintenanceId");

                    b.HasIndex("VehicleId");

                    b.ToTable("VehiclesMaintenance");
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

            modelBuilder.Entity("GestioneAzienda.Data.Employees.Employee", b =>
                {
                    b.HasOne("GestioneAzienda.Data.Employees.ProfessionalLevel", "ProfessionalLevel")
                        .WithMany()
                        .HasForeignKey("ProfessionalLevelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GestioneAzienda.Data.Employees.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ProfessionalLevel");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GestioneAzienda.Data.Vehicles.Vehicle", b =>
                {
                    b.HasOne("GestioneAzienda.Data.Vehicles.VehicleType", "Type")
                        .WithMany()
                        .HasForeignKey("TypeVehicleTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
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
                        .HasForeignKey("VehicleId");
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
