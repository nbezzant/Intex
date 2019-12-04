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
    public class deletethisController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: deletethis
        public ActionResult Index()
        {
            return View(db.Work_Orders.ToList());
        }

        // GET: deletethis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.Work_Orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // GET: deletethis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: deletethis/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Work_Order_ID,Status_ID,Customer_ID,Instructions,Rush,Conditional_Tests,Price_Quote,Discount,Total_Cost")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Work_Orders.Add(work_Orders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(work_Orders);
        }

        // GET: deletethis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.Work_Orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // POST: deletethis/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Work_Order_ID,Status_ID,Customer_ID,Instructions,Rush,Conditional_Tests,Price_Quote,Discount,Total_Cost")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Orders);
        }

        // GET: deletethis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.Work_Orders.Find(id);
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // POST: deletethis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Work_Orders work_Orders = db.Work_Orders.Find(id);
            db.Work_Orders.Remove(work_Orders);
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
