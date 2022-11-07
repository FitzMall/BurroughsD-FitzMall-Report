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


        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?UseCriteria=true&Page=1&Regions=ALL&Conditions=ALL&Makes=&KeyWordSearch=" + keywordSearch);
        }

        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Make, int? StatusCode, string NewOrUsed, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns
                                               select sDD;

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            ViewBag.PriceTitle = "MSRP";

            // handle nulls
            sortOrder = ("" + sortOrder);
            Make = ("" + Make);
     
            StoreBranch = ("" + StoreBranch);
            StoreBranch = ("" + StoreBranch.Trim());
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());

            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
                ViewBag.PriceTitle = "FitzWay Low Price";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " Status: " + StatusCode.ToString();

            }

            string sLocation = "";



            if (Make != "" && Make != "ALL")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.StoreBranch = StoreBranch;
            ViewBag.parStatusCode = StatusCode;
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.Make = Make.ToUpper();
            ViewBag.SortOrder = sortOrder;
            if (Make.Trim() == "")
            {
                Make = "ALL";
            }


            if (StatusCode > 0)
            {

                if (StoreBranch == "")
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;

                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                    }

                }
                else
                {
                if (Make == "ALL")
                {
                    if (NewOrUsed == "N")
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                           select sDD;
                    }
                    else
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                           select sDD;
                    }
                }
                else
                {
                    if (NewOrUsed == "N")
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;

                    }
                    else
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;
                    }
                }
            }

            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                           select sDD;
                    }
                    else
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                           select sDD;
                    }
                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;
                        }



                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {

                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;
                        }
                    }
                }
            }


            switch (sortOrder)
            {
                case "VIN":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.SERIAL_);
                    break;

                case "VIN_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.SERIAL_);
                    break;
                case "DaysInStock":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.DAYS_IN_STOCK);
                    break;

                case "DaysInStock_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.DAYS_IN_STOCK);
                    break;
                case "MSRP":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.MSRP);
                    break;

                case "MSRP_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.MSRP);
                    break;

                case "Status":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.STAT_CODE);
                    break;

                case "Status_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.STAT_CODE);
                    break;

                case "Make":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.MAKE + d.CARLINE);
                    break;

                case "Make_Descending":
                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.MAKE + d.CARLINE);
                    break;

                case "Model":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CARLINE);
                    break;

                case "Model_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CARLINE);
                    break;

                case "StockNum":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.STOCK_);
                    break;

                case "StockNum_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.STOCK_);
                    break;

                case "Year":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.YEAR);
                    break;

                case "Year_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.YEAR);
                    break;

                case "Color":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.EXT_COLOR);
                    break;

                case "Color_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.EXT_COLOR);
                    break;

                case "Chrome":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeStyleID);
                    break;

                case "Chrome_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeStyleID);
                    break;

                case "ChromeOptions":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeOptions);
                    break;

                case "ChromeOptions_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeOptions);
                    break;

                case "INVOICE":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.INVOICE);
                    break;

                case "INVOICE_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.INVOICE);
                    break;
                case "Location":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.LOCATION);
                    break;

                case "Location_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.LOCATION);
                    break;

                case "Photos":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CustomPhotos);
                    break;

                case "Photos_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CustomPhotos);
                    break;


                default:

                    break;

            }

            if (StoreBranch != "")
            {
                foreach (var result in SORTED_InventoryReportDrillDowns)
                {
                    sLocation = result.LOCATION;
                    break;
                }

                ViewBagString += " " + sLocation;

            }
            ViewBag.Title = ViewBagString;

            return View(SORTED_InventoryReportDrillDowns);

        }


             protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        public ActionResult ExportToExcel(string StoreBranch, string Make, int? StatusCode, string NewOrUsed, string sortOrder)
        {
            string ExcelOutput = "";
            // handle nulls
            sortOrder = ("" + sortOrder);
            Make = ("" + Make);

            StoreBranch = ("" + StoreBranch);
            StoreBranch = ("" + StoreBranch.Trim());
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());            
                var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "CarsOnFitzMall_" +  NewOrUsed + "_" + Make + ".csv",
                Inline = false
            };

            var SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.STORE_BRANCH == StoreBranch)
                                                   select sDD;

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            ViewBag.PriceTitle = "MSRP";



            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "U")
            {
                NewOrUsedTitle = "USED";
                ViewBag.PriceTitle = "FitzWay Low Price";
            }

            ViewBagString = NewOrUsedTitle + " Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " Status: " + StatusCode.ToString();

            }

            string sLocation = "";

            if (StoreBranch != "")
            {
                foreach (var result in SORTED_InventoryReportDrillDowns)
                {
                    sLocation = result.LOCATION;
                    break;
                }
                ViewBagString += " " + sLocation;

            }

            if (Make != "" && Make != "ALL")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.Title = ViewBagString;

            ViewBag.StoreBranch = StoreBranch;
            ViewBag.parStatusCode = StatusCode;
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.Make = Make.ToUpper();
            ViewBag.SortOrder = sortOrder;
            if (Make.Trim() == "")
            {
                Make = "ALL";
            }


            if (StatusCode > 0)
            {

                if (StoreBranch == "")
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;

                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                    }

                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                               select sDD;
                        }
                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;

                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                        }
                    }
                }

            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                           select sDD;
                    }
                    else
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                           select sDD;
                    }
                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;
                        }



                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {

                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                               select sDD;
                        }
                        else
                        {
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;
                        }
                    }
                }
            }


            // load the results for possible Excel export 

            ExcelOutput += ("LOCATION,");
            ExcelOutput += ("SERIAL_,");
            ExcelOutput += ("STOCK_,");
            ExcelOutput += ("STAT_CODE,");
            ExcelOutput += ("YEAR,");
            ExcelOutput += ("MAKE,");
            ExcelOutput += ("CARLINE,");
            ExcelOutput += ("EXT_COLOR,");
            ExcelOutput += ("CustomPhotos,");
            ExcelOutput += ("ChromeStyleID,");
            ExcelOutput += ("INVOICE,");
            ExcelOutput += ("MSRP,");
            ExcelOutput += ("ChromeOptions,");
            ExcelOutput += ("DAYS_IN_STOCK,");
            ExcelOutput += "\r\n";

            foreach (var result in SORTED_InventoryReportDrillDowns)

            {
                ExcelOutput += (result.LOCATION + ",");
                ExcelOutput += (result.SERIAL_ + ",");
                ExcelOutput += (result.STOCK_ + ",");
                ExcelOutput += (result.STAT_CODE + ",");
                ExcelOutput += (result.YEAR + ",");
                ExcelOutput += (result.MAKE + ",");
                ExcelOutput += (result.CARLINE + ",");
                ExcelOutput += (result.EXT_COLOR + ",");
                ExcelOutput += (result.CustomPhotos + ",");
                ExcelOutput += (result.ChromeStyleID + ",");
                ExcelOutput += (result.INVOICE + ",");
                ExcelOutput += (result.MSRP + ",");
                ExcelOutput += (result.ChromeOptions + ",");
                ExcelOutput += (result.DAYS_IN_STOCK + ",");
                ExcelOutput += "\r\n";

            }

            Response.AddHeader("Content-Disposition", cd.ToString());

            return Content(ExcelOutput);
        }


    }
}
