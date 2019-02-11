using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("道具作用范围")]
	[System.Serializable]
	public enum ServiceArea
	{
		A_MYSELF = 1,
		A_PLAYER,
		A_LOOKER = 4
	}
}
