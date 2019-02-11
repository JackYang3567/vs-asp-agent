using Game.Entity.GameScore;
using System;
namespace Game.IData
{
	public interface IGameScoreDataProvider
	{
		GameScoreInfo GetSocreInfoByUserId(int userId);
	}
}
