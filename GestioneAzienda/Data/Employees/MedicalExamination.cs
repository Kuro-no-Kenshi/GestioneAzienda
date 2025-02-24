namespace GestioneAzienda.Data.Employees
{
    public class MedicalExamination
    {
        public int MedicalExaminationId { get; set; }
        public DateOnly MedicalDate { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }
    }
}
