using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class AccountsAgentGame
	{
		public const string Tablename = "AccountsAgentGame";
		public const string _ID = "ID";
		public const string _AgentID = "AgentID";
		public const string _KindID = "KindID";
		public const string _DeviceID = "DeviceID";
		public const string _SortID = "SortID";
		public const string _CollectDate = "CollectDate";
		private int m_id;
		private int m_agentID;
		private int m_kindID;
		private int m_deviceID;
		private int m_sortID;
		private System.DateTime m_collectDate;
		public int ID
		{
			get
			{
				return this.m_id;
			}
			set
			{
				this.m_id = value;
			}
		}
		public int AgentID
		{
			get
			{
				return this.m_agentID;
			}
			set
			{
				this.m_agentID = value;
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
		public int DeviceID
		{
			get
			{
				return this.m_deviceID;
			}
			set
			{
				this.m_deviceID = value;
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
		public AccountsAgentGame()
		{
			this.m_id = 0;
			this.m_agentID = 0;
			this.m_kindID = 0;
			this.m_deviceID = 0;
			this.m_sortID = 0;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
