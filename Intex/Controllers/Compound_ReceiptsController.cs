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
    [Authorize(Roles = "Engineer,Admin")]
    public class Compound_ReceiptsController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();

        // GET: Compound_Receipts
        public ActionResult Index()
        {
            return View(db.Compound_Receipts.ToList());
        }

        public ActionResult ListWork_Orders()
        {
            return View(db.Work_Orders.ToList());
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
                if (db.Work_Orders.Find(compound_Receipts.Work_Order_ID) != null)
                {
                    if (compound_Receipts.Date_Arrived != null)
                    {
                        IEnumerable<Customers> receipt =
             db.Database.SqlQuery<Customers>("select distinct Customers.Customer_ID, customers.First_Name, Customers.Last_Name, customers.Street_Address, Customers.City, customers.State, Customers.Phone, Customers.Email, customers.Qualify_Discount, Customers.Password, customers.User_Role_ID " +
                                         "FROM Customers " +
                                         "inner join Work_Orders on " +
                                         "Work_Orders.Customer_ID = Customers.Customer_ID " +
                                         "inner join Compound_Receipts on " +
                                         "Work_Orders.Work_Order_ID = Compound_Receipts.Work_Order_ID " +
                                         "where Work_Orders.Work_Order_ID = " + compound_Receipts.Work_Order_ID);
                        Customers cust = db.Customers.FirstOrDefault(p => p.Email == User.Identity.Name);
                        List<Customers> listReceipt = receipt.ToList();
                        Customers firstReceipt = listReceipt.First();
                        var senderEmail = new MailAddress("rankIS403@gmail.com", "Northwest Labs");
                        var receiverEmail = new MailAddress(firstReceipt.Email, "Receiver");
                        var password = "werenumber1";
                        var body = "Your Order has been received in Singapore on date: " + compound_Receipts.Date_Arrived + ". We will begin working on the tests as soon as possible.";
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
                            Body = "Our email if you have any questions: " + senderEmail.Address + "\n" + "Message: " + body
                        })
                        {
                            smtp.Send(mess);
                        }
                        {// stuff to change date of due for stuff
                            if( compound_Receipts.Date_Due != null)
                            {
                                IEnumerable<SortingworkOrders> date = db.SortingWorkOrders
                                .Where(o => o.Work_Order_ID == compound_Receipts.Work_Order_ID);

                                List<SortingworkOrders> newDate = date.ToList();
                                foreach (SortingworkOrders ordere in newDate)
                                {

                                    ordere.Date_Due = compound_Receipts.Date_Due;
                                   // db.SortingWorkOrders.FirstOrDefault(p => p.Database_Number == lastOne.Database_Number).Date_Due = compound_Receipts.Date_Due;
                                    db.SaveChanges();
                                }
                                
                            }
                        }
                    }
                }
          
                
                return RedirectToAction("Index");
            }
            ViewBag.error = "ERROR: Make sure your work order id is correct.";
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
        public ActionResult Edit([Bind(Include = "Compound_Receipt_ID,LT,Compound_Sequence_Code,Compound_Name,Quantity,Date_Arrived,Received_By,Date_Due,Appearance,Indicated_Weight,Molecular_Mass,Actual_Weight,MTD,Confirmation_Date,Confirmation_Time,Work_Order_ID")] Compound_Receipts compound_Receipts)
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
