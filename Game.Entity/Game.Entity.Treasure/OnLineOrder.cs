using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class OnLineOrder
	{
		public const string Tablename = "OnLineOrder";
		public const string _OnLineID = "OnLineID";
		public const string _OperUserID = "OperUserID";
		public const string _ShareID = "ShareID";
		public const string _UserID = "UserID";
		public const string _GameID = "GameID";
		public const string _Accounts = "Accounts";
		public const string _OrderID = "OrderID";
		public const string _CardTypeID = "CardTypeID";
		public const string _CardPrice = "CardPrice";
		public const string _CardGold = "CardGold";
		public const string _CardTotal = "CardTotal";
		public const string _OrderAmount = "OrderAmount";
		public const string _DiscountScale = "DiscountScale";
		public const string _PayAmount = "PayAmount";
		public const string _OrderStatus = "OrderStatus";
		public const string _IPAddress = "IPAddress";
		public const string _ApplyDate = "ApplyDate";
		private int m_onLineID;
		private int m_operUserID;
		private int m_shareID;
		private int m_userID;
		private int m_gameID;
		private string m_accounts;
		private string m_orderID;
		private int m_cardTypeID;
		private decimal m_cardPrice;
		private long m_cardGold;
		private int m_cardTotal;
		private decimal m_orderAmount;
		private decimal m_discountScale;
		private decimal m_payAmount;
		private byte m_orderStatus;
		private string m_iPAddress;
		private System.DateTime m_applyDate;
		public int OnLineID
		{
			get
			{
				return this.m_onLineID;
			}
			set
			{
				this.m_onLineID = value;
			}
		}
		public int OperUserID
		{
			get
			{
				return this.m_operUserID;
			}
			set
			{
				this.m_operUserID = value;
			}
		}
		public int ShareID
		{
			get
			{
				return this.m_shareID;
			}
			set
			{
				this.m_shareID = value;
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
		public int GameID
		{
			get
			{
				return this.m_gameID;
			}
			set
			{
				this.m_gameID = value;
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
		public string OrderID
		{
			get
			{
				return this.m_orderID;
			}
			set
			{
				this.m_orderID = value;
			}
		}
		public int CardTypeID
		{
			get
			{
				return this.m_cardTypeID;
			}
			set
			{
				this.m_cardTypeID = value;
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
		public long CardGold
		{
			get
			{
				return this.m_cardGold;
			}
			set
			{
				this.m_cardGold = value;
			}
		}
		public int CardTotal
		{
			get
			{
				return this.m_cardTotal;
			}
			set
			{
				this.m_cardTotal = value;
			}
		}
		public decimal OrderAmount
		{
			get
			{
				return this.m_orderAmount;
			}
			set
			{
				this.m_orderAmount = value;
			}
		}
		public decimal DiscountScale
		{
			get
			{
				return this.m_discountScale;
			}
			set
			{
				this.m_discountScale = value;
			}
		}
		public decimal PayAmount
		{
			get
			{
				return this.m_payAmount;
			}
			set
			{
				this.m_payAmount = value;
			}
		}
		public byte OrderStatus
		{
			get
			{
				return this.m_orderStatus;
			}
			set
			{
				this.m_orderStatus = value;
			}
		}
		public string IPAddress
		{
			get
			{
				return this.m_iPAddress;
			}
			set
			{
				this.m_iPAddress = value;
			}
		}
		public System.DateTime ApplyDate
		{
			get
			{
				return this.m_applyDate;
			}
			set
			{
				this.m_applyDate = value;
			}
		}
		public OnLineOrder()
		{
			this.m_onLineID = 0;
			this.m_operUserID = 0;
			this.m_shareID = 0;
			this.m_userID = 0;
			this.m_gameID = 0;
			this.m_accounts = "";
			this.m_orderID = "";
			this.m_cardTypeID = 0;
			this.m_cardPrice = 0m;
			this.m_cardGold = 0L;
			this.m_cardTotal = 0;
			this.m_orderAmount = 0m;
			this.m_discountScale = 0m;
			this.m_payAmount = 0m;
			this.m_orderStatus = 0;
			this.m_iPAddress = "";
			this.m_applyDate = System.DateTime.Now;
		}
	}
}
