using System;
namespace Game.Entity.Record
{
	[System.Serializable]
	public class RecordTask
	{
		public const string Tablename = "RecordTask";
		public const string _RecordID = "RecordID";
		public const string _DateID = "DateID";
		public const string _UserID = "UserID";
		public const string _TaskID = "TaskID";
		public const string _AwardGold = "AwardGold";
		public const string _AwardMedal = "AwardMedal";
		public const string _InputDate = "InputDate";
		private int m_recordID;
		private int m_dateID;
		private int m_userID;
		private int m_taskID;
		private int m_awardGold;
		private int m_awardMedal;
		private System.DateTime m_inputDate;
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
		public int TaskID
		{
			get
			{
				return this.m_taskID;
			}
			set
			{
				this.m_taskID = value;
			}
		}
		public int AwardGold
		{
			get
			{
				return this.m_awardGold;
			}
			set
			{
				this.m_awardGold = value;
			}
		}
		public int AwardMedal
		{
			get
			{
				return this.m_awardMedal;
			}
			set
			{
				this.m_awardMedal = value;
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
		public RecordTask()
		{
			this.m_recordID = 0;
			this.m_dateID = 0;
			this.m_userID = 0;
			this.m_taskID = 0;
			this.m_awardGold = 0;
			this.m_awardMedal = 0;
			this.m_inputDate = System.DateTime.Now;
		}
	}
}
