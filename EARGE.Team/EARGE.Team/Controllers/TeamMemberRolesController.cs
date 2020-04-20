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
    public class TeamMemberRolesController : BaseAuthController {
        private earge_teamDb db = new earge_teamDb();

        // GET: TeamMemberRoles
        public ActionResult Index()
        {
            var teamMemberRoles = db.TeamMemberRoles.Include(t => t.Role).Include(t => t.TeamMember);
            return View(teamMemberRoles.ToList());
        }

        // GET: TeamMemberRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMemberRole teamMemberRole = db.TeamMemberRoles.Find(id);
            if (teamMemberRole == null)
            {
                return HttpNotFound();
            }
            return View(teamMemberRole);
        }

        // GET: TeamMemberRoles/Create
        public ActionResult Create()
        {
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName");
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            return View();
        }

        // POST: TeamMemberRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamMemberId,RoleId")] TeamMemberRole teamMemberRole)
        {
            if (ModelState.IsValid)
            {
                db.TeamMemberRoles.Add(teamMemberRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", teamMemberRole.RoleId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", teamMemberRole.TeamMemberId);
            return View(teamMemberRole);
        }

        // GET: TeamMemberRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMemberRole teamMemberRole = db.TeamMemberRoles.Find(id);
            if (teamMemberRole == null)
            {
                return HttpNotFound();
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", teamMemberRole.RoleId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", teamMemberRole.TeamMemberId);
            return View(teamMemberRole);
        }

        // POST: TeamMemberRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamMemberId,RoleId")] TeamMemberRole teamMemberRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teamMemberRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RoleId = new SelectList(db.Roles, "Id", "RoleName", teamMemberRole.RoleId);
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", teamMemberRole.TeamMemberId);
            return View(teamMemberRole);
        }

        // GET: TeamMemberRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TeamMemberRole teamMemberRole = db.TeamMemberRoles.Find(id);
            if (teamMemberRole == null)
            {
                return HttpNotFound();
            }
            return View(teamMemberRole);
        }

        // POST: TeamMemberRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TeamMemberRole teamMemberRole = db.TeamMemberRoles.Find(id);
            db.TeamMemberRoles.Remove(teamMemberRole);
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
