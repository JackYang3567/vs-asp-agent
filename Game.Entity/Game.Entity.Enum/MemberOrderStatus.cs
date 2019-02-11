using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("会员等级")]
	[System.Serializable]
	public enum MemberOrderStatus
	{
		普通玩家,
		VIP1,
		VIP2,
		VIP3,
		VIP4,
		VIP5
	}
}
