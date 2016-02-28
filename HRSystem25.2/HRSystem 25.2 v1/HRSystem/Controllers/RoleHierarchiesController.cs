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
    public class RoleHierarchiesController : Controller
    {
        private HRContext db = new HRContext();

        // GET: RoleHierarchies
        public ActionResult Index()
        {
            var roleHierarchies = db.RoleHierarchies.Include(r => r.ChildRole).Include(r => r.ParentRole);
            return View(roleHierarchies.ToList());
        }

        // GET: RoleHierarchies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleHierarchy roleHierarchy = db.RoleHierarchies.Find(id);
            if (roleHierarchy == null)
            {
                return HttpNotFound();
            }
            return View(roleHierarchy);
        }

        // GET: RoleHierarchies/Create
        public ActionResult Create()
        {
            ViewBag.ChildRoleID = new SelectList(db.Roles, "ID", "Name");
            ViewBag.ParentRoleID = new SelectList(db.Roles, "ID", "Name");
            return View();
        }

        // POST: RoleHierarchies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ChildRoleID,ParentRoleID")] RoleHierarchy roleHierarchy)
        {
            if (ModelState.IsValid)
            {
                db.RoleHierarchies.Add(roleHierarchy);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChildRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ChildRoleID);
            ViewBag.ParentRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ParentRoleID);
            return View(roleHierarchy);
        }

        // GET: RoleHierarchies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleHierarchy roleHierarchy = db.RoleHierarchies.Find(id);
            if (roleHierarchy == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChildRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ChildRoleID);
            ViewBag.ParentRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ParentRoleID);
            return View(roleHierarchy);
        }

        // POST: RoleHierarchies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ChildRoleID,ParentRoleID")] RoleHierarchy roleHierarchy)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roleHierarchy).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChildRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ChildRoleID);
            ViewBag.ParentRoleID = new SelectList(db.Roles, "ID", "Name", roleHierarchy.ParentRoleID);
            return View(roleHierarchy);
        }

        // GET: RoleHierarchies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoleHierarchy roleHierarchy = db.RoleHierarchies.Find(id);
            if (roleHierarchy == null)
            {
                return HttpNotFound();
            }
            return View(roleHierarchy);
        }

        // POST: RoleHierarchies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoleHierarchy roleHierarchy = db.RoleHierarchies.Find(id);
            db.RoleHierarchies.Remove(roleHierarchy);
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
