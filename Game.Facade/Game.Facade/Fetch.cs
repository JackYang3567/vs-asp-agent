using Game.Utils.Cache;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
namespace Game.Facade
{
	public class Fetch
	{
		public static string GetVerifyCodeVer2
		{
			get
			{
				object obj = WHCache.Default.Get<SessionCache>("VerifyCodeKey");
				if (obj != null)
				{
					return obj.ToString();
				}
				return "";
			}
		}
		public static string GetCookieName
		{
			get
			{
				return "6603Admin";
			}
		}
		public static void Redirect(string url)
		{
			System.Web.HttpContext.Current.Response.Clear();
			System.Web.HttpContext.Current.Response.StatusCode = 301;
			System.Web.HttpContext.Current.Response.AppendHeader("location", url);
			System.Web.HttpContext.Current.Response.End();
		}
		public static bool ValidVerifyCodeVer2(string verifyCode)
		{
			object obj = WHCache.Default.Get<SessionCache>("VerifyCodeKey");
			return obj != null && obj.ToString() == verifyCode;
		}
		public static bool ValidVerifyCodeVer3(string verifyCode)
		{
			System.Web.HttpContext current = System.Web.HttpContext.Current;
			return current != null && current.Session.Count != 0 && verifyCode.Equals(current.Session["CheckCode"].ToString(), System.StringComparison.InvariantCultureIgnoreCase);
		}
		public static string GetStartTime(System.DateTime bgDate)
		{
			System.DateTime value = new System.DateTime(bgDate.Year, bgDate.Month, bgDate.Day, 0, 0, 0);
			return System.Convert.ToString(value);
		}
		public static string GetEndTime(System.DateTime enDate)
		{
			System.DateTime value = new System.DateTime(enDate.Year, enDate.Month, enDate.Day, 23, 59, 59);
			return System.Convert.ToString(value);
		}
		public static string GetTimeByDate(System.DateTime bgDate, System.DateTime enDate)
		{
			System.DateTime value = new System.DateTime(bgDate.Year, bgDate.Month, bgDate.Day, 0, 0, 0);
			System.DateTime value2 = new System.DateTime(enDate.Year, enDate.Month, enDate.Day, 23, 59, 59);
			return System.Convert.ToString(value) + "$" + System.Convert.ToString(value2);
		}
		public static string GetTodayTime()
		{
			System.DateTime now = System.DateTime.Now;
			return Fetch.GetTimeByDate(now, now);
		}
		public static string GetYesterdayTime()
		{
			System.DateTime dateTime = System.DateTime.Now.AddDays(-1.0);
			return Fetch.GetTimeByDate(dateTime, dateTime);
		}
		public static string GetWeekTime()
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime bgDate = now.AddDays((double)(-(double)System.Convert.ToInt32(now.DayOfWeek.ToString("d"))));
			System.DateTime enDate = bgDate.AddDays(6.0);
			return Fetch.GetTimeByDate(bgDate, enDate);
		}
		public static string GetLastWeekTime()
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime bgDate = now.AddDays((double)(-7 - System.Convert.ToInt32(now.DayOfWeek.ToString("d"))));
			System.DateTime enDate = bgDate.AddDays(6.0);
			return Fetch.GetTimeByDate(bgDate, enDate);
		}
		public static string GetLastMonthTime()
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime bgDate = System.Convert.ToDateTime(now.AddMonths(-1).ToString("yyyy-MM-01"));
			System.DateTime enDate = System.Convert.ToDateTime(now.ToString("yyyy-MM-01"));
			return Fetch.GetTimeByDate(bgDate, enDate);
		}
		public static string GetMonthTime()
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime bgDate = now.AddDays((double)(1 - now.Day));
			System.DateTime enDate = bgDate.AddMonths(1).AddDays(-1.0);
			return Fetch.GetTimeByDate(bgDate, enDate);
		}
		public static string GetYearTime()
		{
			System.DateTime now = System.DateTime.Now;
			System.DateTime bgDate = now.AddDays((double)(1 - now.DayOfYear));
			System.DateTime enDate = bgDate.AddYears(1).AddDays(-1.0);
			return Fetch.GetTimeByDate(bgDate, enDate);
		}
		public static string GetDateID(System.DateTime DateTime)
		{
			System.TimeSpan timeSpan = new System.TimeSpan(DateTime.Ticks);
			System.TimeSpan ts = new System.TimeSpan(System.Convert.ToDateTime("1900-01-01").Ticks);
			return timeSpan.Subtract(ts).Duration().Days.ToString();
		}
		public static string ShowDate(int dateID)
		{
			return System.Convert.ToDateTime("1900-01-01").AddDays((double)dateID).ToString("yyyy-MM-dd");
		}
		public static string GetTimeSpan(System.DateTime dtStartDate, System.DateTime dtEndDate)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.TimeSpan timeSpan = dtEndDate.Subtract(dtStartDate);
			if (timeSpan.Days != 0)
			{
				stringBuilder.AppendFormat("{0}天", timeSpan.Days);
			}
			if (timeSpan.Hours != 0)
			{
				stringBuilder.AppendFormat("{0}小时", timeSpan.Hours);
			}
			if (timeSpan.Minutes != 0)
			{
				stringBuilder.AppendFormat("{0}分钟", timeSpan.Minutes);
			}
			if (timeSpan.Seconds != 0)
			{
				stringBuilder.AppendFormat("{0}秒", timeSpan.Seconds);
			}
			if (string.IsNullOrEmpty(stringBuilder.ToString()))
			{
				return "0秒";
			}
			return stringBuilder.ToString();
		}
		public static string ConverTimeToDHMS(long seconds)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (seconds <= 0L)
			{
				return "0秒";
			}
			long num = seconds / 86400L;
			long num2 = seconds % 86400L / 3600L;
			long num3 = seconds % 3600L / 60L;
			long num4 = seconds % 60L;
			if (num > 0L)
			{
				stringBuilder.AppendFormat("{0}天", num);
			}
			if (num2 > 0L)
			{
				stringBuilder.AppendFormat("{0}小时", num2);
			}
			if (num3 > 0L)
			{
				stringBuilder.AppendFormat("{0}分钟", num3);
			}
			if (num4 > 0L)
			{
				stringBuilder.AppendFormat("{0}秒", num4);
			}
			if (string.IsNullOrEmpty(stringBuilder.ToString()))
			{
				return "0秒";
			}
			return stringBuilder.ToString();
		}
		public static string GetRandomNumeric(int length)
		{
			if (length <= 0)
			{
				return "";
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = length; i > 0; i--)
			{
				stringBuilder.Append(Fetch.GetRandomSingleDigit().ToString());
			}
			return stringBuilder.ToString();
		}
		public static string GetRandomNumeric(int length, System.Random rand)
		{
			if (length <= 0)
			{
				return "";
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			for (int i = length; i > 0; i--)
			{
				stringBuilder.Append(rand.Next(0, 10).ToString());
			}
			return stringBuilder.ToString();
		}
		public static string GetRandomNumericAndEn(int length, System.Random random)
		{
			if (length <= 0)
			{
				return "";
			}
			string text = "nMe7lcIPKpQ1oAtuGCzL2qf8NO9X4mdFSaHbsOj3DvJrwV6ghiUYZWx5kETRyB";
			int i = length;
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.Collections.Generic.List<char> list = new System.Collections.Generic.List<char>();
			while (i > 0)
			{
				char item = text[random.Next(text.Length)];
				if (!list.Contains(item))
				{
					list.Add(item);
					i--;
				}
			}
			foreach (char current in list)
			{
				stringBuilder.Append(current.ToString());
			}
			return stringBuilder.ToString();
		}
		public static int GetRandomSingleDigit()
		{
			System.Random random = new System.Random();
			System.Threading.Thread.Sleep(10);
			return random.Next(10);
		}
		public static string GetRandomStr(int length, bool notRepeat, System.Random random)
		{
			if (length <= 0)
			{
				return "";
			}
			string text = "cohxMLdeabzEFGNmQZPAstpvwTHOkKnlWqrSYyijXufgRIJUVBCD";
			int i = length;
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.Collections.Generic.List<char> list = new System.Collections.Generic.List<char>();
			while (i > 0)
			{
				char item = text[random.Next(text.Length)];
				if (notRepeat)
				{
					if (length >= 26)
					{
						throw new System.Exception("指定了不允许字母重复，并且要生成的字符串长度大于等于26，将造成系统陷入死循环。");
					}
					if (!list.Contains(item))
					{
						list.Add(item);
					}
				}
				else
				{
					list.Add(item);
				}
				i--;
			}
			foreach (char current in list)
			{
				stringBuilder.Append(current.ToString());
			}
			return stringBuilder.ToString();
		}
	}
}
