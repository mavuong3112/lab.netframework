using LAB4.Models;
using LAB4.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LAB4.Controllers
{
    public class InstructorController : Controller
    {
        private static List<Instructor> instructors = new List<Instructor>
        {
            new Instructor { ID = 1, LastName = "Nguyen", FirstMidName = "Hieu", HireDate = new DateTime(2020,1,1), Courses = new List<Course>() },
            new Instructor { ID = 2, LastName = "Tran", FirstMidName = "Hung", HireDate = new DateTime(2019,5,10), Courses = new List<Course>() }
        };

        private static List<Course> courses = new List<Course>
        {
            new Course { CourseID = 1045, Title = "Calculus", Credits = 4, DepartmentID = 1 },
            new Course { CourseID = 1050, Title = "Chemistry", Credits = 3, DepartmentID = 4 },
            new Course { CourseID = 2021, Title = "Composition", Credits = 3, DepartmentID = 2 },
            new Course { CourseID = 2042, Title = "Literature", Credits = 4, DepartmentID = 2 },
            new Course { CourseID = 3141, Title = "Trigonometry", Credits = 4, DepartmentID = 1 },
            new Course { CourseID = 4022, Title = "Microeconomics", Credits = 3, DepartmentID = 3 },
            new Course { CourseID = 4041, Title = "Macroeconomics", Credits = 3, DepartmentID = 3 }
        };

        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 1045, Grade = Grade.A },
            new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID = 1045, Grade = Grade.B },
            new Enrollment { EnrollmentID = 3, StudentID = 2, CourseID = 1050, Grade = Grade.C },
            new Enrollment { EnrollmentID = 4, StudentID = 3, CourseID = 2021, Grade = Grade.A },
        };

        private static List<Student> students = new List<Student>
        {
            new Student { ID = 1, LastName = "Nguyen", FirstMidName = "An", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { ID = 2, LastName = "Tran", FirstMidName = "Binh", EnrollmentDate = new DateTime(2023, 9, 2) },
            new Student { ID = 3, LastName = "Le", FirstMidName = "Chi", EnrollmentDate = new DateTime(2023, 9, 3) },
        };

        private static List<Department> departments = new List<Department>
        {
            new Department { DepartmentID = 1, Name = "Mathematics", Budget = 100000, StartDate = new DateTime(2020,1,1) },
            new Department { DepartmentID = 2, Name = "English", Budget = 80000, StartDate = new DateTime(2020,2,1) },
            new Department { DepartmentID = 3, Name = "Economics", Budget = 120000, StartDate = new DateTime(2020,3,1) },
            new Department { DepartmentID = 4, Name = "Engineering", Budget = 150000, StartDate = new DateTime(2020,4,1) }
        };

        // Gán Department cho Course
        static InstructorController()
        {
            foreach (var c in courses)
            {
                c.Department = departments.FirstOrDefault(d => d.DepartmentID == c.DepartmentID);
            }
        }

        // GET: Instructor
        public ActionResult Index(int? instructorId, int? courseId)
        {
            var vm = new InstructorIndexViewModel
            {
                Instructors = instructors,
                Students = students,
                Courses = new List<Course>(),
                Enrollments = new List<Enrollment>()
            };

            if (instructorId.HasValue)
            {
                vm.SelectedInstructor = instructors.FirstOrDefault(i => i.ID == instructorId);
                if (vm.SelectedInstructor != null)
                {
                    vm.Courses = vm.SelectedInstructor.Courses ?? new List<Course>();
                }
            }

            if (courseId.HasValue)
            {
                vm.SelectedCourse = courses.FirstOrDefault(c => c.CourseID == courseId);
                if (vm.SelectedCourse != null)
                {
                    vm.Enrollments = enrollments.Where(e => e.CourseID == courseId).ToList();
                }
            }

            return View(vm);
        }

        // GET: Instructor/Details/5
        public ActionResult Details(int? id)
        {
            if (!id.HasValue) return RedirectToAction("Index");

            var instructor = instructors.FirstOrDefault(i => i.ID == id.Value);
            if (instructor == null) return HttpNotFound();

            foreach (var c in instructor.Courses)
            {
                c.Department = departments.FirstOrDefault(d => d.DepartmentID == c.DepartmentID);
            }

            return View(instructor);
        }

        // GET: Instructor/Create
        public ActionResult Create()
        {
            var vm = new InstructorEditViewModel
            {
                Instructor = new Instructor(),
                AllCourses = courses,
                SelectedCourseIDs = new List<int>()
            };
            return View(vm);
        }

        // POST: Instructor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InstructorEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Instructor.ID = instructors.Any() ? instructors.Max(i => i.ID) + 1 : 1;
                vm.Instructor.Courses = courses
                    .Where(c => vm.SelectedCourseIDs.Contains(c.CourseID))
                    .ToList();

                instructors.Add(vm.Instructor);
                return RedirectToAction("Index");
            }

            vm.AllCourses = courses;
            return View(vm);
        }

        // GET: Instructor/Edit/5
        public ActionResult Edit(int id)
        {
            var instructor = instructors.FirstOrDefault(i => i.ID == id);
            if (instructor == null) return HttpNotFound();

            var vm = new InstructorEditViewModel
            {
                Instructor = instructor,
                AllCourses = courses,
                SelectedCourseIDs = instructor.Courses?.Select(c => c.CourseID).ToList() ?? new List<int>()
            };

            return View(vm);
        }

        // POST: Instructor/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InstructorEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var existing = instructors.FirstOrDefault(i => i.ID == vm.Instructor.ID);
                if (existing == null) return HttpNotFound();

                existing.LastName = vm.Instructor.LastName;
                existing.FirstMidName = vm.Instructor.FirstMidName;
                existing.HireDate = vm.Instructor.HireDate;
                existing.Office = vm.Instructor.Office;

                existing.Courses = courses
                    .Where(c => vm.SelectedCourseIDs.Contains(c.CourseID))
                    .ToList();

                return RedirectToAction("Index");
            }

            vm.AllCourses = courses;
            return View(vm);
        }

        // GET: Instructor/Delete/5
        public ActionResult Delete(int id)
        {
            var instructor = instructors.FirstOrDefault(i => i.ID == id);
            if (instructor == null) return HttpNotFound();
            return View(instructor);
        }

        // POST: Instructor/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var instructor = instructors.FirstOrDefault(i => i.ID == id);
            if (instructor != null) instructors.Remove(instructor);
            return RedirectToAction("Index");
        }
    }
}
