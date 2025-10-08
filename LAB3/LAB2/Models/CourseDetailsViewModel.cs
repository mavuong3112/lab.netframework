using System.Collections.Generic;

namespace LAB2.Models
{
    public class CourseDetailsViewModel
    {
        public Course Course { get; set; }
        public List<StudentEnrollmentViewModel> EnrolledStudents { get; set; }
    }

    public class StudentEnrollmentViewModel
    {
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public Grade? Grade { get; set; }
    }
}
