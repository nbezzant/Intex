using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using Intex.DAL;
using Intex.Models;

namespace Intex.Controllers
{
    [Authorize(Roles = "Customer,Engineer,Admin")]
    public class Work_OrdersController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        public List<Work_Orders> lstWork_Orders= new List<Work_Orders>();
        public List<Status> lstStatuses = new List<Status>();
        // GET: Work_Orders
        public ActionResult Index()
        {

            Customers cust = db.Customers.FirstOrDefault(p => p.Email == User.Identity.Name);
            if (cust != null)
            {
                ViewBag.Statuses = "";
                lstWork_Orders = db.Work_Orders
               .Where(o => o.Customer_ID == cust.Customer_ID)
               .ToList();


                foreach (Work_Orders order in lstWork_Orders)
                {
                    Status myStatus = db.Statuses.FirstOrDefault(o => o.Status_ID == order.Status_ID);
                    string sStatus = myStatus.Status_Desc;
                    ViewBag.Statuses = ViewBag.Statuses + sStatus + ",";

                }

                return View(lstWork_Orders);
            }
            else
            {
                return View();
            }
           
        }

        // GET: Work_Orders/Details/5
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

        // GET: Work_Orders/Create
        public ActionResult Create()
        {
            Customers cust = db.Customers.FirstOrDefault(p => p.Email == User.Identity.Name);
            ViewBag.QualifyDiscount = cust.Qualify_Discount; 
            return View();
        }

        // POST: Work_Orders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Work_Order_ID,Status_ID,Customer_ID,Instructions,Rush,Conditional_Tests,Price_Quote,Discount,Total_Cost")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                Customers cust = db.Customers.FirstOrDefault(p => p.Email == User.Identity.Name);// get customer

                if(work_Orders.Instructions == null)
                {
                    work_Orders.Instructions = "";
                }
                work_Orders.Customer_ID = cust.Customer_ID;
                work_Orders.Discount = cust.Qualify_Discount;
                work_Orders.Price_Quote = -5;
                work_Orders.Total_Cost = -5;
                work_Orders.Status_ID = 1;// should start by default as like order sent or something at the begining

                db.Work_Orders.Add(work_Orders);
                db.SaveChanges();

                //send confirmation of work order via email

                var senderEmail = new MailAddress("rankIS403@gmail.com", "NorthWest Labs");
                var receiverEmail = new MailAddress(cust.Email, "Receiver");
                var password = "werenumber1";
                var body = "Thank you for submitting your work order! Please attach the following ID to the solution you send: " + work_Orders.Work_Order_ID + ". " + 
                            "You will receive a confirmation when your compound has been received. A price quote will be included.";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "From Northwest Labs Singapore",
                    Body = body + "\n\n" + "Our email if you have any questions: " + senderEmail.Address + "\n"
                }) 
                {
                    smtp.Send(mess);
                }
            
            // this will then take you to which assays you want to add.
            return RedirectToAction("Index","Assays", new {id = work_Orders.Work_Order_ID });
            }

            return View(work_Orders);
        }

        // GET: Work_Orders/Edit/5
        public ActionResult Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Work_Orders work_Orders = db.Work_Orders.Find(id);
            ViewBag.Rush = work_Orders.Rush;
               ViewBag.Discount = work_Orders.Discount;
            if (work_Orders == null)
            {
                return HttpNotFound();
            }
            return View(work_Orders);
        }

        // POST: Work_Orders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Work_Order_ID,Status_ID,Customer_ID,Instructions,Rush,Price_Quote,Discount,Total_Cost")] Work_Orders work_Orders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(work_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(work_Orders);
        }

        // GET: Work_Orders/Delete/5
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

        // POST: Work_Orders/Delete/5
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
