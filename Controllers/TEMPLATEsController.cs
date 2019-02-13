using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using emails.Models;

namespace emails.Controllers
{
    public class TEMPLATEsController : Controller
    {
        private EMAILTEMPLATESEntities db = new EMAILTEMPLATESEntities();

        // GET: TEMPLATEs
        public ActionResult Index()
        {
            return View(db.TEMPLATES.ToList());
        }

        // GET: TEMPLATEs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPLATE tEMPLATE = db.TEMPLATES.Find(id);
            if (tEMPLATE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPLATE);
        }

        // GET: TEMPLATEs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEMPLATEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TMP_SNO,TMP_TEMPLATENAME,TMP_SROURCECODE,TMP_CREATEDBY,TMP_CREATEDDATE,TMP_UPDATEDBY,TMP_UPDATEDDATE,TMP_STATUS")] TEMPLATE tEMPLATE)
        {
            if (ModelState.IsValid)
            {
                db.TEMPLATES.Add(tEMPLATE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEMPLATE);
        }

        // GET: TEMPLATEs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPLATE tEMPLATE = db.TEMPLATES.Find(id);
            if (tEMPLATE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPLATE);
        }

        // POST: TEMPLATEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TMP_SNO,TMP_TEMPLATENAME,TMP_SROURCECODE,TMP_CREATEDBY,TMP_CREATEDDATE,TMP_UPDATEDBY,TMP_UPDATEDDATE,TMP_STATUS")] TEMPLATE tEMPLATE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEMPLATE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEMPLATE);
        }

        // GET: TEMPLATEs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEMPLATE tEMPLATE = db.TEMPLATES.Find(id);
            if (tEMPLATE == null)
            {
                return HttpNotFound();
            }
            return View(tEMPLATE);
        }

        // POST: TEMPLATEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEMPLATE tEMPLATE = db.TEMPLATES.Find(id);
            db.TEMPLATES.Remove(tEMPLATE);
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
