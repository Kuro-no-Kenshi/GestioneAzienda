using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAzienda.Data.Vehicles
{
    public class Vehicle
    {
        public int VehicleId { get; set; }

        [Required(ErrorMessage = "NumberPlate is required.")]
        [RegularExpression(@"^[A-Z]{2}[0-9]{3}[A-Z]{2}$", ErrorMessage = "NumberPlate must be in the format 'AA123BB' (e.g., Italian plate).")]
        public string NumberPlate { get; set; }

        [Required(ErrorMessage = "SerialNumber is required.")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Registration date is required.")]
        public DateOnly Registration { get; set; }

        public bool Industry4 { get; set; }

        public bool FinancingSabatini { get; set; }

        [Required(ErrorMessage = "Inspection date is required.")]
        public DateOnly Inspection { get; set; }

        [Required(ErrorMessage = "RoadTaxes date is required.")]
        public DateOnly RoadTaxes { get; set; }

        [Required(ErrorMessage = "Insurance date is required.")]
        public DateOnly Insurance { get; set; }

        public int VehicleTypeId { get; set; }

        public List<VehicleDocument>? Document { get; set; }

        public List<VehicleMaintenance>? Maintenance { get; set; }

        public int CompanyId { get; set; }
    }
}
