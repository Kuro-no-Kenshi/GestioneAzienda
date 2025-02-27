using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class Contract
    {
        public int ContractId { get; set; }

        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters.")]
        public string Name { get; set; }

        public bool HasEnd { get; set; }
    }
}
