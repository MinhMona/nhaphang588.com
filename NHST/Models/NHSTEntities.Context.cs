﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NHST.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class NHSTEntities : DbContext
    {
        public NHSTEntities()
            : base("name=NHSTEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Account> tbl_Account { get; set; }
        public virtual DbSet<tbl_AccountantOutStockPayment> tbl_AccountantOutStockPayment { get; set; }
        public virtual DbSet<tbl_AccountInfo> tbl_AccountInfo { get; set; }
        public virtual DbSet<tbl_AdminSendUserWallet> tbl_AdminSendUserWallet { get; set; }
        public virtual DbSet<tbl_AppPushNoti> tbl_AppPushNoti { get; set; }
        public virtual DbSet<tbl_Bank> tbl_Bank { get; set; }
        public virtual DbSet<tbl_Banner> tbl_Banner { get; set; }
        public virtual DbSet<tbl_Benefits> tbl_Benefits { get; set; }
        public virtual DbSet<tbl_BigPackage> tbl_BigPackage { get; set; }
        public virtual DbSet<tbl_BigPackage1> tbl_BigPackage1 { get; set; }
        public virtual DbSet<tbl_BigPackageHistory> tbl_BigPackageHistory { get; set; }
        public virtual DbSet<tbl_ChinaSite> tbl_ChinaSite { get; set; }
        public virtual DbSet<tbl_Commitment> tbl_Commitment { get; set; }
        public virtual DbSet<tbl_Complain> tbl_Complain { get; set; }
        public virtual DbSet<tbl_Configuration> tbl_Configuration { get; set; }
        public virtual DbSet<tbl_Contact> tbl_Contact { get; set; }
        public virtual DbSet<tbl_CustomerBenefits> tbl_CustomerBenefits { get; set; }
        public virtual DbSet<tbl_DeviceBrowser> tbl_DeviceBrowser { get; set; }
        public virtual DbSet<tbl_DeviceToken> tbl_DeviceToken { get; set; }
        public virtual DbSet<tbl_ExportRequestTurn> tbl_ExportRequestTurn { get; set; }
        public virtual DbSet<tbl_FeeBuyPro> tbl_FeeBuyPro { get; set; }
        public virtual DbSet<tbl_FeeCheckProduct> tbl_FeeCheckProduct { get; set; }
        public virtual DbSet<tbl_Feedback> tbl_Feedback { get; set; }
        public virtual DbSet<tbl_FeePackaged> tbl_FeePackaged { get; set; }
        public virtual DbSet<tbl_FeeSupport> tbl_FeeSupport { get; set; }
        public virtual DbSet<tbl_FeeWeightTQVN> tbl_FeeWeightTQVN { get; set; }
        public virtual DbSet<tbl_Footer> tbl_Footer { get; set; }
        public virtual DbSet<tbl_HistoryAutoBanking> tbl_HistoryAutoBanking { get; set; }
        public virtual DbSet<tbl_HistoryIntroduce> tbl_HistoryIntroduce { get; set; }
        public virtual DbSet<tbl_HistoryOrderChange> tbl_HistoryOrderChange { get; set; }
        public virtual DbSet<tbl_HistoryPayWallet> tbl_HistoryPayWallet { get; set; }
        public virtual DbSet<tbl_HistoryPayWalletCYN> tbl_HistoryPayWalletCYN { get; set; }
        public virtual DbSet<tbl_HistoryScanPackage> tbl_HistoryScanPackage { get; set; }
        public virtual DbSet<tbl_HistoryServices> tbl_HistoryServices { get; set; }
        public virtual DbSet<tbl_InWareHousePrice> tbl_InWareHousePrice { get; set; }
        public virtual DbSet<tbl_LinkMarquee> tbl_LinkMarquee { get; set; }
        public virtual DbSet<tbl_MainOder> tbl_MainOder { get; set; }
        public virtual DbSet<tbl_MainOrderCode> tbl_MainOrderCode { get; set; }
        public virtual DbSet<tbl_Menu> tbl_Menu { get; set; }
        public virtual DbSet<tbl_Message> tbl_Message { get; set; }
        public virtual DbSet<tbl_News> tbl_News { get; set; }
        public virtual DbSet<tbl_Node> tbl_Node { get; set; }
        public virtual DbSet<tbl_Notification> tbl_Notification { get; set; }
        public virtual DbSet<tbl_Notifications> tbl_Notifications { get; set; }
        public virtual DbSet<tbl_Order> tbl_Order { get; set; }
        public virtual DbSet<tbl_OrderComment> tbl_OrderComment { get; set; }
        public virtual DbSet<tbl_OrderShopTemp> tbl_OrderShopTemp { get; set; }
        public virtual DbSet<tbl_OrderTemp> tbl_OrderTemp { get; set; }
        public virtual DbSet<tbl_OTP> tbl_OTP { get; set; }
        public virtual DbSet<tbl_OutStockSession> tbl_OutStockSession { get; set; }
        public virtual DbSet<tbl_OutStockSessionPackage> tbl_OutStockSessionPackage { get; set; }
        public virtual DbSet<tbl_Page> tbl_Page { get; set; }
        public virtual DbSet<tbl_PageSEO> tbl_PageSEO { get; set; }
        public virtual DbSet<tbl_PageType> tbl_PageType { get; set; }
        public virtual DbSet<tbl_Partners> tbl_Partners { get; set; }
        public virtual DbSet<tbl_PayAllOrderHistory> tbl_PayAllOrderHistory { get; set; }
        public virtual DbSet<tbl_PayHelp> tbl_PayHelp { get; set; }
        public virtual DbSet<tbl_PayhelpDetail> tbl_PayhelpDetail { get; set; }
        public virtual DbSet<tbl_PayHelpTemp> tbl_PayHelpTemp { get; set; }
        public virtual DbSet<tbl_PayOrderHistory> tbl_PayOrderHistory { get; set; }
        public virtual DbSet<tbl_Present> tbl_Present { get; set; }
        public virtual DbSet<tbl_PriceChange> tbl_PriceChange { get; set; }
        public virtual DbSet<tbl_ProductCategory> tbl_ProductCategory { get; set; }
        public virtual DbSet<tbl_ProductLink> tbl_ProductLink { get; set; }
        public virtual DbSet<tbl_Products> tbl_Products { get; set; }
        public virtual DbSet<tbl_Question> tbl_Question { get; set; }
        public virtual DbSet<tbl_Refund> tbl_Refund { get; set; }
        public virtual DbSet<tbl_RequestOutStock> tbl_RequestOutStock { get; set; }
        public virtual DbSet<tbl_RequestShip> tbl_RequestShip { get; set; }
        public virtual DbSet<tbl_Role> tbl_Role { get; set; }
        public virtual DbSet<tbl_SendNotiEmail> tbl_SendNotiEmail { get; set; }
        public virtual DbSet<tbl_Service> tbl_Service { get; set; }
        public virtual DbSet<tbl_ShippingTypeToWareHouse> tbl_ShippingTypeToWareHouse { get; set; }
        public virtual DbSet<tbl_ShippingTypeVN> tbl_ShippingTypeVN { get; set; }
        public virtual DbSet<tbl_SmallPackage> tbl_SmallPackage { get; set; }
        public virtual DbSet<tbl_SmallPackage1> tbl_SmallPackage1 { get; set; }
        public virtual DbSet<tbl_SmallPackageAuto> tbl_SmallPackageAuto { get; set; }
        public virtual DbSet<tbl_SocialSupport> tbl_SocialSupport { get; set; }
        public virtual DbSet<tbl_StaffIncome> tbl_StaffIncome { get; set; }
        public virtual DbSet<tbl_Step> tbl_Step { get; set; }
        public virtual DbSet<tbl_Support> tbl_Support { get; set; }
        public virtual DbSet<tbl_SupportBuyProduct> tbl_SupportBuyProduct { get; set; }
        public virtual DbSet<tbl_TokenForgotPass> tbl_TokenForgotPass { get; set; }
        public virtual DbSet<tbl_TransportaionOrderDetail> tbl_TransportaionOrderDetail { get; set; }
        public virtual DbSet<tbl_TransportationOrder> tbl_TransportationOrder { get; set; }
        public virtual DbSet<tbl_TransportationOrderNew> tbl_TransportationOrderNew { get; set; }
        public virtual DbSet<tbl_UserLevel> tbl_UserLevel { get; set; }
        public virtual DbSet<tbl_Volume> tbl_Volume { get; set; }
        public virtual DbSet<tbl_Warehouse> tbl_Warehouse { get; set; }
        public virtual DbSet<tbl_WarehouseFee> tbl_WarehouseFee { get; set; }
        public virtual DbSet<tbl_WarehouseFrom> tbl_WarehouseFrom { get; set; }
        public virtual DbSet<tbl_WebChina> tbl_WebChina { get; set; }
        public virtual DbSet<tbl_Weight> tbl_Weight { get; set; }
        public virtual DbSet<tbl_Withdraw> tbl_Withdraw { get; set; }
        public virtual DbSet<tbl_YCG> tbl_YCG { get; set; }
        public virtual DbSet<View_OrderList> View_OrderList { get; set; }
        public virtual DbSet<View_OrderListDamuahang> View_OrderListDamuahang { get; set; }
        public virtual DbSet<View_OrderListFilter> View_OrderListFilter { get; set; }
        public virtual DbSet<View_OrderListFilterWithStatusString> View_OrderListFilterWithStatusString { get; set; }
        public virtual DbSet<View_OrderListFilterYCGiao> View_OrderListFilterYCGiao { get; set; }
        public virtual DbSet<View_OrderListKhoTQ> View_OrderListKhoTQ { get; set; }
        public virtual DbSet<View_OrderListKhoVN> View_OrderListKhoVN { get; set; }
        public virtual DbSet<View_Orderlistwithstatus> View_Orderlistwithstatus { get; set; }
        public virtual DbSet<View_UserList> View_UserList { get; set; }
        public virtual DbSet<View_UserListExcel> View_UserListExcel { get; set; }
        public virtual DbSet<View_UserListWithWallet> View_UserListWithWallet { get; set; }
    
        public virtual ObjectResult<GetVolumeList_Result> GetVolumeList(string search, Nullable<int> pageSize, Nullable<int> pageindex)
        {
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("pageSize", pageSize) :
                new ObjectParameter("pageSize", typeof(int));
    
            var pageindexParameter = pageindex.HasValue ?
                new ObjectParameter("pageindex", pageindex) :
                new ObjectParameter("pageindex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetVolumeList_Result>("GetVolumeList", searchParameter, pageSizeParameter, pageindexParameter);
        }
    
        public virtual ObjectResult<ReportOrder_Result> ReportOrder(Nullable<int> stype, string search, string fromdate, string todate, Nullable<int> pageSize, Nullable<int> pageindex)
        {
            var stypeParameter = stype.HasValue ?
                new ObjectParameter("stype", stype) :
                new ObjectParameter("stype", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            var fromdateParameter = fromdate != null ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(string));
    
            var todateParameter = todate != null ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("pageSize", pageSize) :
                new ObjectParameter("pageSize", typeof(int));
    
            var pageindexParameter = pageindex.HasValue ?
                new ObjectParameter("pageindex", pageindex) :
                new ObjectParameter("pageindex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportOrder_Result>("ReportOrder", stypeParameter, searchParameter, fromdateParameter, todateParameter, pageSizeParameter, pageindexParameter);
        }
    
        public virtual ObjectResult<ReportOrderExcel_Result> ReportOrderExcel(Nullable<int> stype, string search, string fromdate, string todate)
        {
            var stypeParameter = stype.HasValue ?
                new ObjectParameter("stype", stype) :
                new ObjectParameter("stype", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            var fromdateParameter = fromdate != null ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(string));
    
            var todateParameter = todate != null ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportOrderExcel_Result>("ReportOrderExcel", stypeParameter, searchParameter, fromdateParameter, todateParameter);
        }
    
        public virtual ObjectResult<ReportOrderSales_Result> ReportOrderSales(Nullable<int> uID, Nullable<int> stype, string search, string fromdate, string todate, Nullable<int> pageSize, Nullable<int> pageindex)
        {
            var uIDParameter = uID.HasValue ?
                new ObjectParameter("UID", uID) :
                new ObjectParameter("UID", typeof(int));
    
            var stypeParameter = stype.HasValue ?
                new ObjectParameter("stype", stype) :
                new ObjectParameter("stype", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            var fromdateParameter = fromdate != null ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(string));
    
            var todateParameter = todate != null ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(string));
    
            var pageSizeParameter = pageSize.HasValue ?
                new ObjectParameter("pageSize", pageSize) :
                new ObjectParameter("pageSize", typeof(int));
    
            var pageindexParameter = pageindex.HasValue ?
                new ObjectParameter("pageindex", pageindex) :
                new ObjectParameter("pageindex", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportOrderSales_Result>("ReportOrderSales", uIDParameter, stypeParameter, searchParameter, fromdateParameter, todateParameter, pageSizeParameter, pageindexParameter);
        }
    
        public virtual ObjectResult<ReportOrderSalesExcel_Result> ReportOrderSalesExcel(Nullable<int> uID, Nullable<int> stype, string search, string fromdate, string todate)
        {
            var uIDParameter = uID.HasValue ?
                new ObjectParameter("UID", uID) :
                new ObjectParameter("UID", typeof(int));
    
            var stypeParameter = stype.HasValue ?
                new ObjectParameter("stype", stype) :
                new ObjectParameter("stype", typeof(int));
    
            var searchParameter = search != null ?
                new ObjectParameter("search", search) :
                new ObjectParameter("search", typeof(string));
    
            var fromdateParameter = fromdate != null ?
                new ObjectParameter("fromdate", fromdate) :
                new ObjectParameter("fromdate", typeof(string));
    
            var todateParameter = todate != null ?
                new ObjectParameter("todate", todate) :
                new ObjectParameter("todate", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<ReportOrderSalesExcel_Result>("ReportOrderSalesExcel", uIDParameter, stypeParameter, searchParameter, fromdateParameter, todateParameter);
        }
    }
}
