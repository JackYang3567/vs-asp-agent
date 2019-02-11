using System;
namespace Game.Entity.GameScore
{
	[System.Serializable]
	public class RecordDrawInfo
	{
		public const string Tablename = "RecordDrawInfo";
		public const string _DrawID = "DrawID";
		public const string _Waste = "Waste";
		public const string _Revenue = "Revenue";
		public const string _Present = "Present";
		public const string _UserMedal = "UserMedal";
		public const string _UserCount = "UserCount";
		public const string _StartTime = "StartTime";
		public const string _ConcludeTime = "ConcludeTime";
		public const string _InsertTime = "InsertTime";
		public const string _DrawCourse = "DrawCourse";
		private int m_drawID;
		private long m_waste;
		private long m_revenue;
		private long m_present;
		private int m_userMedal;
		private int m_userCount;
		private System.DateTime m_startTime;
		private System.DateTime m_concludeTime;
		private System.DateTime m_insertTime;
		private byte[] m_drawCourse;
		public int DrawID
		{
			get
			{
				return this.m_drawID;
			}
			set
			{
				this.m_drawID = value;
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
		public long Present
		{
			get
			{
				return this.m_present;
			}
			set
			{
				this.m_present = value;
			}
		}
		public int UserMedal
		{
			get
			{
				return this.m_userMedal;
			}
			set
			{
				this.m_userMedal = value;
			}
		}
		public int UserCount
		{
			get
			{
				return this.m_userCount;
			}
			set
			{
				this.m_userCount = value;
			}
		}
		public System.DateTime StartTime
		{
			get
			{
				return this.m_startTime;
			}
			set
			{
				this.m_startTime = value;
			}
		}
		public System.DateTime ConcludeTime
		{
			get
			{
				return this.m_concludeTime;
			}
			set
			{
				this.m_concludeTime = value;
			}
		}
		public System.DateTime InsertTime
		{
			get
			{
				return this.m_insertTime;
			}
			set
			{
				this.m_insertTime = value;
			}
		}
		public byte[] DrawCourse
		{
			get
			{
				return this.m_drawCourse;
			}
			set
			{
				this.m_drawCourse = value;
			}
		}
		public RecordDrawInfo()
		{
			this.m_drawID = 0;
			this.m_waste = 0L;
			this.m_revenue = 0L;
			this.m_present = 0L;
			this.m_userMedal = 0;
			this.m_userCount = 0;
			this.m_startTime = System.DateTime.Now;
			this.m_concludeTime = System.DateTime.Now;
			this.m_insertTime = System.DateTime.Now;
			this.m_drawCourse = null;
		}
	}
}
