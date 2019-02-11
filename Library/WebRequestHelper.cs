using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
namespace Library
{
	public class WebRequestHelper
	{
		public static string PostHttp(string url, string data, string contentType)
		{
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
			httpWebRequest.ContentType = contentType;
			httpWebRequest.Method = "POST";
			httpWebRequest.Timeout = 20000;
			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(data);
			httpWebRequest.ContentLength = (long)bytes.Length;
			httpWebRequest.GetRequestStream().Write(bytes, 0, bytes.Length);
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream());
			string result = streamReader.ReadToEnd();
			httpWebResponse.Close();
			streamReader.Close();
			httpWebRequest.Abort();
			httpWebResponse.Close();
			return result;
		}
		public static string Request_WebClient(string uri, string paramStr, System.Text.Encoding encoding, string username, string password)
		{
			if (encoding == null)
			{
				encoding = System.Text.Encoding.UTF8;
			}
			string arg_0F_0 = string.Empty;
			WebClient webClient = new WebClient();
			webClient.Headers.Add("Content-Type", "application/x-www-form-urlencoded");
			byte[] bytes = encoding.GetBytes(paramStr);
			if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
			{
				webClient.Credentials = WebRequestHelper.GetCredentialCache(uri, username, password);
				webClient.Headers.Add("Authorization", WebRequestHelper.GetAuthorization(username, password));
			}
			byte[] bytes2 = webClient.UploadData(uri, "POST", bytes);
			return encoding.GetString(bytes2);
		}
		public static string WebApiPost(string uri, string postData)
		{
			HttpContent httpContent = new StringContent(postData);
			httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
			HttpClient httpClient = new HttpClient();
			return httpClient.PostAsync(uri, httpContent).Result.Content.ReadAsStringAsync().Result;
		}
		public static string GetHttp(string baseUrl, System.Collections.Generic.Dictionary<string, string> dictParam, bool isurlencode = true)
		{
			string result = string.Empty;
			string lastUrl = WebRequestHelper.GetLastUrl(baseUrl, dictParam, isurlencode);
			WebRequest webRequest = WebRequest.Create(new Uri(lastUrl));
			webRequest.Timeout = 20000;
			WebResponse response = webRequest.GetResponse();
			System.IO.Stream responseStream = response.GetResponseStream();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.UTF8);
			result = streamReader.ReadToEnd();
			streamReader.Close();
			responseStream.Close();
			return result;
		}
		private static CredentialCache GetCredentialCache(string uri, string username, string password)
		{
			string.Format("{0}:{1}", username, password);
			return new CredentialCache
			{

				{
					new Uri(uri),
					"Basic",
					new NetworkCredential(username, password)
				}
			};
		}
		private static string GetAuthorization(string username, string password)
		{
			string s = string.Format("{0}:{1}", username, password);
			return "Basic " + System.Convert.ToBase64String(new System.Text.ASCIIEncoding().GetBytes(s));
		}
		private static string GetLastUrl(string baseUrl, System.Collections.Generic.Dictionary<string, string> dictParam, bool isurlencode = true)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(baseUrl);
			if (dictParam != null && dictParam.Count > 0)
			{
				stringBuilder.Append("?");
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictParam)
				{
					stringBuilder.Append(string.Format("{0}={1}", current.Key, isurlencode ? System.Web.HttpUtility.UrlEncode(current.Value, System.Text.Encoding.UTF8) : current.Value));
					if (num < dictParam.Count - 1)
					{
						stringBuilder.Append("&");
					}
					num++;
				}
			}
			return stringBuilder.ToString();
		}
		public static string GetPostData(System.Collections.Generic.Dictionary<string, string> dictParam, bool isurlencode = true)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			if (dictParam != null && dictParam.Count > 0)
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, string> current in dictParam)
				{
					stringBuilder.Append(string.Format("{0}={1}", current.Key, isurlencode ? System.Web.HttpUtility.UrlEncode(current.Value, System.Text.Encoding.UTF8) : current.Value));
					if (num < dictParam.Count - 1)
					{
						stringBuilder.Append("&");
					}
					num++;
				}
			}
			return stringBuilder.ToString();
		}
		public static string CreatFormHtml(string actionUrl, SortedDictionary<string, string> sParaTemp, string strMethod, string strButtonValue)
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
			stringBuilder.Append("<input type='submit' value='" + strButtonValue + "' style='display:none;'></form>");
			stringBuilder.Append("<script>document.forms['paysubmit'].submit();</script>");
			return stringBuilder.ToString();
		}
	}
}
