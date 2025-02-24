using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestioneAzienda.Data.Vehicles
{
    public class VehicleMaintenance
    {
        public int VehicleMaintenanceId { get; set; }

        public int VehicleId { get; set; }

        [Required(ErrorMessage = "Maintenance date is required.")]
        public DateOnly MaintenanceDate { get; set; }

        [Required(ErrorMessage = "Usage hours are required.")]
        [Range(1, int.MaxValue, ErrorMessage = "Usage hours must be greater than 0.")]
        public int UsageHours { get; set; }

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Description must be between 20 and 500 characters.")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Invoice number is required.")]
        public string InvoiceNumber { get; set; }

        [Required(ErrorMessage = "Invoice date is required.")]
        public DateOnly InvoiceDate { get; set; }

        [Required(ErrorMessage = "Supplier ID is required.")]
        public int SupplierId { get; set; }

        [Required(ErrorMessage = "Maintenance cost is required.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Maintenance cost must be greater than 0.")]
        public decimal MaintenanceCost { get; set; }

        [Required(ErrorMessage = "Invoice file name is required.")]
        public string InvoiceFileName { get; set; }
    }
}
