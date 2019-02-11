using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class QPAdminSiteInfo
	{
		public const string Tablename = "QPAdminSiteInfo";
		public const string _SiteID = "SiteID";
		public const string _SiteName = "SiteName";
		public const string _PageSize = "PageSize";
		public const string _CopyRight = "CopyRight";
		private int m_siteID;
		private string m_siteName;
		private int m_pageSize;
		private string m_copyRight;
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
		public string SiteName
		{
			get
			{
				return this.m_siteName;
			}
			set
			{
				this.m_siteName = value;
			}
		}
		public int PageSize
		{
			get
			{
				return this.m_pageSize;
			}
			set
			{
				this.m_pageSize = value;
			}
		}
		public string CopyRight
		{
			get
			{
				return this.m_copyRight;
			}
			set
			{
				this.m_copyRight = value;
			}
		}
		public QPAdminSiteInfo()
		{
			this.m_siteID = 0;
			this.m_siteName = "";
			this.m_pageSize = 0;
			this.m_copyRight = "";
		}
	}
}
