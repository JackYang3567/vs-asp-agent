using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class GrowLevelConfig
	{
		public const string Tablename = "GrowLevelConfig";
		public const string _LevelID = "LevelID";
		public const string _Experience = "Experience";
		public const string _RewardGold = "RewardGold";
		public const string _RewardMedal = "RewardMedal";
		public const string _LevelRemark = "LevelRemark";
		private int m_levelID;
		private int m_experience;
		private int m_rewardGold;
		private int m_rewardMedal;
		private string m_levelRemark;
		public int LevelID
		{
			get
			{
				return this.m_levelID;
			}
			set
			{
				this.m_levelID = value;
			}
		}
		public int Experience
		{
			get
			{
				return this.m_experience;
			}
			set
			{
				this.m_experience = value;
			}
		}
		public int RewardGold
		{
			get
			{
				return this.m_rewardGold;
			}
			set
			{
				this.m_rewardGold = value;
			}
		}
		public int RewardMedal
		{
			get
			{
				return this.m_rewardMedal;
			}
			set
			{
				this.m_rewardMedal = value;
			}
		}
		public string LevelRemark
		{
			get
			{
				return this.m_levelRemark;
			}
			set
			{
				this.m_levelRemark = value;
			}
		}
		public GrowLevelConfig()
		{
			this.m_levelID = 0;
			this.m_experience = 0;
			this.m_rewardGold = 0;
			this.m_rewardMedal = 0;
			this.m_levelRemark = "";
		}
	}
}
