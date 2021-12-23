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

        // GET: NotOnFitzMall_USED
        public ActionResult Index()
        {
            return View(db.NotOnFitzMall_USED.ToList());
        }

        public ActionResult GoToFitzMall(string keywordSearch)
        {

            return Redirect("https://responsive.fitzmall.com/Inventory/SearchResults?KeyWordSearch=" + keywordSearch + "&Sort=&inventoryGrid_length=10&UseCriteria=true");
        }

        public ActionResult DrillDown_AllStatus(string StoreBranch, string Location, string Make)
        {
            Location = ("" + Location);   // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);

            string ViewBagString = "Used Cars NOT On FitzMall ";
         
            if (StoreBranch != "")
            {
                ViewBagString += " " + StoreBranch;

            }

            if (Make != "")
            {
                ViewBagString += " " + Make;

            }

            ViewBag.Title = ViewBagString;


            return View(db.NotOnFitzMall_USED.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == "U" && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
      
        }
        public ActionResult DrillDown_AllLocations(string Status)
        {
            int parStatus = 0;
            Status = ("" + Status);
            if (Status == "")
            {
                Status = "ALL";
            } else
            {
                parStatus = Convert.ToInt32(Status);
            }


            string ViewBagString = "Used Cars NOT On FitzMall";
            if (parStatus > 0)
            {
                ViewBagString += (" Status:" + Status);
            } else
            {
                if (Status == "ALL")
                {
                    ViewBagString += (" Status:" + Status);
                }
            }

            ViewBag.Title = ViewBagString;

            if (Status == "ALL")
            {
                return View(db.NotOnFitzMall_USED.ToList().Where(d => d.NEW_USED == "U" && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
            } else
            {
                return View(db.NotOnFitzMall_USED.ToList().Where(d => d.NEW_USED == "U" && d.STAT_CODE == parStatus));
            }

        }

        public ActionResult DrillDown(string StoreBranch, string Location, string Make, string StatusCode, string OnFitzMall, string NewOrUsed)
        {
            //            return View(db.ReportInventories.ToList().Where(d => d.MAKE == Make && d.STOREBRANCH == StoreBranch));
            //
            Location = ("" + Location);   // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);
            StatusCode = ("" + StatusCode);
            NewOrUsed = ("" + NewOrUsed);

            int parStatusCode;

            if (StatusCode == "ALL")
            {
                parStatusCode = 0;
            }
            else
            {
                if (StatusCode == "")
                {
                    parStatusCode = 0;
                }
                else
                {
                    parStatusCode = Convert.ToInt16(StatusCode);
                }
            };


            string ViewBagString = "";

            ViewBagString = "Used Cars NOT On FitzMall";
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



            System.Diagnostics.Debug.WriteLine("NotOnFitzMallsUSEDController- Getting View: Store/Branch:" + StoreBranch + " Status: " + parStatusCode + " " + NewOrUsed);

            // is this a on-fitzmall drilldown or what should be on fitzmall?
                if (Make + "" == "")
                {
                        System.Diagnostics.Debug.WriteLine(".Where(d => d.STAT_CODE == parStatusCode && d.NEW_USED == Used");
                        return View(db.NotOnFitzMall_USED.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.STAT_CODE == parStatusCode && d.NEW_USED == "U" && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
                else
                {
                        if (parStatusCode == 0)
                        {
                            System.Diagnostics.Debug.WriteLine("d => d.STORE_BRANCH == StoreBranch && d.NEW_USED = U");
                            return View(db.NotOnFitzMall_USED.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == "U" && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                        }
                        else
                        {
                            System.Diagnostics.Debug.WriteLine("Where(d => d.STORE_BRANCH == StoreBranch && d.STAT_CODE == parStatusCode && d.NEW_USED == U");
                            return View(db.NotOnFitzMall_USED.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.STAT_CODE == parStatusCode && d.NEW_USED == "U"));
                        }
          
                }

        }

        // GET: NotOnFitzMall_USED/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall_USED notOnFitzMall_USED = db.NotOnFitzMall_USED.Find(id);
            if (notOnFitzMall_USED == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall_USED);
        }

        // GET: NotOnFitzMall_USED/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NotOnFitzMall_USED/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,Id_Primary")] NotOnFitzMall_USED notOnFitzMall_USED)
        {
            if (ModelState.IsValid)
            {
                db.NotOnFitzMall_USED.Add(notOnFitzMall_USED);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(notOnFitzMall_USED);
        }

        // GET: NotOnFitzMall_USED/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall_USED notOnFitzMall_USED = db.NotOnFitzMall_USED.Find(id);
            if (notOnFitzMall_USED == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall_USED);
        }

        // POST: NotOnFitzMall_USED/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,Id_Primary")] NotOnFitzMall_USED notOnFitzMall_USED)
        {
            if (ModelState.IsValid)
            {
                db.Entry(notOnFitzMall_USED).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(notOnFitzMall_USED);
        }

        // GET: NotOnFitzMall_USED/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NotOnFitzMall_USED notOnFitzMall_USED = db.NotOnFitzMall_USED.Find(id);
            if (notOnFitzMall_USED == null)
            {
                return HttpNotFound();
            }
            return View(notOnFitzMall_USED);
        }

        // POST: NotOnFitzMall_USED/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NotOnFitzMall_USED notOnFitzMall_USED = db.NotOnFitzMall_USED.Find(id);
            db.NotOnFitzMall_USED.Remove(notOnFitzMall_USED);
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
