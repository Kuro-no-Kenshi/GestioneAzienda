using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class Profession
    {
        public int ProfessionId { get; set; }

        [Required(ErrorMessage = "Profession name is required")]
        public string ProfessionName { get; set; }
    }
}
