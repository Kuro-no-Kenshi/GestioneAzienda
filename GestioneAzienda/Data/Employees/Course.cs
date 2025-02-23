using System.ComponentModel.DataAnnotations;

namespace GestioneAzienda.Data.Employees
{
    public class Course
    {
        public int CourseId { get; set; }

        [Required(ErrorMessage = "Course name is required")]
        public string CourseName { get; set; }

        [Required(ErrorMessage = "Course duration is required")]
        public int CourseDuration { get; set; }  // duration in months

        [Required(ErrorMessage = "Course type is required")]
        public CourseType CourseType { get; set; }

        public int? ProfessionId { get; set; }
    }

    public enum CourseType
    {
        Required,
        Optional,
        Specific
    }
}
