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
    public class Customer_PaymentController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        public static List<string> lstCardTypes = new List<string>()
        {
            "Credit",
            "Debit"
        };
        

        // GET: Customer_Payment/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            if (customer_Payment == null)
            {
                return HttpNotFound();
            }
            return View(customer_Payment);
        }

        // GET: Customer_Payment/Create
        public ActionResult Create()
        {
            ViewBag.CardType = lstCardTypes;
            return View();
        }

        // POST: Customer_Payment/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Customer_Payment_ID,Card_Type,Card_Num,Card_Expiration,Card_CVV")] Customer_Payment customer_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Customer_Payments.Add(customer_Payment);
                db.SaveChanges();
                return RedirectToAction("Home", "Customers", new { area = ""});
            }

            return View(customer_Payment);
        }

        // GET: Customer_Payment/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.CardType = lstCardTypes;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer_Payment customer_Payment = db.Customer_Payments.Find(id);
            if (customer_Payment == null)
            {
                return HttpNotFound();
            }
            return View(customer_Payment);
        }

        // POST: Customer_Payment/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Customer_Payment_ID,Card_Type,Card_Num,Card_Expiration,Card_CVV")] Customer_Payment customer_Payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer_Payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Details", new { id = customer_Payment.Customer_Payment_ID});
            }
            return View(customer_Payment);
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
