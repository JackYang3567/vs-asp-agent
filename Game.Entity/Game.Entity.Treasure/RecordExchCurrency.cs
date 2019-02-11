using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class RecordExchCurrency
	{
		public const string Tablename = "RecordExchCurrency";
		public const string _RecordID = "RecordID";
		public const string _CardID = "CardID";
		public const string _CardName = "CardName";
		public const string _CardPrice = "CardPrice";
		public const string _ExchNum = "ExchNum";
		public const string _UserID = "UserID";
		public const string _ExchCurrency = "ExchCurrency";
		public const string _PresentScore = "PresentScore";
		public const string _BeforeCurrency = "BeforeCurrency";
		public const string _BeforeScore = "BeforeScore";
		public const string _ClinetIP = "ClinetIP";
		public const string _InputDate = "InputDate";
		private int m_recordID;
		private int m_cardID;
		private string m_cardName;
		private decimal m_cardPrice;
		private int m_exchNum;
		private int m_userID;
		private decimal m_exchCurrency;
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
		public int CardID
		{
			get
			{
				return this.m_cardID;
			}
			set
			{
				this.m_cardID = value;
			}
		}
		public string CardName
		{
			get
			{
				return this.m_cardName;
			}
			set
			{
				this.m_cardName = value;
			}
		}
		public decimal CardPrice
		{
			get
			{
				return this.m_cardPrice;
			}
			set
			{
				this.m_cardPrice = value;
			}
		}
		public int ExchNum
		{
			get
			{
				return this.m_exchNum;
			}
			set
			{
				this.m_exchNum = value;
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
		public decimal ExchCurrency
		{
			get
			{
				return this.m_exchCurrency;
			}
			set
			{
				this.m_exchCurrency = value;
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
		public RecordExchCurrency()
		{
			this.m_recordID = 0;
			this.m_cardID = 0;
			this.m_cardName = "";
			this.m_cardPrice = 0m;
			this.m_exchNum = 0;
			this.m_userID = 0;
			this.m_exchCurrency = 0m;
			this.m_presentScore = 0L;
			this.m_beforeCurrency = 0m;
			this.m_beforeScore = 0L;
			this.m_clinetIP = "";
			this.m_inputDate = System.DateTime.Now;
		}
	}
}
