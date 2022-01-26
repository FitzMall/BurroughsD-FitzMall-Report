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

        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?KeyWordSearch=" + keywordSearch + "&Sort=&inventoryGrid_length=10&UseCriteria=true");
        }
        // GET: InventoryNotOnFitzMall_USED_Report
        public ActionResult Index()
        {
            return View(db.InventoryNotOnFitzMall_USED_Report.ToList());
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
