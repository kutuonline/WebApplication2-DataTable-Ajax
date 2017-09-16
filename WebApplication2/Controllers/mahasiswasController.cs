using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;
using System.Linq.Dynamic;

namespace WebApplication2.Controllers
{
    public class mahasiswasController : Controller
    {
        private db_kampusEntities dc = new db_kampusEntities();

        // GET: mahasiswas
        public ActionResult Index()
        {
            //return View(db.mahasiswas.ToList());
            return View();
        }

        
        public ActionResult LoadData()
        {
            using (db_kampusEntities dc = new db_kampusEntities())
            {
                var data = dc.mahasiswas.OrderBy(a => a.nm_mhs).ToList();
                return Json(new { data = data }, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: mahasiswas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahasiswa mahasiswa = dc.mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // GET: mahasiswas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: mahasiswas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nip,nm_mhs,email,alamat")] mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                dc.mahasiswas.Add(mahasiswa);
                dc.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(mahasiswa);
        }

        // GET: mahasiswas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahasiswa mahasiswa = dc.mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: mahasiswas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nip,nm_mhs,email,alamat")] mahasiswa mahasiswa)
        {
            if (ModelState.IsValid)
            {
                dc.Entry(mahasiswa).State = EntityState.Modified;
                dc.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(mahasiswa);
        }

        // GET: mahasiswas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            mahasiswa mahasiswa = dc.mahasiswas.Find(id);
            if (mahasiswa == null)
            {
                return HttpNotFound();
            }
            return View(mahasiswa);
        }

        // POST: mahasiswas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            mahasiswa mahasiswa = dc.mahasiswas.Find(id);
            dc.mahasiswas.Remove(mahasiswa);
            dc.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dc.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
