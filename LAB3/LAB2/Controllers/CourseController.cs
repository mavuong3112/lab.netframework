using LAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB2.Controllers
{
    public class CourseController : Controller
    {
        private static List<Course> courses = new List<Course>
        {
            new Course { CourseID = 101, Title = "ASP.NET MVC", Credits = 3},
            new Course { CourseID = 102, Title = "CSDL", Credits = 4},
            new Course { CourseID = 103, Title = "Mobile", Credits =3},
        };

        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentID = 1, StudentID = 2, CourseID = 101, Grade = Grade.A },
            new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID  = 102, Grade = Grade.B },
            new Enrollment { EnrollmentID = 3, StudentID = 3, CourseID = 103, Grade = Grade.C },
        };

        private static List<Student> students = new List<Student>
        {
            new Student { ID = 1, LastName = "Nguyen", FirstMidName = "An", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { ID = 2, LastName = "Tran", FirstMidName = "Binh", EnrollmentDate = new DateTime(2023, 9, 2) },
            new Student { ID = 3, LastName = "Le", FirstMidName = "Chi", EnrollmentDate = new DateTime(2023, 9, 3) },
        };

        // GET: Course
        public ActionResult Index()
        {
            return View(courses);
        }

        // GET: Course/Details/
        public ActionResult Details(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();

            var enrolledStudents = enrollments.Where(e => e.CourseID == id)
                .Join(students,
                      e => e.StudentID,
                      s => s.ID,
                      (e, s) => new StudentEnrollmentViewModel
                      {
                          FirstMidName = s.FirstMidName,
                          LastName = s.LastName,
                          Grade = e.Grade
                      })
                .ToList();

            var viewModel = new CourseDetailsViewModel
            {
                Course = course,
                EnrolledStudents = enrolledStudents
            };

            return View(viewModel);
        }


        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Course course)
        {
            if (ModelState.IsValid)
            {
                courses.Add(course);
                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Edit/
        public ActionResult Edit(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();
            return View(course);
        }

        // POST: Course/Edit
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

                return RedirectToAction("Index");
            }
            return View(course);
        }

        // GET: Course/Delete/
        public ActionResult Delete(int id)
        {
            var course = courses.FirstOrDefault(c => c.CourseID == id);
            if (course == null) return HttpNotFound();
            return View(course);
        }

        // POST: Course/Delete
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