using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class RecordBuyMember
	{
		public const string Tablename = "RecordBuyMember";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberMonths = "MemberMonths";
		public const string _MemberPrice = "MemberPrice";
		public const string _Currency = "Currency";
		public const string _PresentScore = "PresentScore";
		public const string _BeforeCurrency = "BeforeCurrency";
		public const string _BeforeScore = "BeforeScore";
		public const string _ClinetIP = "ClinetIP";
		public const string _InputDate = "InputDate";
		private int m_recordID;
		private int m_userID;
		private int m_memberOrder;
		private int m_memberMonths;
		private decimal m_memberPrice;
		private decimal m_currency;
		private long m_presentScore;
		private decimal m_beforeCurrency;
		private long m_beforeScore;
		private string m_clinetIP;
		private System.DateTime m_inputDate;
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
		public int MemberOrder
		{
			get
			{
				return this.m_memberOrder;
			}
			set
			{
				this.m_memberOrder = value;
			}
		}
		public int MemberMonths
		{
			get
			{
				return this.m_memberMonths;
			}
			set
			{
				this.m_memberMonths = value;
			}
		}
		public decimal MemberPrice
		{
			get
			{
				return this.m_memberPrice;
			}
			set
			{
				this.m_memberPrice = value;
			}
		}
		public decimal Currency
		{
			get
			{
				return this.m_currency;
			}
			set
			{
				this.m_currency = value;
			}
		}
		public long PresentScore
		{
			get
			{
				return this.m_presentScore;
			}
			set
			{
				this.m_presentScore = value;
			}
		}
		public decimal BeforeCurrency
		{
			get
			{
				return this.m_beforeCurrency;
			}
			set
			{
				this.m_beforeCurrency = value;
			}
		}
		public long BeforeScore
		{
			get
			{
				return this.m_beforeScore;
			}
			set
			{
				this.m_beforeScore = value;
			}
		}
		public string ClinetIP
		{
			get
			{
				return this.m_clinetIP;
			}
			set
			{
				this.m_clinetIP = value;
			}
		}
		public System.DateTime InputDate
		{
			get
			{
				return this.m_inputDate;
			}
			set
			{
				this.m_inputDate = value;
			}
		}
		public RecordBuyMember()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_memberOrder = 0;
			this.m_memberMonths = 0;
			this.m_memberPrice = 0m;
			this.m_currency = 0m;
			this.m_presentScore = 0L;
			this.m_beforeCurrency = 0m;
			this.m_beforeScore = 0L;
			this.m_clinetIP = "";
			this.m_inputDate = System.DateTime.Now;
		}
	}
}
