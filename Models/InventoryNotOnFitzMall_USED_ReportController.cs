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

        public ActionResult ExportToExcel()
        {

            string ExcelOutput = "";

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "InventoryNotOnFitzMallUSED.csv",
                Inline = false
            };

            var SORTED_InventoryNotOnFitzMallReport = from sDD_init in db.InventoryNotOnFitzMall_USED_Report.OrderBy(a => a.STOREBRANCH)
                                                      select sDD_init;

            //            IQueryable queryableReport =  SORTED_InventoryNotOnFitzMallReport.AsQueryable();

            // load the results for possible Excel export 

            ExcelOutput += ("STOREBRANCH" + ",");
            ExcelOutput += ("ActuallyOnWebSite_1" + ",");
            ExcelOutput += ("ActuallyOnWebSite_2" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_1" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_2" + ",");
            ExcelOutput += "\r\n";

            foreach (var result in SORTED_InventoryNotOnFitzMallReport)

            {
                ExcelOutput += (result.STOREBRANCH.Replace("/", "_") + ",");
                ExcelOutput += (result.ActuallyOnWebSite_1 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_2 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_1 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_2 + ",");
                ExcelOutput += "\r\n";


            }


            Response.AddHeader("Content-Disposition", cd.ToString());

            return Content(ExcelOutput);
        }



        public ActionResult InventoryNotOnFitzMall_USEDReport()
        {
            return View(db.InventoryNotOnFitzMall_USED_Report.OrderBy(a => a.STOREBRANCH).ToList());
        }

        public ActionResult DrillDown(string StoreBranch, string StatusCode, string OnFitzMall)
        {
            int parStatusCode;
            StoreBranch = ("" + StoreBranch);
            StoreBranch = StoreBranch.Trim();

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
