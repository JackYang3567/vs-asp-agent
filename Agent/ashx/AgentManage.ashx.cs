using Game.Entity.Accounts;
using Game.Entity.NativeWeb;
using Game.Facade;
using Game.Facade.Tools;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Caching;
using System.Web.SessionState;

namespace Agent.ashx
{
    public class AgentManage : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            string s = string.Empty;
            try
            {
                switch (GameRequest.GetInt("doType", 0))
                {
                    case 1:
                        s = this.RegAegnt(context);
                        break;

                    case 2:
                        s = this.SystemInfo(context);
                        break;

                    case 3:
                        s = this.AgentDraw(context);
                        break;

                    case 4:
                        s = this.AgentRecharge(context);
                        break;

                    case 5:
                        s = this.AgentDrawLog(context);
                        break;

                    case 6:
                        s = this.AgentPlayerFillLog(context);
                        break;

                    case 7:
                        s = this.UpdateAgentBank(context);
                        break;

                    case 8:
                        s = this.UpdateAgentPwd(context);
                        break;

                    case 9:
                        s = this.AllNextUser(context);
                        break;

                    case 10:
                        s = this.Login(context);
                        break;

                    case 11:
                        s = this.AegntInfo(context);
                        break;

                    case 12:
                        s = this.LoginOut(context);
                        break;

                    case 13:
                        s = this.AegntDetails(context);
                        break;

                    case 14:
                        s = this.AgentUserRecharge(context);
                        break;

                    case 15:
                        s = this.AgentLogType(context);
                        break;

                    case 16:
                        s = this.AgentScoreChange(context);
                        break;

                    case 17:
                        s = this.MyRevRecord(context);
                        break;

                    case 18:
                        s = this.AgentRev(context);
                        break;

                    case 19:
                        s = this.AgentNotice(context);
                        break;

                    case 20:
                        s = this.Pay(context);
                        break;

                    case 21:
                        s = this.PayOrder(context);
                        break;

                    case 22:
                        s = this.RechargeRecord(context);
                        break;

                    case 23:
                        s = this.GameRecord(context);
                        break;

                    case 24:
                        s = this.PlayBalance(context);
                        break;

                    case 25:
                        s = this.AccountScoreList(context);
                        break;

                    case 26:
                        s = this.AccountScoreDetail(context);
                        break;

                    case 27:
                        s = this.AgentReport(context);
                        break;

                    case 28:
                        s = this.YsScoreLog(context);
                        break;

                    case 29:
                        s = this.Recharge(context);
                        break;

                    case 30:
                        s = this.GetPayRate(context);
                        break;

                    case 31:
                        s = this.PayUnlineRecord(context);
                        break;

                    case 32:
                        s = this.GetGameList(context);
                        break;

                    case 33:
                        s = this.GetRoomList(context);
                        break;

                    case 34:
                        s = this.GetReportList(context);
                        break;

                    case 35:
                        s = this.GetAccounts(context);
                        break;

                    case 36:
                        s = this.GetOnlinePlayer(context);
                        break;

                    case 37:
                        s = this.PresentLog(context);
                        break;

                    case 38:
                        s = this.GetGameChart(context);
                        break;

                    default:
                        s = this.AegntList(context);
                        break;
                }
            }
            catch (System.Exception ex)
            {
                s = ex.Message;
            }
            context.Response.Clear();
            context.Response.Write(s);
            context.Response.End();
        }

        public string RegAegnt(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("account"));
            string formString = GameRequest.GetFormString("password");
            int formInt = GameRequest.GetFormInt("agentNum", 0);
            string safeSQL2 = FiltUtil.GetSafeSQL(GameRequest.GetFormString("trueName"));
            if (safeSQL == "" || formString == "" || safeSQL2 == "" || formInt < 1 || formInt > 80)
            {
                return "参数错误！";
            }
            AgentInfo agentInfo = new AgentInfo(safeSQL, Utility.MD5(formString), System.Convert.ToDouble(formInt) / 100.0, safeSQL2, "", "", "", GameRequest.GetUserIP(), agentInfoFromCookie.AgentID);
            agentInfo.ParentID = agentInfoFromCookie.AgentID;
            Message message = FacadeManage.aideAccountsFacade.RegAegnt(agentInfo);
            if (message.Success)
            {
                return "1";
            }
            return message.Content;
        }

        public string AegntList(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            if (!TypeUtil.IsHasRight("agent", agentInfoFromCookie.QueryRight, 128, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int @int = GameRequest.GetInt("type", 0);
            int int2 = GameRequest.GetInt("aid", 0);
            string formString = GameRequest.GetFormString("aname");
            int int3 = GameRequest.GetInt("pageindex", 1);
            int int4 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND AgentAcc ='{0}'", formString);
            }
            if (int2 > 0)
            {
                stringBuilder.AppendFormat(" AND ParentID ={0} AND ParentID IN(SELECT NodeID FROM RYAgentDB..Fn_GetAllNodes(1,{1}))", int2, agentInfoFromCookie.AgentID);
            }
            else
            {
                if (@int == 1)
                {
                    stringBuilder.AppendFormat(" AND ParentID ={0}", agentInfoFromCookie.AgentID);
                }
                else
                {
                    if (@int == 2)
                    {
                        stringBuilder.AppendFormat(" AND ParentID IN(SELECT NodeID FROM RYAgentDB..Fn_GetAllNodes(1,{0}) WHERE NodeID<>{0})", agentInfoFromCookie.AgentID);
                    }
                    else
                    {
                        stringBuilder.AppendFormat(" AND ParentID IN(SELECT NodeID FROM RYAgentDB..Fn_GetAllNodes(1,{0}))", agentInfoFromCookie.AgentID);
                    }
                }
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB..T_Acc_Agent", int3, int4, stringBuilder.ToString(), "ORDER BY AgentID DESC");
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" }"
			});
        }

        public string SystemInfo(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            if (!TypeUtil.IsHasRight("money", agentInfoFromCookie.QueryRight, 8192, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            return JsonHelper.SerializeObject(FacadeManage.aideAccountsFacade.AgentCashInfo());
        }

        public string AgentDraw(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("money", agentInfoFromCookie.QueryRight, 8192, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            double num = System.Convert.ToDouble(context.Request.Form["pscore"]);
            GameRequest.GetFormString("adata");
            string formString = GameRequest.GetFormString("bankname");
            string formString2 = GameRequest.GetFormString("banktitle");
            string formString3 = GameRequest.GetFormString("bankaddress");
            if (num <= 0.0 || formString == "" || formString2 == "" || formString3 == "")
            {
                return "参数错误！";
            }
            AgentInfo agentInfo = new AgentInfo();
            agentInfo.AgentID = agentInfoFromCookie.AgentID;
            agentInfo.Score = num;
            agentInfo.BankName = formString;
            agentInfo.BankAcc = formString2;
            agentInfo.BankAddress = formString3;
            agentInfo.LastIP = GameRequest.GetUserIP();
            agentInfo.Memo = PayHelper.GetOrderIDByPrefix("");
            Message message = FacadeManage.aideAccountsFacade.AgentDraw(agentInfo);
            if (message.Success)
            {
                return "1";
            }
            return message.Content;
        }

        public string AgentRecharge(HttpContext context)
        {
            return "暂不开启该功能！";
        }

        public string Pay(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("pay", agentInfoFromCookie.QueryRight, 0, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            string formString = GameRequest.GetFormString("orderId");
            int formInt = GameRequest.GetFormInt("score", 0);
            if (formString == "" || formInt < 1)
            {
                return "参数错误！";
            }
            System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
            dictionary["OrderID"] = formString;
            dictionary["Score"] = formInt;
            dictionary["dwAgentID"] = agentInfoFromCookie.AgentID;
            dictionary["StrErr"] = "";
            Message message = FacadeManage.aideAccountsFacade.ExcuteByProce("RYAgentDB..P_AgentFillOrder", dictionary);
            if (message.Success)
            {
                return "1";
            }
            return message.Content;
        }

        public string Recharge(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            string formString = GameRequest.GetFormString("dwGameID");
            string formString2 = GameRequest.GetFormString("strPwd");
            string formString3 = GameRequest.GetFormString("dwScore");
            string formString4 = GameRequest.GetFormString("remainScore");

            decimal num = 0m;
            decimal num1 = 0m;
            if (formString == "" || formString2 == "" || !decimal.TryParse(formString3, out num) || (formString4 != "" && !decimal.TryParse(formString4, out num1)))
            {
                return "参数错误！";
            }

            System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
            dictionary["dwOperator"] = agentInfoFromCookie.AgentID;
            dictionary["strPwd"] = Utility.MD5(formString2);
            dictionary["dwGameID"] = formString;
            dictionary["dwScore"] = num;
            dictionary["remainScore"] = num1;
            dictionary["strClientIP"] = GameRequest.GetUserIP();
            dictionary["StrErr"] = "";
            Message message = FacadeManage.aideAccountsFacade.ExcuteByProce("RYAgentDB..P_YsAgentRecharge", dictionary);
            if (message.Success)
            {
                return "1";
            }
            return message.Content;
        }

        public string AgentDrawLog(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("DuiHuanRecord", agentInfoFromCookie.QueryRight, 16384, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE 1=1");
            stringBuilder.AppendFormat(" AND AgentID={0}", agentInfoFromCookie.AgentID);
            if (formString != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                stringBuilder.AppendFormat(" AND ApplyTime>='{0}'", dateTime);
            }
            if (formString2 != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" AND ApplyTime<='{0}'", dateTime);
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB..View_AgentDraw", @int, int2, stringBuilder.ToString(), "ORDER BY ID DESC");
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" }"
			});
        }

        public string AgentPlayerFillLog(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("account"));
            int @int = GameRequest.GetInt("type", 0);
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int int2 = GameRequest.GetInt("pageindex", 1);
            int int3 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE TradeType =3");
            if (@int == 0)
            {
                stringBuilder.AppendFormat(" AND ParentID={0}", agentInfoFromCookie.AgentID);
            }
            else
            {
                stringBuilder.AppendFormat(" AND ParentID IN (SELECT NodeID FROM RYAgentDB..Fn_GetAllNodes(1,{0}) WHERE NodeID<>{0})", agentInfoFromCookie.AgentID);
            }
            if (formString != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                stringBuilder.AppendFormat(" AND CollectDate>='{0}'", dateTime);
            }
            if (formString2 != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" AND CollectDate<='{0}'", dateTime);
            }
            if (safeSQL != "")
            {
                stringBuilder.AppendFormat(" AND Accounts='{0}'", safeSQL);
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB..view_PlayerFillLog", int2, int3, stringBuilder.ToString(), "ORDER BY CollectDate DESC");
            double num = FacadeManage.aideAccountsFacade.SumAgentPlayerPay(stringBuilder.ToString());
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" , \"Sum\": ",
				num,
				" }"
			});
        }

        public string PayOrder(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("payOrder", agentInfoFromCookie.QueryRight, 0, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("account"));
            int @int = GameRequest.GetInt("type", 0);
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int int2 = GameRequest.GetInt("pageindex", 1);
            int int3 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE OrderStatus =1");
            stringBuilder.AppendFormat(" AND AgentID={0}", agentInfoFromCookie.AgentID);
            if (formString != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                stringBuilder.AppendFormat(" AND OperateDate>='{0}'", dateTime);
            }
            if (formString2 != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" AND OperateDate<='{0}'", dateTime);
            }
            if (safeSQL != "")
            {
                if (@int == 1)
                {
                    stringBuilder.AppendFormat(" AND Accounts='{0}'", safeSQL);
                }
                else
                {
                    if (@int == 2)
                    {
                        stringBuilder.AppendFormat(" AND GameID={0}", safeSQL);
                    }
                    else
                    {
                        stringBuilder.AppendFormat(" AND OrderId='{0}'", safeSQL);
                    }
                }
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB..T_AgentFillOrder", int2, int3, stringBuilder.ToString(), "ORDER BY OperateDate DESC");
            decimal num = FacadeManage.aideAccountsFacade.SumPayOrder(stringBuilder.ToString());
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" , \"Sum\": ",
				num,
				" }"
			});
        }

        public string UpdateAgentBank(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("revise", agentInfoFromCookie.QueryRight, 32, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            string formString = GameRequest.GetFormString("bankname");
            string formString2 = GameRequest.GetFormString("banktitle");
            string formString3 = GameRequest.GetFormString("bankaddress");
            if (formString == "" || formString2 == "" || formString3 == "")
            {
                return "参数错误！";
            }
            AgentInfo model = new AgentInfo(agentInfoFromCookie.AgentID, formString, formString2, formString3);
            string result;
            try
            {
                FacadeManage.aideAccountsFacade.UpdateAegntBank(model);
                agentInfoFromCookie.BankName = formString;
                agentInfoFromCookie.BankAcc = formString2;
                agentInfoFromCookie.BankAddress = formString3;
                AdminCookie.SetAgentCookieNew(agentInfoFromCookie);
                result = "1";
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string UpdateAgentPwd(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("revise", agentInfoFromCookie.QueryRight, 32, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            string formString = GameRequest.GetFormString("oldPass");
            string formString2 = GameRequest.GetFormString("newPass");
            if (formString == "" || formString2 == "")
            {
                return "参数错误！";
            }
            if (Utility.MD5(formString) != agentInfoFromCookie.Pwd)
            {
                return "原密码错误！";
            }
            AgentInfo agentInfo = new AgentInfo();
            agentInfo.AgentID = agentInfoFromCookie.AgentID;
            agentInfo.Pwd = Utility.MD5(formString2);
            string result;
            try
            {
                FacadeManage.aideAccountsFacade.UpdateAegntPwd(agentInfo);
                agentInfoFromCookie.Pwd = agentInfo.Pwd;
                AdminCookie.SetAgentCookieNew(agentInfoFromCookie);
                result = "1";
            }
            catch (System.Exception ex)
            {
                result = ex.Message;
            }
            return result;
        }

        public string AgentUserRecharge(HttpContext context)
        {
            return "暂不开启该功能！";
        }

        public string AgentScoreChange(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("change", agentInfoFromCookie.QueryRight, 1024, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int formInt = GameRequest.GetFormInt("cType", 0);
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("acc"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            stringBuilder.AppendFormat(" AND AgentID IN (SELECT NodeID FROM RYAgentDB.dbo.Fn_GetAllNodes(1,{0}))", agentID);
            if (safeSQL != "")
            {
                stringBuilder.AppendFormat(" AND AgentAcc='{0}'", safeSQL);
            }
            if (formInt > 0)
            {
                stringBuilder.AppendFormat(" AND LogType={0}", formInt);
            }
            if (formString != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                stringBuilder.AppendFormat(" AND SwapDate>'{0}'", dateTime);
            }
            if (formString2 != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" AND SwapDate<'{0}'", dateTime);
            }
            PagerSet list = FacadeManage.aideRecordFacade.GetList("RYAgentDB..View_AgentScoreLog", @int, int2, stringBuilder.ToString(), "ORDER BY SwapDate DESC");
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" }"
			});
        }

        public string MyRevRecord(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("recordcs", agentInfoFromCookie.QueryRight, 512, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("acc"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            stringBuilder.AppendFormat(" AND AgentID ={0}", agentID);
            if (safeSQL != "")
            {
                stringBuilder.AppendFormat(" AND UserAcc='{0}'", safeSQL);
            }
            if (formString != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                stringBuilder.AppendFormat(" AND RevDate>'{0}'", dateTime);
            }
            if (formString2 != "")
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" AND RevDate<'{0}'", dateTime);
            }
            PagerSet list = FacadeManage.aideRecordFacade.GetList("RYAgentDB..view_MyRevRecord", @int, int2, stringBuilder.ToString(), "ORDER BY RevDate DESC");
            double num = FacadeManage.aideRecordFacade.SumCS(stringBuilder.ToString());
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" , \"Sum\": ",
				num,
				" }"
			});
        }

        public string AgentLogType(HttpContext context)
        {
            return JsonHelper.SerializeObject(FacadeManage.aideRecordFacade.AgentLogType());
        }

        public string AllNextUser(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            if (!TypeUtil.IsHasRight("game", agentInfoFromCookie.QueryRight, 64, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int formInt = GameRequest.GetFormInt("aid", 0);
            string formString = GameRequest.GetFormString("account");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            string formString2 = GameRequest.GetFormString("bTimeReg");
            string formString3 = GameRequest.GetFormString("eTimeReg");
            string formString4 = GameRequest.GetFormString("bTimeLogin");
            string formString5 = GameRequest.GetFormString("eTimeLogin");
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("");
            stringBuilder.AppendFormat("WHERE ParentID IN(SELECT NodeID FROM RYAgentDB.dbo.Fn_GetAllNodes(1,{0}))", agentInfoFromCookie.AgentID);
            if (formInt > 0)
            {
                stringBuilder.AppendFormat(" AND ParentID={0}", formInt);
            }
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND Accounts = '{0}'", formString);
            }
            if (formString2 != "")
            {
                stringBuilder.AppendFormat(" AND RegisterDate >= '{0}'", System.Convert.ToDateTime(formString2));
            }
            if (formString3 != "")
            {
                stringBuilder.AppendFormat(" AND RegisterDate <= '{0}'", System.Convert.ToDateTime(formString3).AddDays(1.0));
            }
            if (formString4 != "")
            {
                stringBuilder.AppendFormat(" AND LastLogonDate >= '{0}'", System.Convert.ToDateTime(formString4));
            }
            if (formString5 != "")
            {
                stringBuilder.AppendFormat(" AND LastLogonDate <= '{0}'", System.Convert.ToDateTime(formString5).AddDays(1.0));
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB.dbo.View_AllNextUserZj", @int, int2, stringBuilder.ToString(), "ORDER BY Score ASC,UserID DESC");
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" }"
			});
        }

        public string Login(HttpContext context)
        {
            string formString = GameRequest.GetFormString("vcode");
            string formString2 = GameRequest.GetFormString("account");
            string text = GameRequest.GetFormString("passWord");
            if (!Fetch.ValidVerifyCodeVer3(formString))
            {
                return "验证码错误";
            }
            if (formString2 == "" || text == "")
            {
                return "参数错误";
            }
            text = Utility.MD5(text);
            AgentInfo agentInfo = new AgentInfo();
            agentInfo.AgentAcc = formString2;
            agentInfo.Pwd = text;
            agentInfo.LastIP = GameRequest.GetUserIP();
            Message message = FacadeManage.aideAccountsFacade.AgentLogonNew(agentInfo);
            if (message.Success)
            {
                return "1";
            }
            return message.Content;
        }

        public string AegntInfo(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            agentInfoFromCookie.Score = System.Convert.ToDouble(FacadeManage.aideAccountsFacade.AgentScore(agentInfoFromCookie.AgentID, 0).Tables[0].Rows[0][0]);
            System.Collections.Generic.List<AgentMenu> list = new System.Collections.Generic.List<AgentMenu>();
            if (agentInfoFromCookie.IsClient == 2)
            {
                list.Add(new AgentMenu
                {
                    prefixUrl = "recharge",
                    key = "充值记录"
                });
                list.Add(new AgentMenu
                {
                    prefixUrl = "present",
                    key = "赠送记录"
                });
            }
            else
            {
                list.Add(new AgentMenu
                {
                    prefixUrl = "new",
                    key = "代理信息"
                });
                if (agentInfoFromCookie.IsClient == 1)
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "pay",
                        key = "订单充值"
                    });
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "payOrder",
                        key = "订单充值记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 1))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "recharges",
                        key = "玩家充值记录"
                    });
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "payunline",
                        key = "玩家线下充值记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 2))
                {
                    AgentMenu agentMenu = new AgentMenu();
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "GameChart",
                        key = "玩家游戏报表"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 4))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "balance",
                        key = "玩家提现记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 8))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "accountScoreList",
                        key = "玩家总输赢"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 16))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "notice",
                        key = "代理公告"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 32))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "revise",
                        key = "资料修改"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 64))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "game",
                        key = "玩家管理"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 128))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "agent",
                        key = "代理管理"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 256))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "baobiao",
                        key = "我的报表"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 512))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "recordcs",
                        key = "我的抽水记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 1024))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "change",
                        key = "金币变化记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 2048))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "agent_win",
                        key = "代理输赢情况"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 4096))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "game_win",
                        key = "玩家输赢情况"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 8192))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "money",
                        key = "提款"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 16384))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "DuiHuanRecord",
                        key = "提款记录"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 32768))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "payReport",
                        key = "充值提成报表"
                    });
                }
                if (TypeUtil.AgentRight(agentInfoFromCookie.QueryRight, 65536))
                {
                    list.Add(new AgentMenu
                    {
                        prefixUrl = "onlinePayer",
                        key = "在线玩家"
                    });
                }
            }
            agentInfoFromCookie.menus = list;
            return JsonHelper.SerializeObject(agentInfoFromCookie);
        }

        public string LoginOut(HttpContext context)
        {
            HttpContext.Current.Session.Abandon();
            return "1";
        }

        public string AegntDetails(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            System.Data.DataSet dataSet = FacadeManage.aideAccountsFacade.AgentScore(agentInfoFromCookie.AgentID, 1);
            agentInfoFromCookie.Score = System.Convert.ToDouble(dataSet.Tables[0].Rows[0][0]);
            string text = dataSet.Tables[1].Rows[0][0].ToString();
            AgentStatusInfo agentStatusInfo = new AgentStatusInfo();
            if (context.Cache["AgentURL"] == null)
            {
                agentStatusInfo = FacadeManage.aideAccountsFacade.AgentBaseURL();
                context.Cache["AgentURL"] = agentStatusInfo;
            }
            else
            {
                agentStatusInfo = (context.Cache["AgentURL"] as AgentStatusInfo);
            }
            return string.Concat(new string[]
			{
				"{ \"Agent\": ",
				JsonHelper.SerializeObject(agentInfoFromCookie),
				", \"AgentURL\": ",
				JsonHelper.SerializeObject(agentStatusInfo),
				", \"CZScore\": ",
				text,
				" }"
			});
        }

        public string AgentRev(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            if (!TypeUtil.IsHasRight("agent_win", agentInfoFromCookie.QueryRight, 2048, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int formInt = GameRequest.GetFormInt("aid", agentID);
            string formString = GameRequest.GetFormString("aname");
            string formString2 = GameRequest.GetFormString("sTime");
            string formString3 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            if (formString2 == "" || formString3 == "")
            {
                return "{\"error\":1,\"msg\":\"请选择查询时间！\"}";
            }
            System.DateTime sTime = System.Convert.ToDateTime(formString2);
            System.DateTime eTime = System.Convert.ToDateTime(formString3).AddDays(1.0);
            int formInt2 = GameRequest.GetFormInt("type", 1);
            PagerSet pagerSet = FacadeManage.aideRecordFacade.StraightAgentRev(agentID, formInt, formString, sTime, eTime, @int, int2, formInt2);
            decimal num = 0m;
            decimal num2 = 0m;
            if (pagerSet.PageSet.Tables[1] != null && pagerSet.PageSet.Tables[1].Rows.Count > 0)
            {
                num = TypeUtil.ObjectToDecimal(pagerSet.PageSet.Tables[1].Rows[0]["SumAgentRevTotal"]);
                num2 = TypeUtil.ObjectToDecimal(pagerSet.PageSet.Tables[1].Rows[0]["SumWinlost"]);
            }
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(pagerSet.PageSet.Tables[0]),
				", \"Total\": ",
				pagerSet.RecordCount,
				",\"Sum\":",
				num,
				",\"Sum1\":",
				num2,
				" }"
			});
        }

        public string YsScoreLog(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int formInt = GameRequest.GetFormInt("aid", agentID);
            string formString = GameRequest.GetFormString("aname");
            string formString2 = GameRequest.GetFormString("sTime");
            string formString3 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" where LogType<>1 and AgentID=" + formInt);
            if (!string.IsNullOrEmpty(formString))
            {
                stringBuilder.AppendFormat(" and SwapNote like'%{0}%'", formString);
            }
            if (!string.IsNullOrEmpty(formString2) && !string.IsNullOrEmpty(formString3))
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString2);
                System.DateTime dateTime2 = System.Convert.ToDateTime(formString3).AddDays(1.0);
                stringBuilder.AppendFormat(" and SwapDate>='{0}' and SwapDate<='{1}'", dateTime.ToString("yyyy-MM-dd"), dateTime2.ToString("yyyy-MM-dd"));
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB.dbo.View_YsScoreLog", @int, int2, stringBuilder.ToString(), "ORDER BY SwapDate DESC");
            decimal num = System.Math.Abs(FacadeManage.aideAccountsFacade.GetDecSum("select sum(SwapScore) from RYAgentDB.dbo.View_YsScoreLog" + stringBuilder.ToString()));
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num,
				" }"
			});
        }

        public string PresentLog(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int formInt = GameRequest.GetFormInt("aid", agentID);
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" where LogType=1 and AgentID=" + formInt);
            if (!string.IsNullOrEmpty(formString) && !string.IsNullOrEmpty(formString2))
            {
                System.DateTime dateTime = System.Convert.ToDateTime(formString);
                System.DateTime dateTime2 = System.Convert.ToDateTime(formString2).AddDays(1.0);
                stringBuilder.AppendFormat(" and SwapDate>='{0}' and SwapDate<='{1}'", dateTime.ToString("yyyy-MM-dd"), dateTime2.ToString("yyyy-MM-dd"));
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB.dbo.T_Rec_AgentScoreLog", @int, int2, stringBuilder.ToString(), "ORDER BY SwapDate DESC");
            decimal num = System.Math.Abs(FacadeManage.aideAccountsFacade.GetDecSum("select sum(SwapScore) from RYAgentDB.dbo.T_Rec_AgentScoreLog" + stringBuilder.ToString()));
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num,
				" }"
			});
        }

        public string AgentNotice(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            if (!TypeUtil.IsHasRight("notice", agentInfoFromCookie.QueryRight, 16, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            News agentNotice = FacadeManage.aideNativeWebFacade.GetAgentNotice();
            if (agentNotice != null)
            {
                return agentNotice.FormattedBody;
            }
            return "";
        }

        public string RechargeRecord(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int num = TypeUtil.ObjectToInt(GameRequest.GetFormString("sType"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            string orderby = "Order BY ApplyDate DESC";
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE AUShow=1");
            if (agentID > 0)
            {
                stringBuilder.AppendFormat(" AND ParentID={0} ", agentID);
            }
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND ApplyDate > '{0}'", System.Convert.ToDateTime(formString));
            }
            if (formString2 != "")
            {
                stringBuilder.AppendFormat(" AND ApplyDate <= '{0}'", System.Convert.ToDateTime(formString2).AddDays(1.0));
            }
            if (safeSQL != "")
            {
                switch (num)
                {
                    case 1:
                        stringBuilder.AppendFormat(" AND Accounts='{0}' ", safeSQL);
                        break;

                    case 2:
                        if (TypeUtil.ObjectToInt(safeSQL) <= 0)
                        {
                            return "{\"error\":1,\"msg\":\"游戏ID格式错误！\"}";
                        }
                        stringBuilder.AppendFormat(" AND GameID={0}", safeSQL);
                        break;

                    case 3:
                        stringBuilder.AppendFormat(" and OrderID='{0}'", safeSQL);
                        break;
                }
            }
            PagerSet list = FacadeManage.aideTreasureFacade.GetList("RYAgentDB.dbo.View_NextPayZj", @int, int2, stringBuilder.ToString(), orderby);
            string sql = "Select Sum(PayAmount) AS PayAmount From RYAgentDB.dbo.View_NextPayZj" + stringBuilder.ToString();
            System.Data.DataSet dataSetBySql = FacadeManage.aideTreasureFacade.GetDataSetBySql(sql);
            decimal num2 = 0m;
            if (dataSetBySql.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dataRow = dataSetBySql.Tables[0].Rows[0];
                num2 = System.Convert.ToDecimal(dataRow["PayAmount"]);
            }
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num2,
				" }"
			});
        }

        public string AccountScoreDetail(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "-1";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int @int = GameRequest.GetInt("userID", 0);
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            System.DateTime now = System.DateTime.Now;
            System.DateTime now2 = System.DateTime.Now;
            System.DateTime.TryParse(formString, out now);
            System.DateTime.TryParse(formString2, out now2);
            System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
            dictionary.Add("LogonAgentID", agentID);
            dictionary.Add("UserID", @int);
            dictionary.Add("BTime", now.ToString("yyyy-MM-dd 00:00:00"));
            dictionary.Add("ETime", now2.ToString("yyyy-MM-dd 23:59:59"));
            System.Data.DataTable dataTable = FacadeManage.aideRecordFacade.QueryUserGameWinLost(dictionary);
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            if (dataTable != null && dataTable.Rows.Count > 0)
            {
                foreach (System.Data.DataRow dataRow in dataTable.Rows)
                {
                    list.Add(new
                    {
                        KindName = TypeUtil.ObjectToString(dataRow["KindName"]),
                        Score = TypeUtil.ObjectToDecimal(dataRow["Score"]).ToString("0.00"),
                        Time = now.ToString("yyyy-MM-dd") + "至" + now2.ToString("yyyy-MM-dd")
                    });
                }
            }
            return "{ \"Rows\": " + JsonHelper.SerializeObject(list) + " }";
        }

        public string AccountScoreList(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int num = TypeUtil.ObjectToInt(GameRequest.GetFormString("sType"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
            System.DateTime now = System.DateTime.Now;
            System.DateTime now2 = System.DateTime.Now;
            System.DateTime.TryParse(formString, out now);
            System.DateTime.TryParse(formString2, out now2);
            dictionary.Add("LogonAgentID ", agentID);
            dictionary.Add("BeginTime", now.ToString("yyyy-MM-dd 00:00:00"));
            dictionary.Add("EndTime", now2.ToString("yyyy-MM-dd 23:59:59"));
            dictionary.Add("QueryType", num);
            dictionary.Add("QueryWhere", safeSQL);
            dictionary.Add("DescOrAsc", 0);
            dictionary.Add("PageSize", int2);
            dictionary.Add("PageIndex", @int);
            PagerSet pagerSet = FacadeManage.aideRecordFacade.QueryPlayerWinLost(dictionary);
            System.Collections.Generic.List<object> list = new System.Collections.Generic.List<object>();
            if (pagerSet != null && pagerSet.PageSet != null && pagerSet.PageSet.Tables.Count > 0)
            {
                foreach (System.Data.DataRow dataRow in pagerSet.PageSet.Tables[0].Rows)
                {
                    list.Add(new
                    {
                        UserID = TypeUtil.ObjectToInt(dataRow["UserID"]),
                        Accounts = TypeUtil.ObjectToString(dataRow["Accounts"]),
                        NickName = TypeUtil.ObjectToString(dataRow["NickName"]),
                        AgentAcc = TypeUtil.ObjectToString(dataRow["AgentAcc"]),
                        Score = TypeUtil.ObjectToDecimal(dataRow["Score"]).ToString("0.00"),
                        Time = now.ToString("yyyy-MM-dd") + "至" + now2.ToString("yyyy-MM-dd")
                    });
                }
            }
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list),
				", \"Total\": ",
				pagerSet.RecordCount,
				" }"
			});
        }

        public string GameRecord(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int num = TypeUtil.ObjectToInt(GameRequest.GetFormString("sType"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            if (agentID > 0)
            {
                stringBuilder.AppendFormat(" AND ParentID={0} ", agentID);
            }
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND InsertTime > '{0}'", System.Convert.ToDateTime(formString));
            }
            if (formString2 != "")
            {
                stringBuilder.AppendFormat(" AND InsertTime <= '{0}'", System.Convert.ToDateTime(formString2).AddDays(1.0));
            }
            if (safeSQL != "")
            {
                switch (num)
                {
                    case 1:
                        stringBuilder.AppendFormat(" AND Accounts='{0}' ", safeSQL);
                        break;

                    case 2:
                        if (TypeUtil.ObjectToInt(safeSQL) <= 0)
                        {
                            return "{\"error\":1,\"msg\":\"游戏ID格式错误！\"}";
                        }
                        stringBuilder.AppendFormat(" AND GameID={0}", safeSQL);
                        break;
                }
            }
            string orderby = "Order BY InsertTime DESC";
            PagerSet list = FacadeManage.aideTreasureFacade.GetList("RYAgentDB.dbo.View_PlayGameInfoZj", @int, int2, stringBuilder.ToString(), orderby);
            string sql = "Select Sum(Score) AS SumWinScore, Sum(Revenue) AS SumRevenue From RYAgentDB.dbo.View_PlayGameInfoZj" + stringBuilder.ToString();
            System.Data.DataSet dataSetBySql = FacadeManage.aideTreasureFacade.GetDataSetBySql(sql);
            decimal num2 = 0m;
            decimal num3 = 0m;
            if (dataSetBySql.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dataRow = dataSetBySql.Tables[0].Rows[0];
                num2 = System.Convert.ToDecimal(dataRow["SumWinScore"]);
                num3 = System.Convert.ToDecimal(dataRow["SumRevenue"]);
            }
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num2,
				",\"Sum1\":",
				num3,
				" }"
			});
        }

        public string PlayBalance(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            int num = TypeUtil.ObjectToInt(GameRequest.GetFormString("sType"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            if (agentID > 0)
            {
                stringBuilder.AppendFormat(" AND ParentID={0} ", agentID);
            }
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND ApplyDate > '{0}'", System.Convert.ToDateTime(formString));
            }
            if (formString2 != "")
            {
                stringBuilder.AppendFormat(" AND ApplyDate <= '{0}'", System.Convert.ToDateTime(formString2).AddDays(1.0));
            }
            if (safeSQL != "")
            {
                switch (num)
                {
                    case 1:
                        stringBuilder.AppendFormat(" AND Accounts='{0}' ", safeSQL);
                        break;

                    case 2:
                        if (TypeUtil.ObjectToInt(safeSQL) <= 0)
                        {
                            return "{\"error\":1,\"msg\":\"游戏ID格式错误！\"}";
                        }
                        stringBuilder.AppendFormat(" AND GameID={0}", safeSQL);
                        break;

                    case 3:
                        stringBuilder.AppendFormat(" AND OrderID='{0}'", safeSQL);
                        break;
                }
            }
            PagerSet list = FacadeManage.aideAccountsFacade.GetList("RYAgentDB.dbo.View_ApplyOrderZj", @int, int2, stringBuilder.ToString(), "Order BY ApplyDate DESC");
            string sql = "Select Sum(SellScore) AS SumSellScore From RYAgentDB.dbo.View_ApplyOrderZj" + stringBuilder.ToString();
            System.Data.DataSet dataSetBySql = FacadeManage.aideAccountsFacade.GetDataSetBySql(sql);
            decimal num2 = 0m;
            if (dataSetBySql.Tables[0].Rows.Count > 0)
            {
                System.Data.DataRow dataRow = dataSetBySql.Tables[0].Rows[0];
                num2 = System.Convert.ToDecimal(dataRow["SumSellScore"]);
            }
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num2,
				" }"
			});
        }

        public string AgentReport(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            if (!TypeUtil.IsHasRight("baobiao", agentInfoFromCookie.QueryRight, 256, agentInfoFromCookie.IsClient))
            {
                return "{\"error\":1,\"msg\":\"你没有权限！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            System.Collections.Generic.Dictionary<string, object> dictionary = new System.Collections.Generic.Dictionary<string, object>();
            System.DateTime now = System.DateTime.Now;
            System.DateTime now2 = System.DateTime.Now;
            System.DateTime.TryParse(formString, out now);
            System.DateTime.TryParse(formString2, out now2);
            dictionary.Add("dwAgentID ", agentID);
            dictionary.Add("BeginTime", now.ToString("yyyy-MM-dd"));
            dictionary.Add("EndTime", now2.ToString("yyyy-MM-dd"));
            Message agentQueryInfo = FacadeManage.aideRecordFacade.getAgentQueryInfo(dictionary);
            if (agentQueryInfo.Success)
            {
                System.Data.DataSet dataSet = agentQueryInfo.EntityList[0] as System.Data.DataSet;
                System.Data.DataTable dataTable = dataSet.Tables[0];
                return string.Concat(new object[]
				{
					"{ \"Rows\": ",
					JsonHelper.SerializeObject(dataTable),
					", \"Total\": ",
					dataTable.Rows.Count,
					"}"
				});
            }
            return "{\"error\":1,\"msg\":\"" + agentQueryInfo.Content + "\"}";
        }

        public string GetPayRate(HttpContext context)
        {
            if (HttpRuntime.Cache["payrate"] == null)
            {
                SystemStatusInfo systemStatusInfo = FacadeManage.aideAccountsFacade.GetSystemStatusInfo("PayRate");
                if (systemStatusInfo != null)
                {
                    CacheHelper.AddCache("payrate", systemStatusInfo.StatusValue);
                }
                else
                {
                    CacheHelper.AddCache("payrate", 1);
                }
            }
            return HttpRuntime.Cache["payrate"].ToString();
        }

        public string PayUnlineRecord(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            string formString = GameRequest.GetFormString("sTime");
            string formString2 = GameRequest.GetFormString("eTime");
            TypeUtil.ObjectToInt(GameRequest.GetFormString("sType"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            new System.Collections.Generic.Dictionary<string, object>();
            System.DateTime now = System.DateTime.Now;
            System.DateTime now2 = System.DateTime.Now;
            System.DateTime.TryParse(formString, out now);
            System.DateTime.TryParse(formString2, out now2);
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE AUShow=1 AND AgentID=" + agentID);
            if (formString != "")
            {
                stringBuilder.AppendFormat(" AND CollectDate >= '{0}'", now);
            }
            if (formString2 != "")
            {
                stringBuilder.AppendFormat(" AND CollectDate < '{0}'", now2.AddDays(1.0));
            }
            if (safeSQL != "")
            {
                stringBuilder.AppendFormat(" AND GameID = {0}", System.Convert.ToInt32(safeSQL));
            }
            PagerSet list = FacadeManage.aideTreasureFacade.GetList("RYAgentDB.dbo.View_OffLineOrderZj", @int, int2, stringBuilder.ToString(), "ORDER BY ID DESC");
            string sql = "SELECT SUM(PayAmount) FROM RYAgentDB.dbo.View_OffLineOrderZj " + stringBuilder.ToString();
            decimal num = System.Convert.ToDecimal(FacadeManage.aideTreasureFacade.GetScalarBySql(sql));
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				",\"Sum\":",
				num,
				" }"
			});
        }

        public string GetOnlinePlayer(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int arg_15_0 = agentInfoFromCookie.AgentID;
            string safeSQL = FiltUtil.GetSafeSQL(GameRequest.GetFormString("keyword"));
            int @int = GameRequest.GetInt("pageindex", 1);
            int int2 = GameRequest.GetInt("pagesize", 30);
            string result;
            try
            {
                RequestMessage requestMessage = new RequestMessage(2);
                string text = requestMessage.Post();
                if (text.Contains("["))
                {
                    System.Collections.Generic.List<UserOnline> list = JsonHelper.DeserializeJsonToList<UserOnline>(text);
                    if (list != null && list.Count > 0)
                    {
                        string arg = string.Join<int>(",", (
                            from q in list
                            select q.UserID).ToArray<int>());
                        System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("WHERE AgentName='" + agentInfoFromCookie.AgentAcc + "'");
                        if (!string.IsNullOrWhiteSpace(safeSQL))
                        {
                            int num = 0;
                            if (int.TryParse(safeSQL, out num))
                            {
                                stringBuilder.AppendFormat(" and GameID={0}", num);
                            }
                            else
                            {
                                stringBuilder.AppendFormat(" and Accounts='{0}'", safeSQL);
                            }
                        }
                        stringBuilder.AppendFormat(" and UserID in({0})", arg);
                        PagerSet list2 = FacadeManage.aideAccountsFacade.GetList("View_UserOnline", @int, int2, stringBuilder.ToString(), "ORDER BY TotalScore DESC");
                        result = string.Concat(new object[]
						{
							"{ \"Rows\": ",
							JsonHelper.SerializeObject(list2.PageSet.Tables[0]),
							", \"Total\": ",
							list2.RecordCount,
							" }"
						});
                        return result;
                    }
                }
                result = "{ \"Rows\": \"\", \"Total\": 0}";
            }
            catch (System.Exception)
            {
                result = "{\"error\":-3,\"msg\":\"服务器异常！\"}";
            }
            return result;
        }

        public string GetGameList(HttpContext context)
        {
            System.Data.DataTable dataTable = new System.Data.DataTable();
            Cache cache = HttpRuntime.Cache;
            if (cache["GameList"] == null)
            {
                dataTable = FacadeManage.aidePlatformFacade.GameList();
                CacheHelper.AddCache("GameList", dataTable);
            }
            else
            {
                dataTable = (cache["GameList"] as System.Data.DataTable);
            }
            return JsonHelper.SerializeObject(dataTable);
        }

        public string GetRoomList(HttpContext context)
        {
            int num = System.Convert.ToInt32(context.Request["kid"]);
            System.Data.DataTable dataTable = new System.Data.DataTable();
            if (num == 0)
            {
                Cache cache = HttpRuntime.Cache;
                if (cache["RoomList"] == null)
                {
                    dataTable = FacadeManage.aidePlatformFacade.GetRoomList(num);
                    CacheHelper.AddCache("RoomList", dataTable);
                }
                else
                {
                    dataTable = (cache["RoomList"] as System.Data.DataTable);
                }
            }
            else
            {
                dataTable = FacadeManage.aidePlatformFacade.GetRoomList(num);
            }
            return JsonHelper.SerializeObject(dataTable);
        }

        public string GetReportList(HttpContext context)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return "{\"error\":0,\"msg\":\"登录超时，请重新登录！\"}";
            }
            int agentID = agentInfoFromCookie.AgentID;
            int @int = GameRequest.GetInt("pageIndex", 1);
            int int2 = GameRequest.GetInt("pageSize", 10);
            string orderby = "Order BY LastCountDate DESC";
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(" WHERE 1=1");
            if (agentID > 0)
            {
                stringBuilder.AppendFormat(" AND AgentID={0} ", agentID);
            }
            PagerSet list = FacadeManage.aideTreasureFacade.GetList("RYAgentDB.dbo.View_FillAgentRpt", @int, int2, stringBuilder.ToString(), orderby);
            return string.Concat(new object[]
			{
				"{ \"Rows\": ",
				JsonHelper.SerializeObject(list.PageSet.Tables[0]),
				", \"Total\": ",
				list.RecordCount,
				" }"
			});
        }

        public string UpdateState(HttpContext context)
        {
            if (AdminCookie.GetAgentInfoFromCookie() == null)
            {
                return "-1";
            }
            int formInt = GameRequest.GetFormInt("ID", 0);
            if (formInt <= 0)
            {
                return "验证失败，输入错误";
            }
            string result = "";
            bool flag = FacadeManage.aideAccountsFacade.UpdateState(formInt, 3, out result);
            if (flag)
            {
                return "1";
            }
            return result;
        }

        public string GetAccounts(HttpContext context)
        {
            if (AdminCookie.GetAgentInfoFromCookie() == null)
            {
                return "请先登录";
            }
            int formInt = GameRequest.GetFormInt("gameId", 0);
            if (formInt <= 0)
            {
                return "ID错误";
            }
            return FacadeManage.aideAccountsFacade.GetAccountsByGameID(formInt);
        }

        public string GetGameChart(HttpContext content)
        {
            AgentInfo agentInfoFromCookie = AdminCookie.GetAgentInfoFromCookie();
            if (agentInfoFromCookie == null)
            {
                return JsonHelper.SerializeObject(new
                {
                    code = 1,
                    msg = "登录超时，请重新登录！"
                });
            }
            int num = TypeUtil.ObjectToInt(content.Request["kindId"]);
            if (num <= 0)
            {
                return JsonHelper.SerializeObject(new
                {
                    code = 2,
                    msg = "请选择游戏"
                });
            }
            System.DateTime dateTime = TypeUtil.StringToDateTime(content.Request["sTime"]);
            System.DateTime dateTime2 = TypeUtil.StringToDateTime(content.Request["eTime"]).AddDays(1.0);
            int num2 = System.Convert.ToInt32((dateTime2 - dateTime).TotalDays);
            if (num2 < 7)
            {
                return JsonHelper.SerializeObject(new
                {
                    code = 3,
                    msg = "起止时间相差不能少于一周！"
                });
            }
            if (num2 > 31)
            {
                return JsonHelper.SerializeObject(new
                {
                    code = 3,
                    msg = "起止时间相差不能大于一个月！"
                });
            }
            System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
            System.Collections.Generic.List<string> list2 = new System.Collections.Generic.List<string>();
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendFormat(" WHERE KindId={0}", num);
            stringBuilder.AppendFormat(" AND AgentID={0}", agentInfoFromCookie.AgentID);
            stringBuilder.AppendFormat(" AND InsertTime>='{0}'", dateTime);
            stringBuilder.AppendFormat(" AND InsertTime<='{0}'", dateTime2);
            string sql = "SELECT InsertTime,UserNum FROM View_AgentRoommActive" + stringBuilder.ToString();
            System.Data.DataTable dataTable = FacadeManage.aideTreasureFacade.GetDataSetBySql(sql).Tables[0];
            int num3 = num2 / 7;
            for (int i = 0; i < 7; i++)
            {
                string text;
                if (i == 6)
                {
                    text = dateTime2.AddDays(-1.0).ToString("yyyy-MM-dd");
                }
                else
                {
                    text = dateTime.AddDays((double)(i * num3)).ToString("yyyy-MM-dd");
                }
                System.Data.DataRow[] array = dataTable.Select("InsertTime='" + text + "'");
                int num4;
                if (array.Length != 0)
                {
                    num4 = System.Convert.ToInt32(array[0]["UserNum"]);
                }
                else
                {
                    num4 = 0;
                }
                list.Add(text);
                list2.Add(num4.ToString());
            }
            return JsonHelper.SerializeObject(new
            {
                x = list,
                y = list2
            });
        }
    }
}