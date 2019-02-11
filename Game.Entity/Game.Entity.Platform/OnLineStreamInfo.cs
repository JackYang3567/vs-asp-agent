using System;
namespace Game.Entity.Platform
{
	[System.Serializable]
	public class OnLineStreamInfo
	{
		public const string Tablename = "OnLineStreamInfo";
		public const string _ID = "ID";
		public const string _MachineID = "MachineID";
		public const string _MachineServer = "MachineServer";
		public const string _InsertDateTime = "InsertDateTime";
		public const string _OnLineCountSum = "OnLineCountSum";
		public const string _OnLineCountKind = "OnLineCountKind";
		private int m_iD;
		private string m_machineID;
		private string m_machineServer;
		private System.DateTime m_insertDateTime;
		private int m_onLineCountSum;
		private string m_onLineCountKind;
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
		public string MachineID
		{
			get
			{
				return this.m_machineID;
			}
			set
			{
				this.m_machineID = value;
			}
		}
		public string MachineServer
		{
			get
			{
				return this.m_machineServer;
			}
			set
			{
				this.m_machineServer = value;
			}
		}
		public System.DateTime InsertDateTime
		{
			get
			{
				return this.m_insertDateTime;
			}
			set
			{
				this.m_insertDateTime = value;
			}
		}
		public int OnLineCountSum
		{
			get
			{
				return this.m_onLineCountSum;
			}
			set
			{
				this.m_onLineCountSum = value;
			}
		}
		public string OnLineCountKind
		{
			get
			{
				return this.m_onLineCountKind;
			}
			set
			{
				this.m_onLineCountKind = value;
			}
		}
		public OnLineStreamInfo()
		{
			this.m_iD = 0;
			this.m_machineID = "";
			this.m_machineServer = "";
			this.m_insertDateTime = System.DateTime.Now;
			this.m_onLineCountSum = 0;
			this.m_onLineCountKind = "";
		}
	}
}
