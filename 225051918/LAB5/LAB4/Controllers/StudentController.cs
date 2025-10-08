using LAB4.Models;
using LAB4.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LAB4.Controllers
{
    public class StudentController : Controller
    {
        // Danh sách mẫu Student
        private static List<Student> students = new List<Student>
        {
            new Student { ID = 1, LastName = "Nguyen", FirstMidName = "An", EnrollmentDate = new DateTime(2023, 9, 1) },
            new Student { ID = 2, LastName = "Tran", FirstMidName = "Binh", EnrollmentDate = new DateTime(2023, 9, 2) },
            new Student { ID = 3, LastName = "Le", FirstMidName = "Chi", EnrollmentDate = new DateTime(2023, 9, 3) },
        };

        // Danh sách mẫu Course
        private static List<Course> courses = new List<Course>
        {
            new Course { CourseID = 101, Title = "ASP.NET MVC", Credits = 3 },
            new Course { CourseID = 102, Title = "CSDL", Credits = 4 },
            new Course { CourseID = 103, Title = "Mobile", Credits = 3 }
        };

        // Danh sách mẫu Enrollment
        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 101, Grade = Grade.A },
            new Enrollment { EnrollmentID = 2, StudentID = 1, CourseID = 102, Grade = Grade.B },
            new Enrollment { EnrollmentID = 3, StudentID = 2, CourseID = 103, Grade = Grade.C }
        };

        // GET: Student (có tìm kiếm, sắp xếp, phân trang)
        public ActionResult Index(string searchString, string sortOrder, int page = 1)
        {
            int pageSize = 3;

            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            var list = students.AsQueryable();

            // Tìm kiếm không phân biệt hoa/thường
            if (!string.IsNullOrEmpty(searchString))
            {
                var lowerSearch = searchString.ToLower();
                list = list.Where(s => s.LastName.ToLower().Contains(lowerSearch)
                                    || s.FirstMidName.ToLower().Contains(lowerSearch));
            }

            // Sắp xếp
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

            // Phân trang
            int totalStudents = list.Count();
            var studentsOnPage = list.Skip((page - 1) * pageSize).Take(pageSize).ToList();

            ViewBag.TotalPages = (int)Math.Ceiling((double)totalStudents / pageSize);
            ViewBag.CurrentPage = page;

            return View(studentsOnPage);
        }

        // GET: Student/Details/5
        public ActionResult Details(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();

            var studentEnrollments = enrollments
                .Where(e => e.StudentID == student.ID)
                .Join(courses,
                      e => e.CourseID,
                      c => c.CourseID,
                      (e, c) => new Enrollment
                      {
                          EnrollmentID = e.EnrollmentID,
                          StudentID = e.StudentID,
                          CourseID = e.CourseID,
                          Grade = e.Grade,
                          Course = c
                      })
                .ToList();

            var viewModel = new StudentDetailsViewModel
            {
                Student = student,
                Enrollments = studentEnrollments,
                Courses = courses
            };

            return View(viewModel);
        }

        // GET: Student/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Student/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student student)
        {
            if (ModelState.IsValid)
            {
                student.ID = students.Any() ? students.Max(s => s.ID) + 1 : 1;
                students.Add(student);
                return RedirectToAction("Index");
            }
            return View(student);
        }

        // GET: Student/Edit/5
        public ActionResult Edit(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Student/Edit/5
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

        // GET: Student/Delete/5
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student == null) return HttpNotFound();
            return View(student);
        }

        // POST: Student/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var student = students.FirstOrDefault(s => s.ID == id);
            if (student != null) students.Remove(student);
            return RedirectToAction("Index");
        }
    }
}
