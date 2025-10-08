using System.ComponentModel.DataAnnotations;

namespace LAB4.Models
{
    public enum Grade { A, B, C, D, F }

    public class Enrollment
    {
        public int EnrollmentID { get; set; }

        [Required(ErrorMessage = "Student ID is required")]
        [Display(Name = "Student ID")]
        public int StudentID { get; set; }

        [Required(ErrorMessage = "Course ID is required")]
        [Display(Name = "Course ID")]
        public int CourseID { get; set; }

        [Display(Name = "Grade")]
        public Grade? Grade { get; set; }

        public virtual Student Student { get; set; }
        public virtual Course Course { get; set; }
    }
}
