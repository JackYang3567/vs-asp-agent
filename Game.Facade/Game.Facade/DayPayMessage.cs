using System;
using System.Xml;
namespace Game.Facade
{
	public class DayPayMessage
	{
		public string path;
		public DayPayMessage(string path)
		{
			this.path = path;
		}
		public string GetDayPayMessage(string typeID)
		{
			string result = "未知原因";
			XmlReader xmlReader = XmlReader.Create(this.path);
			while (xmlReader.Read())
			{
				if (xmlReader.HasAttributes && xmlReader.GetAttribute("MessageID") == typeID)
				{
					xmlReader.Read();
					xmlReader.Read();
					result = xmlReader.ReadString();
					break;
				}
			}
			xmlReader.Close();
			return result;
		}
	}
}
