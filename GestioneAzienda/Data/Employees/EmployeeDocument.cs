using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class EmployeeDocument
    {
        public int EmployeeDocumentId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }

        public string FileName { get; set; }
    }
}
