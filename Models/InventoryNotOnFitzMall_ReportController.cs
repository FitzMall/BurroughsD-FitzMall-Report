﻿using System;
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

        // GET: InventoryNotOnFitzMall_Report/Details/5

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report = db.InventoryNotOnFitzMall_Report.Find(id);
            if (inventoryNotOnFitzMall_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_Report);
        }

        // GET: InventoryNotOnFitzMall_Report/Create
        public ActionResult Create()
        {
            return View();
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
            StatusCode = ("" + StatusCode);
            OnFitzMall = ("" + OnFitzMall);
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

        public ActionResult DrillDown_AllLocationsNew(string Make, string StatusCode, string OnFitzMall)
        {
            int parStatusCode;

            Make = ("" + Make);
            StatusCode = ("" + StatusCode);
            OnFitzMall = ("" + OnFitzMall);

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
                return RedirectToAction("DrillDown_AllLocationsNew", "InventoryReportDrillDowns", new { Make = Make.ToUpper(), StatusCode = parStatusCode, NewOrUsed = "N" });
            }
            else
            {
                return RedirectToAction("DrillDown_AllLocations", "NotOnFitzMalls", new { Make = Make.ToUpper(), Status = parStatusCode, NewOrUsed = "N" });
            }

        }

        public ActionResult DrillDown_AllStatusNew(string StoreBranch, string Location, string Make, string StatusCode, string OnFitzMall)
        {
            int parStatusCode;

            Location = ("" + Location);
            Make = ("" + Make);
            StatusCode = ("" + StatusCode);
            StoreBranch = ("" + StoreBranch);

            StoreBranch = StoreBranch.Trim();

            if (StatusCode.Trim() == "")
            {
                StatusCode = "ALL"; //no status code? - default to ALL
            }

            if (Make.Trim() == "")
            {
                Make = "ALL"; //no make code? - default to ALL
            }

            OnFitzMall = ("" + OnFitzMall);

            Location = Location.Trim();


            if (StatusCode == "ALL")
            {
                parStatusCode = 0;
            }
            else
            {
                parStatusCode = Convert.ToInt16(StatusCode);
            }

            if (OnFitzMall == "1")
            {
                return RedirectToAction("DrillDown_AllStatusNew", "InventoryReportDrillDowns", new { Make = Make.ToUpper(), StoreBranch = StoreBranch, NewOrUsed = "N" });
            }
            else
            {
                return RedirectToAction("DrillDown_AllStatus", "NotOnFitzMalls", new { Make = Make.ToUpper(), StoreBranch = StoreBranch, NewOrUsed = "N" });
            }

        }



        // POST: InventoryNotOnFitzMall_Report/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STOREBRANCH,LOCATION,MAKE,OnWebSite_1,OnWebSite_2,OnWebSite_4,OnWebSite_9,OnWebSite_12,OnWebSite_14,Reynolds_1,Reynolds_2,Reynolds_4,Reynolds_9,Reynolds_12,Reynolds_14,Id_Primary")] InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report)
        {
            if (ModelState.IsValid)
            {
                db.InventoryNotOnFitzMall_Report.Add(inventoryNotOnFitzMall_Report);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryNotOnFitzMall_Report);
        }

        // GET: InventoryNotOnFitzMall_Report/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report = db.InventoryNotOnFitzMall_Report.Find(id);
            if (inventoryNotOnFitzMall_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_Report);
        }

        // POST: InventoryNotOnFitzMall_Report/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STOREBRANCH,LOCATION,MAKE,OnWebSite_1,OnWebSite_2,OnWebSite_4,OnWebSite_9,OnWebSite_12,OnWebSite_14,Reynolds_1,Reynolds_2,Reynolds_4,Reynolds_9,Reynolds_12,Reynolds_14,Id_Primary")] InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryNotOnFitzMall_Report).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryNotOnFitzMall_Report);
        }

        // GET: InventoryNotOnFitzMall_Report/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report = db.InventoryNotOnFitzMall_Report.Find(id);
            if (inventoryNotOnFitzMall_Report == null)
            {
                return HttpNotFound();
            }
            return View(inventoryNotOnFitzMall_Report);
        }

        // POST: InventoryNotOnFitzMall_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryNotOnFitzMall_Report inventoryNotOnFitzMall_Report = db.InventoryNotOnFitzMall_Report.Find(id);
            db.InventoryNotOnFitzMall_Report.Remove(inventoryNotOnFitzMall_Report);
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
