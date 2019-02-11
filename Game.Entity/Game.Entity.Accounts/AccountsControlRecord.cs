using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class AccountsControlRecord
	{
		public const string Tablename = "AccountsControlRecord";
		public const string _ID = "ID";
		public const string _UserID = "UserID";
		public const string _Accounts = "Accounts";
		public const string _ControlStatus = "ControlStatus";
		public const string _ControlType = "ControlType";
		public const string _ChangeScore = "ChangeScore";
		public const string _SustainedTimeCount = "SustainedTimeCount";
		public const string _ConsumeTimeCount = "ConsumeTimeCount";
		public const string _ConcludeType = "ConcludeType";
		public const string _StartDateTime = "StartDateTime";
		public const string _ConcludeDateTime = "ConcludeDateTime";
		public const string _WinRate = "WinRate";
		public const string _WinScore = "WinScore";
		public const string _LoseScore = "LoseScore";
		private int m_iD;
		private int m_userID;
		private string m_accounts;
		private short m_controlStatus;
		private short m_controlType;
		private decimal m_changeScore;
		private int m_sustainedTimeCount;
		private int m_consumeTimeCount;
		private short m_concludeType;
		private System.DateTime m_startDateTime;
		private System.DateTime m_concludeDateTime;
		private short m_winRate;
		private decimal m_winScore;
		private decimal m_loseScore;
		public int ID
		{
			get
			{
				return this.m_iD;
			}
			set
			{
				this.m_iD = value;
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
		public decimal ChangeScore
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
		public short ConcludeType
		{
			get
			{
				return this.m_concludeType;
			}
			set
			{
				this.m_concludeType = value;
			}
		}
		public System.DateTime StartDateTime
		{
			get
			{
				return this.m_startDateTime;
			}
			set
			{
				this.m_startDateTime = value;
			}
		}
		public System.DateTime ConcludeDateTime
		{
			get
			{
				return this.m_concludeDateTime;
			}
			set
			{
				this.m_concludeDateTime = value;
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
		public decimal WinScore
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
		public decimal LoseScore
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
		public AccountsControlRecord()
		{
			this.m_iD = 0;
			this.m_userID = 0;
			this.m_accounts = "";
			this.m_controlStatus = 0;
			this.m_controlType = 0;
			this.m_changeScore = 0m;
			this.m_sustainedTimeCount = 0;
			this.m_consumeTimeCount = 0;
			this.m_concludeType = 0;
			this.m_startDateTime = System.DateTime.Now;
			this.m_concludeDateTime = System.DateTime.Now;
			this.m_winRate = 0;
			this.m_winScore = 0m;
			this.m_loseScore = 0m;
		}
	}
}
