using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6
{
    public class NotOnFitzMall_USEDController : Controller
    {
        private InventoryEntities1 db = new InventoryEntities1();

        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?KeyWordSearch=" + keywordSearch + "&Sort=&inventoryGrid_length=10&UseCriteria=true");
        }

        // GET: ReportInventories/DrillDown/5
        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Make, int? StatusCode, string NewOrUsed, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED
                                                   select sDD;

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

             // handle nulls
            sortOrder = ("" + sortOrder);
            Make = ("" + Make);

            StoreBranch = ("" + StoreBranch);
            StoreBranch = ("" + StoreBranch.Trim());
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());
            NewOrUsed = "U";  // default to used 
          
            string ViewBagString = "";
            string NewOrUsedTitle = "USED";
            ViewBag.PriceTitle = "FitzWay Low Price";
            
            ViewBagString = NewOrUsedTitle + " Cars Not On FitzMall";
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
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                    }
                    else
                    {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                    }

                }
                else
                {
                    if (Make == "ALL")
                    {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                               select sDD;
                    }
                    else
                    {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                               select sDD;
                    }
                }

            }
            else
            {
                if (StoreBranch == "")
                {
    
                        SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                           select sDD;
                }
                else
                {
                    if (Make == "ALL")
                    {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;

                    }
                    else
                    {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                               select sDD;
                    }
                }
            }


            switch (sortOrder)
            {
                case "VIN":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.SERIAL_);
                    break;

                case "VIN_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.SERIAL_);
                    break;
                case "DaysInStock":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.DAYS_IN_STOCK);
                    break;

                case "DaysInStock_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.DAYS_IN_STOCK);
                    break;
                case "MSRP":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.MSRP);
                    break;

                case "MSRP_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.MSRP);
                    break;

                case "Status":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.STAT_CODE);
                    break;

                case "Status_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.STAT_CODE);
                    break;

                case "Make":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.MAKE + d.CARLINE);
                    break;

                case "Make_Descending":
                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.MAKE + d.CARLINE);
                    break;

                case "Model":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.CARLINE);
                    break;

                case "Model_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.CARLINE);
                    break;

                case "StockNum":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.STOCK_);
                    break;

                case "StockNum_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.STOCK_);
                    break;

                case "Year":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.YEAR);
                    break;

                case "Year_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.YEAR);
                    break;

                case "Color":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.EXT_COLOR);
                    break;

                case "Color_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.EXT_COLOR);
                    break;

                case "Chrome":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.ChromeStyleID);
                    break;

                case "Chrome_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.ChromeStyleID);
                    break;

                case "ChromeOptions":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.ChromeOptions);
                    break;

                case "ChromeOptions_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.ChromeOptions);
                    break;

                case "INVOICE":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.INVOICE);
                    break;

                case "INVOICE_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.INVOICE);
                    break;
                case "Location":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.LOCATION);
                    break;

                case "Location_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.LOCATION);
                    break;

                case "Photos":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderBy(d => d.CustomPhotos);
                    break;

                case "Photos_Descending":

                    SORTED_NotOnFitzMall_USED = SORTED_NotOnFitzMall_USED.OrderByDescending(d => d.CustomPhotos);
                    break;


                default:

                    break;

            }

            if (StoreBranch != "")
            {
                foreach (var result in SORTED_NotOnFitzMall_USED)
                {
                    sLocation = result.LOCATION;
                    break;
                }

                ViewBagString += " " + sLocation;

            }
            ViewBag.Title = ViewBagString;

            return View(SORTED_NotOnFitzMall_USED);

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

            Make = ("" + Make);
            if (Make == "")
            {
                Make = "ALL";
            }
            StoreBranch = ("" + StoreBranch);
            StoreBranch = ("" + StoreBranch.Trim());
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());

            var cd = new System.Net.Mime.ContentDisposition
            {
                FileName = "NotOnFitzMallUsed" + Make + ".csv",
                Inline = false
            };

            Make = ("" + Make);
            if (Make == "")
            {
                Make = "ALL";
            }
            StoreBranch = ("" + StoreBranch);
            StoreBranch = ("" + StoreBranch.Trim());
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());


            var SORTED_NotOnFitzMall_USED = from sDD_init in db.NotOnFitzMall_USED.OrderBy(d => d.MSRP)
                                                   select sDD_init;

            if (StatusCode > 0)
            {

                if (StoreBranch == "")
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                        select sDD;
                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                        select sDD;
                        }
                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                        select sDD;

                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
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
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                        select sDD;
                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                        select sDD;
                        }
                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                        select sDD;

                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
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

                        SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) ))
                                                    select sDD;
                    }
                    else
                    {

                        SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                    select sDD;
                    }
                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) ))
                                                        select sDD;
                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                        select sDD;
                        }



                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {

                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) ))
                                                        select sDD;
                        }
                        else
                        {
                            SORTED_NotOnFitzMall_USED = from sDD in db.NotOnFitzMall_USED.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
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

            foreach (var result in SORTED_NotOnFitzMall_USED)

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
