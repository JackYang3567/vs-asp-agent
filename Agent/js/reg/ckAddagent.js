
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
///账号校验 
function checkAccounts() {
    if ($.trim($("#txtAccounts").val()) == "") {
        hintMessage("txtAccounts", "error", "<br/>请输入代理账号");
        return false;
    }
    var reg = /^[a-zA-Z0-9_\u4e00-]+$/;
    if (!reg.test($("#txtAccounts").val())) {
        hintMessage("txtAccounts", "error", "<br/>由字母、数字、下划线的组合！");
        return false;
    }

    if ($("#txtAccounts").val().length < 4 || $("#txtAccounts").val().length > 12) {
        hintMessage("txtAccounts", "error", "<br/>代理账号长度为4-12个字符");
        return false;
    }
    hintMessage("txtAccounts", "right", "");
    return true;
}

///账号重复校验 
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
                hintMessage("txtAccountsTip", "right", ""); //"账号可以注册"
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
    if ($("#txtLogonPass").val() == "") {
        hintMessage("txtLogonPass", "error", "<br/>请输入您的登录密码");
        return false;
    }
    if ($("#txtLogonPass").val().length < 6 || $("#txtLogonPass").val().length > 32) {
        hintMessage("txtLogonPass", "error", "<br/>密码长度为6到32个字符");
        return false;
    }
    hintMessage("txtLogonPass", "right", "");
    return true;
}
///密码2
function checkLoginConPass() {
    if ($("#txtLogonPass2").val() == "") {
        hintMessage("txtLogonPass2", "error", "<br/>请输入登录确认密码");
        return false;
    }
    if ($("#txtLogonPass2").val() != $("#txtLogonPass").val()) {
        hintMessage("txtLogonPass2", "error", "<br/>两次密码输入不一致");
        return false;
    }
    hintMessage("txtLogonPass2", "right", "");
    return true;
}


///检查姓名
function checkCompellation() {
    var trueName = $("#txtName").val();
    if (trueName == "") {
        hintMessage("txtName", "error", "<br/>请输入姓名");
        return false;
    }
    if ($.trim(trueName) != "") {
        if (trueName.length > 5) {
            hintMessage("txtName", "error", "<br/>真实姓名长度不能大于5个字");
            return false;
        }
    }
    if (!/[u4e00-u9fa5]+/.test(trueName)) {
        if (trueName.length > 5) {
            hintMessage("txtName", "error", "<br/>真实姓名最多5位");
            return false;
        }
    }
    else {
        hintMessage("txtName", "error", "<br/>真实姓名只能为中文");
        return false;
    }

    hintMessage("txtName", "right", "");
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
        hintMessage("txtQQTip", "error", "请输入QQ");
        return false;
    }
    if ($.trim($("#txtQQ").val()) != "") {
        if ($("#txtQQ").val().length < 5 || $("#txtName").val().length > 11) {
            hintMessage("txtQQTip", "error", "5到11位的QQ号");
            return false;
        }
    }
    hintMessage("txtQQTip", "right", "");
    return true;
}


function checkPhone() {
    if ($.trim($("#txtPhone").val()) != "") {
        if ($("#txtPhone").val().length != 11) {
            hintMessage("txtPhoneTip", "error", "11位手机号码");
            return false;
        }
    }
    hintMessage("txtPhoneTip", "right", "");
    return true;
}

function checkEmail() {
    if ($("#txtEmail").val() == "") {
        hintMessage("txtEmailTip", "error", "请输入邮箱");
        return false;
    }
    if ($.trim($("#txtEmail").val()) != "") {
        var reg = /^[\w\-\.]+@[\w\-\.]+(\.\w+)+$/;
        if (!reg.test($("#txtEmail").val())) {
            hintMessage("txtEmailTip", "error", "Email格式不正确！");
            return false;
        }
    }
    hintMessage("txtEmailTip", "right", "");
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
        $("#txtAccounts").focus(); return false;
    }
    /*else 
    {
    if (isExitsUserName)
    {
    $("#txtAccounts").focus();
    hintMessage("txtAccountsTip", "error", "该账号已经被注册");
    return false;
    }
    }
    */

    if (!checkLoginPass()) { $("#txtLogonPass").focus(); return false; }
    if (!checkLoginConPass()) { $("#txtLogonPass2").focus(); return false; }
    if (!checkCompellation()) { $("#txtName").focus(); return false; }
    if (!checkEmail()) { $("#txtEmail").focus(); return false; }
    if (!checkPhone()) { $("#txtPhone").focus(); return false; }
    if (!checkQQ()) { $("#txtQQ").focus(); return false; }
    if (!checkVerifyCode()) { $("#txtCode").focus(); return false; }
    if (!checkService()) { return false; }
}

$(document).ready(function () {
    $("#txtAccounts").blur(function () {
        checkAccounts()


        /* if (checkAccounts()) {
        checkUserName();
        }*/
    });
    $("#txtName").blur(function () { checkCompellation(); });
    $("#txtLogonPass").blur(function () { checkLoginPass(); });
    $("#txtLogonPass2").blur(function () { checkLoginConPass(); });
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
    strongRankBind($("#txtLogonPass"), $("#strongpass"));

    $('#txtEmail').autoMail({
        emails: ['qq.com', '163.com', '126.com', 'sina.com', 'sohu.com', 'yahoo.cn', 'gmail.com', 'hotmail.com', 'live.cn']
    });

});

$(function () {
    $("#txtPhone").keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '');
    })

    $("#txtQQ").keyup(function () {
        this.value = this.value.replace(/[^\d]/g, '');
    })



});