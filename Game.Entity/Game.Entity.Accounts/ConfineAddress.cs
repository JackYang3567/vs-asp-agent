using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class ConfineAddress
	{
		public const string Tablename = "ConfineAddress";
		public const string _AddrString = "AddrString";
		public const string _EnjoinLogon = "EnjoinLogon";
		public const string _EnjoinRegister = "EnjoinRegister";
		public const string _EnjoinOverDate = "EnjoinOverDate";
		public const string _CollectDate = "CollectDate";
		public const string _CollectNote = "CollectNote";
		private string m_addrString;
		private bool m_enjoinLogon;
		private bool m_enjoinRegister;
		private System.DateTime? m_enjoinOverDate;
		private System.DateTime m_collectDate;
		private string m_collectNote;
		public string AddrString
		{
			get
			{
				return this.m_addrString;
			}
			set
			{
				this.m_addrString = value;
			}
		}
		public bool EnjoinLogon
		{
			get
			{
				return this.m_enjoinLogon;
			}
			set
			{
				this.m_enjoinLogon = value;
			}
		}
		public bool EnjoinRegister
		{
			get
			{
				return this.m_enjoinRegister;
			}
			set
			{
				this.m_enjoinRegister = value;
			}
		}
		public System.DateTime? EnjoinOverDate
		{
			get
			{
				return this.m_enjoinOverDate;
			}
			set
			{
				this.m_enjoinOverDate = value;
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
		public string CollectNote
		{
			get
			{
				return this.m_collectNote;
			}
			set
			{
				this.m_collectNote = value;
			}
		}
		public ConfineAddress()
		{
			this.m_addrString = "";
			this.m_enjoinLogon = false;
			this.m_enjoinRegister = false;
			this.m_enjoinOverDate = null;
			this.m_collectDate = System.DateTime.Now;
			this.m_collectNote = "";
		}
	}
}
