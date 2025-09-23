using lab2.net.DAL;
using lab2.net.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace lab2.net.Controllers
{
    public class StudentController : Controller
    {
        private readonly SchoolContext db = new SchoolContext();

        // GET: /Student?search=...
        public ActionResult Index(string search)
        {
            var students = db.Students.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                students = students.Where(s =>
                    s.FirstMidName.Contains(search) ||
                    s.LastName.Contains(search));
            }
            ViewBag.Search = search;
            return View(students.OrderBy(s => s.LastName).ThenBy(s => s.FirstMidName).ToList());
        }

        // GET: /Student/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var st = db.Students.Find(id);
            if (st == null) return HttpNotFound();
            return View(st);
        }

        // GET: Create
        public ActionResult Create() => View();

        // POST: Create
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LastName,FirstMidName,EnrollmentDate")] Student st)
        {
            if (ModelState.IsValid)
            {
                db.Students.Add(st);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }

        // GET: Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var st = db.Students.Find(id);
            if (st == null) return HttpNotFound();
            return View(st);
        }

        // POST: Edit/5
        [HttpPost, ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LastName,FirstMidName,EnrollmentDate")] Student st)
        {
            if (ModelState.IsValid)
            {
                db.Entry(st).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(st);
        }

        // GET: Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var st = db.Students.Find(id);
            if (st == null) return HttpNotFound();
            return View(st);
        }

        // POST: Delete/5
        [HttpPost, ActionName("Delete"), ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var st = db.Students.Find(id);
            db.Students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing) db.Dispose();
            base.Dispose(disposing);
        }
    }
}