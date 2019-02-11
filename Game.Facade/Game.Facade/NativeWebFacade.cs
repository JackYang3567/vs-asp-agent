using Game.Data.Factory;
using Game.Entity.NativeWeb;
using Game.IData;
using Game.Kernel;
using System;
using System.Data;
namespace Game.Facade
{
	public class NativeWebFacade
	{
		private INativeWebDataProvider aideNativeWebData;
		public NativeWebFacade()
		{
			this.aideNativeWebData = ClassFactory.GetINativeWebDataProvider();
		}
		public News GetAgentNotice()
		{
			return this.aideNativeWebData.GetAgentNotice();
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetNewsList(pageIndex, pageSize, condition, orderby);
		}
		public News GetNewsInfo(int newsID)
		{
			return this.aideNativeWebData.GetNewsInfo(newsID);
		}
		public Message InsertNews(News news)
		{
			this.aideNativeWebData.InsertNews(news);
			return new Message(true);
		}
		public Message UpdateNews(News news)
		{
			this.aideNativeWebData.UpdateNews(news);
			return new Message(true);
		}
		public void DeleteNews(string sqlQuery)
		{
			this.aideNativeWebData.DeleteNews(sqlQuery);
		}
		public void JinyongNews(int id, int value)
		{
			string sql = string.Concat(new object[]
			{
				"Update News Set IsDelete=",
				value,
				" Where NewsID=",
				id
			});
			this.aideNativeWebData.ExecuteSql(sql);
		}
		public PagerSet GetGameRulesList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetGameRulesList(pageIndex, pageSize, condition, orderby);
		}
		public GameRulesInfo GetGameRulesInfo(int kindID)
		{
			return this.aideNativeWebData.GetGameRulesInfo(kindID);
		}
		public Message InsertGameRules(GameRulesInfo gameRules)
		{
			this.aideNativeWebData.InsertGameRules(gameRules);
			return new Message(true);
		}
		public Message UpdateGameRules(GameRulesInfo gameRules, int kindID)
		{
			this.aideNativeWebData.UpdateGameRules(gameRules, kindID);
			return new Message(true);
		}
		public void DeleteGameRules(string sqlQuery)
		{
			this.aideNativeWebData.DeleteGameRules(sqlQuery);
		}
		public bool JudgeRulesIsExistence(int kindID)
		{
			return this.aideNativeWebData.JudgeRulesIsExistence(kindID);
		}
		public PagerSet GetGameIssueList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetGameIssueList(pageIndex, pageSize, condition, orderby);
		}
		public GameIssueInfo GetGameIssueInfo(int issueID)
		{
			return this.aideNativeWebData.GetGameIssueInfo(issueID);
		}
		public Message InsertGameIssue(GameIssueInfo gameIssue)
		{
			this.aideNativeWebData.InsertGameIssue(gameIssue);
			return new Message(true);
		}
		public Message UpdateGameIssue(GameIssueInfo gameIssue)
		{
			this.aideNativeWebData.UpdateGameIssue(gameIssue);
			return new Message(true);
		}
		public void DeleteGameIssue(string sqlQuery)
		{
			this.aideNativeWebData.DeleteGameIssue(sqlQuery);
		}
		public PagerSet GetGameFeedbackList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetGameFeedbackList(pageIndex, pageSize, condition, orderby);
		}
		public GameFeedbackInfo GetGameFeedbackInfo(int feedbackID)
		{
			return this.aideNativeWebData.GetGameFeedbackInfo(feedbackID);
		}
		public Message RevertGameFeedback(GameFeedbackInfo gameFeedback)
		{
			this.aideNativeWebData.RevertGameFeedback(gameFeedback);
			return new Message(true);
		}
		public void DeleteGameFeedback(string sqlQuery)
		{
			this.aideNativeWebData.DeleteGameFeedback(sqlQuery);
		}
		public void SetFeedbackDisbale(string sqlQuery)
		{
			this.aideNativeWebData.SetFeedbackDisbale(sqlQuery);
		}
		public void SetFeedbackEnbale(string sqlQuery)
		{
			this.aideNativeWebData.SetFeedbackEnbale(sqlQuery);
		}
		public int GetNewMessageCounts()
		{
			return this.aideNativeWebData.GetNewMessageCounts();
		}
		public PagerSet GetNoticeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetNoticeList(pageIndex, pageSize, condition, orderby);
		}
		public Notice GetNoticeInfo(int noticeID)
		{
			return this.aideNativeWebData.GetNoticeInfo(noticeID);
		}
		public Message InsertNotice(Notice notice)
		{
			this.aideNativeWebData.InsertNotice(notice);
			return new Message(true);
		}
		public Message UpdateNotice(Notice notice)
		{
			this.aideNativeWebData.UpdateNotice(notice);
			return new Message(true);
		}
		public void DeleteNotice(string sqlQuery)
		{
			this.aideNativeWebData.DeleteNotice(sqlQuery);
		}
		public void SetNoticeDisbale(string sqlQuery)
		{
			this.aideNativeWebData.SetNoticeDisbale(sqlQuery);
		}
		public void SetNoticeEnbale(string sqlQuery)
		{
			this.aideNativeWebData.SetNoticeEnbale(sqlQuery);
		}
		public PagerSet GetGameMatchInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetGameMatchInfoList(pageIndex, pageSize, condition, orderby);
		}
		public GameMatchInfo GetGameMatchInfo(int matchID)
		{
			return this.aideNativeWebData.GetGameMatchInfo(matchID);
		}
		public void InsertGameMatchInfo(GameMatchInfo gameMatch)
		{
			this.aideNativeWebData.InsertGameMatchInfo(gameMatch);
		}
		public void UpdateGameMatchInfo(GameMatchInfo gameMatch)
		{
			this.aideNativeWebData.UpdateGameMatchInfo(gameMatch);
		}
		public void DeleteGameMatchInfo(string sqlQuery)
		{
			this.aideNativeWebData.DeleteGameMatchInfo(sqlQuery);
		}
		public void SetMatchDisbale(string sqlQuery)
		{
			this.aideNativeWebData.SetMatchDisbale(sqlQuery);
		}
		public void SetMatchEnbale(string sqlQuery)
		{
			this.aideNativeWebData.SetMatchEnbale(sqlQuery);
		}
		public PagerSet GetGameMatchUserInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetGameMatchUserInfoList(pageIndex, pageSize, condition, orderby);
		}
		public void SetUserMatchDisbale(string sqlQuery)
		{
			this.aideNativeWebData.SetUserMatchDisbale(sqlQuery);
		}
		public void SetUserMatchEnbale(string sqlQuery)
		{
			this.aideNativeWebData.SetUserMatchEnbale(sqlQuery);
		}
		public AwardType GetAwardTypeByPID(int typeID)
		{
			return this.aideNativeWebData.GetAwardTypeByPID(typeID);
		}
		public DataSet GetAllAwardType()
		{
			return this.aideNativeWebData.GetAllAwardType();
		}
		public DataSet GetAllChildType()
		{
			return this.aideNativeWebData.GetAllChildType();
		}
		public AwardType GetAwardTypeByID(int typeID)
		{
			return this.aideNativeWebData.GetAwardTypeByID(typeID);
		}
		public bool InsertAwardTypeInfo(AwardType awardType)
		{
			this.aideNativeWebData.InsertAwardTypeInfo(awardType);
			return true;
		}
		public bool UpdateAwardTypeInfo(AwardType awardType)
		{
			int num = this.aideNativeWebData.UpdateAwardTypeInfo(awardType);
			return num > 0;
		}
		public int UpdateNulity(string typeId, int state)
		{
			return this.aideNativeWebData.UpdateNulity(typeId, state);
		}
		public string GetChildAwardTypeByPID(int Pid)
		{
			return this.aideNativeWebData.GetChildAwardTypeByPID(Pid);
		}
		public Message DeleteAwardType(int typeId)
		{
			return this.aideNativeWebData.DeleteAwardType(typeId);
		}
		public AwardInfo GetAwardInfoByID(int id)
		{
			return this.aideNativeWebData.GetAwardInfoByID(id);
		}
		public int UpdateAwardInfoNulity(string idList, int state)
		{
			return this.aideNativeWebData.UpdateAwardInfoNulity(idList, state);
		}
		public bool InsertAwardInfo(AwardInfo info)
		{
			this.aideNativeWebData.InsertAwardInfo(info);
			return true;
		}
		public bool UpdateAwardInfo(AwardInfo info)
		{
			int num = this.aideNativeWebData.UpdateAwardInfo(info);
			return num > 0;
		}
		public int GetMaxAwardInfoID()
		{
			return this.aideNativeWebData.GetMaxAwardInfoID();
		}
		public bool IsHaveGoods(int typeID)
		{
			return this.aideNativeWebData.IsHaveGoods(typeID);
		}
		public AwardOrder GetAwardOrderByID(int orderID)
		{
			return this.aideNativeWebData.GetAwardOrderByID(orderID);
		}
		public int UpdateOrderState(int state, int orderID, string note)
		{
			return this.aideNativeWebData.UpdateOrderState(state, orderID, note);
		}
		public int GetNewOrderCounts()
		{
			return this.aideNativeWebData.GetNewOrderCounts();
		}
		public ConfigInfo GetConfigInfo(int configID)
		{
			return this.aideNativeWebData.GetConfigInfo(configID);
		}
		public ConfigInfo GetConfigInfo(string configKey)
		{
			return this.aideNativeWebData.GetConfigInfo(configKey);
		}
		public void UpdateConfigInfo(ConfigInfo ci)
		{
			this.aideNativeWebData.UpdateConfigInfo(ci);
		}
		public int GetConfigInfoMinID()
		{
			return this.aideNativeWebData.GetConfigInfoMinID();
		}
		public SinglePage GetSinglePage(int pageID)
		{
			return this.aideNativeWebData.GetSinglePage(pageID);
		}
		public SinglePage GetSinglePage(string keyValue)
		{
			return this.aideNativeWebData.GetSinglePage(keyValue);
		}
		public int UpdateSinglePage(SinglePage singlePage)
		{
			return this.aideNativeWebData.UpdateSinglePage(singlePage);
		}
		public int GetSinglePageMinID()
		{
			return this.aideNativeWebData.GetSinglePageMinID();
		}
		public Ads GetAds(int ID)
		{
			return this.aideNativeWebData.GetAds(ID);
		}
		public void DeleteAds(string sqlQuery)
		{
			this.aideNativeWebData.DeleteAds(sqlQuery);
		}
		public void InsertAds(Ads ads)
		{
			this.aideNativeWebData.InsertAds(ads);
		}
		public void UpdateAds(Ads ads)
		{
			this.aideNativeWebData.UpdateAds(ads);
		}
		public LossReport GetLossReport(int reportID)
		{
			return this.aideNativeWebData.GetLossReport(reportID);
		}
		public bool UpdateLossReport(LossReport lossReport)
		{
			return this.aideNativeWebData.UpdateLossReport(lossReport);
		}
		public void DeleteActivity(string idList)
		{
			this.aideNativeWebData.DeleteActivity(idList);
		}
		public Activity GetActivity(int id)
		{
			return this.aideNativeWebData.GetActivity(id);
		}
		public void AddActivity(Activity model)
		{
			this.aideNativeWebData.AddActivity(model);
		}
		public void UpdateActivity(Activity model)
		{
			this.aideNativeWebData.UpdateActivity(model);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aideNativeWebData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public int ExecuteSql(string sql)
		{
			return this.aideNativeWebData.ExecuteSql(sql);
		}
		public DataSet GetDataSetBySql(string sql)
		{
			return this.aideNativeWebData.GetDataSetBySql(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return this.aideNativeWebData.GetScalarBySql(sql);
		}
		public void DelReport(string sWhere)
		{
			string sql = "DELETE GameAccuseInfo " + sWhere;
			this.aideNativeWebData.ExecuteSql(sql);
		}
		public GameAccuseInfo GetGameAccuseInfo(int accuseID)
		{
			return this.aideNativeWebData.GetGameAccuseInfo(accuseID);
		}
		public int UpdateReport(int id, string body, string admin)
		{
			return this.aideNativeWebData.UpdateReport(id, body, admin);
		}
		public void InsertPushMessage(string accounts, string device, string msg, string strOperator, string ip)
		{
			string sql = string.Format("INSERT T_PushedNews(Accounts,Device,Msg,Operator,ClinetIP)VALUES('{0}','{1}','{2}','{3}','{4}')", new object[]
			{
				accounts,
				device,
				msg,
				strOperator,
				ip
			});
			this.aideNativeWebData.ExecuteSql(sql);
		}
		public int GetUnDoGameFeedbackInfoCount()
		{
			return this.aideNativeWebData.GetUnDoGameFeedbackInfoCount();
		}
		public int AddPlatformDraw(PlatformDraw model)
		{
			return this.aideNativeWebData.AddPlatformDraw(model);
		}
		public string SumPlayerDraw(string sWhere)
		{
			string sql = "select isnull(sum(DrawAmt),0) from T_PlatformDraw " + sWhere;
			return this.aideNativeWebData.GetScalarBySql(sql);
		}
	}
}
