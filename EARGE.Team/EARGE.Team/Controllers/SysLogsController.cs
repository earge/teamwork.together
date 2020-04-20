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
    public class SysLogsController : BaseAuthController {
        private earge_teamDb db = new earge_teamDb();

        // GET: SysLogs
        public ActionResult Index()
        {
            var sysLogs = db.SysLogs.Include(s => s.SysLogType).Include(s => s.TeamMember);
            return View(sysLogs.ToList());
        }

        // GET: SysLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLog sysLog = db.SysLogs.Find(id);
            if (sysLog == null)
            {
                return HttpNotFound();
            }
            return View(sysLog);
        }

        // GET: SysLogs/Create
        public ActionResult Create()
        {
            ViewBag.LogTypeId = new SelectList(db.SysLogTypes, "Id", "Name");
            ViewBag.LogCreatedByMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            return View();
        }

        // POST: SysLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CreateDate,LogTypeId,LogCreatedByMemberId,TargetObjectId")] SysLog sysLog)
        {
            if (ModelState.IsValid)
            {
                db.SysLogs.Add(sysLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LogTypeId = new SelectList(db.SysLogTypes, "Id", "Name", sysLog.LogTypeId);
            ViewBag.LogCreatedByMemberId = new SelectList(db.TeamMembers, "Id", "Email", sysLog.LogCreatedByMemberId);
            return View(sysLog);
        }

        // GET: SysLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLog sysLog = db.SysLogs.Find(id);
            if (sysLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.LogTypeId = new SelectList(db.SysLogTypes, "Id", "Name", sysLog.LogTypeId);
            ViewBag.LogCreatedByMemberId = new SelectList(db.TeamMembers, "Id", "Email", sysLog.LogCreatedByMemberId);
            return View(sysLog);
        }

        // POST: SysLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CreateDate,LogTypeId,LogCreatedByMemberId,TargetObjectId")] SysLog sysLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LogTypeId = new SelectList(db.SysLogTypes, "Id", "Name", sysLog.LogTypeId);
            ViewBag.LogCreatedByMemberId = new SelectList(db.TeamMembers, "Id", "Email", sysLog.LogCreatedByMemberId);
            return View(sysLog);
        }

        // GET: SysLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SysLog sysLog = db.SysLogs.Find(id);
            if (sysLog == null)
            {
                return HttpNotFound();
            }
            return View(sysLog);
        }

        // POST: SysLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SysLog sysLog = db.SysLogs.Find(id);
            db.SysLogs.Remove(sysLog);
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
