using System;
using System.Collections.Generic;
using System.Web.Script.Serialization;
namespace Game.Facade
{
	public class RequestMessage
	{
		private System.Collections.Generic.Dictionary<string, object> _data = new System.Collections.Generic.Dictionary<string, object>();
		public int msgid
		{
			get;
			set;
		}
		public System.Collections.Generic.Dictionary<string, object> content
		{
			get
			{
				return this._data;
			}
			set
			{
				this._data = value;
			}
		}
		public RequestMessage(int id)
		{
			this.msgid = id;
		}
		public void AddDataItem(string key, object value)
		{
			this._data.Add(key, value);
		}
		public void SetDataItem(string key, object value)
		{
			this._data[key] = value;
		}
		public string SerializeToJson()
		{
			return new JavaScriptSerializer().Serialize(this);
		}
		public string Post()
		{
			string param = this.SerializeToJson();
			return HttpHelper.HttpRequest(AppConfig.ServerUrl, param, "post", "GB2312");
		}
	}
}
