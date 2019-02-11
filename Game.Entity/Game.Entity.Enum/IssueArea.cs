using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("道具使用范围")]
	[System.Serializable]
	public enum IssueArea
	{
		A_MALL = 1,
		A_GAME,
		A_GAMEROOM = 4
	}
}
