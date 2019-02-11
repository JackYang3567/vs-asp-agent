using System;
namespace Game.Entity.Record
{
	[System.Serializable]
	public class RecordEveryDayData
	{
		public const string Tablename = "RecordEveryDayData";
		public const string _DateID = "DateID";
		public const string _UserTotal = "UserTotal";
		public const string _PayUserTotal = "PayUserTotal";
		public const string _ActiveUserTotal = "ActiveUserTotal";
		public const string _LossUserTotal = "LossUserTotal";
		public const string _LossPayUserTotal = "LossPayUserTotal";
		public const string _PayTotalAmount = "PayTotalAmount";
		public const string _PayAmountForCurrency = "PayAmountForCurrency";
		public const string _GoldTotal = "GoldTotal";
		public const string _CurrencyTotal = "CurrencyTotal";
		public const string _GameTax = "GameTax";
		public const string _GameTaxTotal = "GameTaxTotal";
		public const string _BankTax = "BankTax";
		public const string _Waste = "Waste";
		public const string _UserAVGOnlineTime = "UserAVGOnlineTime";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private int m_userTotal;
		private int m_payUserTotal;
		private int m_activeUserTotal;
		private int m_lossUserTotal;
		private int m_lossPayUserTotal;
		private int m_payTotalAmount;
		private int m_payAmountForCurrency;
		private long m_goldTotal;
		private long m_currencyTotal;
		private long m_gameTax;
		private long m_gameTaxTotal;
		private long m_bankTax;
		private long m_waste;
		private int m_userAVGOnlineTime;
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
		public int UserTotal
		{
			get
			{
				return this.m_userTotal;
			}
			set
			{
				this.m_userTotal = value;
			}
		}
		public int PayUserTotal
		{
			get
			{
				return this.m_payUserTotal;
			}
			set
			{
				this.m_payUserTotal = value;
			}
		}
		public int ActiveUserTotal
		{
			get
			{
				return this.m_activeUserTotal;
			}
			set
			{
				this.m_activeUserTotal = value;
			}
		}
		public int LossUserTotal
		{
			get
			{
				return this.m_lossUserTotal;
			}
			set
			{
				this.m_lossUserTotal = value;
			}
		}
		public int LossPayUserTotal
		{
			get
			{
				return this.m_lossPayUserTotal;
			}
			set
			{
				this.m_lossPayUserTotal = value;
			}
		}
		public int PayTotalAmount
		{
			get
			{
				return this.m_payTotalAmount;
			}
			set
			{
				this.m_payTotalAmount = value;
			}
		}
		public int PayAmountForCurrency
		{
			get
			{
				return this.m_payAmountForCurrency;
			}
			set
			{
				this.m_payAmountForCurrency = value;
			}
		}
		public long GoldTotal
		{
			get
			{
				return this.m_goldTotal;
			}
			set
			{
				this.m_goldTotal = value;
			}
		}
		public long CurrencyTotal
		{
			get
			{
				return this.m_currencyTotal;
			}
			set
			{
				this.m_currencyTotal = value;
			}
		}
		public long GameTax
		{
			get
			{
				return this.m_gameTax;
			}
			set
			{
				this.m_gameTax = value;
			}
		}
		public long GameTaxTotal
		{
			get
			{
				return this.m_gameTaxTotal;
			}
			set
			{
				this.m_gameTaxTotal = value;
			}
		}
		public long BankTax
		{
			get
			{
				return this.m_bankTax;
			}
			set
			{
				this.m_bankTax = value;
			}
		}
		public long Waste
		{
			get
			{
				return this.m_waste;
			}
			set
			{
				this.m_waste = value;
			}
		}
		public int UserAVGOnlineTime
		{
			get
			{
				return this.m_userAVGOnlineTime;
			}
			set
			{
				this.m_userAVGOnlineTime = value;
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
		public RecordEveryDayData()
		{
			this.m_dateID = 0;
			this.m_userTotal = 0;
			this.m_payUserTotal = 0;
			this.m_activeUserTotal = 0;
			this.m_lossUserTotal = 0;
			this.m_lossPayUserTotal = 0;
			this.m_payTotalAmount = 0;
			this.m_payAmountForCurrency = 0;
			this.m_goldTotal = 0L;
			this.m_currencyTotal = 0L;
			this.m_gameTax = 0L;
			this.m_gameTaxTotal = 0L;
			this.m_bankTax = 0L;
			this.m_waste = 0L;
			this.m_userAVGOnlineTime = 0;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
