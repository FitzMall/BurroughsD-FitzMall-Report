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
    public class InventoryReportDrillDownsController : Controller
    {
        private InventoryEntities1 db = new InventoryEntities1();

        // GET: InventoryReportDrillDowns
        public ActionResult Index()
        {
            return View(db.InventoryReportDrillDowns.ToList());
        }


        public ActionResult DrillDown_AllLocationsNew(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View DrillDown_AllLocations: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);
            // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);
            NewOrUsed = ("" + NewOrUsed);

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " Status:" + StatusCode.ToString();

            }

            if (StoreBranch != "")
            {
                ViewBagString += " " + StoreBranch;

            }

            if (Make != "")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.Title = ViewBagString;


            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            if (StatusCode > 0)
            {
                if ((Make + "") == "")
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
                else
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {

                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
                else
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
            }
        }

        public ActionResult DrillDown_AllLocationsUsed(int? StatusCode, string NewOrUsed)
        {

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View DrillDown_AllLocations: Status: " + StatusCode + " " + NewOrUsed);

            // handle nulls
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "U";  // default to used 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if ((StatusCode.ToString() != "0") && (StatusCode.ToString() != ""))
            {
                ViewBagString += " Status: " + StatusCode.ToString();

            }

            ViewBag.Title = ViewBagString;

            if (StatusCode > 0)
            {
                return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
            }
            else
            {
                return View(db.InventoryReportDrillDowns.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
            }
        }
        public ActionResult DrillDown_AllStatusNew(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {


            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting DrillDown_AllStatusNew View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);


            // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " Status: " + StatusCode.ToString();

            }

            if (StoreBranch != "")
            {
                ViewBagString += " " + StoreBranch;

            }

            if (Make != "")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.Title = ViewBagString;



            if (StatusCode > 0)
            {
                if ((Make + "") == "")
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
                else
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {

                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
                else
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
            }
        }



        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);


            // handle nulls
            Make = ("" + Make);
            if (Make == "")
            {
                Make = "ALL";
            }
            StoreBranch = ("" + StoreBranch);
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " " + StatusCode.ToString();

            }

            if (StoreBranch != "")
            {
                ViewBagString += " " + StoreBranch;

            }

            if (Make != "")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.Title = ViewBagString;



            if (StatusCode > 0)
            {
                if (Make == "ALL")
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch));
                }
                else
                {
                    return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {
                        return View(db.InventoryReportDrillDowns.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                    }
                    else
                    {
                        return View(db.InventoryReportDrillDowns.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                    }
                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                        }
                        else
                        {
                            return View(db.InventoryReportDrillDowns.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                        }

                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                        }
                        else
                        {
                            return View(db.InventoryReportDrillDowns.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                        }
                    }
                }
            }
        }


        // GET: InventoryReportDrillDowns/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReportDrillDown inventoryReportDrillDown = db.InventoryReportDrillDowns.Find(id);
            if (inventoryReportDrillDown == null)
            {
                return HttpNotFound();
            }
            return View(inventoryReportDrillDown);
        }

        // GET: InventoryReportDrillDowns/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InventoryReportDrillDowns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,ChromeStyleID,YEAR,MAKE,MAKE_PREFIX,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,LOCATION,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,CARLINE_CODE_DV,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,EXT_CLR_CD,IN_STOCK,INV_AMT,MDL_NO,Id_Primary,CLR_DESC")] InventoryReportDrillDown inventoryReportDrillDown)
        {
            if (ModelState.IsValid)
            {
                db.InventoryReportDrillDowns.Add(inventoryReportDrillDown);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventoryReportDrillDown);
        }

        // GET: InventoryReportDrillDowns/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReportDrillDown inventoryReportDrillDown = db.InventoryReportDrillDowns.Find(id);
            if (inventoryReportDrillDown == null)
            {
                return HttpNotFound();
            }
            return View(inventoryReportDrillDown);
        }

        // POST: InventoryReportDrillDowns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,ChromeStyleID,YEAR,MAKE,MAKE_PREFIX,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,LOCATION,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,CARLINE_CODE_DV,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,EXT_CLR_CD,IN_STOCK,INV_AMT,MDL_NO,Id_Primary,CLR_DESC")] InventoryReportDrillDown inventoryReportDrillDown)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventoryReportDrillDown).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventoryReportDrillDown);
        }

        // GET: InventoryReportDrillDowns/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InventoryReportDrillDown inventoryReportDrillDown = db.InventoryReportDrillDowns.Find(id);
            if (inventoryReportDrillDown == null)
            {
                return HttpNotFound();
            }
            return View(inventoryReportDrillDown);
        }

        // POST: InventoryReportDrillDowns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            InventoryReportDrillDown inventoryReportDrillDown = db.InventoryReportDrillDowns.Find(id);
            db.InventoryReportDrillDowns.Remove(inventoryReportDrillDown);
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
