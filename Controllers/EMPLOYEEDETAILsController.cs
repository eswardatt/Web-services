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
    public class EMPLOYEEDETAILsController : Controller
    {
        private EMAILTEMPLATESEntities db = new EMAILTEMPLATESEntities();

        // GET: EMPLOYEEDETAILs
        public ActionResult Index()
        {
            var list = db.ASP_BIND_EMPLOYEEDETAILS();
            return View(list);
            
        }

        // GET: EMPLOYEEDETAILs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEDETAIL eMPLOYEEDETAIL = db.EMPLOYEEDETAILS.Find(id);
            if (eMPLOYEEDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEDETAIL);
        }

        // GET: EMPLOYEEDETAILs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EMPLOYEEDETAILs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EMP_EMPLOYEEID,EMP_EMPLOYEENAME,EMP_EMPLOYEEEMAILID,EMP_EMPLOYEEPHONENUMBER,EMP_CREATEDBY,EMP_CREATEDDATE,EMP_UPDATEDDATE,EMP_STATUS,EMP_UPDATEDBY")] EMPLOYEEDETAIL eMPLOYEEDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.EMPLOYEEDETAILS.Add(eMPLOYEEDETAIL);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(eMPLOYEEDETAIL);
        }

        // GET: EMPLOYEEDETAILs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEDETAIL eMPLOYEEDETAIL = db.EMPLOYEEDETAILS.Find(id);
            if (eMPLOYEEDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEDETAIL);
        }

        // POST: EMPLOYEEDETAILs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EMP_EMPLOYEEID,EMP_EMPLOYEENAME,EMP_EMPLOYEEEMAILID,EMP_EMPLOYEEPHONENUMBER,EMP_CREATEDBY,EMP_CREATEDDATE,EMP_UPDATEDDATE,EMP_STATUS,EMP_UPDATEDBY")] EMPLOYEEDETAIL eMPLOYEEDETAIL)
        {
            if (ModelState.IsValid)
            {
                db.Entry(eMPLOYEEDETAIL).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(eMPLOYEEDETAIL);
        }

        // GET: EMPLOYEEDETAILs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EMPLOYEEDETAIL eMPLOYEEDETAIL = db.EMPLOYEEDETAILS.Find(id);
            if (eMPLOYEEDETAIL == null)
            {
                return HttpNotFound();
            }
            return View(eMPLOYEEDETAIL);
        }

        // POST: EMPLOYEEDETAILs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            //EMPLOYEEDETAIL eMPLOYEEDETAIL = db.EMPLOYEEDETAILS.Find(id);
            //db.EMPLOYEEDETAILS.Remove(eMPLOYEEDETAIL);
            db.ASP_DELETE_EMPLOYEE(eMP_EMPLOYEEID: id);
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
