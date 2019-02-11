using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class GrantInfo
	{
		public const string Tablename = "GrantInfo";
		public const string _SiteID = "SiteID";
		public const string _GrantRoom = "GrantRoom";
		public const string _GrantStartDate = "GrantStartDate";
		public const string _GrantEndDate = "GrantEndDate";
		public const string _GrantObjet = "GrantObjet";
		public const string _MaxGrant = "MaxGrant";
		public const string _DayMaxGrant = "DayMaxGrant";
		private int m_siteID;
		private int m_grantRoom;
		private System.DateTime m_grantStartDate;
		private System.DateTime m_grantEndDate;
		private string m_grantObjet;
		private int m_maxGrant;
		private int m_dayMaxGrant;
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
		public int GrantRoom
		{
			get
			{
				return this.m_grantRoom;
			}
			set
			{
				this.m_grantRoom = value;
			}
		}
		public System.DateTime GrantStartDate
		{
			get
			{
				return this.m_grantStartDate;
			}
			set
			{
				this.m_grantStartDate = value;
			}
		}
		public System.DateTime GrantEndDate
		{
			get
			{
				return this.m_grantEndDate;
			}
			set
			{
				this.m_grantEndDate = value;
			}
		}
		public string GrantObjet
		{
			get
			{
				return this.m_grantObjet;
			}
			set
			{
				this.m_grantObjet = value;
			}
		}
		public int MaxGrant
		{
			get
			{
				return this.m_maxGrant;
			}
			set
			{
				this.m_maxGrant = value;
			}
		}
		public int DayMaxGrant
		{
			get
			{
				return this.m_dayMaxGrant;
			}
			set
			{
				this.m_dayMaxGrant = value;
			}
		}
		public GrantInfo()
		{
			this.m_siteID = 0;
			this.m_grantRoom = 0;
			this.m_grantStartDate = System.DateTime.Now;
			this.m_grantEndDate = System.DateTime.Now;
			this.m_grantObjet = "";
			this.m_maxGrant = 0;
			this.m_dayMaxGrant = 0;
		}
	}
}
