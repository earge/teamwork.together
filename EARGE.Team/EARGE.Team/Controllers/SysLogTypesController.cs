using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EARGE.DataLayer;

namespace EARGE.Team.Controllers
{
    public class SysLogTypesController : BaseAuthController {
        private earge_teamDb db = new earge_teamDb();

        // GET: SysLogTypes
        public ActionResult Index()
        {
            return View(db.SysLogTypes.ToList());
        }

        // GET: SysLogTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLogType sysLogType = db.SysLogTypes.Find(id);
            if (sysLogType == null)
            {
                return HttpNotFound();
            }
            return View(sysLogType);
        }

        // GET: SysLogTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SysLogTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] SysLogType sysLogType)
        {
            if (ModelState.IsValid)
            {
                db.SysLogTypes.Add(sysLogType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysLogType);
        }

        // GET: SysLogTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLogType sysLogType = db.SysLogTypes.Find(id);
            if (sysLogType == null)
            {
                return HttpNotFound();
            }
            return View(sysLogType);
        }

        // POST: SysLogTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SysLogType sysLogType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysLogType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysLogType);
        }

        // GET: SysLogTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLogType sysLogType = db.SysLogTypes.Find(id);
            if (sysLogType == null)
            {
                return HttpNotFound();
            }
            return View(sysLogType);
        }

        // POST: SysLogTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysLogType sysLogType = db.SysLogTypes.Find(id);
            db.SysLogTypes.Remove(sysLogType);
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
