using Game.Utils;
using System;
namespace Game.Entity.Enum
{
	[EnumDescription("充值渠道")]
	[System.Serializable]
	public enum PayType
	{
		WXJFB = 1,
		QQJFB,
		KJHYF = 4,
		WXTXF = 8,
		ZFBTXF = 16,
		QQTXF = 32,
		WXQYF = 64,
		WXSMQYF = 128,
		ZFBQYF = 256,
		ZFBSM = 512,
		QQQYF = 1024,
		QQSMQYF = 2048,
		KJQYF = 4096,
		WXDDB = 8192,
		ZFBDDB = 16384,
		QQDDB = 32768
	}
}
