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
    public class NotOnFitzMallsController : Controller 
    {
        private InventoryEntities1 db = new InventoryEntities1();

        // GET: NotOnFitzMalls
        public ActionResult Index()
        {
            return View(db.NotOnFitzMalls.ToList());
        }

        // GET: NotOnFitzMalls/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall notOnFitzMall = db.NotOnFitzMalls.Find(id);
            if (notOnFitzMall == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall);
        }

        // GET: NotOnFitzMalls/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotOnFitzMalls/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,Id_Primary")] NotOnFitzMall notOnFitzMall)
        {
            if (ModelState.IsValid)
            {
                db.NotOnFitzMalls.Add(notOnFitzMall);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notOnFitzMall);
        }

        // GET: NotOnFitzMalls/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall notOnFitzMall = db.NotOnFitzMalls.Find(id);
            if (notOnFitzMall == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall);
        }

        // POST: NotOnFitzMalls/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,Id_Primary")] NotOnFitzMall notOnFitzMall)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notOnFitzMall).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notOnFitzMall);
        }


        public ActionResult DrillDown_AllStatus(string StoreBranch, string Location, string Make, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_InventoryReportDrillDowns = from sDD_init in db.NotOnFitzMalls.Where(d => d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;


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
            string NewOrUsed = ("N");

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            ViewBag.PriceTitle = "MSRP";

            ViewBagString = NewOrUsedTitle + " Cars NOT On FitzMall";
            System.Diagnostics.Debug.WriteLine("NotONFitzMall DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " " + NewOrUsed);

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
            ViewBag.NewOrUsed = NewOrUsed;
            ViewBag.Make = Make.ToUpper();
            ViewBag.SortOrder = sortOrder;

            if (StoreBranch == "")
            {

                SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                   select sDD;
            }
            else
            {
                if (Make == "ALL")
                {

                    SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d =>d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                       select sDD;

                }
                else
                {

                    SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                       select sDD;

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

                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);
        }

        public ActionResult DrillDown_AllLocations(int? Status, string sortOrder)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //
            var SORTED_InventoryReportDrillDowns = from sDD_init in db.NotOnFitzMalls.Where(d => d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;

            System.Diagnostics.Debug.WriteLine("NotONFitzMall DrillDown_ALLLocations Controller- Getting View:  " + Status);

            ViewBag.PriceTitle = "MSRP";

            // handle nulls
            sortOrder = ("" + sortOrder);

            string ViewBagString = "";

            string NewOrUsed = "N";

            ViewBagString = "NEW Cars Not On FitzMall";
            if (Status.ToString() != "0")
            {
                ViewBagString += " " + Status.ToString();

            }


            ViewBag.Title = ViewBagString;

            ViewBag.parStatusCode = Status;
            ViewBag.NewOrUsed = "N";
            ViewBag.SortOrder = sortOrder;

            if (Status > 0)
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.STAT_CODE == Status && d.NEW_USED == NewOrUsed)
                                                   select sDD;
            }
            else
            {
                SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                   select sDD;
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
            var SORTED_InventoryReportDrillDowns = from sDD_init in db.NotOnFitzMalls.Where(d => d.ChromeStyleID != 0 && d.MSRP > 0 && d.FitzWayVIN != "")
                                                   select sDD_init;


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
            System.Diagnostics.Debug.WriteLine("NotONFitzMall DrillDown Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            string ViewBagString = "";
            string NewOrUsedTitle = "NEW";
            if (NewOrUsed == "N")
            {
                NewOrUsedTitle = "NEW";
            }

            ViewBagString = NewOrUsedTitle + " Cars NOT On FitzMall";
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

                    SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d =>d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch)
                                                       select sDD;

                }
                else
                {

                    SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed)
                                                       select sDD;
                }
            }
            else
            {
                if (StoreBranch == "")
                {

                    SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                       select sDD;
                }
                else
                {
                    if (Make == "ALL")
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                           select sDD;

                    }
                    else
                    {

                        SORTED_InventoryReportDrillDowns = from sDD in db.NotOnFitzMalls.Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2)  || (d.STAT_CODE == 4)  || (d.STAT_CODE == 9)  || (d.STAT_CODE == 12)  || (d.STAT_CODE == 14)))
                                                           select sDD;

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

                default:

                    return View(SORTED_InventoryReportDrillDowns);
                    break;

            }
            return View(SORTED_InventoryReportDrillDowns);
        }

        // GET: NotOnFitzMalls/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall notOnFitzMall = db.NotOnFitzMalls.Find(id);
            if (notOnFitzMall == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall);
        }

        // POST: NotOnFitzMalls/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotOnFitzMall notOnFitzMall = db.NotOnFitzMalls.Find(id);
            db.NotOnFitzMalls.Remove(notOnFitzMall);
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
