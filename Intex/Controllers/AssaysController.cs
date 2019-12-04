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
    [Authorize(Roles = "Customer,Engineer,Admin")]

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
            theTest.Assay_Cost = assays.Base_Price + assays.Employee_Cost;
            db.Work_Order_Assays.Add(theTest);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = workOrderId });
        }
        public ActionResult SeeAssayOnTest(int id)
        {
            workOrderId = id;
            ViewBag.ID = id;
            IEnumerable<Assays> assays =
            db.Database.SqlQuery<Assays>("SELECT *" +
                                        "FROM Assays, Work_Order_Assays, Work_Orders " +
                                        "WHERE Work_Orders.Work_Order_ID = Work_Order_Assays.Work_Order_ID "+
                                        "AND Work_Order_Assays.Assay_ID = Assays.Assay_ID " +
                                        "AND Work_Orders.Work_Order_Id = " + workOrderId);
          
            //need to create a sql statement that takes it out with the id of workorder id
            return View(assays);
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
        public ActionResult Create([Bind(Include = "Assay_ID,Assay_Abbreviation,Assay_Desc,Assay_Duration,Employee_Cost,Base_Price,Assay_Results")] Assays assays)
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
        public ActionResult Edit([Bind(Include = "Assay_ID,Assay_Abbreviation,Assay_Desc,Assay_Duration,Employee_Cost,Base_Price,Assay_Results")] Assays assays)
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
