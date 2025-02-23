using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Surname is required.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Surname must contain only letters.")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "BirthDate is required.")]
        public DateOnly BirthDate { get; set; }

        [Required(ErrorMessage = "BirthPlace is required.")]
        [RegularExpression(@"^[a-zA-ZÀ-ÿ\s'-]+ \([A-Z]{2}\)$", ErrorMessage = "BirthPlace must be in the format 'City (XX)', where XX is the province code.")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "FiscalCode is required.")]
        [RegularExpression(@"^[A-Z]{6}[0-9]{2}[A-Z][0-9]{2}[A-Z][0-9]{3}[A-Z]$", ErrorMessage = "FiscalCode must be a valid Italian fiscal code.")]
        public string FiscalCode { get; set; }

        [Required(ErrorMessage = "HiringDate is required.")]
        public DateOnly HiringDate { get; set; }

        [Required(ErrorMessage = "IsPermanentContract is required.")]
        public bool IsPermanentContract { get; set; }

        [Required(ErrorMessage = "SerialNumber is required.")]
        public string SerialNumber { get; set; }

        public int ProfessionId { get; set; }

        public int CourseId { get; set; }

        public int ProfessionalLevelId { get; set; }

        public DateOnly CourseStart { get; set; }

        public int CompanyId { get; set; }
    }
}
