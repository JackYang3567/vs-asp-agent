using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class AccountsControl
	{
		public const string Tablename = "AccountsControl";
		public const string _UserID = "UserID";
		public const string _Accounts = "Accounts";
		public const string _ActiveDateTime = "ActiveDateTime";
		public const string _ControlStatus = "ControlStatus";
		public const string _ControlType = "ControlType";
		public const string _ChangeScore = "ChangeScore";
		public const string _SustainedTimeCount = "SustainedTimeCount";
		public const string _ConsumeTimeCount = "ConsumeTimeCount";
		public const string _WinRate = "WinRate";
		public const string _WinScore = "WinScore";
		public const string _LoseScore = "LoseScore";
		private int m_userID;
		private string m_accounts;
		private System.DateTime m_activeDateTime;
		private short m_controlStatus;
		private short m_controlType;
		private long m_changeScore;
		private int m_sustainedTimeCount;
		private int m_consumeTimeCount;
		private short m_winRate;
		private long m_winScore;
		private long m_loseScore;
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
		public string Accounts
		{
			get
			{
				return this.m_accounts;
			}
			set
			{
				this.m_accounts = value;
			}
		}
		public System.DateTime ActiveDateTime
		{
			get
			{
				return this.m_activeDateTime;
			}
			set
			{
				this.m_activeDateTime = value;
			}
		}
		public short ControlStatus
		{
			get
			{
				return this.m_controlStatus;
			}
			set
			{
				this.m_controlStatus = value;
			}
		}
		public short ControlType
		{
			get
			{
				return this.m_controlType;
			}
			set
			{
				this.m_controlType = value;
			}
		}
		public long ChangeScore
		{
			get
			{
				return this.m_changeScore;
			}
			set
			{
				this.m_changeScore = value;
			}
		}
		public int SustainedTimeCount
		{
			get
			{
				return this.m_sustainedTimeCount;
			}
			set
			{
				this.m_sustainedTimeCount = value;
			}
		}
		public int ConsumeTimeCount
		{
			get
			{
				return this.m_consumeTimeCount;
			}
			set
			{
				this.m_consumeTimeCount = value;
			}
		}
		public short WinRate
		{
			get
			{
				return this.m_winRate;
			}
			set
			{
				this.m_winRate = value;
			}
		}
		public long WinScore
		{
			get
			{
				return this.m_winScore;
			}
			set
			{
				this.m_winScore = value;
			}
		}
		public long LoseScore
		{
			get
			{
				return this.m_loseScore;
			}
			set
			{
				this.m_loseScore = value;
			}
		}
		public AccountsControl()
		{
			this.m_userID = 0;
			this.m_accounts = "";
			this.m_activeDateTime = System.DateTime.Now;
			this.m_controlStatus = 0;
			this.m_controlType = 0;
			this.m_changeScore = 0L;
			this.m_sustainedTimeCount = 0;
			this.m_consumeTimeCount = 0;
			this.m_winRate = 0;
			this.m_winScore = 0L;
			this.m_loseScore = 0L;
		}
	}
}
