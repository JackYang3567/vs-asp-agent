using Game.Data.Factory;
using Game.Entity.GameScore;
using Game.IData;
using System;
namespace Game.Facade.Facade
{
	public class GameScoreFacade
	{
		private IGameScoreDataProvider aideGameScoreData;
		public GameScoreFacade(string conn)
		{
			this.aideGameScoreData = ClassFactory.GetIGameScoreDataProvider(conn);
		}
		public GameScoreInfo GetGameScoreInfoByUserId(int userId)
		{
			return this.aideGameScoreData.GetSocreInfoByUserId(userId);
		}
	}
}
