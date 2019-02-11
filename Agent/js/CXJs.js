function CloseDiv() {
    $("#windownbg").remove();
    $("#windown-box").fadeOut("slow", function () { $(this).remove(); });
}
function CurentTime() {
    var d = new Date();
    var years = d.getFullYear();

    var month = add_zero(d.getMonth() + 1);
    var days = add_zero(d.getDate());
    //var hours = add_zero(d.getHours());
    //var minutes = add_zero(d.getMinutes());
    //var seconds = add_zero(d.getSeconds());
    var ndate = years + "-" + month + "-" + days;
        //+ " " + hours + ":" + minutes + ":" + seconds;
    return (ndate);
}
function CurentTimeStart(time) {
    var d = new Date();
    var years = d.getFullYear();

    var month = add_zero(d.getMonth() + 1);
    var days = add_zero(d.getDate());
    //var hours = add_zero(d.getHours());
    //var minutes = add_zero(d.getMinutes());
    //var seconds = add_zero(d.getSeconds());
    var ndate = years + "-" + month + "-" + days;
        //+ (time || " 00:00:00");
    return (ndate);
}
function add_zero(temp) {
    if (temp < 10) return "0" + temp;
    else return temp;
}
//URL获取函数
function getUrlParam(name) {

    var reg = new RegExp("(^|&)" + name + "=([^&]*)(&|$)"); //构造一个含有目标参数的正则表达式对象

    var r = window.location.search.substr(1).match(reg);  //匹配目标参数

    if (r != null) return unescape(r[2]); return null; //返回参数值

}
//验证是否是数字
function clearNoNum(obj) {
    obj.value = obj.value.replace(/[^\d.]/g, "");  //清除“数字”和“.”以外的字符 
    obj.value = obj.value.replace(/^\./g, "");  //验证第一个字符是数字而不是. 
    obj.value = obj.value.replace(/\.{2,}/g, "."); //只保留第一个. 清除多余的. 
    obj.value = obj.value.replace(".", "$#$").replace(/\./g, "").replace("$#$", ".");

}

function check(str) {
    var temp = ""
    for (var i = 0; i < str.length; i++)
        if (str.charCodeAt(i) > 47 && str.charCodeAt(i) < 58)
            temp += str.charAt(i)
    return temp
}

function HideLoad() {
    top.loading1.hide();
}

function IsTure(Temp) {
    if (Temp == "True") {
        return true;
    }
    else {
        false;
    }
}
function hidetop() {
   // top.loading1.hide();
}
function trim(str) { //删除左右两端的空格 
    return str.replace(/(^\s*)|(\s*$)/g, "");
}
function ltrim(str) { //删除左边的空格 
    return str.replace(/(^\s*)/g, "");
}
function rtrim(str) { //删除右边的空格 
    return str.replace(/(\s*$)/g, "");
} 