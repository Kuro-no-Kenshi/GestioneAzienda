using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAzienda.Data.Vehicles
{
    public class VehicleDocument
    {
        public int VehicleDocumentId { get; set; }

        [Required(ErrorMessage = "Please select a vehicle")]
        public int VehicleId { get; set; }

        public string FileName { get; set; }
    }
}
