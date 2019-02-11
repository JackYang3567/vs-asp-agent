using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("管理权限")]
	[System.Serializable]
	public enum MasterRightStatus
	{
		UR_CAN_LIMIT_PLAY = 1,
		UR_CAN_LIMIT_LOOKON,
		UR_CAN_LIMIT_WISPER = 4,
		UR_CAN_LIMIT_ROOM_CHAT = 8,
		UR_CAN_LIMIT_GAME_CHAT = 16,
		UR_CAN_KILL_USER = 256,
		UR_CAN_DISMISS_GAME = 1024,
		UR_CAN_ISSUE_MESSAGE = 16777216,
		UR_CAN_MANAGER_SERVER = 33554432,
		UR_CAN_MANAGER_ANDROID = 134217728
	}
}
