using Game.Data.Factory;
using Game.Entity.Platform;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
namespace Game.Facade
{
	public class PlatformFacade
	{
		private IPlatformDataProvider aidePlatformData;
		public PlatformFacade()
		{
			this.aidePlatformData = ClassFactory.GetIPlatformDataProvider();
		}
		public PagerSet GetDataBaseList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetDataBaseList(pageIndex, pageSize, condition, orderby);
		}
		public DataBaseInfo GetDataBaseInfo(int dBInfoID)
		{
			return this.aidePlatformData.GetDataBaseInfo(dBInfoID);
		}
		public DataBaseInfo GetDataBaseInfo(string dBAddr)
		{
			return this.aidePlatformData.GetDataBaseInfo(dBAddr);
		}
		public Message InsertDataBase(DataBaseInfo dataBase)
		{
			this.aidePlatformData.InsertDataBase(dataBase);
			return new Message(true);
		}
		public Message UpdateDataBase(DataBaseInfo dataBase)
		{
			this.aidePlatformData.UpdateDataBase(dataBase);
			return new Message(true);
		}
		public void DeleteDataBase(string sqlQuery)
		{
			this.aidePlatformData.DeleteDataBase(sqlQuery);
		}
		public bool IsExistsDBAddr(string address)
		{
			return this.GetDataBaseInfo(address) != null;
		}
		public PagerSet GetGameGameItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGameGameItemList(pageIndex, pageSize, condition, orderby);
		}
		public GameGameItem GetGameGameItemInfo(int gameID)
		{
			return this.aidePlatformData.GetGameGameItemInfo(gameID);
		}
		public int GetMaxGameGameID()
		{
			return this.aidePlatformData.GetMaxGameGameID();
		}
		public Message InsertGameGameItem(GameGameItem gameGameItem)
		{
			this.aidePlatformData.InsertGameGameItem(gameGameItem);
			return new Message(true);
		}
		public Message UpdateGameGameItem(GameGameItem gameGameItem)
		{
			this.aidePlatformData.UpdateGameGameItem(gameGameItem);
			return new Message(true);
		}
		public void DeleteGameGameItem(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameGameItem(sqlQuery);
		}
		public bool IsExistsGameID(int gameID)
		{
			return this.GetGameGameItemInfo(gameID) != null;
		}
		public PagerSet GetGameTypeItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGameTypeItemList(pageIndex, pageSize, condition, orderby);
		}
		public GameTypeItem GetGameTypeItemInfo(int typeID)
		{
			return this.aidePlatformData.GetGameTypeItemInfo(typeID);
		}
		public int GetMaxGameTypeID()
		{
			return this.aidePlatformData.GetMaxGameTypeID();
		}
		public Message InsertGameTypeItem(GameTypeItem gameTypeItem)
		{
			this.aidePlatformData.InsertGameTypeItem(gameTypeItem);
			return new Message(true);
		}
		public Message UpdateGameTypeItem(GameTypeItem gameTypeItem)
		{
			this.aidePlatformData.UpdateGameTypeItem(gameTypeItem);
			return new Message(true);
		}
		public void DeleteGameTypeItem(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameTypeItem(sqlQuery);
		}
		public bool IsExistsTypeID(int typeID)
		{
			return this.GetGameTypeItemInfo(typeID) != null;
		}
		public System.Collections.Generic.IList<GameKindItem> GetGameList(int typeId)
		{
			return this.aidePlatformData.GetGameList(typeId);
		}
		public PagerSet GetGameNodeItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGameNodeItemList(pageIndex, pageSize, condition, orderby);
		}
		public GameNodeItem GetGameNodeItemInfo(int nodeID)
		{
			return this.aidePlatformData.GetGameNodeItemInfo(nodeID);
		}
		public int GetMaxGameNodeID()
		{
			return this.aidePlatformData.GetMaxGameNodeID();
		}
		public Message InsertGameNodeItem(GameNodeItem gameNodeItem)
		{
			this.aidePlatformData.InsertGameNodeItem(gameNodeItem);
			return new Message(true);
		}
		public Message UpdateGameNodeItem(GameNodeItem gameNodeItem)
		{
			this.aidePlatformData.UpdateGameNodeItem(gameNodeItem);
			return new Message(true);
		}
		public void DeleteGameNodeItem(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameNodeItem(sqlQuery);
		}
		public bool IsExistsNodeID(int nodeID)
		{
			return this.GetGameNodeItemInfo(nodeID) != null;
		}
		public PagerSet GetGamePageItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGamePageItemList(pageIndex, pageSize, condition, orderby);
		}
		public GamePageItem GetGamePageItemInfo(int pageID)
		{
			return this.aidePlatformData.GetGamePageItemInfo(pageID);
		}
		public int GetMaxGamePageID()
		{
			return this.aidePlatformData.GetMaxGamePageID();
		}
		public Message InsertGamePageItem(GamePageItem gamePageItem)
		{
			this.aidePlatformData.InsertGamePageItem(gamePageItem);
			return new Message(true);
		}
		public Message UpdateGamePageItem(GamePageItem gamePageItem)
		{
			this.aidePlatformData.UpdateGamePageItem(gamePageItem);
			return new Message(true);
		}
		public void DeleteGamePageItem(string sqlQuery)
		{
			this.aidePlatformData.DeleteGamePageItem(sqlQuery);
		}
		public bool IsExistsPageID(int pageID)
		{
			return this.GetGamePageItemInfo(pageID) != null;
		}
		public DataSet GetGameList()
		{
			return this.aidePlatformData.GetGameList();
		}
		public PagerSet GetGameKindItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGameKindItemList(pageIndex, pageSize, condition, orderby);
		}
		public GameKindItem GetGameKindItemInfo(int kindID)
		{
			return this.aidePlatformData.GetGameKindItemInfo(kindID);
		}
		public int GetMaxGameKindID()
		{
			return this.aidePlatformData.GetMaxGameKindID();
		}
		public Message InsertGameKindItem(GameKindItem gameKindItem)
		{
			this.aidePlatformData.InsertGameKindItem(gameKindItem);
			return new Message(true);
		}
		public Message UpdateGameKindItem(GameKindItem gameKindItem)
		{
			this.aidePlatformData.UpdateGameKindItem(gameKindItem);
			return new Message(true);
		}
		public void DeleteGameKindItem(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameKindItem(sqlQuery);
		}
		public bool IsExistsKindID(int kindID)
		{
			return this.GetGameKindItemInfo(kindID) != null;
		}
		public void UpdateGameConfig(GameConfig gameConfig)
		{
			this.aidePlatformData.UpdateGameConfig(gameConfig);
		}
		public GameConfig GetGameConfig(int kindID)
		{
			return this.aidePlatformData.GetGameConfig(kindID);
		}
		public DataTable GameList()
		{
			string sql = "SELECT KindID,KindName,WebTypeID FROM GameKindItem where Nullity=0";
			return this.aidePlatformData.GetDataSetBySql(sql).Tables[0];
		}
		public PagerSet GetMobileKindItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetMobileKindItemList(pageIndex, pageSize, condition, orderby);
		}
		public MobileKindItem GetMobileKindItemInfo(int kindID)
		{
			return this.aidePlatformData.GetMobileKindItemInfo(kindID);
		}
		public int GetMaxMobileKindID()
		{
			return this.aidePlatformData.GetMaxMobileKindID();
		}
		public Message InsertMobileKindItem(MobileKindItem model)
		{
			Message result;
			try
			{
				this.aidePlatformData.InsertMobileKindItem(model);
				result = new Message(true);
			}
			catch
			{
				result = new Message(false);
			}
			return result;
		}
		public Message UpdateMobileKindItem(MobileKindItem model)
		{
			Message result;
			try
			{
				this.aidePlatformData.UpdateMobileKindItem(model);
				result = new Message(true);
			}
			catch
			{
				result = new Message(false);
			}
			return result;
		}
		public Message DeleteMobileKindItem(string sqlQuery)
		{
			Message result;
			try
			{
				this.aidePlatformData.DeleteMobileKindItem(sqlQuery);
				result = new Message(true);
			}
			catch
			{
				result = new Message(false);
			}
			return result;
		}
		public PagerSet GetGameRoomInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGameRoomInfoList(pageIndex, pageSize, condition, orderby);
		}
		public GameRoomInfo GetGameRoomInfoInfo(int serverID)
		{
			return this.aidePlatformData.GetGameRoomInfoInfo(serverID);
		}
		public Message InsertGameRoomInfo(GameRoomInfo gameRoomInfo)
		{
			this.aidePlatformData.InsertGameRoomInfo(gameRoomInfo);
			return new Message(true);
		}
		public Message UpdateGameRoomInfo(GameRoomInfo gameRoomInfo)
		{
			this.aidePlatformData.UpdateGameRoomInfo(gameRoomInfo);
			return new Message(true);
		}
		public void DeleteGameRoomInfo(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameRoomInfo(sqlQuery);
		}
		public DataTable GetRoomList(int kid)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT ServerID,ServerName,KindID FROM GameRoomInfo WHERE Nullity=0 ");
			if (kid > 0)
			{
				stringBuilder.AppendFormat(" AND KindID={0}", kid);
			}
			return this.aidePlatformData.GetDataSetBySql(stringBuilder.ToString()).Tables[0];
		}
		public DataSet GetOnLineStreamInfoList(string year, string month, string day)
		{
			string text;
			if (month == "-1")
			{
				text = "select CONVERT(varchar(7),InsertDateTime, 120) as InsertDateTime,max(OnLineCountSum) as MaxCount,min(OnLineCountSum) as MinCount,";
				text += "convert(int,round(avg(OnLineCountSum*1.0),0)) as AvgCount from OnLineStreamInfo ";
				text = text + "where year(InsertDateTime)='" + year + "' group by CONVERT(varchar(7),InsertDateTime, 120) order by InsertDateTime asc";
			}
			else
			{
				if (day == "-1")
				{
					System.DateTime dateTime = System.Convert.ToDateTime(year + "-" + month + "-01");
					System.DateTime dateTime2 = dateTime.AddMonths(1);
					text = "select CONVERT(varchar(10),InsertDateTime, 120) as InsertDateTime,max(OnLineCountSum) as MaxCount,min(OnLineCountSum) as MinCount,";
					text += "convert(int,round(avg(OnLineCountSum*1.0),0)) as AvgCount from OnLineStreamInfo ";
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						"where InsertDateTime>'",
						dateTime.ToString(),
						"' and InsertDateTime<'",
						dateTime2.ToString(),
						"' group by CONVERT(varchar(10),InsertDateTime, 120) order by InsertDateTime asc"
					});
				}
				else
				{
					string str = string.Concat(new string[]
					{
						year,
						"-",
						month,
						"-",
						day
					});
					text = "select datepart(hh,InsertDateTime) as InsertDateTime,max(OnLineCountSum) as MaxCount,min(OnLineCountSum) as MinCount,";
					text += "convert(int,round(avg(OnLineCountSum*1.0),0)) as AvgCount from OnLineStreamInfo ";
					text = text + "where convert(varchar(10),InsertDateTime,120)='" + str + "' group by datepart(hh,InsertDateTime) order by InsertDateTime asc";
				}
			}
			return this.aidePlatformData.GetOnLineStreamInfoList(text);
		}
		public DataSet GetOnlineStreamGameInfoList(string year, string month, string day, string hour)
		{
			string sqlQuery;
			if (day == "-1")
			{
				System.DateTime dateTime = System.Convert.ToDateTime(year + "-" + month + "-01");
				System.DateTime dateTime2 = dateTime.AddMonths(1);
				sqlQuery = string.Concat(new string[]
				{
					"select * from OnLineStreamInfo where InsertDateTime>'",
					dateTime.ToString(),
					"' and InsertDateTime<'",
					dateTime2.ToString(),
					"' order by InsertDateTime asc"
				});
			}
			else
			{
				if (hour == "-1")
				{
					string str = string.Concat(new string[]
					{
						year,
						"-",
						month,
						"-",
						day
					});
					sqlQuery = "select * from OnLineStreamInfo where convert(varchar(10),InsertDateTime,120)='" + str + "' order by InsertDateTime asc";
				}
				else
				{
					string text = string.Concat(new string[]
					{
						year,
						"-",
						month,
						"-",
						day
					});
					sqlQuery = string.Concat(new string[]
					{
						"select * from OnLineStreamInfo where convert(varchar(10),InsertDateTime,120)='",
						text,
						"' and datepart(hh,InsertDateTime)='",
						hour,
						"' order by InsertDateTime asc"
					});
				}
			}
			return this.aidePlatformData.GetOnLineStreamInfoList(sqlQuery);
		}
		public PagerSet GetOnLineStreamInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetOnLineStreamInfoList(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetSystemMessageList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetSystemMessageList(pageIndex, pageSize, condition, orderby);
		}
		public SystemMessage GetSystemMessageInfo(int id)
		{
			return this.aidePlatformData.GetSystemMessageInfo(id);
		}
		public Message InsertSystemMessage(SystemMessage systemMessage)
		{
			this.aidePlatformData.InsertSystemMessage(systemMessage);
			return new Message(true);
		}
		public Message UpdateSystemMessage(SystemMessage systemMessage)
		{
			this.aidePlatformData.UpdateSystemMessage(systemMessage);
			return new Message(true);
		}
		public void DeleteSystemMessage(string sqlQuery)
		{
			this.aidePlatformData.DeleteSystemMessage(sqlQuery);
		}
		public PagerSet GetGlobalPlayPresentList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGlobalPlayPresentList(pageIndex, pageSize, condition, orderby);
		}
		public GlobalPlayPresent GetGlobalPlayPresentInfo(int serverID)
		{
			return this.aidePlatformData.GetGlobalPlayPresentInfo(serverID);
		}
		public Message InsertGlobalPlayPresent(GlobalPlayPresent globalPlayPresent)
		{
			this.aidePlatformData.InsertGlobalPlayPresent(globalPlayPresent);
			return new Message(true);
		}
		public Message UpdateGlobalPlayPresent(GlobalPlayPresent globalPlayPresent)
		{
			this.aidePlatformData.UpdateGlobalPlayPresent(globalPlayPresent);
			return new Message(true);
		}
		public void DeleteGlobalPlayPresent(string sqlQuery)
		{
			this.aidePlatformData.DeleteGlobalPlayPresent(sqlQuery);
		}
		public TaskInfo GetTaskInfoByID(int id)
		{
			return this.aidePlatformData.GetTaskInfoByID(id);
		}
		public bool InsertTaskInfo(TaskInfo info)
		{
			this.aidePlatformData.InsertTaskInfo(info);
			return true;
		}
		public bool UpdateTaskInfo(TaskInfo info)
		{
			int num = this.aidePlatformData.UpdateTaskInfo(info);
			return num > 0;
		}
		public void DeleteTaskInfo(string sqlQuery)
		{
			this.aidePlatformData.DeleteTaskInfo(sqlQuery);
		}
		public void JinyongTask(int id, int value)
		{
			string sql = string.Concat(new object[]
			{
				"Update TaskInfo Set Nullity=",
				value,
				" Where TaskID=",
				id
			});
			this.aidePlatformData.ExecuteSql(sql);
		}
		public DataSet GetSigninConfig()
		{
			return this.aidePlatformData.GetSigninConfig();
		}
		public void UpdateSigninConfig(DataSet ds)
		{
			this.aidePlatformData.UpdateSigninConfig(ds);
		}
		public int UpdateGrowLevelConfig(GrowLevelConfig glc)
		{
			return this.aidePlatformData.UpdateGrowLevelConfig(glc);
		}
		public PagerSet GetGamePropertyTypeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGamePropertyTypeList(pageIndex, pageSize, condition, orderby);
		}
		public GamePropertyType GetGamePropertyTypeInfo(int typeID)
		{
			return this.aidePlatformData.GetGamePropertyTypeInfo(typeID);
		}
		public int GetMaxPropertyTypeID()
		{
			return this.aidePlatformData.GetMaxPropertyTypeID();
		}
		public Message InsertGamePropertyType(GamePropertyType gamePropertyType)
		{
			this.aidePlatformData.InsertGamePropertyType(gamePropertyType);
			return new Message(true);
		}
		public Message UpdateGamePropertyType(GamePropertyType gamePropertyType)
		{
			this.aidePlatformData.UpdateGamePropertyType(gamePropertyType);
			return new Message(true);
		}
		public void DeleteGamePropertyType(string sqlQuery)
		{
			this.aidePlatformData.DeleteGamePropertyType(sqlQuery);
		}
		public PagerSet GetGamePropertyList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetGamePropertyList(pageIndex, pageSize, condition, orderby);
		}
		public System.Collections.Generic.IList<GameProperty> GetGamePropertyGift(int kind)
		{
			return this.aidePlatformData.GetGamePropertyGift(kind);
		}
		public GameProperty GetGamePropertyInfo(int id)
		{
			return this.aidePlatformData.GetGamePropertyInfo(id);
		}
		public int GetMaxPropertyID()
		{
			return this.aidePlatformData.GetMaxPropertyID();
		}
		public void InsertGameProperty(GameProperty property)
		{
			this.aidePlatformData.InsertGameProperty(property);
		}
		public void UpdateGameProperty(GameProperty property)
		{
			this.aidePlatformData.UpdateGameProperty(property);
		}
		public void DeleteGameProperty(string sqlQuery)
		{
			this.aidePlatformData.DeleteGameProperty(sqlQuery);
		}
		public void SetPropertyDisbale(string sqlQuery)
		{
			this.aidePlatformData.SetPropertyDisbale(sqlQuery);
		}
		public void SetPropertyEnbale(string sqlQuery)
		{
			this.aidePlatformData.SetPropertyEnbale(sqlQuery);
		}
		public void SetPropertyRecommend(int recommend, string sqlQuery)
		{
			this.aidePlatformData.SetPropertyRecommend(recommend, sqlQuery);
		}
		public GamePropertySub GetGamePropertySubInfo(int id, int ownerID)
		{
			return this.aidePlatformData.GetGamePropertySubInfo(id, ownerID);
		}
		public void InsertGamePropertySub(GamePropertySub property)
		{
			this.aidePlatformData.InsertGamePropertySub(property);
		}
		public void UpdateGamePropertySub(GamePropertySub property)
		{
			this.aidePlatformData.UpdateGamePropertySub(property);
		}
		public void DeleteGamePropertySub(string sqlQuery)
		{
			this.aidePlatformData.DeleteGamePropertySub(sqlQuery);
		}
		public string GetConn(int kindID)
		{
			return this.aidePlatformData.GetConn(kindID);
		}
		public Message AppStatOnline(string accounts, string logonPass, string machineID)
		{
			return this.aidePlatformData.AppStatOnline(accounts, logonPass, machineID);
		}
		public Message AppPlatformGeneral(string accounts, string logonPass, string machineID)
		{
			return this.aidePlatformData.AppPlatformGeneral(accounts, logonPass, machineID);
		}
		public Message AppStatUserOnline(string accounts, string logonPass, string machineID)
		{
			return this.aidePlatformData.AppStatUserOnline(accounts, logonPass, machineID);
		}
		public Message AppGetOnlineData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			return this.aidePlatformData.AppGetOnlineData(accounts, logonPass, machineID, dateType, startDate, endDate);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public int ExecuteSql(string sql)
		{
			return this.aidePlatformData.ExecuteSql(sql);
		}
		public void UpdateCount(int kid, int sid, int count)
		{
			string text = string.Concat(new object[]
			{
				"UPDATE OnlineCount SET AddCounts=",
				count,
				" where ServerID=",
				sid
			});
			object obj = text;
			text = string.Concat(new object[]
			{
				obj,
				";if @@ROWCOUNT=0 INSERT OnlineCount(KindID,ServerID,AddCounts) VALUES(",
				kid,
				",",
				sid,
				",",
				count,
				") "
			});
			this.aidePlatformData.ExecuteSql(text);
		}
		public DataTable GetOnlineCount(int sid)
		{
			string sql = "SELECT * FROM OnlineCount WHERE ServerID=" + sid;
			return this.aidePlatformData.GetDataSetBySql(sql).Tables[0];
		}
		public void DeleteOnlineCount(string sWhere)
		{
			string sql = "DELETE OnlineCount " + sWhere;
			this.aidePlatformData.ExecuteSql(sql);
		}
	}
}
