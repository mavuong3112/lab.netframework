using System.Collections.Generic;

namespace LAB4.Models.ViewModels
{
    public class CourseDetailsViewModel
    {
        public Course Course { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Student> Students { get; set; } = new List<Student>();
    }

    public class StudentDetailsViewModel
    {
        public Student Student { get; set; }
        public List<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public List<Course> Courses { get; set; } = new List<Course>();
    }

    public class InstructorEditViewModel
    {
        public Instructor Instructor { get; set; } = new Instructor();
        public List<Course> AllCourses { get; set; } = new List<Course>();
        public List<int> SelectedCourseIDs { get; set; } = new List<int>();
    }

    public class InstructorDetailsViewModel
    {
        public Instructor Instructor { get; set; }
        public List<Course> Courses { get; set; }
    }
    


    public class InstructorIndexViewModel
    {
        public IEnumerable<Instructor> Instructors { get; set; } = new List<Instructor>();
        public Instructor SelectedInstructor { get; set; }
        public IEnumerable<Course> Courses { get; set; } = new List<Course>();
        public Course SelectedCourse { get; set; }
        public IEnumerable<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
        public IEnumerable<Student> Students { get; set; } = new List<Student>();
    }

}
