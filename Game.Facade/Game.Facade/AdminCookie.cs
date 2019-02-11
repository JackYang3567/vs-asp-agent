using Game.Entity.Accounts;
using Game.Entity.PlatformManager;
using Game.Utils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Security;
namespace Game.Facade
{
	public class AdminCookie
	{
		private static string ValidateKey = "{2EF1D4CB-16BA-471D-9DFC-12C1E4D15253}";
		private static string ValidateName = "VS";
		private static string ExpireTimeStr = "_ETS";
		protected static string CookiesName
		{
			get
			{
				string appSetting = Utility.GetAppSetting("CookiesName");
				if (!string.IsNullOrEmpty(appSetting))
				{
					return appSetting;
				}
				if (!string.IsNullOrEmpty(Fetch.GetCookieName))
				{
					return Fetch.GetCookieName;
				}
				return "Default";
			}
		}
		protected static System.DateTime CookiesExpire
		{
			get
			{
				int num;
				if (!int.TryParse(Utility.GetAppSetting("CookiesExpireMinutes"), out num))
				{
					num = 30;
				}
				return System.DateTime.Now.AddMinutes((double)num);
			}
		}
		protected static string CookiesPath
		{
			get
			{
				string appSetting = Utility.GetAppSetting("CookiesPath");
				if (!string.IsNullOrEmpty(appSetting))
				{
					return appSetting;
				}
				return "/";
			}
		}
		protected static string CookiesDomain
		{
			get
			{
				string appSetting = Utility.GetAppSetting("CookiesDomain");
				if (!string.IsNullOrEmpty(appSetting))
				{
					return appSetting;
				}
				return "";
			}
		}
		public static void SetUserCookie(Base_Users user)
		{
			AdminCookie.Add(new System.Collections.Generic.Dictionary<string, object>
			{

				{
					"UserID",
					user.UserID
				},

				{
					"Username",
					user.Username
				},

				{
					"RoleID",
					user.RoleID
				},

				{
					"IsBand",
					user.IsBand
				}
			}, new int?(30));
		}
		public static Base_Users GetUserFromCookie()
		{
			if (System.Web.HttpContext.Current == null)
			{
				return null;
			}
			Base_Users base_Users = new Base_Users();
			object value = AdminCookie.GetValue("UserID");
			object value2 = AdminCookie.GetValue("Username");
			object value3 = AdminCookie.GetValue("RoleID");
			object value4 = AdminCookie.GetValue("IsBand");
			if (value == null || value2 == null || value3 == null || value4 == null)
			{
				return null;
			}
			base_Users.UserID = int.Parse(value.ToString());
			base_Users.Username = value2.ToString();
			base_Users.RoleID = int.Parse(value3.ToString());
			base_Users.IsBand = int.Parse(value4.ToString());
			AdminCookie.SetUserCookie(base_Users);
			return base_Users;
		}
		public static AgentInfo GetAgentInfoFromCookie()
		{
			System.Web.HttpContext current = System.Web.HttpContext.Current;
			if (current == null)
			{
				return null;
			}
			if (current.Session["agentinfo"] == null)
			{
				return null;
			}
			return current.Session["agentinfo"] as AgentInfo;
		}
		public static void SetAgentCookieNew(AgentInfo user)
		{
			System.Web.HttpContext.Current.Session["agentinfo"] = user;
		}
		public static void ClearUserCookie()
		{
			if (System.Web.HttpContext.Current == null)
			{
				return;
			}
			System.Web.HttpCookie httpCookie = System.Web.HttpContext.Current.Request.Cookies[Fetch.GetCookieName];
			httpCookie.Expires = System.DateTime.Now.AddYears(-1);
			System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public static bool CheckedUserLogon()
		{
			Base_Users userFromCookie = AdminCookie.GetUserFromCookie();
			if (userFromCookie == null || userFromCookie.UserID <= 0 || userFromCookie.RoleID <= 0)
			{
				return false;
			}
			AdminCookie.SetUserCookie(userFromCookie);
			return true;
		}
		private static string GetCookie(string strKey)
		{
			return Utility.UrlDecode(Utility.GetCookie(Fetch.GetCookieName, strKey));
		}
		public static void Add(string key, object value, int? timeout)
		{
			System.Web.HttpCookie httpCookie = System.Web.HttpContext.Current.Request.Cookies[AdminCookie.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new System.Web.HttpCookie(AdminCookie.CookiesName);
			}
			httpCookie.Expires = System.DateTime.Now.AddYears(50);
			httpCookie.Domain = AdminCookie.CookiesDomain;
			httpCookie.Values[key] = System.Web.HttpUtility.UrlEncode(value.ToString());
			httpCookie.Values[key + AdminCookie.ExpireTimeStr] = ((!timeout.HasValue) ? System.Web.HttpUtility.UrlEncode(AdminCookie.CookiesExpire.ToString("yyyy-MM-dd HH:mm:ss")) : System.Web.HttpUtility.UrlEncode(System.DateTime.Now.AddMinutes((double)timeout.Value).ToString("yyyy-MM-dd HH:mm:ss")));
			httpCookie.Values[AdminCookie.ValidateName] = AdminCookie.GetValidateStr(httpCookie);
			System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public static void Add(System.Collections.Generic.Dictionary<string, object> dic, int? timeout)
		{
			System.Web.HttpCookie httpCookie = System.Web.HttpContext.Current.Request.Cookies[AdminCookie.CookiesName];
			if (httpCookie == null)
			{
				httpCookie = new System.Web.HttpCookie(AdminCookie.CookiesName);
			}
			httpCookie.Expires = System.DateTime.Now.AddYears(50);
			httpCookie.Domain = AdminCookie.CookiesDomain;
			foreach (System.Collections.Generic.KeyValuePair<string, object> current in dic)
			{
				httpCookie.Values[current.Key] = System.Web.HttpUtility.UrlEncode(current.Value.ToString());
				httpCookie.Values[current.Key + AdminCookie.ExpireTimeStr] = ((!timeout.HasValue) ? System.Web.HttpUtility.UrlEncode(AdminCookie.CookiesExpire.ToString("yyyy-MM-dd HH:mm:ss")) : System.Web.HttpUtility.UrlEncode(System.DateTime.Now.AddMinutes((double)timeout.Value).ToString("yyyy-MM-dd HH:mm:ss")));
			}
			httpCookie.Values[AdminCookie.ValidateName] = AdminCookie.GetValidateStr(httpCookie);
			System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
		}
		public static object GetValue(string key)
		{
			if (key != null && key != "")
			{
				System.Web.HttpCookie httpCookie = System.Web.HttpContext.Current.Request.Cookies[AdminCookie.CookiesName];
				if (httpCookie == null)
				{
					return null;
				}
				httpCookie.Expires = System.DateTime.Now.AddYears(50);
				httpCookie.Domain = AdminCookie.CookiesDomain;
				if (!AdminCookie.ValidateCookies(httpCookie))
				{
					httpCookie.Expires = System.DateTime.Now.AddYears(-1);
					System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
					return null;
				}
				string text = httpCookie.Values[key + AdminCookie.ExpireTimeStr];
				System.DateTime t;
				if (string.IsNullOrEmpty(text) || !System.DateTime.TryParse(System.Web.HttpUtility.UrlDecode(text), out t))
				{
					httpCookie.Values[key] = "";
					httpCookie.Values[key + AdminCookie.ExpireTimeStr] = "";
					httpCookie.Values[AdminCookie.ValidateName] = AdminCookie.GetValidateStr(httpCookie);
					System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
					return null;
				}
				System.DateTime now = System.DateTime.Now;
				if (t > now)
				{
					return System.Web.HttpUtility.UrlDecode(httpCookie.Values[key]);
				}
				httpCookie.Values[key] = "";
				httpCookie.Values[key + AdminCookie.ExpireTimeStr] = "";
				httpCookie.Values[AdminCookie.ValidateName] = AdminCookie.GetValidateStr(httpCookie);
				System.Web.HttpContext.Current.Response.Cookies.Add(httpCookie);
			}
			return null;
		}
		private static string GetValidateStr(System.Web.HttpCookie ck)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			string[] allKeys = ck.Values.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				string text = allKeys[i];
				if (text != AdminCookie.ValidateName)
				{
					stringBuilder.Append(ck.Values[text]);
				}
			}
			stringBuilder.Append(AdminCookie.ValidateKey);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["INSTANCE_ID"]);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);
			return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToLower().Substring(8, 16);
		}
		private static bool ValidateCookies(System.Web.HttpCookie ck)
		{
			string text = ck.Values[AdminCookie.ValidateName];
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			string[] allKeys = ck.Values.AllKeys;
			for (int i = 0; i < allKeys.Length; i++)
			{
				string text2 = allKeys[i];
				if (text2 != AdminCookie.ValidateName)
				{
					stringBuilder.Append(ck.Values[text2]);
				}
			}
			stringBuilder.Append(AdminCookie.ValidateKey);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["LOCAL_ADDR"]);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["INSTANCE_ID"]);
			stringBuilder.Append(System.Web.HttpContext.Current.Request.ServerVariables["HTTP_USER_AGENT"]);
			string value = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(stringBuilder.ToString(), "md5").ToLower().Substring(8, 16);
			return text.Equals(value);
		}
	}
}
