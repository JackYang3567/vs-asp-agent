(function ($) {
    ConverTimeToDHMS = function (seconds) {
        if (seconds <= 0)
            return "0秒";
        var str = "";
        var day = parseInt(seconds / 0x15180);
        var hour = parseInt((seconds % 0x15180) / 0xe10);
        var minute = parseInt((seconds % 0xe10) / 60);
        var second = parseInt(seconds % 60);
        if (day > 0)
            str += day + "天";
        if (hour > 0)
            str += hour + "小时";
        else
            str += "0小时";
        if (minute > 0)
            str += minute + "分";
        else
            str += "0分";
        if (second > 0)
            str += second + "秒";
        else
            str += "0秒";
        return str;
    };
    JsonToStr = function (o) {
        var arr = [];
        var fmt = function (s) {
            if (typeof s == 'object' && s != null) return JsonToStr(s);
            return /^(string|number)$/.test(typeof s) ? "'" + s + "'" : s;
        };
        for (var i in o) arr.push("'" + i + "':" + fmt(o[i]));
        return '{' + arr.join(',') + '}';
    };
    OperType = {
        Insert: 1,
        Delete: 2,
        Update: 3
    };

    SetFontColor =
    {
        Red: function (text) {
            return "<font color='#FF0000'>" + text + "</font>";
        },
        Green: function (text) {
            return "<font color='#71C671'>" + text + "</font>";
        }
    };
    G_AddUserNameLink = function (uname, uid, color) {
        if (uname != "") {
            return "<a href='javascript:void(0)' style='color:" + color + "' onclick='G_UserDetails(\"" + uname + "\"," + uid + ")'>" + uname + "</a>";
        }
        else {
            return "";
        }
    }
    G_UserDetails = function (uname, uid) {
        detailsDialog = new OpeIframeWindow2("/Module/AccountManager/UserDetails.html?uid=" + uid + "&uname=" + uname, "用户信息");
    }
    G_IPSpanTitle = function (name, title) {
        if (name != "") {
            return "<span title='" + title + "'>" + name + "</span>";
        }
        else {
            return "";
        }
    }

    CloseDetails = function () {
        detailsDialog.Close();
    }

    ServreErrorMsg = function (dMsg) {
        //alert("dMsg:"+dMsg);
        var showMsg = dMsg || "服务器错误 请稍候再试";
        alert(showMsg);
    };
    var LoginShowOnce = false;
    var FomatData = function (dataMap) {
        if (dataMap === "" || dataMap === null) return "";
        var date = "";
        $.each(dataMap, function (k, v) {
            date += k + "=" + v + "&";
        });
        return date.substring(0, date.length - 1);
    };
    QueryString = function (n) {
        var t = location.href, f = t.substring(t.indexOf("?") + 1, t.length).split("&"), u = {}, r;
        for (i = 0; j = f[i]; i++)
            u[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
        return r = u[n.toLowerCase()], typeof r == "undefined" ? "" : r;
    };
    String.prototype.format = function (args) {
        var result = this;
        if (arguments.length > 0) {
            if (arguments.length == 1 && typeof (args) == "object") {
                for (var key in args) {
                    if (args[key] != undefined) {
                        var reg = new RegExp("({" + key + "})", "g");
                        result = result.replace(reg, args[key]);
                    }
                }
            } else {
                for (var i = 0; i < arguments.length; i++) {
                    if (arguments[i] != undefined) {
                        var reg = new RegExp("({)" + i + "(})", "g");
                        result = result.replace(reg, arguments[i]);
                    }
                }
            }
        }
        return result;
    };
    $.extend({
        SendData: function (sy, d, t, l, m, timeoutFun, purl) {
            $.ajax({
                type: "POST",
                dataType: "json",
                data: FomatData(d),
                url: t,
                async: sy,
                cache: false,
                beforeSend: function () {
                    l && l();
                },
                success: function (msg) {
                    if (msg.error != undefined) {
                        if (!LoginShowOnce) {
                            LoginShowOnce = true;
                            if (msg.error == 0) {
                                alert("登录超时 请重新登陆");
                                window.top.location = "/login.html";
                            }
                            else
                                alert(msg.msg);
                        }
                    }
                    else
                        m(msg);
                },
                complete: function (XMLHttpRequest, status) {
                    if (status == 'timeout') {
                        timeoutFun && timeoutFun();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                }
            });
        },
        SendData_Text: function (sy, d, t, l, m, timeoutFun, purl) {

            $.ajax({
                type: "POST",
                data: FomatData(d),

                url: t,
                async: sy,
                cache: false,
                beforeSend: function () {
                    l && l();
                },
                success: function (msg) {
                    if (msg == -1) {
                        if (!LoginShowOnce) {
                            LoginShowOnce = true;
                            alert("登录超时 请重新登陆");
                            window.top.location = "/login.html";
                        }
                    }
                    else if (msg == -2) {
                        if (!LoginShowOnce) {
                            LoginShowOnce = true;
                            alert("您没有权限执行此操作");
                        }
                    }
                    else {
                        m(msg);
                    }
                },
                complete: function (XMLHttpRequest, status) {
                    if (status == 'timeout') {
                        timeoutFun && timeoutFun();
                    }
                },
                error: function (XMLHttpRequest, textStatus, errorThrown) {
                    alert("XMLHttpRequest:" + XMLHttpRequest + ",textStatus:" + textStatus + ",errorThrown:" + errorThrown);

                }
            });
        }
    });
    $.fn.extend({
        buttonDisabled: function (b) {
            $(this).prop("disabled", b);
        },
        aDisabled: function (b, evt) {
            if (b)
                $(this).unbind("click");
            else
                $(this).bind("click", evt);
        },
        SetDefaultDate: function (addDay, isHour) {
            var mdate = new Date();
            if (!addDay)
                $(this).val(mdate.getFullYear() + "-" + (mdate.getMonth() + 1) + "-" + (parseInt(mdate.getDate())));
            else {
                mdate = mdate.valueOf();
                mdate = mdate + addDay * 24 * 60 * 60 * 1000;
                mdate = new Date(mdate);
                $(this).val(mdate.getFullYear() + "-" + (mdate.getMonth() + 1) + "-" + (parseInt(mdate.getDate())));
            }
        },
        SetDefaultDateSecond: function (t) {
            var mdate = new Date();
            if (t)
                $(this).val(mdate.getFullYear() + "-" + (mdate.getMonth() + 1) + "-" + (parseInt(mdate.getDate())) + " 00:00:00");
            else {
                $(this).val(mdate.getFullYear() + "-" + (mdate.getMonth() + 1) + "-" + (parseInt(mdate.getDate())) + " " + mdate.getHours() + ":" + mdate.getMinutes() + ":" + mdate.getSeconds());
            }
        }

    });


    OpeIframeWindow = function (url, mtitle, opt, isDiv) {
        var mopt = opt || { autoOpen: true, modal: true, height: 650, width: 1000 };
        mopt.title = mtitle;
        var mDialog;
        if (isDiv)
            mDialog = $("#" + url).dialog(mopt);
        else {
            mopt.close = function (event, ui) {
                $("body").focus();
                mDialog.remove();
            };
            mDialog = $("<div id='edit_div'><iframe style='height:99%;width:99%' id='edit_iframe' src='" + url + "' scrolling='no' frameborder ='0'/></div>").dialog(mopt);
        }
        this.Close = function () {
            mDialog.dialog("close");
        };
    };
    //同桌玩家
    OpeIframeWindow3 = function (url, mtitle, opt, isDiv) {
        var mopt = opt || { autoOpen: true, modal: true, height: 650, width: 1000 };
        mopt.title = mtitle;
        var mDialog;
        if (isDiv)
            mDialog = $("#" + url).dialog(mopt);
        else {
            mopt.close = function (event, ui) {
                $("body").focus();
                mDialog.remove();
            };
            mDialog = $("<div id='edit_div_ltable'><iframe style='height:99%;width:99%' id='edit_iframe_ltable' src='" + url + "' scrolling='no' frameborder ='0'/></div>").dialog(mopt);
        }
        this.Close = function () {
            mDialog.dialog("close");
        };
    };


    OpeIframeWindow2 = function (url, mtitle, opt, isDiv) {
        var mopt = opt || { autoOpen: true, modal: true, height: 650, width: 1100 };
        mopt.title = mtitle;
        var mDialog;
        if (isDiv)
            mDialog = $("#" + url).dialog(mopt);
        else {
            mopt.close = function (event, ui) {
                $("body").focus();
                mDialog.remove();
            };
            mDialog = $("<div id='edit_iframe_div'><iframe style='height:100%;width:99%' marginheight=0 marginwidth=0 id='edit_iframe' src='" + url + "' scrolling='auto' frameborder ='0'/></div>").dialog(mopt);
        }
        this.Close = function () {
            mDialog.dialog("close");
        };
    };
    FomatDictionary = function (parmsArray) {
        var dictionaryStr = new String();
        for (var i = 0; i < parmsArray.length; i++) {
            dictionaryStr += parmsArray[i].join(',') + "|";
        }
        return dictionaryStr;
    };
    window.FomatDictionary = FomatDictionary
    window.OpeIframeWindow = OpeIframeWindow
})(jQuery);