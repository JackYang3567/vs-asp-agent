using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class ServiceAreaHelper
	{
		public static string GetServiceAreaDes(ServiceArea status)
		{
			return EnumDescription.GetFieldText(status);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetServiceAreaList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
