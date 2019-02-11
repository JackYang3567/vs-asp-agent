using Game.Entity.Platform;
using System;
using System.Text;
namespace Game.Facade
{
	public class DataAccess
	{
		protected internal PlatformFacade aidePlatformFacade = new PlatformFacade();
		public string GetConn(int kindID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			GameKindItem gameKindItemInfo = this.aidePlatformFacade.GetGameKindItemInfo(kindID);
			GameGameItem gameGameItemInfo = this.aidePlatformFacade.GetGameGameItemInfo(gameKindItemInfo.GameID);
			stringBuilder.AppendFormat("Data Source={0}; Initial Catalog={1}; User ID={2}; Password={3}; Pooling=true", new object[]
			{
				gameGameItemInfo.DataBaseAddr,
				gameGameItemInfo.DataBaseName,
				"sa",
				"3112546"
			});
			return stringBuilder.ToString();
		}
	}
}
