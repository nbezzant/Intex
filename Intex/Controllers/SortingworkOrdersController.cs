using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Intex.DAL;
using Intex.Models;

namespace Intex.Controllers
{
    [Authorize(Roles ="Engineer,Admin")]
    public class SortingworkOrdersController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: SortingworkOrders
        public ActionResult Index()
        {
            return View(db.SortingWorkOrders.OrderBy(x => x.order).ThenBy(n => n.Date_Due).ToList());
        }

        // GET: SortingworkOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortingworkOrders sortingworkOrders = db.SortingWorkOrders.Find(id);
            if (sortingworkOrders == null)
            {
                return HttpNotFound();
            }
            return View(sortingworkOrders);
        }

        // GET: SortingworkOrders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SortingworkOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Database_Number,order,Work_Order_Assay_ID,Work_Order_ID,Assay_Cost,Assay_ID,Date_Due")] SortingworkOrders sortingworkOrders)
        {
            if (ModelState.IsValid)
            {
                db.SortingWorkOrders.Add(sortingworkOrders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sortingworkOrders);
        }

        // GET: SortingworkOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortingworkOrders sortingworkOrders = db.SortingWorkOrders.Find(id);
            if (sortingworkOrders == null)
            {
                return HttpNotFound();
            }
            return View(sortingworkOrders);
        }

        // POST: SortingworkOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Database_Number,order,Work_Order_Assay_ID,Work_Order_ID,Assay_Cost,Assay_ID,Date_Due")] SortingworkOrders sortingworkOrders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sortingworkOrders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sortingworkOrders);
        }

        // GET: SortingworkOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SortingworkOrders sortingworkOrders = db.SortingWorkOrders.Find(id);
            if (sortingworkOrders == null)
            {
                return HttpNotFound();
            }
            return View(sortingworkOrders);
        }

        // POST: SortingworkOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SortingworkOrders sortingworkOrders = db.SortingWorkOrders.Find(id);
            db.SortingWorkOrders.Remove(sortingworkOrders);
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
