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
    public class Work_Order_AssaysController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        public static int workOrderId = -5;
        // GET: Work_Order_Assays
        public ActionResult SeeAssay_WorkOnTest(int id)
        {
            workOrderId = id;
            ViewBag.ID = id;
            IEnumerable<Work_Order_Assays> assays =
            db.Database.SqlQuery<Work_Order_Assays>("SELECT * " +
                                        "FROM Assays, Work_Order_Assays, Work_Orders " +
                                        "WHERE Work_Orders.Work_Order_ID = Work_Order_Assays.Work_Order_ID " +
                                        "AND Work_Order_Assays.Assay_ID = Assays.Assay_ID " +
                                        "AND Work_Orders.Work_Order_Id = " + workOrderId);
            return View(db.Work_Order_Assays.ToList());
        }

        // GET: Work_Order_Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Order_Assays work_Order_Assays = db.Work_Order_Assays.Find(id);
            if (work_Order_Assays == null)
            {
                return HttpNotFound();
            }
            return View(work_Order_Assays);
        }

        // GET: Work_Order_Assays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Work_Order_Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Work_Order_Assay_ID,Work_Order_ID,Assay_Cost,Assay_ID,Assay_results")] Work_Order_Assays work_Order_Assays)
        {
            if (ModelState.IsValid)
            {
                db.Work_Order_Assays.Add(work_Order_Assays);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Order_Assays);
        }

        // GET: Work_Order_Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Order_Assays work_Order_Assays = db.Work_Order_Assays.Find(id);
            if (work_Order_Assays == null)
            {
                return HttpNotFound();
            }
            return View(work_Order_Assays);
        }

        // POST: Work_Order_Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Work_Order_Assay_ID,Work_Order_ID,Assay_Cost,Assay_ID,Assay_results")] Work_Order_Assays work_Order_Assays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Order_Assays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Order_Assays);
        }

        // GET: Work_Order_Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Order_Assays work_Order_Assays = db.Work_Order_Assays.Find(id);
            if (work_Order_Assays == null)
            {
                return HttpNotFound();
            }
            return View(work_Order_Assays);
        }

        // POST: Work_Order_Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_Order_Assays work_Order_Assays = db.Work_Order_Assays.Find(id);
            db.Work_Order_Assays.Remove(work_Order_Assays);
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
