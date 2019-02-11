using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class MemberOrderHelper
	{
		public static string GetMemberOrderStatusDes(MemberOrderStatus status)
		{
			return EnumDescription.GetFieldText(status);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetMemberOrderStatusList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
