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
    public class MoneyOutgoingsController : BaseAuthController
    {
        private earge_teamDb db = new earge_teamDb();

        // GET: MoneyOutgoings
        public ActionResult Index()
        {
            var moneyOutgoings = db.MoneyOutgoings.Include(m => m.Project).Include(m => m.ProjectTask).Include(m => m.TeamMember).Include(m => m.TeamMember1).Include(m => m.TeamMember2);
            return View(moneyOutgoings.ToList());
        }

        // GET: MoneyOutgoings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyOutgoing moneyOutgoing = db.MoneyOutgoings.Find(id);
            if (moneyOutgoing == null)
            {
                return HttpNotFound();
            }
            return View(moneyOutgoing);
        }

        // GET: MoneyOutgoings/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.TaskId = new SelectList(db.ProjectTasks, "Id", "Title");
            ViewBag.ApprovedMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email");
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            return View();
        }

        // POST: MoneyOutgoings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamMemberId,TaskId,Amount,Notes,CreateUserId,CreateDate,IsApproved,Deleted,ApprovedMemberId,ApprovedDate,ProjectId")] MoneyOutgoing moneyOutgoing)
        {
            if (ModelState.IsValid)
            {
                db.MoneyOutgoings.Add(moneyOutgoing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", moneyOutgoing.ProjectId);
            ViewBag.TaskId = new SelectList(db.ProjectTasks, "Id", "Title", moneyOutgoing.TaskId);
            ViewBag.ApprovedMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.ApprovedMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.CreateUserId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.TeamMemberId);
            return View(moneyOutgoing);
        }

        // GET: MoneyOutgoings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyOutgoing moneyOutgoing = db.MoneyOutgoings.Find(id);
            if (moneyOutgoing == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", moneyOutgoing.ProjectId);
            ViewBag.TaskId = new SelectList(db.ProjectTasks, "Id", "Title", moneyOutgoing.TaskId);
            ViewBag.ApprovedMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.ApprovedMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.CreateUserId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.TeamMemberId);
            return View(moneyOutgoing);
        }

        // POST: MoneyOutgoings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamMemberId,TaskId,Amount,Notes,CreateUserId,CreateDate,IsApproved,Deleted,ApprovedMemberId,ApprovedDate,ProjectId")] MoneyOutgoing moneyOutgoing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneyOutgoing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", moneyOutgoing.ProjectId);
            ViewBag.TaskId = new SelectList(db.ProjectTasks, "Id", "Title", moneyOutgoing.TaskId);
            ViewBag.ApprovedMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.ApprovedMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.CreateUserId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyOutgoing.TeamMemberId);
            return View(moneyOutgoing);
        }

        // GET: MoneyOutgoings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyOutgoing moneyOutgoing = db.MoneyOutgoings.Find(id);
            if (moneyOutgoing == null)
            {
                return HttpNotFound();
            }
            return View(moneyOutgoing);
        }

        // POST: MoneyOutgoings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoneyOutgoing moneyOutgoing = db.MoneyOutgoings.Find(id);
            db.MoneyOutgoings.Remove(moneyOutgoing);
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
