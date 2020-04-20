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
    public class MoneyIncomesController : BaseAuthController
    {
        private earge_teamDb db = new earge_teamDb();

        // GET: MoneyIncomes
        public ActionResult Index()
        {
            var moneyIncomes = db.MoneyIncomes.Include(m => m.TeamMember).Include(m => m.TeamMember1);
            return View(moneyIncomes.ToList());
        }

        // GET: MoneyIncomes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyIncome moneyIncome = db.MoneyIncomes.Find(id);
            if (moneyIncome == null)
            {
                return HttpNotFound();
            }
            return View(moneyIncome);
        }

        // GET: MoneyIncomes/Create
        public ActionResult Create()
        {
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email");
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email");
            return View();
        }

        // POST: MoneyIncomes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TeamMemberId,Amount,TransactionDate,IsApproved,CreateUserId,CreateDate,Deleted")] MoneyIncome moneyIncome)
        {
            if (ModelState.IsValid)
            {
                db.MoneyIncomes.Add(moneyIncome);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.TeamMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.CreateUserId);
            return View(moneyIncome);
        }

        // GET: MoneyIncomes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyIncome moneyIncome = db.MoneyIncomes.Find(id);
            if (moneyIncome == null)
            {
                return HttpNotFound();
            }
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.TeamMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.CreateUserId);
            return View(moneyIncome);
        }

        // POST: MoneyIncomes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TeamMemberId,Amount,TransactionDate,IsApproved,CreateUserId,CreateDate,Deleted")] MoneyIncome moneyIncome)
        {
            if (ModelState.IsValid)
            {
                db.Entry(moneyIncome).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TeamMemberId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.TeamMemberId);
            ViewBag.CreateUserId = new SelectList(db.TeamMembers, "Id", "Email", moneyIncome.CreateUserId);
            return View(moneyIncome);
        }

        // GET: MoneyIncomes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MoneyIncome moneyIncome = db.MoneyIncomes.Find(id);
            if (moneyIncome == null)
            {
                return HttpNotFound();
            }
            return View(moneyIncome);
        }

        // POST: MoneyIncomes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MoneyIncome moneyIncome = db.MoneyIncomes.Find(id);
            db.MoneyIncomes.Remove(moneyIncome);
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
