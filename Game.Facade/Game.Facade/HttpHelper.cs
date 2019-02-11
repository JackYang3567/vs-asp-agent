using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
namespace Game.Facade
{
	public class HttpHelper
	{
		public static string HttpRequest(string url, string param)
		{
			return HttpHelper.HttpRequest(url, param, "post");
		}
		public static string HttpRequest(string url, string param, string method)
		{
			return HttpHelper.HttpRequest(url, param, method, "UTF-8");
		}
		public static string HttpRequest(string url, string param, string method, string charset)
		{
			if (method.ToLower() == "get")
			{
				url = url + "?" + param;
			}
			string result;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
				if (method.ToLower() == "post")
				{
					byte[] bytes = System.Text.Encoding.GetEncoding(charset).GetBytes(param);
					httpWebRequest.Method = "POST";
					httpWebRequest.ContentType = "application/x-www-form-urlencoded";
					httpWebRequest.ContentLength = (long)bytes.Length;
					using (System.IO.Stream requestStream = httpWebRequest.GetRequestStream())
					{
						requestStream.Write(bytes, 0, bytes.Length);
					}
				}
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				string text = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), System.Text.Encoding.GetEncoding(charset)).ReadToEnd();
				result = text;
			}
			catch (System.Exception ex)
			{
				result = ex.Message;
			}
			return result;
		}
		public static string GetParam(System.Collections.Generic.Dictionary<string, string> dic)
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
		public static string CreatFormHtml(string actionUrl, SortedDictionary<string, string> sParaTemp, string strMethod)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append(string.Concat(new string[]
			{
				"<form id='paysubmit' name='paysubmit' action='",
				actionUrl,
				"' method='",
				strMethod.ToLower().Trim(),
				"'>"
			}));
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in sParaTemp)
			{
				stringBuilder.Append(string.Concat(new string[]
				{
					"<input type='hidden' name='",
					current.Key,
					"' value='",
					current.Value,
					"'/>"
				}));
			}
			stringBuilder.Append("</form>");
			stringBuilder.Append("<script>document.forms['paysubmit'].submit();</script>");
			return stringBuilder.ToString();
		}
	}
}
