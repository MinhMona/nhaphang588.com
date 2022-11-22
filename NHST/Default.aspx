<%@ Page Language="C#" MasterPageFile="~/NHAPHANG558MASTER.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NHST.Default" %>

<asp:Content runat="server" ContentPlaceHolderID="head">
</asp:Content>
<asp:Content runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <main class="main-wrap">
        <div class="banner-wrapper">
            <div class="swiper mySwiper">
                <div class="swiper-wrapper">
                    <div class="swiper-slide">
                        <div class="bg-1">
                            <img src="/App_Themes/CSS558/images/banner-slide-1.jpg" alt="">
                            <div class="content-bg">
                                <div class="container">
                                    <div class="both-banner">
                                        <div class="row">
                                            <div class="col-6">
                                                <div class="content-banner-phuong">
                                                    <div class="title-banner">
                                                        <h3>NHẬP SỈ TRUNG QUỐC CAO CẤP</h3>
                                                    </div>
                                                    <div class="desc-banner">
                                                        <marquee>Ưu đãi ngày hội Mua Sắm Giá Rẻ </marquee>
                                                    </div>
                                                    <div class="local-brand">
                                                        <div class="box-local">
                                                            <a target="_blank" href="https://world.taobao.com/">
                                                                <img src="/App_Themes/CSS558/images/taobao.png" alt="">
                                                            </a>
                                                        </div>
                                                        <div class="box-local">
                                                            <a target="_blank" href="https://www.1688.com/">
                                                                <img src="/App_Themes/CSS558/images/1688.png" alt="">
                                                            </a>
                                                        </div>
                                                        <div class="box-local">
                                                            <a target="_blank" href="https://www.tmall.com/">
                                                                <img src="/App_Themes/CSS558/images/tmall.png" alt="">
                                                            </a>
                                                        </div>
                                                    </div>
                                                    <%--  <div class="hotline-banner">
                                                        <a href="tel:+0815870000 " class="hotline-in">
                                                            <div class="icon">
                                                                <i class="fa fa-phone" aria-hidden="true"></i>
                                                            </div>
                                                            <div class="number">
                                                                <span>081.5870.000 </span>
                                                            </div>
                                                        </a>
                                                    </div>--%>
                                                </div>
                                            </div>
                                            <div class="col-6">
                                                <div class="find-prd-wrap tab-wrapper">
                                                    <div class="title">
                                                        <h3 class="hd tab-link current" data-tab="#search">Tìm kiếm sản phẩm</h3>
                                                    <%--    <span class="none-spsan">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</span>
                                                        <h3 class="hd tab-link" data-tab="#tracking">Tracking</h3>--%>
                                                    </div>
                                                    <div class="search-form-wrap">
                                                        <div id="search" class="search-form tab-content">
                                                            <div class="select-form">
                                                                <select class="fcontrol" id="brand-source">
                                                                    <option value="taobao" data-image="/App_Themes/CSS558/images/hdsearch-item-taobao.png">Taobao</option>
                                                                    <option value="tmall" data-image="/App_Themes/CSS558/images/hdsearch-item-tmall.png">Tmall</option>
                                                                    <option value="1688" data-image="/App_Themes/CSS558/images/hdsearch-item-1688.png">1688</option>
                                                                </select>
                                                                <span class="icon">
                                                                    <i class="fa fa-caret-down"></i>
                                                                </span>
                                                            </div>
                                                            <div class="input-form">
                                                                <asp:TextBox type="text" runat="server" ID="txtSearch" class="fcontrol f-input" placeholder="Nhập sản phẩm tìm kiếm"></asp:TextBox>
                                                            </div>
                                                            <a href="javascript:" onclick="searchProduct()" class="main-btn">Tìm kiếm</a>
                                                            <asp:Button ID="btnSearch" runat="server"
                                                                OnClick="btnSearch_Click" Style="display: none"
                                                                OnClientClick="document.forms[0].target = '_blank';" UseSubmitBehavior="false" />
                                                        </div>
                                                        <%-- <div id="tracking" class="search-form tab-content">
                                                            <div class="input-form">
                                                                <input type="text" class="fcontrol f-input" placeholder="Nhập link sản phẩm">
                                                            </div>
                                                            <a href="#" class="main-btn">Tracking</a>
                                                        </div>--%>
                                                    </div>
                                                </div>
                                                <%--    <div class="box-setting wow fadeInRight" data-wow-delay=".6s" data-wow-duration="1s">
                                                    <p class="text-setting">
                                                        Cài đặt công cụ đặt hàng:
                                                    </p>
                                                    <a href="#" class="app mr-15">
                                                        <img src="images/apple.png" alt=""></a>
                                                    <a href="#" class="app">
                                                        <img src="images/chplay.png" alt=""></a>
                                                </div>--%>
                                                <div class="box-setting wow fadeInRight" data-wow-delay=".6s" data-wow-duration="1s">
                                                    <p class="text-setting">
                                                        Cài đặt công cụ đặt hàng:
                                                    </p>
                                                    <a href="#" class="white-phuong mr-15">
                                                        <img style="width: 20px !important; height: 20px !important;" src="/App_Themes/CSS558/images/coccoc.png" alt="">Cốc Cốc</a>
                                                    <a href="#" class="white-phuong">
                                                        <img style="width: 20px !important; height: 20px !important;" src="/App_Themes/CSS558/images/chrome.png" alt="">Chrome</a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <%-- <div class="swiper-slide">
                        <div class="bg-1">
                            <img src="/App_Themes/CSS558/images/banner-slide-2.jpg" alt="">
                        </div>
                    </div>
                    <div class="swiper-slide">
                        <div class="bg-1">
                            <img src="/App_Themes/CSS558/images/banner-slide-3.jpg" alt="">
                        </div>
                    </div>--%>
                </div>
                <%--<div class="swiper-button-next"></div>
                <div class="swiper-button-prev"></div>--%>
            </div>

        </div>
        <div class="sec sec-commitment">
            <div class="container">
                <div class="table-commitment">
                    <div class="main-title">
                        <h3 class="title wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">Dịch vụ của nhập hàng NHẬP HÀNG 558
                        </h3>
                        <p class="desc wow fadeInRight" data-wow-delay=".4s" data-wow-duration="1s">
                            Nhập hàng thương mại là công ty NHẬP HÀNG 558 uy tín với nguồn hàng phong phú, mức giá cực rẻ, chắc chắn sẽ là giải pháp tối ưu cho bạn.
                        </p>
                    </div>
                    <div class="columns">
                        <asp:Literal runat="server" ID="ltrServices"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec sec-note-book">
            <div class="container">
                <div class="table-note-book">
                    <div class="main-title color-white">
                        <h3 class="title wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">Cam kết dịch vụ
                        </h3>
                        <p class="desc wow fadeInRight" data-wow-delay=".4s" data-wow-duration="1s">
                            <span>NHẬP HÀNG 558 </span>nhằm mang đến cho quý khách hàng dịch vụ nhập hàng tốt nhất, chúng tôi luôn nỗ lực cải tiền không ngừng nhằm nâng cao chất lượng phục vụ , đem đến sự hài lòng cho khách hàng sử dụng dịch vụ của chúng tôi !
                        </p>
                    </div>
                    <div class="columns">
                        <div class="columns">
                            <asp:Literal runat="server" ID="ltrCamKet"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec sec-why-about">
            <div class="container">
                <div class="table-why-about">
                    <div class="main-title">
                        <h3 class="title wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">Câu hỏi thường gặp
                        </h3>
                        <p class="desc wow fadeInRight" data-wow-delay=".4s" data-wow-duration="1s">
                            Danh mục giải đáp các vấn đề thường xuyên xảy ra đối với khách hàng trong quá trình NHẬP HÀNG 558, order hàng quảng châu. Nếu khách hàng thắc mắc hay gặp những vấn đề khi nhập hàng hãy gửi email hoặc liên hệ ngay với Nhập Hàng 558. Chúng tôi sẽ giải đáp toàn bộ vấn đề mà quý khách gặp phải.
                        </p>
                    </div>
                    <div class="columns">
                        <div class="colum">
                            <div class="tabs">
                                <asp:Literal runat="server" ID="ltrQuestions"></asp:Literal>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="box-img wow fadeInUp" data-wow-delay=".6s" data-wow-duration="1s">
                                <img src="/App_Themes/CSS558/images/11065.jpg" alt="">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec sec-row-buy">
            <div class="container">
                <div class="table-row-buy">
                    <div class="main-title">
                        <h3 class="title wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">Quy trình đặt hàng
                        </h3>
                    </div>
                    <div class="columns wow zoomIn" data-wow-delay=".2s" data-wow-duration="1s">
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v1-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">1. Tư vấn tìm
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v2-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">2. đám phán, báo giá
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v3-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">3. Đặt cọc hàng hóa
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v4-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">4. vận chuyển
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v5-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">5. thanh toán
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content loading">
                                <div class="box-icon">
                                    <img src="/App_Themes/CSS558/images/icon-v6-re.png" alt="">
                                </div>
                                <div class="box-text">
                                    <a href="#">
                                        <h4 class="txt">6. nhận hàng
                                        </h4>
                                    </a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec sec-it-works">
            <div class="container">
                <div class="table-it-works">
                    <div class="main-title">
                        <h3 class="title wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">Tin mới nhất
                        </h3>
                        <p class="desc wow fadeInRight" data-wow-delay=".2s" data-wow-duration="1s">
                            <span>Nhập hàng NHẬP HÀNG 558</span>  luôn cập nhật các tin tức mới nhất để cung cấp thông tin cho khách hàng
                        </p>
                    </div>
                    <div class="slide-works wow zoomIn" data-wow-delay=".2s" data-wow-duration="1s" id="js-slide-works">
                        <asp:Literal runat="server" ID="ltrNews"></asp:Literal>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec sec-number">
            <div class="container">
                <div class="table-number">
                    <div class="columns">
                        <div class="colum">
                            <div class="content-number wow fadeInUp">
                                <asp:Literal runat="server" ID="ltrEmail"></asp:Literal>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="content-number wow fadeInUp">
                                <div class="icon">
                                    <i class="fa fa-clock-o" aria-hidden="true"></i>
                                </div>
                                <asp:Literal runat="server" ID="ltrTimeWork"></asp:Literal>
                            </div>
                        </div>
                        <div class="colum">
                            <asp:Literal runat="server" ID="ltrHotline"></asp:Literal>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="sec-map">
            <div class="map">
                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d658.4862396249937!2d105.81320874075892!3d20.994213103132942!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x3135ac9177f26c01%3A0xda329eda81b9f997!2zNyBOZy4gMTYyIMSQLiBLaMawxqFuZyDEkMOsbmgsIEjhuqEgxJDDrG5oLCBUaGFuaCBYdcOibiwgSMOgIE7hu5lpLCBWaeG7h3QgTmFt!5e0!3m2!1svi!2s!4v1668483231461!5m2!1svi!2s" width="100%" height="560" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
            </div>
            <div class="table-map-contact">
                <div class="container">
                    <div class="columns">
                        <div class="colum">
                            <div class="contact-li">
                                <div class="icon">
                                    <img src="/App_Themes/CSS558/images/a1.png" alt="">
                                </div>
                                <div class="text">
                                    <div class="txt-big counter">
                                        111,265
                                    </div>
                                    <div class="txt-small">
                                        <p>Đơn hàng thành công </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="contact-li">
                                <div class="icon">
                                    <img src="/App_Themes/CSS558/images/a2.png" alt="">
                                </div>
                                <div class="text">
                                    <div class="txt-big counter">
                                        18,755
                                    </div>
                                    <div class="txt-small">
                                        Khách hàng thân thiết
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="colum">
                            <div class="contact-li">
                                <div class="icon">
                                    <img src="/App_Themes/CSS558/images/a3.png" alt="">
                                </div>
                                <div class="text">
                                    <div class="txt-big counter">
                                        982
                                    </div>
                                    <div class="txt-small">
                                        <p>Phản hồi từ khách hàng </p>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </main>
    <asp:HiddenField ID="hdfWebsearch" runat="server" />
    <script type="text/javascript">

        $(document).ready(function () {
            $('.txtSearch').on("keypress", function (e) {
                if (e.keyCode == 13) {
                    searchProduct();
                }
            });
        });

        function searchProduct() {
            var web = $("#brand-source").val();
            $("#<%=hdfWebsearch.ClientID%>").val(web);
            $("#<%=btnSearch.ClientID%>").click();
        }

        function close_popup_ms() {
            $("#pupip_home").animate({ "opacity": 0 }, 400);
            $("#bg_popup_home").animate({ "opacity": 0 }, 400);
            setTimeout(function () {
                $("#pupip_home").remove();
                $(".zoomContainer").remove();
                $("#bg_popup_home").remove();
                $('body').css('overflow', 'auto').attr('onkeydown', '');
            }, 500);
        }
        function closeandnotshow() {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/setNotshow",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    close_popup_ms();
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        }
        $(document).ready(function () {
            $.ajax({
                type: "POST",
                url: "/Default.aspx/getPopup",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d != "null") {
                        var data = JSON.parse(msg.d);
                        var title = data.NotiTitle;
                        var content = data.NotiContent;
                        var email = data.NotiEmail;
                        var obj = $('form');
                        $(obj).css('overflow', 'hidden');
                        $(obj).attr('onkeydown', 'keyclose_ms(event)');
                        var bg = "<div id='bg_popup_home'></div>";
                        var fr = "<div id='pupip_home' class=\"columns-container1\">" +
                            "  <div class=\"center_column col-xs-12 col-sm-5\" id=\"popup_content_home\">";
                        fr += "<div class=\"popup_header\">";
                        fr += title;
                        fr += "<a style='cursor:pointer;right:5px;' onclick='close_popup_ms()' class='close_message'></a>";
                        fr += "</div>";
                        fr += "     <div class=\"changeavatar\">";
                        fr += "         <div class=\"content1\">";
                        fr += content;
                        fr += "         </div>";
                        fr += "         <div class=\"content2\">";
                        fr += "<a href=\"javascript:;\" class=\"btn-new btn-close-full\" onclick='closeandnotshow()'>Đóng & không hiện thông báo</a>";
                        fr += "<a href=\"javascript:;\" class=\"btn-new btn-close\" onclick='close_popup_ms()'>Đóng</a>";
                        fr += "         </div>";
                        fr += "     </div>";
                        fr += "<div class=\"popup_footer\">";
                        fr += "<span class=\"float-right\">" + email + "</span>";
                        fr += "</div>";
                        fr += "   </div>";
                        fr += "</div>";
                        $(bg).appendTo($(obj)).show().animate({ "opacity": 0.7 }, 800);
                        $(fr).appendTo($(obj));
                        setTimeout(function () {
                            $('#pupip').show().animate({ "opacity": 1, "top": 20 + "%" }, 200);
                            $("#bg_popup").attr("onclick", "close_popup_ms()");
                        }, 1000);
                    }
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert('lỗi');
                }
            });
        });
    </script>
    <style>
        #bg_popup_home {
            position: fixed;
            width: 100%;
            height: 100%;
            background-color: #333;
            opacity: 0.7;
            filter: alpha(opacity=70);
            left: 0px;
            top: 0px;
            z-index: 999999999;
            opacity: 0;
            filter: alpha(opacity=0);
        }

        #popup_content_home {
            height: auto;
            position: fixed;
            background-color: #fff;
            top: 15.5%;
            z-index: 999999999;
            left: 25%;
            border-radius: 10px;
            -moz-border-radius: 10px;
            -webkit-border-radius: 10px;
            width: 50%;
            padding: 20px;
        }

        #popup_content_home {
            padding: 0;
        }

        .popup_header, .popup_footer {
            float: left;
            width: 100%;
            background: #f36703;
            padding: 10px;
            position: relative;
            color: #fff;
        }

        .popup_header {
            font-weight: bold;
            font-size: 16px;
            text-transform: uppercase;
        }

        .close_message {
            top: 10px;
        }

        .changeavatar {
            padding: 10px;
            margin: 5px 0;
            float: left;
            width: 100%;
        }

        .float-right {
            float: right;
        }

        .content1 {
            float: left;
            width: 100%;
        }

        .content2 {
            float: left;
            width: 100%;
            border-top: 1px solid #eee;
            clear: both;
            margin-top: 10px;
        }

        .btn-new.btn-close {
            float: right;
            background: #343a40;
            color: #fff;
            margin: 10px 5px;
            text-transform: none;
            padding: 10px 20px;
        }

        .btn-new.btn-close-full {
            float: right;
            background: #385fb9;
            color: #fff;
            margin: 10px 5px;
            text-transform: none;
            padding: 10px 20px;
        }


        @media screen and (max-width: 768px) {
            #popup_content_home {
                left: 10%;
                width: 80%;
            }

            .content1 {
                overflow: auto;
                height: 300px;
            }
        }

        @media screen and (min-device-width: 1200px) and (max-device-width: 1400px) {
            .main-banner .content-banner .title {
                font-size: 50px;
                padding-bottom: 10px;
            }

            .main-banner .content-banner .setting-cc .text-setting {
                margin-top: 15px;
            }

            .find-product-section {
                padding: 15px;
            }

            .btn.btn-fex {
                margin-top: 15px;
                height: 40px;
                line-height: 25px;
            }
        }
    </style>
</asp:Content>
