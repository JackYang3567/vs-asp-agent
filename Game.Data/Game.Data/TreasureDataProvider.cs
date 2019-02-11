using Game.Entity;
using Game.Entity.Treasure;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class TreasureDataProvider : BaseDataProvider, ITreasureDataProvider
	{
		private ITableProvider aideShareDetialProvider;
		private ITableProvider aideGlobalShareProvider;
		private ITableProvider aideOnLineOrderProvider;
		private ITableProvider aideDayDetailProvider;
		private ITableProvider aideKQDetailProvider;
		private ITableProvider aideYPDetailProvider;
		private ITableProvider aideGameScoreInfoProvider;
		private ITableProvider aideRecordDrawInfoProvider;
		private ITableProvider aideRecordDrawScoreProvider;
		private ITableProvider aideGameScoreLockerProvider;
		private ITableProvider aideAndroidProvider;
		private ITableProvider aideGlobalLivcardProvider;
		private ITableProvider aideLivcardAssociatorProvider;
		private ITableProvider aideLivcardBuildStreamProvider;
		private ITableProvider aideGlobalSpreadInfoProvider;
		private ITableProvider aideGameScoreLocker;
		private ITableProvider aideVBDetailProvider;
		private ITableProvider aideAppDetailProvider;
		private ITableProvider aideGlobalAppProvider;
		private ITableProvider aideRecordExchCurrency;
		private ITableProvider aideLotteryConfigProvider;
		public TreasureDataProvider(string connString) : base(connString)
		{
			this.aideShareDetialProvider = this.GetTableProvider("ShareDetailInfo");
			this.aideGlobalShareProvider = this.GetTableProvider("GlobalShareInfo");
			this.aideOnLineOrderProvider = this.GetTableProvider("OnLineOrder");
			this.aideDayDetailProvider = this.GetTableProvider("ReturnDayDetailInfo");
			this.aideKQDetailProvider = this.GetTableProvider("ReturnKQDetailInfo");
			this.aideYPDetailProvider = this.GetTableProvider("ReturnYPDetailInfo");
			this.aideVBDetailProvider = this.GetTableProvider("ReturnVBDetailInfo");
			this.aideAppDetailProvider = this.GetTableProvider("ReturnAppDetailInfo");
			this.aideGlobalAppProvider = this.GetTableProvider("GlobalAppInfo");
			this.aideGameScoreInfoProvider = this.GetTableProvider("GameScoreInfo");
			this.aideRecordDrawInfoProvider = this.GetTableProvider("RecordDrawInfo");
			this.aideRecordDrawScoreProvider = this.GetTableProvider("RecordDrawScore");
			this.aideGameScoreLockerProvider = this.GetTableProvider("GameScoreLocker");
			this.aideAndroidProvider = this.GetTableProvider("AndroidManager");
			this.aideGlobalLivcardProvider = this.GetTableProvider("GlobalLivcard");
			this.aideLivcardAssociatorProvider = this.GetTableProvider("LivcardAssociator");
			this.aideLivcardBuildStreamProvider = this.GetTableProvider("LivcardBuildStream");
			this.aideGlobalSpreadInfoProvider = this.GetTableProvider("GlobalSpreadInfo");
			this.aideGameScoreLocker = this.GetTableProvider("GameScoreLocker");
			this.aideRecordExchCurrency = this.GetTableProvider("RecordExchCurrency");
			this.aideLotteryConfigProvider = this.GetTableProvider("LotteryConfig");
		}
		public PagerSet GetAgentPayOrder(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RYAgentDB..T_AgentFillOrder", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetGlobalAppInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GlobalAppInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void DeleteGlobalAppInfo(string sqlQuery)
		{
			this.aideGlobalAppProvider.Delete(sqlQuery);
		}
		public System.Data.DataTable GetGlobalAppInfoes(int AppID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("select AppId,Price,SortID,PresentCurrency from GlobalAppInfo where ").Append("AppId=@AppId ");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AppId", AppID));
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
			System.Data.DataTable result = new System.Data.DataTable();
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				result = dataSet.Tables[0];
			}
			return result;
		}
		public int EditGlobalAppInfo(int AppID, decimal Price, decimal PresentCurrency, int SortID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (AppID > 0)
			{
				stringBuilder.Append("UPDATE GlobalAppInfo SET ").Append("Price=@Price, ").Append("PresentCurrency=@PresentCurrency, ").Append("SortID=@SortID ").Append("WHERE AppId=@AppId");
				list.Add(base.Database.MakeInParam("Price", Price));
				list.Add(base.Database.MakeInParam("PresentCurrency", PresentCurrency));
				list.Add(base.Database.MakeInParam("SortID", SortID));
				list.Add(base.Database.MakeInParam("AppId", AppID));
			}
			else
			{
				stringBuilder.Append("INSERT INTO GlobalAppInfo(Price,SortID,PresentCurrency)values(@Price,@SortID,@PresentCurrency)");
				list.Add(base.Database.MakeInParam("Price", Price));
				list.Add(base.Database.MakeInParam("SortID", SortID));
				list.Add(base.Database.MakeInParam("PresentCurrency", PresentCurrency));
			}
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetGlobalLivcardList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GlobalLivcard", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GlobalLivcard GetGlobalLivcardInfo(int cardTypeID)
		{
			string where = string.Format("(NOLOCK) WHERE CardTypeID= '{0}'", cardTypeID);
			return this.aideGlobalLivcardProvider.GetObject<GlobalLivcard>(where);
		}
		public void InsertGlobalLivcard(GlobalLivcard globalLivcard)
		{
			System.Data.DataRow dataRow = this.aideGlobalLivcardProvider.NewRow();
			dataRow["CardName"] = globalLivcard.CardName;
			dataRow["CardPrice"] = globalLivcard.CardPrice;
			dataRow["Currency"] = globalLivcard.Currency;
			dataRow["InputDate"] = System.DateTime.Now;
			dataRow["Gold"] = globalLivcard.Gold;
			this.aideGlobalLivcardProvider.Insert(dataRow);
		}
		public void UpdateGlobalLivcard(GlobalLivcard globalLivcard)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GlobalLivcard SET ").Append("CardName=@CardName, ").Append("CardPrice=@CardPrice, ").Append("Currency=@Currency ").Append("WHERE CardTypeID=@CardTypeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("CardName", globalLivcard.CardName));
			list.Add(base.Database.MakeInParam("CardPrice", globalLivcard.CardPrice));
			list.Add(base.Database.MakeInParam("Currency", globalLivcard.Currency));
			list.Add(base.Database.MakeInParam("CardTypeID", globalLivcard.CardTypeID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGlobalLivcard(string sqlQuery)
		{
			this.aideGlobalLivcardProvider.Delete(sqlQuery);
		}
		public PagerSet GetLivcardBuildStreamList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("LivcardBuildStream", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public LivcardBuildStream GetLivcardBuildStreamInfo(int buildID)
		{
			string where = string.Format("(NOLOCK) WHERE BuildID= '{0}'", buildID);
			return this.aideLivcardBuildStreamProvider.GetObject<LivcardBuildStream>(where);
		}
		public int InsertLivcardBuildStream(LivcardBuildStream livcardBuildStream)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AdminName", livcardBuildStream.AdminName));
			list.Add(base.Database.MakeInParam("CardTypeID", livcardBuildStream.CardTypeID));
			list.Add(base.Database.MakeInParam("CardPrice", livcardBuildStream.CardPrice));
			list.Add(base.Database.MakeInParam("Currency", livcardBuildStream.Currency));
			list.Add(base.Database.MakeInParam("BuildCount", livcardBuildStream.BuildCount));
			list.Add(base.Database.MakeInParam("BuildAddr", livcardBuildStream.BuildAddr));
			list.Add(base.Database.MakeInParam("NoteInfo", livcardBuildStream.NoteInfo));
			list.Add(base.Database.MakeInParam("BuildCardPacket", livcardBuildStream.BuildCardPacket));
			list.Add(base.Database.MakeInParam("Gold", livcardBuildStream.Gold));
			object obj;
			base.Database.RunProc("WSP_PM_BuildStreamAdd", list, out obj);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void UpdateLivcardBuildStream(LivcardBuildStream livcardBuildStream)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE LivcardBuildStream SET ").Append("BuildCardPacket=@BuildCardPacket ").Append("WHERE BuildID=@BuildID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("BuildCardPacket", livcardBuildStream.BuildCardPacket));
			list.Add(base.Database.MakeInParam("BuildID", livcardBuildStream.BuildID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void UpdateLivcardBuildStream(int buildID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE LivcardBuildStream SET ").Append("DownLoadCount=DownLoadCount+1 ").Append("WHERE BuildID=@BuildID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("BuildID", buildID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetLivcardAssociatorList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("LivcardAssociator", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public LivcardAssociator GetLivcardAssociatorInfo(int cardID)
		{
			string where = string.Format("(NOLOCK) WHERE CardID= '{0}'", cardID);
			return this.aideLivcardAssociatorProvider.GetObject<LivcardAssociator>(where);
		}
		public LivcardAssociator GetLivcardAssociatorInfo(string serialID)
		{
			string where = string.Format("(NOLOCK) WHERE SerialID= '{0}'", serialID);
			return this.aideLivcardAssociatorProvider.GetObject<LivcardAssociator>(where);
		}
		public ShareDetailInfo GetShareDetailInfo(string serialID)
		{
			string where = string.Format("(NOLOCK) WHERE SerialID= '{0}'", serialID);
			return this.aideShareDetialProvider.GetObject<ShareDetailInfo>(where);
		}
		public string GetSalesperson(int buildID)
		{
			string commandText = string.Format("SELECT TOP 1 Salesperson FROM LivcardAssociator(NOLOCK) WHERE BuildID= '{0}'", buildID);
			return base.Database.ExecuteScalarToStr(System.Data.CommandType.Text, commandText);
		}
		public void SetCardDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE LivcardAssociator SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetCardEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE LivcardAssociator SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void InsertLivcardAssociator(LivcardAssociator livcardAssociator, string[,] list)
		{
			string text = string.Empty;
			string text2 = string.Empty;
			int length = list.GetLength(0);
			for (int i = 0; i < length; i += 100)
			{
				System.Collections.Generic.List<System.Data.Common.DbParameter> list2 = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
				text = string.Empty;
				text2 = string.Empty;
				int num = i;
				while (num < i + 100 && num < length)
				{
					text += string.Format("{0},", list[num, 0]);
					text2 += string.Format("{0},", list[num, 1]);
					num++;
				}
				if (!string.IsNullOrEmpty(text) && !string.IsNullOrEmpty(text2))
				{
					text = text.TrimEnd(new char[]
					{
						','
					});
					text2 = text2.TrimEnd(new char[]
					{
						','
					});
					list2.Add(base.Database.MakeInParam("SerialID", text));
					list2.Add(base.Database.MakeInParam("Password", text2));
					list2.Add(base.Database.MakeInParam("BuildID", livcardAssociator.BuildID));
					list2.Add(base.Database.MakeInParam("CardTypeID", livcardAssociator.CardTypeID));
					list2.Add(base.Database.MakeInParam("CardPrice", livcardAssociator.CardPrice));
					list2.Add(base.Database.MakeInParam("Currency", livcardAssociator.Currency));
					list2.Add(base.Database.MakeInParam("UseRange", livcardAssociator.UseRange));
					list2.Add(base.Database.MakeInParam("SalesPerson", livcardAssociator.SalesPerson));
					list2.Add(base.Database.MakeInParam("ValidDate", livcardAssociator.ValidDate));
					list2.Add(base.Database.MakeInParam("Gold", livcardAssociator.Gold));
					base.Database.RunProc("WSP_PM_LivcardAdd", list2);
				}
			}
		}
		public System.Data.DataSet GetLivcardStat()
		{
			System.Data.DataSet result;
			base.Database.RunProc("WSP_PM_LivcardStat", out result);
			return result;
		}
		public System.Data.DataSet GetLivcardStatByBuildID(int buildID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("BuildID", buildID));
			System.Data.DataSet result;
			base.Database.RunProc("NET_PM_LivcardStatByBuildID", list, out result);
			return result;
		}
		public PagerSet GetOnLineOrderList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("OnLineOrder", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public OnLineOrder GetOnLineOrderInfo(string orderID)
		{
			string where = string.Format("(NOLOCK) WHERE OrderID= '{0}'", orderID);
			return this.aideOnLineOrderProvider.GetObject<OnLineOrder>(where);
		}
		public void DeleteOnlineOrder(string sqlQuery)
		{
			this.aideOnLineOrderProvider.Delete(sqlQuery);
		}
		public PagerSet GetKQDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("ReturnKQDetailInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public ReturnKQDetailInfo GetKQDetailInfo(int detailID)
		{
			string where = string.Format("(NOLOCK) WHERE DetailID= {0}", detailID);
			return this.aideKQDetailProvider.GetObject<ReturnKQDetailInfo>(where);
		}
		public void DeleteKQDetail(string sqlQuery)
		{
			this.aideKQDetailProvider.Delete(sqlQuery);
		}
		public PagerSet GetYPDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("ReturnYPDetailInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public ReturnYPDetailInfo GetYPDetailInfo(int detailID)
		{
			string where = string.Format("(NOLOCK) WHERE DetailID= {0}", detailID);
			return this.aideYPDetailProvider.GetObject<ReturnYPDetailInfo>(where);
		}
		public void DeleteYPDetail(string sqlQuery)
		{
			this.aideYPDetailProvider.Delete(sqlQuery);
		}
		public PagerSet GetVBDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("ReturnVBDetailInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public ReturnVBDetailInfo GetVBDetailInfo(int detailID)
		{
			string where = string.Format("(NOLOCK) WHERE DetailID= {0}", detailID);
			return this.aideVBDetailProvider.GetObject<ReturnVBDetailInfo>(where);
		}
		public void DeleteVBDetail(string sqlQuery)
		{
			this.aideVBDetailProvider.Delete(sqlQuery);
		}
		public PagerSet GetDayDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("ReturnDayDetailInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public ReturnDayDetailInfo GetDayDetailInfo(int detailID)
		{
			return new ReturnDayDetailInfo();
		}
		public void DeleteDayDetail(string sqlQuery)
		{
			this.aideDayDetailProvider.Delete(sqlQuery);
		}
		public PagerSet GetShareDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			string arg = "RYTreasureDB.dbo.ShareDetailInfo(nolock) as sd inner join RYAccountsDB..AccountsInfo(nolock) as acc on sd.UserID=acc.UserID left join RYAgentDB.dbo.T_Acc_Agent(nolock) as agt on acc.ParentId = agt.AgentID left join RYAccountsDB.dbo.AccountsInfo(nolock) as acc1 on acc.SpreaderID>0 and acc.SpreaderID=acc1.UserID ";
			string arg2 = "ApplyDate,ShareID,sd.UserID,acc.Accounts,acc.GameID,SerialID,OrderID,OrderAmount,PayAmount,CardTypeID,Currency,Gold,BeforeGold,IPAddress,BeforeCurrency,OperUserID,isnull(agt.AgentAcc,'') as AgentAcc,isnull(acc1.accounts,'') as Spreader";
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat(" SELECT {0}", "ApplyDate,ShareID,UserID,Accounts,GameID,SerialID,OrderID,OrderAmount,PayAmount,CardTypeID,Currency,Gold,BeforeGold,IPAddress,BeforeCurrency,OperUserID,AgentAcc,Spreader");
			stringBuilder.Append(" FROM(");
			stringBuilder.AppendFormat(" SELECT {0},ROW_NUMBER() over(order by {1}) as RowNumber", arg2, orderby);
			stringBuilder.AppendFormat(" FROM {0} {1}) as t", arg, condition);
			stringBuilder.AppendFormat(" WHERE t.RowNumber>{0} and t.RowNumber<={1}", (pageIndex - 1) * pageSize, pageIndex * pageSize);
			stringBuilder.AppendFormat(" SELECT COUNT(*) FROM {0} {1}", arg, condition);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(stringBuilder.ToString());
			PagerSet pagerSet = new PagerSet();
			pagerSet.PageSet = dataSet;
			int recordCount = 0;
			if (dataSet != null && dataSet.Tables.Count > 1)
			{
				int.TryParse(dataSet.Tables[1].Rows[0][0].ToString(), out recordCount);
			}
			pagerSet.RecordCount = recordCount;
			return pagerSet;
		}
		public GlobalShareInfo GetGlobalShareByShareID(int shareID)
		{
			string where = string.Format("(NOLOCK) WHERE ShareID= N'{0}'", shareID);
			return this.aideGlobalShareProvider.GetObject<GlobalShareInfo>(where);
		}
		public PagerSet GetGlobalShareList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GlobalShareInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetAppDetailList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("ReturnAppDetailInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public ReturnAppDetailInfo GetAppDetailInfo(int detailID)
		{
			string where = string.Format("(NOLOCK) WHERE DetailID= {0}", detailID);
			return this.aideAppDetailProvider.GetObject<ReturnAppDetailInfo>(where);
		}
		public GlobalAppInfo GetGlobalAppInfo(int appID)
		{
			string where = string.Format("(NOLOCK) WHERE AppID= '{0}'", appID);
			return this.aideGlobalAppProvider.GetObject<GlobalAppInfo>(where);
		}
		public void InsertGlobalAppInfo(GlobalAppInfo globalApp)
		{
			System.Data.DataRow dataRow = this.aideGlobalAppProvider.NewRow();
			dataRow["ProductID"] = globalApp.ProductID;
			dataRow["ProductName"] = globalApp.ProductName;
			dataRow["Description"] = globalApp.Description;
			dataRow["Price"] = globalApp.Price;
			dataRow["AttachCurrency"] = globalApp.AttachCurrency;
			dataRow["TagID"] = globalApp.TagID;
			dataRow["CollectDate"] = globalApp.CollectDate;
			this.aideGlobalAppProvider.Insert(dataRow);
		}
		public void UpdateGlobalAppInfo(GlobalAppInfo globalApp)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GlobalAppInfo SET ").Append("ProductID=@ProductID, ").Append("ProductName=@ProductName, ").Append("Description=@Description, ").Append("Price=@Price, ").Append("AttachCurrency=@AttachCurrency, ").Append("TagID=@TagID ").Append("WHERE AppID=@AppID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ProductID", globalApp.ProductID));
			list.Add(base.Database.MakeInParam("ProductName", globalApp.ProductName));
			list.Add(base.Database.MakeInParam("Description", globalApp.Description));
			list.Add(base.Database.MakeInParam("Price", globalApp.Price));
			list.Add(base.Database.MakeInParam("AttachCurrency", globalApp.AttachCurrency));
			list.Add(base.Database.MakeInParam("TagID", globalApp.TagID));
			list.Add(base.Database.MakeInParam("AppID", globalApp.AppID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetGameScoreInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameScoreInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameScoreInfo GetGameScoreInfoByUserID(int UserID)
		{
			string where = string.Format("(NOLOCK) WHERE UserID= N'{0}'", UserID);
			return this.aideGameScoreInfoProvider.GetObject<GameScoreInfo>(where);
		}
		public decimal GetGameScoreByUserID(int UserID)
		{
			GameScoreInfo gameScoreInfoByUserID = this.GetGameScoreInfoByUserID(UserID);
			if (gameScoreInfoByUserID == null)
			{
				return 0m;
			}
			return gameScoreInfoByUserID.InsureScore;
		}
		public void UpdateInsureScore(GameScoreInfo gameScoreInfo)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameScoreInfo SET ").Append("InsureScore=@InsureScore ").Append("WHERE UserID=@UserID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("InsureScore", gameScoreInfo.InsureScore));
			list.Add(base.Database.MakeInParam("UserID", gameScoreInfo.UserID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public Message GrantTreasure(int type, string strUserIdList, decimal intGold, int intMasterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwTypeId", type));
			list.Add(base.Database.MakeInParam("strUserIDList", strUserIdList));
			list.Add(base.Database.MakeInParam("dwAddGold", intGold));
			list.Add(base.Database.MakeInParam("dwMasterID", intMasterID));
			list.Add(base.Database.MakeInParam("strReason", strReason));
			list.Add(base.Database.MakeInParam("strClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "NET_PM_GrantTreasure", list);
		}
		public Message GrantScore(int userID, int kindID, int score, int masterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			list.Add(base.Database.MakeInParam("KindID", kindID));
			list.Add(base.Database.MakeInParam("AddScore", score));
			list.Add(base.Database.MakeInParam("MasterID", masterID));
			list.Add(base.Database.MakeInParam("Reason", strReason));
			list.Add(base.Database.MakeInParam("ClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_GrantGameScore", list);
		}
		public Message GrantClearScore(int userID, int kindID, int masterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			list.Add(base.Database.MakeInParam("KindID", kindID));
			list.Add(base.Database.MakeInParam("MasterID", masterID));
			list.Add(base.Database.MakeInParam("Reason", strReason));
			list.Add(base.Database.MakeInParam("ClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_GrantClearScore", list);
		}
		public Message GrantFlee(int userID, int kindID, int masterID, string strReason, string strIP)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			list.Add(base.Database.MakeInParam("KindID", kindID));
			list.Add(base.Database.MakeInParam("MasterID", masterID));
			list.Add(base.Database.MakeInParam("Reason", strReason));
			list.Add(base.Database.MakeInParam("ClientIP", strIP));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_GrantClearFlee", list);
		}
		public UserCurrencyInfo GetUserCurrencyInfo(int userID)
		{
			string commandText = "SELECT * FROM UserCurrencyInfo WHERE UserID=@UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", userID));
			return base.Database.ExecuteObject<UserCurrencyInfo>(commandText, list);
		}
		public PagerSet GetRecordDrawInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordDrawInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public int DeleteRecordDrawInfoByTime(System.DateTime dt)
		{
			string commandText = "DELETE RecordDrawInfo WHERE InsertTime<@Date";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Date", dt));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public PagerSet GetRecordDrawScoreList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordDrawScore", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public System.Data.DataSet GetRecordDrawScoreByDrawID(int drawID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwDrawID", drawID));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_GetRecordDrawScoreByDrawID", list.ToArray());
		}
		public int DeleteRecordDrawScoreByTime(System.DateTime dt)
		{
			string commandText = "DELETE RecordDrawScore WHERE InsertTime<@Date";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Date", dt));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public PagerSet GetGameScoreLockerList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameScoreLocker", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void DeleteGameScoreLockerByUserID(int userID)
		{
			string where = string.Format("WHERE UserID='{0}'", userID);
			this.aideGameScoreLockerProvider.Delete(where);
		}
		public void DeleteGameScoreLocker(string sqlQuery)
		{
			this.aideGameScoreLockerProvider.Delete(sqlQuery);
		}
		public GameScoreLocker GetGameScoreLockerByUserID(int userID)
		{
			string where = string.Format("(NOLOCK) WHERE UserID= N'{0}'", userID);
			return this.aideGameScoreLocker.GetObject<GameScoreLocker>(where);
		}
		public PagerSet GetAndroidList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("AndroidManager", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public AndroidManager GetAndroidInfo(int userID)
		{
			string where = string.Format("(NOLOCK) WHERE UserID= {0}", userID);
			return this.aideAndroidProvider.GetObject<AndroidManager>(where);
		}
		public void InsertAndroid(AndroidManager android)
		{
			System.Data.DataRow dataRow = this.aideAndroidProvider.NewRow();
			dataRow["UserID"] = android.UserID;
			dataRow["ServerID"] = android.ServerID;
			dataRow["MinPlayDraw"] = android.MinPlayDraw;
			dataRow["MaxPlayDraw"] = android.MaxPlayDraw;
			dataRow["MinTakeScore"] = android.MinTakeScore;
			dataRow["MaxTakeScore"] = android.MaxTakeScore;
			dataRow["MinReposeTime"] = android.MinReposeTime;
			dataRow["MaxReposeTime"] = android.MaxReposeTime;
			dataRow["ServiceGender"] = android.ServiceGender;
			dataRow["ServiceTime"] = android.ServiceTime;
			dataRow["AndroidNote"] = android.AndroidNote;
			dataRow["Nullity"] = android.Nullity;
			dataRow["CreateDate"] = android.CreateDate;
			this.aideAndroidProvider.Insert(dataRow);
		}
		public void UpdateAndroid(AndroidManager android)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE AndroidManager SET ").Append("ServerID=@ServerID ,").Append("MinPlayDraw=@MinPlayDraw,").Append("MaxPlayDraw=@MaxPlayDraw,").Append("MinTakeScore=@MinTakeScore,").Append("MaxTakeScore=@MaxTakeScore,").Append("MinReposeTime=@MinReposeTime,").Append("MaxReposeTime=@MaxReposeTime,").Append("ServiceGender=@ServiceGender,").Append("ServiceTime=@ServiceTime,").Append("AndroidNote=@AndroidNote,").Append("Nullity=@Nullity ").Append("WHERE UserID= @UserID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ServerID", android.ServerID));
			list.Add(base.Database.MakeInParam("MinPlayDraw", android.MinPlayDraw));
			list.Add(base.Database.MakeInParam("MaxPlayDraw", android.MaxPlayDraw));
			list.Add(base.Database.MakeInParam("MinTakeScore", android.MinTakeScore));
			list.Add(base.Database.MakeInParam("MaxTakeScore", android.MaxTakeScore));
			list.Add(base.Database.MakeInParam("MinReposeTime", android.MinReposeTime));
			list.Add(base.Database.MakeInParam("MaxReposeTime", android.MaxReposeTime));
			list.Add(base.Database.MakeInParam("ServiceGender", android.ServiceGender));
			list.Add(base.Database.MakeInParam("ServiceTime", android.ServiceTime));
			list.Add(base.Database.MakeInParam("AndroidNote", android.AndroidNote));
			list.Add(base.Database.MakeInParam("Nullity", android.Nullity));
			list.Add(base.Database.MakeInParam("UserID", android.UserID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteAndroid(string sqlQuery)
		{
			this.aideAndroidProvider.Delete(sqlQuery);
		}
		public void NullityAndroid(byte nullity, string sqlQuery)
		{
			string commandText = string.Format("UPDATE AndroidManager SET Nullity={0} {1}", nullity, sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public PagerSet GetRecordUserInoutList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordUserInout", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public int DeleteRecordUserInoutByTime(System.DateTime dt)
		{
			string commandText = "DELETE RecordUserInout WHERE LeaveTime<@Date";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Date", dt));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public PagerSet GetRecordInsureList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordInsure", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public System.Data.DataSet GetUserTransferTop100()
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_GetUserTransferTop100");
		}
		public int DeleteRecordInsureByTime(System.DateTime dt)
		{
			string commandText = "DELETE RecordInsure WHERE CollectDate<@Date";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Date", dt));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public GlobalSpreadInfo GetGlobalSpreadInfo(int id)
		{
			string where = string.Format("(NOLOCK) WHERE ID= {0}", id);
			return this.aideGlobalSpreadInfoProvider.GetObject<GlobalSpreadInfo>(where);
		}
		public void UpdateGlobalSpreadInfo(GlobalSpreadInfo spreadinfo)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GlobalSpreadInfo SET ").Append("RegisterGrantScore=@RegisterGrantScore ,").Append("PlayTimeCount=@PlayTimeCount,").Append("PlayTimeGrantScore=@PlayTimeGrantScore,").Append("FillGrantRate=@FillGrantRate,").Append("BalanceRate=@BalanceRate,").Append("MinBalanceScore=@MinBalanceScore ").Append("WHERE ID= @ID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", spreadinfo.ID));
			list.Add(base.Database.MakeInParam("RegisterGrantScore", spreadinfo.RegisterGrantScore));
			list.Add(base.Database.MakeInParam("PlayTimeCount", spreadinfo.PlayTimeCount));
			list.Add(base.Database.MakeInParam("PlayTimeGrantScore", spreadinfo.PlayTimeGrantScore));
			list.Add(base.Database.MakeInParam("FillGrantRate", spreadinfo.FillGrantRate));
			list.Add(base.Database.MakeInParam("BalanceRate", spreadinfo.BalanceRate));
			list.Add(base.Database.MakeInParam("MinBalanceScore", spreadinfo.MinBalanceScore));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void UpdatePromoterSet(GlobalSpreadInfo spreadinfo)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GlobalSpreadInfo SET ").Append("To1UperRate=@To1UperRate ,").Append("To2UperRate=@To2UperRate,").Append("To3UperRate=@To3UperRate,").Append("To4UperRate=@To4UperRate,").Append("To5UperRate=@To5UperRate");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("To1UperRate", spreadinfo.To1UperRate));
			list.Add(base.Database.MakeInParam("To2UperRate", spreadinfo.To2UperRate));
			list.Add(base.Database.MakeInParam("To3UperRate", spreadinfo.To3UperRate));
			list.Add(base.Database.MakeInParam("To4UperRate", spreadinfo.To4UperRate));
			list.Add(base.Database.MakeInParam("To5UperRate", spreadinfo.To5UperRate));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetRecordSpreadInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("RecordSpreadInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public int GetSpreadScore(int userID)
		{
			string commandText = string.Format("SELECT ISNULL(SUM(Score),0) FROM RecordSpreadInfo WHERE Score>0 AND UserID= {0}", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			int result = 0;
			int.TryParse(obj.ToString(), out result);
			return result;
		}
		public System.Data.DataSet GetGoldDistribution()
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "NET_PM_AnalGoldDistribution");
		}
		public System.Data.DataSet GetPayStat()
		{
			return base.Database.ExecuteDataset("NET_PM_AnalPayStat");
		}
		public System.Data.DataSet GetPayStatByDay(string startDate, string endDate)
		{
			string text = "SELECT CONVERT(VARCHAR(10),ApplyDate,120) AS ApplyDate,SUM(PayAmount) AS PayAmount FROM ShareDetailInfo WHERE ApplyDate>=@StartDate AND ApplyDate<=@EndDate";
			text += " GROUP BY CONVERT(VARCHAR(10),ApplyDate,120) ORDER BY ApplyDate DESC";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartDate", startDate));
			list.Add(base.Database.MakeInParam("EndDate", endDate));
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, text, list.ToArray());
		}
		public System.Data.DataSet GetActiveUserByDay(int startDateID, int endDateID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("StartDateID", startDateID));
			list.Add(base.Database.MakeInParam("EndDateID", endDateID));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_StatActiveUserTotalByDay", list.ToArray());
		}
		public System.Data.DataSet GetActivieUserByMonth()
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_StatActiveUserTotalByMonth", null);
		}
		public System.Data.DataSet StatRecordTable()
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_StatRecordTable", null);
		}
		public System.Data.DataSet GetStatInfo()
		{
			System.Data.DataSet result;
			base.Database.RunProc("NET_PM_StatInfo", out result);
			return result;
		}
		public Message AppStatFilled(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatFilled", list);
		}
		public Message AppStatFilledCash(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatFilledCash", list);
		}
		public Message AppStatFilledScore(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatFilledScore", list);
		}
		public Message AppStatScorePresent(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatScorePresent", list);
		}
		public Message AppStatScoreRevenue(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatScoreRevenue", list);
		}
		public Message AppStatScoreWaste(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatScoreWaste", list);
		}
		public Message AppGetChargeData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwTypeID", typeID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetChargeData", list);
		}
		public Message AppGetPayScoreData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetPayScoreData", list);
		}
		public Message AppGetRevenueData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwTypeID", typeID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetRevenueData", list);
		}
		public Message AppGetPresentData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwTypeID", typeID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetPresentData", list);
		}
		public Message AppGetWasteData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetWasteData", list);
		}
		public Message AppGetPlatScoreData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetPlatScoreData", list);
		}
		public Message AppGetMemberData(string accounts, string logonPass, int typeID, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwTypeID", typeID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetMemberData", list);
		}
		public long GetChildRevenueProvide(int userID)
		{
			string commandText = string.Format("SELECT ISNULL(SUM(AgentRevenue),0) FROM RecordUserRevenue WHERE UserID= {0}", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0L;
			}
			return System.Convert.ToInt64(obj);
		}
		public long GetChildPayProvide(int userID)
		{
			string commandText = string.Format("SELECT ISNULL(SUM(Score),0) FROM RecordAgentInfo WHERE ChildrenID= {0} AND TypeID=1", userID);
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0L;
			}
			return System.Convert.ToInt64(obj);
		}
		public System.Data.DataSet GetAgentFinance(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			return base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, "WSP_PM_GetAgentFinance", list.ToArray());
		}
		public void StatRevenueHand()
		{
			base.Database.ExecuteScalar(System.Data.CommandType.StoredProcedure, "WSP_PM_StatAccountRevenueHand");
		}
		public void StatAgentPayHand()
		{
			base.Database.ExecuteScalar(System.Data.CommandType.StoredProcedure, "WSP_PM_StatAgentPayHand");
		}
		public LotteryConfig GetLotteryConfig(int id)
		{
			string where = string.Format("(NOLOCK) WHERE ID= {0}", id);
			return this.aideLotteryConfigProvider.GetObject<LotteryConfig>(where);
		}
		public void UpdateLotteryConfig(LotteryConfig model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE LotteryConfig SET ").Append("FreeCount=@FreeCount ,").Append("ChargeFee=@ChargeFee,").Append("IsCharge=@IsCharge ").Append("WHERE ID= @ID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", model.ID));
			list.Add(base.Database.MakeInParam("FreeCount", model.FreeCount));
			list.Add(base.Database.MakeInParam("ChargeFee", model.ChargeFee));
			list.Add(base.Database.MakeInParam("IsCharge", model.IsCharge));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int UpdateLotteryItem(LotteryItem model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE LotteryItem SET ").Append("ItemType=@ItemType,").Append("ItemQuota=@ItemQuota,").Append("ItemRate=@ItemRate ").Append("WHERE ItemIndex=@ItemIndex");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ItemType", model.ItemType));
			list.Add(base.Database.MakeInParam("ItemQuota", model.ItemQuota));
			list.Add(base.Database.MakeInParam("ItemRate", model.ItemRate));
			list.Add(base.Database.MakeInParam("ItemIndex", model.ItemIndex));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public int ExecuteSql(string sql)
		{
			return base.Database.ExecuteNonQuery(sql);
		}
		public System.Data.DataSet GetDataSetBySql(string sql)
		{
			return base.Database.ExecuteDataset(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return base.Database.ExecuteScalarToStr(System.Data.CommandType.Text, sql);
		}
		public System.Data.DataSet GetGameRevenue(string stime, string etime)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT r.KindID,r.ServerID,ServerName,sum(UserCount) UserCount,sum(r.Revenue) Revenue from RecordDrawInfo r inner join RYPlatformDB.dbo.GameRoomInfo room on r.ServerID=room.ServerID WHERE 1=1");
			if (!string.IsNullOrEmpty(stime))
			{
				stringBuilder.Append(" AND InsertTime>=@stime");
			}
			if (!string.IsNullOrEmpty(etime))
			{
				stringBuilder.Append(" AND InsertTime<=@etime");
			}
			stringBuilder.Append(" GROUP BY r.KindID,ServerName,r.ServerID having sum(r.Revenue)>0");
			stringBuilder.Append(";SELECT SUM(Revenue) AS Revenue FROM RecordDrawInfo(NOLOCK) WHERE 1=1");
			if (!string.IsNullOrEmpty(stime))
			{
				stringBuilder.Append(" AND InsertTime>=@stime");
			}
			if (!string.IsNullOrEmpty(etime))
			{
				stringBuilder.Append(" AND InsertTime<=@etime");
			}
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (!string.IsNullOrEmpty(stime))
			{
				list.Add(base.Database.MakeInParam("stime", System.Convert.ToDateTime(stime)));
			}
			if (!string.IsNullOrEmpty(etime))
			{
				list.Add(base.Database.MakeInParam("etime", System.Convert.ToDateTime(etime).AddDays(1.0)));
			}
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public System.Data.DataSet GetRecordPresentInfo(string where)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT * from View_PresentInfo ");
			if (!string.IsNullOrEmpty(where))
			{
				stringBuilder.AppendFormat("{0}", where);
			}
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString());
		}
		public System.Data.DataSet GetRecordType(string TabName)
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, "SELECT ID,TypeName FROM  RecordType WHERE IsShow=0 " + (string.IsNullOrEmpty(TabName) ? "" : (" AND TabName='" + TabName + "'")));
		}
		public int EditRecordType(RecordType entity)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (entity.Mode == "edit")
			{
				stringBuilder.Append("UPDATE RecordType SET ").Append("TypeName=@TypeName, ").Append("IsShow=@IsShow ").Append("WHERE ID=@ID AND TabName=@TabName");
				list.Add(base.Database.MakeInParam("IsShow", entity.IsShow));
			}
			else
			{
				stringBuilder.Append("INSERT INTO RecordType(TabName,ID,TypeName,Memo,IsShow)VALUES(@TabName,@ID,@TypeName,@Memo,1)");
				list.Add(base.Database.MakeInParam("Memo", entity.Memo));
			}
			list.Add(base.Database.MakeInParam("TypeName", entity.TypeName));
			list.Add(base.Database.MakeInParam("ID", entity.ID));
			list.Add(base.Database.MakeInParam("TabName", entity.TabName));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetPager(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			PagerSet pagerSet = new PagerSet();
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
							string[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								string text = array2[i];
								if (!string.IsNullOrEmpty(text))
								{
									list.Add(base.Database.MakeOutParam(text, typeof(int)));
								}
							}
						}
					}
					else
					{
						list.Add(base.Database.MakeInParam(current, dic[current]));
					}
				}
			}
			System.Data.DataSet pageSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, procName, list.ToArray());
			pagerSet.PageSet = pageSet;
			pagerSet.PageSize = System.Convert.ToInt32(list[list.Count - 2].Value);
			pagerSet.RecordCount = System.Convert.ToInt32(list[list.Count - 1].Value);
			return pagerSet;
		}
		public SQLResult GetTable(System.Collections.Generic.Dictionary<string, string> dic, string procName)
		{
			SQLResult sQLResult = new SQLResult();
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
							string[] array2 = array;
							for (int i = 0; i < array2.Length; i++)
							{
								string text = array2[i];
								if (!string.IsNullOrEmpty(text))
								{
									list.Add(base.Database.MakeOutParam(text, typeof(int)));
								}
							}
						}
					}
					else
					{
						list.Add(base.Database.MakeInParam(current, dic[current]));
					}
				}
			}
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.StoredProcedure, procName, list.ToArray());
			sQLResult.Data = dataSet.Tables[0];
			if (string.IsNullOrEmpty(list[list.Count - 1].Value.ToString()))
			{
				sQLResult.Success = false;
				sQLResult.Msg = list[list.Count - 1].Value.ToString();
			}
			else
			{
				sQLResult.Success = true;
			}
			return sQLResult;
		}
		public System.Data.DataTable GetAccountScoreById(int id)
		{
			string commandText = string.Concat(new object[]
			{
				"SELECT KindID,KindName,SUM(Score)AS Score FROM  View_UserGameRDScore (NOLOCK) WHERE UserID=",
				id,
				" GROUP BY KindID,KindName UNION SELECT 0,'统计',SUM(Score)AS Score FROM  View_UserGameRDScore (NOLOCK) WHERE UserID=",
				id
			});
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
			return dataSet.Tables[0];
		}
		public PagerSet GetAgentPlayRecords(int pageIndex, int pageSize, string condition, string orderby)
		{
			string arg = "RYTreasureDB..ShareDetailInfo as sdi inner join (select u.UserID,u.Accounts,isnull(a.ORechargeRate,0) as RechargeRate,a.AgentID from RYAccountsDB..AccountsInfo as u inner join RYAgentDB..T_Plm_AgentChangeLog as a on u.AgentID = a.AgentID) as t on sdi.UserID = t.UserID";
			string arg2 = "sdi.DetailID,t.UserID,t.Accounts,t.RechargeRate,sdi.Currency,sdi.ApplyDate,sdi.ShareID,t.AgentID";
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat(" SELECT {0}", "DetailID,UserID,Accounts,RechargeRate,Currency,ApplyDate,ShareID ");
			stringBuilder.Append(" FROM(");
			stringBuilder.AppendFormat(" SELECT {0},ROW_NUMBER() over(order by {1}) as RowNumber", arg2, orderby);
			stringBuilder.AppendFormat(" FROM {0}", arg);
			stringBuilder.AppendFormat(" {0}) as t", condition);
			stringBuilder.AppendFormat(" WHERE t.RowNumber>{0} and t.RowNumber<={1}", (pageIndex - 1) * pageSize, pageIndex * pageSize);
			stringBuilder.AppendFormat(" SELECT COUNT(*) FROM {0}", arg);
			stringBuilder.AppendFormat(" {0}", condition);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(stringBuilder.ToString());
			PagerSet pagerSet = new PagerSet();
			pagerSet.PageSet = dataSet;
			int recordCount = 0;
			if (dataSet != null && dataSet.Tables.Count > 1)
			{
				int.TryParse(dataSet.Tables[1].Rows[0][0].ToString(), out recordCount);
			}
			pagerSet.RecordCount = recordCount;
			return pagerSet;
		}
	}
}
