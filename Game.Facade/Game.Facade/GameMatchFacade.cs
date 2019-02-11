using Game.Data.Factory;
using Game.Entity.GameMatch;
using Game.IData;
using Game.Kernel;
using System;
using System.Data;
namespace Game.Facade
{
	public class GameMatchFacade
	{
		private IGameMatchProvider gameMatchData;
		public GameMatchFacade()
		{
			this.gameMatchData = ClassFactory.GetIGameMatchProvider();
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.gameMatchData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public int ExecuteSql(string sql)
		{
			return this.gameMatchData.ExecuteSql(sql);
		}
		public MatchInfo GetMatchInfo(int matchID)
		{
			return this.gameMatchData.GetMatchInfo(matchID);
		}
		public Message UpdateMatchInfo(MatchInfo matchInfo)
		{
			Message result;
			try
			{
				this.gameMatchData.UpdateMatchInfo(matchInfo);
				result = new Message(true);
			}
			catch
			{
				result = new Message(false);
			}
			return result;
		}
		public MatchPublic GetMatchPublicInfo(int matchID)
		{
			return this.gameMatchData.GetMatchPublicInfo(matchID);
		}
		public DataSet GetAllMatch()
		{
			return this.gameMatchData.GetAllMatch();
		}
		public DataSet GetMatchListByMatchType(byte matchType)
		{
			return this.gameMatchData.GetMatchListByMatchType(matchType);
		}
		public DataSet GetMatchListByMatchID(int matchId)
		{
			return this.gameMatchData.GetMatchListByMatchID(matchId);
		}
		public PagerSet GetTimingMatchHistoryGroup(byte matchType, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.gameMatchData.GetTimingMatchHistoryGroup(matchType, pageIndex, pageSize, condition, orderby);
		}
		public DataSet GetMatchRewardList(int matchId)
		{
			return this.gameMatchData.GetMatchRewardList(matchId);
		}
	}
}
