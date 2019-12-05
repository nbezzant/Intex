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
        public static List<Work_Orders> lstWork_Orders= new List<Work_Orders>();
        public static List<Status> lstStatuses = new List<Status>();
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
                    IEnumerable<Work_Order_Assays> assays =
               db.Database.SqlQuery<Work_Order_Assays>("select Work_Order_Assay_ID, Work_Order_Assays.Work_Order_ID,Work_Order_Assays.Assay_Cost,Work_Order_Assays.Assay_ID,Work_Order_Assays.Assay_Results " +
               "from Work_Order_Assays " +
               "Where Work_order_Assays.Work_Order_ID = " + order.Work_Order_ID);
                    List<Work_Order_Assays> myList = assays.ToList();
                    double totalPrice = 0;
                    foreach(Work_Order_Assays thing in myList)
                    {
                        totalPrice += thing.Assay_Cost;
                    }
                    if (order.Rush)
                    {
                        totalPrice = totalPrice * 1.15;
                    }
                    if(order.Discount)
                    {
                        totalPrice = totalPrice - totalPrice * .15;
                    }
                    order.Price_Quote = totalPrice;
                    if (order.Conditional_Tests)
                    {
                        totalPrice = totalPrice + totalPrice * .5;
                    }
                    order.Total_Cost = totalPrice;
                    Status myStatus = db.Statuses.FirstOrDefault(o => o.Status_ID == order.Status_ID);
                    string sStatus = myStatus.Status_Desc;
                    ViewBag.Statuses = ViewBag.Statuses + sStatus + ",";
                 
                        db.Work_Orders.Find(order.Work_Order_ID).Total_Cost = totalPrice;
                    db.Work_Orders.Find(order.Work_Order_ID).Price_Quote = order.Price_Quote;
                    db.SaveChanges();
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

            Status myStatus = db.Statuses.FirstOrDefault(o => o.Status_ID == work_Orders.Status_ID);
            ViewBag.myStatus = myStatus.Status_Desc;

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
            Status myStatus = db.Statuses.FirstOrDefault(o => o.Status_ID == work_Orders.Status_ID);
            ViewBag.myStatus = myStatus.Status_Desc;
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
        public ActionResult Edit([Bind(Include = "Work_Order_ID,Status_ID,Customer_ID,Instructions,Rush,Conditional_Tests,Price_Quote,Discount,Total_Cost")] Work_Orders work_Orders)
        {
            work_Orders.Status_ID = 1; //reset status after changes
            work_Orders.Customer_ID = db.Customers.FirstOrDefault(p => p.Email == User.Identity.Name).Customer_ID;
            if (ModelState.IsValid)
            {
                db.Entry(work_Orders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index","Work_Orders");
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
