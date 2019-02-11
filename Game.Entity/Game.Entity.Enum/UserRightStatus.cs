using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("用户权限")]
	[System.Serializable]
	public enum UserRightStatus
	{
		UR_CANNOT_PLAY = 1,
		UR_CANNOT_LOOKON,
		UR_CANNOT_WISPER = 4,
		UR_CANNOT_ROOM_CHAT = 8,
		UR_CANNOT_GAME_CHAT = 16,
		UR_CANNOT_TRANSFER_ACCOT = 64,
		UR_GAME_KICK_OUT_USER = 512,
		UR_GAME_MATCH_USER = 268435456,
		UR_GAME_ZUOBI_USER = 536870912
	}
}
