using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class GameConfig
	{
		public const string Tablename = "GameConfig";
		public const string _KindID = "KindID";
		public const string _NoticeChangeGolds = "NoticeChangeGolds";
		public const string _WinExperience = "WinExperience";
		private int m_kindID;
		private long m_noticeChangeGolds;
		private int m_winExperience;
		public int KindID
		{
			get
			{
				return this.m_kindID;
			}
			set
			{
				this.m_kindID = value;
			}
		}
		public long NoticeChangeGolds
		{
			get
			{
				return this.m_noticeChangeGolds;
			}
			set
			{
				this.m_noticeChangeGolds = value;
			}
		}
		public int WinExperience
		{
			get
			{
				return this.m_winExperience;
			}
			set
			{
				this.m_winExperience = value;
			}
		}
		public GameConfig()
		{
			this.m_kindID = 0;
			this.m_noticeChangeGolds = 0L;
			this.m_winExperience = 0;
		}
	}
}
