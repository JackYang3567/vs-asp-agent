using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
namespace Game.Facade
{
	public class JsonHelper
	{
		public static string SerializeObject(object o)
		{
			return JsonConvert.SerializeObject(o, Formatting.Indented, new JsonConverter[]
			{
				new IsoDateTimeConverter
				{
					DateTimeFormat = "yyyy-MM-dd HH:mm:ss"
				}
			});
		}
		public static T DeserializeJsonToObject<T>(string json) where T : class
		{
			JsonSerializer jsonSerializer = new JsonSerializer();
			System.IO.StringReader reader = new System.IO.StringReader(json);
			object obj = jsonSerializer.Deserialize(new JsonTextReader(reader), typeof(T));
			return obj as T;
		}
		public static System.Collections.Generic.List<T> DeserializeJsonToList<T>(string json) where T : class
		{
			JsonSerializer jsonSerializer = new JsonSerializer();
			System.IO.StringReader reader = new System.IO.StringReader(json);
			object obj = jsonSerializer.Deserialize(new JsonTextReader(reader), typeof(System.Collections.Generic.List<T>));
			return obj as System.Collections.Generic.List<T>;
		}
		public static T DeserializeAnonymousType<T>(string json, T anonymousTypeObject)
		{
			return JsonConvert.DeserializeAnonymousType<T>(json, anonymousTypeObject);
		}
	}
}
