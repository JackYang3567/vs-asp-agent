using System;
namespace Game.Facade
{
	public class EnumerationList
	{
		[System.Serializable]
		public enum MallNeedInfo
		{
			Compellation = 1,
			PhoneNumber,
			QQNumber = 4,
			AdressAndCode = 8
		}
		public enum AwardOrderStatus
		{
			处理中,
			已发货,
			已收货,
			申请退货,
			同意退货等待客户发货,
			拒绝退货,
			退货成功
		}
		public enum TaskType
		{
			总赢局 = 1,
			总局数,
			首胜 = 4,
			总赢取 = 8,
			总输额 = 16,
			充值金额 = 32
		}
		public enum SystemStatusKey
		{
			WinExperience
		}
		public enum SiteConfigKey
		{
			ContactConfig,
			SiteConfig,
			GameFullPackageConfig,
			GameJanePackageConfig,
			EmailConfig
		}
		public enum SpreadTypes
		{
			注册 = 1,
			游戏时长,
			充值,
			结算
		}
		public enum ClearTableTypes
		{
			玩家进出记录表 = 1,
			游戏记录总局表,
			游戏记录详情表,
			银行操作记录表
		}
		public enum MatchType
		{
			定时赛,
			即时赛
		}
		public enum MatchFeeType
		{
			金币,
			元宝
		}
		public enum UploadFileEnum
		{
			MatchImg = 1,
			EditImg,
			MobileImg,
			PcNewsImg,
			RulesImg,
			ActivityImg,
			SiteLogoImg,
			SiteAdminlogoImg,
			SiteMobileLogoImg,
			SiteMobileRegLogoImg
		}
		public enum MemberType
		{
			普通会员
		}
	}
}
