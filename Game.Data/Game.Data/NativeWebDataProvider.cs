using Game.Entity.NativeWeb;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class NativeWebDataProvider : BaseDataProvider, INativeWebDataProvider
	{
		private ITableProvider aideNewsProvider;
		private ITableProvider aideGameRulesProvider;
		private ITableProvider aideGameIssueProvider;
		private ITableProvider aideGameFeedbackProvider;
		private ITableProvider aideNoticeProvider;
		private ITableProvider aideGameMatchInfoProvider;
		private ITableProvider aideAwardTypeProvider;
		private ITableProvider aideAwardOrderProvider;
		private ITableProvider aideAwardInfoProvider;
		private ITableProvider aideAdsProvider;
		private ITableProvider aideLossReport;
		public NativeWebDataProvider(string connString) : base(connString)
		{
			this.aideNewsProvider = this.GetTableProvider("News");
			this.aideGameRulesProvider = this.GetTableProvider("GameRulesInfo");
			this.aideGameIssueProvider = this.GetTableProvider("GameIssueInfo");
			this.aideGameFeedbackProvider = this.GetTableProvider("GameFeedbackInfo");
			this.aideNoticeProvider = this.GetTableProvider("Notice");
			this.aideGameMatchInfoProvider = this.GetTableProvider("GameMatchInfo");
			this.aideAwardTypeProvider = this.GetTableProvider("AwardType");
			this.aideAwardOrderProvider = this.GetTableProvider("AwardOrder");
			this.aideAwardInfoProvider = this.GetTableProvider("AwardInfo");
			this.aideAdsProvider = this.GetTableProvider("Ads");
			this.aideLossReport = this.GetTableProvider("LossReport");
		}
		public News GetAgentNotice()
		{
			string commandText = "SELECT TOP 1 Body FROM News WHERE Subject='代理公告'";
			return base.Database.ExecuteObject<News>(commandText);
		}
		public PagerSet GetNewsList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("News", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public News GetNewsInfo(int newsID)
		{
			string where = string.Format("(NOLOCK) WHERE NewsID= {0}", newsID);
			return this.aideNewsProvider.GetObject<News>(where);
		}
		public void InsertNews(News news)
		{
			System.Data.DataRow dataRow = this.aideNewsProvider.NewRow();
			dataRow["NewsID"] = news.NewsID;
			dataRow["PopID"] = news.PopID;
			dataRow["Subject"] = news.Subject;
			dataRow["Subject1"] = news.Subject1;
			dataRow["OnTop"] = news.OnTop;
			dataRow["OnTopAll"] = news.OnTopAll;
			dataRow["IsElite"] = news.IsElite;
			dataRow["IsHot"] = news.IsHot;
			dataRow["IsLock"] = news.IsLock;
			dataRow["IsDelete"] = news.IsDelete;
			dataRow["IsLinks"] = news.IsLinks;
			dataRow["LinkUrl"] = news.LinkUrl;
			dataRow["Body"] = news.Body;
			dataRow["FormattedBody"] = news.FormattedBody;
			dataRow["HighLight"] = news.HighLight;
			dataRow["ClassID"] = news.ClassID;
			dataRow["GameRange"] = news.GameRange;
			dataRow["ImageUrl"] = news.ImageUrl;
			dataRow["UserID"] = news.UserID;
			dataRow["IssueIP"] = news.IssueIP;
			dataRow["LastModifyIP"] = news.LastModifyIP;
			dataRow["IssueDate"] = news.IssueDate;
			dataRow["LastModifyDate"] = news.LastModifyDate;
			dataRow["SortID"] = 0;
			this.aideNewsProvider.Insert(dataRow);
		}
		public void UpdateNews(News news)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE News SET ").Append("PopID=@PopID ,").Append("Subject=@Subject,").Append("Subject1= @Subject1 ,").Append("OnTop= @OnTop ,").Append("OnTopAll= @OnTopAll,").Append("IsElite=@IsElite ,").Append("IsHot= @IsHot,").Append("IsLock= @IsLock ,").Append("IsDelete=@IsDelete,").Append("IsLinks=@IsLinks,").Append("LinkUrl=@LinkUrl ,").Append("Body= @Body ,").Append("FormattedBody= @FormattedBody,").Append("HighLight= @HighLight,").Append("ClassID= @ClassID,").Append("GameRange= @GameRange,").Append("ImageUrl= @ImageUrl,").Append("UserID=@UserID,").Append("IssueIP=@IssueIP,").Append("LastModifyIP=@LastModifyIP ,").Append("LastModifyDate=@LastModifyDate  ").Append("WHERE NewsID= @NewsID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PopID", news.PopID));
			list.Add(base.Database.MakeInParam("Subject", news.Subject));
			list.Add(base.Database.MakeInParam("Subject1", news.Subject1));
			list.Add(base.Database.MakeInParam("OnTop", news.OnTop));
			list.Add(base.Database.MakeInParam("OnTopAll", news.OnTopAll));
			list.Add(base.Database.MakeInParam("IsElite", news.IsElite));
			list.Add(base.Database.MakeInParam("IsHot", news.IsHot));
			list.Add(base.Database.MakeInParam("IsLock", news.IsLock));
			list.Add(base.Database.MakeInParam("IsDelete", news.IsDelete));
			list.Add(base.Database.MakeInParam("IsLinks", news.IsLinks));
			list.Add(base.Database.MakeInParam("LinkUrl", news.LinkUrl));
			list.Add(base.Database.MakeInParam("Body", news.Body));
			list.Add(base.Database.MakeInParam("FormattedBody", news.FormattedBody));
			list.Add(base.Database.MakeInParam("HighLight", news.HighLight));
			list.Add(base.Database.MakeInParam("ClassID", news.ClassID));
			list.Add(base.Database.MakeInParam("GameRange", news.GameRange));
			list.Add(base.Database.MakeInParam("ImageUrl", news.ImageUrl));
			list.Add(base.Database.MakeInParam("UserID", news.UserID));
			list.Add(base.Database.MakeInParam("IssueIP", news.IssueIP));
			list.Add(base.Database.MakeInParam("LastModifyIP", news.LastModifyIP));
			list.Add(base.Database.MakeInParam("IssueDate", news.IssueDate));
			list.Add(base.Database.MakeInParam("LastModifyDate", news.LastModifyDate));
			list.Add(base.Database.MakeInParam("NewsID", news.NewsID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteNews(string sqlQuery)
		{
			this.aideNewsProvider.Delete(sqlQuery);
		}
		public PagerSet GetGameRulesList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameRulesInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameRulesInfo GetGameRulesInfo(int kindID)
		{
			string where = string.Format("(NOLOCK) WHERE KindID= {0}", kindID);
			return this.aideGameRulesProvider.GetObject<GameRulesInfo>(where);
		}
		public void InsertGameRules(GameRulesInfo gameRules)
		{
			System.Data.DataRow dataRow = this.aideGameRulesProvider.NewRow();
			dataRow["KindID"] = gameRules.KindID;
			dataRow["KindName"] = gameRules.KindName;
			dataRow["ImgRuleUrl"] = gameRules.ImgRuleUrl;
			dataRow["ThumbnailUrl"] = gameRules.ThumbnailUrl;
			dataRow["MobileImgUrl"] = gameRules.MobileImgUrl;
			dataRow["MobileSize"] = gameRules.MobileSize;
			dataRow["MobileDate"] = gameRules.MobileDate;
			dataRow["MobileVersion"] = gameRules.MobileVersion;
			dataRow["MobileGameType"] = gameRules.MobileGameType;
			dataRow["AndroidDownloadUrl"] = gameRules.AndroidDownloadUrl;
			dataRow["IOSDownloadUrl"] = gameRules.IOSDownloadUrl;
			dataRow["HelpIntro"] = gameRules.HelpIntro;
			dataRow["HelpRule"] = gameRules.HelpRule;
			dataRow["HelpGrade"] = gameRules.HelpGrade;
			dataRow["JoinIntro"] = gameRules.JoinIntro;
			dataRow["Nullity"] = gameRules.Nullity;
			dataRow["CollectDate"] = gameRules.CollectDate;
			dataRow["ModifyDate"] = gameRules.ModifyDate;
			this.aideGameRulesProvider.Insert(dataRow);
		}
		public void UpdateGameRules(GameRulesInfo gameRules, int kindID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameRulesInfo SET ").Append("ImgRuleUrl = @ImgRuleUrl,").Append("ThumbnailUrl = @ThumbnailUrl,").Append("MobileImgUrl = @MobileImgUrl,").Append("MobileSize = @MobileSize,").Append("MobileDate = @MobileDate,").Append("MobileVersion = @MobileVersion,").Append("MobileGameType = @MobileGameType ,").Append("AndroidDownloadUrl = @AndroidDownloadUrl,").Append("IOSDownloadUrl = @IOSDownloadUrl,").Append("HelpIntro = @HelpIntro ,").Append("HelpRule = @HelpRule,").Append("HelpGrade = @HelpGrade,").Append("JoinIntro = @JoinIntro,").Append("Nullity = @Nullity,").Append("ModifyDate = @ModifyDate ").Append("WHERE KindID = @OldKindID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ImgRuleUrl", gameRules.ImgRuleUrl));
			list.Add(base.Database.MakeInParam("ThumbnailUrl", gameRules.ThumbnailUrl));
			list.Add(base.Database.MakeInParam("MobileImgUrl", gameRules.MobileImgUrl));
			list.Add(base.Database.MakeInParam("MobileSize", gameRules.MobileSize));
			list.Add(base.Database.MakeInParam("MobileDate", gameRules.MobileDate));
			list.Add(base.Database.MakeInParam("MobileVersion", gameRules.MobileVersion));
			list.Add(base.Database.MakeInParam("MobileGameType", gameRules.MobileGameType));
			list.Add(base.Database.MakeInParam("AndroidDownloadUrl", gameRules.AndroidDownloadUrl));
			list.Add(base.Database.MakeInParam("IOSDownloadUrl", gameRules.IOSDownloadUrl));
			list.Add(base.Database.MakeInParam("HelpIntro", gameRules.HelpIntro));
			list.Add(base.Database.MakeInParam("HelpRule", gameRules.HelpRule));
			list.Add(base.Database.MakeInParam("HelpGrade", gameRules.HelpGrade));
			list.Add(base.Database.MakeInParam("JoinIntro", gameRules.JoinIntro));
			list.Add(base.Database.MakeInParam("Nullity", gameRules.Nullity));
			list.Add(base.Database.MakeInParam("ModifyDate", gameRules.ModifyDate));
			list.Add(base.Database.MakeInParam("OldKindID", kindID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameRules(string sqlQuery)
		{
			this.aideGameRulesProvider.Delete(sqlQuery);
		}
		public bool JudgeRulesIsExistence(int kindID)
		{
			string where = string.Format("(NOLOCK) WHERE KindID= {0}", kindID);
			return this.aideGameRulesProvider.GetObject<GameRulesInfo>(where) != null;
		}
		public PagerSet GetGameIssueList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameIssueInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameIssueInfo GetGameIssueInfo(int issueID)
		{
			string where = string.Format("(NOLOCK) WHERE IssueID= {0}", issueID);
			return this.aideGameIssueProvider.GetObject<GameIssueInfo>(where);
		}
		public void InsertGameIssue(GameIssueInfo gameIssue)
		{
			System.Data.DataRow dataRow = this.aideGameIssueProvider.NewRow();
			dataRow["IssueID"] = gameIssue.IssueID;
			dataRow["IssueTitle"] = gameIssue.IssueTitle;
			dataRow["IssueContent"] = gameIssue.IssueContent;
			dataRow["TypeID"] = gameIssue.TypeID;
			dataRow["Nullity"] = gameIssue.Nullity;
			dataRow["Hot"] = gameIssue.Hot;
			dataRow["CollectDate"] = gameIssue.CollectDate;
			dataRow["ModifyDate"] = gameIssue.ModifyDate;
			this.aideGameIssueProvider.Insert(dataRow);
		}
		public void UpdateGameIssue(GameIssueInfo gameIssue)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameIssueInfo SET ").Append("IssueTitle=@IssueTitle ,").Append("IssueContent=@IssueContent,").Append("TypeID=@TypeID,").Append("Nullity= @Nullity ,").Append("Hot= @Hot ,").Append("ModifyDate= @ModifyDate ").Append("WHERE IssueID= @IssueID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("IssueTitle", gameIssue.IssueTitle));
			list.Add(base.Database.MakeInParam("IssueContent", gameIssue.IssueContent));
			list.Add(base.Database.MakeInParam("TypeID", gameIssue.TypeID));
			list.Add(base.Database.MakeInParam("Nullity", gameIssue.Nullity));
			list.Add(base.Database.MakeInParam("Hot", gameIssue.Hot));
			list.Add(base.Database.MakeInParam("ModifyDate", gameIssue.ModifyDate));
			list.Add(base.Database.MakeInParam("IssueID", gameIssue.IssueID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameIssue(string sqlQuery)
		{
			this.aideGameIssueProvider.Delete(sqlQuery);
		}
		public PagerSet GetGameFeedbackList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameFeedbackInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameFeedbackInfo GetGameFeedbackInfo(int feedbackID)
		{
			string where = string.Format("(NOLOCK) WHERE FeedbackID= {0}", feedbackID);
			return this.aideGameFeedbackProvider.GetObject<GameFeedbackInfo>(where);
		}
		public void RevertGameFeedback(GameFeedbackInfo gameFeedback)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameFeedbackInfo SET ").Append("RevertUserID=@RevertUserID ,").Append("RevertContent=@RevertContent,").Append("RevertDate= @RevertDate, ").Append("Nullity= @Nullity, ").Append("IsProcessed= @IsProcessed ").Append("WHERE FeedbackID= @FeedbackID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("RevertUserID", gameFeedback.RevertUserID));
			list.Add(base.Database.MakeInParam("RevertContent", gameFeedback.RevertContent));
			list.Add(base.Database.MakeInParam("RevertDate", gameFeedback.RevertDate));
			list.Add(base.Database.MakeInParam("Nullity", gameFeedback.Nullity));
			list.Add(base.Database.MakeInParam("IsProcessed", gameFeedback.IsProcessed));
			list.Add(base.Database.MakeInParam("FeedbackID", gameFeedback.FeedbackID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameFeedback(string sqlQuery)
		{
			this.aideGameFeedbackProvider.Delete(sqlQuery);
		}
		public void SetFeedbackDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameFeedbackInfo SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetFeedbackEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameFeedbackInfo SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public int GetNewMessageCounts()
		{
			string commandText = "SELECT COUNT(FeedbackID) FROM GameFeedbackInfo WHERE IsProcessed=0";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj != null)
			{
				return System.Convert.ToInt32(obj);
			}
			return 0;
		}
		public PagerSet GetNoticeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("Notice", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public Notice GetNoticeInfo(int noticeID)
		{
			string where = string.Format("(NOLOCK) WHERE NoticeID= {0}", noticeID);
			return this.aideNoticeProvider.GetObject<Notice>(where);
		}
		public void InsertNotice(Notice notice)
		{
			System.Data.DataRow dataRow = this.aideNoticeProvider.NewRow();
			dataRow["Subject"] = notice.Subject;
			dataRow["IsLink"] = notice.IsLink;
			dataRow["LinkUrl"] = notice.LinkUrl;
			dataRow["Body"] = notice.Body;
			dataRow["Location"] = notice.Location;
			dataRow["Width"] = notice.Width;
			dataRow["Height"] = notice.Height;
			dataRow["StartDate"] = notice.StartDate;
			dataRow["OverDate"] = notice.OverDate;
			dataRow["Nullity"] = notice.Nullity;
			this.aideNoticeProvider.Insert(dataRow);
		}
		public void UpdateNotice(Notice notice)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Notice SET ").Append("Subject=@Subject ,").Append("IsLink=@IsLink,").Append("LinkUrl= @LinkUrl ,").Append("Body= @Body,").Append("Location= @Location,").Append("Width=@Width,").Append("Height= @Height,").Append("StartDate= @StartDate,").Append("OverDate=@OverDate,").Append("Nullity=@Nullity ").Append("WHERE NoticeID= @NoticeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Subject", notice.Subject));
			list.Add(base.Database.MakeInParam("IsLink", notice.IsLink));
			list.Add(base.Database.MakeInParam("LinkUrl", notice.LinkUrl));
			list.Add(base.Database.MakeInParam("Body", notice.Body));
			list.Add(base.Database.MakeInParam("Location", notice.Location));
			list.Add(base.Database.MakeInParam("Width", notice.Width));
			list.Add(base.Database.MakeInParam("Height", notice.Height));
			list.Add(base.Database.MakeInParam("StartDate", notice.StartDate));
			list.Add(base.Database.MakeInParam("OverDate", notice.OverDate));
			list.Add(base.Database.MakeInParam("Nullity", notice.Nullity));
			list.Add(base.Database.MakeInParam("NoticeID", notice.NoticeID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteNotice(string sqlQuery)
		{
			this.aideNoticeProvider.Delete(sqlQuery);
		}
		public void SetNoticeDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE Notice SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetNoticeEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE Notice SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public PagerSet GetGameMatchInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameMatchInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameMatchInfo GetGameMatchInfo(int matchID)
		{
			string where = string.Format("(NOLOCK) WHERE MatchID= {0}", matchID);
			return this.aideGameMatchInfoProvider.GetObject<GameMatchInfo>(where);
		}
		public void InsertGameMatchInfo(GameMatchInfo gameMatch)
		{
			System.Data.DataRow dataRow = this.aideGameMatchInfoProvider.NewRow();
			dataRow["MatchID"] = gameMatch.MatchID;
			dataRow["MatchTitle"] = gameMatch.MatchTitle;
			dataRow["MatchSummary"] = gameMatch.MatchSummary;
			dataRow["MatchContent"] = gameMatch.MatchContent;
			dataRow["ApplyBeginDate"] = gameMatch.ApplyBeginDate;
			dataRow["ApplyEndDate"] = gameMatch.ApplyEndDate;
			dataRow["MatchStatus"] = gameMatch.MatchStatus;
			dataRow["Nullity"] = gameMatch.Nullity;
			dataRow["CollectDate"] = gameMatch.CollectDate;
			dataRow["ModifyDate"] = gameMatch.ModifyDate;
			this.aideGameMatchInfoProvider.Insert(dataRow);
		}
		public void UpdateGameMatchInfo(GameMatchInfo gameMatch)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameMatchInfo SET ").Append("MatchTitle=@MatchTitle ,").Append("MatchSummary=@MatchSummary,").Append("MatchContent= @MatchContent ,").Append("ApplyBeginDate= @ApplyBeginDate,").Append("ApplyEndDate= @ApplyEndDate,").Append("MatchStatus=@MatchStatus,").Append("Nullity= @Nullity,").Append("ModifyDate=@ModifyDate ").Append("WHERE MatchID= @MatchID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MatchTitle", gameMatch.MatchTitle));
			list.Add(base.Database.MakeInParam("MatchSummary", gameMatch.MatchSummary));
			list.Add(base.Database.MakeInParam("MatchContent", gameMatch.MatchContent));
			list.Add(base.Database.MakeInParam("ApplyBeginDate", gameMatch.ApplyBeginDate));
			list.Add(base.Database.MakeInParam("ApplyEndDate", gameMatch.ApplyEndDate));
			list.Add(base.Database.MakeInParam("MatchStatus", gameMatch.MatchStatus));
			list.Add(base.Database.MakeInParam("Nullity", gameMatch.Nullity));
			list.Add(base.Database.MakeInParam("ModifyDate", gameMatch.ModifyDate));
			list.Add(base.Database.MakeInParam("MatchID", gameMatch.MatchID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameMatchInfo(string sqlQuery)
		{
			this.aideGameMatchInfoProvider.Delete(sqlQuery);
		}
		public void SetMatchDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameMatchInfo SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetMatchEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameMatchInfo SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public PagerSet GetGameMatchUserInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameMatchUserInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public void SetUserMatchDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameMatchUserInfo SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetUserMatchEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameMatchUserInfo SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public AwardType GetAwardTypeByPID(int typeID)
		{
			string where = string.Format(" WHERE TypeID={0}", typeID);
			return this.aideAwardTypeProvider.GetObject<AwardType>(where);
		}
		public System.Data.DataSet GetAllAwardType()
		{
			string commandText = "SELECT * FROM dbo.AwardType WHERE Nullity=0";
			return base.Database.ExecuteDataset(commandText);
		}
		public System.Data.DataSet GetAllChildType()
		{
			string commandText = "SELECT * FROM dbo.AwardType WHERE ParentID!=0 AND Nullity=0";
			return base.Database.ExecuteDataset(commandText);
		}
		public AwardType GetAwardTypeByID(int typeID)
		{
			string where = string.Format(" WHERE TypeID={0}", typeID);
			return this.aideAwardTypeProvider.GetObject<AwardType>(where);
		}
		public void InsertAwardTypeInfo(AwardType awardType)
		{
			System.Data.DataRow dataRow = this.aideAwardTypeProvider.NewRow();
			dataRow["TypeName"] = awardType.TypeName;
			dataRow["ParentID"] = awardType.ParentID;
			dataRow["SortID"] = awardType.SortID;
			dataRow["Nullity"] = awardType.Nullity;
			dataRow["CollectDate"] = awardType.CollectDate;
			this.aideAwardTypeProvider.Insert(dataRow);
		}
		public int UpdateAwardTypeInfo(AwardType awardType)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE AwardType SET ").Append("TypeName=@TypeName,").Append("ParentID=@ParentID,").Append("SortID=@SortID,").Append("Nullity=@Nullity,").Append("CollectDate=@CollectDate").Append(" WHERE TypeID= @TypeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TypeName", awardType.TypeName));
			list.Add(base.Database.MakeInParam("ParentID", awardType.ParentID));
			list.Add(base.Database.MakeInParam("SortID", awardType.SortID));
			list.Add(base.Database.MakeInParam("Nullity", awardType.Nullity));
			list.Add(base.Database.MakeInParam("CollectDate", awardType.CollectDate));
			list.Add(base.Database.MakeInParam("TypeID", awardType.TypeID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int UpdateNulity(string typeId, int state)
		{
			string commandText = string.Format("UPDATE AwardType SET Nullity={0} WHERE TypeID IN({1})", state, typeId);
			return base.Database.ExecuteNonQuery(commandText);
		}
		public string GetChildAwardTypeByPID(int Pid)
		{
			string commandText = string.Format("SELECT TypeID FROM AwardType WHERE ParentID={0}", Pid);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(commandText);
			string text = "";
			foreach (System.Data.DataRow dataRow in dataSet.Tables[0].Rows)
			{
				text = text + dataRow["TypeID"].ToString() + ",";
			}
			if (text != "")
			{
				return text.Substring(0, text.Length - 1);
			}
			return "";
		}
		public Message DeleteAwardType(int typeId)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TypeID", typeId));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessage(base.Database, "WSP_PM_DeleteAwardType", list);
		}
		public AwardInfo GetAwardInfoByID(int id)
		{
			string where = string.Format(" WHERE AwardID={0}", id);
			return this.aideAwardInfoProvider.GetObject<AwardInfo>(where);
		}
		public int UpdateAwardInfoNulity(string idList, int state)
		{
			string commandText = string.Format("UPDATE dbo.AwardInfo SET Nullity={0} WHERE AwardID IN ({1})", state, idList);
			return base.Database.ExecuteNonQuery(commandText);
		}
		public void InsertAwardInfo(AwardInfo info)
		{
			System.Data.DataRow dataRow = this.aideAwardInfoProvider.NewRow();
			dataRow["AwardName"] = info.AwardName;
			dataRow["BigImage"] = info.BigImage;
			dataRow["BuyCount"] = info.BuyCount;
			dataRow["Description"] = info.Description;
			dataRow["Inventory"] = info.Inventory;
			dataRow["CollectDate"] = info.CollectDate;
			dataRow["IsMember"] = info.IsMember;
			dataRow["IsReturn"] = info.IsReturn;
			dataRow["NeedInfo"] = info.NeedInfo;
			dataRow["Nullity"] = info.Nullity;
			dataRow["Price"] = info.Price;
			dataRow["SmallImage"] = info.SmallImage;
			dataRow["SortID"] = info.SortID;
			dataRow["TypeID"] = info.TypeID;
			this.aideAwardInfoProvider.Insert(dataRow);
		}
		public int UpdateAwardInfo(AwardInfo info)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE AwardInfo SET ").Append("AwardName=@AwardName,").Append("BigImage=@BigImage,").Append("BuyCount=@BuyCount,").Append("Description=@Description,").Append("Inventory=@Inventory,").Append("IsMember=@IsMember,").Append("IsReturn=@IsReturn,").Append("NeedInfo=@NeedInfo,").Append("Nullity=@Nullity,").Append("Price=@Price,").Append("SmallImage=@SmallImage,").Append("SortID=@SortID,").Append("TypeID=@TypeID ").Append(" WHERE AwardID= @AwardID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AwardName", info.AwardName));
			list.Add(base.Database.MakeInParam("BigImage", info.BigImage));
			list.Add(base.Database.MakeInParam("BuyCount", info.BuyCount));
			list.Add(base.Database.MakeInParam("Description", info.Description));
			list.Add(base.Database.MakeInParam("Inventory", info.Inventory));
			list.Add(base.Database.MakeInParam("CollectDate", info.CollectDate));
			list.Add(base.Database.MakeInParam("IsMember", info.IsMember));
			list.Add(base.Database.MakeInParam("IsReturn", info.IsReturn));
			list.Add(base.Database.MakeInParam("NeedInfo", info.NeedInfo));
			list.Add(base.Database.MakeInParam("Nullity", info.Nullity));
			list.Add(base.Database.MakeInParam("Price", info.Price));
			list.Add(base.Database.MakeInParam("SmallImage", info.SmallImage));
			list.Add(base.Database.MakeInParam("SortID", info.SortID));
			list.Add(base.Database.MakeInParam("TypeID", info.TypeID));
			list.Add(base.Database.MakeInParam("AwardID", info.AwardID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int GetMaxAwardInfoID()
		{
			string commandText = string.Format("SELECT MAX(AwardID) FROM dbo.AwardInfo", new object[0]);
			return System.Convert.ToInt32(base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText));
		}
		public bool IsHaveGoods(int typeID)
		{
			string commandText = "SELECT TOP 1 * FROM AwardInfo WHERE TypeID=" + typeID;
			int num = base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText);
			return num > 0;
		}
		public AwardOrder GetAwardOrderByID(int orderID)
		{
			string commandText = "SELECT * FROM AwardOrder WHERE OrderID=" + orderID;
			return base.Database.ExecuteObject<AwardOrder>(commandText);
		}
		public int UpdateOrderState(int state, int orderID, string note)
		{
			string commandText = string.Format("UPDATE dbo.AwardOrder SET OrderStatus={0},SolveDate='{1}',SolveNote='{2}' WHERE OrderID={3}", new object[]
			{
				state,
				System.DateTime.Now,
				note,
				orderID
			});
			return base.Database.ExecuteNonQuery(commandText);
		}
		public int GetNewOrderCounts()
		{
			string commandText = "SELECT COUNT(OrderID) FROM AwardOrder WHERE OrderStatus=0";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj != null)
			{
				return System.Convert.ToInt32(obj);
			}
			return 0;
		}
		public ConfigInfo GetConfigInfo(int configID)
		{
			string commandText = "SELECT * FROM ConfigInfo WHERE ConfigID=@ConfigID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ConfigID", configID));
			return base.Database.ExecuteObject<ConfigInfo>(commandText, list);
		}
		public ConfigInfo GetConfigInfo(string configKey)
		{
			string commandText = "SELECT * FROM ConfigInfo WHERE ConfigKey=@ConfigKey";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ConfigKey", configKey));
			return base.Database.ExecuteObject<ConfigInfo>(commandText, list);
		}
		public void UpdateConfigInfo(ConfigInfo ci)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE ConfigInfo SET ").Append("Field1=@Field1 ,").Append("Field2=@Field2,").Append("Field3=@Field3 ,").Append("Field4=@Field4,").Append("Field5=@Field5,").Append("Field6=@Field6,").Append("Field7=@Field7,").Append("Field8=@Field8, ").Append("ConfigString=@ConfigString").Append(" WHERE ConfigID=@ConfigID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Field1", ci.Field1));
			list.Add(base.Database.MakeInParam("Field2", ci.Field2));
			list.Add(base.Database.MakeInParam("Field3", ci.Field3));
			list.Add(base.Database.MakeInParam("Field4", ci.Field4));
			list.Add(base.Database.MakeInParam("Field5", ci.Field5));
			list.Add(base.Database.MakeInParam("Field6", ci.Field6));
			list.Add(base.Database.MakeInParam("Field7", ci.Field7));
			list.Add(base.Database.MakeInParam("Field8", ci.Field8));
			list.Add(base.Database.MakeInParam("ConfigString", ci.ConfigString));
			list.Add(base.Database.MakeInParam("ConfigID", ci.ConfigID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int GetConfigInfoMinID()
		{
			string commandText = "SELECT ISNULL(MIN(ConfigID),0) FROM ConfigInfo";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj != null)
			{
				return System.Convert.ToInt32(obj);
			}
			return 0;
		}
		public SinglePage GetSinglePage(int pageID)
		{
			string commandText = "SELECT * FROM SinglePage WHERE PageID=@pageID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PageID", pageID));
			return base.Database.ExecuteObject<SinglePage>(commandText, list);
		}
		public SinglePage GetSinglePage(string keyValue)
		{
			string commandText = "SELECT * FROM SinglePage WHERE KeyValue=@KeyValue";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("KeyValue", keyValue));
			return base.Database.ExecuteObject<SinglePage>(commandText, list);
		}
		public int UpdateSinglePage(SinglePage singlePage)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE SinglePage SET ").Append("PageName=@PageName,").Append("KeyWords=@KeyWords,").Append("Description=@Description,").Append("Contents=@Contents").Append(" WHERE PageID=@PageID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PageName", singlePage.PageName));
			list.Add(base.Database.MakeInParam("KeyWords", singlePage.KeyWords));
			list.Add(base.Database.MakeInParam("Description", singlePage.Description));
			list.Add(base.Database.MakeInParam("Contents", singlePage.Contents));
			list.Add(base.Database.MakeInParam("PageID", singlePage.PageID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int GetSinglePageMinID()
		{
			string commandText = "SELECT ISNULL(MIN(PageID),0) FROM SinglePage";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj != null)
			{
				return System.Convert.ToInt32(obj);
			}
			return 0;
		}
		public Ads GetAds(int ID)
		{
			string where = string.Format(" WHERE ID={0}", ID);
			return this.aideAdsProvider.GetObject<Ads>(where);
		}
		public void DeleteAds(string sqlQuery)
		{
			this.aideAdsProvider.Delete(sqlQuery);
		}
		public void InsertAds(Ads ads)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder("SELECT MAX(ID) FROM Ads");
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, stringBuilder.ToString());
			int num = 0;
			if (obj != null)
			{
				num = System.Convert.ToInt32(obj);
			}
			num++;
			stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("INSERT Ads(ID,Title,ResourceURL,LinkURL,Type,SortID,Remark) ").Append("VALUES(@ID,@Title,@ResourceURL,@LinkURL,@Type,@SortID,@Remark)");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", num));
			list.Add(base.Database.MakeInParam("Title", ads.Title));
			list.Add(base.Database.MakeInParam("ResourceURL", ads.ResourceURL));
			list.Add(base.Database.MakeInParam("LinkURL", ads.LinkURL));
			list.Add(base.Database.MakeInParam("Type", ads.Type));
			list.Add(base.Database.MakeInParam("SortID", ads.SortID));
			list.Add(base.Database.MakeInParam("Remark", ads.Remark));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void UpdateAds(Ads ads)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Ads SET ").Append("Title=@Title ,").Append("ResourceURL=@ResourceURL,").Append("LinkUrl= @LinkUrl ,").Append("Type=@Type,").Append("SortID=@SortID,").Append("Remark=@Remark").Append(" WHERE ID= @ID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", ads.ID));
			list.Add(base.Database.MakeInParam("Title", ads.Title));
			list.Add(base.Database.MakeInParam("ResourceURL", ads.ResourceURL));
			list.Add(base.Database.MakeInParam("LinkURL", ads.LinkURL));
			list.Add(base.Database.MakeInParam("Type", ads.Type));
			list.Add(base.Database.MakeInParam("SortID", ads.SortID));
			list.Add(base.Database.MakeInParam("Remark", ads.Remark));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public LossReport GetLossReport(int reportID)
		{
			string where = string.Format(" WHERE ReportID={0}", reportID);
			return this.aideLossReport.GetObject<LossReport>(where);
		}
		public bool UpdateLossReport(LossReport lossReport)
		{
			string commandText = string.Format("UPDATE LossReport SET ProcessStatus={0},SendCount=SendCount+1,SolveDate='{1}',OverDate='{2}' WHERE ReportID={3}", new object[]
			{
				lossReport.ProcessStatus,
				System.DateTime.Now,
				System.DateTime.Now.AddHours(24.0),
				lossReport.ReportID
			});
			return base.Database.ExecuteNonQuery(commandText) > 0;
		}
		public void DeleteActivity(string idList)
		{
			string commandText = string.Format("DELETE Activity WHERE ActivityID IN({0})", idList);
			base.Database.ExecuteNonQuery(commandText);
		}
		public Activity GetActivity(int id)
		{
			string commandText = "SELECT * FROM Activity WHERE ActivityID=@ActivityID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ActivityID", id));
			return base.Database.ExecuteObject<Activity>(commandText, list);
		}
		public void AddActivity(Activity model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("INSERT INTO Activity(Title,ImageUrl,Describe,SortID,IsRecommend) ");
			stringBuilder.Append("VALUES(@Title,@ImageUrl,@Describe,@SortID,@IsRecommend)");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Title", model.Title));
			list.Add(base.Database.MakeInParam("ImageUrl", model.ImageUrl));
			list.Add(base.Database.MakeInParam("Describe", model.Describe));
			list.Add(base.Database.MakeInParam("SortID", model.SortID));
			list.Add(base.Database.MakeInParam("IsRecommend", model.IsRecommend));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void UpdateActivity(Activity model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Activity SET Title=@Title,ImageUrl=@ImageUrl,Describe=@Describe,SortID=@SortID,IsRecommend=@IsRecommend ");
			stringBuilder.Append("WHERE ActivityID=@ActivityID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Title", model.Title));
			list.Add(base.Database.MakeInParam("ImageUrl", model.ImageUrl));
			list.Add(base.Database.MakeInParam("Describe", model.Describe));
			list.Add(base.Database.MakeInParam("SortID", model.SortID));
			list.Add(base.Database.MakeInParam("ActivityID", model.ActivityID));
			list.Add(base.Database.MakeInParam("IsRecommend", model.IsRecommend));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
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
		public GameAccuseInfo GetGameAccuseInfo(int accuseID)
		{
			string commandText = "SELECT * FROM View_GameAccuseInfo WHERE AccuseID=" + accuseID;
			return base.Database.ExecuteObject<GameAccuseInfo>(commandText);
		}
		public int UpdateReport(int id, string body, string admin)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameAccuseInfo SET ").Append("DealerMark=@DealerMark ,").Append("Dealer=@Dealer,").Append("DealTime=getdate()").Append(" WHERE AccuseID= @AccuseID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("AccuseID", id));
			list.Add(base.Database.MakeInParam("DealerMark", body));
			list.Add(base.Database.MakeInParam("Dealer", admin));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public int GetUnDoGameFeedbackInfoCount()
		{
			string commandText = "select count(FeedbackID) from GameFeedbackInfo where IsProcessed=0";
			return System.Convert.ToInt32(base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText));
		}
		public int AddPlatformDraw(PlatformDraw model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("INSERT T_PlatformDraw(OrderID,FlowID,RealName,BankName,BankNo,BankAddr,DrawAmt,Operator,OperateIP)").Append("VALUES(@OrderID,@FlowID,@RealName,@BankName,@BankNo,@BankAddr,@DrawAmt,@Operator,@OperateIP)");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("OrderID", model.OrderID));
			list.Add(base.Database.MakeInParam("FlowID", model.FlowID));
			list.Add(base.Database.MakeInParam("RealName", model.RealName));
			list.Add(base.Database.MakeInParam("BankName", model.BankName));
			list.Add(base.Database.MakeInParam("BankNo", model.BankNo));
			list.Add(base.Database.MakeInParam("BankAddr", model.BankAddr));
			list.Add(base.Database.MakeInParam("DrawAmt", model.DrawAmt));
			list.Add(base.Database.MakeInParam("Operator", model.Operator));
			list.Add(base.Database.MakeInParam("OperateIP", model.OperateIP));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
	}
}
