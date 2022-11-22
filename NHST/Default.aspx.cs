using NHST.Bussiness;
using NHST.Controllers;
using Supremes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace NHST
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadData();
            }
        }

        public void LoadData()
        {
            var confi = ConfigurationController.GetByTop1();
            if (confi != null)
            {
                string email = confi.EmailContact;
                string hotline = confi.Hotline;
                string timework = confi.TimeWork;

                ltrEmail.Text += "<a href=\"mailto:" + email + "\">";
                ltrEmail.Text += "<div class=\"icon\"><i class=\"fa fa-envelope\" aria-hidden=\"true\"></i></div>";
                ltrEmail.Text += "<div class=\"text-number\"><p>" + email + "</p></div>";
                ltrEmail.Text += "</a>";

                ltrTimeWork.Text += "<div class=\"text-number\"><p>" + timework + "</p></div>";

                ltrHotline.Text += "<a href=\"tel:" + hotline + "\">";
                ltrHotline.Text += "<div class=\"content-number wow fadeInUp\">";
                ltrHotline.Text += "<div class=\"icon\"><i class=\"fa fa-phone\" aria-hidden=\"true\"></i></div>";
                ltrHotline.Text += "<div class=\"text-number\"><p>" + hotline + "</p></div>";
                ltrHotline.Text += "</div>";
                ltrHotline.Text += "</a>";

                //ltrHotlineBanner.Text += "<div class=\"hotline-banner\">";
                //ltrHotlineBanner.Text += "<a href=\"tel:" + hotline + "\" class=\"hotline-in\">";
                //ltrHotlineBanner.Text += "<div class=\"icon\"><i class=\"fa fa-phone\" aria-hidden=\"true\"></i></div>";
                //ltrHotlineBanner.Text += "<div class=\"number\"><span>" + hotline + "</span></div>";
                //ltrHotlineBanner.Text += "</a>";
                //ltrHotlineBanner.Text += "</div>";

                try
                {
                    string weblink = "https://nhaphang558.com/";
                    string url = HttpContext.Current.Request.Url.AbsoluteUri;

                    HtmlHead objHeader = (HtmlHead)Page.Header;

                    //we add meta description
                    HtmlMeta objMetaFacebook = new HtmlMeta();

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "fb:app_id");
                    objMetaFacebook.Content = "676758839172144";
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:url");
                    objMetaFacebook.Content = url;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:type");
                    objMetaFacebook.Content = "website";
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:title");
                    objMetaFacebook.Content = confi.OGTitle;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:description");
                    objMetaFacebook.Content = confi.OGDescription;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:image");
                    objMetaFacebook.Content = weblink + confi.OGImage;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:image:width");
                    objMetaFacebook.Content = "200";
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:image:height");
                    objMetaFacebook.Content = "500";
                    objHeader.Controls.Add(objMetaFacebook);

                    HtmlMeta meta = new HtmlMeta();
                    meta = new HtmlMeta();
                    meta.Attributes.Add("name", "description");
                    meta.Content = confi.MetaDescription;

                    meta = new HtmlMeta();
                    meta.Attributes.Add("name", "keyword");
                    meta.Content = confi.MetaKeyword;

                    objHeader.Controls.Add(meta);
                    this.Title = confi.MetaTitle;

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "og:title");
                    objMetaFacebook.Content = confi.OGTitle;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "twitter:title");
                    objMetaFacebook.Content = confi.OGTwitterTitle;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "twitter:description");
                    objMetaFacebook.Content = confi.OGTwitterDescription;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "twitter:image");
                    objMetaFacebook.Content = weblink + confi.OGTwitterImage;
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "twitter:image:width");
                    objMetaFacebook.Content = "200";
                    objHeader.Controls.Add(objMetaFacebook);

                    objMetaFacebook = new HtmlMeta();
                    objMetaFacebook.Attributes.Add("property", "twitter:image:height");
                    objMetaFacebook.Content = "500";
                    objHeader.Controls.Add(objMetaFacebook);

                    HtmlLink canonicalTag = new HtmlLink();
                    canonicalTag.Attributes["rel"] = "canonical";
                    canonicalTag.Href = weblink;
                    Page.Header.Controls.Add(canonicalTag);
                }
                catch
                {

                }
            }
            var services = ServiceController.GetAll();
            if (services.Count > 0)
            {
                foreach (var item in services)
                {
                    ltrServices.Text += "<div class=\"colum\">";
                    ltrServices.Text += "<div class=\"content wow fadeInUp\" data-wow-delay=\".2s\" data-wow-duration=\"1s\">";
                    ltrServices.Text += "<div class=\"icon-ck\"><img src=\"" + item.ServiceIMG + "\" alt=\"\"></div>";
                    ltrServices.Text += "<div class=\"text-box\">";
                    ltrServices.Text += "<h4 class=\"title\"><a href =\"" + item.ServiceLink + "\">" + item.ServiceName + "</a></h4>";
                    ltrServices.Text += "<p class=\"desc\">" + item.ServiceContent + "</p>";
                    ltrServices.Text += "</div>";
                    ltrServices.Text += "</div>";
                    ltrServices.Text += "</div>";
                }
            }

            var ql = CustomerBenefitsController.GetAllByItemType(1);
            if (ql.Count > 0)
            {
                foreach (var q in ql)
                {
                    ltrCamKet.Text += "<div class=\"colum\">";
                    ltrCamKet.Text += "<a href =\"" + q.CustomerBenefitLink + "\">";
                    ltrCamKet.Text += "<div class=\"camket-title\">";
                    ltrCamKet.Text += "<span class=\"txt\">" + q.CustomerBenefitName + "</span>";
                    ltrCamKet.Text += "<span class=\"desc-camket\">" + q.CustomerBenefitDescription + "</span>";
                    ltrCamKet.Text += "</div>";
                    ltrCamKet.Text += "</a>";
                    ltrCamKet.Text += "</div>";
                }
            }

            var quest = QuestionController.GetAllNotHiden();
            if (quest.Count > 0)
            {
                foreach (var item in quest)
                {
                    ltrQuestions.Text += "<div class=\"tab wow fadeInUp\" data-wow-delay=\".2s\" data-wow-duration=\"1s\">";
                    ltrQuestions.Text += "<input type=\"radio\" id=\"rd" + item.ID + "\" name=\"rd\" class=\"input-radio\">";
                    ltrQuestions.Text += "<label class=\"tab-label\" for=\"rd" + item.ID + "\">" + item.ID + "." + item.QuesTitle + "</label>";
                    ltrQuestions.Text += "<div class=\"tab-contents\">" + item.QuesDesc + "</div>";
                    ltrQuestions.Text += "</div>";
                }
            }

            var news = NewsController.GetAllNotHidden();
            if (news.Count > 0)
            {
                foreach (var item in news)
                {
                    ltrNews.Text += "<div class=\"item\">";
                    ltrNews.Text += "<div class=\"box-img\"><a href=\"" + item.NewsLink + "\"><img src=\"" + item.NewsIMG + "\" alt=\"\"></a></div>";
                    ltrNews.Text += "<div class=\"content-news\">";
                    ltrNews.Text += "<div class=\"title-news\">";
                    ltrNews.Text += "<a href =\"" + item.NewsLink + "\">" + item.NewsTitle + "</a>";
                    ltrNews.Text += "</div>";
                    ltrNews.Text += "<div class=\"desc-news\">";
                    ltrNews.Text += "<p>" + item.NewsDesc + "</p>";
                    ltrNews.Text += "</div>";
                    ltrNews.Text += "</div>";
                    ltrNews.Text += "</div>";
                }
            }
        }

        #region tìm kiếm sản phẩm
        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA1.Create();
            byte[] bytes = Encoding.GetEncoding("gb2312").GetBytes(inputString);
            return bytes;
        }
        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append("%" + b.ToString("X2"));

            return sb.ToString();
        }

        public void SearchPage(string page, string text)
        {
            string linkgo = "";
            if (page == "tmall")
            {
                string a = text;
                string textsearch_tmall = GetHashString(a);
                //string fullLinkSearch_tmall = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
                linkgo = "https://list.tmall.com/search_product.htm?q=" + textsearch_tmall + "&type=p&vmarket=&spm=875.7931836%2FB.a2227oh.d100&from=mallfp..pc_1_searchbutton";
            }
            else if (page == "taobao")
            {
                string a = text;
                string textsearch_taobao = GetHashString(a);
                //string fullLinkSearch_taobao = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                linkgo = "https://world.taobao.com/search/search.htm?q=" + textsearch_taobao + "&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1";
                //https://world.taobao.com/search/search.htm?q=%B9%AB%BC%A6&navigator=all&_input_charset=&spm=a21bp.7806943.20151106.1
            }
            else if (page == "1688")
            {
                string a = text;
                string textsearch_1688 = GetHashString(a);
                //string fullLinkSearch_1688 = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
                linkgo = "https://s.1688.com/selloffer/offer_search.htm?keywords=" + textsearch_1688 + "&button_click=top&earseDirect=false&n=y";
            }
            Response.Redirect(linkgo);
            //Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", "redirect('" + linkgo + "')", true);
            //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "redirect('" + linkgo + "');", true);
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                string text = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(text))
                {
                    string a = PJUtils.TranslateTextNew(text, "vi", "zh");
                    a = a.Replace("[", "").Replace("]", "").Replace("\"", "");
                    string[] ass = a.Split(',');
                    string page = hdfWebsearch.Value;
                    SearchPage(page, PJUtils.RemoveHTMLTags(ass[0]));
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
        }
        #endregion

        #region Thông báo
        [WebMethod]
        public static string getPopup()
        {
            if (HttpContext.Current.Session["notshowpopup"] == null)
            {
                var conf = ConfigurationController.GetByTop1();
                string popup = conf.NotiPopupTitle;
                if (!string.IsNullOrEmpty(popup))
                {
                    NotiInfo n = new NotiInfo();
                    n.NotiTitle = conf.NotiPopupTitle;
                    n.NotiEmail = conf.NotiPopupEmail;
                    n.NotiContent = conf.NotiPopup;
                    JavaScriptSerializer serializer = new JavaScriptSerializer();
                    return serializer.Serialize(n);
                }
                else
                    return "null";
            }
            else
                return null;

        }
        [WebMethod]
        public static void setNotshow()
        {
            HttpContext.Current.Session["notshowpopup"] = "1";
        }
        public class NotiInfo
        {
            public string NotiTitle { get; set; }
            public string NotiContent { get; set; }
            public string NotiEmail { get; set; }
        }
        #endregion
    }
}