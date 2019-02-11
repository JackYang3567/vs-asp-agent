using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class NoticeLocationHelper
	{
		public static string GetNoticeLocationDes(NoticeLocation status)
		{
			return EnumDescription.GetFieldText(status);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetNoticeLocationList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
