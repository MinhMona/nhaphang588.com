using NHST.Bussiness;
using NHST.Controllers;
using NHST.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZLADIPJ.Business;
using Telerik.Web.UI;
using System.Data;
using System.Text;
using MB.Extensions;
using System.IO;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Text.RegularExpressions;

namespace NHST.manager
{
    public partial class kien_troi_noi : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["userLoginSystem"] == null)
                {
                    Response.Redirect("/trang-chu");
                }
                else
                {
                    LoadData();
                    LoadFrom();
                    LoadDDL();
                }
            }
        }

        public void LoadDDL()
        {
            var user = AccountController.GetAllByRoleIDNotHiden(1);
            if (user.Count > 0)
            {
                ddlUsername.DataSource = user;
                ddlUsername.DataBind();
            }

            var user1 = AccountController.GetAllByRoleIDNotHiden(1);
            if (user1.Count > 0)
            {
                ddlUsername1.DataSource = user1;
                ddlUsername1.DataBind();
            }

            var khotq = WarehouseFromController.GetAllWithIsHidden(false);
            if (khotq.Count > 0)
            {
                foreach (var item in khotq)
                {
                    ListItem us = new ListItem(item.WareHouseName, item.ID.ToString());
                    ddlKhoTQ.Items.Add(us);
                }
            }

            var khovn = WarehouseController.GetAllWithIsHidden(false);
            if (khovn.Count > 0)
            {
                foreach (var item in khovn)
                {
                    ListItem us = new ListItem(item.WareHouseName, item.ID.ToString());
                    ddlKhoVN.Items.Add(us);
                }
            }

            var shipping = ShippingTypeToWareHouseController.GetAllWithIsHidden(false);
            if (shipping.Count > 0)
            {
                foreach (var item in shipping)
                {
                    ListItem us = new ListItem(item.ShippingTypeName, item.ID.ToString());
                    ddlPTVC.Items.Add(us);
                }
            }
        }

        private void LoadFrom()
        {
            var bp = BigPackageController.GetAll("");
            if (bp.Count > 0)
            {
                ddlPrefix.Items.Clear();
                ddlPrefix.Items.Insert(0, "Chọn bao hàng");
                foreach (var item in bp)
                {
                    ListItem listitem = new ListItem(item.PackageCode, item.ID.ToString());
                    ddlPrefix.Items.Add(listitem);
                }
                ddlPrefix.DataBind();
            }
            string username_current = Session["userLoginSystem"].ToString();
            tbl_Account ac = AccountController.GetByUsername(username_current);
            if (ac != null)
            {
                int roleID = ac.RoleID.ToString().ToInt();
                if (roleID == 0)
                {
                    txtEditOrderTransaction.Enabled = true;
                    txtEditProductType.Enabled = true;
                    txtEditFeeShip.Enabled = true;
                    txtEditWeight.Enabled = true;
                    txtEditVolume.Enabled = true;
                }
                else
                {
                    txtEditOrderTransaction.Enabled = false;
                    txtEditProductType.Enabled = false;
                    txtEditFeeShip.Enabled = false;
                    txtEditWeight.Enabled = false;
                    txtEditVolume.Enabled = false;
                }
            }
        }

        private void LoadData()
        {
            string search = "";
            if (!string.IsNullOrEmpty(Request.QueryString["s"]))
            {
                search = Request.QueryString["s"].ToString().Trim();
                search_name.Text = search;
            }
            int page = 0;
            Int32 Page = GetIntFromQueryString("Page");
            if (Page > 0)
            {
                page = Page - 1;
            }
            var total = SmallPackageController.GetTotalTroiNoiBySQL(search);
            var la = SmallPackageController.GetAllTroiNoiBySQL(search, 20, page);
            pagingall(la, total);
        }

        #region button event
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchname = search_name.Text.Trim();
            if (!string.IsNullOrEmpty(searchname))
            {
                Response.Redirect("kien-troi-noi?s=" + searchname);
            }
            else
            {
                Response.Redirect("kien-troi-noi");
            }
        }
        #endregion
        #region Pagging
        public void pagingall(List<tbl_SmallPackage> acs, int total)
        {
            int PageSize = 20;
            if (total > 0)
            {
                int TotalItems = total;
                if (TotalItems % PageSize == 0)
                    PageCount = TotalItems / PageSize;
                else
                    PageCount = TotalItems / PageSize + 1;

                Int32 Page = GetIntFromQueryString("Page");

                if (Page == -1) Page = 1;
                int FromRow = (Page - 1) * PageSize;
                int ToRow = Page * PageSize - 1;
                if (ToRow >= TotalItems)
                    ToRow = TotalItems - 1;
                StringBuilder hcm = new StringBuilder();
                for (int i = 0; i < acs.Count; i++)
                {
                    var item = acs[i];
                    var baoHang = BigPackageController.GetByID(item.BigPackageID.Value);
                    string mabaohang = "";
                    if (baoHang != null)
                        mabaohang = baoHang.PackageCode;

                    int sttcf = 0;
                    if (!string.IsNullOrEmpty(item.StatusConfirm.ToString()))
                    {
                        sttcf = Convert.ToInt32(item.StatusConfirm);
                    }

                    hcm.Append("<tr>");
                    hcm.Append("<td>" + item.ID + "</td>");
                    hcm.Append("<td>" + mabaohang + "</td>");
                    hcm.Append("<td>" + item.OrderTransactionCode + "</td>");
                    //hcm.Append("<td>" + item.MainOrderID + "</td>");
                    hcm.Append("<td>" + item.ProductType + "</td>");
                    hcm.Append("<td>" + item.Description + "</td>");
                    hcm.Append("<td>" + item.Weight + "</td>");
                    //hcm.Append("<td>" + item.Volume + "</td>");
                    hcm.Append("<td>" + PJUtils.IntToStringStatusSmallPackageWithBG45(item.Status.Value) + "</td>");
                    hcm.Append("<td>" + item.Username + "</td>");
                    hcm.Append("<td>" + PJUtils.IntToStringStatusConfirm(sttcf) + "</td>");
                    hcm.Append("<td>" + item.CreatedDate.Value.ToString("dd/MM/yyyy HH:mm") + "</td>");
                    hcm.Append("<td>");
                    hcm.Append("<div class=\"action-table\">");
                    //hcm.Append("<a href=\"#\" class=\"edit-mode\" id=\"EditFunction-" + item.ID + "\" onclick=\"EditFunction(" + item.ID + ")\" data-position=\"top\" ><i class=\"material-icons\">edit</i><span>Cập nhật</span></a>");
                    //hcm.Append("<a href=\"#modalConfirm\" id=\"ConfirmFunction-" + item.ID + "\" onclick=\"ConfirmFunction(" + item.ID + ")\" class=\" modal-trigger\" data-position=\"top\"><i class=\"material-icons\">done</i><span>Xác nhận</span></a>");
                    hcm.Append("<a href=\"javascript:;\" onclick=\"GetbyTrancode('" + item.ID + "')\" class=\"tooltipped updatebutton\" data-position=\"top\" data-tooltip=\"Gán kiện ký gửi\"><i class=\"material-icons\">add</i></a>");
                    hcm.Append("<a href=\"javascript:;\" onclick=\"GetbyTrancodeOrder('" + item.ID + "')\" class=\"tooltipped updatebutton\" data-position=\"top\" data-tooltip=\"Gán kiện mua hộ\"><i class=\"material-icons\">add</i></a>");

                    hcm.Append("</div>");
                    hcm.Append("</td>");
                    hcm.Append("</tr>");
                }
                ltr.Text = hcm.ToString();
            }
        }

        public static Int32 GetIntFromQueryString(String key)
        {
            Int32 returnValue = -1;
            String queryStringValue = HttpContext.Current.Request.QueryString[key];
            try
            {
                if (queryStringValue == null)
                    return returnValue;
                if (queryStringValue.IndexOf("#") > 0)
                    queryStringValue = queryStringValue.Substring(0, queryStringValue.IndexOf("#"));
                returnValue = Convert.ToInt32(queryStringValue);
            }
            catch
            { }
            return returnValue;
        }
        private int PageCount;
        protected void DisplayHtmlStringPaging1()
        {
            Int32 CurrentPage = Convert.ToInt32(Request.QueryString["Page"]);
            if (CurrentPage == -1) CurrentPage = 1;
            string[] strText = new string[4] { "Trang đầu", "Trang cuối", "Trang sau", "Trang trước" };
            if (PageCount > 1)
                Response.Write(GetHtmlPagingAdvanced(6, CurrentPage, PageCount, Context.Request.RawUrl, strText));
        }
        private static string GetPageUrl(int currentPage, string pageUrl)
        {
            pageUrl = Regex.Replace(pageUrl, "(\\?|\\&)*" + "Page=" + currentPage, "");
            if (pageUrl.IndexOf("?") > 0)
            {
                if (pageUrl.IndexOf("Page=") > 0)
                {
                    int a = pageUrl.IndexOf("Page=");
                    int b = pageUrl.Length;
                    pageUrl.Remove(a, b - a);
                }
                else
                {
                    pageUrl += "&Page={0}";
                }

            }
            else
            {
                pageUrl += "?Page={0}";
            }
            return pageUrl;
        }
        public static string GetHtmlPagingAdvanced(int pagesToOutput, int currentPage, int pageCount, string currentPageUrl, string[] strText)
        {
            //Nếu Số trang hiển thị là số lẻ thì tăng thêm 1 thành chẵn
            if (pagesToOutput % 2 != 0)
            {
                pagesToOutput++;
            }

            //Một nửa số trang để đầu ra, đây là số lượng hai bên.
            int pagesToOutputHalfed = pagesToOutput / 2;

            //Url của trang
            string pageUrl = GetPageUrl(currentPage, currentPageUrl);


            //Trang đầu tiên
            int startPageNumbersFrom = currentPage - pagesToOutputHalfed; ;

            //Trang cuối cùng
            int stopPageNumbersAt = currentPage + pagesToOutputHalfed; ;

            StringBuilder output = new StringBuilder();

            //Nối chuỗi phân trang
            //output.Append("<div class=\"paging\">");
            //output.Append("<ul class=\"paging_hand\">");

            //Link First(Trang đầu) và Previous(Trang trước)
            if (currentPage > 1)
            {
                //output.Append("<li class=\"UnselectedPrev \" ><a title=\"" + strText[0] + "\" href=\"" + string.Format(pageUrl, 1) + "\">|<</a></li>");
                //output.Append("<li class=\"UnselectedPrev\" ><a title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\"><i class=\"fa fa-angle-left\"></i></a></li>");
                output.Append("<a class=\"prev-page pagi-button\" title=\"" + strText[1] + "\" href=\"" + string.Format(pageUrl, currentPage - 1) + "\">Prev</a>");
                //output.Append("<span class=\"Unselect_prev\"><a href=\"" + string.Format(pageUrl, currentPage - 1) + "\"></a></span>");
            }

            /******************Xác định startPageNumbersFrom & stopPageNumbersAt**********************/
            if (startPageNumbersFrom < 1)
            {
                startPageNumbersFrom = 1;

                //As page numbers are starting at one, output an even number of pages.  
                stopPageNumbersAt = pagesToOutput;
            }

            if (stopPageNumbersAt > pageCount)
            {
                stopPageNumbersAt = pageCount;
            }

            if ((stopPageNumbersAt - startPageNumbersFrom) < pagesToOutput)
            {
                startPageNumbersFrom = stopPageNumbersAt - pagesToOutput;
                if (startPageNumbersFrom < 1)
                {
                    startPageNumbersFrom = 1;
                }
            }
            /******************End: Xác định startPageNumbersFrom & stopPageNumbersAt**********************/

            //Các dấu ... chỉ những trang phía trước  
            if (startPageNumbersFrom > 1)
            {
                output.Append("<a href=\"" + string.Format(GetPageUrl(currentPage - 1, pageUrl), startPageNumbersFrom - 1) + "\">&hellip;</a>");
            }

            //Duyệt vòng for hiển thị các trang
            for (int i = startPageNumbersFrom; i <= stopPageNumbersAt; i++)
            {
                if (currentPage == i)
                {
                    output.Append("<a class=\"pagi-button current-active\">" + i.ToString() + "</a>");
                }
                else
                {
                    output.Append("<a class=\"pagi-button\" href=\"" + string.Format(pageUrl, i) + "\">" + i.ToString() + "</a>");
                }
            }

            //Các dấu ... chỉ những trang tiếp theo  
            if (stopPageNumbersAt < pageCount)
            {
                output.Append("<a href=\"" + string.Format(pageUrl, stopPageNumbersAt + 1) + "\">&hellip;</a>");
            }

            //Link Next(Trang tiếp) và Last(Trang cuối)
            if (currentPage != pageCount)
            {
                //output.Append("<span class=\"Unselect_next\"><a href=\"" + string.Format(pageUrl, currentPage + 1) + "\"></a></span>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\"><i class=\"fa fa-angle-right\"></i></a></li>");
                output.Append("<a class=\"next-page pagi-button\" title=\"" + strText[2] + "\" href=\"" + string.Format(pageUrl, currentPage + 1) + "\">Next</a>");
                //output.Append("<li class=\"UnselectedNext\" ><a title=\"" + strText[3] + "\" href=\"" + string.Format(pageUrl, pageCount) + "\">>|</a></li>");
            }
            //output.Append("</ul>");
            //output.Append("</div>");
            return output.ToString();
        }
        #endregion

        protected void btnConfirm_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            string username_current = Session["userLoginSystem"].ToString();
            DateTime currendDate = DateTime.Now;
            int id = hdfID.Value.ToInt(0);
            var s = SmallPackageController.GetByID(id);
            if (s != null)
            {
                string code = txtMainOrderCode.Text;
                int UID = Convert.ToInt32(txtUID.Text);
                if (UID > 0)
                {
                    var acc = AccountController.GetByID(UID);
                    var mainOrderCode = MainOrderCodeController.GetByCode(code);
                    if (mainOrderCode != null)
                    {
                        var mainOrder = MainOrderController.GetByIDAndUID(mainOrderCode.MainOrderID ?? 0, UID);
                        if (mainOrder != null)
                        {
                            string kq = SmallPackageController.UpdateLost(id, mainOrder.ID, mainOrderCode.ID, UID, acc.Username, currendDate, username_current);
                            if (kq.ToInt(0) > 0)
                            {
                                int QuantityBarcode = mainOrder.QuantityBarcode ?? 0 + 1;
                                string ListMVD = mainOrder.Barcode;
                                ListMVD += s.OrderTransactionCode + " | ";
                                MainOrderController.UpdateBarcode(mainOrder.ID, ListMVD);
                                MainOrderController.UpdateQuantityBarcode(mainOrder.ID, QuantityBarcode);
                                PJUtils.ShowMessageBoxSwAlert("Cập nhật thành công.", "s", true, Page);
                            }
                            else
                            {
                                PJUtils.ShowMessageBoxSwAlert("Cập nhật thất bại.", "e", true, Page);
                            }
                        }
                    }
                    else
                    {
                        PJUtils.ShowMessageBoxSwAlert("Mã đơn hàng không tồn tại.", "e", true, Page);
                    }
                }
            }
        }
        //protected void btnConfirm2_Click(object sender, EventArgs e)
        //{
        //    if (!Page.IsValid) return;
        //    string username_current = Session["userLoginSystem"].ToString();
        //    DateTime currendDate = DateTime.Now;
        //    int id = hdfID.Value.ToInt(0);
        //    var s = SmallPackageController.GetByID(id);
        //    if (s != null)
        //    {
        //        string code = txtMainOrderCode.Text;
        //        int UID = Convert.ToInt32(txtUID.Text);
        //        if (UID > 0)
        //        {
        //            var acc = AccountController.GetByID(UID);
        //            var mainOrderCode = MainOrderCodeController.GetByCode(code);
        //            var mainOrder = MainOrderController.GetByIDAndUID(mainOrderCode.MainOrderID ?? 0, UID);
        //            if (mainOrder != null)
        //            {
        //                string kq = SmallPackageController.UpdateLost(id, mainOrder.ID, UID, acc.Username, currendDate, username_current);
        //                if (kq.ToInt(0) > 0)
        //                {
        //                    PJUtils.ShowMessageBoxSwAlert("Cập nhật thành công.", "s", true, Page);
        //                }
        //                else
        //                {
        //                    PJUtils.ShowMessageBoxSwAlert("Cập nhật thất bại.", "e", true, Page);
        //                }
        //            }
        //            else
        //            {
        //                PJUtils.ShowMessageBoxSwAlert("Mã đơn hàng không tồn tại.", "e", true, Page);
        //            }
        //        }
        //    }
        //}

        [WebMethod]
        public static string GetpackageID(string packageID)
        {
            if (HttpContext.Current.Session["userLoginSystem"] != null)
            {
                string username = HttpContext.Current.Session["userLoginSystem"].ToString();
                var user = AccountController.GetByUsername(username);
                if (user != null)
                {
                    int userRole = Convert.ToInt32(user.RoleID);

                    if (userRole == 0 || userRole == 2 || userRole == 5)
                    {
                        if (!string.IsNullOrEmpty(packageID))
                        {

                            var sm = SmallPackageController.GetByID(packageID.ToInt(0));
                            if (sm != null)
                            {
                                JavaScriptSerializer serializer = new JavaScriptSerializer();
                                return serializer.Serialize(sm);
                            }
                            else
                            {
                                return "none";
                            }
                        }
                        else
                        {
                            return "none";
                        }
                    }
                    else
                        return "none";
                }
                else
                {
                    return "none";
                }
            }
            else
            {
                return "none";
            }
        }
        [WebMethod]
        public static string UpdateKyGui(string ordertransaction, string Username, string KhoTQ, string KhoVN, string PTVC)
        {
            if (HttpContext.Current.Session["userLoginSystem"] != null)
            {
                string username_check = HttpContext.Current.Session["userLoginSystem"].ToString();
                DateTime currentDate = DateTime.UtcNow.AddHours(7);
                var user_check = AccountController.GetByUsername(username_check);
                if (user_check != null)
                {
                    double currency = 0;
                    var config = ConfigurationController.GetByTop1();
                    if (config != null)
                    {
                        currency = Convert.ToDouble(config.Currency);
                    }
                    int userRole_check = Convert.ToInt32(user_check.RoleID);
                    if (userRole_check == 0 || userRole_check == 2 || userRole_check == 5)
                    {
                        var checkcode = SmallPackageController.GetTroiNoi(ordertransaction);
                        if (checkcode != null)
                        {
                            var checkuser = AccountController.GetByUsername(AccountController.GetByID(Convert.ToInt32(Username)).Username);
                            if (checkuser != null)
                            {
                                int SaleID = 0;
                                string SaleName = "";
                                SaleID = Convert.ToInt32(checkuser.SaleID);
                                if (SaleID > 0)
                                {
                                    var sale = AccountController.GetByID(SaleID);
                                    if (sale != null)
                                    {
                                        SaleName = sale.Username;
                                    }
                                }
                                string tID = TransportationOrderController.InsertNew(checkuser.ID, checkuser.Username,
                                KhoTQ.ToInt(0), KhoVN.ToInt(0), PTVC.ToInt(0), 5, 0, currency, 0, 0, 0, 0, 0, 0, "", currentDate, user_check.Username);

                                if (tID.ToInt(0) > 0)
                                {
                                    TransportationOrderDetailController.InsertNew(tID.ToInt(0), ordertransaction, 0, "",
                                    false, false, false, "0", "0", "", "", currentDate, user_check.Username);
                                    TransportationOrderController.UpdatSale(tID.ToInt(0), SaleID, SaleName);

                                    SmallPackageController.UpdateTransportationOrderID(checkcode.ID, tID.ToInt(0));
                                    SmallPackageController.UpdateDateInVNWareHouse(checkcode.ID, user_check.Username, currentDate);
                                    SmallPackageController.UpdateNotTemp(checkcode.ID);
                                    SmallPackageController.UpdateStatus(checkcode.ID, 3, currentDate, user_check.Username);
                                    SmallPackageController.UpdateInforUser(checkcode.ID, checkuser.ID, checkuser.Username, "");

                                    var transportation = TransportationOrderController.GetByID(Convert.ToInt32(tID.ToInt(0)));
                                    if (transportation != null)
                                    {
                                        int warehouseFrom = Convert.ToInt32(transportation.WarehouseFromID);
                                        int warehouse = Convert.ToInt32(transportation.WarehouseID);
                                        int shipping = Convert.ToInt32(transportation.ShippingTypeID);

                                        var packages = SmallPackageController.GetByTransportationOrderID(transportation.ID);
                                        if (packages.Count > 0)
                                        {
                                            var usercreate = AccountController.GetByID(Convert.ToInt32(transportation.UID));
                                            double returnprice = 0;
                                            double totalweight = 0;
                                            double totalWeightTT = 0;
                                            double pricePerWeight = 0;
                                            double finalPriceOfPackage = 0;

                                            foreach (var item in packages)
                                            {
                                                double weight = Convert.ToDouble(item.Weight);
                                                double pDai = Convert.ToDouble(item.Length);
                                                double pRong = Convert.ToDouble(item.Width);
                                                double pCao = Convert.ToDouble(item.Height);
                                                if (pDai > 0 && pRong > 0 && pCao > 0)
                                                {
                                                    totalWeightTT += (pDai * pRong * pCao) / 1000000;
                                                }

                                                totalweight += weight;

                                            }

                                            totalweight = Math.Round(totalweight, 2);
                                            if (usercreate.FeeTQVNPerWeight.ToFloat(0) > 0)
                                            {
                                                pricePerWeight = Convert.ToDouble(usercreate.FeeTQVNPerWeight);
                                                returnprice = totalweight * pricePerWeight;
                                            }
                                            else
                                            {
                                                if (totalweight > totalWeightTT)
                                                {
                                                    var fee = WarehouseFeeController.GetByAndWarehouseFromAndToWarehouseAndShippingTypeAndAndHelpMoving(
                                                    warehouseFrom, warehouse, shipping, true);
                                                    if (fee.Count > 0)
                                                    {
                                                        foreach (var f in fee)
                                                        {
                                                            if (totalweight > f.WeightFrom && totalweight <= f.WeightTo)
                                                            {
                                                                pricePerWeight = Convert.ToDouble(f.Price);
                                                                returnprice = totalweight * Convert.ToDouble(f.Price);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                                else
                                                {
                                                    var fee = VolumeController.GetAllByFromWareHouseToWareHouse(warehouseFrom, warehouse, shipping, false);
                                                    if (fee.Count > 0)
                                                    {
                                                        foreach (var f in fee)
                                                        {
                                                            if (totalWeightTT > f.VolumeFrom && totalWeightTT <= f.VolumeTo)
                                                            {
                                                                pricePerWeight = Convert.ToDouble(f.ValueVolume);
                                                                returnprice = totalWeightTT * Convert.ToDouble(f.ValueVolume);
                                                                break;
                                                            }
                                                        }
                                                    }
                                                }
                                            }

                                            foreach (var item in packages)
                                            {
                                                double compareSize = 0;
                                                double weight = Convert.ToDouble(item.Weight);
                                                double pDai = Convert.ToDouble(item.Length);
                                                double pRong = Convert.ToDouble(item.Width);
                                                double pCao = Convert.ToDouble(item.Height);
                                                if (pDai > 0 && pRong > 0 && pCao > 0)
                                                {
                                                    compareSize = (pDai * pRong * pCao) / 1000000;
                                                }
                                                if (weight >= compareSize)
                                                {
                                                    double TotalPriceCN = Math.Round(weight * pricePerWeight, 0);
                                                    SmallPackageController.UpdateTotalPrice(item.ID, TotalPriceCN);
                                                }
                                                else
                                                {
                                                    double TotalPriceTT = Math.Round(compareSize * pricePerWeight, 0);
                                                    SmallPackageController.UpdateTotalPrice(item.ID, TotalPriceTT);
                                                }
                                            }

                                            finalPriceOfPackage = Math.Round(returnprice, 0);

                                            double CheckProductFee = Convert.ToDouble(transportation.CheckProductFee);
                                            double PackagedFee = Convert.ToDouble(transportation.PackagedFee);
                                            double TotalCODTQVND = Convert.ToDouble(transportation.TotalCODTQVND);
                                            double InsurranceFee = Convert.ToDouble(transportation.InsurranceFee);

                                            double totalPriceVND = finalPriceOfPackage + CheckProductFee + PackagedFee + TotalCODTQVND + InsurranceFee;

                                            double totalPriceCYN = 0;
                                            totalPriceCYN = Math.Round(totalPriceVND / currency, 2);

                                            var setNoti = SendNotiEmailController.GetByID(9);
                                            if (setNoti != null)
                                            {
                                                var acc = AccountController.GetByID(transportation.UID.Value);
                                                if (acc != null)
                                                {
                                                    if (setNoti.IsSentNotiUser == true)
                                                    {
                                                        NotificationsController.Inser(acc.ID,
                                                              acc.Username, transportation.ID,
                                                              "Đơn hàng vận chuyển hộ " + transportation.ID + " Hàng về kho VN.", 10,
                                                              currentDate, user_check.Username, true);
                                                    }

                                                    if (setNoti.IsSendEmailUser == true)
                                                    {
                                                        try
                                                        {
                                                            PJUtils.SendMailGmail("MONAMEDIA", "mrurgljtizcfckzi",
                                                                acc.Email, "Thông báo tại NHẬP HÀNG 558.",
                                                                "Đơn hàng vận chuyển hộ " + transportation.ID + " Hàng về kho VN.", "");
                                                        }
                                                        catch { }
                                                    }
                                                }
                                            }

                                            TransportationOrderController.UpdateTotalWeightTotalPrice(transportation.ID, totalweight, totalWeightTT, totalPriceVND, currentDate, user_check.Username);
                                            TransportationOrderController.UpdateFeeWeight(transportation.ID, finalPriceOfPackage, currentDate, user_check.Username);

                                            return "ok";
                                        }
                                        else
                                        {
                                            return "none";
                                        }
                                    }
                                    else
                                    {
                                        return "none";
                                    }
                                }
                                else
                                {
                                    return "none";
                                }
                            }
                            else
                            {
                                return "2";
                            }
                        }
                        else
                        {
                            return "1";
                        }
                    }
                    else
                        return "none";
                }
                else
                {
                    return "none";
                }
            }
            else
            {
                return "none";
            }
        }

        [WebMethod]
        public static string UpdateMuaHo(string ordertransaction, string Username, int MainOrderID)
        {
            if (HttpContext.Current.Session["userLoginSystem"] != null)
            {
                string username_current = HttpContext.Current.Session["userLoginSystem"].ToString();
                tbl_Account ac = AccountController.GetByUsername(username_current);
                DateTime currentDate = DateTime.UtcNow.AddHours(7);

                int CheckRole = Convert.ToInt32(ac.RoleID);
                if (CheckRole == 0 || CheckRole == 2 || CheckRole == 5)
                {
                    var checkcode = SmallPackageController.GetTroiNoi(ordertransaction);
                    if (checkcode != null)
                    {
                        var checkuser = AccountController.GetByUsername(AccountController.GetByID(Convert.ToInt32(Username)).Username);
                        if (checkuser != null)
                        {
                            var checkmo = MainOrderController.GetAllByUIDAndID(checkuser.ID, MainOrderID);
                            if (checkmo != null)
                            {
                                SmallPackageController.UpdateMainOrderForIsTemp(checkcode.ID, checkuser.ID, checkuser.Username, MainOrderID, ac.Username, currentDate);
                                SmallPackageController.UpdateDateInVNWareHouse(checkcode.ID, ac.Username, currentDate);
                                SmallPackageController.UpdateStatus(checkcode.ID, 3, currentDate, ac.Username);
                                HistoryOrderChangeController.Insert(MainOrderID, ac.ID, ac.Username, ac.Username +
                                " đã thêm mã vận đơn của đơn hàng ID là: " + MainOrderID + ", Mã vận đơn: " + ordertransaction + "", 8, currentDate);

                                if (checkmo.Status < 7)
                                {
                                    if (checkmo.DateVN == null)
                                    {
                                        MainOrderController.UpdateDateVN(checkmo.ID, currentDate);
                                        MainOrderController.UpdateStatus(checkmo.ID, checkuser.ID, 7);
                                        HistoryOrderChangeController.Insert(checkmo.ID, ac.ID, ac.Username, ac.Username +
                                        " đã đổi trạng thái đơn hàng ID là: " + checkmo.ID + ", là: Hàng về kho VN", 8, currentDate);
                                    }
                                }

                                int orderID = checkmo.ID;
                                int warehouse = Convert.ToInt32(checkmo.ReceivePlace);
                                int shipping = Convert.ToInt32(checkmo.ShippingType);
                                int warehouseFrom = Convert.ToInt32(checkmo.FromPlace);
                                var usercreate = AccountController.GetByID(Convert.ToInt32(checkmo.UID));

                                int MainOrderCodeID = 0;
                                var lMainOrderCode = MainOrderCodeController.GetAllByMainOrderID(MainOrderID);
                                if (lMainOrderCode.Count > 0)
                                {
                                    MainOrderCodeID = lMainOrderCode[0].ID;
                                }
                                SmallPackageController.UpdateMainOrderCodeID(checkcode.ID, MainOrderCodeID);

                                double FeeWeight = 0;
                                double FeeWeightDiscount = 0;
                                double ckFeeWeight = 0;
                                double returnprice = 0;
                                double pricePerWeight = 0;
                                double totalweight = 0;
                                ckFeeWeight = Convert.ToDouble(UserLevelController.GetByID(usercreate.LevelID.ToString().ToInt()).FeeWeight.ToString());

                                var smallpackage = SmallPackageController.GetByMainOrderID(orderID);
                                if (smallpackage.Count > 0)
                                {
                                    double totalWeight = 0;
                                    foreach (var item in smallpackage)
                                    {
                                        double compareSize = 0;
                                        double weight = Convert.ToDouble(item.Weight);
                                        double pDai = Convert.ToDouble(item.Length);
                                        double pRong = Convert.ToDouble(item.Width);
                                        double pCao = Convert.ToDouble(item.Height);

                                        if (pDai > 0 && pRong > 0 && pCao > 0)
                                        {
                                            compareSize = (pDai * pRong * pCao) / 6000;
                                        }

                                        if (weight >= compareSize)
                                        {
                                            totalWeight += Math.Round(weight, 1);
                                        }
                                        else
                                        {
                                            totalWeight += Math.Round(compareSize, 1);
                                        }
                                    }

                                    totalweight = Math.Round(totalWeight, 2);

                                    if (usercreate.FeeTQVNPerWeight.ToFloat(0) > 0)
                                    {
                                        pricePerWeight = Convert.ToDouble(usercreate.FeeTQVNPerWeight);
                                        returnprice = totalweight * pricePerWeight;
                                    }
                                    else
                                    {

                                        var fee = WarehouseFeeController.GetByAndWarehouseFromAndToWarehouseAndShippingTypeAndAndHelpMoving(warehouseFrom, warehouse, shipping, false);
                                        if (fee.Count > 0)
                                        {
                                            foreach (var f in fee)
                                            {
                                                if (totalWeight > f.WeightFrom && totalWeight <= f.WeightTo)
                                                {
                                                    pricePerWeight = Convert.ToDouble(f.Price);
                                                    returnprice = totalWeight * Convert.ToDouble(f.Price);
                                                }
                                            }
                                        }
                                    }

                                    foreach (var item in smallpackage)
                                    {
                                        double compareSize = 0;
                                        double weight = Convert.ToDouble(item.Weight);
                                        double pDai = Convert.ToDouble(item.Length);
                                        double pRong = Convert.ToDouble(item.Width);
                                        double pCao = Convert.ToDouble(item.Height);
                                        if (pDai > 0 && pRong > 0 && pCao > 0)
                                        {
                                            compareSize = (pDai * pRong * pCao) / 6000;
                                        }
                                        if (weight >= compareSize)
                                        {
                                            double TotalPriceCN = weight * pricePerWeight;
                                            TotalPriceCN = Math.Round(TotalPriceCN, 0);
                                            SmallPackageController.UpdateTotalPrice(item.ID, TotalPriceCN);
                                        }
                                        else
                                        {
                                            double TotalPriceTT = compareSize * pricePerWeight;
                                            TotalPriceTT = Math.Round(TotalPriceTT, 0);
                                            SmallPackageController.UpdateTotalPrice(item.ID, TotalPriceTT);
                                        }
                                    }
                                }

                                double currency = Convert.ToDouble(checkmo.CurrentCNYVN);
                                FeeWeight = Math.Round(returnprice, 0);
                                FeeWeightDiscount = FeeWeight * ckFeeWeight / 100;
                                FeeWeightDiscount = Math.Round(FeeWeightDiscount, 0);
                                FeeWeight = FeeWeight - FeeWeightDiscount;
                                FeeWeight = Math.Round(FeeWeight, 0);

                                double FeeShipCN = Math.Round(Convert.ToDouble(checkmo.FeeShipCN), 0);
                                double FeeBuyPro = Math.Round(Convert.ToDouble(checkmo.FeeBuyPro), 0);
                                double IsCheckProductPrice = Math.Round(Convert.ToDouble(checkmo.IsCheckProductPrice), 0);
                                double IsPackedPrice = Math.Round(Convert.ToDouble(checkmo.IsPackedPrice), 0);
                                double IsFastDeliveryPrice = Math.Round(Convert.ToDouble(checkmo.IsFastDeliveryPrice), 0);
                                double TotalFeeSupport = Math.Round(Convert.ToDouble(checkmo.TotalFeeSupport), 0);
                                double InsuranceMoney = Math.Round(Convert.ToDouble(checkmo.InsuranceMoney), 0);
                                double isfastprice = 0;
                                if (checkmo.IsFastPrice.ToFloat(0) > 0)
                                    isfastprice = Math.Round(Convert.ToDouble(checkmo.IsFastPrice), 0);
                                double pricenvd = 0;
                                if (checkmo.PriceVND.ToFloat(0) > 0)
                                    pricenvd = Math.Round(Convert.ToDouble(checkmo.PriceVND), 0);
                                double Deposit = Math.Round(Convert.ToDouble(checkmo.Deposit), 0);

                                double TotalPriceVND = FeeShipCN + FeeBuyPro + FeeWeight + IsCheckProductPrice + IsPackedPrice
                                             + IsFastDeliveryPrice + isfastprice + pricenvd + TotalFeeSupport + InsuranceMoney;
                                TotalPriceVND = Math.Round(TotalPriceVND, 0);
                                MainOrderController.UpdateFee(checkmo.ID, Deposit.ToString(), FeeShipCN.ToString(), FeeBuyPro.ToString(), FeeWeight.ToString(),
                                           IsCheckProductPrice.ToString(), IsPackedPrice.ToString(), IsFastDeliveryPrice.ToString(), TotalPriceVND.ToString());
                                MainOrderController.UpdateFeeWeightCK(checkmo.ID, FeeWeightDiscount.ToString(), ckFeeWeight.ToString());
                                MainOrderController.UpdateTotalWeight(checkmo.ID, totalweight.ToString(), totalweight.ToString());

                                var mainOrder = MainOrderController.GetByID(MainOrderID);
                                int QuantityBarcode = mainOrder.QuantityBarcode ?? 0 + 1;
                                string ListMVD = mainOrder.Barcode;
                                ListMVD += ordertransaction + " | ";
                                MainOrderController.UpdateBarcode(mainOrder.ID, ListMVD);
                                MainOrderController.UpdateQuantityBarcode(mainOrder.ID, QuantityBarcode);

                                return "ok";
                            }
                            else
                            {
                                return "1";
                            }
                        }
                        else
                        {
                            return "2";
                        }
                    }
                    return "none";
                }
                return "none";
            }
            return "none";
        }


        [WebMethod]
        public static string loadinfo(string ID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var p = SmallPackageController.GetByID(ID.ToInt(0));
            if (p != null)
            {
                tbl_SmallPackage l = new tbl_SmallPackage();
                l.ID = p.ID;
                l.OrderTransactionCode = p.OrderTransactionCode;
                l.BigPackageID = p.BigPackageID;
                l.MainOrderID = p.MainOrderID;
                l.ProductType = p.ProductType;
                l.FeeShip = p.FeeShip;
                l.Weight = p.Weight;
                l.CreatedDate = p.CreatedDate;
                l.Volume = p.Volume;
                l.Description = p.Description;
                l.Status = p.Status;
                l.ListIMG = p.ListIMG;
                return serializer.Serialize(l);
            }
            return serializer.Serialize(null);
        }
        [WebMethod]
        public static string LoadInforVer2(string ID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var p = SmallPackageController.GetByID(ID.ToInt(0));
            if (p != null)
            {
                tbl_SmallPackage l = new tbl_SmallPackage();
                l.ID = p.ID;
                l.OrderTransactionCode = p.OrderTransactionCode;
                return serializer.Serialize(l);
            }
            return serializer.Serialize(null);
        }
        protected void btncreateuser_Click(object sender, EventArgs e)
        {
            if (!Page.IsValid) return;
            string username_current = Session["userLoginSystem"].ToString();
            DateTime currendDate = DateTime.Now;
            int id = hdfID.Value.ToInt(0);
            var s = SmallPackageController.GetByID(id);
            if (s != null)
            {
                string dbIMG = s.ListIMG;
                string[] listk = { };
                if (!string.IsNullOrEmpty(s.ListIMG))
                {
                    listk = dbIMG.Split('|');
                }
                string value = hdfListIMG.Value;
                string link = "";
                if (!string.IsNullOrEmpty(value))
                {
                    string[] listIMG = value.Split('|');
                    for (int i = 0; i < listIMG.Length - 1; i++)
                    {
                        string imageData = listIMG[i];
                        bool ch = listk.Any(x => x == imageData);
                        if (ch == true)
                        {
                            link += imageData + "|";
                        }
                        else
                        {
                            string path = System.Web.HttpContext.Current.Server.MapPath("~/Uploads/smallpackageIMG/");
                            string date = DateTime.Now.ToString("dd-MM-yyyy");
                            string time = DateTime.Now.ToString("hh:mm tt");
                            Page page = (Page)HttpContext.Current.Handler;
                            //  TextBox txtCampaign = (TextBox)page.FindControl("txtCampaign");
                            string k = i.ToString();
                            string fileNameWitPath = path + k + "-" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "") + ".png";
                            string linkIMG = "/Uploads/smallpackageIMG/" + k + "-" + DateTime.Now.ToString().Replace("/", "-").Replace(" ", "-").Replace(":", "") + ".png";
                            link += linkIMG + "|";
                            //   string fileNameWitPath = path + s + ".png";
                            byte[] data;
                            string convert;
                            using (FileStream fs = new FileStream(fileNameWitPath, FileMode.Create))
                            {
                                using (BinaryWriter bw = new BinaryWriter(fs))
                                {
                                    if (imageData.Contains("data:image/png"))
                                    {
                                        convert = imageData.Replace("data:image/png;base64,", String.Empty);
                                        data = Convert.FromBase64String(convert);
                                        bw.Write(data);
                                    }
                                    else if (imageData.Contains("data:image/jpeg"))
                                    {
                                        convert = imageData.Replace("data:image/jpeg;base64,", String.Empty);
                                        data = Convert.FromBase64String(convert);
                                        bw.Write(data);
                                    }
                                    else if (imageData.Contains("data:image/gif"))
                                    {
                                        convert = imageData.Replace("data:image/gif;base64,", String.Empty);
                                        data = Convert.FromBase64String(convert);
                                        bw.Write(data);
                                    }
                                }
                            }
                        }
                    }
                }
                string current_ordertransactioncode = s.OrderTransactionCode;
                string current_producttype = s.ProductType;

                double current_ship = 0;
                if (s.FeeShip.ToString().ToFloat(0) > 0)
                    current_ship = Convert.ToDouble(s.FeeShip);

                double current_weight = 0;
                if (s.Weight.ToString().ToFloat(0) > 0)
                    current_weight = Convert.ToDouble(s.Weight);

                double current_volume = 0;
                if (s.Volume.ToString().ToFloat(0) > 0)
                    current_volume = Convert.ToDouble(s.Volume);

                int current_status = s.Status.ToString().ToInt();
                int current_BigpackageID = s.BigPackageID.ToString().ToInt(0);

                string new_ordertransactionCode = txtEditOrderTransaction.Text.Trim();
                string new_producttype = txtEditProductType.Text.Trim();

                double new_ship = 0;
                if (txtEditFeeShip.Text.ToFloat(0) > 0)
                    new_ship = Convert.ToDouble(txtEditFeeShip.Text);

                double new_weight = 0;
                if (txtEditWeight.Text.ToFloat(0) > 0)
                    new_weight = Convert.ToDouble(txtEditWeight.Text);

                double new_volume = 0;
                if (txtEditVolume.Text.ToString().ToFloat(0) > 0)
                    new_volume = Convert.ToDouble(txtEditVolume.Text);

                int new_status = ddlStatus.SelectedValue.ToString().ToInt(1);
                int new_BigpackageID = ddlPrefix.SelectedValue.ToString().ToInt(0);
                string new_description = txtEditNote.Text.Trim();
                string kq = SmallPackageController.Update(id, new_BigpackageID, new_ordertransactionCode, new_producttype, new_ship,
                   new_weight, new_volume, new_status, new_description, DateTime.Now, username_current);

                string kt = SmallPackageController.UpdateIMG(id, link, DateTime.Now, username_current);

                var allsmall = SmallPackageController.GetBuyBigPackageID(new_BigpackageID, "");
                if (allsmall.Count > 0)
                {
                    double totalweight = 0;
                    foreach (var item in allsmall)
                    {
                        totalweight += Convert.ToDouble(item.Weight);
                    }
                    BigPackageController.UpdateWeight(new_BigpackageID, totalweight);
                }

                if (current_ordertransactioncode != new_ordertransactionCode)
                {
                    BigPackageHistoryController.Insert(id, "OrderTransactionCode", current_ordertransactioncode, new_ordertransactionCode, 2, currendDate, username_current);
                }
                if (current_producttype != new_producttype)
                {
                    BigPackageHistoryController.Insert(id, "ProductType", current_producttype, new_producttype, 2, currendDate, username_current);
                }
                if (current_ship != new_ship)
                {
                    BigPackageHistoryController.Insert(id, "FeeShip", current_ship.ToString(), new_ship.ToString(), 2, currendDate, username_current);
                }
                if (current_weight != new_weight)
                {
                    BigPackageHistoryController.Insert(id, "Weight", current_weight.ToString(), new_weight.ToString(), 2, currendDate, username_current);
                }
                if (current_volume != new_volume)
                {
                    BigPackageHistoryController.Insert(id, "Volume", current_volume.ToString(), new_volume.ToString(), 2, currendDate, username_current);
                }
                if (current_status != new_status)
                {
                    BigPackageHistoryController.Insert(id, "Status", current_status.ToString(), new_status.ToString(), 2, currendDate, username_current);
                }
                if (current_BigpackageID != new_BigpackageID)
                {
                    BigPackageHistoryController.Insert(id, "BigpackageID", current_BigpackageID.ToString(), new_BigpackageID.ToString(), 2, currendDate, username_current);
                }

                if (kq.ToInt(0) > 0)
                {
                    PJUtils.ShowMessageBoxSwAlert("Cập nhật thành công.", "s", true, Page);
                }
                else
                    PJUtils.ShowMessageBoxSwAlert("Cập nhật thất bại.", "e", true, Page);
            }
        }
    }
}