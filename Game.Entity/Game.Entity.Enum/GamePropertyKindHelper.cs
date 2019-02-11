using Game.Utils;
using System;
using System.Collections.Generic;
namespace Game.Entity.Enum
{
	public class GamePropertyKindHelper
	{
		public static string GetGamePropertyKindDes(GamePropertyKind kind)
		{
			return EnumDescription.GetFieldText(kind);
		}
		public static System.Collections.Generic.IList<EnumDescription> GetGamePropertyKindList(System.Type t)
		{
			return EnumDescription.GetFieldTexts(t);
		}
	}
}
