using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class GamePropertySub
	{
		public const string Tablename = "GamePropertySub";
		public const string _ID = "ID";
		public const string _OwnerID = "OwnerID";
		public const string _Count = "Count";
		public const string _SortID = "SortID";
		private int m_iD;
		private int m_ownerID;
		private int m_count;
		private int m_sortID;
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
		public int OwnerID
		{
			get
			{
				return this.m_ownerID;
			}
			set
			{
				this.m_ownerID = value;
			}
		}
		public int Count
		{
			get
			{
				return this.m_count;
			}
			set
			{
				this.m_count = value;
			}
		}
		public int SortID
		{
			get
			{
				return this.m_sortID;
			}
			set
			{
				this.m_sortID = value;
			}
		}
		public GamePropertySub()
		{
			this.m_iD = 0;
			this.m_ownerID = 0;
			this.m_count = 0;
			this.m_sortID = 0;
		}
	}
}
