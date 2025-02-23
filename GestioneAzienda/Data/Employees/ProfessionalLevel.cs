using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class ProfessionalLevel
    {
        public int ProfessionalLevelId { get; set; }

        [Required(ErrorMessage = "Professional level name is required")]
        public string Name { get; set; }
    }
}
