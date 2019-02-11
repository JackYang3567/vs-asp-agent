using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class MemberType
	{
		public const string Tablename = "MemberType";
		public const string _MemberOrder = "MemberOrder";
		public const string _MemberName = "MemberName";
		public const string _MemberPrice = "MemberPrice";
		public const string _PresentScore = "PresentScore";
		public const string _UserRight = "UserRight";
		private byte m_memberOrder;
		private string m_memberName;
		private decimal m_memberPrice;
		private int m_presentScore;
		private int m_userRight;
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
		public string MemberName
		{
			get
			{
				return this.m_memberName;
			}
			set
			{
				this.m_memberName = value;
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
		public MemberType()
		{
			this.m_memberOrder = 0;
			this.m_memberName = "";
			this.m_memberPrice = 0m;
			this.m_presentScore = 0;
			this.m_userRight = 0;
		}
	}
}
