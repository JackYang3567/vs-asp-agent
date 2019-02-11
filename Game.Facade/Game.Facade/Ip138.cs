using System;
using System.Net;
using System.Text;
using System.Web;
namespace Game.Facade
{
	public class Ip138
	{
		public static string GetIPData(string token, string ip = null, string datatype = "txt")
		{
			if (string.IsNullOrEmpty(ip))
			{
				ip = System.Web.HttpContext.Current.Request.UserHostAddress;
			}
			string address = string.Format("http://api.ip138.com/query/?ip={0}&datatype={1}&token={2}", ip, datatype, token);
			string result;
			using (WebClient webClient = new WebClient())
			{
				webClient.Encoding = System.Text.Encoding.UTF8;
				result = webClient.DownloadString(address);
			}
			return result;
		}
	}
}
