using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCBoard.Models;

namespace MVCBoard.Views
{
    public class PublicHolidaysController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PublicHolidays
        public ActionResult Index()
        {
            return View(db.PublicHolidays.ToList());
        }

        // GET: PublicHolidays/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicHoliday publicHoliday = db.PublicHolidays.Find(id);
            if (publicHoliday == null)
            {
                return HttpNotFound();
            }
            return View(publicHoliday);
        }

        // GET: PublicHolidays/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PublicHolidays/Create
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,Desc,Start_Date,End_Date")] PublicHoliday publicHoliday)
        {
            if (ModelState.IsValid)
            {
                db.PublicHolidays.Add(publicHoliday);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(publicHoliday);
        }

        // GET: PublicHolidays/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicHoliday publicHoliday = db.PublicHolidays.Find(id);
            if (publicHoliday == null)
            {
                return HttpNotFound();
            }
            return View(publicHoliday);
        }

        // POST: PublicHolidays/Edit/5
        // 초과 게시 공격으로부터 보호하려면 바인딩하려는 특정 속성을 사용하도록 설정하십시오. 
        // 자세한 내용은 https://go.microsoft.com/fwlink/?LinkId=317598을(를) 참조하십시오.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,Desc,Start_Date,End_Date")] PublicHoliday publicHoliday)
        {
            if (ModelState.IsValid)
            {
                db.Entry(publicHoliday).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(publicHoliday);
        }

        // GET: PublicHolidays/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PublicHoliday publicHoliday = db.PublicHolidays.Find(id);
            if (publicHoliday == null)
            {
                return HttpNotFound();
            }
            return View(publicHoliday);
        }

        // POST: PublicHolidays/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PublicHoliday publicHoliday = db.PublicHolidays.Find(id);
            db.PublicHolidays.Remove(publicHoliday);
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
