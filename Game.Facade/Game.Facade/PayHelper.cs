using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Facade
{
	public class PayHelper
	{
		public static string GetOrderID()
		{
			StringBuffer stringBuffer = new StringBuffer();
			stringBuffer += TextUtility.GetDateTimeLongString();
			stringBuffer += TextUtility.CreateRandom(8, 1, 0, 0, 0, "");
			return stringBuffer.ToString();
		}
		public static string GetOrderIDByPrefix(string prefix)
		{
			int num = 22;
			int num2 = 6;
			StringBuffer stringBuffer = new StringBuffer();
			stringBuffer += prefix;
			stringBuffer += TextUtility.GetDateTimeLongString();
			if (stringBuffer.Length + num2 > num)
			{
				num2 = num - stringBuffer.Length;
			}
			stringBuffer += TextUtility.CreateRandom(num2, 1, 0, 0, 0, "");
			return stringBuffer.ToString();
		}
		public static string PrepareSign(System.Collections.Generic.Dictionary<string, string> dic)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				string text2 = text;
				text = string.Concat(new string[]
				{
					text2,
					current.Key,
					"=",
					current.Value,
					"&"
				});
			}
			text = text.Remove(text.Length - 1);
			return text;
		}
		public static string PrepareSign(SortedDictionary<string, string> dic)
		{
			string text = "";
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in dic)
			{
				if (!string.IsNullOrEmpty(current.Value))
				{
					string text2 = text;
					text = string.Concat(new string[]
					{
						text2,
						current.Key,
						"=",
						current.Value,
						"&"
					});
				}
			}
			text = text.Remove(text.Length - 1);
			return text;
		}
	}
}
