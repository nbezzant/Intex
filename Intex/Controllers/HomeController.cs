using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Intex.Models;
using Intex.DAL;

namespace Intex.Controllers
{
    public class HomeController : Controller
    {

        private NorthwestLabsContext db = new NorthwestLabsContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(FormCollection form, bool rememberMe = false)
        {
            String email = form["Email address"].ToString();
            String password = form["Password"].ToString();


            if (db.Customers.FirstOrDefault(p=> p.Email == email && p.Password == password)!= null)
            {
                FormsAuthentication.SetAuthCookie(email, rememberMe);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Incorrect username or password. Please try again.";
                return View();
            }
        }

    }
}