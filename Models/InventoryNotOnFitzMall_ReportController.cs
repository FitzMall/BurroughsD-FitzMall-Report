using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using ClosedXML.Excel;

//using ExportExcelDemo.Models;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication6.Models
{
    public class InventoryNotOnFitzMall_ReportController : Controller
    {

        private InventoryEntities1 db = new InventoryEntities1();

        // GET: InventoryNotOnFitzMall_Report
        public ActionResult Index()
        {
            return View(db.InventoryNotOnFitzMall_Report.ToList());

        }

              // GET: InventoryNotOnFitzMall_Report
        public ActionResult InventoryNotOnFitzMallReport()
        {
            

            return View(db.InventoryNotOnFitzMall_Report.OrderBy(a => a.STOREBRANCH + a.MAKE).ToList());
        }

       public ActionResult DrillDown(string StoreBranch, string Make, string StatusCode, string OnFitzMall)
        {
            int parStatusCode;

            Make = ("" + Make);
            Make = (Make.Trim());
            StatusCode = ("" + StatusCode);
            StatusCode = (StatusCode.Trim());
            OnFitzMall = ("" + OnFitzMall);
            OnFitzMall = (OnFitzMall.Trim());
            StoreBranch = ("" + StoreBranch);
            StoreBranch = StoreBranch.Trim();
            StatusCode = StatusCode.Trim();

            if (StatusCode == "")
            {
                StatusCode = "ALL";
            }
            
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
                return RedirectToAction("DrillDown", "InventoryReportDrillDowns", new { Make = Make.ToUpper(), StoreBranch = StoreBranch, StatusCode = parStatusCode, NewOrUsed = "N" });
            }
            else
            {
                return RedirectToAction("DrillDown", "NotOnFitzMalls", new { Make = Make.ToUpper(), StoreBranch = StoreBranch, StatusCode = parStatusCode, NewOrUsed = "N" });
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

        public ActionResult ExportToExcel()
        {

            string ExcelOutput ="";

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "InventoryNotOnFitzMall.csv",
                Inline = false
            };

            var SORTED_InventoryNotOnFitzMallReport = from sDD_init in db.InventoryNotOnFitzMall_Report.OrderBy(a => a.STOREBRANCH)
                                                      select sDD_init;

            //            IQueryable queryableReport =  SORTED_InventoryNotOnFitzMallReport.AsQueryable();

            // load the results for possible Excel export 

            ExcelOutput += ("STOREBRANCH" + ",");
            ExcelOutput += ("LOCATION" + ",");
            ExcelOutput += ("MAKE" + ",");
            ExcelOutput += ("ActuallyOnWebSite_1" + ",");
            ExcelOutput += ("ActuallyOnWebSite_2" + ",");
            ExcelOutput += ("ActuallyOnWebSite_4" + ",");
            ExcelOutput += ("ActuallyOnWebSite_9" + ",");
            ExcelOutput += ("ActuallyOnWebSite_12" + ",");
            ExcelOutput += ("ActuallyOnWebSite_14" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_1" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_2" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_4" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_9" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_12" + ",");
            ExcelOutput += ("ShouldBeOnWebSite_14" + ",");
            ExcelOutput += "\r\n";

            foreach (var result in SORTED_InventoryNotOnFitzMallReport)

            {
                ExcelOutput += (result.STOREBRANCH.Replace("/","_") + ",");
                ExcelOutput += (result.LOCATION + ",");
                ExcelOutput += (result.MAKE + ",");
                ExcelOutput += (result.ActuallyOnWebSite_1 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_2 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_4 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_9 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_12 + ",");
                ExcelOutput += (result.ActuallyOnWebSite_14 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_1 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_2 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_4 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_9 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_12 + ",");
                ExcelOutput += (result.ShouldBeOnWebSite_14 + ",");
                ExcelOutput += "\r\n";

                System.Diagnostics.Debug.WriteLine("" + result.STOREBRANCH + " " + result.LOCATION + " " + result.MAKE);
                
            }


            Response.AddHeader("Content-Disposition", cd.ToString());

            return Content(ExcelOutput);
        }


    }
}
