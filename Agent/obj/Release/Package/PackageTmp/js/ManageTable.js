(function () {
    ManagePagination = function (fillName) {
        var that = this;
        var pCount = 1
        var evt = evt || function () { return false };
        var DataCount = 0;
        that.opt = {
            sReserved: 2,
            eReserved: 2,
            mReserved: 5,
            currentnum: 1,
            splitStr: "...",
            pageStencil: "<a href='javascript:void(0)' {0} id='" + fillName + "_a_{1}'>{2}</a>"
        }
        var opt = that.opt
        var appendPage = function () {
            var endPage = '';
            for (var i = opt.eReserved - 1; i >= 0; i--) {
                endPage += opt.pageStencil.format('', pCount - i, pCount - i);
            }
            return opt.splitStr + endPage;
        }
        var addPage = function () {
            var startPage = '';
            for (var i = 1; i <= opt.sReserved; i++) {
                startPage += opt.pageStencil.format('', i, i);
            }
            return startPage + opt.splitStr;
        }
        var writeHTML = function () {
            var showHTML = "";
            var currentnum = opt.currentnum;
            var sReserved = opt.sReserved;
            var eReserved = opt.eReserved;
            var mReserved = opt.mReserved;
            var astyle = "style='COLOR: #FFFFFF; BACKGROUND-COLOR: #666666'";
            if (pCount == 1) {
                showHTML = opt.pageStencil.format(astyle, 1, 1);
            }
            else {
                var pageShowCount = opt.sReserved + opt.eReserved + opt.mReserved
                if (pCount > pageShowCount) {
                    if (currentnum < sReserved + mReserved) {
                        for (var i = 1; i <= sReserved + mReserved; i++) {
                            if (currentnum == 1 && i == 1)
                                showHTML += opt.pageStencil.format(astyle, i, i);
                            else
                                showHTML += opt.pageStencil.format('', i, i);
                        }
                        showHTML += appendPage();
                    }
                    else if (currentnum > pCount - (eReserved + mReserved - 1)) {
                        showHTML += addPage();
                        for (var i = pCount - (eReserved + mReserved - 1) ; i <= pCount; i++) {
                            showHTML += opt.pageStencil.format('', i, i);
                        }
                    }
                    else {
                        showHTML += addPage();
                        for (var i = currentnum - sReserved; i < currentnum; i++) {
                            showHTML += opt.pageStencil.format('', i, i);
                        }
                        for (var i = currentnum; i <= currentnum + eReserved; i++) {
                            showHTML += opt.pageStencil.format('', i, i);
                        }
                        showHTML += appendPage();
                    }
                }
                else {
                    for (var i = 1; i <= pCount; i++) {
                        showHTML += opt.pageStencil.format('', i, i);
                    }
                }
            }
            if ($('#TJ'))
                $('#TJ').text(DataCount);
            return "<div class=\"new3\" style='width:" + (currentnum >= 7 ? 760 : 610) + "px'><div id=\"" + fillName + "pageContent\" class=\"megas512\">" + opt.pageStencil.format('', "bp", "上一页") + showHTML + opt.pageStencil.format('', "np", "下一页") + opt.pageStencil.format('', "scount", "总条数：" + DataCount + "条") + "</div>";
        }
        var pageEvent = function () {
            $("#" + fillName + "pageContent a[id!='" + fillName + "_a_" + opt.currentnum + "']").bind("click", function () {
                var that_a = $(this);
                var curpage = that_a.attr("id").replace(eval("/" + fillName + "_a_/"), '');
                if (curpage == "scount")
                    return;
                if (curpage == "bp") {
                    if (opt.currentnum == 1) return false;
                    opt.currentnum--;
                }
                else if (curpage == "np") {
                    if (opt.currentnum == pCount) return false;
                    opt.currentnum++;
                }
                else
                    opt.currentnum = parseInt(curpage);
                $("#" + fillName + "pageContent").html(writeHTML());
                pageEvent();
                evt();
            }).attr("style", "");
            $("#" + fillName + "_a_" + opt.currentnum).attr("style", "COLOR: #FFFFFF; BACKGROUND-COLOR: #666666");
        }
        that.InitManagePage = function (pageCount, dataCount, evet) {
            pCount = pageCount;
            evt = evet;
            DataCount = dataCount;
            $("." + fillName).html(writeHTML());
            pageEvent();
        }
        that.Clear = function (index) {
            opt.currentnum = index || 1;
            $("." + fillName).html('');
        }
    }
    ManageTable = function (fillName) {
        var that = this;
        that.opt = {
            waitHtml: "<div id='waitTable' style=\"text-align: center\">未查到数据</div>",
            fillObj: $("." + fillName),
            isCheckBox: false
        }
        var fionj = that.opt.fillObj.find("table");
        that.WaitData = function () {
            fionj.hide().eq(0).before(that.opt.waitHtml);
        }
        that.FillingData = function (colData) {
            that.Clear();
            $("#waitTable").remove();
            var tableHTML = "";
            var trStyle = "";
            var checkHTML = "";
            if (that.opt.isCheckBox) {
                checkHTML = "<td height=\"35px\"><input name=\"" + fillName + "_fxks\" type=\"checkbox\" class=\"fxk\" value=\"\" /></td>";
            }
            
            $.each(colData, function (k, v) {
                //if (k % 2 == 0)
                //    trStyle = "class=\"STYLE8\"";
                //else
                //    trStyle = "";
                trStyle = "class=\"STYLE6\"";
                var tdHTML = "";
                var data = colData[k];
                tableHTML += "<tr name='" + fillName + "_ctr' " + trStyle + " id='" + data.k + "'>" + checkHTML;
                if (data.d) {
                    var d = data.d;
                    for (var i = 0; i < d.length; i++) {
                        var style = "";
                        if (data.c)
                            style = data.c[i];
                        tdHTML += "<td " + style + " height=\"35px\">" + d[i] + "</td>";
                    }
                }
                var extendRowHtml = "";
                if (data.e) {
                    var extendRow = data.e;
                    for (var i = 0; i < extendRow.length; i++) {
                        extendRowHtml += extendRow[i];
                    }
                }
                tableHTML += tdHTML + extendRowHtml + "</tr>";
            });
            fionj.show().append(tableHTML);
        }
        that.Clear = function () {
            fionj.find("[name='" + fillName + "_ctr']").remove();
        }
        that.GetRowKeys = function (operatingElements) {
            var keys = new Array();
            $.each(operatingElements, function (i) {
                //keys[i] = parseInt(operatingElements[i].parents("tr").attr("id").replace(/k_/, ''));
                keys[i] = parseInt(operatingElements[i].parents("tr").attr("id").replace(eval("/" + fillName + "_k_/"), ''));
            });
            return keys;
        }
        that.GetRowKeysStr = function (operatingElements) {
            var keys = ''
            if (operatingElements.length == 1) {
                var t_mp;
                if (operatingElements instanceof Array)
                    t_mp = operatingElements[0];
                else
                    t_mp = operatingElements;
                //keys = t_mp.parents("tr").attr("id").replace(/k_/, '') + ',';
                keys = t_mp.parents("tr").attr("id").replace(eval("/" + fillName + "_k_/"), '') + ',';
            }
            else {
                $.each(operatingElements, function (i) {
                    //keys += (operatingElements[i].parents("tr").attr("id").replace(/k_/, '')) + ',';
                    keys += (operatingElements[i].parents("tr").attr("id").replace(eval("/" + fillName + "_k_/"), '')) + ',';
                });
            }
            return keys.substring(0, keys.length - 1);
        }
        that.GetRowValues = function (operatingElement) {
            var rowValues = new Array();
            $.each(operatingElement.parents("tr").children(), function (i, v) {
                rowValues[i] = $(v).text();
            });
            return rowValues;
        }
        that.GetRowsValues = function (operatingElements) {
            var rowsValue = new Array();
            $.each(operatingElements, function (i) {
                rowsValue[i] = new Array();
                $.each($(this).parents("tr").children(), function (j, v) {
                    rowsValue[i][j] = $(v).text();
                });
            });
            return rowsValue;
        }
        that.GetCheckObj = function () {
            var objs = new Array();
            var n = 0;
            $("input[name='" + fillName + "_fxks']").each(function () {
                var t = $(this);
                if (t.prop("checked")) {
                    objs[n] = t;
                    n++;
                }
            });
            return objs;
        }
        that.ClearCheck = function () {
            $(":checkbox").prop("checked", false);
        }
        $("#seletall").click(function () {
            if ($(this).prop("checked"))
                $("input[name='" + fillName + "_fxks']").prop("checked", true);
            else
                $("input[name='" + fillName + "_fxks']").prop("checked", false);
        });
    }
    window.MP = ManagePagination;
    window.MT = ManageTable;
    BindData = function (args) {
        var that = this;
        args.isPage = !args.isPage;
        args.tableTage = args.tableTage || "right4";
        //alert(1111);
        args.LineTage = args.LineTage || "page";
        args.serverName = args.serverName || "";
        args.postData = args.postData || {};
        args.bData = args.bData || function (data) { return false };
        args.isCheckBox = args.isCheckBox;
        args.pageSize = args.pageSize || 10;
        that.pageObj;
        that.currentnum;
        that.tableObj;
        if (args.isPage)
            that.pageObj = new MP(args.LineTage);
        that.tableObj = new MT(args.tableTage);
        that.tableObj.opt.isCheckBox = args.isCheckBox;
        var GetData = function () {
            args.postData.pageindex = that.currentnum = that.pageObj.opt.currentnum;
            args.postData.pagesize = args.pageSize;
            $.SendData(false, args.postData, args.serverName,
                function () {
                    that.tableObj.WaitData();
                },
                function (msg) {
                    if (msg.msg) {
                        alert(msg.msg);
                        that.Clear();
                        $("#waitTable").remove();
                        return;
                    }
                    if (that.pageObj) {
                        if ($("#sum"))
                            $("#sum").html(msg.Sum);
                        if ($("#sum1"))
                            $("#sum1").html(msg.Sum1);
                        if ($("#fee"))
                        {
                            $("#fee").html(2.00 * msg.Total);
                            $("#yingfu").html(msg.Sum+2.00 * msg.Total);
                        }
                            
                        var pageCount = parseInt(msg.Total % args.pageSize == 0 ? msg.Total / args.pageSize : msg.Total / args.pageSize + 1);
                        that.pageObj.InitManagePage(pageCount, msg.Total, GetData);
                    }

                    var colData = new Array();
                    $.each(msg.Rows, function (k, v) {
                        colData[k] = args.bData(v);
                    });
                    that.tableObj.FillingData(colData);

                }
            );
        }
        that.ShowGameRecord = function (req) {
            new OpeIframeWindow("UserGameRecord.html?uid=" + that.tableObj.GetRowKeysStr($(req)), "游戏记录");
        }
        that.OpenSChange = function (obj, index) {
            var parmsarray = that.tableObj.GetRowValues($(obj));
            new OpeIframeWindow("ScoreChange.html?uid=" + parmsarray[index.uid] + "&uname=" + parmsarray[index.uname], "金币变化", { autoOpen: true, modal: true, height: 700, width: 1000 });
        }
        that.Bind = function () {
            var pindex = QueryString("pageIndex");
            if (that.pageObj) that.pageObj.Clear(isNaN(pindex) ? null : pindex);
            GetData();
            return this;
        }
        that.ToURL = function (url, parms) {
            window.location.href = url + "?pageIndex=" + that.currentnum + "&" + parms;
        }
        that.RefData = function () {
            GetData();
        }
        that.Clear = function () {

            that.tableObj.Clear();
            that.pageObj.Clear();
        }
    }
    window.BindData = BindData;
})(jQuery);
var ToUrlBack = function (url) {
    window.location.href = url + "?pageIndex=" + QueryString("pageIndex");
}
//var GetKindOption = function (optList) {
//    $.SendData(false, {}, "UGRList", null, function (data) {
//        var optHTML = new String();
//        $.each(data, function (i, o) {
//            optHTML += "<option value='" + o.key + "'>" + o.value + "</option>";
//        });
//        if (optList) {
//            for (var i = 0; i < optList.length; i++) {
//                var t = new String();
//                if (optList[i].t)
//                    t = "<option value='-1'>全部游戏类型</option>";
//                $("#" + optList[i].id).append(t + optHTML);
//            }
//        }
//        else
//            $("#roomselect").append("<option value='-1'>全部游戏类型</option>" + optHTML);
//    });
//}
var GetKindOption = function (optList) {
    $.SendData(false, { action: "GameList", r: Math.random() }, "/ashx/UserGameRecord.ashx", null, function (data) {
        var optHTML = new String();
        $.each(data, function (i, o) {
            optHTML += "<option value='" + o.KindID + "'>" + o.KindName + "</option>";
        });
        if (optList) {
            for (var i = 0; i < optList.length; i++) {
                var t = new String();
                if (optList[i].t)
                    t = "<option value='-1'>全部游戏类型</option>";
                $("#" + optList[i].id).append(t + optHTML);
            }
        }
        else
            $("#roomselect").append("<option value='-1'>全部游戏类型</option>" + optHTML);
    });
}

function formatNumber(num) {
    if (num == null || num == "" || num == 0 || num == "NaN")
        return "0";
    return num
    //var array = num.toString().split('');
    //if (num < 0) {
    //    array.splice(0, 1);
    //}

    //var index = -4;
    //while (array.length + index > 0) {
    //    // 从单词的最后每隔三个数字添加逗号  
    //    array.splice(index, 0, ',');
    //    index -= 5;
    //}
    //if (num < 0)
    //    return "-" + array.join('')
    //return array.join('');
};