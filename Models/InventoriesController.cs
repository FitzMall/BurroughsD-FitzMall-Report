using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace WebApplication6.Models
{
    public class InventoriesController : Controller
    {
        private InventoryEntities1 db = new InventoryEntities1();

        // GET: Inventories
        public ActionResult Index()
        {
            return View(db.Inventories.ToList());
        }

        // GET: Inventories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // GET: Inventories/Create
        public ActionResult Create()
        {
            return View();
        }


        public ActionResult DrillDown_AllLocationsNew(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {

            System.Diagnostics.Debug.WriteLine("Inventories Controller- Getting View DrillDown_AllLocations: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);

            // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            if (StatusCode > 0)
            {
                if ((Make + "") == "")
                {
                    return View(db.Inventories.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
                else
                {
                    return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {

                    return View(db.Inventories.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
                else
                {
                    return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
            }
        }

        public ActionResult DrillDown_AllLocationsUsed(int? StatusCode, string NewOrUsed)
        {

            System.Diagnostics.Debug.WriteLine("Inventories Controller- Getting View DrillDown_AllLocations: Status: " + StatusCode + " " + NewOrUsed);

            // handle nulls
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "U";  // default to used 
            }

            if (StatusCode > 0)
            {
                    return View(db.Inventories.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
            }
            else
            {
                    return View(db.Inventories.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
            }
        }
        public ActionResult DrillDown_AllStatusNew(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {


            System.Diagnostics.Debug.WriteLine("Inventories Controller- Getting DrillDown_AllStatusNew View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);


            // handle nulls
            Make = ("" + Make);
            StoreBranch = ("" + StoreBranch);
            NewOrUsed = ("" + NewOrUsed);
            if (NewOrUsed == "")
            {
                NewOrUsed = "N";  // default to new 
            }

            if (StatusCode > 0)
            {
                if ((Make + "") == "")
                {
                    return View(db.Inventories.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
                else
                {
                    return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {

                    return View(db.Inventories.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
                else
                {
                    return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                }
            }
        }



        // GET: ReportInventories/DrillDown/5
        public ActionResult DrillDown(string StoreBranch, string Make, int? StatusCode, string NewOrUsed)
        {
            // actually called by NotOnFitzMalls controller
            // status code = 0 means all status
            //

            System.Diagnostics.Debug.WriteLine("Inventories Controller- Getting View: Make:" + Make + " Store/Branch:" + StoreBranch + " Status: " + StatusCode + " " + NewOrUsed);


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

            if (StatusCode > 0)
            {
                if (Make == "ALL")
                {
                    return View(db.Inventories.ToList().Where(d => d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed && d.STORE_BRANCH == StoreBranch));
                }
                else
                {
                    return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.STAT_CODE == StatusCode && d.NEW_USED == NewOrUsed));
                }
            }
            else
            {
                if (StoreBranch == "")
                {
                    if (NewOrUsed == "N")
                    {
                        return View(db.Inventories.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                    } else
                    {
                        return View(db.Inventories.ToList().Where(d => d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                    }
                }
                else
                {
                    if (Make == "ALL")
                    {
                        if (NewOrUsed == "N")
                        {
                            return View(db.Inventories.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                        } else
                        {
                            return View(db.Inventories.ToList().Where(d => d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                        }

                    }
                    else
                    {
                        if (NewOrUsed == "N")
                        {
                            return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2) || (d.STAT_CODE == 4) || (d.STAT_CODE == 9) || (d.STAT_CODE == 12) || (d.STAT_CODE == 14))));
                        } else
                        {
                            return View(db.Inventories.ToList().Where(d => d.MAKE == Make && d.STORE_BRANCH == StoreBranch && d.NEW_USED == NewOrUsed && ((d.STAT_CODE == 1) || (d.STAT_CODE == 2))));
                        }
                    }
                }
            }
        }

        // POST: Inventories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,IMPORT_DATE,Id_Primary")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Inventories.Add(inventory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(inventory);
        }

        // GET: Inventories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "STORE_BRANCH,SERIAL_,STOCK_,ORDER_,NEW_USED,YEAR,MAKE,MAKE_PREFIX,ACCOUNTING_MAKE,MODEL,CARLINE,CARLINE_CODE,DESC,RECEIVED_DATE,DAYS_IN_STOCK,MSRP,BASE_MSRP,INVOICE,INVEN_AMT,INTERNET_PRICE,CODED_COST,FREIGHT,STAT_CODE,STATUS_LOG_DATE_DR,STATUS_LOG_DR,LOCATION,ODOM_READING,EXT_COLOR,EXT_CLR_DESC,INT_COLOR,INT_CLR_DESC,MEMO1_CAT,MEMO2_CAT,MPG_LOW,MPG_HIGH,FUEL,FUEL_DESC,BODYSIZE,BODYSIZE_DESC,ORD_DATE,ORD_TYPE,KEY_NO_1,KEY_NO_2,ACCENT_CLR,BEST_PRICE,BODY_CD,BUILD_DATE,BUILD_NAME_DV,CARLINE_CODE_DV,CHASSIS_NO,CHASSIS_NO_DR,CLR_CODE,CLR_CODE_1,CLR_DESC,CLR_DESC_41,CLR_GENERIC,COST_PACK_LB,CREATE_DATE_DV,CREATED_BY_DV,DATE_ADDED_DR,DATE_SOLD_DV,DAYS_IN_STK,DEMO_DATE_DV,DEMO_MIL_DV,DLR_FLAG,DLR_NO_DESC,DLR_NO_DV,DRIVE_TYPE,ENG_NO,EST_ARRIVAL_DATE,EXT_CLR_CD,HBK_AMT,IN_STOCK,INT_CLR_CD,INV_AMT,INV_AMT_2,INV_AMT_3,JRNL_PURCH_DATE_DR,KEYCHIP_NO_DV,KEYLESS_NO_DV,LABEL_DATE,LOC,MAINT_CODE_DV,MDL_NO,MDL_NO_10,MDL_YR_CD,MFR_SCHED_DATE,MFR_STAT,MFR_STAT_DATE,MIL_PER_GAL,MODIFIED_DATE,MODIFIED_STATION,MODIFIED_TIME,MODIFIED_USER_ID,NO_OF_CYL,ON_ORDER,ORDR_PROC_DATE,ORDR_PRTY,PKG_CODE_1,PKG_CODE1_CAT,PURCH_DATE,PURCH_FROM_NAME_DR,PURCH_REF_NO_DV,PWRSTR,RECALL_DATE_DV,RECALL_DATE4_DV,RECID,ROOF_CLR,RPG_NO_OF_CYL,SELLER_TYPE,SLS_CODE,SLS_COST,SLS_PRICE,STK_NO,STK_TYPE,STKNO,STYLE,STYLE_LONG,SVC_DAYS_DV,SYS_DATE_CAT,TOT_DLR_ACC_COST_LB,TOTAL_OPTION_INV,TRAN_FLAG,TRANSM,TRIM,TURBO,TYPE,VEH_TRANSM_DR,VEH_TYPE,VEND_NAME,VEND_NO,WEIGHT,WHEEL_BASE,FLAG_NEW_USED_DV,YR,MAKE_PFX,DESC1,RCPT_DATE,DAYS,LIST_PRICE,CODED_COST2,LIC_FEE,MIL,CLR_EXT_CODE,CLR_EXT_DESC,CLR_INT_CODE,CLR_INT_DESC,BODYSIZE_DESC_DR,ACC_CODE,ACC_DESC,ACCT_PFX,ACTVY_DATE,ALARM_NO_DV,BOOK_VALUE,CAMP_NO_DV,CATEG_CODE,CERT_NO,CERTIFED,CHASSIS_NO_DV,CLASS,CLR_CD,CLR_DV,KEY_NUM_1,COLOR_DESC,COMMENTS_6,COST_PACK_AMT,DEALER_CODE_DV,DLR_ACC_AMT,DLR_ACC_CODE,DLR_ACC_CODE_1,DLR_ACC_REF_NO,DLR_ACC_RTL,DMV_AMT,ENTRY_INFO,FACT_ACC_AMT,FACT_ACC_CODE,FACT_ACC_DESC,FACT_ACC_RTL,FROM_TO_DR,IN_SERV_DATE_DV,INIT_RO_DATE_DV,JRNL_PFX_UVP_DR,KBB_TYPE,KEY_N,KEY_N_1,KEY_N_2,SECOND_BOOK_CODE1_DR,SECOND_BOOK_CODE2_DR,SECOND_BOOK_CODE3_DR,SECOND_BOOK_VALUE1_DR,SECOND_BOOK_VALUE2_DR,SECOND_BOOK_VALUE3_DR,SER_UDF_1_DV,SER_UDF_10_DV,SER_UDF_11_DV,SER_UDF_12_DV,SER_UDF_13_DV,SER_UDF_14_DV,SER_UDF_15_DV,SER_UDF_16_DV,SER_UDF_17_DV,SER_UDF_18_DV,SER_UDF_19_DV,SER_UDF_2_DV,SER_UDF_20_DV,SER_UDF_21_DV,SER_UDF_22_DV,SER_UDF_23_DV,SER_UDF_24_DV,SER_UDF_25_DV,SER_UDF_26_DV,SER_UDF_27_DV,SER_UDF_28_DV,SER_UDF_29_DV,SER_UDF_3_DV,SER_UDF_30_DV,SER_UDF_31_DV,SER_UDF_32_DV,SER_UDF_33_DV,SER_UDF_34_DV,SER_UDF_35_DV,SER_UDF_36_DV,SER_UDF_37_DV,SER_UDF_38_DV,SER_UDF_39_DV,SER_UDF_4_DV,SER_UDF_40_DV,SER_UDF_41_DV,SER_UDF_42_DV,SER_UDF_43_DV,SER_UDF_44_DV,SER_UDF_45_DV,SER_UDF_46_DV,SER_UDF_47_DV,SER_UDF_48_DV,SER_UDF_49_DV,SER_UDF_5_DV,SER_UDF_50_DV,SER_UDF_51_DV,SER_UDF_52_DV,SER_UDF_53_DV,SER_UDF_54_DV,SER_UDF_55_DV,SER_UDF_56_DV,SER_UDF_57_DV,SER_UDF_58_DV,SER_UDF_59_DV,SER_UDF_6_DV,SER_UDF_60_DV,SER_UDF_7_DV,SER_UDF_8_DV,SER_UDF_9_DV,SERSEQ,STANDARD_STYLE,STANDARDIZED,STOCK_NO2,STORE_NAME,STORE_NO,STYLE_ID,SYS_DATE_ALPHA_CAT,TI_PAYOFF_AMT,TI_STK_NO,TURBO_DV,USED_GRP,USED_VEH_PUR_PFX_DR,UVP_JNL_PFX,VDC_VIN_REC,VEH_TYPE_DR,VINPATTERN,YR_Y4,UDF_DIFFERENCE,UDF_IRC_FLAG,IMPORT_DATE,Id_Primary")] Inventory inventory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inventory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(inventory);
        }

        // GET: Inventories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Inventory inventory = db.Inventories.Find(id);
            if (inventory == null)
            {
                return HttpNotFound();
            }
            return View(inventory);
        }

        // POST: Inventories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Inventory inventory = db.Inventories.Find(id);
            db.Inventories.Remove(inventory);
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
