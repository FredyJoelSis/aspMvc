using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc_web_crud_psql.DataContext;
using mvc_web_crud_psql.Models;

namespace mvc_web_crud_psql.Controllers
{
    public class EmpleadoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Empleado
        public ActionResult Index()
        {
            return View(db.Empleadoobj.ToList());
        }

        // GET: Empleado/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoClass empleadoClass = db.Empleadoobj.Find(id);
            if (empleadoClass == null)
            {
                return HttpNotFound();
            }
            return View(empleadoClass);
        }

        // GET: Empleado/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empleado/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre,apellidos,edad,telefono,direccion")] EmpleadoClass empleadoClass)
        {
            if (ModelState.IsValid)
            {
                db.Empleadoobj.Add(empleadoClass);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empleadoClass);
        }

        // GET: Empleado/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoClass empleadoClass = db.Empleadoobj.Find(id);
            if (empleadoClass == null)
            {
                return HttpNotFound();
            }
            return View(empleadoClass);
        }

        // POST: Empleado/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre,apellidos,edad,telefono,direccion")] EmpleadoClass empleadoClass)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empleadoClass).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empleadoClass);
        }

        // GET: Empleado/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpleadoClass empleadoClass = db.Empleadoobj.Find(id);
            if (empleadoClass == null)
            {
                return HttpNotFound();
            }
            return View(empleadoClass);
        }

        // POST: Empleado/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpleadoClass empleadoClass = db.Empleadoobj.Find(id);
            db.Empleadoobj.Remove(empleadoClass);
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
