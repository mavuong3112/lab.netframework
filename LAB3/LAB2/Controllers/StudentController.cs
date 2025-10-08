using LAB2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LAB2.Controllers
{
    public class StudentController : Controller
    {
        private static List<Student> students = new List<Student>
        {
            new Student { ID = 1, LastName = "Nguyen", FirstMidName = "An", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { ID = 2, LastName = "Tran", FirstMidName = "Binh", EnrollmentDate = new DateTime(2023, 9, 2) },
            new Student { ID = 3, LastName = "Le", FirstMidName = "Chi", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 4, LastName = "AAA", FirstMidName = "Khec", EnrollmentDate = new DateTime(2025, 9, 4) },
            new Student { ID = 5, LastName = "Skibidi", FirstMidName = "Quao", EnrollmentDate = new DateTime(2024, 9, 5) },
            new Student { ID = 6, LastName = "Le", FirstMidName = "Dung", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 7, LastName = "Le", FirstMidName = "Kha", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 8, LastName = "Le", FirstMidName = "Bao", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 9, LastName = "Le", FirstMidName = "La", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 10, LastName = "Le", FirstMidName = "Loi", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 11, LastName = "Le", FirstMidName = "Lai", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 12, LastName = "Le", FirstMidName = "Minh", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 13, LastName = "Le", FirstMidName = "Linh", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 14, LastName = "Le", FirstMidName = "Chao", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 15, LastName = "Le", FirstMidName = "Hai", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 16, LastName = "Le", FirstMidName = "Hong", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 17, LastName = "Le", FirstMidName = "Ngoc", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 18, LastName = "Le", FirstMidName = "Hoang", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 19, LastName = "Le", FirstMidName = "Anh", EnrollmentDate = new DateTime(2023, 9, 3) },
            new Student { ID = 20, LastName = "Le", FirstMidName = "Em", EnrollmentDate = new DateTime(2023, 9, 3) },
        };

        //GET: Student/Index
        public ActionResult Index(string searchString, string sortOrder, int page  = 1)
        {
            int pageSize = 3;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var list = students.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                list = list.Where(s =>
                    (!string.IsNullOrEmpty(s.LastName) &&
                     s.LastName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                    ||
                    (!string.IsNullOrEmpty(s.FirstMidName) &&
                     s.FirstMidName.IndexOf(searchString, StringComparison.OrdinalIgnoreCase) >= 0)
                );
            }


            switch (sortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    list = list.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    list = list.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    list = list.OrderBy(s => s.LastName);
                    break;
            }

            int totalStudents = list.Count();
            var studentOnPage = list.Skip((page - 1)*pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalStudents / pageSize);
            ViewBag.CurrentPage = page;

            return View(studentOnPage);
        }

        //GET: Student/Details/
        public ActionResult Details(int? id)
        {
            if (id == null) return HttpNotFound();

            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();

            var studentEnrollments = enrollments.Where(e => e.StudentID == student.ID).Join(courses,
                e => e.CourseID, c => c.CourseID, (e, c) => new { c.Title, c.Credits, e.Grade }).ToList();

            ViewBag.Enrollments = studentEnrollments;

            return View(student);
        }

        //GET: Student/Create
        public ActionResult Create()
        { 
            return View(); 
        }

        //POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.ID = students.Max(s => s.ID) + 1;
                students.Add(student);
                return RedirectToAction("Index");
            }

            return View(student);
        }

        //GET: Student/Edit/
        public ActionResult Edit(int? id)
        {
            if (id == null) return HttpNotFound();

            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();

            return View(student);
        }

        //POST: Student/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var existing = students.FirstOrDefault(s => s.ID == student.ID);
                if (existing == null) return HttpNotFound();

                existing.LastName = student.LastName;
                existing.FirstMidName = student.FirstMidName;
                existing.EnrollmentDate = student.EnrollmentDate;

                return RedirectToAction("Index");
            }
            return View(student);
        }

        //GET: Student/Delete/
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound();

            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();

            return View(student);
        }

        //POST: Student/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student != null) students.Remove(student);

            return RedirectToAction("Index");
        }

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

    }
}