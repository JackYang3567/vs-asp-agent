using System;
using System.Web;
using System.Web.Caching;
namespace Game.Facade
{
	public class CacheHelper
	{
		public static void AddCache(string key, object value)
		{
			System.Web.Caching.Cache cache = System.Web.HttpRuntime.Cache;
			cache.Insert(key, value, null, System.DateTime.Now.AddMinutes(1.0), System.TimeSpan.Zero);
		}
	}
}
