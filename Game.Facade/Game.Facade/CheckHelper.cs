using System;
namespace Game.Facade
{
	public class CheckHelper
	{
		public static bool CheckIds(string ids)
		{
			string[] array = ids.Split(new char[]
			{
				','
			});
			int num = 0;
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string s = array2[i];
				if (!int.TryParse(s, out num))
				{
					return false;
				}
			}
			return true;
		}
	}
}
