using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Views
{
    public class InventoryNotOnFitzMall_USED_ReportController : Controller
    {
        private InventoryEntities1 db = new InventoryEntities1();

        // GET: InventoryNotOnFitzMall_USED_Report
        public ActionResult Index()
        {
            return View(db.InventoryNotOnFitzMall_USED_Report.ToList());
        }

        public ActionResult PrintableReport()
        {
            return View(db.InventoryNotOnFitzMall_USED_Report.OrderBy(a => a.STOREBRANCH).ToList());
        }

        public ActionResult InventoryNotOnFitzMall_USEDReport()
        {
            return View(db.InventoryNotOnFitzMall_USED_Report.OrderBy(a => a.STOREBRANCH).ToList());
        }

        public ActionResult DrillDown_AllStatus(string StoreBranch, string OnFitzMall)
        {

            if (OnFitzMall == "1")
            {
                return RedirectToAction("DrillDown", "InventoryReportDrillDowns", new { StoreBranch = StoreBranch,  NewOrUsed = "U" });
            }
            else
            {
                return RedirectToAction("DrillDown_AllStatus", "NotOnFitzMall_USED", new { StoreBranch = StoreBranch });
            }

        }

        public ActionResult DrillDown_AllLocations(string StatusCode, string OnFitzMall)
        {
            if (OnFitzMall == "1")
            {
                return RedirectToAction("DrillDown_AllLocationsUsed", "InventoryReportDrillDowns", new { StatusCode = StatusCode, NewOrUsed = "U" });
            }
            else
            {
                return RedirectToAction("DrillDown_AllLocations", "NotOnFitzMall_USED", new { Status = StatusCode, NewOrUsed = "U" });
            }
        }


        public ActionResult DrillDown(string StoreBranch, string StatusCode, string OnFitzMall)
        {
            int parStatusCode;

            if (StatusCode == "ALL")
            {
                parStatusCode = 0;
            }
            else
            {
                parStatusCode = Convert.ToInt16(StatusCode);
            };

            if (OnFitzMall == "1")
            {
                return RedirectToAction("DrillDown", "InventoryReportDrillDowns", new { StoreBranch = StoreBranch, StatusCode = parStatusCode, NewOrUsed = "U" });
            }
            else
            {
                return RedirectToAction("DrillDown", "NotOnFitzMall_USED", new {  StoreBranch = StoreBranch, StatusCode = parStatusCode, NewOrUsed = "U" });
            }

        }


        // GET: InventoryNotOnFitzMall_USED_Report/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report = db.InventoryNotOnFitzMall_USED_Report.Find(id);
            if (inventoryNotOnFitzMall_USED_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_USED_Report);
        }

        // GET: InventoryNotOnFitzMall_USED_Report/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryNotOnFitzMall_USED_Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STOREBRANCH,LOCATION,MAKE,ShouldBeOnWebSite_1,ShouldBeOnWebSite_2,FM_TotalAllCarStat,ActuallyOnWebSite_1,ActuallyOnWebSite_2,ActuallyOnWebSite_TotalAllCarStat,Id_Primary")] InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report)
        {
            if (ModelState.IsValid)
            {
                db.InventoryNotOnFitzMall_USED_Report.Add(inventoryNotOnFitzMall_USED_Report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryNotOnFitzMall_USED_Report);
        }

        // GET: InventoryNotOnFitzMall_USED_Report/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report = db.InventoryNotOnFitzMall_USED_Report.Find(id);
            if (inventoryNotOnFitzMall_USED_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_USED_Report);
        }

        // POST: InventoryNotOnFitzMall_USED_Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STOREBRANCH,LOCATION,ShouldBeOnWebSite_1,ShouldBeOnWebSite_2,FM_TotalAllCarStat,ActuallyOnWebSite_1,ActuallyOnWebSite_2,ActuallyOnWebSite_TotalAllCarStat,Id_Primary")] InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryNotOnFitzMall_USED_Report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryNotOnFitzMall_USED_Report);
        }

        // GET: InventoryNotOnFitzMall_USED_Report/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report = db.InventoryNotOnFitzMall_USED_Report.Find(id);
            if (inventoryNotOnFitzMall_USED_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_USED_Report);
        }

        // POST: InventoryNotOnFitzMall_USED_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryNotOnFitzMall_USED_Report inventoryNotOnFitzMall_USED_Report = db.InventoryNotOnFitzMall_USED_Report.Find(id);
            db.InventoryNotOnFitzMall_USED_Report.Remove(inventoryNotOnFitzMall_USED_Report);
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
