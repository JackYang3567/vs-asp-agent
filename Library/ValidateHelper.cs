using Game.Facade.Tools;
using System;
using System.Text.RegularExpressions;
namespace Library
{
	public class ValidateHelper
	{
		private static Regex _emailregex = new Regex("^[a-z0-9]([a-z0-9]*[-_]?[a-z0-9]+)*@([a-z0-9]*[-_]?[a-z0-9]+)+[\\.][a-z]{2,3}([\\.][a-z]{2})?$", RegexOptions.IgnoreCase);
		private static Regex _mobileregex = new Regex("^((1[3,5,8][0-9])|(14[5,7])|(17[0,1,6,7,8]))[0-9]{8}$");
		private static Regex _phoneregex = new Regex("^(\\d{3,4}-?)?\\d{7,8}$");
		private static Regex _ipregex = new Regex("^(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])\\.(\\d{1,2}|1\\d\\d|2[0-4]\\d|25[0-5])$");
		private static Regex _dateregex = new Regex("(\\d{4})-(\\d{1,2})-(\\d{1,2})");
		private static Regex _numericregex = new Regex("^[-]?[0-9]+(\\.[0-9]+)?$");
		private static Regex _zipcoderegex = new Regex("^\\d{6}$");
		private static Regex _cnnameegex = new Regex("^[\\u4E00-\\u9FA5]{2,5}(?:·[\\u4E00-\\u9FA5]{2,5})*$");
		public static bool IsEmail(string s)
		{
			return string.IsNullOrEmpty(s) || ValidateHelper._emailregex.IsMatch(s);
		}
		public static bool IsMobile(string s)
		{
			return string.IsNullOrEmpty(s) || ValidateHelper._mobileregex.IsMatch(s);
		}
		public static bool IsPhone(string s)
		{
			return string.IsNullOrEmpty(s) || ValidateHelper._phoneregex.IsMatch(s);
		}
		public static bool IsIP(string s)
		{
			return ValidateHelper._ipregex.IsMatch(s);
		}
		public static bool IsIdCard(string id)
		{
			if (string.IsNullOrEmpty(id))
			{
				return true;
			}
			if (id.Length == 18)
			{
				return ValidateHelper.CheckIDCard18(id);
			}
			return id.Length == 15 && ValidateHelper.CheckIDCard15(id);
		}
		private static bool CheckIDCard18(string Id)
		{
			long num = 0L;
			if (!long.TryParse(Id.Remove(17), out num) || (double)num < System.Math.Pow(10.0, 16.0) || !long.TryParse(Id.Replace('x', '0').Replace('X', '0'), out num))
			{
				return false;
			}
			string text = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
			if (text.IndexOf(Id.Remove(2)) == -1)
			{
				return false;
			}
			string s = Id.Substring(6, 8).Insert(6, "-").Insert(4, "-");
			System.DateTime dateTime = default(System.DateTime);
			if (!System.DateTime.TryParse(s, out dateTime))
			{
				return false;
			}
			string[] array = "1,0,x,9,8,7,6,5,4,3,2".Split(new char[]
			{
				','
			});
			string[] array2 = "7,9,10,5,8,4,2,1,6,3,7,9,10,5,8,4,2".Split(new char[]
			{
				','
			});
			char[] array3 = Id.Remove(17).ToCharArray();
			int num2 = 0;
			for (int i = 0; i < 17; i++)
			{
				num2 += int.Parse(array2[i]) * int.Parse(array3[i].ToString());
			}
			int num3 = -1;
			System.Math.DivRem(num2, 11, out num3);
			return !(array[num3] != Id.Substring(17, 1).ToLower());
		}
		private static bool CheckIDCard15(string Id)
		{
			long num = 0L;
			if (!long.TryParse(Id, out num) || (double)num < System.Math.Pow(10.0, 14.0))
			{
				return false;
			}
			string text = "11x22x35x44x53x12x23x36x45x54x13x31x37x46x61x14x32x41x50x62x15x33x42x51x63x21x34x43x52x64x65x71x81x82x91";
			if (text.IndexOf(Id.Remove(2)) == -1)
			{
				return false;
			}
			string s = Id.Substring(6, 6).Insert(4, "-").Insert(2, "-");
			System.DateTime dateTime = default(System.DateTime);
			return System.DateTime.TryParse(s, out dateTime);
		}
		public static bool IsDate(string s)
		{
			return ValidateHelper._dateregex.IsMatch(s);
		}
		public static bool IsNumeric(string numericStr)
		{
			return ValidateHelper._numericregex.IsMatch(numericStr);
		}
		public static bool IsInt(string value)
		{
			return Regex.IsMatch(value, "^[+-]?\\d*$");
		}
		public static bool IsUnsign(string value)
		{
			return Regex.IsMatch(value, "^\\d*[.]?\\d*$");
		}
		public static bool IsZipCode(string s)
		{
			return string.IsNullOrEmpty(s) || ValidateHelper._zipcoderegex.IsMatch(s);
		}
		public static bool IsImgFileName(string fileName)
		{
			if (fileName.IndexOf(".") == -1)
			{
				return false;
			}
			string text = fileName.Trim().ToLower();
			string a = text.Substring(text.LastIndexOf("."));
			return a == ".png" || a == ".bmp" || a == ".jpg" || a == ".jpeg" || a == ".gif" || a == ".swf";
		}
		public static bool InIP(string sourceIP, string targetIP)
		{
			if (string.IsNullOrEmpty(sourceIP) || string.IsNullOrEmpty(targetIP))
			{
				return false;
			}
			string[] array = StringHelper.SplitString(sourceIP, ".");
			string[] array2 = StringHelper.SplitString(targetIP, ".");
			int num = array.Length;
			for (int i = 0; i < num; i++)
			{
				if (array2[i] == "*")
				{
					return true;
				}
				if (array[i] != array2[i])
				{
					return false;
				}
				if (i == 3)
				{
					return true;
				}
			}
			return false;
		}
		public static bool InIPList(string sourceIP, string[] targetIPList)
		{
			if (targetIPList != null && targetIPList.Length > 0)
			{
				for (int i = 0; i < targetIPList.Length; i++)
				{
					string targetIP = targetIPList[i];
					if (ValidateHelper.InIP(sourceIP, targetIP))
					{
						return true;
					}
				}
			}
			return false;
		}
		public static bool InIPList(string sourceIP, string targetIPStr)
		{
			string[] targetIPList = StringHelper.SplitString(targetIPStr, "\n");
			return ValidateHelper.InIPList(sourceIP, targetIPList);
		}
		public static bool BetweenPeriod(string[] periodList, out string liePeriod)
		{
			if (periodList != null && periodList.Length > 0)
			{
				System.DateTime now = System.DateTime.Now;
				System.DateTime date = now.Date;
				for (int i = 0; i < periodList.Length; i++)
				{
					string text = periodList[i];
					int num = text.IndexOf("-");
					System.DateTime dateTime = TypeUtil.StringToDateTime(text.Substring(0, num));
					System.DateTime t = TypeUtil.StringToDateTime(text.Substring(num + 1));
					if (dateTime < t)
					{
						if (now > dateTime && now < t)
						{
							liePeriod = text;
							bool result = true;
							return result;
						}
					}
					else
					{
						if ((now > dateTime && now < date.AddDays(1.0)) || now < t)
						{
							liePeriod = text;
							bool result = true;
							return result;
						}
					}
				}
			}
			liePeriod = string.Empty;
			return false;
		}
		public static bool BetweenPeriod(string periodStr, out string liePeriod)
		{
			string[] periodList = StringHelper.SplitString(periodStr, "\n");
			return ValidateHelper.BetweenPeriod(periodList, out liePeriod);
		}
		public static bool BetweenPeriod(string periodList)
		{
			string empty = string.Empty;
			return ValidateHelper.BetweenPeriod(periodList, out empty);
		}
		public static bool IsNumericArray(string[] numericStrList)
		{
			if (numericStrList != null && numericStrList.Length > 0)
			{
				for (int i = 0; i < numericStrList.Length; i++)
				{
					string numericStr = numericStrList[i];
					if (!ValidateHelper.IsNumeric(numericStr))
					{
						return false;
					}
				}
				return true;
			}
			return false;
		}
		public static bool IsNumericRule(string numericRuleStr, string splitChar)
		{
			return ValidateHelper.IsNumericArray(StringHelper.SplitString(numericRuleStr, splitChar));
		}
		public static bool IsNumericRule(string numericRuleStr)
		{
			return ValidateHelper.IsNumericRule(numericRuleStr, ",");
		}
		public static bool IsCN(string strInput)
		{
			Regex regex = new Regex("^[一-龥]+$");
			return regex.IsMatch(strInput);
		}
		public static bool IsCNName(string strInput)
		{
			return ValidateHelper._cnnameegex.IsMatch(strInput);
		}
	}
}
