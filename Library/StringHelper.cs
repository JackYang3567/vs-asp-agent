using System;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
namespace Library
{
	public class StringHelper
	{
		public static int GetStringLength(string s)
		{
			if (!string.IsNullOrEmpty(s))
			{
				return System.Text.Encoding.Default.GetBytes(s).Length;
			}
			return 0;
		}
		public static int GetCharCount(string s, char c)
		{
			if (s == null || s.Length == 0)
			{
				return 0;
			}
			int num = 0;
			for (int i = 0; i < s.Length; i++)
			{
				char c2 = s[i];
				if (c2 == c)
				{
					num++;
				}
			}
			return num;
		}
		public static int IndexOf(string s, int order)
		{
			return StringHelper.IndexOf(s, '-', order);
		}
		public static int IndexOf(string s, char c, int order)
		{
			int length = s.Length;
			for (int i = 0; i < length; i++)
			{
				if (c == s[i])
				{
					if (order == 1)
					{
						return i;
					}
					order--;
				}
			}
			return -1;
		}
		public static string[] SplitString(string sourceStr, string splitStr)
		{
			if (string.IsNullOrEmpty(sourceStr) || string.IsNullOrEmpty(splitStr))
			{
				return new string[0];
			}
			if (sourceStr.IndexOf(splitStr) == -1)
			{
				return new string[]
				{
					sourceStr
				};
			}
			if (splitStr.Length == 1)
			{
				return sourceStr.Split(new char[]
				{
					splitStr[0]
				});
			}
			return Regex.Split(sourceStr, Regex.Escape(splitStr), RegexOptions.IgnoreCase);
		}
		public static string[] SplitString(string sourceStr)
		{
			return StringHelper.SplitString(sourceStr, ",");
		}
		public static string SubString(string sourceStr, int startIndex, int length)
		{
			if (string.IsNullOrEmpty(sourceStr))
			{
				return "";
			}
			if (sourceStr.Length >= startIndex + length)
			{
				return sourceStr.Substring(startIndex, length);
			}
			return sourceStr.Substring(startIndex);
		}
		public static string SubString(string sourceStr, int length)
		{
			return StringHelper.SubString(sourceStr, 0, length);
		}
		public static string TrimStart(string sourceStr, string trimStr)
		{
			return StringHelper.TrimStart(sourceStr, trimStr, true);
		}
		public static string TrimStart(string sourceStr, string trimStr, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(sourceStr))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(trimStr) || !sourceStr.StartsWith(trimStr, ignoreCase, System.Globalization.CultureInfo.CurrentCulture))
			{
				return sourceStr;
			}
			return sourceStr.Remove(0, trimStr.Length);
		}
		public static string TrimEnd(string sourceStr, string trimStr)
		{
			return StringHelper.TrimEnd(sourceStr, trimStr, true);
		}
		public static string TrimEnd(string sourceStr, string trimStr, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(sourceStr))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(trimStr) || !sourceStr.EndsWith(trimStr, ignoreCase, System.Globalization.CultureInfo.CurrentCulture))
			{
				return sourceStr;
			}
			return sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
		}
		public static string Trim(string sourceStr, string trimStr)
		{
			return StringHelper.Trim(sourceStr, trimStr, true);
		}
		public static string Trim(string sourceStr, string trimStr, bool ignoreCase)
		{
			if (string.IsNullOrEmpty(sourceStr))
			{
				return string.Empty;
			}
			if (string.IsNullOrEmpty(trimStr))
			{
				return sourceStr;
			}
			if (sourceStr.StartsWith(trimStr, ignoreCase, System.Globalization.CultureInfo.CurrentCulture))
			{
				sourceStr = sourceStr.Remove(0, trimStr.Length);
			}
			if (sourceStr.EndsWith(trimStr, ignoreCase, System.Globalization.CultureInfo.CurrentCulture))
			{
				sourceStr = sourceStr.Substring(0, sourceStr.Length - trimStr.Length);
			}
			return sourceStr;
		}
		public static string ReplaceStr(string targetstr, int index, int length, string replacestr)
		{
			if (targetstr == "" || targetstr.Length == 0)
			{
				return "";
			}
			if (index < 0)
			{
				index = 0;
			}
			if (index > targetstr.Length - 1)
			{
				index = targetstr.Length - 1;
			}
			if (length == 0 || length > targetstr.Length - index - 1)
			{
				length = targetstr.Length - index;
			}
			string text = "";
			for (int i = 0; i < length; i++)
			{
				text += replacestr;
			}
			return targetstr.Replace(targetstr.Substring(index, length), text);
		}
	}
}
