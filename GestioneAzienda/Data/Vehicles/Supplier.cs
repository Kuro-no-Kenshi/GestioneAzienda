using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Vehicles
{
    public class Supplier
    {
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "CompanyName is required.")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [RegularExpression(@"^[^@\s]+@[^@\s]+\.[^@\s]+$", ErrorMessage = "Email is not in a valid format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\+?[0-9\s\-]+$", ErrorMessage = "Phone must contain only numbers, spaces, or dashes, and may start with a '+'.")]
        public string Phone { get; set; }
    }
}
