using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Intex.Models;

namespace Intex.Controllers
{
    [Authorize(Roles = "Admin")]

    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {


            return View();
        }
    }
}