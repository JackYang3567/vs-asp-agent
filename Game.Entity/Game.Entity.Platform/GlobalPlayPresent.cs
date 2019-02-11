using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class GlobalPlayPresent
	{
		public const string Tablename = "GlobalPlayPresent";
		public const string _ServerID = "ServerID";
		public const string _PresentMember = "PresentMember";
		public const string _MaxDatePresent = "MaxDatePresent";
		public const string _MaxPresent = "MaxPresent";
		public const string _CellPlayPresnet = "CellPlayPresnet";
		public const string _CellPlayTime = "CellPlayTime";
		public const string _StartPlayTime = "StartPlayTime";
		public const string _CellOnlinePresent = "CellOnlinePresent";
		public const string _CellOnlineTime = "CellOnlineTime";
		public const string _StartOnlineTime = "StartOnlineTime";
		public const string _IsPlayPresent = "IsPlayPresent";
		public const string _IsOnlinePresent = "IsOnlinePresent";
		public const string _CollectDate = "CollectDate";
		private int m_serverID;
		private string m_presentMember;
		private int m_maxDatePresent;
		private int m_maxPresent;
		private int m_cellPlayPresnet;
		private int m_cellPlayTime;
		private int m_startPlayTime;
		private int m_cellOnlinePresent;
		private int m_cellOnlineTime;
		private int m_startOnlineTime;
		private byte m_isPlayPresent;
		private byte m_isOnlinePresent;
		private System.DateTime m_collectDate;
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
		public string PresentMember
		{
			get
			{
				return this.m_presentMember;
			}
			set
			{
				this.m_presentMember = value;
			}
		}
		public int MaxDatePresent
		{
			get
			{
				return this.m_maxDatePresent;
			}
			set
			{
				this.m_maxDatePresent = value;
			}
		}
		public int MaxPresent
		{
			get
			{
				return this.m_maxPresent;
			}
			set
			{
				this.m_maxPresent = value;
			}
		}
		public int CellPlayPresnet
		{
			get
			{
				return this.m_cellPlayPresnet;
			}
			set
			{
				this.m_cellPlayPresnet = value;
			}
		}
		public int CellPlayTime
		{
			get
			{
				return this.m_cellPlayTime;
			}
			set
			{
				this.m_cellPlayTime = value;
			}
		}
		public int StartPlayTime
		{
			get
			{
				return this.m_startPlayTime;
			}
			set
			{
				this.m_startPlayTime = value;
			}
		}
		public int CellOnlinePresent
		{
			get
			{
				return this.m_cellOnlinePresent;
			}
			set
			{
				this.m_cellOnlinePresent = value;
			}
		}
		public int CellOnlineTime
		{
			get
			{
				return this.m_cellOnlineTime;
			}
			set
			{
				this.m_cellOnlineTime = value;
			}
		}
		public int StartOnlineTime
		{
			get
			{
				return this.m_startOnlineTime;
			}
			set
			{
				this.m_startOnlineTime = value;
			}
		}
		public byte IsPlayPresent
		{
			get
			{
				return this.m_isPlayPresent;
			}
			set
			{
				this.m_isPlayPresent = value;
			}
		}
		public byte IsOnlinePresent
		{
			get
			{
				return this.m_isOnlinePresent;
			}
			set
			{
				this.m_isOnlinePresent = value;
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
		public GlobalPlayPresent()
		{
			this.m_serverID = 0;
			this.m_presentMember = "";
			this.m_maxDatePresent = 0;
			this.m_maxPresent = 0;
			this.m_cellPlayPresnet = 0;
			this.m_cellPlayTime = 0;
			this.m_startPlayTime = 0;
			this.m_cellOnlinePresent = 0;
			this.m_cellOnlineTime = 0;
			this.m_startOnlineTime = 0;
			this.m_isPlayPresent = 0;
			this.m_isOnlinePresent = 0;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
