using Game.Entity.Platform;
using Game.IData;
using Game.Kernel;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class PlatformDataProvider : BaseDataProvider, IPlatformDataProvider
	{
		private ITableProvider aideDataBaseInfoProvider;
		private ITableProvider aideGameGameItemProvider;
		private ITableProvider aideGameTypeItemProvider;
		private ITableProvider aideGameKindItemProvider;
		private ITableProvider aideGameNodeItemProvider;
		private ITableProvider aideGamePageItemProvider;
		private ITableProvider aideGameRoomInfoProvider;
		private ITableProvider aideSystemMessageProvider;
		private ITableProvider aideGlobalPlayPresentProvider;
		private ITableProvider aideGameConfigProvider;
		private ITableProvider aideTaskInfoProvider;
		private ITableProvider aideGamePropertyProvider;
		private ITableProvider aideGamePropertySubProvider;
		private ITableProvider aideGamePropertyTypeProvider;
		private ITableProvider aideMobileKindItemProvider;
		public PlatformDataProvider(string connString) : base(connString)
		{
			this.aideDataBaseInfoProvider = this.GetTableProvider("DataBaseInfo");
			this.aideGameGameItemProvider = this.GetTableProvider("GameGameItem");
			this.aideGameTypeItemProvider = this.GetTableProvider("GameTypeItem");
			this.aideGameKindItemProvider = this.GetTableProvider("GameKindItem");
			this.aideGameNodeItemProvider = this.GetTableProvider("GameNodeItem");
			this.aideGamePageItemProvider = this.GetTableProvider("GamePageItem");
			this.aideGameRoomInfoProvider = this.GetTableProvider("GameRoomInfo");
			this.aideSystemMessageProvider = this.GetTableProvider("SystemMessage");
			this.aideGlobalPlayPresentProvider = this.GetTableProvider("GlobalPlayPresent");
			this.aideGameConfigProvider = this.GetTableProvider("GameConfig");
			this.aideTaskInfoProvider = this.GetTableProvider("TaskInfo");
			this.aideGamePropertyProvider = this.GetTableProvider("GameProperty");
			this.aideGamePropertySubProvider = this.GetTableProvider("GamePropertySub");
			this.aideGamePropertyTypeProvider = this.GetTableProvider("GamePropertyType");
			this.aideMobileKindItemProvider = this.GetTableProvider("MobileKindItem");
		}
		public string GetConn(int kindID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			GameKindItem gameKindItemInfo = this.GetGameKindItemInfo(kindID);
			if (gameKindItemInfo == null)
			{
				return "";
			}
			GameGameItem gameGameItemInfo = this.GetGameGameItemInfo(gameKindItemInfo.GameID);
			if (gameGameItemInfo == null)
			{
				return "";
			}
			DataBaseInfo dataBaseInfo = this.GetDataBaseInfo(gameGameItemInfo.DataBaseAddr);
			if (dataBaseInfo == null)
			{
				return "";
			}
			string text = CWHEncryptNet.XorCrevasse(dataBaseInfo.DBUser);
			string text2 = CWHEncryptNet.XorCrevasse(dataBaseInfo.DBPassword);
			stringBuilder.AppendFormat("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Pooling=true", new object[]
			{
				gameGameItemInfo.DataBaseAddr + (string.IsNullOrEmpty(dataBaseInfo.DBPort.ToString()) ? "" : ("," + dataBaseInfo.DBPort.ToString())),
				gameGameItemInfo.DataBaseName,
				text,
				text2
			});
			return stringBuilder.ToString();
		}
		public PagerSet GetDataBaseList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("DataBaseInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public DataBaseInfo GetDataBaseInfo(int dBInfoID)
		{
			string where = string.Format("(NOLOCK) WHERE DBInfoID= {0}", dBInfoID);
			return this.aideDataBaseInfoProvider.GetObject<DataBaseInfo>(where);
		}
		public DataBaseInfo GetDataBaseInfo(string dBAddr)
		{
			string where = string.Format("(NOLOCK) WHERE DBAddr= '{0}'", dBAddr);
			return this.aideDataBaseInfoProvider.GetObject<DataBaseInfo>(where);
		}
		public void InsertDataBase(DataBaseInfo dataBase)
		{
			System.Data.DataRow dataRow = this.aideDataBaseInfoProvider.NewRow();
			dataRow["DBAddr"] = dataBase.DBAddr;
			dataRow["DBPort"] = dataBase.DBPort;
			dataRow["DBUser"] = dataBase.DBUser;
			dataRow["DBPassword"] = dataBase.DBPassword;
			dataRow["MachineID"] = dataBase.MachineID;
			dataRow["Information"] = dataBase.Information;
			this.aideDataBaseInfoProvider.Insert(dataRow);
		}
		public void UpdateDataBase(DataBaseInfo dataBase)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE DataBaseInfo SET ").Append("DBAddr=@DBAddr, ").Append("DBPort=@DBPort, ").Append("DBUser=@DBUser, ");
			if (!string.IsNullOrEmpty(dataBase.DBPassword))
			{
				stringBuilder.Append("DBPassword=@DBPassword, ");
			}
			stringBuilder.Append("MachineID=@MachineID, ").Append("Information=@Information ").Append("WHERE DBInfoID=@DBInfoID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("DBAddr", dataBase.DBAddr));
			list.Add(base.Database.MakeInParam("DBPort", dataBase.DBPort));
			list.Add(base.Database.MakeInParam("DBUser", dataBase.DBUser));
			list.Add(base.Database.MakeInParam("DBPassword", dataBase.DBPassword));
			list.Add(base.Database.MakeInParam("MachineID", dataBase.MachineID));
			list.Add(base.Database.MakeInParam("Information", dataBase.Information));
			list.Add(base.Database.MakeInParam("DBInfoID", dataBase.DBInfoID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteDataBase(string sqlQuery)
		{
			this.aideDataBaseInfoProvider.Delete(sqlQuery);
		}
		public PagerSet GetGameGameItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameGameItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameGameItem GetGameGameItemInfo(int gameID)
		{
			string where = string.Format("(NOLOCK) WHERE GameID= {0}", gameID);
			return this.aideGameGameItemProvider.GetObject<GameGameItem>(where);
		}
		public int GetMaxGameGameID()
		{
			string commandText = "SELECT MAX(GameID) FROM GameGameItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGameGameItem(GameGameItem gameGameItem)
		{
			System.Data.DataRow dataRow = this.aideGameGameItemProvider.NewRow();
			dataRow["GameID"] = gameGameItem.GameID;
			dataRow["GameName"] = gameGameItem.GameName;
			dataRow["SuportType"] = gameGameItem.SuportType;
			dataRow["DataBaseAddr"] = gameGameItem.DataBaseAddr;
			dataRow["DataBaseName"] = gameGameItem.DataBaseName;
			dataRow["ServerVersion"] = gameGameItem.ServerVersion;
			dataRow["ClientVersion"] = gameGameItem.ClientVersion;
			dataRow["ServerDLLName"] = gameGameItem.ServerDLLName;
			dataRow["ClientExeName"] = gameGameItem.ClientExeName;
			this.aideGameGameItemProvider.Insert(dataRow);
		}
		public void UpdateGameGameItem(GameGameItem gameGameItem)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameGameItem SET ").Append("GameName=@GameName, ").Append("SuportType=@SuporType, ").Append("DataBaseAddr=@DataBaseAddr, ").Append("DataBaseName=@DataBaseName, ").Append("ServerVersion=@ServerVersion, ").Append("ClientVersion=@ClientVersion, ").Append("ServerDLLName=@ServerDLLName, ").Append("ClientExeName=@ClientExeName ").Append("WHERE GameID=@GameID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("GameName", gameGameItem.GameName));
			list.Add(base.Database.MakeInParam("SuporType", gameGameItem.SuportType));
			list.Add(base.Database.MakeInParam("DataBaseAddr", gameGameItem.DataBaseAddr));
			list.Add(base.Database.MakeInParam("DataBaseName", gameGameItem.DataBaseName));
			list.Add(base.Database.MakeInParam("ServerVersion", gameGameItem.ServerVersion));
			list.Add(base.Database.MakeInParam("ClientVersion", gameGameItem.ClientVersion));
			list.Add(base.Database.MakeInParam("ServerDLLName", gameGameItem.ServerDLLName));
			list.Add(base.Database.MakeInParam("ClientExeName", gameGameItem.ClientExeName));
			list.Add(base.Database.MakeInParam("GameID", gameGameItem.GameID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameGameItem(string sqlQuery)
		{
			this.aideGameGameItemProvider.Delete(sqlQuery);
		}
		public PagerSet GetGameTypeItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameTypeItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameTypeItem GetGameTypeItemInfo(int typeID)
		{
			string where = string.Format("(NOLOCK) WHERE TypeID= {0}", typeID);
			return this.aideGameTypeItemProvider.GetObject<GameTypeItem>(where);
		}
		public int GetMaxGameTypeID()
		{
			string commandText = "SELECT MAX(TypeID) FROM GameTypeItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGameTypeItem(GameTypeItem gameTypeItem)
		{
			System.Data.DataRow dataRow = this.aideGameTypeItemProvider.NewRow();
			dataRow["TypeID"] = gameTypeItem.TypeID;
			dataRow["SortID"] = gameTypeItem.SortID;
			dataRow["TypeName"] = gameTypeItem.TypeName;
			dataRow["JoinID"] = gameTypeItem.JoinID;
			dataRow["Nullity"] = gameTypeItem.Nullity;
			this.aideGameTypeItemProvider.Insert(dataRow);
		}
		public void UpdateGameTypeItem(GameTypeItem gameTypeItem)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameTypeItem SET ").Append("SortID=@SortID, ").Append("TypeName=@TypeName, ").Append("JoinID=@JoinID, ").Append("Nullity=@Nullity ").Append("WHERE TypeID=@TypeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TypeID", gameTypeItem.TypeID));
			list.Add(base.Database.MakeInParam("SortID", gameTypeItem.SortID));
			list.Add(base.Database.MakeInParam("TypeName", gameTypeItem.TypeName));
			list.Add(base.Database.MakeInParam("JoinID", gameTypeItem.JoinID));
			list.Add(base.Database.MakeInParam("Nullity", gameTypeItem.Nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameTypeItem(string sqlQuery)
		{
			this.aideGameTypeItemProvider.Delete(sqlQuery);
		}
		public System.Collections.Generic.IList<GameKindItem> GetGameList(int typeId)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("SELECT KindID,KindName,TypeID ").Append("FROM GameKindItem ").Append("WHERE Nullity=0 ");
			if (typeId > 0)
			{
				stringBuilder.AppendFormat(" AND WebTypeID={0} ", typeId).Append(" ORDER By SortID ASC,KindID ASC");
			}
			return base.Database.ExecuteObjectList<GameKindItem>(stringBuilder.ToString());
		}
		public PagerSet GetGameNodeItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameNodeItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameNodeItem GetGameNodeItemInfo(int nodeID)
		{
			string where = string.Format("(NOLOCK) WHERE NodeID= {0}", nodeID);
			return this.aideGameNodeItemProvider.GetObject<GameNodeItem>(where);
		}
		public int GetMaxGameNodeID()
		{
			string commandText = "SELECT MAX(NodeID) FROM GameNodeItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGameNodeItem(GameNodeItem gameNodeItem)
		{
			System.Data.DataRow dataRow = this.aideGameNodeItemProvider.NewRow();
			dataRow["NodeID"] = gameNodeItem.NodeID;
			dataRow["KindID"] = gameNodeItem.KindID;
			dataRow["JoinID"] = gameNodeItem.JoinID;
			dataRow["SortID"] = gameNodeItem.SortID;
			dataRow["NodeName"] = gameNodeItem.NodeName;
			dataRow["Nullity"] = gameNodeItem.Nullity;
			this.aideGameNodeItemProvider.Insert(dataRow);
		}
		public void UpdateGameNodeItem(GameNodeItem gameNodeItem)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameNodeItem SET ").Append("KindID=@KindID, ").Append("JoinID=@JoinID, ").Append("SortID=@SortID, ").Append("NodeName=@NodeName, ").Append("Nullity=@Nullity ").Append("WHERE NodeID=@NodeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("NodeID", gameNodeItem.NodeID));
			list.Add(base.Database.MakeInParam("KindID", gameNodeItem.KindID));
			list.Add(base.Database.MakeInParam("JoinID", gameNodeItem.JoinID));
			list.Add(base.Database.MakeInParam("SortID", gameNodeItem.SortID));
			list.Add(base.Database.MakeInParam("NodeName", gameNodeItem.NodeName));
			list.Add(base.Database.MakeInParam("Nullity", gameNodeItem.Nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameNodeItem(string sqlQuery)
		{
			this.aideGameNodeItemProvider.Delete(sqlQuery);
		}
		public PagerSet GetGamePageItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GamePageItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GamePageItem GetGamePageItemInfo(int pageID)
		{
			string where = string.Format("(NOLOCK) WHERE PageID= {0}", pageID);
			return this.aideGamePageItemProvider.GetObject<GamePageItem>(where);
		}
		public int GetMaxGamePageID()
		{
			string commandText = "SELECT MAX(PageID) FROM GamePageItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGamePageItem(GamePageItem gamePageItem)
		{
			System.Data.DataRow dataRow = this.aideGamePageItemProvider.NewRow();
			dataRow["PageID"] = gamePageItem.PageID;
			dataRow["NodeID"] = gamePageItem.NodeID;
			dataRow["KindID"] = gamePageItem.KindID;
			dataRow["SortID"] = gamePageItem.SortID;
			dataRow["OperateType"] = gamePageItem.OperateType;
			dataRow["DisplayName"] = gamePageItem.DisplayName;
			dataRow["ResponseUrl"] = gamePageItem.ResponseUrl;
			dataRow["Nullity"] = gamePageItem.Nullity;
			this.aideGamePageItemProvider.Insert(dataRow);
		}
		public void UpdateGamePageItem(GamePageItem gamePageItem)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GamePageItem SET ").Append("NodeID=@NodeID, ").Append("KindID=@KindID, ").Append("SortID=@SortID, ").Append("OperateType=@OperateType, ").Append("DisplayName=@DisplayName, ").Append("ResponseUrl=@ResponseUrl, ").Append("Nullity=@Nullity ").Append("WHERE PageID=@PageID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PageID", gamePageItem.PageID));
			list.Add(base.Database.MakeInParam("NodeID", gamePageItem.NodeID));
			list.Add(base.Database.MakeInParam("KindID", gamePageItem.KindID));
			list.Add(base.Database.MakeInParam("SortID", gamePageItem.SortID));
			list.Add(base.Database.MakeInParam("OperateType", gamePageItem.OperateType));
			list.Add(base.Database.MakeInParam("DisplayName", gamePageItem.DisplayName));
			list.Add(base.Database.MakeInParam("ResponseUrl", gamePageItem.ResponseUrl));
			list.Add(base.Database.MakeInParam("Nullity", gamePageItem.Nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGamePageItem(string sqlQuery)
		{
			this.aideGamePageItemProvider.Delete(sqlQuery);
		}
		public System.Data.DataSet GetGameList()
		{
			string commandText = " SELECT a.KindID,a.KindName FROM GameKindItem a INNER JOIN GameGameItem b ON a.GameID=b.GameID\r\n                                WHERE b.DataBaseName<>'RYTreasureDB' ORDER BY KindID ASC";
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public PagerSet GetGameKindItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameKindItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameKindItem GetGameKindItemInfo(int kindID)
		{
			string where = string.Format("(NOLOCK) WHERE KindID= {0}", kindID);
			return this.aideGameKindItemProvider.GetObject<GameKindItem>(where);
		}
		public int GetMaxGameKindID()
		{
			string commandText = "SELECT MAX(KindID) FROM GameKindItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGameKindItem(GameKindItem gameKindItem)
		{
			System.Data.DataRow dataRow = this.aideGameKindItemProvider.NewRow();
			dataRow["KindID"] = gameKindItem.KindID;
			dataRow["GameID"] = gameKindItem.GameID;
			dataRow["TypeID"] = gameKindItem.TypeID;
			dataRow["SortID"] = gameKindItem.SortID;
			dataRow["KindName"] = gameKindItem.KindName;
			dataRow["JoinID"] = gameKindItem.JoinID;
			dataRow["ProcessName"] = gameKindItem.ProcessName;
			dataRow["GameRuleUrl"] = gameKindItem.GameRuleUrl;
			dataRow["DownLoadUrl"] = gameKindItem.DownLoadUrl;
			dataRow["Recommend"] = gameKindItem.Recommend;
			dataRow["GameFlag"] = gameKindItem.GameFlag;
			dataRow["Nullity"] = gameKindItem.Nullity;
			this.aideGameKindItemProvider.Insert(dataRow);
		}
		public void UpdateGameKindItem(GameKindItem gameKindItem)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameKindItem SET ").Append("GameID=@GameID, ").Append("TypeID=@TypeID, ").Append("SortID=@SortID, ").Append("KindName=@KindName, ").Append("JoinID=@JoinID, ").Append("ProcessName=@ProcessName, ").Append("GameRuleUrl=@GameRuleUrl, ").Append("DownLoadUrl=@DownLoadUrl, ").Append("Recommend=@Recommend, ").Append("GameFlag=@GameFlag, ").Append("Nullity=@Nullity ").Append("WHERE KindID=@KindID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("GameID", gameKindItem.GameID));
			list.Add(base.Database.MakeInParam("TypeID", gameKindItem.TypeID));
			list.Add(base.Database.MakeInParam("SortID", gameKindItem.SortID));
			list.Add(base.Database.MakeInParam("KindName", gameKindItem.KindName));
			list.Add(base.Database.MakeInParam("JoinID", gameKindItem.JoinID));
			list.Add(base.Database.MakeInParam("ProcessName", gameKindItem.ProcessName));
			list.Add(base.Database.MakeInParam("GameRuleUrl", gameKindItem.GameRuleUrl));
			list.Add(base.Database.MakeInParam("DownLoadUrl", gameKindItem.DownLoadUrl));
			list.Add(base.Database.MakeInParam("Nullity", gameKindItem.Nullity));
			list.Add(base.Database.MakeInParam("Recommend", gameKindItem.Recommend));
			list.Add(base.Database.MakeInParam("GameFlag", gameKindItem.GameFlag));
			list.Add(base.Database.MakeInParam("KindID", gameKindItem.KindID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameKindItem(string sqlQuery)
		{
			this.aideGameKindItemProvider.Delete(sqlQuery);
		}
		public void UpdateGameConfig(GameConfig gameConfig)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("UPDATE GameConfig SET NoticeChangeGolds={0},WinExperience={2} WHERE KindID={1}", gameConfig.NoticeChangeGolds, gameConfig.KindID, gameConfig.WinExperience);
			stringBuilder.AppendFormat("IF @@ROWCOUNT=0 BEGIN ", new object[0]);
			stringBuilder.AppendFormat("INSERT GameConfig(KindID,NoticeChangeGolds,WinExperience) VALUES({0},{1},{2}) ", gameConfig.KindID, gameConfig.NoticeChangeGolds, gameConfig.WinExperience);
			stringBuilder.Append("END ");
			base.Database.ExecuteNonQuery(stringBuilder.ToString());
		}
		public GameConfig GetGameConfig(int kindID)
		{
			string where = string.Format("(NOLOCK) WHERE KindID={0}", kindID);
			return this.aideGameConfigProvider.GetObject<GameConfig>(where);
		}
		public PagerSet GetMobileKindItemList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("MobileKindItem", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public MobileKindItem GetMobileKindItemInfo(int kindID)
		{
			string where = string.Format("(NOLOCK) WHERE KindID= {0}", kindID);
			return this.aideMobileKindItemProvider.GetObject<MobileKindItem>(where);
		}
		public int GetMaxMobileKindID()
		{
			string commandText = "SELECT MAX(KindID) FROM MobileKindItem(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertMobileKindItem(MobileKindItem model)
		{
			System.Data.DataRow dataRow = this.aideMobileKindItemProvider.NewRow();
			dataRow["KindID"] = model.KindID;
			dataRow["KindName"] = model.KindName;
			dataRow["TypeID"] = model.TypeID;
			dataRow["ModuleName"] = model.ModuleName;
			dataRow["ClientVersion"] = model.ClientVersion;
			dataRow["ResVersion"] = model.ResVersion;
			dataRow["SortID"] = model.SortID;
			dataRow["KindMark"] = model.KindMark;
			dataRow["KindType"] = model.KindType;
			dataRow["Nullity"] = model.Nullity;
			this.aideMobileKindItemProvider.Insert(dataRow);
		}
		public void UpdateMobileKindItem(MobileKindItem model)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE MobileKindItem SET ").Append("KindName=@KindName, ").Append("ModuleName=@ModuleName, ").Append("ClientVersion=@ClientVersion, ").Append("ResVersion=@ResVersion, ").Append("SortID=@SortID, ").Append("KindMark=@KindMark, ").Append("KindType=@KindType, ").Append("Nullity=@Nullity ").Append("WHERE KindID=@KindID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("KindName", model.KindName));
			list.Add(base.Database.MakeInParam("ModuleName", model.ModuleName));
			list.Add(base.Database.MakeInParam("ClientVersion", model.ClientVersion));
			list.Add(base.Database.MakeInParam("ResVersion", model.ResVersion));
			list.Add(base.Database.MakeInParam("SortID", model.SortID));
			list.Add(base.Database.MakeInParam("KindMark", model.KindMark));
			list.Add(base.Database.MakeInParam("KindType", model.KindType));
			list.Add(base.Database.MakeInParam("Nullity", model.Nullity));
			list.Add(base.Database.MakeInParam("KindID", model.KindID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteMobileKindItem(string sqlQuery)
		{
			this.aideMobileKindItemProvider.Delete(sqlQuery);
		}
		public PagerSet GetGameRoomInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameRoomInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GameRoomInfo GetGameRoomInfoInfo(int serverID)
		{
			string where = string.Format("(NOLOCK) WHERE ServerID= {0}", serverID);
			return this.aideGameRoomInfoProvider.GetObject<GameRoomInfo>(where);
		}
		public void InsertGameRoomInfo(GameRoomInfo gameRoomInfo)
		{
			System.Data.DataRow dataRow = this.aideGameRoomInfoProvider.NewRow();
			dataRow["ServerID"] = gameRoomInfo.ServerID;
			dataRow["ServerName"] = gameRoomInfo.ServerName;
			dataRow["KindID"] = gameRoomInfo.KindID;
			dataRow["SortID"] = gameRoomInfo.SortID;
			dataRow["NodeID"] = gameRoomInfo.NodeID;
			dataRow["GameID"] = gameRoomInfo.GameID;
			dataRow["TableCount"] = gameRoomInfo.TableCount;
			dataRow["ServerType"] = gameRoomInfo.ServerType;
			dataRow["ServerPort"] = gameRoomInfo.ServerPort;
			dataRow["DataBaseName"] = gameRoomInfo.DataBaseName;
			dataRow["DataBaseAddr"] = gameRoomInfo.DataBaseAddr;
			dataRow["CellScore"] = gameRoomInfo.CellScore;
			dataRow["RevenueRatio"] = gameRoomInfo.RevenueRatio;
			dataRow["RestrictScore"] = gameRoomInfo.RestrictScore;
			dataRow["MinTableScore"] = gameRoomInfo.MinTableScore;
			dataRow["MinEnterScore"] = gameRoomInfo.MinEnterScore;
			dataRow["MaxEnterScore"] = gameRoomInfo.MaxEnterScore;
			dataRow["MinEnterMember"] = gameRoomInfo.MinEnterMember;
			dataRow["MaxEnterMember"] = gameRoomInfo.MaxEnterMember;
			dataRow["MaxPlayer"] = gameRoomInfo.MaxPlayer;
			dataRow["ServerRule"] = gameRoomInfo.ServerRule;
			dataRow["DistributeRule"] = gameRoomInfo.DistributeRule;
			dataRow["MinDistributeUser"] = gameRoomInfo.MinDistributeUser;
			dataRow["DistributeTimeSpace"] = gameRoomInfo.DistributeTimeSpace;
			dataRow["DistributeDrawCount"] = gameRoomInfo.DistributeDrawCount;
			dataRow["AttachUserRight"] = gameRoomInfo.AttachUserRight;
			dataRow["ServiceMachine"] = gameRoomInfo.ServiceMachine;
			dataRow["CustomRule"] = gameRoomInfo.CustomRule;
			dataRow["Nullity"] = gameRoomInfo.Nullity;
			dataRow["ServerNote"] = gameRoomInfo.ServerNote;
			dataRow["CreateDateTime"] = gameRoomInfo.CreateDateTime;
			dataRow["ModifyDateTime"] = gameRoomInfo.ModifyDateTime;
			dataRow["ServiceScore"] = gameRoomInfo.ServiceScore;
			this.aideGameRoomInfoProvider.Insert(dataRow);
		}
		public void UpdateGameRoomInfo(GameRoomInfo gameRoomInfo)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameRoomInfo SET ").Append("ServerName=@ServerName, ").Append("KindID=@KindID, ").Append("NodeID=@NodeID, ").Append("SortID=@SortID, ").Append("GameID=@GameID, ").Append("TableCount=@TableCount, ").Append("ServerType=@ServerType, ").Append("ServerPort=@ServerPort, ").Append("DataBaseName=@DataBaseName, ").Append("DataBaseAddr=@DataBaseAddr, ").Append("CellScore=@CellScore, ").Append("RevenueRatio=@RevenueRatio, ").Append("RestrictScore=@RestrictScore, ").Append("MinTableScore=@MinTableScore, ").Append("MinEnterScore=@MinEnterScore, ").Append("MaxEnterScore=@MaxEnterScore, ").Append("MinEnterMember=@MinEnterMember, ").Append("MaxEnterMember=@MaxEnterMember, ").Append("MaxPlayer=@MaxPlayer, ").Append("ServerRule=@ServerRule, ").Append("DistributeRule=@DistributeRule, ").Append("MinDistributeUser=@MinDistributeUser, ").Append("MaxDistributeUser=@MaxDistributeUser, ").Append("DistributeTimeSpace=@DistributeTimeSpace, ").Append("DistributeDrawCount=@DistributeDrawCount, ").Append("DistributeStartDelay=@DistributeStartDelay, ").Append("AttachUserRight=@AttachUserRight, ").Append("ServiceMachine=@ServiceMachine, ").Append("CustomRule=@CustomRule, ").Append("Nullity=@Nullity, ").Append("ServerNote=@ServerNote, ").Append("ModifyDateTime=@ModifyDateTime ").Append("WHERE ServerID=@ServerID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ServerName", gameRoomInfo.ServerName));
			list.Add(base.Database.MakeInParam("KindID", gameRoomInfo.KindID));
			list.Add(base.Database.MakeInParam("NodeID", gameRoomInfo.NodeID));
			list.Add(base.Database.MakeInParam("SortID", gameRoomInfo.SortID));
			list.Add(base.Database.MakeInParam("GameID", gameRoomInfo.GameID));
			list.Add(base.Database.MakeInParam("TableCount", gameRoomInfo.TableCount));
			list.Add(base.Database.MakeInParam("ServerType", gameRoomInfo.ServerType));
			list.Add(base.Database.MakeInParam("ServerPort", gameRoomInfo.ServerPort));
			list.Add(base.Database.MakeInParam("DataBaseName", gameRoomInfo.DataBaseName));
			list.Add(base.Database.MakeInParam("DataBaseAddr", gameRoomInfo.DataBaseAddr));
			list.Add(base.Database.MakeInParam("CellScore", gameRoomInfo.CellScore));
			list.Add(base.Database.MakeInParam("RevenueRatio", gameRoomInfo.RevenueRatio));
			list.Add(base.Database.MakeInParam("RestrictScore", gameRoomInfo.RestrictScore));
			list.Add(base.Database.MakeInParam("MinTableScore", gameRoomInfo.MinTableScore));
			list.Add(base.Database.MakeInParam("MinEnterScore", gameRoomInfo.MinEnterScore));
			list.Add(base.Database.MakeInParam("MaxEnterScore", gameRoomInfo.MaxEnterScore));
			list.Add(base.Database.MakeInParam("MinEnterMember", gameRoomInfo.MinEnterMember));
			list.Add(base.Database.MakeInParam("MaxEnterMember", gameRoomInfo.MaxEnterMember));
			list.Add(base.Database.MakeInParam("MaxPlayer", gameRoomInfo.MaxPlayer));
			list.Add(base.Database.MakeInParam("ServerRule", gameRoomInfo.ServerRule));
			list.Add(base.Database.MakeInParam("DistributeRule", gameRoomInfo.DistributeRule));
			list.Add(base.Database.MakeInParam("MinDistributeUser", gameRoomInfo.MinDistributeUser));
			list.Add(base.Database.MakeInParam("DistributeTimeSpace", gameRoomInfo.DistributeTimeSpace));
			list.Add(base.Database.MakeInParam("DistributeDrawCount", gameRoomInfo.DistributeDrawCount));
			list.Add(base.Database.MakeInParam("AttachUserRight", gameRoomInfo.AttachUserRight));
			list.Add(base.Database.MakeInParam("ServiceMachine", gameRoomInfo.ServiceMachine));
			list.Add(base.Database.MakeInParam("CustomRule", gameRoomInfo.CustomRule));
			list.Add(base.Database.MakeInParam("Nullity", gameRoomInfo.Nullity));
			list.Add(base.Database.MakeInParam("ServerNote", gameRoomInfo.ServerNote));
			list.Add(base.Database.MakeInParam("ModifyDateTime", gameRoomInfo.ModifyDateTime));
			list.Add(base.Database.MakeInParam("ServerID", gameRoomInfo.ServerID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameRoomInfo(string sqlQuery)
		{
			this.aideGameRoomInfoProvider.Delete(sqlQuery);
		}
		public System.Data.DataSet GetOnLineStreamInfoList(string sqlQuery)
		{
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, sqlQuery);
		}
		public PagerSet GetOnLineStreamInfoList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("OnLineStreamInfo", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetSystemMessageList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("SystemMessage", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public SystemMessage GetSystemMessageInfo(int id)
		{
			string where = string.Format("(NOLOCK) WHERE ID= {0}", id);
			return this.aideSystemMessageProvider.GetObject<SystemMessage>(where);
		}
		public void InsertSystemMessage(SystemMessage systemMessage)
		{
			System.Data.DataRow dataRow = this.aideSystemMessageProvider.NewRow();
			dataRow["MessageType"] = systemMessage.MessageType;
			dataRow["ServerRange"] = systemMessage.ServerRange;
			dataRow["MessageString"] = systemMessage.MessageString;
			dataRow["StartTime"] = systemMessage.StartTime;
			dataRow["ConcludeTime"] = systemMessage.ConcludeTime;
			dataRow["TimeRate"] = systemMessage.TimeRate;
			dataRow["Nullity"] = systemMessage.Nullity;
			dataRow["CreateDate"] = systemMessage.CreateDate;
			dataRow["CreateMasterID"] = systemMessage.CreateMasterID;
			dataRow["UpdateDate"] = systemMessage.UpdateDate;
			dataRow["UpdateMasterID"] = systemMessage.UpdateMasterID;
			dataRow["UpdateCount"] = systemMessage.UpdateCount;
			dataRow["CollectNote"] = systemMessage.CollectNote;
			this.aideSystemMessageProvider.Insert(dataRow);
		}
		public void UpdateSystemMessage(SystemMessage systemMessage)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE SystemMessage SET ").Append("MessageType=@MessageType, ").Append("ServerRange=@ServerRange, ").Append("MessageString=@MessageString, ").Append("StartTime=@StartTime, ").Append("ConcludeTime=@ConcludeTime, ").Append("TimeRate=@TimeRate, ").Append("Nullity=@Nullity, ").Append("UpdateDate=@UpdateDate, ").Append("UpdateMasterID=@UpdateMasterID, ").Append("UpdateCount=UpdateCount+1, ").Append("CollectNote=@CollectNote ").Append("WHERE ID=@ID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("MessageType", systemMessage.MessageType));
			list.Add(base.Database.MakeInParam("ServerRange", systemMessage.ServerRange));
			list.Add(base.Database.MakeInParam("MessageString", systemMessage.MessageString));
			list.Add(base.Database.MakeInParam("StartTime", systemMessage.StartTime));
			list.Add(base.Database.MakeInParam("ConcludeTime", systemMessage.ConcludeTime));
			list.Add(base.Database.MakeInParam("TimeRate", systemMessage.TimeRate));
			list.Add(base.Database.MakeInParam("Nullity", systemMessage.Nullity));
			list.Add(base.Database.MakeInParam("UpdateDate", System.DateTime.Now));
			list.Add(base.Database.MakeInParam("UpdateMasterID", systemMessage.UpdateMasterID));
			list.Add(base.Database.MakeInParam("CollectNote", systemMessage.CollectNote));
			list.Add(base.Database.MakeInParam("ID", systemMessage.ID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteSystemMessage(string sqlQuery)
		{
			this.aideSystemMessageProvider.Delete(sqlQuery);
		}
		public PagerSet GetGlobalPlayPresentList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GlobalPlayPresent", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GlobalPlayPresent GetGlobalPlayPresentInfo(int serverID)
		{
			string where = string.Format("(NOLOCK) WHERE ServerID= {0}", serverID);
			return this.aideGlobalPlayPresentProvider.GetObject<GlobalPlayPresent>(where);
		}
		public void InsertGlobalPlayPresent(GlobalPlayPresent globalPlayPresent)
		{
			System.Data.DataRow dataRow = this.aideGlobalPlayPresentProvider.NewRow();
			dataRow["ServerID"] = globalPlayPresent.ServerID;
			dataRow["PresentMember"] = globalPlayPresent.PresentMember;
			dataRow["MaxDatePresent"] = globalPlayPresent.MaxDatePresent;
			dataRow["MaxPresent"] = globalPlayPresent.MaxPresent;
			dataRow["CellPlayPresnet"] = globalPlayPresent.CellPlayPresnet;
			dataRow["CellPlayTime"] = globalPlayPresent.CellPlayTime;
			dataRow["StartPlayTime"] = globalPlayPresent.StartPlayTime;
			dataRow["CellOnlinePresent"] = globalPlayPresent.CellOnlinePresent;
			dataRow["CellOnlineTime"] = globalPlayPresent.CellOnlineTime;
			dataRow["StartOnlineTime"] = globalPlayPresent.StartOnlineTime;
			dataRow["IsPlayPresent"] = globalPlayPresent.IsPlayPresent;
			dataRow["IsOnlinePresent"] = globalPlayPresent.IsOnlinePresent;
			dataRow["CollectDate"] = globalPlayPresent.CollectDate;
			this.aideGlobalPlayPresentProvider.Insert(dataRow);
		}
		public void UpdateGlobalPlayPresent(GlobalPlayPresent globalPlayPresent)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GlobalPlayPresent SET ").Append("PresentMember=@PresentMember, ").Append("MaxDatePresent=@MaxDatePresent, ").Append("MaxPresent=@MaxPresent, ").Append("CellPlayPresnet=@CellPlayPresnet, ").Append("CellPlayTime=@CellPlayTime, ").Append("StartPlayTime=@StartPlayTime, ").Append("CellOnlinePresent=@CellOnlinePresent, ").Append("CellOnlineTime=@CellOnlineTime, ").Append("StartOnlineTime=@StartOnlineTime, ").Append("IsPlayPresent=@IsPlayPresent, ").Append("IsOnlinePresent=@IsOnlinePresent, ").Append("CollectDate=@CollectDate ").Append("WHERE ServerID=@ServerID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("PresentMember", globalPlayPresent.PresentMember));
			list.Add(base.Database.MakeInParam("MaxDatePresent", globalPlayPresent.MaxDatePresent));
			list.Add(base.Database.MakeInParam("MaxPresent", globalPlayPresent.MaxPresent));
			list.Add(base.Database.MakeInParam("CellPlayPresnet", globalPlayPresent.CellPlayPresnet));
			list.Add(base.Database.MakeInParam("CellPlayTime", globalPlayPresent.CellPlayTime));
			list.Add(base.Database.MakeInParam("StartPlayTime", globalPlayPresent.StartPlayTime));
			list.Add(base.Database.MakeInParam("CellOnlinePresent", globalPlayPresent.CellOnlinePresent));
			list.Add(base.Database.MakeInParam("CellOnlineTime", globalPlayPresent.CellOnlineTime));
			list.Add(base.Database.MakeInParam("StartOnlineTime", globalPlayPresent.StartOnlineTime));
			list.Add(base.Database.MakeInParam("IsPlayPresent", globalPlayPresent.IsPlayPresent));
			list.Add(base.Database.MakeInParam("IsOnlinePresent", globalPlayPresent.IsOnlinePresent));
			list.Add(base.Database.MakeInParam("CollectDate", globalPlayPresent.CollectDate));
			list.Add(base.Database.MakeInParam("ServerID", globalPlayPresent.ServerID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGlobalPlayPresent(string sqlQuery)
		{
			this.aideGlobalPlayPresentProvider.Delete(sqlQuery);
		}
		public TaskInfo GetTaskInfoByID(int id)
		{
			string where = string.Format(" WHERE TaskID={0}", id);
			return this.aideTaskInfoProvider.GetObject<TaskInfo>(where);
		}
		public void InsertTaskInfo(TaskInfo info)
		{
			System.Data.DataRow dataRow = this.aideTaskInfoProvider.NewRow();
			dataRow["TaskName"] = info.TaskName;
			dataRow["TaskType"] = info.TaskType;
			dataRow["UserType"] = info.UserType;
			dataRow["KindID"] = info.KindID;
			dataRow["StandardAwardGold"] = info.StandardAwardGold;
			dataRow["StandardAwardMedal"] = info.StandardAwardMedal;
			dataRow["MemberAwardGold"] = info.MemberAwardGold;
			dataRow["MemberAwardMedal"] = info.MemberAwardMedal;
			dataRow["TimeLimit"] = info.TimeLimit;
			dataRow["TaskDescription"] = info.TaskDescription;
			dataRow["InputDate"] = info.InputDate;
			dataRow["MatchID"] = info.MatchID;
			dataRow["Innings"] = info.Innings;
			this.aideTaskInfoProvider.Insert(dataRow);
		}
		public int UpdateTaskInfo(TaskInfo info)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE TaskInfo SET ").Append("TaskName=@TaskName,").Append("TaskType=@TaskType,").Append("UserType=@UserType,").Append("KindID=@KindID,").Append("StandardAwardGold=@StandardAwardGold,").Append("StandardAwardMedal=@StandardAwardMedal,").Append("MemberAwardGold=@MemberAwardGold,").Append("MemberAwardMedal=@MemberAwardMedal,").Append("TimeLimit=@TimeLimit,").Append("TaskDescription=@TaskDescription,").Append("MatchID=@MatchID,").Append("Innings=@Innings").Append(" WHERE TaskID= @TaskID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TaskName", info.TaskName));
			list.Add(base.Database.MakeInParam("TaskType", info.TaskType));
			list.Add(base.Database.MakeInParam("UserType", info.UserType));
			list.Add(base.Database.MakeInParam("KindID", info.KindID));
			list.Add(base.Database.MakeInParam("StandardAwardGold", info.StandardAwardGold));
			list.Add(base.Database.MakeInParam("StandardAwardMedal", info.StandardAwardMedal));
			list.Add(base.Database.MakeInParam("MemberAwardGold", info.MemberAwardGold));
			list.Add(base.Database.MakeInParam("MemberAwardMedal", info.MemberAwardMedal));
			list.Add(base.Database.MakeInParam("TimeLimit", info.TimeLimit));
			list.Add(base.Database.MakeInParam("TaskDescription", info.TaskDescription));
			list.Add(base.Database.MakeInParam("MatchID", info.MatchID));
			list.Add(base.Database.MakeInParam("Innings", info.Innings));
			list.Add(base.Database.MakeInParam("TaskID", info.TaskID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteTaskInfo(string sqlQuery)
		{
			this.aideTaskInfoProvider.Delete(sqlQuery);
		}
		public System.Data.DataSet GetSigninConfig()
		{
			string commandText = string.Format("SELECT * FROM SigninConfig ORDER BY DayID ASC", new object[0]);
			return base.Database.ExecuteDataset(commandText);
		}
		public void UpdateSigninConfig(System.Data.DataSet ds)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			foreach (System.Data.DataRow dataRow in ds.Tables[0].Rows)
			{
				stringBuilder.AppendFormat("UPDATE SigninConfig SET RewardGold={0} WHERE DayID={1} ", dataRow[1], dataRow[0]);
				stringBuilder.AppendFormat("IF @@ROWCOUNT=0 BEGIN ", new object[0]);
				stringBuilder.AppendFormat("INSERT SigninConfig(DayID,RewardGold) VALUES({0},{1}) ", dataRow[0], dataRow[1]);
				stringBuilder.Append("END ");
			}
			base.Database.ExecuteNonQuery(stringBuilder.ToString());
		}
		public int UpdateGrowLevelConfig(GrowLevelConfig glc)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GrowLevelConfig SET ").Append("Experience=@Experience,").Append("RewardGold=@RewardGold,").Append("RewardMedal=@RewardMedal,").Append("LevelRemark=@LevelRemark ").Append("WHERE LevelID=@LevelID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Experience", glc.Experience));
			list.Add(base.Database.MakeInParam("RewardGold", glc.RewardGold));
			list.Add(base.Database.MakeInParam("RewardMedal", glc.RewardMedal));
			list.Add(base.Database.MakeInParam("LevelRemark", glc.LevelRemark));
			list.Add(base.Database.MakeInParam("LevelID", glc.LevelID));
			return base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetGamePropertyTypeList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GamePropertyType", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public GamePropertyType GetGamePropertyTypeInfo(int typeID)
		{
			string where = string.Format("(NOLOCK) WHERE TypeID= {0}", typeID);
			return this.aideGamePropertyTypeProvider.GetObject<GamePropertyType>(where);
		}
		public int GetMaxPropertyTypeID()
		{
			string commandText = "SELECT MAX(TypeID) FROM GamePropertyType(NOLOCK)";
			object obj = base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText);
			if (obj == null || obj.ToString().Length <= 0)
			{
				return 0;
			}
			return int.Parse(obj.ToString());
		}
		public void InsertGamePropertyType(GamePropertyType gamePropertyType)
		{
			System.Data.DataRow dataRow = this.aideGamePropertyTypeProvider.NewRow();
			dataRow["TypeID"] = gamePropertyType.TypeID;
			dataRow["SortID"] = gamePropertyType.SortID;
			dataRow["TypeName"] = gamePropertyType.TypeName;
			dataRow["TagID"] = gamePropertyType.TagID;
			dataRow["Nullity"] = gamePropertyType.Nullity;
			this.aideGamePropertyTypeProvider.Insert(dataRow);
		}
		public void UpdateGamePropertyType(GamePropertyType gamePropertyType)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GamePropertyType SET ").Append("SortID=@SortID, ").Append("TypeName=@TypeName, ").Append("TagID=@TagID, ").Append("Nullity=@Nullity ").Append("WHERE TypeID=@TypeID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("TypeID", gamePropertyType.TypeID));
			list.Add(base.Database.MakeInParam("SortID", gamePropertyType.SortID));
			list.Add(base.Database.MakeInParam("TypeName", gamePropertyType.TypeName));
			list.Add(base.Database.MakeInParam("TagID", gamePropertyType.TagID));
			list.Add(base.Database.MakeInParam("Nullity", gamePropertyType.Nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGamePropertyType(string sqlQuery)
		{
			this.aideGamePropertyTypeProvider.Delete(sqlQuery);
		}
		public PagerSet GetGamePropertyList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("GameProperty", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public System.Collections.Generic.IList<GameProperty> GetGamePropertyGift(int kind)
		{
			string commandText = string.Format("SELECT * FROM GameProperty(NOLOCK) WHERE Kind= {0}", kind);
			return base.Database.ExecuteObjectList<GameProperty>(commandText);
		}
		public GameProperty GetGamePropertyInfo(int id)
		{
			string where = string.Format("(NOLOCK) WHERE ID= {0}", id);
			return this.aideGamePropertyProvider.GetObject<GameProperty>(where);
		}
		public int GetMaxPropertyID()
		{
			string commandText = string.Format("SELECT MAX(ID) FROM GameProperty(NOLOCK)", new object[0]);
			return Utility.StrToInt(base.Database.ExecuteScalar(System.Data.CommandType.Text, commandText), 0);
		}
		public void InsertGameProperty(GameProperty property)
		{
			System.Data.DataRow dataRow = this.aideGamePropertyProvider.NewRow();
			dataRow["ID"] = property.ID;
			dataRow["Name"] = property.Name;
			dataRow["Kind"] = property.Kind;
			dataRow["PTypeID"] = property.PTypeID;
			dataRow["MTypeID"] = property.MTypeID;
			dataRow["Cash"] = property.Cash;
			dataRow["Gold"] = property.Gold;
			dataRow["UserMedal"] = property.UserMedal;
			dataRow["LoveLiness"] = property.LoveLiness;
			dataRow["UseArea"] = property.UseArea;
			dataRow["ServiceArea"] = property.ServiceArea;
			dataRow["SuportMobile"] = property.SuportMobile;
			dataRow["RegulationsInfo"] = property.RegulationsInfo;
			dataRow["SendLoveLiness"] = property.SendLoveLiness;
			dataRow["RecvLoveLiness"] = property.RecvLoveLiness;
			dataRow["UseResultsGold"] = property.UseResultsGold;
			dataRow["UseResultsValidTime"] = property.UseResultsValidTime;
			dataRow["UseResultsValidTimeScoreMultiple"] = property.UseResultsValidTimeScoreMultiple;
			dataRow["UseResultsGiftPackage"] = property.UseResultsGiftPackage;
			dataRow["Recommend"] = property.Recommend;
			dataRow["Nullity"] = property.Nullity;
			this.aideGamePropertyProvider.Insert(dataRow);
		}
		public void UpdateGameProperty(GameProperty property)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GameProperty SET ").Append("Name=@Name ,").Append("Kind=@Kind ,").Append("PTypeID=@PTypeID ,").Append("MTypeID=@MTypeID ,").Append("Cash=@Cash,").Append("Gold=@Gold,").Append("UserMedal=@UserMedal,").Append("LoveLiness=@LoveLiness,").Append("UseArea=@UseArea,").Append("ServiceArea=@ServiceArea,").Append("SuportMobile=@SuportMobile,").Append("RegulationsInfo=@RegulationsInfo,").Append("SendLoveLiness=@SendLoveLiness,").Append("RecvLoveLiness=@RecvLoveLiness,").Append("UseResultsGold=@UseResultsGold,").Append("UseResultsValidTime=@UseResultsValidTime,").Append("UseResultsValidTimeScoreMultiple=@UseResultsValidTimeScoreMultiple,").Append("UseResultsGiftPackage=@UseResultsGiftPackage,").Append("Recommend=@Recommend,").Append("Nullity=@Nullity ").Append("WHERE ID= @ID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", property.ID));
			list.Add(base.Database.MakeInParam("Name", property.Name));
			list.Add(base.Database.MakeInParam("Kind", property.Kind));
			list.Add(base.Database.MakeInParam("PTypeID", property.PTypeID));
			list.Add(base.Database.MakeInParam("MTypeID", property.MTypeID));
			list.Add(base.Database.MakeInParam("Cash", property.Cash));
			list.Add(base.Database.MakeInParam("Gold", property.Gold));
			list.Add(base.Database.MakeInParam("UserMedal", property.UserMedal));
			list.Add(base.Database.MakeInParam("LoveLiness", property.LoveLiness));
			list.Add(base.Database.MakeInParam("UseArea", property.UseArea));
			list.Add(base.Database.MakeInParam("ServiceArea", property.ServiceArea));
			list.Add(base.Database.MakeInParam("SuportMobile", property.SuportMobile));
			list.Add(base.Database.MakeInParam("RegulationsInfo", property.RegulationsInfo));
			list.Add(base.Database.MakeInParam("SendLoveLiness", property.SendLoveLiness));
			list.Add(base.Database.MakeInParam("RecvLoveLiness", property.RecvLoveLiness));
			list.Add(base.Database.MakeInParam("UseResultsGold", property.UseResultsGold));
			list.Add(base.Database.MakeInParam("UseResultsValidTime", property.UseResultsValidTime));
			list.Add(base.Database.MakeInParam("UseResultsValidTimeScoreMultiple", property.UseResultsValidTimeScoreMultiple));
			list.Add(base.Database.MakeInParam("UseResultsGiftPackage", property.UseResultsGiftPackage));
			list.Add(base.Database.MakeInParam("Recommend", property.Recommend));
			list.Add(base.Database.MakeInParam("Nullity", property.Nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGameProperty(string sqlQuery)
		{
			this.aideGamePropertyProvider.Delete(sqlQuery);
		}
		public void SetPropertyDisbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameProperty SET Nullity=1 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetPropertyEnbale(string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameProperty SET Nullity=0 {0}", sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public void SetPropertyRecommend(int recommend, string sqlQuery)
		{
			string commandText = string.Format("UPDATE GameProperty SET Recommend={0} {1}", recommend, sqlQuery);
			base.Database.ExecuteNonQuery(commandText);
		}
		public GamePropertySub GetGamePropertySubInfo(int id, int ownerID)
		{
			string where = string.Format("(NOLOCK) WHERE ID= {0} AND OwnerID={1}", id, ownerID);
			return this.aideGamePropertySubProvider.GetObject<GamePropertySub>(where);
		}
		public void InsertGamePropertySub(GamePropertySub property)
		{
			System.Data.DataRow dataRow = this.aideGamePropertySubProvider.NewRow();
			dataRow["ID"] = property.ID;
			dataRow["OwnerID"] = property.OwnerID;
			dataRow["Count"] = property.Count;
			dataRow["SortID"] = property.SortID;
			this.aideGamePropertySubProvider.Insert(dataRow);
		}
		public void UpdateGamePropertySub(GamePropertySub property)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE GamePropertySub SET ").Append("Count=@Count ,").Append("SortID=@SortID ").Append("WHERE ID= @ID AND OwnerID=@OwnerID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("ID", property.ID));
			list.Add(base.Database.MakeInParam("OwnerID", property.OwnerID));
			list.Add(base.Database.MakeInParam("Count", property.Count));
			list.Add(base.Database.MakeInParam("SortID", property.SortID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteGamePropertySub(string sqlQuery)
		{
			this.aideGamePropertySubProvider.Delete(sqlQuery);
		}
		public Message AppStatOnline(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatOnline", list);
		}
		public Message AppPlatformGeneral(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_PlatformGeneral", list);
		}
		public Message AppStatUserOnline(string accounts, string logonPass, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_StatUserOnline", list);
		}
		public Message AppGetOnlineData(string accounts, string logonPass, string machineID, int dateType, string startDate, string endDate)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", accounts));
			list.Add(base.Database.MakeInParam("strPassword", logonPass));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeInParam("dwDateType", dateType));
			list.Add(base.Database.MakeInParam("strStartDate", startDate));
			list.Add(base.Database.MakeInParam("strEndDate", endDate));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForDataSet(base.Database, "APP_PM_GetOnlineData", list);
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
	}
}
