using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication6.Models
{

    public class ReportInventoriesController : Controller
    {
        private InventoryEntities db = new InventoryEntities();

        // GET: ReportInventories
        public ActionResult Index()
        {
            return View(db.ReportInventories.ToList());
        }

        // GET: ReportInventories
        public ActionResult Inventory_Report()
        {
            return View(db.ReportInventories.ToList());
        }

        // GET: ReportInventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInventory reportInventory = db.ReportInventories.Find(id);
            if (reportInventory == null)
            {
                return HttpNotFound();
            }
            return View(reportInventory);
        }

        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Location, string Make, string StatusCode)
        {
            //            return View(db.ReportInventories.ToList().Where(d => d.MAKE == Make && d.STOREBRANCH == StoreBranch));

            return RedirectToAction("DrillDown", "Inventories", new { Make = Make, StoreBranch = StoreBranch });

        }

        // GET: ReportInventories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ReportInventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NEWUSED,STOREBRANCH,LOCATION,MAKE,CarStat1,CarStat2,CarStat4,CarStat9,CarStat12,CarStat14,TotalAllCarStat,Id_Primary")] ReportInventory reportInventory)
        {
            if (ModelState.IsValid)
            {
                db.ReportInventories.Add(reportInventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(reportInventory);
        }

        // GET: ReportInventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInventory reportInventory = db.ReportInventories.Find(id);
            if (reportInventory == null)
            {
                return HttpNotFound();
            }
            return View(reportInventory);
        }

        // POST: ReportInventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NEWUSED,STOREBRANCH,LOCATION,MAKE,CarStat1,CarStat2,CarStat4,CarStat9,CarStat12,CarStat14,TotalAllCarStat,Id_Primary")] ReportInventory reportInventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportInventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(reportInventory);
        }

        // GET: ReportInventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportInventory reportInventory = db.ReportInventories.Find(id);
            if (reportInventory == null)
            {
                return HttpNotFound();
            }
            return View(reportInventory);
        }

        // POST: ReportInventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportInventory reportInventory = db.ReportInventories.Find(id);
            db.ReportInventories.Remove(reportInventory);
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
