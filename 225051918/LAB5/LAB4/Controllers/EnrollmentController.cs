using LAB4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LAB4.Controllers
{
    public class EnrollmentController : Controller
    {
        private static List<Enrollment> enrollments = new List<Enrollment>
        {
            new Enrollment { EnrollmentID = 1, StudentID = 1, CourseID = 101, Grade = Grade.A },
            new Enrollment { EnrollmentID = 2, StudentID = 2, CourseID = 102, Grade = Grade.B },
            new Enrollment { EnrollmentID = 3, StudentID = 3, CourseID = 103, Grade = Grade.C }
        };

        // GET: Enrollment
        public ActionResult Index()
        {
            return View(enrollments);
        }

        // GET: Enrollment/Details/5
        public ActionResult Details(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.EnrollmentID == id);
            if (enrollment == null) return HttpNotFound();
            return View(enrollment);
        }

        // GET: Enrollment/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Enrollment/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.EnrollmentID = enrollments.Max(e => e.EnrollmentID) + 1;
                enrollments.Add(enrollment);
                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        // GET: Enrollment/Edit/5
        public ActionResult Edit(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.EnrollmentID == id);
            if (enrollment == null) return HttpNotFound();
            return View(enrollment);
        }

        // POST: Enrollment/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                var existing = enrollments.FirstOrDefault(e => e.EnrollmentID == enrollment.EnrollmentID);
                if (existing == null) return HttpNotFound();

                existing.StudentID = enrollment.StudentID;
                existing.CourseID = enrollment.CourseID;
                existing.Grade = enrollment.Grade;

                return RedirectToAction("Index");
            }
            return View(enrollment);
        }

        // GET: Enrollment/Delete/5
        public ActionResult Delete(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.EnrollmentID == id);
            if (enrollment == null) return HttpNotFound();
            return View(enrollment);
        }

        // POST: Enrollment/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var enrollment = enrollments.FirstOrDefault(e => e.EnrollmentID == id);
            if (enrollment != null) enrollments.Remove(enrollment);
            return RedirectToAction("Index");
        }
    }
}
