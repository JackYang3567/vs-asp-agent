using Game.Data.Factory;
using Game.Entity;
using Game.Entity.Treasure;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class TreasureFacade
	{
		private ITreasureDataProvider aideTreasureData;
		public TreasureFacade()
		{
			this.aideTreasureData = ClassFactory.GetITreasureDataProvider();
		}
		public TreasureFacade(int kindID)
		{
			this.aideTreasureData = ClassFactory.GetITreasureDataProvider(kindID);
		}
		public PagerSet GetAgentPayOrder(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetAgentPayOrder(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetGlobalAppInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetGlobalAppInfoList(pageIndex, pageSize, condition, orderby);
		}
		public void DeleteGlobalAppInfo(string sqlQuery)
		{
			this.aideTreasureData.DeleteGlobalAppInfo(sqlQuery);
		}
		public DataTable GetGlobalAppInfo(int AppID)
		{
			return this.aideTreasureData.GetGlobalAppInfoes(AppID);
		}
		public int EditGlobalAppInfo(int AppID, decimal Price, decimal PresentCurrency, int SortID)
		{
			return this.aideTreasureData.EditGlobalAppInfo(AppID, Price, PresentCurrency, SortID);
		}
		public PagerSet GetGlobalLivcardList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetGlobalLivcardList(pageIndex, pageSize, condition, orderby);
		}
		public GlobalLivcard GetGlobalLivcardInfo(int cardTypeID)
		{
			return this.aideTreasureData.GetGlobalLivcardInfo(cardTypeID);
		}
		public Message InsertGlobalLivcard(GlobalLivcard globalLivcard)
		{
			this.aideTreasureData.InsertGlobalLivcard(globalLivcard);
			return new Message(true);
		}
		public Message UpdateGlobalLivcard(GlobalLivcard globalLivcard)
		{
			this.aideTreasureData.UpdateGlobalLivcard(globalLivcard);
			return new Message(true);
		}
		public void DeleteGlobalLivcard(string sqlQuery)
		{
			this.aideTreasureData.DeleteGlobalLivcard(sqlQuery);
		}
		public PagerSet GetLivcardBuildStreamList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetLivcardBuildStreamList(pageIndex, pageSize, condition, orderby);
		}
		public LivcardBuildStream GetLivcardBuildStreamInfo(int buildID)
		{
			return this.aideTreasureData.GetLivcardBuildStreamInfo(buildID);
		}
		public int InsertLivcardBuildStream(LivcardBuildStream livcardBuildStream)
		{
			return this.aideTreasureData.InsertLivcardBuildStream(livcardBuildStream);
		}
		public void UpdateLivcardBuildStream(LivcardBuildStream livcardBuildStream)
		{
			this.aideTreasureData.UpdateLivcardBuildStream(livcardBuildStream);
		}
		public void UpdateLivcardBuildStream(int buildID)
		{
			this.aideTreasureData.UpdateLivcardBuildStream(buildID);
		}
		public PagerSet GetLivcardAssociatorList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetLivcardAssociatorList(pageIndex, pageSize, condition, orderby);
		}
		public LivcardAssociator GetLivcardAssociatorInfo(int cardID)
		{
			return this.aideTreasureData.GetLivcardAssociatorInfo(cardID);
		}
		public LivcardAssociator GetLivcardAssociatorInfo(string serialID)
		{
			return this.aideTreasureData.GetLivcardAssociatorInfo(serialID);
		}
		public ShareDetailInfo GetShareDetailInfo(string serialID)
		{
			return this.aideTreasureData.GetShareDetailInfo(serialID);
		}
		public string GetSalesperson(int buildID)
		{
			return this.aideTreasureData.GetSalesperson(buildID);
		}
		public void SetCardDisbale(string sqlQuery)
		{
			this.aideTreasureData.SetCardDisbale(sqlQuery);
		}
		public void SetCardEnbale(string sqlQuery)
		{
			this.aideTreasureData.SetCardEnbale(sqlQuery);
		}
		public void InsertLivcardAssociator(LivcardAssociator livcardAssociator, string[,] list)
		{
			this.aideTreasureData.InsertLivcardAssociator(livcardAssociator, list);
		}
		public DataSet GetLivcardStat()
		{
			return this.aideTreasureData.GetLivcardStat();
		}
		public DataSet GetLivcardStatByBuildID(int buildID)
		{
			return this.aideTreasureData.GetLivcardStatByBuildID(buildID);
		}
		public PagerSet GetOnLineOrderList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetOnLineOrderList(pageIndex, pageSize, condition, orderby);
		}
		public OnLineOrder GetOnLineOrderInfo(string orderID)
		{
			return this.aideTreasureData.GetOnLineOrderInfo(orderID);
		}
		public void DeleteOnlineOrder(string sqlQuery)
		{
			this.aideTreasureData.DeleteOnlineOrder(sqlQuery);
		}
		public PagerSet GetKQDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetKQDetailList(pageIndex, pageSize, condition, orderby);
		}
		public ReturnKQDetailInfo GetKQDetailInfo(int detailID)
		{
			return this.aideTreasureData.GetKQDetailInfo(detailID);
		}
		public void DeleteKQDetail(string sqlQuery)
		{
			this.aideTreasureData.DeleteKQDetail(sqlQuery);
		}
		public PagerSet GetYPDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetYPDetailList(pageIndex, pageSize, condition, orderby);
		}
		public ReturnYPDetailInfo GetYPDetailInfo(int detailID)
		{
			return this.aideTreasureData.GetYPDetailInfo(detailID);
		}
		public void DeleteYPDetail(string sqlQuery)
		{
			this.aideTreasureData.DeleteYPDetail(sqlQuery);
		}
		public PagerSet GetVBDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetVBDetailList(pageIndex, pageSize, condition, orderby);
		}
		public ReturnVBDetailInfo GetVBDetailInfo(int detailID)
		{
			return this.aideTreasureData.GetVBDetailInfo(detailID);
		}
		public void DeleteVBDetail(string sqlQuery)
		{
			this.aideTreasureData.DeleteVBDetail(sqlQuery);
		}
		public PagerSet GetDayDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetDayDetailList(pageIndex, pageSize, condition, orderby);
		}
		public ReturnDayDetailInfo GetDayDetailInfo(int detailID)
		{
			return this.aideTreasureData.GetDayDetailInfo(detailID);
		}
		public void DeleteDayDetail(string sqlQuery)
		{
			this.aideTreasureData.DeleteDayDetail(sqlQuery);
		}
		public PagerSet GetShareDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetShareDetailList(pageIndex, pageSize, condition, orderby);
		}
		public GlobalShareInfo GetGlobalShareByShareID(int shareID)
		{
			return this.aideTreasureData.GetGlobalShareByShareID(shareID);
		}
		public PagerSet GetGlobalShareList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetGlobalShareList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetAppDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetAppDetailList(pageIndex, pageSize, condition, orderby);
		}
		public ReturnAppDetailInfo GetAppDetailInfo(int detailID)
		{
			return this.aideTreasureData.GetAppDetailInfo(detailID);
		}
		public Message InsertGlobalAppInfo(GlobalAppInfo globalApp)
		{
			this.aideTreasureData.InsertGlobalAppInfo(globalApp);
			return new Message(true);
		}
		public Message UpdateGlobalAppInfo(GlobalAppInfo globalApp)
		{
			this.aideTreasureData.UpdateGlobalAppInfo(globalApp);
			return new Message(true);
		}
		public DataTable GetMoney(int userId)
		{
			string sql = "SELECT Score,InsureScore FROM GameScoreInfo WHERE UserID=" + userId;
			return this.aideTreasureData.GetDataSetBySql(sql).Tables[0];
		}
		public PagerSet GetGameScoreInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetGameScoreInfoList(pageIndex, pageSize, condition, orderby);
		}
		public GameScoreInfo GetGameScoreInfoByUserID(int UserID)
		{
			return this.aideTreasureData.GetGameScoreInfoByUserID(UserID);
		}
		public decimal GetGameScoreByUserID(int UserID)
		{
			return this.aideTreasureData.GetGameScoreByUserID(UserID);
		}
		public void UpdateInsureScore(GameScoreInfo gameScoreInfo)
		{
			this.aideTreasureData.UpdateInsureScore(gameScoreInfo);
		}
		public Message GrantTreasure(int type, string strUserIdList, decimal intGold, int intMasterID, string strReason, string strIP)
		{
			return this.aideTreasureData.GrantTreasure(type, strUserIdList, intGold, intMasterID, strReason, strIP);
		}
		public Message GrantScore(int userID, int kindID, int score, int masterID, string strReason, string strIP)
		{
			return this.aideTreasureData.GrantScore(userID, kindID, score, masterID, strReason, strIP);
		}
		public Message GrantClearScore(int userID, int kindID, int masterID, string strReason, string strIP)
		{
			return this.aideTreasureData.GrantClearScore(userID, kindID, masterID, strReason, strIP);
		}
		public Message GrantFlee(int userID, int kindID, int masterID, string strReason, string strIP)
		{
			return this.aideTreasureData.GrantFlee(userID, kindID, masterID, strReason, strIP);
		}
		public UserCurrencyInfo GetUserCurrencyInfo(int userID)
		{
			return this.aideTreasureData.GetUserCurrencyInfo(userID);
		}
		public PagerSet GetRecordDrawInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetRecordDrawInfoList(pageIndex, pageSize, condition, orderby);
		}
		public int DeleteRecordDrawInfoByTime(System.DateTime dt)
		{
			return this.aideTreasureData.DeleteRecordDrawInfoByTime(dt);
		}
		public PagerSet GetRecordDrawScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetRecordDrawScoreList(pageIndex, pageSize, condition, orderby);
		}
		public DataSet GetRecordDrawScoreByDrawID(int drawID)
		{
			return this.aideTreasureData.GetRecordDrawScoreByDrawID(drawID);
		}
		public int DeleteRecordDrawScoreByTime(System.DateTime dt)
		{
			return this.aideTreasureData.DeleteRecordDrawScoreByTime(dt);
		}
		public PagerSet GetGameScoreLockerList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetGameScoreLockerList(pageIndex, pageSize, condition, orderby);
		}
		public void DeleteGameScoreLockerByUserID(int userID)
		{
			this.aideTreasureData.DeleteGameScoreLockerByUserID(userID);
		}
		public void DeleteGameScoreLocker(string sqlQuery)
		{
			this.aideTreasureData.DeleteGameScoreLocker(sqlQuery);
		}
		public GameScoreLocker GetGameScoreLockerByUserID(int userID)
		{
			return this.aideTreasureData.GetGameScoreLockerByUserID(userID);
		}
		public PagerSet GetAndroidList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetAndroidList(pageIndex, pageSize, condition, orderby);
		}
		public AndroidManager GetAndroidInfo(int userID)
		{
			return this.aideTreasureData.GetAndroidInfo(userID);
		}
		public Message InsertAndroid(AndroidManager android)
		{
			this.aideTreasureData.InsertAndroid(android);
			return new Message(true);
		}
		public Message UpdateAndroid(AndroidManager android)
		{
			this.aideTreasureData.UpdateAndroid(android);
			return new Message(true);
		}
		public void DeleteAndroid(string sqlQuery)
		{
			this.aideTreasureData.DeleteAndroid(sqlQuery);
		}
		public void NullityAndroid(byte nullity, string sqlQuery)
		{
			this.aideTreasureData.NullityAndroid(nullity, sqlQuery);
		}
		public PagerSet GetRecordUserInoutList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetRecordUserInoutList(pageIndex, pageSize, condition, orderby);
		}
		public int DeleteRecordUserInoutByTime(System.DateTime dt)
		{
			return this.aideTreasureData.DeleteRecordUserInoutByTime(dt);
		}
		public PagerSet GetRecordInsureList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetRecordInsureList(pageIndex, pageSize, condition, orderby);
		}
		public DataSet GetUserTransferTop100()
		{
			return this.aideTreasureData.GetUserTransferTop100();
		}
		public int DeleteRecordInsureByTime(System.DateTime dt)
		{
			return this.aideTreasureData.DeleteRecordInsureByTime(dt);
		}
		public GlobalSpreadInfo GetGlobalSpreadInfo(int id)
		{
			return this.aideTreasureData.GetGlobalSpreadInfo(id);
		}
		public void UpdateGlobalSpreadInfo(GlobalSpreadInfo spreadinfo)
		{
			this.aideTreasureData.UpdateGlobalSpreadInfo(spreadinfo);
		}
		public void UpdatePromoterSet(GlobalSpreadInfo spreadinfo)
		{
			this.aideTreasureData.UpdatePromoterSet(spreadinfo);
		}
		public PagerSet GetRecordSpreadInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetRecordSpreadInfoList(pageIndex, pageSize, condition, orderby);
		}
		public int GetSpreadScore(int userID)
		{
			return this.aideTreasureData.GetSpreadScore(userID);
		}
		public DataSet GetGoldDistribution()
		{
			return this.aideTreasureData.GetGoldDistribution();
		}
		public DataSet GetPayStat()
		{
			return this.aideTreasureData.GetPayStat();
		}
		public DataSet GetPayStatByDay(string startID, string endID)
		{
			return this.aideTreasureData.GetPayStatByDay(startID, endID);
		}
		public DataSet GetActiveUserByDay(int startDateID, int endDateID)
		{
			return this.aideTreasureData.GetActiveUserByDay(startDateID, endDateID);
		}
		public DataSet GetActivieUserByMonth()
		{
			return this.aideTreasureData.GetActivieUserByMonth();
		}
		public DataSet StatRecordTable()
		{
			return this.aideTreasureData.StatRecordTable();
		}
		public DataSet GetStatInfo()
		{
			return this.aideTreasureData.GetStatInfo();
		}
		public Message AppStatFilled(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatFilled(accounts, logonPass, machineID);
		}
		public Message AppStatFilledCash(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatFilledCash(accounts, logonPass, machineID);
		}
		public Message AppStatFilledScore(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatFilledScore(accounts, logonPass, machineID);
		}
		public Message AppStatScorePresent(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatScorePresent(accounts, logonPass, machineID);
		}
		public Message AppStatScoreRevenue(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatScoreRevenue(accounts, logonPass, machineID);
		}
		public Message AppStatScoreWaste(string accounts, string logonPass, string machineID)
		{
			return this.aideTreasureData.AppStatScoreWaste(accounts, logonPass, machineID);
		}
		public Message AppGetChargeData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetChargeData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public Message AppGetPayScoreData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetPayScoreData(accounts, logonPass, machineID, dateType, startDate, endDate);
		}
		public Message AppGetRevenueData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetRevenueData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public Message AppGetPresentData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetPresentData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public Message AppGetWasteData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetWasteData(accounts, logonPass, machineID, dateType, startDate, endDate);
		}
		public Message AppGetPlatScoreData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetPlatScoreData(accounts, logonPass, machineID, dateType, startDate, endDate);
		}
		public Message AppGetMemberData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aideTreasureData.AppGetMemberData(accounts, logonPass, typeID, machineID, dateType, startDate, endDate);
		}
		public long GetChildRevenueProvide(int userID)
		{
			return this.aideTreasureData.GetChildRevenueProvide(userID);
		}
		public long GetChildPayProvide(int userID)
		{
			return this.aideTreasureData.GetChildPayProvide(userID);
		}
		public DataSet GetAgentFinance(int userID)
		{
			return this.aideTreasureData.GetAgentFinance(userID);
		}
		public void StatRevenueHand()
		{
			this.aideTreasureData.StatRevenueHand();
		}
		public void StatAgentPayHand()
		{
			this.aideTreasureData.StatAgentPayHand();
		}
		public LotteryConfig GetLotteryConfig(int id)
		{
			return this.aideTreasureData.GetLotteryConfig(id);
		}
		public void UpdateLotteryConfig(LotteryConfig model)
		{
			this.aideTreasureData.UpdateLotteryConfig(model);
		}
		public int UpdateLotteryItem(LotteryItem model)
		{
			return this.aideTreasureData.UpdateLotteryItem(model);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public int ExecuteSql(string sql)
		{
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public DataSet GetDataSetBySql(string sql)
		{
			return this.aideTreasureData.GetDataSetBySql(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return this.aideTreasureData.GetScalarBySql(sql);
		}
		public double SumRevenue(string sWhere)
		{
			string sql = "SELECT SUM(Revenue) FROM View_RecordDrawScore " + sWhere;
			string scalarBySql = this.aideTreasureData.GetScalarBySql(sql);
			if (string.IsNullOrEmpty(scalarBySql))
			{
				return 0.0;
			}
			return System.Convert.ToDouble(scalarBySql);
		}
		public DataSet SumRevenueAll()
		{
			string sql = "SELECT SUM(Revenue) FROM RecordDrawScore(NOLOCK);SELECT SUM(RealRev) FROM RYAgentDB..view_MyRevRecord(NOLOCK);";
			return this.aideTreasureData.GetDataSetBySql(sql);
		}
		public DataSet GetGameRevenue(string stime, string etime)
		{
			return this.aideTreasureData.GetGameRevenue(stime, etime);
		}
		public DataSet GetRecordPresentInfo(string where)
		{
			return this.aideTreasureData.GetRecordPresentInfo(where);
		}
		public DataSet GetRecordType(string TabName)
		{
			return this.aideTreasureData.GetRecordType(TabName);
		}
		public decimal TotalScore(string sWhere)
		{
			string sql = "SELECT SUM(PresentScore) FROM View_PresentInfo " + sWhere;
			object scalarBySql = this.aideTreasureData.GetScalarBySql(sql);
			if (scalarBySql == null)
			{
				return 0m;
			}
			return System.Convert.ToDecimal(scalarBySql);
		}
		public decimal TotalAgentScore(string sWhere)
		{
			string sql = "SELECT SUM(SwapScore) FROM RYAgentDB..View_AgentScoreLog " + sWhere;
			object scalarBySql = this.aideTreasureData.GetScalarBySql(sql);
			if (scalarBySql == null)
			{
				return 0m;
			}
			return System.Convert.ToDecimal(scalarBySql);
		}
		public DataTable GetType(string tabName)
		{
			string sql = "SELECT ID,TypeName,IsShow FROM RecordType WHERE TabName='" + tabName + "'";
			return this.aideTreasureData.GetDataSetBySql(sql).Tables[0];
		}
		public int DeletePresentByTime(System.DateTime dt)
		{
			string sql = "DELETE RecordPresentInfo WHERE CollectDate<='" + dt + "'";
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int DeleteSpreadByTime(System.DateTime dt)
		{
			string sql = "DELETE RecordSpreadInfo WHERE CollectDate<='" + dt + "'";
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int DeleteAgentScoreByTime(System.DateTime dt)
		{
			string sql = "DELETE RYAgentDB.dbo.T_Rec_AgentScoreLog WHERE SwapDate<='" + dt + "'";
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int DeleteAgentChangeByTime(System.DateTime dt)
		{
			string sql = "DELETE RYAgentDB.dbo.T_Plm_AgentChangeLog WHERE UpdTime<='" + dt + "'";
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int DeleteSystemByTime(System.DateTime dt)
		{
			string sql = "DELETE RYPlatformManagerDB..SystemSecurity WHERE OperatingTime<='" + dt + "'";
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int EditRecordType(RecordType entity)
		{
			return this.aideTreasureData.EditRecordType(entity);
		}
		public void DelRecordType(string sWhere)
		{
			string sql = "DELETE RecordType " + sWhere;
			this.aideTreasureData.ExecuteSql(sql);
		}
		public PagerSet GetPager(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			return this.aideTreasureData.GetPager(dic, procName);
		}
		public SQLResult GetTable(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			return this.aideTreasureData.GetTable(dic, procName);
		}
		public DataTable GetAccountScoreById(int id)
		{
			return this.aideTreasureData.GetAccountScoreById(id);
		}
		public PagerSet GetAgentPlayRecords(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideTreasureData.GetAgentPlayRecords(pageIndex, pageSize, condition, orderby);
		}
		public int Freeze(string ids, int nullity)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE T_PayInfo SET Nullity=",
				nullity,
				" WHERE ID IN(",
				ids,
				")"
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int UpdateSort(int id, int sort)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE T_PayInfo SET SortID=",
				sort,
				" WHERE ID =",
				id
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int FreezeQudao(string ids, int nullity)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE T_PayQudaoInfo SET IsShow=",
				nullity,
				" WHERE ID IN(",
				ids,
				")"
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int UpdateQudaoSort(int id, int sort)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE T_PayQudaoInfo SET SortID=",
				sort,
				" WHERE ID =",
				id
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public DataTable GetPayQudaoList()
		{
			string sql = "SELECT ID,QudaoName FROM T_PayQudaoInfo WHERE (IsShow=1 and ID!=11) OR ID=100";
			return this.aideTreasureData.GetDataSetBySql(sql).Tables[0];
		}
		public int AddAmount(int qudaoId, int amount)
		{
			string sql = string.Concat(new object[]
			{
				"INSERT T_QudaoLimit(QudaoID,Limit) VALUES (",
				qudaoId,
				",",
				amount,
				")"
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int UpdateAmount(int amount, int id)
		{
			string sql = string.Concat(new object[]
			{
				"UPDATE T_QudaoLimit SET Limit=",
				amount,
				" WHERE ID =",
				id
			});
			return this.aideTreasureData.ExecuteSql(sql);
		}
		public int DelAmount(string sqlWhere)
		{
			string sql = "DELETE T_QudaoLimit " + sqlWhere;
			return this.aideTreasureData.ExecuteSql(sql);
		}
	}
}
