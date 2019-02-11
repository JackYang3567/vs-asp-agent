using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class MemberCard
	{
		public const string Tablename = "MemberCard";
		public const string _CardID = "CardID";
		public const string _CardName = "CardName";
		public const string _CardPrice = "CardPrice";
		public const string _PresentScore = "PresentScore";
		public const string _MemberOrder = "MemberOrder";
		public const string _UserRight = "UserRight";
		public const string _Describe = "Describe";
		private int m_cardID;
		private string m_cardName;
		private int m_cardPrice;
		private int m_presentScore;
		private byte m_memberOrder;
		private int m_userRight;
		private string m_describe;
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
		public int CardPrice
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
		public int PresentScore
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
		public byte MemberOrder
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
		public int UserRight
		{
			get
			{
				return this.m_userRight;
			}
			set
			{
				this.m_userRight = value;
			}
		}
		public string Describe
		{
			get
			{
				return this.m_describe;
			}
			set
			{
				this.m_describe = value;
			}
		}
		public MemberCard()
		{
			this.m_cardID = 0;
			this.m_cardName = "";
			this.m_cardPrice = 0;
			this.m_presentScore = 0;
			this.m_memberOrder = 0;
			this.m_userRight = 0;
			this.m_describe = "";
		}
	}
}
