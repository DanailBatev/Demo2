using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRSystem.DAL;
using HRSystem.Models;

namespace HRSystem.Controllers
{
    public class EmployeesController : Controller
    {
        private HRContext db = new HRContext();

        // GET: Employees
        public ActionResult Index()
        {
            var employees = db.Employees.Include(e => e.BossEmployee).Include(e => e.Project).Include(e => e.Role).Include(e => e.User);
            return View(employees.ToList());
        }

        // GET: Employees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.BossEmployeeID = new SelectList(db.Employees, "ID", "User.FullName");
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name");
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name");
            ViewBag.UserID = new SelectList(db.Users, "ID", "FullName");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,UserID,BossEmployeeID,RoleID,ProjectID,SalaryAmount")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employees.Add(employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BossEmployeeID = new SelectList(db.Employees, "ID", "ID", employee.BossEmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", employee.ProjectID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", employee.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", employee.UserID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BossEmployeeID = new SelectList(db.Employees, "ID", "ID", employee.BossEmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", employee.ProjectID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", employee.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", employee.UserID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,UserID,BossEmployeeID,RoleID,ProjectID,SalaryAmount")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BossEmployeeID = new SelectList(db.Employees, "ID", "ID", employee.BossEmployeeID);
            ViewBag.ProjectID = new SelectList(db.Projects, "ID", "Name", employee.ProjectID);
            ViewBag.RoleID = new SelectList(db.Roles, "ID", "Name", employee.RoleID);
            ViewBag.UserID = new SelectList(db.Users, "ID", "FirstName", employee.UserID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Employee employee = db.Employees.Find(id);
            db.Employees.Remove(employee);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
