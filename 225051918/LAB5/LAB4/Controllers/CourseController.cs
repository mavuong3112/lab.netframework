using LAB4.Models;
using LAB4.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LAB4.Controllers
{
    public class CourseController : Controller
    {
        // Danh sách mẫu
        private static List<Department> departments = new List<Department>
        {
            new Department { DepartmentID = 1, Name = "Mathematics", Budget = 100000, StartDate = new DateTime(2020,1,1) },
            new Department { DepartmentID = 2, Name = "English", Budget = 80000, StartDate = new DateTime(2020,2,1) },
            new Department { DepartmentID = 3, Name = "Economics", Budget = 120000, StartDate = new DateTime(2020,3,1) },
            new Department { DepartmentID = 4, Name = "Engineering", Budget = 150000, StartDate = new DateTime(2020,4,1) }
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

        private static List<Student> students = new List<Student>
        {
            new Student { ID = 1, LastName = "Nguyen", FirstMidName = "An", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { ID = 2, LastName = "Tran", FirstMidName = "Binh", EnrollmentDate = new DateTime(2023, 9, 2) },
            new Student { ID = 3, LastName = "Le", FirstMidName = "Chi", EnrollmentDate = new DateTime(2023, 9, 3) },
        };

        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 1045, Grade = Grade.A },
            new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID = 1045, Grade = Grade.B },
            new Enrollment { EnrollmentID = 3, StudentID = 2, CourseID = 1050, Grade = Grade.C },
            new Enrollment { EnrollmentID = 4, StudentID = 3, CourseID = 2021, Grade = Grade.A },
        };

        // GET: Course
        public ActionResult Index()
        {
            foreach (var c in courses)
            {
                c.Department = departments.FirstOrDefault(d => d.DepartmentID == c.DepartmentID);
            }
            return View(courses);
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();

            course.Department = departments.FirstOrDefault(d => d.DepartmentID == course.DepartmentID);

            var courseEnrollments = enrollments.Where(e => e.CourseID == id).ToList();
            var enrolledStudents = courseEnrollments
                .Join(students, e => e.StudentID, s => s.ID, (e, s) => s)
                .ToList();

            var viewModel = new CourseDetailsViewModel
            {
                Course = course,
                Enrollments = courseEnrollments,
                Students = enrolledStudents
            };

            return View(viewModel);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(departments, "DepartmentID", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                course.Department = departments.FirstOrDefault(d => d.DepartmentID == course.DepartmentID);
                courses.Add(course);
                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();

            ViewBag.DepartmentID = new SelectList(departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Course course)
        {
            if (ModelState.IsValid)
            {
                var existing = courses.FirstOrDefault(c => c.CourseID == course.CourseID);
                if (existing == null) return HttpNotFound();

                existing.Title = course.Title;
                existing.Credits = course.Credits;
                existing.DepartmentID = course.DepartmentID;
                existing.Department = departments.FirstOrDefault(d => d.DepartmentID == course.DepartmentID);

                return RedirectToAction("Index");
            }
            ViewBag.DepartmentID = new SelectList(departments, "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();

            course.Department = departments.FirstOrDefault(d => d.DepartmentID == course.DepartmentID);
            return View(course);
        }

        // POST: Course/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course != null) courses.Remove(course);
            return RedirectToAction("Index");
        }
    }
}
