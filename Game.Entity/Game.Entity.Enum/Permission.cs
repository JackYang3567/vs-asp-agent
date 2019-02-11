using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("管理员操作权限")]
	[System.Serializable]
	public enum Permission
	{
		Read = 1,
		Add,
		Edit = 4,
		Delete = 8,
		GrantMember = 16,
		GrantTreasure = 32,
		GrantExperience = 64,
		GrantScore = 128,
		GrantGameID = 256,
		ClearScore = 512,
		ClearFlee = 1024,
		CreateCard = 2048,
		ExportCard = 4096,
		Enable = 8192,
		IsRobot = 16384,
		IsNulity = 32768,
		OrderOperating = 65536,
		SendMail = 131072
	}
}
