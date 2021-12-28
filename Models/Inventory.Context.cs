﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApplication6.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class InventoryEntities1 : DbContext
    {
        public InventoryEntities1()
            : base("name=InventoryEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Inventory> Inventories { get; set; }
        public virtual DbSet<InventoryHistory> InventoryHistories { get; set; }
        public virtual DbSet<InventoryNotOnFitzMall_Report> InventoryNotOnFitzMall_Report { get; set; }
        public virtual DbSet<InventoryNotOnFitzMall_USED_Report> InventoryNotOnFitzMall_USED_Report { get; set; }
        public virtual DbSet<InventoryReportDrillDown> InventoryReportDrillDowns { get; set; }
        public virtual DbSet<NotOnFitzMall> NotOnFitzMalls { get; set; }
        public virtual DbSet<NotOnFitzMall_USED> NotOnFitzMall_USED { get; set; }
        public virtual DbSet<ReportInventory> ReportInventories { get; set; }
        public virtual DbSet<DefaultLocationsByStoreBranch_NewVehicles> DefaultLocationsByStoreBranch_NewVehicles { get; set; }
    
        public virtual ObjectResult<CARbySTOCK_Result> CARbySTOCK(string sTOCK)
        {
            var sTOCKParameter = sTOCK != null ?
                new ObjectParameter("STOCK", sTOCK) :
                new ObjectParameter("STOCK", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<CARbySTOCK_Result>("CARbySTOCK", sTOCKParameter);
        }
    
        public virtual int Inventory_ReBuild()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Inventory_ReBuild");
        }
    
        public virtual int PROC_InventoryNotOnFitzMallReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PROC_InventoryNotOnFitzMallReport");
        }
    
        public virtual int PROC_USEDInventoryNotOnFitzMallReport()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("PROC_USEDInventoryNotOnFitzMallReport");
        }
    
        public virtual ObjectResult<procDAB_Result> procDAB()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<procDAB_Result>("procDAB");
        }
    }
}
