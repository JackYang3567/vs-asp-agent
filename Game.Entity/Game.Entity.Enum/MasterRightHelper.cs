using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class MasterRightHelper
	{
		public static string GetMasterRightDes(MasterRightHelper status)
		{
			return EnumDescription.GetFieldText(status);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetMasterRightList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
