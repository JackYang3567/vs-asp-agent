using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class SystemStreamInfo
	{
		public const string Tablename = "SystemStreamInfo";
		public const string _DateID = "DateID";
		public const string _WebLogonSuccess = "WebLogonSuccess";
		public const string _WebRegisterSuccess = "WebRegisterSuccess";
		public const string _GameLogonSuccess = "GameLogonSuccess";
		public const string _GameRegisterSuccess = "GameRegisterSuccess";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private int m_webLogonSuccess;
		private int m_webRegisterSuccess;
		private int m_gameLogonSuccess;
		private int m_gameRegisterSuccess;
		private System.DateTime m_collectDate;
		public int DateID
		{
			get
			{
				return this.m_dateID;
			}
			set
			{
				this.m_dateID = value;
			}
		}
		public int WebLogonSuccess
		{
			get
			{
				return this.m_webLogonSuccess;
			}
			set
			{
				this.m_webLogonSuccess = value;
			}
		}
		public int WebRegisterSuccess
		{
			get
			{
				return this.m_webRegisterSuccess;
			}
			set
			{
				this.m_webRegisterSuccess = value;
			}
		}
		public int GameLogonSuccess
		{
			get
			{
				return this.m_gameLogonSuccess;
			}
			set
			{
				this.m_gameLogonSuccess = value;
			}
		}
		public int GameRegisterSuccess
		{
			get
			{
				return this.m_gameRegisterSuccess;
			}
			set
			{
				this.m_gameRegisterSuccess = value;
			}
		}
		public System.DateTime CollectDate
		{
			get
			{
				return this.m_collectDate;
			}
			set
			{
				this.m_collectDate = value;
			}
		}
		public SystemStreamInfo()
		{
			this.m_dateID = 0;
			this.m_webLogonSuccess = 0;
			this.m_webRegisterSuccess = 0;
			this.m_gameLogonSuccess = 0;
			this.m_gameRegisterSuccess = 0;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
