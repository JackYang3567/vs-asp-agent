using System;
using System.IO;
using System.Net;
using System.Text;
namespace Game.Utils
{
	public class CodeHelper
	{
		public static string SendCode(string phone, string code, string content)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("name={0}", ApplicationSettings.Get("phoneName"));
			stringBuilder.AppendFormat("&pwd={0}", ApplicationSettings.Get("phonePwd"));
			stringBuilder.AppendFormat("&content={0}", content.Replace("@", code));
			stringBuilder.AppendFormat("&mobile={0}", phone);
			stringBuilder.AppendFormat("&sign={0}", ApplicationSettings.Get("phoneSign"));
			stringBuilder.Append("&type=pt");
			string text = CodeHelper.PushToWeb("http://web.wasun.cn/asmx/smsservice.aspx", stringBuilder.ToString(), System.Text.Encoding.UTF8);
			string[] array = text.Split(new char[]
			{
				','
			});
			if (array[0] == "0")
			{
				return "发送成功";
			}
			string str = array[1];
			return "发送失败：" + str;
		}
		private static string PushToWeb(string weburl, string data, System.Text.Encoding encode)
		{
			byte[] bytes = encode.GetBytes(data);
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(new Uri(weburl));
			httpWebRequest.Method = "POST";
			httpWebRequest.ContentType = "application/x-www-form-urlencoded";
			httpWebRequest.ContentLength = (long)bytes.Length;
			System.IO.Stream requestStream = httpWebRequest.GetRequestStream();
			requestStream.Write(bytes, 0, bytes.Length);
			requestStream.Close();
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			System.IO.StreamReader streamReader = new System.IO.StreamReader(httpWebResponse.GetResponseStream(), encode);
			return streamReader.ReadToEnd();
		}
	}
}
