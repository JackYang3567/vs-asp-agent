using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class QPAdminSiteInfo
	{
		public const string Tablename = "QPAdminSiteInfo";
		public const string _SiteID = "SiteID";
		public const string _Revenue = "Revenue";
		public const string _GameScore = "GameScore";
		private int m_siteID;
		private decimal m_revenue;
		private long m_gameScore;
		public int SiteID
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
		public decimal Revenue
		{
			get
			{
				return this.m_revenue;
			}
			set
			{
				this.m_revenue = value;
			}
		}
		public long GameScore
		{
			get
			{
				return this.m_gameScore;
			}
			set
			{
				this.m_gameScore = value;
			}
		}
		public QPAdminSiteInfo()
		{
			this.m_siteID = 0;
			this.m_revenue = 0m;
			this.m_gameScore = 0L;
		}
	}
}
