﻿using NHST.Bussiness;
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
using MB.Extensions;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;

namespace NHST.manager
{
    public partial class Tariff_Volume : System.Web.UI.Page
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
                    string username_current = Session["userLoginSystem"].ToString();
                    tbl_Account ac = AccountController.GetByUsername(username_current);
                    if (ac.RoleID != 0)
                        Response.Redirect("/trang-chu");
                    LoadData();
                    LoadPrefix();
                }
            }
        }
        public void LoadPrefix()
        {
            var shipping = ShippingTypeToWareHouseController.GetAllWithIsHidden(true);
            if (shipping.Count > 0)
            {
                foreach (var item in shipping)
                {
                    ListItem us = new ListItem(item.ShippingTypeName, item.ID.ToString());                   
                    ddlShipping.Items.Add(us);
                    ddlShippingType.Items.Add(us);
                }                
            }

            var khotq = WarehouseFromController.GetAllWithIsHidden(false);
            if (khotq.Count > 0)
            {
                foreach (var item in khotq)
                {
                    ListItem us = new ListItem(item.WareHouseName, item.ID.ToString());
                    ddlKhoChina.Items.Add(us);
                }
            }         

            var khovn = WarehouseController.GetAllWithIsHidden(false);
            if (khovn.Count > 0)
            {
                foreach (var item in khovn)
                {
                    ListItem us = new ListItem(item.WareHouseName, item.ID.ToString());
                    ddlKhoViet.Items.Add(us);
                }
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchname = search_name.Text.Trim();
            if (!string.IsNullOrEmpty(searchname))
            {
                Response.Redirect("Tariff-Volume.aspx?s=" + searchname);
            }
            else
            {
                Response.Redirect("Tariff-Volume.aspx");
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
            var la = VolumeController.GetAllVolumeList(search, 999, page);
            if (la.Count > 0)
            {
                var total = la[0].TotalRow.Value;
                pagingall(la, total);
            }
        }

        #region Pagging
        public void pagingall(List<GetVolumeList_Result> acs, int total)
        {
            int PageSize = 999;
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
                    string hiden = "";
                    if (item.IsHelpMoving.Value)
                    {
                        hiden = "<span class=\"badge blue white-text text-darken-2 border-radius-2 font-weight-500\">Đơn ký gửi</span>";
                    }
                    else
                    {
                        hiden = "<span class=\"badge red white-text text-darken-2 border-radius-2 font-weight-500\">Đơn hàng mua hộ</span>";
                    }
                    hcm.Append("<tr>");
                    hcm.Append("<td>" + item.ID + "</td>");
                    hcm.Append("<td>" + item.WareHouseFromName + "</td>");
                    hcm.Append("<td>" + item.WareHouseToName + "</td>");
                    hcm.Append("<td>" + item.VolumeFrom + "</td>");
                    hcm.Append("<td>" + item.VolumeTo + "</td>");
                    hcm.Append("<td>" + string.Format("{0:N0}", Convert.ToDouble(item.ValueVolume)) + "</td>");
                    hcm.Append("<td>" + item.ShippingTypeName + "</td>");
                    hcm.Append("<td>" + hiden + "</td>");
                    hcm.Append("<td>");
                    hcm.Append("<div class=\"action-table\">");
                    hcm.Append("<a href=\"#modalEditFee\" onclick=\"EditFunction(" + item.ID + ")\" class=\"modal-trigger\" data-position=\"top\"> ");
                    hcm.Append("<i class=\"material-icons\">edit</i><span>Sửa</span></a>");



                    hcm.Append("    <a href=\"javascript:;\" onclick=\"CancelOrder('" + item.ID + "')\" data-position=\"top\" ><i class=\"material-icons\">delete</i><span>Xóa</span></a>");

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
                pageUrl += "&Page={0}";
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

        protected void btnCancel_Click(object sender, EventArgs e)
        {           
            string username = Session["userLoginSystem"].ToString();
            var obj_user = AccountController.GetByUsername(username);
            if (obj_user != null)
            {
                int ID = hdfID.Value.ToInt();
                if (ID > 0)
                {
                    var fee = VolumeController.GetByID(ID);
                    if (fee != null)
                    {
                        var kq = VolumeController.DeleteVolume(ID);
                        if (kq != null)
                        {
                            PJUtils.ShowMessageBoxSwAlert("Xóa mức giá vận chuyển thành công.", "s", true, Page);
                        }
                        else
                        {
                            PJUtils.ShowMessageBoxSwAlert("Có lỗi trong quá trình xử lý. Vui lòng thử lại.", "e", true, Page);
                        }
                    }
                }
            }
        }

        [WebMethod]
        public static string loadinfo(string ID)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            var f = VolumeController.GetByID(ID.ToInt(0));
            if (f != null)
            {
                ListByHDK l = new ListByHDK();
                var Wfrom = WarehouseFromController.GetByID(f.WarehouseFromID.Value);
                if (Wfrom != null)
                    l.WFromName = Wfrom.WareHouseName;
                var WTo = WarehouseController.GetByID(f.WarehouseToID.Value);
                if (WTo != null)
                    l.WToName = WTo.WareHouseName;
                l.WeightFrom = f.VolumeFrom.ToString();
                l.WeightTo = f.VolumeTo.ToString();
                l.ShippingType = f.ShippingType.ToString();
                l.ShippingTypeToWareHouseID = f.ShippingTypeToWareHouseID.ToString();
                l.IsHelpMoving = Convert.ToInt32(f.IsHelpMoving.Value).ToString();
                l.Price = f.ValueVolume.ToString();
                return serializer.Serialize(l);
            }
            return serializer.Serialize(null);
        }
        public partial class ListByHDK
        {
            public string WeightFrom { get; set; }
            public string WeightTo { get; set; }
            public string ShippingType { get; set; }
            public string ShippingTypeToWareHouseID { get; set; }
            public string IsHelpMoving { get; set; }
            public string Price { get; set; }
            public string WFromName { get; set; }
            public string WToName { get; set; }
        }
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            int ID = hdfID.Value.ToInt(0);
            var f = VolumeController.GetByID(ID);
            string BackLink = "/manager/tariff-Volume.aspx";
            if (f != null)
            {
                string Username = Session["userLoginSystem"].ToString();
                double WeightFrom = Convert.ToDouble(txtEditWeightFrom.Text);
                double WeightTo = Convert.ToDouble(txtEditWeighTo.Text);
                double Amount = Convert.ToDouble(txtEditFee.Text);
                tbl_Volume model = new tbl_Volume()
                {
                    ID = ID,
                    WarehouseFromID = f.WarehouseFromID,
                    WarehouseToID = f.WarehouseToID,
                    VolumeFrom = WeightFrom,
                    VolumeTo = WeightTo,
                    ValueVolume = Amount,
                    ShippingType = Convert.ToInt32(ddlShipping.SelectedValue),
                    ShippingTypeToWareHouseID = Convert.ToInt32(ddlShipping.SelectedValue),
                    IsHidden = f.IsHidden,
                    IsHelpMoving = Convert.ToBoolean(lbType.SelectedValue.ToInt(0)),
                    CreatedBy = f.CreatedBy,
                    CreatedDate = f.CreatedDate,
                    ModifiedBy = Username,
                    ModifiedDate = DateTime.UtcNow.AddHours(7)
                };
                string kq = VolumeController.UpdateVolume(model);
                if (kq.ToInt(0) > 0)
                    PJUtils.ShowMessageBoxSwAlertBackToLink("Chỉnh sửa chi phí thành công", "s", true, BackLink, Page);
            }
            else
            {
                PJUtils.ShowMessageBoxSwAlert("Không tồn tại chi phí này.", "e", false, Page);
            }
        }

        protected void btnCreateFee_Click(object sender, EventArgs e)
        {
            string username = Session["userLoginSystem"].ToString();           

            double WeightFrom = Convert.ToDouble(AmountFrom.Text);
            double WeightTo = Convert.ToDouble(AmountTo.Text);
            double Amount = Convert.ToDouble(AmountPrice.Text);

            bool OrderType = Convert.ToBoolean(lbTypeAdd.SelectedValue.ToInt(0));
            int HinhThuc = Convert.ToInt32(ddlShippingType.SelectedValue.ToInt(1));
            int KhoChina = Convert.ToInt32(ddlKhoChina.SelectedValue.ToInt(1));
            int KhoViet = Convert.ToInt32(ddlKhoViet.SelectedValue.ToInt(1));
            tbl_Volume model = new tbl_Volume()
            {
                IsHelpMoving = OrderType,
                IsHidden = false,
                CreatedBy = username,
                CreatedDate = DateTime.UtcNow.AddHours(7).ToString(),
                ShippingType =HinhThuc,
                ShippingTypeToWareHouseID = HinhThuc,
                ValueVolume = Amount,
                VolumeFrom = WeightFrom,
                VolumeTo = WeightTo,
                WarehouseFromID = KhoChina,
                WarehouseToID = KhoViet
            };

            string kq = VolumeController.InsertVolume(model);

            if (kq.ToInt(0) > 0)
                PJUtils.ShowMessageBoxSwAlert("Thêm mức giá thành công", "s", true, Page);
        }    
    }
}