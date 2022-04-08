using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TH04_CNPMNC.Models;

namespace TH04_CNPMNC.Controllers
{
    public class ChiTietSachController : Controller
    {
        private CNPMNC_QLThuVienEntities db = new CNPMNC_QLThuVienEntities();

        // GET: ChiTietSach
        public ActionResult Index()
        {
            var chiTietSaches = db.ChiTietSaches.Include(c => c.Sach);
            return View(chiTietSaches.ToList());
        }

        // GET: ChiTietSach/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSach);
        }

        // GET: ChiTietSach/Create
        public ActionResult Create()
        {
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach");
            return View();
        }

        // POST: ChiTietSach/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCTS,MaSach,TheLoai")] ChiTietSach chiTietSach)
        {
            if (ModelState.IsValid)
            {
                db.ChiTietSaches.Add(chiTietSach);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", chiTietSach.MaSach);
            return View(chiTietSach);
        }

        // GET: ChiTietSach/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", chiTietSach.MaSach);
            return View(chiTietSach);
        }

        // POST: ChiTietSach/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCTS,MaSach,TheLoai")] ChiTietSach chiTietSach)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chiTietSach).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSach = new SelectList(db.Saches, "MaSach", "TenSach", chiTietSach.MaSach);
            return View(chiTietSach);
        }

        // GET: ChiTietSach/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            if (chiTietSach == null)
            {
                return HttpNotFound();
            }
            return View(chiTietSach);
        }

        // POST: ChiTietSach/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChiTietSach chiTietSach = db.ChiTietSaches.Find(id);
            db.ChiTietSaches.Remove(chiTietSach);
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
