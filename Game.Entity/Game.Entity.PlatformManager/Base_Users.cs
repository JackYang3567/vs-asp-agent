using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_Users
	{
		public const string Tablename = "Base_Users";
		public const string _UserID = "UserID";
		public const string _Username = "Username";
		public const string _Password = "Password";
		public const string _RoleID = "RoleID";
		public const string _Nullity = "Nullity";
		public const string _PreLogintime = "PreLogintime";
		public const string _PreLoginIP = "PreLoginIP";
		public const string _LastLogintime = "LastLogintime";
		public const string _LastLoginIP = "LastLoginIP";
		public const string _LoginTimes = "LoginTimes";
		public const string _IsBand = "IsBand";
		public const string _BandIP = "BandIP";
		public const string _IsAssist = "IsAssist";
		private int m_userID;
		private string m_username;
		private string m_password;
		private int m_roleID;
		private byte m_nullity;
		private System.DateTime m_preLogintime;
		private string m_preLoginIP;
		private System.DateTime m_lastLogintime;
		private string m_lastLoginIP;
		private int m_loginTimes;
		private int m_isBand;
		private string m_bandIP;
		private byte m_isAssist;
		private int moudleId;
		public int MoudleID
		{
			get
			{
				return this.moudleId;
			}
			set
			{
				this.moudleId = value;
			}
		}
		public int UserID
		{
			get
			{
				return this.m_userID;
			}
			set
			{
				this.m_userID = value;
			}
		}
		public string Username
		{
			get
			{
				return this.m_username;
			}
			set
			{
				this.m_username = value;
			}
		}
		public string Password
		{
			get
			{
				return this.m_password;
			}
			set
			{
				this.m_password = value;
			}
		}
		public int RoleID
		{
			get
			{
				return this.m_roleID;
			}
			set
			{
				this.m_roleID = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public System.DateTime PreLogintime
		{
			get
			{
				return this.m_preLogintime;
			}
			set
			{
				this.m_preLogintime = value;
			}
		}
		public string PreLoginIP
		{
			get
			{
				return this.m_preLoginIP;
			}
			set
			{
				this.m_preLoginIP = value;
			}
		}
		public System.DateTime LastLogintime
		{
			get
			{
				return this.m_lastLogintime;
			}
			set
			{
				this.m_lastLogintime = value;
			}
		}
		public string LastLoginIP
		{
			get
			{
				return this.m_lastLoginIP;
			}
			set
			{
				this.m_lastLoginIP = value;
			}
		}
		public int LoginTimes
		{
			get
			{
				return this.m_loginTimes;
			}
			set
			{
				this.m_loginTimes = value;
			}
		}
		public int IsBand
		{
			get
			{
				return this.m_isBand;
			}
			set
			{
				this.m_isBand = value;
			}
		}
		public string BandIP
		{
			get
			{
				return this.m_bandIP;
			}
			set
			{
				this.m_bandIP = value;
			}
		}
		public byte IsAssist
		{
			get
			{
				return this.m_isAssist;
			}
			set
			{
				this.m_isAssist = value;
			}
		}
		public string MobilePhone
		{
			get;
			set;
		}
		public bool IsMobileNeed
		{
			get;
			set;
		}
		public Base_Users()
		{
			this.m_userID = 0;
			this.m_username = "";
			this.m_password = "";
			this.m_roleID = 0;
			this.m_nullity = 0;
			this.m_preLogintime = System.DateTime.Now;
			this.m_preLoginIP = "";
			this.m_lastLogintime = System.DateTime.Now;
			this.m_lastLoginIP = "";
			this.m_loginTimes = 0;
			this.m_isBand = 0;
			this.m_bandIP = "";
			this.m_isAssist = 0;
			this.moudleId = 0;
		}
	}
}
