using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Poligon_test1.Models;

namespace Poligon_test1.Controllers
{
    public class CUSTOMERSController : Controller
    {
        private Entities db = new Entities();

        // GET: CUSTOMERS
        public ActionResult Index()
        {
            return View(db.CUSTOMERS.ToList());
        }

        // GET: CUSTOMERS/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERS cUSTOMERS = db.CUSTOMERS.Find(id);
            if (cUSTOMERS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERS);
        }

        // GET: CUSTOMERS/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CUSTOMERS/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CUSTOMER_ID,CUSTOMER_NAME,CITY")] CUSTOMERS cUSTOMERS)
        {
            if (ModelState.IsValid)
            {
                db.CUSTOMERS.Add(cUSTOMERS);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cUSTOMERS);
        }

        // GET: CUSTOMERS/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERS cUSTOMERS = db.CUSTOMERS.Find(id);
            if (cUSTOMERS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERS);
        }

        // POST: CUSTOMERS/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CUSTOMER_ID,CUSTOMER_NAME,CITY")] CUSTOMERS cUSTOMERS)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cUSTOMERS).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cUSTOMERS);
        }

        // GET: CUSTOMERS/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CUSTOMERS cUSTOMERS = db.CUSTOMERS.Find(id);
            if (cUSTOMERS == null)
            {
                return HttpNotFound();
            }
            return View(cUSTOMERS);
        }

        // POST: CUSTOMERS/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CUSTOMERS cUSTOMERS = db.CUSTOMERS.Find(id);
            db.CUSTOMERS.Remove(cUSTOMERS);
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
