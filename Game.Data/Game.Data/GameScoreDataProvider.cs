using Game.Entity.GameScore;
using Game.IData;
using Game.Kernel;
using System;
namespace Game.Data
{
	public class GameScoreDataProvider : BaseDataProvider, IGameScoreDataProvider
	{
		private ITableProvider aideGameScoreInfo;
		public GameScoreDataProvider(string connString) : base(connString)
		{
			this.aideGameScoreInfo = this.GetTableProvider("GameScoreInfo");
		}
		public GameScoreInfo GetSocreInfoByUserId(int userId)
		{
			string where = string.Format("(NOLOCK) WHERE UserID= N'{0}'", userId);
			return this.aideGameScoreInfo.GetObject<GameScoreInfo>(where);
		}
	}
}
