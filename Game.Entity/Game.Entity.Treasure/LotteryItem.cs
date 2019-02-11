using System;
namespace Game.Entity.Treasure
{
	[System.Serializable]
	public class LotteryItem
	{
		public const string Tablename = "LotteryItem";
		public const string _ItemIndex = "ItemIndex";
		public const string _ItemType = "ItemType";
		public const string _ItemQuota = "ItemQuota";
		public const string _ItemRate = "ItemRate";
		private int m_itemIndex;
		private int m_itemType;
		private int m_itemQuota;
		private int m_itemRate;
		public int ItemIndex
		{
			get
			{
				return this.m_itemIndex;
			}
			set
			{
				this.m_itemIndex = value;
			}
		}
		public int ItemType
		{
			get
			{
				return this.m_itemType;
			}
			set
			{
				this.m_itemType = value;
			}
		}
		public int ItemQuota
		{
			get
			{
				return this.m_itemQuota;
			}
			set
			{
				this.m_itemQuota = value;
			}
		}
		public int ItemRate
		{
			get
			{
				return this.m_itemRate;
			}
			set
			{
				this.m_itemRate = value;
			}
		}
		public LotteryItem()
		{
			this.m_itemIndex = 0;
			this.m_itemType = 0;
			this.m_itemQuota = 0;
			this.m_itemRate = 0;
		}
	}
}
