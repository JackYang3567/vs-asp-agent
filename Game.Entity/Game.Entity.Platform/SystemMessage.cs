using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class SystemMessage
	{
		public const string Tablename = "SystemMessage";
		public const string _ID = "ID";
		public const string _MessageType = "MessageType";
		public const string _ServerRange = "ServerRange";
		public const string _MessageString = "MessageString";
		public const string _StartTime = "StartTime";
		public const string _ConcludeTime = "ConcludeTime";
		public const string _TimeRate = "TimeRate";
		public const string _Nullity = "Nullity";
		public const string _CreateDate = "CreateDate";
		public const string _CreateMasterID = "CreateMasterID";
		public const string _UpdateDate = "UpdateDate";
		public const string _UpdateMasterID = "UpdateMasterID";
		public const string _UpdateCount = "UpdateCount";
		public const string _CollectNote = "CollectNote";
		private int m_iD;
		private int m_messageType;
		private string m_serverRange;
		private string m_messageString;
		private System.DateTime m_startTime;
		private System.DateTime m_concludeTime;
		private int m_timeRate;
		private byte m_nullity;
		private System.DateTime m_createDate;
		private int m_createMasterID;
		private System.DateTime m_updateDate;
		private int m_updateMasterID;
		private int m_updateCount;
		private string m_collectNote;
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
		public int MessageType
		{
			get
			{
				return this.m_messageType;
			}
			set
			{
				this.m_messageType = value;
			}
		}
		public string ServerRange
		{
			get
			{
				return this.m_serverRange;
			}
			set
			{
				this.m_serverRange = value;
			}
		}
		public string MessageString
		{
			get
			{
				return this.m_messageString;
			}
			set
			{
				this.m_messageString = value;
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
		public int TimeRate
		{
			get
			{
				return this.m_timeRate;
			}
			set
			{
				this.m_timeRate = value;
			}
		}
		public byte Nullity
		{
			get
			{
				return this.m_nullity;
			}
			set
			{
				this.m_nullity = value;
			}
		}
		public System.DateTime CreateDate
		{
			get
			{
				return this.m_createDate;
			}
			set
			{
				this.m_createDate = value;
			}
		}
		public int CreateMasterID
		{
			get
			{
				return this.m_createMasterID;
			}
			set
			{
				this.m_createMasterID = value;
			}
		}
		public System.DateTime UpdateDate
		{
			get
			{
				return this.m_updateDate;
			}
			set
			{
				this.m_updateDate = value;
			}
		}
		public int UpdateMasterID
		{
			get
			{
				return this.m_updateMasterID;
			}
			set
			{
				this.m_updateMasterID = value;
			}
		}
		public int UpdateCount
		{
			get
			{
				return this.m_updateCount;
			}
			set
			{
				this.m_updateCount = value;
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
		public SystemMessage()
		{
			this.m_iD = 0;
			this.m_messageType = 0;
			this.m_serverRange = "";
			this.m_messageString = "";
			this.m_startTime = System.DateTime.Now;
			this.m_concludeTime = System.DateTime.Now;
			this.m_timeRate = 0;
			this.m_nullity = 0;
			this.m_createDate = System.DateTime.Now;
			this.m_createMasterID = 0;
			this.m_updateDate = System.DateTime.Now;
			this.m_updateMasterID = 0;
			this.m_updateCount = 0;
			this.m_collectNote = "";
		}
	}
}
