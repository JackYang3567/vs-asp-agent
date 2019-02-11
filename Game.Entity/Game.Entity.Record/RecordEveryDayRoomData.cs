using System;
namespace Game.Entity.Record
{
	[System.Serializable]
	public class RecordEveryDayRoomData
	{
		public const string Tablename = "RecordEveryDayRoomData";
		public const string _DateID = "DateID";
		public const string _KindID = "KindID";
		public const string _ServerID = "ServerID";
		public const string _Waste = "Waste";
		public const string _Revenue = "Revenue";
		public const string _Medal = "Medal";
		public const string _CollectDate = "CollectDate";
		private int m_dateID;
		private int m_kindID;
		private int m_serverID;
		private long m_waste;
		private long m_revenue;
		private int m_medal;
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
		public int KindID
		{
			get
			{
				return this.m_kindID;
			}
			set
			{
				this.m_kindID = value;
			}
		}
		public int ServerID
		{
			get
			{
				return this.m_serverID;
			}
			set
			{
				this.m_serverID = value;
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
		public long Revenue
		{
			get
			{
				return this.m_revenue;
			}
			set
			{
				this.m_revenue = value;
			}
		}
		public int Medal
		{
			get
			{
				return this.m_medal;
			}
			set
			{
				this.m_medal = value;
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
		public RecordEveryDayRoomData()
		{
			this.m_dateID = 0;
			this.m_kindID = 0;
			this.m_serverID = 0;
			this.m_waste = 0L;
			this.m_revenue = 0L;
			this.m_medal = 0;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
