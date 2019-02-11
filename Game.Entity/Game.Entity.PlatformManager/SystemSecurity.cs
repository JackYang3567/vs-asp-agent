using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class SystemSecurity
	{
		public const string Tablename = "SystemSecurity";
		public const string _RecordID = "RecordID";
		public const string _OperatingTime = "OperatingTime";
		public const string _OperatingName = "OperatingName";
		public const string _OperatingIP = "OperatingIP";
		public const string _OperatingAccounts = "OperatingAccounts";
		private int m_recordID;
		private System.DateTime m_operatingTime;
		private string m_operatingName;
		private string m_operatingIP;
		private string m_operatingAccounts;
		public int RecordID
		{
			get
			{
				return this.m_recordID;
			}
			set
			{
				this.m_recordID = value;
			}
		}
		public System.DateTime OperatingTime
		{
			get
			{
				return this.m_operatingTime;
			}
			set
			{
				this.m_operatingTime = value;
			}
		}
		public string OperatingName
		{
			get
			{
				return this.m_operatingName;
			}
			set
			{
				this.m_operatingName = value;
			}
		}
		public string OperatingIP
		{
			get
			{
				return this.m_operatingIP;
			}
			set
			{
				this.m_operatingIP = value;
			}
		}
		public string OperatingAccounts
		{
			get
			{
				return this.m_operatingAccounts;
			}
			set
			{
				this.m_operatingAccounts = value;
			}
		}
		public string Remark
		{
			get;
			set;
		}
		public SystemSecurity()
		{
			this.m_recordID = 0;
			this.m_operatingTime = System.DateTime.Now;
			this.m_operatingName = "";
			this.m_operatingIP = "";
			this.m_operatingAccounts = "";
		}
	}
}
