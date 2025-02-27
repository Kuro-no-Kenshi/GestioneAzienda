using Microsoft.EntityFrameworkCore;
using GestioneAzienda.Data.Employees;
using GestioneAzienda.Data.Vehicles;

namespace GestioneAzienda.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options) { }

        public DbSet<Contract> Contracts { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeCourseDetail> EmployeeCourseDetails { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<MedicalExamination> MedicalExaminations { get; set; }
        public DbSet<Profession> Professions { get; set; }
        public DbSet<ProfessionalLevel> ProfessionalLevels { get; set; }

        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<VehicleDocument> VehicleDocuments { get; set; }
        public DbSet<VehicleMaintenance> VehicleMaintenances { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }

        public DbSet<Company> Companies { get; set; }

    }
}
