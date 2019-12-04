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
    public class AssaysController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        public static int workOrderId = -5;
        // GET: Assays
        public ActionResult Index(int id)
        {
            workOrderId = id;
            return View(db.Assays.ToList());  
        }

        public ActionResult add2Test(int? id)
        {
            ViewBag.ID = id;
            Assays assays = db.Assays.Find(id);
            Work_Order_Assays theTest = new Work_Order_Assays();
            theTest.Work_Order_ID = workOrderId;
            theTest.Assay_ID = assays.Assay_ID;
            theTest.Assay_Cost = -5;
            db.Work_Order_Assays.Add(theTest);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = workOrderId });
        }
        public ActionResult SeeAssayOnTest()
        {
            Work_Order_Assays myWork_Order_Assays = db.Work_Order_Assays.FirstOrDefault(o => o.Work_Order_ID == workOrderId);
            lstAssays = db.Assays
                .Where(o => o.Assay_ID == myWork_Order_Assays.Assay_ID)
                .ToList();

            //need to create a sql statement that takes it out with the id of workorder id
            return View(lstAssays);
        }
        // GET: Assays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assays.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            return View(assays);
        }
        public int Work_Order_Id = -5;
        // GET: Assays/Create
        public ActionResult Create()
        { 
            return View();
        }

        // POST: Assays/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Assay_ID,Assay_Desc,Assay_Duration")] Assays assays)
        {
            if (ModelState.IsValid)
            {
                assays.Employee_Cost = 40;
                db.Assays.Add(assays);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = workOrderId });
            }

            return RedirectToAction("Index", new { id = workOrderId });
        }

        // GET: Assays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assays.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            return View(assays);
        }

        // POST: Assays/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Assay_ID,Assay_Desc,Assay_Duration,Employee_Cost")] Assays assays)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assays).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(assays);
        }

        // GET: Assays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Assays assays = db.Assays.Find(id);
            if (assays == null)
            {
                return HttpNotFound();
            }
            return View(assays);
        }

        // POST: Assays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Assays assays = db.Assays.Find(id);
            db.Assays.Remove(assays);
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
