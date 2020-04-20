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
    public class ProjectTasksController : BaseAuthController
    {
        private earge_teamDb db = new earge_teamDb();

        // GET: ProjectTasks
        public ActionResult Index()
        {
            var projectTasks = db.ProjectTasks.Include(p => p.Project).Include(p => p.TaskStatus).Include(p => p.TeamMember);
            return View(projectTasks.ToList());
        }

        // GET: ProjectTasks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        // GET: ProjectTasks/Create
        public ActionResult Create()
        {
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name");
            ViewBag.StatusId = new SelectList(db.TaskStatuses, "Id", "Name");
            ViewBag.AssignedMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            return View();
        }

        // POST: ProjectTasks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Description,PublishedDate,AssignedMemberId,TargetGroups,StatusId,AssignedDate,CompletedDate,HoursEffort,ProjectId,BudgetAmount,Notes")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.ProjectTasks.Add(projectTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.StatusId = new SelectList(db.TaskStatuses, "Id", "Name", projectTask.StatusId);
            ViewBag.AssignedMemberId = new SelectList(db.TeamMembers, "Id", "Email", projectTask.AssignedMemberId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.StatusId = new SelectList(db.TaskStatuses, "Id", "Name", projectTask.StatusId);
            ViewBag.AssignedMemberId = new SelectList(db.TeamMembers, "Id", "Email", projectTask.AssignedMemberId);
            return View(projectTask);
        }

        // POST: ProjectTasks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Description,PublishedDate,AssignedMemberId,TargetGroups,StatusId,AssignedDate,CompletedDate,HoursEffort,ProjectId,BudgetAmount,Notes")] ProjectTask projectTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(projectTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProjectId = new SelectList(db.Projects, "Id", "Name", projectTask.ProjectId);
            ViewBag.StatusId = new SelectList(db.TaskStatuses, "Id", "Name", projectTask.StatusId);
            ViewBag.AssignedMemberId = new SelectList(db.TeamMembers, "Id", "Email", projectTask.AssignedMemberId);
            return View(projectTask);
        }

        // GET: ProjectTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            if (projectTask == null)
            {
                return HttpNotFound();
            }
            return View(projectTask);
        }

        // POST: ProjectTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProjectTask projectTask = db.ProjectTasks.Find(id);
            db.ProjectTasks.Remove(projectTask);
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
