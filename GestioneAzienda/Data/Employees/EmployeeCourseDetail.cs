namespace GestioneAzienda.Data.Employees
{
    public class EmployeeCourseDetail
    {
        public int EmployeeCourseDetailId { get; set; }
        public int EmployeeId { get; set; }
        public int CourseId { get; set; }
        public DateOnly CompleteDate { get; set; }
        public DateOnly? RenewalDate { get; set; }
    }
}
