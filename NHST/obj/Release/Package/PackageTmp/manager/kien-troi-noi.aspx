<%@ Page Title="Danh sách kiện trôi nổi" Language="C#" MasterPageFile="~/manager/adminMasterNew.Master" AutoEventWireup="true" CodeBehind="kien-troi-noi.aspx.cs" Inherits="NHST.manager.kien_troi_noi" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Import Namespace="NHST.Controllers" %>
<%@ Import Namespace="NHST.Models" %>
<%@ Import Namespace="NHST.Bussiness" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="main" class="main-full">
        <div class="row">
            <div class="content-wrapper-before bg-dark-gradient"></div>
            <div class="page-title">
                <div class="card-panel">
                    <h4 class="title no-margin" style="display: inline-block;">Danh sách kiện trôi nổi</h4>
                </div>
            </div>
            <div class="list-staff col s12 section">
                <div class="list-table card-panel">
                    <div class="filter">
                        <div class="search-name input-field no-margin">
                            <asp:TextBox runat="server" placeholder="Nhập mã vận đơn" ID="search_name" onkeypress="myFunction()" type="text" class="validate autocomplete barcode"></asp:TextBox>
                            <div class="bg-barcode"></div>
                            <span class="material-icons search-action">search</span>
                        </div>
                    </div>
                    <div class="list-lost mt-2">
                        <div class="responsive-tb package-item">
                            <table class="table bordered highlight">
                                <thead>
                                    <tr class="teal darken-4">
                                        <th>ID</th>
                                        <th>Bao hàng</th>
                                        <th>Mã vận đơn</th>
                                        <th>Loại hàng</th>
                                        <th>Ghi chú nhân viên</th>
                                        <th>Cân (kg)</th>
                                        <%-- <th>Khối (m<sup>3</sup>)</th>--%>
                                        <th>Trạng thái</th>
                                        <th>Username nhận</th>
                                        <th>Trạng thái xác nhận</th>
                                        <th>Ngày tạo</th>
                                        <th class="tb-date">Action</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <asp:Literal runat="server" ID="ltr"></asp:Literal>
                                </tbody>
                            </table>
                        </div>
                        <div class="pagi-table float-right mt-2">
                            <%this.DisplayHtmlStringPaging1();%>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="bg-overlay"></div>
            <!-- Edit mode -->
            <div class="detail-fixed  col s12 m12 l6 xl6 section">
                <div class="rp-detail card-panel row">
                    <div class="col s12">
                        <div class="page-title">
                            <h5>Mã vận đơn #<asp:Label runat="server" ID="lbMVD"></asp:Label></h5>
                            <a href="#!" class="close-editmode top-right valign-wrapper"><i class="material-icons">close</i>Close</a>
                        </div>

                    </div>
                    <div class="col s12">
                        <div class="row">
                            <div class="input-field col s12 m12">
                                <asp:TextBox runat="server" ID="txtEditOrderTransaction" type="text" placeholder="" class="validate"></asp:TextBox>
                                <label class="active" for="mvc_detail-mvc">Mã vận đơn</label>
                            </div>
                            <div class="input-field col s12 m6">
                                <asp:DropDownList runat="server" ID="ddlPrefix">
                                </asp:DropDownList>
                                <label for="mvc_detail-bh">Bao hàng</label>
                            </div>
                            <div class="input-field col s12 m6">
                                <asp:TextBox runat="server" ID="txtEditProductType" type="text" class="validate" placeholder=""></asp:TextBox>
                                <label class="active" for="mvc_detail-lh">Loại hàng</label>
                            </div>
                            <div class="input-field col s12 m4">
                                <asp:TextBox runat="server" ID="txtEditFeeShip" TextMode="Number" class="validate" placeholder=""></asp:TextBox>
                                <label class="active" for="mvc_detail-ps">Phí ship (tệ)</label>
                            </div>
                            <div class="input-field col s12 m4">
                                <asp:TextBox runat="server" ID="txtEditWeight" TextMode="Number" class="validate" placeholder=""></asp:TextBox>
                                <label class="active" for="mvc_detail-tl">Trọng lượng (kg)</label>
                            </div>
                            <div class="input-field col s12 m4">
                                <asp:TextBox runat="server" ID="txtEditVolume" TextMode="Number" class="validate" placeholder=""></asp:TextBox>
                                <label class="active" for="mvc_detail-khoi">Khối (m<sup>3</sup>)</label>
                            </div>
                            <div class="col s12 m12">
                                <span class="black-text">Hình ảnh</span>
                                <div style="display: inline-block; margin-left: 15px;">
                                    <asp:FileUpload runat="server" ID="EditIMG" class="upload-img" type="file" AllowMultiple="true" onchange="readFile(this)" title=""></asp:FileUpload>
                                    <a class="btn-upload">Upload</a>
                                </div>
                                <div class="preview-img">
                                </div>
                            </div>
                            <div class="input-field col s12 m12">
                                <asp:TextBox runat="server" ID="txtEditNote" placeholder="" type="text" class="validate"></asp:TextBox>
                                <label class="active" for="mvc_detail-note">Ghi chú</label>
                            </div>
                            <div class="input-field col s12 m12">
                                <asp:DropDownList runat="server" ID="ddlStatus">
                                    <asp:ListItem Value="0">Đã hủy</asp:ListItem>
                                    <asp:ListItem Value="1">Chưa về kho TQ</asp:ListItem>
                                    <asp:ListItem Value="2">Đã về kho TQ</asp:ListItem>
                                    <asp:ListItem Value="3">Đã về kho VN</asp:ListItem>
                                    <asp:ListItem Value="4">Đã giao cho khách</asp:ListItem>
                                </asp:DropDownList>
                                <label for="mvc_detail-status">Trạng thái</label>
                            </div>
                            <div class="input-field col s12 m12">
                                <div class="action-wrap">
                                    <a class="btn" id="btnUpdate">Cập nhật</a>
                                    <button class="btn close-editmode">Trở về</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- END : Edit mode -->
        </div>
    </div>
    <div id="modalConfirm" class="modal modal-fixed-footer">
        <div class="modal-hd">
            <span class="right"><i class="material-icons modal-close right-align">clear</i></span>
            <h4 class="no-margin center-align">Xác nhận kiện trôi nổi</h4>
            <div class="page-title">
                <h5>Mã hệ thống #<asp:Label runat="server" ID="lbID"></asp:Label></h5>
            </div>
        </div>
        <div class="modal-bd">
            <div class="row">
                <div class="input-field col s12 m6">
                    <asp:TextBox runat="server" placeholder="" ID="pBarcode" type="text" Enabled="false" class="validate" data-type="text-only"></asp:TextBox>
                    <label class="active" for="edit__step-name">Mã vận đơn</label>
                </div>
                <div class="input-field col s12 m6">
                    <asp:TextBox runat="server" placeholder="" ID="txtMainOrderCode" type="text" class="validate" data-type="text-only"></asp:TextBox>
                    <label class="active" for="edit__step-name">Mã đơn hàng</label>
                </div>
                <div class="input-field col s12 m6">
                    <asp:TextBox runat="server" placeholder="" ID="txtUID" type="number" min="0" class="validate" data-type="text-only"></asp:TextBox>
                    <label class="active" for="edit__step-number">Mã khách hàng</label>
                </div>



            </div>
        </div>
        <div class="modal-ft">
            <div class="ft-wrap center-align">
                <a id="btnUpBenefit" onclick="btnConfirm_Click($(this))" class="modal-action btn modal-close waves-effect waves-green mr-2">Cập nhật</a>
                <a href="#!" class="modal-action btn orange darken-2 modal-close waves-effect waves-green ml-2">Hủy</a>
            </div>
        </div>
    </div>


    <div id="addTroiNoiKyGui" class="modal modal-small add-package" style="height: 45vh">
        <div class="modal-hd">
            <span class="right"><i class="material-icons modal-close right-align">clear</i></span>
            <h4 class="no-margin center-align">Gán kiện trôi nổi ký gửi</h4>
        </div>
        <div class="modal-bd">
            <div class="row">
                <div class="input-field col s12">
                    <input id="BarcodeTransport" disabled type="text" placeholder="" class="validate" data-type="text-only">
                    <label for="add_package_code">Mã kiện</label>
                </div>

                <div class="search-name input-field no-margin col s12 m6">
                    <asp:DropDownList ID="ddlUsername1" runat="server" CssClass="select2-username2"
                        DataValueField="ID" DataTextField="Username">
                    </asp:DropDownList>
                    <%-- <label for="add_package_code">Username</label>--%>
                </div>

                <div class="input-field col s12 m6">
                    <asp:DropDownList runat="server" ID="ddlKhoTQ" AppendDataBoundItems="true" DataTextField="WareHouseName" DataValueField="ID">
                    </asp:DropDownList>
                    <label for="add_package_code">Kho TQ</label>
                </div>

                <div class="input-field col s12 m6">
                    <asp:DropDownList runat="server" ID="ddlKhoVN" AppendDataBoundItems="true" DataTextField="WareHouseName" DataValueField="ID"></asp:DropDownList>
                    <label for="add_package_code">Kho VN</label>
                </div>

                <div class="input-field col s12 m6">
                    <asp:DropDownList runat="server" ID="ddlPTVC" AppendDataBoundItems="true" DataTextField="ShippingTypeName" DataValueField="ID"></asp:DropDownList>
                    <label for="add_package_code">Phương thức VC</label>
                </div>

            </div>
        </div>
        <div class="modal-ft">
            <div class="ft-wrap center-align">
                <a href="javascript:;" onclick="AddTransport()" id="btn-update1" class="modal-action btn modal-close waves-effect waves-green mr-2 submit-button">Thêm</a>
                <a href="javascript:;" class="modal-action btn orange darken-2 modal-close waves-effect waves-green ml-2">Hủy</a>
            </div>

        </div>
    </div>

    <div id="addTroiNoiMuaHo" class="modal modal-small add-package" style="height: 45vh">
        <div class="modal-hd">
            <span class="right"><i class="material-icons modal-close right-align">clear</i></span>
            <h4 class="no-margin center-align">Gán kiện trôi nổi mua hộ</h4>
        </div>
        <div class="modal-bd">
            <div class="row">
                <div class="input-field col s12">
                    <input id="BarcodeOrder" disabled type="text" placeholder="" class="validate" data-type="text-only">
                    <label for="add_package_code">Mã kiện</label>
                </div>

                <div class="search-name input-field no-margin col s12 m6">
                    <asp:DropDownList ID="ddlUsername" runat="server" CssClass="select-username"
                        DataValueField="ID" DataTextField="Username">
                    </asp:DropDownList>
                    <%--<label for="add_package_code">Username</label>--%>
                </div>

                <div class="input-field col s12 m6">
                    <input id="MainOrderID" type="text" class="validate" placeholder="" data-type="text-only">
                    <label for="add_package_code">ID đơn</label>
                </div>
            </div>
        </div>
        <div class="modal-ft">
            <div class="ft-wrap center-align">
                <a href="javascript:;" onclick="AddOrder()" id="btn-update2" class="modal-action btn modal-close waves-effect waves-green mr-2 submit-button">Thêm</a>
                <a href="javascript:;" class="modal-action btn orange darken-2 modal-close waves-effect waves-green ml-2">Hủy</a>
            </div>

        </div>
    </div>

    <asp:HiddenField runat="server" ID="hdfListIMG" />
    <asp:Button runat="server" ID="btnSearch" OnClick="btnSearch_Click" UseSubmitBehavior="false" Style="display: none" />
    <asp:Button runat="server" ID="buttonUpdate" OnClick="btncreateuser_Click" UseSubmitBehavior="false" Style="display: none" />
    <asp:Button ID="buttonUpBenefit" runat="server" OnClick="btnConfirm_Click" Style="display: none" />
    <asp:HiddenField ID="hdfID" runat="server" Value="0" />
    <!-- END: Page Main-->
    <script>
        function myFunction() {
            if (event.which == 13 || event.keyCode == 13) {
                $('#<%=btnSearch.ClientID%>').click();
            }
        }
        function btnConfirm_Click(obj) {
            $('#<%=buttonUpBenefit.ClientID%>').click();
        }
        $('.search-action').click(function () {
            console.log($('#<%=search_name.ClientID%>').val());
            $('#<%=btnSearch.ClientID%>').click();
        })
        $('#btnUpdate').click(function () {
            var base64 = "";
            $(".preview-img .img-block img").each(function () {
                base64 += $(this).attr('src') + "|";
            })
            $("#<%=hdfListIMG.ClientID%>").val(base64);
            console.log(base64);
            $('#<%=buttonUpdate.ClientID%>').click();
        });
        function EditFunction(ID) {
            console.log("Ajax");
            $('.preview-img').empty();
            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/loadinfo",
                data: '{ID: "' + ID + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var data = JSON.parse(msg.d);
                    if (data != null) {
                        $('#<%=lbMVD.ClientID%>').text(ID);
                        $('#<%=txtEditOrderTransaction.ClientID%>').val(data.OrderTransactionCode);
                        $('#<%=txtEditFeeShip.ClientID%>').val(data.FeeShip);
                        $('#<%=txtEditProductType.ClientID%>').val(data.ProductType);
                        $('#<%=ddlPrefix.ClientID%>').val(data.BigPackageID);
                        $('#<%=txtEditFeeShip.ClientID%>').val(data.FeeShip);
                        $('#<%=txtEditWeight.ClientID%>').val(data.Weight);
                        $('#<%=txtEditVolume.ClientID%>').val(data.Volume);
                        $('#<%=txtEditNote.ClientID%>').val(data.Description);
                        $('#<%=ddlStatus.ClientID%>').val(data.Status);
                        $('#<%=hdfID.ClientID%>').val(data.ID);
                        var list = data.ListIMG;
                        if (list != null) {
                            var IMG = list.split('|');
                            var html = "";
                            for (var i = 0; i < IMG.length - 1; i++) {
                                if (IMG[i] != "") {
                                    html += "<div class=\"img-block\"><img class=\"materialboxed\" src =\"" + IMG[i] + "\" ><span class=\"material-icons red-text delete\" onclick=\"Delete($(this))\">clear</span></div>";
                                }
                            }
                            $(".preview-img").append(html);
                        }
                        $(".materialboxed").materialbox({
                            inDuration: 150,
                            onOpenStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', 'overflow:visible !important;');
                            },
                            onCloseStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', '');
                            }
                        });
                        $('select').formSelect();
                    }
                    else
                        swal("Error", "Không thành công", "error");
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    swal("Error", "Fail updateInfoAcc", "error");
                }
            });
        }
        function ConfirmFunction(ID) {
            console.log("Ajax");
            $('.preview-img').empty();
            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/LoadInforVer2",
                data: '{ID: "' + ID + '"}',
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var data = JSON.parse(msg.d);
                    if (data != null) {
                        $('#<%=lbID.ClientID%>').text(ID);
                        $('#<%=pBarcode.ClientID%>').val(data.OrderTransactionCode);
                        $('#<%=hdfID.ClientID%>').val(data.ID);
                        var list = data.ListIMG;
                        if (list != null) {
                            var IMG = list.split('|');
                            var html = "";
                            for (var i = 0; i < IMG.length - 1; i++) {
                                if (IMG[i] != "") {
                                    html += "<div class=\"img-block\"><img class=\"materialboxed\" src =\"" + IMG[i] + "\" ><span class=\"material-icons red-text delete\" onclick=\"Delete($(this))\">clear</span></div>";
                                }
                            }
                            $(".preview-img").append(html);
                        }
                        $(".materialboxed").materialbox({
                            inDuration: 150,
                            onOpenStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', 'overflow:visible !important;');
                            },
                            onCloseStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', '');
                            }
                        });
                        $('select').formSelect();
                    }
                    else
                        swal("Error", "Không thành công", "error");
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    swal("Error", "Fail updateInfoAcc", "error");
                }
            });
        }
        $(document).ready(function () {
            $('.table-warehouse').on('click', '.select-trigger', function () {
                var content = $(this).parent().find('.dropdown-content');
                var dropDownTop = $(this).offset().top + $(this).outerHeight();
                content.css('top', dropDownTop + 'px');
                content.css('left', $(this).offset().left + 'px');
            });

            $('.bg-barcode').on('click', function () {
                alert('BarCode Open !');
            });

        });
        function Delete(obj) {
            //$("li." + obj + "").remove();
            obj.parent().remove();
        }
        function readFile(input) {
            var k = 0;
            var counter = input.files.length;
            for (x = 0; x < counter; x++) {
                if (input.files && input.files[x]) {
                    var reader = new FileReader();
                    var t = k + x;
                    reader.onload = function (e) {
                        var a = "<div class=\"img-block\"><img class=\"materialboxed 2" + t + "\" src =\"" + e.target.result + "\" ><span class=\"material-icons red-text delete\" onclick=\"Delete($(this))\">clear</span></div>";
                        $(".preview-img").append(a);
                        $(".materialboxed").materialbox({
                            inDuration: 150,
                            onOpenStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', 'overflow:visible !important;');
                            },
                            onCloseStart: function (element) {
                                $(element).parents('.material-placeholder').attr('style', '');
                            }
                        });
                        //$(".preview-img").append('<li class=\"2' + t + '\"><img src="' + e.target.result + '" class="img-thumbnail"><a href=\"javascript:;\" onclick=\"Delete($(this))\">Xóa</a></li>');
                    };
                    reader.readAsDataURL(input.files[x]);
                    k++;
                }
            }
        }

        function GetbyTrancode(packageID) {
            debugger;
            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/GetpackageID",
                data: "{packageID:" + packageID + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d != null) {
                        var data = JSON.parse(msg.d);
                        $("#BarcodeTransport").val(data.OrderTransactionCode);
                        $("#btn-update1").attr('data-id', data.ID);
                        $("#addTroiNoiKyGui").modal('open');
                    }

                }
            })
        }

        function GetbyTrancodeOrder(packageID) {
            debugger;
            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/GetpackageID",
                data: "{packageID:" + packageID + "}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    if (msg.d != null) {
                        var data = JSON.parse(msg.d);
                        $("#BarcodeOrder").val(data.OrderTransactionCode);
                        $("#btn-update2").attr('data-id', data.ID);
                        $("#addTroiNoiMuaHo").modal('open');
                    }

                }
            })
        }

        function AddTransport() {

            var username = $("#<%=ddlUsername1.ClientID%>").val();
            var ordercode = $("#BarcodeTransport").val();
            var khotq = $("#<%=ddlKhoTQ.ClientID%>").val();
            var khovn = $("#<%=ddlKhoVN.ClientID%>").val();
            var ptvc = $("#<%=ddlPTVC.ClientID%>").val();

            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/UpdateKyGui",
                data: "{ordertransaction:'" + ordercode + "',Username:'" + username + "',KhoTQ:'" + khotq + "',KhoVN:'" + khovn + "',PTVC:'" + ptvc + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var ret = msg.d;
                    if (ret != "none") {
                        if (ret == "1") {
                            alert('Kiện này đã xác định');
                        }
                        else if (ret == "2") {
                            alert('Username khách không tồn tại');
                        }
                        else {
                            alert('Gán kiện ký gửi thành công. Vui lòng check lại đơn hàng');
                        }
                    }
                    removeLoading();
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert(errorthrow);
                    removeLoading();
                }
            });
        }


        function AddOrder() {

            var username = $("#<%=ddlUsername.ClientID%>").val();
            var mainorderID = $("#MainOrderID").val();
            var ordercode = $("#BarcodeOrder").val();

            $.ajax({
                type: "POST",
                url: "/manager/kien-troi-noi.aspx/UpdateMuaHo",
                data: "{ordertransaction:'" + ordercode + "',Username:'" + username + "',MainOrderID:'" + mainorderID + "'}",
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (msg) {
                    var ret = msg.d;
                    if (ret != "none") {
                        if (ret == "1") {
                            alert('Mã đơn không tồn tại theo khách hàng vừa chọn');
                        }
                        else if (ret == "2") {
                            alert('Username khách không tồn tại');
                        }
                        else {
                            alert('Gán kiện mua hộ thành công. Vui lòng check lại đơn hàng');
                        }
                    }
                    removeLoading();
                },
                error: function (xmlhttprequest, textstatus, errorthrow) {
                    alert(errorthrow);
                    removeLoading();
                }
            });
        }
    </script>
</asp:Content>
