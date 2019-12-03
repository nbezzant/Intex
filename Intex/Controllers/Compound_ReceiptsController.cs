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
    public class Compound_ReceiptsController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Compound_Receipts
        public ActionResult ListWork_Orders()
        {
            return View(db.Work_Orders.ToList());
        }
        public ActionResult Index()
        {
            return View(db.Compound_Receipts.ToList());
        }

        // GET: Compound_Receipts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Receipts compound_Receipts = db.Compound_Receipts.Find(id);
            if (compound_Receipts == null)
            {
                return HttpNotFound();
            }
            return View(compound_Receipts);
        }

        // GET: Compound_Receipts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Compound_Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LT,Compound_Sequence_Code,Compound_Name,Quantity,Date_Arrived,Received_By,Date_Due,Appearance,Indicated_Weight,Molecular_Mass,Actual_Weight,MTD,Confirmation_Date,Confirmation_Time,Work_Order_ID")] Compound_Receipts compound_Receipts)
        {
            if (ModelState.IsValid)
            {
                db.Compound_Receipts.Add(compound_Receipts);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(compound_Receipts);
        }

        // GET: Compound_Receipts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Receipts compound_Receipts = db.Compound_Receipts.Find(id);
            if (compound_Receipts == null)
            {
                return HttpNotFound();
            }
            return View(compound_Receipts);
        }

        // POST: Compound_Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LT,Compound_Sequence_Code,Compound_Name,Quantity,Date_Arrived,Received_By,Date_Due,Appearance,Indicated_Weight,Molecular_Mass,Actual_Weight,MTD,Confirmation_Date,Confirmation_Time,Work_Order_ID")] Compound_Receipts compound_Receipts)
        {
            if (ModelState.IsValid)
            {
                db.Entry(compound_Receipts).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(compound_Receipts);
        }

        // GET: Compound_Receipts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Compound_Receipts compound_Receipts = db.Compound_Receipts.Find(id);
            if (compound_Receipts == null)
            {
                return HttpNotFound();
            }
            return View(compound_Receipts);
        }

        // POST: Compound_Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Compound_Receipts compound_Receipts = db.Compound_Receipts.Find(id);
            db.Compound_Receipts.Remove(compound_Receipts);
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
