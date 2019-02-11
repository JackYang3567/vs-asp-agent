using System;
namespace Game.Entity.GameScore
{
	[System.Serializable]
	public class RecordDrawScore
	{
		public const string Tablename = "RecordDrawScore";
		public const string _DrawID = "DrawID";
		public const string _UserID = "UserID";
		public const string _Score = "Score";
		public const string _Grade = "Grade";
		public const string _Revenue = "Revenue";
		public const string _Present = "Present";
		public const string _UserMedal = "UserMedal";
		public const string _InsertTime = "InsertTime";
		private int m_drawID;
		private int m_userID;
		private long m_score;
		private long m_grade;
		private long m_revenue;
		private long m_present;
		private int m_userMedal;
		private System.DateTime m_insertTime;
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
		public long Score
		{
			get
			{
				return this.m_score;
			}
			set
			{
				this.m_score = value;
			}
		}
		public long Grade
		{
			get
			{
				return this.m_grade;
			}
			set
			{
				this.m_grade = value;
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
		public RecordDrawScore()
		{
			this.m_drawID = 0;
			this.m_userID = 0;
			this.m_score = 0L;
			this.m_grade = 0L;
			this.m_revenue = 0L;
			this.m_present = 0L;
			this.m_userMedal = 0;
			this.m_insertTime = System.DateTime.Now;
		}
	}
}
