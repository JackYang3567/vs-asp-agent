using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_RolePermission
	{
		public const string Tablename = "Base_RolePermission";
		public const string _RoleID = "RoleID";
		public const string _ModuleID = "ModuleID";
		public const string _ManagerPermission = "ManagerPermission";
		public const string _OperationPermission = "OperationPermission";
		public const string _StateFlag = "StateFlag";
		private int m_roleID;
		private int m_moduleID;
		private long m_managerPermission;
		private long m_operationPermission;
		private int m_stateFlag;
		public int RoleID
		{
			get
			{
				return this.m_roleID;
			}
			set
			{
				this.m_roleID = value;
			}
		}
		public int ModuleID
		{
			get
			{
				return this.m_moduleID;
			}
			set
			{
				this.m_moduleID = value;
			}
		}
		public long ManagerPermission
		{
			get
			{
				return this.m_managerPermission;
			}
			set
			{
				this.m_managerPermission = value;
			}
		}
		public long OperationPermission
		{
			get
			{
				return this.m_operationPermission;
			}
			set
			{
				this.m_operationPermission = value;
			}
		}
		public int StateFlag
		{
			get
			{
				return this.m_stateFlag;
			}
			set
			{
				this.m_stateFlag = value;
			}
		}
		public Base_RolePermission()
		{
			this.m_roleID = 0;
			this.m_moduleID = 0;
			this.m_managerPermission = 0L;
			this.m_operationPermission = 0L;
			this.m_stateFlag = 0;
		}
	}
}
