using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class GrantTimeCountsInfo
	{
		public const string Tablename = "GrantTimeCountsInfo";
		public const string _GrantID = "GrantID";
		public const string _GrantCouts = "GrantCouts";
		public const string _GrantScore = "GrantScore";
		public const string _GrantGameScore = "GrantGameScore";
		public const string _GrantLoveliness = "GrantLoveliness";
		public const string _GrantType = "GrantType";
		public const string _GrantExp = "GrantExp";
		public const string _SiteID = "SiteID";
		private int m_grantID;
		private int m_grantCouts;
		private int m_grantScore;
		private int m_grantGameScore;
		private int m_grantLoveliness;
		private int m_grantType;
		private int m_grantExp;
		private string m_siteID;
		public int GrantID
		{
			get
			{
				return this.m_grantID;
			}
			set
			{
				this.m_grantID = value;
			}
		}
		public int GrantCouts
		{
			get
			{
				return this.m_grantCouts;
			}
			set
			{
				this.m_grantCouts = value;
			}
		}
		public int GrantScore
		{
			get
			{
				return this.m_grantScore;
			}
			set
			{
				this.m_grantScore = value;
			}
		}
		public int GrantGameScore
		{
			get
			{
				return this.m_grantGameScore;
			}
			set
			{
				this.m_grantGameScore = value;
			}
		}
		public int GrantLoveliness
		{
			get
			{
				return this.m_grantLoveliness;
			}
			set
			{
				this.m_grantLoveliness = value;
			}
		}
		public int GrantType
		{
			get
			{
				return this.m_grantType;
			}
			set
			{
				this.m_grantType = value;
			}
		}
		public int GrantExp
		{
			get
			{
				return this.m_grantExp;
			}
			set
			{
				this.m_grantExp = value;
			}
		}
		public string SiteID
		{
			get
			{
				return this.m_siteID;
			}
			set
			{
				this.m_siteID = value;
			}
		}
		public GrantTimeCountsInfo()
		{
			this.m_grantID = 0;
			this.m_grantCouts = 0;
			this.m_grantScore = 0;
			this.m_grantGameScore = 0;
			this.m_grantLoveliness = 0;
			this.m_grantType = 0;
			this.m_grantExp = 0;
			this.m_siteID = "";
		}
	}
}
