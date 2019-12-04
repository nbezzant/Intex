﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Intex.Models;
using Intex.DAL;
using System.Net;
using System.Data.Entity;

namespace Intex.Controllers
{
    [Authorize(Roles ="Engineer,Admin")]
    public class EngineerController : Controller
    {
        private NorthwestLabsContext db = new NorthwestLabsContext();
        // GET: Engineer
        public ActionResult Index()
        {
            return View();
        }
        //inside here will be materials edits and stuff.

        // GET: Materials
        public ActionResult ListMaterials()
        {
            return View(db.Materials.ToList());
        }

        // GET: Materials/Details/5
        public ActionResult DetailsMaterial(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // GET: Materials/Create
        public ActionResult CreateMaterial()
        {
            return View();
        }

        // POST: Materials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateMaterial([Bind(Include = "Material_ID,Material_Name")] Materials materials)
        {
            if (ModelState.IsValid)
            {
                db.Materials.Add(materials);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(materials);
        }

        // GET: Materials/Edit/5
        public ActionResult EditMaterial(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // POST: Materials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditMaterial([Bind(Include = "Material_ID,Material_Name")] Materials materials)
        {
            if (ModelState.IsValid)
            {
                db.Entry(materials).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(materials);
        }

        // GET: Materials/Delete/5
        public ActionResult DeleteMaterial(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Materials materials = db.Materials.Find(id);
            if (materials == null)
            {
                return HttpNotFound();
            }
            return View(materials);
        }

        // POST: Materials/Delete/5
        [HttpPost, ActionName("DeleteMaterial")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Materials materials = db.Materials.Find(id);
            db.Materials.Remove(materials);
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