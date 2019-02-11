using Game.Data.Factory;
using Game.Entity.Record;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class RecordFacade
	{
		private IRecordDataProvider aideRecordData;
		public RecordFacade()
		{
			this.aideRecordData = ClassFactory.GetIRecordDataProvider();
		}
		public PagerSet GetRecordAccountsExpendList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordAccountsExpendList(pageIndex, pageSize, condition, orderby);
		}
		public void InsertRecordAccountsExpend(RecordAccountsExpend actExpend)
		{
			this.aideRecordData.InsertRecordAccountsExpend(actExpend);
		}
		public System.Collections.Generic.Dictionary<int, string> GetOldNickNameOrAccountsList(int userId, int typeID)
		{
			return this.aideRecordData.GetOldNickNameOrAccountsList(userId, typeID);
		}
		public PagerSet GetRecordPasswdExpendList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordPasswdExpendList(pageIndex, pageSize, condition, orderby);
		}
		public void InsertRecordPasswdExpend(RecordPasswdExpend pwExpend)
		{
			this.aideRecordData.InsertRecordPasswdExpend(pwExpend);
		}
		public RecordPasswdExpend GetRecordPasswdExpendByRid(int rid)
		{
			return this.aideRecordData.GetRecordPasswdExpendByRid(rid);
		}
		public bool ConfirmPass(int rid, string password, int type)
		{
			return this.aideRecordData.ConfirmPass(rid, password, type);
		}
		public System.Collections.Generic.Dictionary<int, string> GetOldLogonPassList(int userId)
		{
			return this.aideRecordData.GetOldLogonPassList(userId);
		}
		public PagerSet GetRecordGrantTreasureList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantTreasureList(pageIndex, pageSize, condition, orderby);
		}
		public void InsertRecordGrantTreasure(RecordGrantTreasure grantTreasure)
		{
			this.aideRecordData.InsertRecordGrantTreasure(grantTreasure);
		}
		public PagerSet GetRecordGrantMemberList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantMemberList(pageIndex, pageSize, condition, orderby);
		}
		public void InsertRecordGrantMember(RecordGrantMember grantMember)
		{
			this.aideRecordData.InsertRecordGrantMember(grantMember);
		}
		public void GrantMember(int userID, int memberOrder, int days, int masterID, string strReason, string strIP)
		{
			this.aideRecordData.GrantMember(userID, memberOrder, days, masterID, strReason, strIP);
		}
		public PagerSet GetRecordGrantExperienceList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantExperienceList(pageIndex, pageSize, condition, orderby);
		}
		public void InsertRecordGrantExperience(RecordGrantExperience grantExperience)
		{
			this.aideRecordData.InsertRecordGrantExperience(grantExperience);
		}
		public PagerSet GetRecordGrantGameScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantGameScoreList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetRecordGrantClearScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantClearScoreList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetRecordGrantClearFleeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantClearFleeList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetRecordConvertPresentList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordConvertPresentList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetRecordGrantGameIDList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetRecordGrantGameIDList(pageIndex, pageSize, condition, orderby);
		}
		public Message GrantGameID(int userID, int gameID, int masterID, string strReason, string strIP)
		{
			return this.aideRecordData.GrantGameID(userID, gameID, masterID, strReason, strIP);
		}
		public void DeleteTaskRecord(string sqlQuery)
		{
			this.aideRecordData.DeleteTaskRecord(sqlQuery);
		}
		public DataSet GetLossUserByDay(int startID, int endID)
		{
			return this.aideRecordData.GetLossUserByDay(startID, endID);
		}
		public DataSet GetLossUserByMonth()
		{
			return this.aideRecordData.GetLossUserByMonth();
		}
		public DataSet GetPayDesireByDay(int startID, int endID)
		{
			return this.aideRecordData.GetPayDesireByDay(startID, endID);
		}
		public DataSet GetBankTaxByDay(int startID, int endID)
		{
			return this.aideRecordData.GetBankTaxByDay(startID, endID);
		}
		public DataSet GetBankTaxByMonth()
		{
			return this.aideRecordData.GetBankTaxByMonth();
		}
		public DataSet GetGameTaxByDay(int startID, int endID)
		{
			return this.aideRecordData.GetGameTaxByDay(startID, endID);
		}
		public DataSet GetGameTaxByMonth()
		{
			return this.aideRecordData.GetGameTaxByMonth();
		}
		public DataSet GetGameTaxListByDateID(int dateID)
		{
			return this.aideRecordData.GetGameTaxListByDateID(dateID);
		}
		public DataTable GetGameRevenue()
		{
			return this.aideRecordData.GetGameRevenue();
		}
		public DataTable GetRoomRevenue()
		{
			return this.aideRecordData.GetRoomRevenue();
		}
		public DataTable GetGameWaste()
		{
			return this.aideRecordData.GetGameWaste();
		}
		public DataTable GetRoomWaste()
		{
			return this.aideRecordData.GetRoomWaste();
		}
		public PagerSet StraightAgentRev(int curId, int aid, string acc, System.DateTime sTime, System.DateTime eTime, int pageIndex, int pageSize, int doType = 1)
		{
			return this.aideRecordData.StraightAgentRev(curId, aid, acc, sTime, eTime, pageIndex, pageSize, doType);
		}
		public double SumCS(string sWhere)
		{
			return this.aideRecordData.SumCS(sWhere);
		}
		public DataTable AgentLogType()
		{
			return this.aideRecordData.AgentLogType();
		}
		public double AgentScoreChangeSum(string sWhere)
		{
			return this.aideRecordData.AgentScoreChangeSum(sWhere);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideRecordData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public DataTable GetAdvertInfo(string Advertiser, int IsWeek = 1)
		{
			return this.aideRecordData.GetAdvertInfo(Advertiser, IsWeek);
		}
		public DataSet GetPlayer(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			return this.aideRecordData.GetPlayer(dic, procName);
		}
		public DataSet GetRanks(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			return this.aideRecordData.GetRanks(dic, procName);
		}
		public DataTable GetAdvertisers(string fields, string where)
		{
			return this.aideRecordData.GetAdvertisers(fields, where);
		}
		public DataTable GetAdvertTask(string fields, string where)
		{
			return this.aideRecordData.GetAdvertTask(fields, where);
		}
		public DataSet GetRanks(System.Collections.Generic.Dictionary<string, string> dic, string ProcName, string account)
		{
			return this.aideRecordData.GetRanks(dic, ProcName, account);
		}
		public Message EditAdvertiser(TAdvertiser model)
		{
			return this.aideRecordData.EditAdvertiser(model);
		}
		public bool DelAdvertiser(int id)
		{
			return this.aideRecordData.DelAdvertiser(id);
		}
		public Message EditAdvertTask(AdvertTask entity)
		{
			return this.aideRecordData.EditAdvertTask(entity);
		}
		public DataTable GetAdvertTaskKinds(int taskID)
		{
			return this.aideRecordData.GetAdvertTaskKinds(taskID);
		}
		public bool EidterAdvertTaskKinds(System.Collections.Generic.List<T_Rec_AdvertTaskKindsEntity> entities)
		{
			return this.aideRecordData.EidterAdvertTaskKinds(entities);
		}
		public void InsertBaiRenGameLog(BarrenGameLog model)
		{
			this.aideRecordData.InsertBaiRenGameLog(model);
		}
		public PagerSet getAgentRecharges(System.Collections.Generic.Dictionary<string, object> dic, out decimal total)
		{
			return this.aideRecordData.getAgentRecharges(dic, out total);
		}
		public PagerSet getAgentGameRecord(System.Collections.Generic.Dictionary<string, object> dic)
		{
			return this.aideRecordData.getAgentGameRecord(dic);
		}
		public PagerSet getAgentBalance(System.Collections.Generic.Dictionary<string, object> dic, out decimal total)
		{
			return this.aideRecordData.getAgentBalance(dic, out total);
		}
		public PagerSet QueryPlayerWinLost(System.Collections.Generic.Dictionary<string, object> dic)
		{
			return this.aideRecordData.QueryPlayerWinLost(dic);
		}
		public DataTable QueryUserGameWinLost(System.Collections.Generic.Dictionary<string, object> dic)
		{
			return this.aideRecordData.QueryUserGameWinLost(dic);
		}
		public Message getAgentQueryInfo(System.Collections.Generic.Dictionary<string, object> dic)
		{
			return this.aideRecordData.getAgentQueryInfo(dic);
		}
	}
}
