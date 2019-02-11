using Game.Data.Factory;
using Game.Entity.Accounts;
using Game.Facade.Tools;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Xml.Linq;
namespace Game.Facade
{
	public class AccountsFacade
	{
		private IAccountsDataProvider aideAccountsData;
		public AccountsFacade()
		{
			this.aideAccountsData = ClassFactory.IAccountsDataProvider();
		}
		public PagerSet GetAccountsList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetAccountsList(pageIndex, pageSize, condition, orderby);
		}
		public void DongjieAccount(string sqlQuery)
		{
			this.aideAccountsData.DongjieAccount(sqlQuery);
		}
		public void SetTeshu(int type, string sqlQuery)
		{
			string sql = "UPDATE AccountsInfo SET UserType=" + type + sqlQuery;
			this.aideAccountsData.ExecuteSql(sql);
		}
		public void JieDongAccount(string sqlQuery)
		{
			this.aideAccountsData.JieDongAccount(sqlQuery);
		}
		public void SettingAndroid(string sqlQuery)
		{
			this.aideAccountsData.SettingAndroid(sqlQuery);
		}
		public void CancleAndroid(string sqlQuery)
		{
			this.aideAccountsData.CancleAndroid(sqlQuery);
		}
		public AccountsInfo GetAccountInfoByUserID(int userID)
		{
			return this.aideAccountsData.GetAccountInfoByUserID(userID);
		}
		public AccountsInfo GetAccountInfoByAccount(string account)
		{
			return this.aideAccountsData.GetAccountInfoByAccount(account);
		}
		public AccountsInfo GetAccountInfoByNickname(string nickname)
		{
			return this.aideAccountsData.GetAccountInfoByNickname(nickname);
		}
		public AccountsInfo GetAccountInfoByGameID(int gameID)
		{
			return this.aideAccountsData.GetAccountInfoByGameID(gameID);
		}
		public string GetAccountsByGameID(int gameId)
		{
			return this.aideAccountsData.GetAccountsByGameID(gameId);
		}
		public string GetAccountByUserID(int userID)
		{
			return this.aideAccountsData.GetAccountByUserID(userID);
		}
		public int GetExperienceByUserID(int userID)
		{
			return this.aideAccountsData.GetExperienceByUserID(userID);
		}
		public Message UpdateAccount(AccountsInfo account, int masterID, string clientIP)
		{
			return this.aideAccountsData.UpdateAccount(account, masterID, clientIP);
		}
		public Message AddAccount(AccountsInfo account, IndividualDatum datum)
		{
			return this.aideAccountsData.AddAccount(account, datum);
		}
		public bool AddUserMedal(int userId, int medal)
		{
			return this.aideAccountsData.AddUserMedal(userId, medal);
		}
		public bool UpdateUserPassword(AccountsInfo accountsInfo)
		{
			return this.aideAccountsData.UpdateUserPassword(accountsInfo);
		}
		public DataTable GetUserDetails(int uid)
		{
			string text = "SELECT u.UserID,GameID,Accounts,,Compellation,Score,InsureScore";
			text = text + " FROM AccountsInfo u LEFT JOIN THTreasureDB.dbo.GameScoreInfo s ON u.UserID=s.UserID WHERE u.UserID=" + uid;
			return this.aideAccountsData.GetDataSetBySql(text).Tables[0];
		}
		public DataTable GetUserOnline(string ids)
		{
			string sql = "SELECT * FROM View_UserOnline WHERE UserID IN(" + ids + ")";
			return this.aideAccountsData.GetDataSetBySql(sql).Tables[0];
		}
		public IndividualDatum GetAccountDetailByUserID(int userID)
		{
			return this.aideAccountsData.GetAccountDetailByUserID(userID);
		}
		public Message InsertAccountDetail(IndividualDatum accountDetail)
		{
			this.aideAccountsData.InsertAccountDetail(accountDetail);
			return new Message(true);
		}
		public Message UpdateAccountDetail(IndividualDatum accountDetail)
		{
			this.aideAccountsData.UpdateAccountDetail(accountDetail);
			return new Message(true);
		}
		public string GetUserFaceUrl(int faceID, int customID)
		{
			string result = string.Empty;
			if (customID == 0)
			{
				result = string.Format("/gamepic/Avatar{0}.png", faceID);
			}
			else
			{
				if (this.GetAccountsFace(customID) == null)
				{
					result = string.Format("/gamepic/Avatar{0}.png", faceID);
				}
				else
				{
					System.Random random = new System.Random();
					double num = random.NextDouble();
					result = string.Format("/Tools/UserFace.ashx?customid={0}&x={1}", customID, num);
				}
			}
			return result;
		}
		public DataSet GetAccountsFaceList(int userId)
		{
			return this.aideAccountsData.GetAccountsFaceList(userId);
		}
		public AccountsFace GetAccountsFace(int customId)
		{
			return this.aideAccountsData.GetAccountsFace(customId);
		}
		public PagerSet GetConfineContentList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetConfineContentList(pageIndex, pageSize, condition, orderby);
		}
		public ConfineContent GetConfineContentByContentID(int contentID)
		{
			return this.aideAccountsData.GetConfineContentByContentID(contentID);
		}
		public Message InsertConfineContent(ConfineContent content)
		{
			this.aideAccountsData.InsertConfineContent(content);
			return new Message(true);
		}
		public Message UpdateConfineContent(ConfineContent content)
		{
			this.aideAccountsData.UpdateConfineContent(content);
			return new Message(true);
		}
		public void DeleteConfineContentByContentID(int contentID)
		{
			this.aideAccountsData.DeleteConfineContentByContentID(contentID);
		}
		public void DeleteConfineContent(string sqlQuery)
		{
			this.aideAccountsData.DeleteConfineContent(sqlQuery);
		}
		public bool IsExitStringInConfineContent(string str)
		{
			return this.aideAccountsData.IsExitStringInConfineContent(str);
		}
		public AccountsProtect GetAccountsProtectByPID(int pid)
		{
			return this.aideAccountsData.GetAccountsProtectByPID(pid);
		}
		public AccountsProtect GetAccountsProtectByUserID(int uid)
		{
			return this.aideAccountsData.GetAccountsProtectByUserID(uid);
		}
		public Message UpdateAccountsProtect(AccountsProtect accountProtect)
		{
			this.aideAccountsData.UpdateAccountsProtect(accountProtect);
			return new Message(true);
		}
		public void DeleteAccountsProtect(int pid)
		{
			this.aideAccountsData.DeleteAccountsProtect(pid);
		}
		public void DeleteAccountsProtect(string sqlQuery)
		{
			this.aideAccountsData.DeleteAccountsProtect(sqlQuery);
		}
		public DataSet GetReserveIdentifierList()
		{
			return this.aideAccountsData.GetReserveIdentifierList();
		}
		public PagerSet GetConfineAddressList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetConfineAddressList(pageIndex, pageSize, condition, orderby);
		}
		public ConfineAddress GetConfineAddressByAddress(string strAddress)
		{
			return this.aideAccountsData.GetConfineAddressByAddress(strAddress);
		}
		public Message InsertConfineAddress(ConfineAddress address)
		{
			this.aideAccountsData.InsertConfineAddress(address);
			return new Message(true);
		}
		public Message UpdateConfineAddress(ConfineAddress address)
		{
			this.aideAccountsData.UpdateConfineAddress(address);
			return new Message(true);
		}
		public void DeleteConfineAddressByAddress(string strAddress)
		{
			this.aideAccountsData.DeleteConfineAddressByAddress(strAddress);
		}
		public void DeleteConfineAddress(string sqlQuery)
		{
			this.aideAccountsData.DeleteConfineAddress(sqlQuery);
		}
		public DataSet GetIPRegisterTop100()
		{
			return this.aideAccountsData.GetIPRegisterTop100();
		}
		public void BatchInsertConfineAddress(string ipList)
		{
			this.aideAccountsData.BatchInsertConfineAddress(ipList);
		}
		public PagerSet GetConfineMachineList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetConfineMachineList(pageIndex, pageSize, condition, orderby);
		}
		public ConfineMachine GetConfineMachineBySerial(string strSerial)
		{
			return this.aideAccountsData.GetConfineMachineBySerial(strSerial);
		}
		public Message InsertConfineMachine(ConfineMachine machine)
		{
			this.aideAccountsData.InsertConfineMachine(machine);
			return new Message(true);
		}
		public Message UpdateConfineMachine(ConfineMachine machine)
		{
			this.aideAccountsData.UpdateConfineMachine(machine);
			return new Message(true);
		}
		public void DeleteConfineMachineBySerial(string strSerial)
		{
			this.aideAccountsData.DeleteConfineMachineBySerial(strSerial);
		}
		public void DeleteConfineMachine(string sqlQuery)
		{
			this.aideAccountsData.DeleteConfineMachine(sqlQuery);
		}
		public DataSet GetMachineRegisterTop100()
		{
			return this.aideAccountsData.GetMachineRegisterTop100();
		}
		public void BatchInsertConfineMachine(string machineList)
		{
			this.aideAccountsData.BatchInsertConfineMachine(machineList);
		}
		public DataTable SystemCount()
		{
			return this.aideAccountsData.SystemCount();
		}
		public PagerSet GetSystemStatusInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetSystemStatusInfoList(pageIndex, pageSize, condition, orderby);
		}
		public SystemStatusInfo GetSystemStatusInfo(string statusName)
		{
			return this.aideAccountsData.GetSystemStatusInfo(statusName);
		}
		public Message UpdateSystemStatusInfo(SystemStatusInfo systemStatusInfo)
		{
			this.aideAccountsData.UpdateSystemStatusInfo(systemStatusInfo);
			return new Message(true);
		}
		public int UpdateSystemStatusInfo(string key, decimal value)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE SystemStatusInfo SET ").AppendFormat("StatusValue={0} ", value).AppendFormat("WHERE StatusName='{0}'", key);
			return this.aideAccountsData.ExecuteSql(stringBuilder.ToString());
		}
		public DataSet GetRegUserByDays(string startDate, string endDate)
		{
			return this.aideAccountsData.GetRegUserByDays(startDate, endDate);
		}
		public DataSet GetRegUserByHours(string startDate, string endDate)
		{
			return this.aideAccountsData.GetRegUserByHours(startDate, endDate);
		}
		public DataSet GetRegUserByMonth()
		{
			return this.aideAccountsData.GetRegUserByMonth();
		}
		public DataSet GetUsersStat()
		{
			return this.aideAccountsData.GetUsersStat();
		}
		public DataSet GetUsersNumber()
		{
			return this.aideAccountsData.GetUsersNumber();
		}
		public Message AppStatLogon(string accounts, string logonPass, string machineID)
		{
			return this.aideAccountsData.AppStatLogon(accounts, logonPass, machineID);
		}
		public Message AppStatUserActive(string accounts, string logonPass, string machineID)
		{
			return this.aideAccountsData.AppStatUserActive(accounts, logonPass, machineID);
		}
		public Message AppStatUserMember(string accounts, string logonPass, string machineID)
		{
			return this.aideAccountsData.AppStatUserMember(accounts, logonPass, machineID);
		}
		public Message AppGetLogonData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideAccountsData.AppGetLogonData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public Message AppGetRegData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideAccountsData.AppGetRegData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public ControlConfig GetControlConfig()
		{
			return this.aideAccountsData.GetControlConfig();
		}
		public void UpdateControlConfig(ControlConfig model)
		{
			this.aideAccountsData.UpdateControlConfig(model);
		}
		public void DeleteAccountsControl(string where)
		{
			this.aideAccountsData.DeleteAccountsControl(where);
		}
		public void AddAccountsControl(AccountsControl model)
		{
			this.aideAccountsData.AddAccountsControl(model);
		}
		public void UpdateAccountsControl(AccountsControl model)
		{
			this.aideAccountsData.UpdateAccountsControl(model);
		}
		public AccountsControl GetAccountsControl(int id)
		{
			return this.aideAccountsData.GetAccountsControl(id);
		}
		public void DongjieAgent(string sqlQuery)
		{
			this.aideAccountsData.DongjieAgent(sqlQuery);
		}
		public void JieDongAgent(string sqlQuery)
		{
			this.aideAccountsData.JieDongAgent(sqlQuery);
		}
		public AccountsAgent GetAccountAgentByUserID(int userID)
		{
			return this.aideAccountsData.GetAccountAgentByUserID(userID);
		}
		public AccountsAgent GetAccountAgentByDomain(string domain)
		{
			return this.aideAccountsData.GetAccountAgentByDomain(domain);
		}
		public Message AddAgent(AccountsAgent agent)
		{
			return this.aideAccountsData.AddAgent(agent);
		}
		public bool UpdateAgent(AccountsAgent agent)
		{
			return this.aideAccountsData.UpdateAgent(agent);
		}
		public int GetAgentChildCount(int userID)
		{
			return this.aideAccountsData.GetAgentChildCount(userID);
		}
		public AccountsAgentGame GetAccountsAgentGameInfo(int id)
		{
			return this.aideAccountsData.GetAccountsAgentGameInfo(id);
		}
		public Message InsertAccountsAgentGame(AccountsAgentGame model)
		{
			Message result;
			try
			{
				this.aideAccountsData.InsertAccountsAgentGame(model);
				result = new Message(true);
			}
			catch (System.Exception ex)
			{
				result = new Message(false, ex.Message);
			}
			return result;
		}
		public Message UpdateAccountsAgentGame(AccountsAgentGame model)
		{
			Message result;
			try
			{
				this.aideAccountsData.UpdateAccountsAgentGame(model);
				result = new Message(true);
			}
			catch (System.Exception ex)
			{
				result = new Message(false, ex.Message);
			}
			return result;
		}
		public Message DeleteAccountsAgentGame(string sqlQuery)
		{
			Message result;
			try
			{
				this.aideAccountsData.DeleteAccountsAgentGame(sqlQuery);
				result = new Message(true);
			}
			catch (System.Exception ex)
			{
				result = new Message(false, ex.Message);
			}
			return result;
		}
		public DataTable GetPushConfig()
		{
			string sql = "SELECT AppKey,AppSecret FROM RyAgentDB.dbo.T_AgentIsIOS WHERE AppKey<>'' AND AppSecret<>''";
			return this.aideAccountsData.GetDataSetBySql(sql).Tables[0];
		}
		public DataSet GetMemberPropertyList()
		{
			return this.aideAccountsData.GetMemberPropertyList();
		}
		public MemberProperty GetMemberProperty(int memberOrder)
		{
			return this.aideAccountsData.GetMemberProperty(memberOrder);
		}
		public void UpdateMemberType(MemberProperty memberType)
		{
			this.aideAccountsData.UpdateMemberType(memberType);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideAccountsData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby, string[] fields)
		{
			return this.aideAccountsData.GetList(tableName, pageIndex, pageSize, condition, orderby, fields);
		}
		public int ExecuteSql(string sql)
		{
			return this.aideAccountsData.ExecuteSql(sql);
		}
		public DataSet GetDataSetBySql(string sql)
		{
			return this.aideAccountsData.GetDataSetBySql(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return this.aideAccountsData.GetScalarBySql(sql);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			return this.aideAccountsData.ExcuteByProce(proceName, dir);
		}
		public decimal GetDecSum(string sql)
		{
			return this.aideAccountsData.GetDecSum(sql);
		}
		public int GetIntSum(string sql)
		{
			return this.aideAccountsData.GetIntSum(sql);
		}
		public long GetLongSum(string sql)
		{
			return this.aideAccountsData.GetLongSum(sql);
		}
		public CashSetting PlayerCashInfo()
		{
			return this.aideAccountsData.PlayerCashInfo();
		}
		public void UpdatePlayerSetting(CashSetting model)
		{
			this.aideAccountsData.UpdatePlayerSetting(model);
		}
		public int TradeOper(int state, int id)
		{
			return this.aideAccountsData.TradeOper(state, id);
		}
		public decimal SumPlayerDraw(string sWhere)
		{
			return this.aideAccountsData.SumPlayerDraw(sWhere);
		}
		public int GetUndoApplyOrderCount()
		{
			return this.aideAccountsData.GetUndoApplyOrderCount();
		}
		public int GetUndoAgentDrawCount()
		{
			return this.aideAccountsData.GetUndoAgentDrawCount();
		}
		public string queryXml(string xmlContent, out int status)
		{
			System.IO.MemoryStream stream = new System.IO.MemoryStream(System.Text.Encoding.UTF8.GetBytes(xmlContent));
			XElement root = XDocument.Load(stream).Root;
			if (root.Element("response").Element("is_success").Value.ToUpper() == "TRUE")
			{
				XElement xElement = root.Element("response").Element("remit_status");
				status = System.Convert.ToInt32(xElement.Value);
				return xElement.Value;
			}
			status = 0;
			return "0";
		}
		public void UpdateAgentBaseURL(AgentStatusInfo model)
		{
			this.aideAccountsData.UpdateAgentBaseURL(model);
		}
		public Message RegAegnt(AgentInfo model)
		{
			return this.aideAccountsData.RegAegnt(model);
		}
		public Message AgentDraw(AgentInfo agent)
		{
			return this.aideAccountsData.AgentDraw(agent);
		}
		public Message AgentRecharge(AgentInfo model, byte opType = 0)
		{
			return this.aideAccountsData.AgentRecharge(model, opType);
		}
		public double SumAgentPlayerPay(string sWhere)
		{
			return this.aideAccountsData.SumAgentPlayerPay(sWhere);
		}
		public decimal SumPayOrder(string sWhere)
		{
			string sql = "SELECT SUM(Score) FROM RYAgentDB..T_AgentFillOrder " + sWhere;
			string scalarBySql = this.aideAccountsData.GetScalarBySql(sql);
			if (scalarBySql == "")
			{
				return 0m;
			}
			return System.Convert.ToDecimal(scalarBySql);
		}
		public void UpdateAegntBank(AgentInfo model)
		{
			this.aideAccountsData.UpdateAegntBank(model);
		}
		public string UpdateAegntPwd(AgentInfo model)
		{
			this.aideAccountsData.UpdateAegntPwd(model);
			return "1";
		}
		public Message AgentUserRecharge(AgentInfo model)
		{
			return this.aideAccountsData.AgentUserRecharge(model);
		}
		public Message AgentLogonNew(AgentInfo user)
		{
			Message message = this.aideAccountsData.AgentLogonNew(user);
			if (message.Success)
			{
				AgentInfo agentInfo = message.EntityList[0] as AgentInfo;
				agentInfo.Pwd = user.Pwd;
				AdminCookie.SetAgentCookieNew(agentInfo);
			}
			return message;
		}
		public DataSet AgentScore(int aid, byte type = 0)
		{
			return this.aideAccountsData.AgentScore(aid, type);
		}
		public AgentStatusInfo AgentBaseURL()
		{
			return this.aideAccountsData.AgentBaseURL();
		}
		public double SumAgentDraw(string sWhere)
		{
			string sql = "SELECT SUM(SellScore) FROM RYAgentDB..View_AgentDraw " + sWhere;
			string scalarBySql = this.aideAccountsData.GetScalarBySql(sql);
			if (string.IsNullOrEmpty(scalarBySql))
			{
				return 0.0;
			}
			return System.Convert.ToDouble(scalarBySql);
		}
		public DataTable AgentCashInfo()
		{
			string sql = "SELECT TOP 1 IsOpen,WeekOpenDay,SOpenTime,EOpenTime, DailyApplyTimes, BalancePrice,MinBalance,CounterFee,MinCounterFee,DiffAgentRate,MaxAgentRate FROM RYAgentDB..T_Acc_AgentStatusInfo";
			return this.aideAccountsData.GetDataSetBySql(sql).Tables[0];
		}
		public void UpdateAgentSetting(AgentSetting model)
		{
			this.aideAccountsData.UpdateAgentSetting(model);
		}
		public AgentInfo GetAgentDetail(int aid)
		{
			return this.aideAccountsData.GetAgentDetail(aid);
		}
		public Message UpdateAegnt(AgentInfo model)
		{
			return this.aideAccountsData.UpdateAegnt(model);
		}
		public DataTable AgentLogType()
		{
			string sql = "select * from RYAgentDB..T_Rec_AgentLogType";
			return this.aideAccountsData.GetDataSetBySql(sql).Tables[0];
		}
		public bool SetRate(int id, int fillRate, int drawFee, int fillRevRate, out string msg)
		{
			DataTable dataTable = this.aideAccountsData.GetDataSetBySql("SELECT CheckStatus FROM RYAgentDB.dbo.T_FillAgentRpt WHERE ID=" + id).Tables[0];
			if (dataTable.Rows.Count <= 0)
			{
				msg = "该信息不存在";
				return false;
			}
			short num = System.Convert.ToInt16(dataTable.Rows[0][0]);
			if (num == 3)
			{
				msg = "此信息双方都已确认，无法修改";
				return false;
			}
			string sql = string.Concat(new object[]
			{
				"UPDATE RYAgentDB.dbo.T_FillAgentRpt SET FillRate=",
				fillRate,
				",DrawFee=",
				drawFee,
				",FillRevRate=",
				fillRevRate,
				" WHERE ID=",
				id
			});
			if (this.aideAccountsData.ExecuteSql(sql) > 0)
			{
				msg = "设置成功";
				return true;
			}
			msg = "系统错误";
			return false;
		}
		public bool UpdateState(int id, int state, out string msg)
		{
			DataTable dataTable = this.aideAccountsData.GetDataSetBySql("SELECT CheckStatus,FillRevRate FROM RYAgentDB.dbo.T_FillAgentRpt WHERE ID=" + id).Tables[0];
			if (dataTable.Rows.Count <= 0)
			{
				msg = "该信息不存在";
				return false;
			}
			short num = System.Convert.ToInt16(dataTable.Rows[0][0]);
			if (System.Convert.ToInt16(dataTable.Rows[0][1]) == 0)
			{
				msg = "提成比例还未设置，确认失败";
				return false;
			}
			if (state == 2 && num != 1)
			{
				msg = "状态不为等待运营商确认，确认失败";
				return false;
			}
			if (state == 3 && num != 2)
			{
				msg = "状态不为等待运营商确认，确认失败";
				return false;
			}
			string sql = string.Concat(new object[]
			{
				"UPDATE RYAgentDB.dbo.T_FillAgentRpt SET CheckStatus=",
				state,
				" WHERE ID=",
				id
			});
			if (this.aideAccountsData.ExecuteSql(sql) > 0)
			{
				msg = "确认成功";
				return true;
			}
			msg = "系统错误";
			return false;
		}
		public AUFillConfig GetFillConfig(int aid)
		{
			string sql = "SELECT [AgentID],[UserAllAmt],[BeginTime] ,[EndTime],[Amount],[Times] FROM RYAgentDB.dbo.T_AUFillConfig WHERE AgentID=" + aid;
			DataTable dataTable = this.aideAccountsData.GetDataSetBySql(sql).Tables[0];
			if (dataTable.Rows.Count > 0)
			{
				ModelHandler<AUFillConfig> modelHandler = new ModelHandler<AUFillConfig>();
				return modelHandler.FillModel(dataTable.Rows[0]);
			}
			return null;
		}
		public bool UpdateCheckState(int id, int status, string admin, out string msg)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE RYAgentDB.dbo.T_UserAccuseYS SET Status=",
				status,
				",Operator='",
				admin,
				"',OperateDate=GetDate() WHERE Status=0 AND ID=",
				id
			});
			if (this.aideAccountsData.ExecuteSql(sql) > 0)
			{
				if (status == 1)
				{
					msg = "处理成功";
				}
				else
				{
					msg = "拒绝成功";
				}
				return true;
			}
			msg = "系统错误";
			return false;
		}
		public bool UpdateDailiCheckState(int id, int status, string admin, out string msg)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE RYAgentDB.dbo.T_UserApplyYs SET YsStatus=",
				status,
				",Operator='",
				admin,
				"',OperateDate=GetDate() WHERE YsStatus=0 AND ID=",
				id
			});
			if (this.aideAccountsData.ExecuteSql(sql) > 0)
			{
				if (status == 1)
				{
					msg = "处理成功";
				}
				else
				{
					msg = "拒绝成功";
				}
				return true;
			}
			msg = "系统错误";
			return false;
		}
		public DataTable MySpreadInfo(int uid, int dateType)
		{
			return this.aideAccountsData.MySpreadInfo(uid, dateType);
		}
		public DataTable MyOwnSpreadCount(int uid)
		{
			return this.aideAccountsData.MyOwnSpreadCount(uid);
		}
		public Message SpreadBalance(int uid, double balance, string ip)
		{
			return this.aideAccountsData.SpreadBalance(uid, balance, ip);
		}
		public DataTable MySpreadCntInfo(int uid, int type = 0)
		{
			return this.aideAccountsData.MySpreadCntInfo(uid, type);
		}
		public PagerSet QuerySpreadScore(int uid, int type, int recordType, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			return this.aideAccountsData.QuerySpreadScore(uid, type, recordType, bTime, eTime, pageIndex, pageSize);
		}
		public PagerSet QuerySpreadDailyRpt(int uid, string account, int lev, System.DateTime bTime, System.DateTime eTime, int pageIndex, int pageSize)
		{
			return this.aideAccountsData.QuerySpreadDailyRpt(uid, account, lev, bTime, eTime, pageIndex, pageSize);
		}
		public DataTable GetUserGoldException(string sTime, string eTime)
		{
			return this.aideAccountsData.GetUserGoldException(sTime, eTime);
		}
		public void InsertAndroid(AndroidConfigure android)
		{
			this.aideAccountsData.InsertAndroid(android);
		}
		public void UpdateAndroid(AndroidConfigure android)
		{
			this.aideAccountsData.UpdateAndroid(android);
		}
		public void DeleteConfigure(string ids)
		{
			string sql = "DELETE AndroidConfigure WHERE BatchID IN(" + ids + ")";
			this.aideAccountsData.ExecuteSql(sql);
		}
		public int SetSuperHao(string account)
		{
			return this.aideAccountsData.SetSuperHao(account);
		}
		public int QXSuperHao(int UserID)
		{
			return this.aideAccountsData.QXSuperHao(UserID);
		}
		public int QXSuperAccount(string ids)
		{
			string sql = string.Concat(new string[]
			{
				"Update AccountsInfo set UserRight=UserRight&~536870912 WHERE UserID IN(",
				ids,
				");DELETE T_SuperUser WHERE UserID IN(",
				ids,
				")"
			});
			return this.aideAccountsData.ExecuteSql(sql);
		}
		public int GetAgentIDByAccounts(string account)
		{
			return this.aideAccountsData.GetAgentIDByAccounts(account);
		}
		public bool AddIOSConfig(int IsIOSShop, int AgentID, string AgentAcc)
		{
			return this.aideAccountsData.AddIOSConfig(IsIOSShop, AgentID, AgentAcc);
		}
		public bool DelIOSConfig(string AgentID)
		{
			return this.aideAccountsData.DelIOSConfig(AgentID);
		}
		public bool UpdateIOSConfig(int AgentID)
		{
			return this.aideAccountsData.UpdateIOSConfig(AgentID);
		}
		public int AddIOSConfig(int IsIOSShop, int AgentID, string AgentAcc, string AgentName, int VersionNo, int SrcVersionNo, string AppKey, string AppSecret, string AppUrl)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("INSERT INTO RYAgentDB.dbo.T_AgentIsIOS(IsIOSShop,AgentID,AgentAcc,AgentName,VersionNo,SrcVersionNo,AppKey,AppSecret,AppUrl) values({0},{1},'{2}','{3}',{4},{5},'{6}','{7}','{8}')", new object[]
			{
				IsIOSShop,
				AgentID,
				AgentAcc,
				AgentName,
				VersionNo,
				SrcVersionNo,
				AppKey,
				AppSecret,
				AppUrl
			});
			return this.aideAccountsData.ExecuteSql(stringBuilder.ToString());
		}
		public int UpdateIOSConfig(int IsIOSShop, int AgentID, int VersionNo, int SrcVersionNo, string AgentName, string AppKey, string AppSecret, string AppUrl)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("UPDATE RYAgentDB.dbo.T_AgentIsIOS SET IsIOSShop={0},VersionNo={1},SrcVersionNo={2},AgentName='{4}',AppKey='{5}',AppSecret='{6}',AppUrl='{7}' WHERE AgentID={3}", new object[]
			{
				IsIOSShop,
				VersionNo,
				SrcVersionNo,
				AgentID,
				AgentName,
				AppKey,
				AppSecret,
				AppUrl
			});
			return this.aideAccountsData.ExecuteSql(stringBuilder.ToString());
		}
		public System.Collections.Generic.IList<BankCard> GetAllBankCard()
		{
			return this.aideAccountsData.GetAllBankCard();
		}
		public int EditBankCard(BankCard entity)
		{
			return this.aideAccountsData.EditBankCard(entity);
		}
		public BankCard GetBankCardByID(int id)
		{
			return this.aideAccountsData.GetBankCardByID(id);
		}
	}
}
