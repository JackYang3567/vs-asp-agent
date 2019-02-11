using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class RecordCurrencyChange
	{
		public const string Tablename = "RecordCurrencyChange";
		public const string _RecordID = "RecordID";
		public const string _UserID = "UserID";
		public const string _ChangeCurrency = "ChangeCurrency";
		public const string _ChangeType = "ChangeType";
		public const string _BeforeCurrency = "BeforeCurrency";
		public const string _AfterCurrency = "AfterCurrency";
		public const string _ClinetIP = "ClinetIP";
		public const string _InputDate = "InputDate";
		public const string _Remark = "Remark";
		private int m_recordID;
		private int m_userID;
		private decimal m_changeCurrency;
		private byte m_changeType;
		private decimal m_beforeCurrency;
		private decimal m_afterCurrency;
		private string m_clinetIP;
		private System.DateTime m_inputDate;
		private string m_remark;
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
		public decimal ChangeCurrency
		{
			get
			{
				return this.m_changeCurrency;
			}
			set
			{
				this.m_changeCurrency = value;
			}
		}
		public byte ChangeType
		{
			get
			{
				return this.m_changeType;
			}
			set
			{
				this.m_changeType = value;
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
		public decimal AfterCurrency
		{
			get
			{
				return this.m_afterCurrency;
			}
			set
			{
				this.m_afterCurrency = value;
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
		public string Remark
		{
			get
			{
				return this.m_remark;
			}
			set
			{
				this.m_remark = value;
			}
		}
		public RecordCurrencyChange()
		{
			this.m_recordID = 0;
			this.m_userID = 0;
			this.m_changeCurrency = 0m;
			this.m_changeType = 0;
			this.m_beforeCurrency = 0m;
			this.m_afterCurrency = 0m;
			this.m_clinetIP = "";
			this.m_inputDate = System.DateTime.Now;
			this.m_remark = "";
		}
	}
}
