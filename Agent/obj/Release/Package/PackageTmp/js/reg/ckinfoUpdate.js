
///验证码
function UpdateImage() {
    document.getElementById("picVerifyCode").src = "ValidateImage.aspx?r=" + Math.random();
}

function hintMessage(hintObj, error, message) {
    //删除样式
    if (error == "error") {

        $("#" + hintObj + "").removeClass("");

        $("#" + hintObj + "").addClass("changeinput");

    } else if (error == "right") {

        $("#" + hintObj + "").removeClass("changeinput");

        $("#" + hintObj + "").addClass("");

    } else if (error == "info") {
        $("#" + hintObj + "").removeClass("onError");
        $("#" + hintObj + "").addClass("onFocus");
        $("#" + hintObj + "").removeClass("onCorrect");
    }
    $("#" + hintObj + "Tip").html(message);
}
///用户名校验 
function checkAccounts() {
    if ($.trim($("#TrueName").val()) == "") {
        hintMessage("TrueName", "error", "<br/>请输入您的真实姓名");
        return false;
    }

    hintMessage("TrueName", "right", "");
    return true;
}


function checkAccounts2() {
    if ($.trim($("#BankName").val()) == "") {
        hintMessage("BankName", "error", "<br/>请输入开户行名称");
        return false;
    }

    hintMessage("BankName", "right", "");
    return true;
}


function checkAccounts3() {
    if ($.trim($("#BankAddress").val()) == "") {
        hintMessage("BankAddress", "error", "<br/>请输入开户行地址");
        return false;
    }

    hintMessage("BankAddress", "right", "");
    return true;
}


function checkAccounts4() {
    if ($.trim($("#BankID").val()) == "") {
        hintMessage("BankID", "error", "<br/>请输入银行卡号");
        return false;
    }

    hintMessage("BankID", "right", "");
    return true;
}
///用户名重复校验 
var isExitsUserName = true;
function checkUserName() {
    $.ajax({
        async: false,
        contentType: "application/json",
        url: "Ws/WebService.asmx/CheckName",
        data: "{userName:'" + $("#txtAccounts").val() + "'}",
        type: "POST",
        dataType: "json",
        success: function (json) {
            json = eval("(" + json.d + ")");

            if (json.success == "error") {
                hintMessage("txtAccountsTip", "error", json.msg);
                isExitsUserName = true;
                return;
            } else if (json.success == "success") {
                hintMessage("txtAccountsTip", "right", ""); //"用户名可以注册"
                isExitsUserName = false;
                return;
            }
        },
        error: function (err, ex) {
            //alert(err.responseText);
        }
    });
}



///密码1
function checkLoginPass() {
    if ($("#NewPassWord2").val() == "") {
        hintMessage("NewPassWord2", "error", "<br/>请输入您的登录密码");
        return false;
    }
    if ($("#NewPassWord2").val().length < 6 || $("#NewPassWord2").val().length > 32) {
        hintMessage("NewPassWord2", "error", "<br/>密码长度为6到32个字符");
        return false;
    }
    hintMessage("NewPassWord2", "right", "");
    return true;
}
///密码2
function checkLoginConPass() {
    if ($("#NewPassWord3").val() == "") {
        hintMessage("NewPassWord3", "error", "<br/>请输入登录确认密码");
        return false;
    }
    if ($("#NewPassWord3").val() != $("#NewPassWord2").val()) {
        hintMessage("NewPassWord3", "error", "<br/>两次密码输入不一致");
        return false;
    }
    hintMessage("NewPassWord3", "right", "");
    return true;
}


///检查姓名
function checkCompellation() {
    if ($("#EndScore").val() == "") {
        hintMessage("EndScore", "error", "<br/>请输入结算金额");
        return false;
    }

    hintMessage("EndScore", "right", "");
    return true;
}
////验证码非空校验
function checkVerifyCode() {
    if ($("#txtCode").val() == "") {
        hintMessage("txtCodeTip", "error", "请输入验证码");
        return false;
    }

    hintMessage("txtCodeTip", "right", "");
    return true;

}

