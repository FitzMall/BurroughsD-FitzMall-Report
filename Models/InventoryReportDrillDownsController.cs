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

        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?KeyWordSearch=" + keywordSearch + "&Sort=&inventoryGrid_length=10&UseCriteria=true");
        }


        public ActionResult DrillDown_AllLocationsUsed(int? StatusCode,  string sortOrder)
            {
                // actually called by NotOnFitzMalls controller
                // status code = 0 means all status
                //
                var SORTED_InventoryReportDrillDowns = from sDD_init in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "")
                                                       select sDD_init;
                string NewOrUsed = "U";  // default to used 

                System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View DrillDown_AllLocationsUsed: Status: " + StatusCode + " " + NewOrUsed);

                ViewBag.PriceTitle = "MSRP";

                // handle nulls
                sortOrder = ("" + sortOrder);
                
                string ViewBagString = "";

                ViewBagString = "USED Cars On FitzMall";
                if (StatusCode.ToString() != "0")
                {
                    ViewBagString += " " + StatusCode.ToString();

                }

                ViewBag.Title = ViewBagString;

                ViewBag.parStatusCode = StatusCode;
                ViewBag.NewOrUsed = NewOrUsed;
                ViewBag.SortOrder = sortOrder;

            if (StatusCode > 0)
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed && d.STAT_CODE == StatusCode)
                                                   select sDD;
            }
            else
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)))
                                                   select sDD;
            }


            switch (sortOrder)
            {
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

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CLR_DESC);
                    break;

                case "Color_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CLR_DESC);
                    break;

                case "Chrome":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeStyleID);
                    break;

                case "Chrome_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeStyleID);
                    break;

                case "Status":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.STAT_CODE);
                    break;

                case "Status_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.STAT_CODE);
                    break;

                case "ChromeOptions":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeOptions);
                    break;

                case "ChromeOptions_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeOptions);
                    break;

                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);

        }



        public ActionResult DrillDown_AllStatusNew(string StoreBranch, string Make, int? StatusCode, string NewOrUsed, string sortOrder)
        {


            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting DrillDown_AllStatusNew View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            var SORTED_InventoryReportDrillDowns = from sDD_init in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;

            // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch.Trim());
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

            ViewBag.StoreBranch = StoreBranch;
            ViewBag.parStatusCode = StatusCode;
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.Make = Make.ToUpper();
            ViewBag.SortOrder = sortOrder;

            if (StatusCode > 0)
            {
                if (Make == "ALL")
                {
                    if (NewOrUsed == "N")
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
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
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;

                    }
                    else
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;
                    }
                }
            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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

                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CLR_DESC);
                    break;

                case "Color_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CLR_DESC);
                    break;

                case "Chrome":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeStyleID);
                    break;

                case "Chrome_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeStyleID);
                    break;

                case "Status":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.STAT_CODE);
                    break;

                case "Status_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.STAT_CODE);
                    break;

                case "ChromeOptions":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeOptions);
                    break;

                case "ChromeOptions_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeOptions);
                    break;

                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);

        }



        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Make, int? StatusCode, string NewOrUsed, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_InventoryReportDrillDowns = from sDD_init in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            ViewBag.PriceTitle = "MSRP";

            // handle nulls
            sortOrder = ("" + sortOrder);
            Make = ("" + Make);
            if (Make == "")
            {
                Make = "ALL";
            }
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

            ViewBag.StoreBranch = StoreBranch;
            ViewBag.parStatusCode = StatusCode;
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.Make = Make.ToUpper();
            ViewBag.SortOrder = sortOrder;

            if (StatusCode > 0)
            {
                if (Make == "ALL")
                {
                    if (NewOrUsed == "N")
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
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
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;

                    }
                    else
                    {
                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                           select sDD;
                    }
                }
            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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
                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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

                            SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
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

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CLR_DESC);
                    break;

                case "Color_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CLR_DESC);
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

                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);

        }

        public ActionResult DrillDown_AllLocationsNew(int? StatusCode, string NewOrUsed, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_InventoryReportDrillDowns = from sDD_init in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;

            System.Diagnostics.Debug.WriteLine("Inventory DrillDown Controller- Getting View DrillDown_AllLocationsNew: Status: " + StatusCode + " " + NewOrUsed);

            ViewBag.PriceTitle = "MSRP";

            // handle nulls
            sortOrder = ("" + sortOrder);
            NewOrUsed = ("" + NewOrUsed);
            NewOrUsed = ("" + NewOrUsed.Trim());
            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";

            ViewBagString = "NEW Cars On FitzMall";
            if (StatusCode.ToString() != "0")
            {
                ViewBagString += " " + StatusCode.ToString();

            }

            ViewBag.Title = ViewBagString;

            ViewBag.parStatusCode = StatusCode;
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.SortOrder = sortOrder;

            if (StatusCode > 0)
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.STAT_CODE == StatusCode && d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed)
                                                   select sDD;

            }
            else
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.InventoryReportDrillDowns.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "" && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14)))
                                                   select sDD;
            }

            switch (sortOrder)
            {
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

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.CLR_DESC);
                    break;

                case "Color_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.CLR_DESC);
                    break;

                case "Chrome":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeStyleID);
                    break;

                case "Chrome_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeStyleID);
                    break;

                case "Make":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.MAKE + d.CARLINE);
                    break;

                case "Make_Descending":
                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.MAKE + d.CARLINE);
                    break;

                case "Options":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.ChromeOptions);
                    break;

                case "Options_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.ChromeOptions);
                    break;


                case "Status":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderBy(d => d.STAT_CODE);
                    break;

                case "Status_Descending":

                    SORTED_InventoryReportDrillDowns = SORTED_InventoryReportDrillDowns.OrderByDescending(d => d.STAT_CODE);
                    break;
                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);

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
