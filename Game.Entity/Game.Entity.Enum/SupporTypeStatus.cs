using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("支持类型")]
	[System.Serializable]
	public enum SupporTypeStatus
	{
		SP_TREASURE = 1,
		SP_SCORE,
		SP_Timing_Match = 4,
		SP_EXERCISE = 8,
		SP_Immediately_Match = 16
	}
}