function checkQQ() {
    if ($("#txtQQ").val() == "") {
        hintMessage("txtQQ", "error", "<br/>请输入QQ");
        return false;
    }
    if ($.trim($("#txtQQ").val()) != "") {
        if ($("#txtQQ").val().length < 5 || $("#txtName").val().length > 11) {
            hintMessage("txtQQ", "error", "<br/>5到11位的QQ号");
            return false;
        }
    }
    hintMessage("txtQQ", "right", "");
    return true;
}


function checkPhone() {
    if ($.trim($("#txtPhone").val()) != "") {
        if ($("#txtPhone").val().length != 11) {
            hintMessage("txtPhone", "error", "<br/>11位手机号码");
            return false;
        }
    }
    hintMessage("txtPhone", "right", "");
    return true;
}

function checkEmail() {
    if ($("#txtEmail").val() == "") {
        hintMessage("txtEmail", "error", "<br/>请输入邮箱");
        return false;
    }
    if ($.trim($("#txtEmail").val()) != "") {
        var reg = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
        if (!reg.test($("#txtEmail").val())) {
            hintMessage("txtEmail", "error", "<br/>Email格式不正确！");
            return false;
        }
    }
    hintMessage("txtEmail", "right", "");
    return true;

}



///服务条款
function checkService() {
    if (!$("#chkAgree").attr("checked")) {
        hintMessage("chkAgreeTip", "error", "请选中已阅读并同意服务条款");
        return false;
    }
    hintMessage("chkAgreeTip", "right", "");
    return true;
}


function checkInput() {
    if (!checkAccounts()) {
        $("#TrueName").focus(); return false;
    }

    if (!checkAccounts()) {
        $("#BankName").focus(); return false;
    }

    if (!checkAccounts()) {
        $("#BankAddress").focus(); return false;
    }

    if (!checkAccounts()) {
        $("#BankID").focus(); return false;
    }

    if (!checkLoginPass()) { $("#NewPassWord2").focus(); return false; }
    if (!checkLoginConPass()) { $("#NewPassWord3").focus(); return false; }

    /*else 
    {
    if (isExitsUserName)
    {
    $("#txtAccounts").focus();
    hintMessage("txtAccountsTip", "error", "该用户名已经被注册");
    return false;
    }
    }
    */

    if (!checkLoginPass()) { $("#txtLogonPass").focus(); return false; }
    if (!checkLoginConPass()) { $("#txtLogonPass2").focus(); return false; }
    if (!checkCompellation()) { $("#EndScore").focus(); return false; }
    if (!checkEmail()) { $("#txtEmail").focus(); return false; }
    if (!checkPhone()) { $("#txtPhone").focus(); return false; }
    if (!checkQQ()) { $("#txtQQ").focus(); return false; }
    if (!checkVerifyCode()) { $("#txtCode").focus(); return false; }
    if (!checkService()) { return false; }
}

$(document).ready(function () {
    $("#TrueName").blur(function () {
        checkAccounts();
    });


    $("#BankName").blur(function () {
        checkAccounts2();
    });


    $("#BankAddress").blur(function () {
        checkAccounts3();
    });


    $("#BankID").blur(function () {
        checkAccounts4();
    });


    $("#EndScore").blur(function () { checkCompellation(); });

    $("#NewPassWord2").blur(function () { checkLoginPass(); });
    $("#NewPassWord3").blur(function () { checkLoginConPass(); });


    $("#txtQQ").blur(function () { checkQQ(); });
    $("#txtPhone").blur(function () { checkPhone(); });
    /*$("#txtEmail").blur(function () { checkEmail(); });*/


    /* $("#txtEmail").bind("propertychange input", function () {
         checkEmail();
     });*/
    /* $("#txtCode").blur(function () { checkVerifyCode(); });*/
    $("#btnRegister").click(function () {
        return checkInput();
    });

    //密码强度
    //strongRankBind($("#txtLogonPass"), $("#strongpass"));

    //$('#txtEmail').autoMail({
    //    emails: ['qq.com', '163.com', '126.com', 'sina.com', 'sohu.com', 'yahoo.cn', 'gmail.com', 'hotmail.com', 'live.cn']
    //});

});

$(function () {
    $("#txtPhone").keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '');
    })

    $("#txtQQ").keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '');
    })



});