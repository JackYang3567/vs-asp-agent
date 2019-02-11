using Game.IData;
using Game.Kernel;
using Game.Utils;
using System;
namespace Game.Data.Factory
{
	public class ClassFactory
	{
		public static IPlatformManagerDataProvider GetIPlatformManagerDataProvider()
		{
			return ProxyFactory.CreateInstance<PlatformManagerDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBPlatformManager")
			});
		}
		public static INativeWebDataProvider GetINativeWebDataProvider()
		{
			return ProxyFactory.CreateInstance<NativeWebDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBNativeWeb")
			});
		}
		public static IAccountsDataProvider IAccountsDataProvider()
		{
			return ProxyFactory.CreateInstance<AccountsDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBAccounts")
			});
		}
		public static IPlatformDataProvider GetIPlatformDataProvider()
		{
			return ProxyFactory.CreateInstance<PlatformDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBPlatform")
			});
		}
		public static ITreasureDataProvider GetITreasureDataProvider()
		{
			return ProxyFactory.CreateInstance<TreasureDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBTreasure")
			});
		}
		public static ITreasureDataProvider GetITreasureDataProvider(int KindID)
		{
			return ProxyFactory.CreateInstance<TreasureDataProvider>(new object[]
			{
				new PlatformDataProvider(ApplicationSettings.Get("DBPlatform")).GetConn(KindID)
			});
		}
		public static IRecordDataProvider GetIRecordDataProvider()
		{
			return ProxyFactory.CreateInstance<RecordDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBRecord")
			});
		}
		public static IGameScoreDataProvider GetIGameScoreDataProvider(string conn)
		{
			return ProxyFactory.CreateInstance<GameScoreDataProvider>(new object[]
			{
				conn
			});
		}
		public static IGameMatchProvider GetIGameMatchProvider()
		{
			return ProxyFactory.CreateInstance<GameMatchDataProvider>(new object[]
			{
				ApplicationSettings.Get("DBGameMatch")
			});
		}
	}
}
