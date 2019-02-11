using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class UserRightHelper
	{
		public static string GetUserRightDes(UserRightStatus status)
		{
			return EnumDescription.GetFieldText(status);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetUserRightList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
