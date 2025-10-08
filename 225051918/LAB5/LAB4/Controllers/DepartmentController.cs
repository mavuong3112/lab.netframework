using LAB4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LAB4.Controllers
{
    public class DepartmentController : Controller
    {
        private static List<Department> departments = new List<Department>
        {
            new Department { DepartmentID = 1, Name = "IT", Budget = 50000, StartDate = new DateTime(2020,1,1), InstructorID = 1 },
            new Department { DepartmentID = 2, Name = "Business", Budget = 30000, StartDate = new DateTime(2021,2,15), InstructorID = 2 }
        };

        // GET: Department
        public ActionResult Index()
        {
            return View(departments);
        }

        // GET: Department/Details/5
        public ActionResult Details(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        // GET: Department/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Department/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Department department)
        {
            if (ModelState.IsValid)
            {
                department.DepartmentID = departments.Max(d => d.DepartmentID) + 1;
                departments.Add(department);
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Department/Edit/5
        public ActionResult Edit(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        // POST: Department/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Department department)
        {
            if (ModelState.IsValid)
            {
                var existing = departments.FirstOrDefault(d => d.DepartmentID == department.DepartmentID);
                if (existing == null) return HttpNotFound();

                existing.Name = department.Name;
                existing.Budget = department.Budget;
                existing.StartDate = department.StartDate;
                existing.InstructorID = department.InstructorID;

                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Department/Delete/5
        public ActionResult Delete(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department == null) return HttpNotFound();
            return View(department);
        }

        // POST: Department/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var department = departments.FirstOrDefault(d => d.DepartmentID == id);
            if (department != null) departments.Remove(department);
            return RedirectToAction("Index");
        }
    }
}
