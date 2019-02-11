using Game.Entity.Record;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class RecordDataProvider : BaseDataProvider, IRecordDataProvider
	{
		private ITableProvider aideRecordAccountsExpendProvider;
		private ITableProvider aideRecordPasswdExpendProvider;
		private ITableProvider aideRecordGrantTreasureProvider;
		private ITableProvider aideRecordGrantMemberProvider;
		private ITableProvider aideRecordGrantExperienceProvider;
		private ITableProvider aideRecordGrantGameScoreProvider;
		private ITableProvider aideRecordGrantClearScoreProvider;
		private ITableProvider aideRecordGrantClearFleeProvider;
		private ITableProvider aideRecordConvertPresentProvider;
		private ITableProvider aideTaskRecordProvider;
		public RecordDataProvider(string connString) : base(connString)
		{
			this.aideRecordAccountsExpendProvider = this.GetTableProvider("RecordAccountsExpend");
			this.aideRecordPasswdExpendProvider = this.GetTableProvider("RecordPasswdExpend");
			this.aideRecordGrantTreasureProvider = this.GetTableProvider("RecordGrantTreasure");
			this.aideRecordGrantMemberProvider = this.GetTableProvider("RecordGrantMember");
			this.aideRecordGrantExperienceProvider = this.GetTableProvider("RecordGrantExperience");
			this.aideRecordGrantGameScoreProvider = this.GetTableProvider("RecordGrantGameScore");
			this.aideRecordGrantClearScoreProvider = this.GetTableProvider("RecordGrantClearScore");
			this.aideRecordGrantClearFleeProvider = this.GetTableProvider("RecordGrantClearFlee");
			this.aideRecordConvertPresentProvider = this.GetTableProvider("RecordConvertPresent");
			this.aideTaskRecordProvider = this.GetTableProvider("RecordTask");
		}
		public PagerSet GetRecordAccountsExpendList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordAccountsExpend", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void InsertRecordAccountsExpend(RecordAccountsExpend actExpend)
		{
			System.Data.DataRow dataRow = this.aideRecordAccountsExpendProvider.NewRow();
			dataRow["ReAccounts"] = actExpend.ReAccounts;
			dataRow["UserID"] = actExpend.UserID;
			dataRow["ClientIP"] = actExpend.ClientIP;
			dataRow["OperMasterID"] = actExpend.OperMasterID;
			dataRow["CollectDate"] = System.DateTime.Now;
			this.aideRecordAccountsExpendProvider.Insert(dataRow);
		}
		public System.Collections.Generic.Dictionary<int, string> GetOldNickNameOrAccountsList(int userId, int typeID)
		{
			string commandText = string.Format("SELECT ReAccounts FROM dbo.RecordAccountsExpend WHERE UserID={0} AND Type={1}", userId, typeID);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(commandText);
			System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
			int num = 1;
			foreach (System.Data.DataRow dataRow in dataSet.Tables[0].Rows)
			{
				string value = dataRow["ReAccounts"].ToString();
				dictionary.Add(num, value);
				num++;
			}
			return dictionary;
		}
		public PagerSet GetRecordPasswdExpendList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordPasswdExpend", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void InsertRecordPasswdExpend(RecordPasswdExpend pwExpend)
		{
			System.Data.DataRow dataRow = this.aideRecordPasswdExpendProvider.NewRow();
			dataRow["ReLogonPasswd"] = pwExpend.ReLogonPasswd;
			dataRow["ReInsurePasswd"] = pwExpend.ReInsurePasswd;
			dataRow["UserID"] = pwExpend.UserID;
			dataRow["ClientIP"] = pwExpend.ClientIP;
			dataRow["OperMasterID"] = pwExpend.OperMasterID;
			dataRow["CollectDate"] = System.DateTime.Now;
			this.aideRecordPasswdExpendProvider.Insert(dataRow);
		}
		public RecordPasswdExpend GetRecordPasswdExpendByRid(int rid)
		{
			string where = string.Format("(NOLOCK) WHERE RecordID= N'{0}'", rid);
			return this.aideRecordPasswdExpendProvider.GetObject<RecordPasswdExpend>(where);
		}
		public bool ConfirmPass(int rid, string password, int type)
		{
			string where = string.Empty;
			if (type == 0)
			{
				where = string.Format("WHERE RecordID={0} AND ReLogonPasswd='{1}'", rid, password);
			}
			else
			{
				where = string.Format("WHERE RecordID={0} AND ReInsurePasswd='{1}'", rid, password);
			}
			int recordsCount = this.aideRecordPasswdExpendProvider.GetRecordsCount(where);
			return recordsCount > 0;
		}
		public System.Collections.Generic.Dictionary<int, string> GetOldLogonPassList(int userId)
		{
			string commandText = string.Format("SELECT ReLogonPasswd,ReInsurePasswd FROM dbo.RecordPasswdExpend WHERE UserID={0}", userId);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(commandText);
			System.Collections.Generic.Dictionary<int, string> dictionary = new System.Collections.Generic.Dictionary<int, string>();
			int num = 1;
			foreach (System.Data.DataRow dataRow in dataSet.Tables[0].Rows)
			{
				string value = dataRow["ReLogonPasswd"].ToString();
				dictionary.Add(num, value);
				num++;
			}
			return dictionary;
		}
		public PagerSet GetRecordGrantTreasureList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantTreasure", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void InsertRecordGrantTreasure(RecordGrantTreasure grantTreasure)
		{
			System.Data.DataRow dataRow = this.aideRecordGrantTreasureProvider.NewRow();
			dataRow["MasterID"] = grantTreasure.MasterID;
			dataRow["CurGold"] = grantTreasure.CurGold;
			dataRow["UserID"] = grantTreasure.UserID;
			dataRow["ClientIP"] = grantTreasure.ClientIP;
			dataRow["AddGold"] = grantTreasure.AddGold;
			dataRow["Reason"] = grantTreasure.Reason;
			dataRow["CollectDate"] = System.DateTime.Now;
			this.aideRecordGrantTreasureProvider.Insert(dataRow);
		}
		public PagerSet GetRecordGrantMemberList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantMember", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void InsertRecordGrantMember(RecordGrantMember grantMember)
		{
			System.Data.DataRow dataRow = this.aideRecordGrantMemberProvider.NewRow();
			dataRow["MasterID"] = grantMember.MasterID;
			dataRow["GrantCardType"] = grantMember.GrantCardType;
			dataRow["UserID"] = grantMember.UserID;
			dataRow["ClientIP"] = grantMember.ClientIP;
			dataRow["MemberDays"] = grantMember.MemberDays;
			dataRow["Reason"] = grantMember.Reason;
			dataRow["CollectDate"] = System.DateTime.Now;
			this.aideRecordGrantMemberProvider.Insert(dataRow);
		}
		public Message GrantMember(int userID, int memberOrder, int days, int masterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			list.Add(base.Database.MakeInParam("MemberOrder", memberOrder));
			list.Add(base.Database.MakeInParam("MemberDays", days));
			list.Add(base.Database.MakeInParam("MasterID", masterID));
			list.Add(base.Database.MakeInParam("Reason", strReason));
			list.Add(base.Database.MakeInParam("ClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_GrantMember", list);
		}
		public PagerSet GetRecordGrantExperienceList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantExperience", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void InsertRecordGrantExperience(RecordGrantExperience grantExperience)
		{
			System.Data.DataRow dataRow = this.aideRecordGrantExperienceProvider.NewRow();
			dataRow["MasterID"] = grantExperience.MasterID;
			dataRow["CurExperience"] = grantExperience.CurExperience;
			dataRow["UserID"] = grantExperience.UserID;
			dataRow["ClientIP"] = grantExperience.ClientIP;
			dataRow["AddExperience"] = grantExperience.AddExperience;
			dataRow["Reason"] = grantExperience.Reason;
			dataRow["CollectDate"] = System.DateTime.Now;
			this.aideRecordGrantExperienceProvider.Insert(dataRow);
		}
		public PagerSet GetRecordGrantGameScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantGameScore", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetRecordGrantClearScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantClearScore", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetRecordGrantClearFleeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantClearFlee", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetRecordConvertPresentList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordConvertPresent", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetRecordGrantGameIDList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordGrantGameID", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public Message GrantGameID(int userID, int gameID, int masterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			list.Add(base.Database.MakeInParam("ReGameID", gameID));
			list.Add(base.Database.MakeInParam("MasterID", masterID));
			list.Add(base.Database.MakeInParam("Reason", strReason));
			list.Add(base.Database.MakeInParam("ClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_GrantGameID", list);
		}
		public void DeleteTaskRecord(string sqlQuery)
		{
			this.aideTaskRecordProvider.Delete(sqlQuery);
		}
		public System.Data.DataSet GetLossUserByDay(int startID, int endID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT");
			stringBuilder.Append(" DateID,LossUser,LossPayUser");
			stringBuilder.Append(" FROM RecordEveryDayData WHERE DateID>=@StartID AND DateID<=@EndID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartID", startID));
			list.Add(base.Database.MakeInParam("EndID", endID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataSet GetLossUserByMonth()
		{
			string text = "SELECT CONVERT(char(7), CollectDate,120 ) AS CollectDate,SUM(LossUser) AS LossUserTotal,SUM(LossPayUser) AS LossPayUserTotal FROM RecordEveryDayData";
			text += " GROUP BY CONVERT(char(7), CollectDate, 120)";
			return base.Database.ExecuteDataset(text);
		}
		public System.Data.DataSet GetPayDesireByDay(int startID, int endID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT");
			stringBuilder.Append(" DateID,UserTotal,PayUserTotal,ActiveUserTotal,LossUserTotal,");
			stringBuilder.Append(" LossPayUserTotal,PayTotalAmount,PayAmountForCurrency,");
			stringBuilder.Append(" GoldTotal,CurrencyTotal,GameTaxTotal,UserAVGOnlineTime");
			stringBuilder.Append(" FROM RecordEveryDayData WHERE DateID>=@StartID AND DateID<=@EndID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartID", startID));
			list.Add(base.Database.MakeInParam("EndID", endID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataSet GetBankTaxByDay(int startID, int endID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT DateID,BankTax FROM RecordEveryDayData WHERE DateID>=@StartID AND DateID<=@EndID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartID", startID));
			list.Add(base.Database.MakeInParam("EndID", endID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataSet GetBankTaxByMonth()
		{
			string text = "SELECT SUM(BankTax) AS BankTax,CONVERT(char(7),CollectDate,120) AS StatDate FROM RecordEveryDayData";
			text += " GROUP BY CONVERT(char(7),CollectDate,120) ORDER BY StatDate ASC";
			return base.Database.ExecuteDataset(text);
		}
		public System.Data.DataSet GetGameTaxByDay(int startID, int endID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT DateID,GameTax FROM RecordEveryDayData WHERE DateID>=@StartID AND DateID<=@EndID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartID", startID));
			list.Add(base.Database.MakeInParam("EndID", endID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataSet GetGameTaxByMonth()
		{
			string text = "SELECT SUM(GameTax) AS GameTax,CONVERT(char(7),CollectDate,120) AS StatDate FROM RecordEveryDayData";
			text += " GROUP BY CONVERT(char(7),CollectDate,120) ORDER BY StatDate ASC";
			return base.Database.ExecuteDataset(text);
		}
		public System.Data.DataSet GetGameTaxListByDateID(int dateID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT KindID,SUM(Revenue) AS Revenue FROM RecordEveryDayRoomData WHERE DateID=@DateID GROUP BY KindID ORDER BY KindID ASC");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("DateID", dateID));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataTable GetGameRevenue()
		{
			string commandText = "SELECT MAX(k.KindName) KindName,SUM(Revenue) AS Revenue FROM RecordEveryDayRoomData d INNER JOIN RYPlatformDB..GameKindItem k ON k.KindID = d.KindID GROUP BY d.KindID HAVING SUM(Revenue)>0";
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
			return dataSet.Tables[0];
		}
		public System.Data.DataTable GetRoomRevenue()
		{
			string commandText = "SELECT MAX(k.ServerName) ServerName,SUM(Revenue) AS Revenue FROM RecordEveryDayRoomData d INNER JOIN RYPlatformDB..GameRoomInfo k ON k.ServerID = d.ServerID GROUP BY d.ServerID HAVING SUM(Revenue)>0";
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
			return dataSet.Tables[0];
		}
		public System.Data.DataTable GetGameWaste()
		{
			string commandText = "SELECT MAX(k.KindName) KindName,SUM(Waste) AS Waste FROM RecordEveryDayRoomData d INNER JOIN RYPlatformDB..GameKindItem k ON k.KindID = d.KindID GROUP BY d.KindID HAVING SUM(Waste)>0";
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
			return dataSet.Tables[0];
		}
		public System.Data.DataTable GetRoomWaste()
		{
			string commandText = "SELECT MAX(k.ServerName) ServerName,SUM(Waste) AS Waste FROM RecordEveryDayRoomData  d INNER JOIN RYPlatformDB..GameRoomInfo k ON k.ServerID = d.ServerID GROUP BY d.ServerID HAVING SUM(Waste)>0";
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
			return dataSet.Tables[0];
		}
		public PagerSet StraightAgentRev(int curId, int aid, string acc, System.DateTime sTime, System.DateTime eTime, int pageIndex, int pageSize, int doType)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("CurAgent", curId));
			list.Add(base.Database.MakeInParam("ParentAgent", aid));
			if (doType == 1)
			{
				list.Add(base.Database.MakeInParam("AgentAcc", acc));
			}
			else
			{
				list.Add(base.Database.MakeInParam("UserAcc", acc));
			}
			list.Add(base.Database.MakeInParam("StartDate", sTime));
			list.Add(base.Database.MakeInParam("EndDate", eTime));
			list.Add(base.Database.MakeInParam("PageSize", pageSize));
			list.Add(base.Database.MakeInParam("PageIndex", pageIndex));
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("SumAgentRevTotal", typeof(double)));
			list.Add(base.Database.MakeOutParam("SumWinlost", typeof(double)));
			list.Add(base.Database.MakeOutParam("StrErr", typeof(string), 127));
			string commandText = "";
			if (doType == 1)
			{
				commandText = "RYAgentDB..P_Rec_StraightAgentRev";
			}
			if (doType == 2)
			{
				commandText = "RYAgentDB..P_Rec_AgentPlayerRev";
			}
			if (doType == 3)
			{
				commandText = "RYAgentDB..P_Rec_PlayerGXRevDetail";
			}
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, commandText, list.ToArray());
			System.Data.DataTable dataTable = new System.Data.DataTable();
			dataTable.Columns.Add("SumWinlost");
			dataTable.Columns.Add("SumAgentRevTotal");
			System.Data.DataRow dataRow = dataTable.NewRow();
			dataRow["SumWinlost"] = System.Convert.ToDecimal(list[list.Count - 2].Value);
			dataRow["SumAgentRevTotal"] = System.Convert.ToDecimal(list[list.Count - 3].Value);
			dataTable.Rows.Add(dataRow);
			dataSet.Tables.Add(dataTable);
			return new PagerSet(1, 1, 1, System.Convert.ToInt32(list[list.Count - 4].Value), dataSet);
		}
		public double SumCS(string sWhere)
		{
			string commandText = "SELECT SUM(RealRev) FROM RYAgentDB..view_MyRevRecord " + sWhere;
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj is System.DBNull)
			{
				return 0.0;
			}
			return System.Convert.ToDouble(obj);
		}
		public System.Data.DataTable AgentLogType()
		{
			string commandText = "select * from RYAgentDB..T_Rec_AgentLogType(NOLOCK)";
			return base.Database.ExecuteDataset(commandText).Tables[0];
		}
		public double AgentScoreChangeSum(string sWhere)
		{
			string commandText = "SELECT SUM(SwapScore) FROM RYAgentDB..T_Rec_AgentScoreLog (NOLOCK) " + sWhere;
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj is System.DBNull)
			{
				return 0.0;
			}
			return System.Convert.ToDouble(obj);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public System.Data.DataTable GetAdvertInfo(string Advertiser, int IsWeek)
		{
			System.Data.DataTable dataTable = new System.Data.DataTable();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("select adv.TaskID,adv.BeginTime,adv.EndTime,adv.AdKey,adv.AdID,adv.PcUrl,k.KindID,k.IsWeek,k.CountType from (select top 1 t.BeginTime,t.EndTime,t.ID as TaskID,a.AdKey,a.PcUrl,t.AdID from dbo.T_Rec_Advertiser a join dbo.T_Rec_AdvertTask t on a.ID=t.AdvertiserID and a.StatusT=1 and t.StatusT=1 where a.Advertiser='{0}' order by t.AddTime desc) as adv inner join T_Rec_AdvertTaskKinds k on adv.TaskID=k.TaskID", Advertiser);
			if (IsWeek == 1)
			{
				stringBuilder.Append("  and k.IsWeek=1 ");
			}
			return base.Database.ExecuteDataset(stringBuilder.ToString()).Tables[0];
		}
		public System.Data.DataSet GetPlayer(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dic != null)
			{
				foreach (string current in dic.Keys)
				{
					list.Add(base.Database.MakeInParam(current, dic[current]));
				}
			}
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, procName, list.ToArray());
		}
		public System.Data.DataSet GetRanks(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dic != null)
			{
				foreach (string current in dic.Keys)
				{
					list.Add(base.Database.MakeInParam(current, dic[current]));
				}
			}
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, procName, list.ToArray());
		}
		public System.Data.DataTable GetAdvertisers(string fields, string where)
		{
			System.Data.DataTable dataTable = new System.Data.DataTable();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("select {0} from dbo.T_Rec_Advertiser {1}", fields, where);
			return base.Database.ExecuteDataset(stringBuilder.ToString()).Tables[0];
		}
		public System.Data.DataSet GetRanks(System.Collections.Generic.Dictionary<string, string> dic, string ProcName, string account)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dic != null)
			{
				foreach (string current in dic.Keys)
				{
					if (current.Contains("|"))
					{
						string[] array = current.Split(new char[]
						{
							'|'
						});
						if (array.Length > 1)
						{
							list.Add(base.Database.MakeOutParam(array[1], typeof(int)));
						}
					}
					else
					{
						list.Add(base.Database.MakeInParam(current, dic[current]));
					}
				}
			}
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, ProcName, list.ToArray());
			if (!string.IsNullOrEmpty(account))
			{
				int num = 0;
				int num2 = 0;
				System.Data.DataSet dataSet2 = new System.Data.DataSet();
				if (dataSet != null && dataSet.Tables[0] != null && dataSet.Tables[0].Rows.Count > 0)
				{
					System.Data.DataRow[] array2 = dataSet.Tables[0].Select(string.Concat(new string[]
					{
						" Accounts like '%",
						account,
						"%' or NickName like '%",
						account,
						"%'"
					}));
					System.Data.DataTable dataTable = dataSet.Tables[0].Clone();
					if (array2 != null)
					{
						System.Data.DataRow[] array3 = array2;
						for (int i = 0; i < array3.Length; i++)
						{
							System.Data.DataRow dataRow = array3[i];
							System.Data.DataRow dataRow2 = dataTable.NewRow();
							dataRow2["rnk"] = dataRow["rnk"];
							dataRow2["UserID"] = dataRow["UserID"];
							dataRow2["Accounts"] = dataRow["Accounts"];
							dataRow2["NickName"] = dataRow["NickName"];
							dataRow2["ADID"] = dataRow["ADID"];
							dataRow2["Score"] = dataRow["Score"];
							dataRow2["PlayTimeCount"] = dataRow["PlayTimeCount"];
							dataRow2["MyScore"] = dataRow["MyScore"];
							dataTable.Rows.Add(dataRow2);
						}
					}
					num = 1;
					num2 = array2.Length;
					dataSet2.Tables.Add(dataTable);
				}
				System.Data.DataTable dataTable2 = new System.Data.DataTable();
				dataTable2.Columns.Add("PageCount");
				dataTable2.Columns.Add("RecordCount");
				System.Data.DataRow dataRow3 = dataTable2.NewRow();
				dataRow3["PageCount"] = num;
				dataRow3["RecordCount"] = num2;
				dataTable2.Rows.Add(dataRow3);
				dataSet2.Tables.Add(dataTable2);
				dataSet = dataSet2;
			}
			else
			{
				System.Data.DataTable dataTable3 = new System.Data.DataTable();
				dataTable3.Columns.Add("PageCount");
				dataTable3.Columns.Add("RecordCount");
				System.Data.DataRow dataRow4 = dataTable3.NewRow();
				dataRow4["PageCount"] = System.Convert.ToInt32(list[list.Count - 3].Value);
				dataRow4["RecordCount"] = System.Convert.ToInt32(list[list.Count - 2].Value);
				dataTable3.Rows.Add(dataRow4);
				dataSet.Tables.Add(dataTable3);
			}
			return dataSet;
		}
		public Message EditAdvertiser(TAdvertiser model)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", model.ID));
			list.Add(base.Database.MakeInParam("AdKey", model.AdKey));
			list.Add(base.Database.MakeInParam("Advertiser", model.Advertiser));
			list.Add(base.Database.MakeInParam("Url", model.Url));
			list.Add(base.Database.MakeInParam("PcUrl", model.PcUrl));
			list.Add(base.Database.MakeInParam("Descr", model.Descr));
			list.Add(base.Database.MakeInParam("StatusT", model.StatusT));
			list.Add(base.Database.MakeInParam("Operator", model.Operator));
			list.Add(base.Database.MakeInParam("strClientIP", model.ClientIP));
			list.Add(base.Database.MakeOutParam("strErr", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_EditAdvertiser", list);
		}
		public bool DelAdvertiser(int id)
		{
			string commandText = "DELETE  FROM T_Rec_Advertiser WHERE ID=" + id;
			return base.Database.ExecuteNonQuery(commandText) > 0;
		}
		public System.Data.DataTable GetAdvertTask(string fields, string where)
		{
			System.Data.DataTable dataTable = new System.Data.DataTable();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("select {0} from dbo.T_Rec_AdvertTask {1}", fields, where);
			return base.Database.ExecuteDataset(stringBuilder.ToString()).Tables[0];
		}
		public Message EditAdvertTask(AdvertTask model)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", model.ID));
			list.Add(base.Database.MakeInParam("AdvertiserID", model.AdvertiserID));
			list.Add(base.Database.MakeInParam("TaskName", model.TaskName));
			list.Add(base.Database.MakeInParam("StatusT", model.StatusT));
			list.Add(base.Database.MakeInParam("AdID", model.AdID));
			list.Add(base.Database.MakeInParam("BeginTime", model.BeginTime));
			list.Add(base.Database.MakeInParam("EndTime", model.EndTime));
			list.Add(base.Database.MakeOutParam("strErr", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "NET_PW_EditAdvertTask", list);
		}
		public System.Data.DataTable GetAdvertTaskKinds(int taskID)
		{
			string commandText = "select t1.KindID,t1.KindName,isnull(t2.KindID,0) as itemKingId,isnull(t2.CountType,1) CountTypes,t2.IsWeek from RYPlatformDB..GameKindItem t1 left join T_Rec_AdvertTaskKinds t2  on t1.KindID = t2.KindID and TaskID= " + taskID;
			return base.Database.ExecuteDataset(commandText).Tables[0];
		}
		public bool EidterAdvertTaskKinds(System.Collections.Generic.List<T_Rec_AdvertTaskKindsEntity> entities)
		{
			bool flag = true;
			if (entities != null && entities.Count > 0)
			{
				int taskID = entities[0].TaskID;
				if (taskID > 0)
				{
					base.Database.ExecuteNonQuery("DELETE T_Rec_AdvertTaskKinds where TaskID=" + taskID);
				}
				else
				{
					flag = false;
				}
				if (flag)
				{
					System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
					stringBuilder.Append("insert into dbo.T_Rec_AdvertTaskKinds(TaskID,KindID,CountType,IsWeek) values");
					foreach (T_Rec_AdvertTaskKindsEntity current in entities)
					{
						stringBuilder.AppendFormat("({0},{1},{2},{3}),", new object[]
						{
							current.TaskID,
							current.KindID,
							current.CountType,
							current.IsWeek
						});
					}
					string text = stringBuilder.ToString().TrimEnd(new char[]
					{
						','
					});
					flag = (!string.IsNullOrEmpty(text) && base.Database.ExecuteNonQuery(text) > 0);
				}
			}
			else
			{
				flag = false;
			}
			return flag;
		}
		public void InsertBaiRenGameLog(BarrenGameLog model)
		{
			string commandText = "INSERT INTO BarrenGameLog(ServerID,ServerName,StorageStart,AttenuationScore,StorageDeduct,[Operator],ClientIP)VALUES(@ServerID,@ServerName,@StorageStart,@AttenuationScore,@StorageDeduct,@Operator,@ClientIP)";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ServerID", model.ServerID));
			list.Add(base.Database.MakeInParam("ServerName", model.ServerName));
			list.Add(base.Database.MakeInParam("StorageStart", model.StorageStart));
			list.Add(base.Database.MakeInParam("AttenuationScore", model.AttenuationScore));
			list.Add(base.Database.MakeInParam("StorageDeduct", model.StorageDeduct));
			list.Add(base.Database.MakeInParam("Operator", model.Operator));
			list.Add(base.Database.MakeInParam("ClientIP", model.ClientIP));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public PagerSet getAgentRecharges(System.Collections.Generic.Dictionary<string, object> dic, out decimal total)
		{
			System.Data.DataSet pageSet = null;
			PagerSet pagerSet = new PagerSet();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("SumGold", typeof(decimal)));
			base.Database.RunProc("RYAgentDB..P_QueryAgentFill", list, out pageSet);
			pagerSet.PageSet = pageSet;
			pagerSet.RecordCount = System.Convert.ToInt32(list[8].Value);
			total = System.Convert.ToDecimal(list[9].Value);
			return pagerSet;
		}
		public Message getAgentQueryInfo(System.Collections.Generic.Dictionary<string, object> dic)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			list.Add(base.Database.MakeOutParam("strErr", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "RYAgentDB..P_AgentQueryInfo", list);
		}
		public PagerSet getAgentGameRecord(System.Collections.Generic.Dictionary<string, object> dic)
		{
			System.Data.DataSet pageSet = null;
			PagerSet pagerSet = new PagerSet();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			base.Database.RunProc("RYAgentDB..P_QueryPlayerGame", list, out pageSet);
			pagerSet.PageSet = pageSet;
			pagerSet.RecordCount = System.Convert.ToInt32(list[8].Value);
			return pagerSet;
		}
		public PagerSet getAgentBalance(System.Collections.Generic.Dictionary<string, object> dic, out decimal total)
		{
			System.Data.DataSet pageSet = null;
			PagerSet pagerSet = new PagerSet();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("SumGold", typeof(decimal)));
			base.Database.RunProc("RYAgentDB..P_QueryPlayerDraw", list, out pageSet);
			pagerSet.PageSet = pageSet;
			pagerSet.RecordCount = System.Convert.ToInt32(list[8].Value);
			total = System.Convert.ToDecimal(list[9].Value);
			return pagerSet;
		}
		public PagerSet QueryPlayerWinLost(System.Collections.Generic.Dictionary<string, object> dic)
		{
			System.Data.DataSet pageSet = null;
			PagerSet pagerSet = new PagerSet();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			list.Add(base.Database.MakeOutParam("PageCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("RecordCount", typeof(int)));
			list.Add(base.Database.MakeOutParam("SumWinlost", typeof(string), 100));
			base.Database.RunProc("RYAgentDB..P_QueryPlayerWinLost", list, out pageSet);
			pagerSet.PageSet = pageSet;
			System.Data.DataTable dataTable = new System.Data.DataTable();
			dataTable.Columns.Add("SumWinlost");
			System.Data.DataRow dataRow = dataTable.NewRow();
			decimal num = 0m;
			dataRow["SumWinlost"] = (decimal.TryParse(list[10].Value.ToString(), out num) ? num : 0m);
			dataTable.Rows.Add(dataRow);
			pagerSet.PageSet.Tables.Add(dataTable);
			pagerSet.RecordCount = System.Convert.ToInt32(list[9].Value);
			return pagerSet;
		}
		public System.Data.DataTable QueryUserGameWinLost(System.Collections.Generic.Dictionary<string, object> dic)
		{
			System.Data.DataSet dataSet = null;
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			foreach (string current in dic.Keys)
			{
				list.Add(base.Database.MakeInParam(current, dic[current]));
			}
			base.Database.RunProc("RYAgentDB..P_QueryUserGameWinLost", list, out dataSet);
			return dataSet.Tables[0];
		}
	}
}
