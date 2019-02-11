function DoAjaxCall(page, parameter, datatype, data, callback, callbackdetails) {
    jQuery.ajax({
        type: 'POST',
        url: page + parameter,
        data: data,
        //timeout: 30000,
        dataType: datatype,
        success: function (data, textStatus) {
            if (data.e == "1") {

                top.location.href = "login.html";
                return false;
            }
            try {
                var jsonData = eval(data).jsonData;

                var s = "function(){" + callback + '(' + IsTure(jsonData.IsSucess) + ',jsonData.ResponseData, jsonData.Message,callbackdetails)' + ";}";

                var ff = eval("1," + s);
                ff();



            }
            catch (err) {
       
                var IsSucess = false;
                var ResponseData = "";
                var Message = "解析错误，请检查数据库！";
                //var Message = "";
                var s = "function(){" + callback + '(IsSucess,ResponseData, Message,callbackdetails)' + ";}";
                var ff = eval("1," + s);
                //top.loading1.hide();
                ff();


            }
        },
        error: function (jqXHR, textStatus, errorThrown) {
            //top.location.href = "login.html";
            return false;

            //var xmlhttp;
            //xmlhttp = new XMLHttpRequest();
            //if (xmlhttp == 'undefind' || xmlhttp == null) {

            //    return;
            //}

            //alert("Error:" + errorThrown + " and " + jqXHR + " and " + textStatus);
            //var IsSucess = false;
            //var ResponseData = "";
            //var Message = "网络超时，请重新登录！";
            //var s = "function(){" + callback + '(IsSucess,ResponseData, Message,callbackdetails)' + ";}";
            //var ff = eval("1," + s);
            ////top.loading1.hide();
            //ff();
        }
    });
}

$(document).ready(function () {
    //FillListing();
});

var ProductID = 0;




function SaveProducts() {

    var Param = "name=" + document.getElementById("txtName").value + "&unit=" + document.getElementById("txtUnit").value + "&Qty=" + document.getElementById("txtQty").value;
    if (ProductID == 0)
        DoAjaxCall("?method=Insert&callbackmethod=InsertProductSucess&" + Param, "json", "");
    else
        DoAjaxCall("?method=Update&callbackmethod=UpdateProductSucess&" + Param + "&ProductID=" + ProductID, "json", "");
}
function InsertProductSucess(data, message) {
    FillListing();
    alert(message);
    ClearValue();
}


function ClearValue() {
    $("#txtName").val("");
    $("#txtUnit").val("");
    $("#txtQty").val("");
}

function UpdateProductSucess(data, message) {
    FillListing();
    alert(message);
    ProductID = 0;
    ClearValue();
}

function FillListing() {
    DoAjaxCall("?method=getproducts&callbackmethod=FillListingSucess", 'json', "");
}

function FillListingSucess(data, message) {
    var str = " <table border='1' cellpadding='2' cellspacing='0' width='500px'><tr><td colspan='5' style='background-color: Gray' align='center'><b>Product Listing Page</b></td></tr><tr> <td>Product Name</td><td>Unit</td><td>Qty</td><td>Delete</td><td>Edit</td></tr>";

    for (var i = 0; i < data.length; i++) {
        str += "<tr><td>" + data[i].Name + "</td>";
        str += "<td>" + data[i].Unit + "</td>";
        str += "<td>" + data[i].Qty + "</td>";
        str += "<td><a href='javascript:void(0)' onclick='DeleteProduct(" + data[i].ProductID + ")'>Delete</a></td>";
        str += "<td><a href='javascript:void(0)' onclick='EditProduct(" + data[i].ProductID + ")'>Edit</a></td></tr>";
    }
    str += "</table>";
    $('#ListingData').html(str);
}


function DeleteProduct(ProductID) {
    DoAjaxCall("?method=delete&callbackmethod=DeleteSucess&param=" + ProductID, "json", "");

}



function EditProduct(ProductID) {
    DoAjaxCall("?method=getbyid&callbackmethod=EditSucess&param=" + ProductID, "json", "");
}

function EditSucess(data, message) {
    ProductID = data.ProductID;
    $("#txtName").val(data.Name);
    $("#txtUnit").val(data.Unit);
    $("#txtQty").val(data.Qty);
}
function IsTure(Temp) {
    if (Temp == "True") {
        return true;
    }
    else {
        false;
    }
}