using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_ModulePermission
	{
		public const string Tablename = "Base_ModulePermission";
		public const string _ModuleID = "ModuleID";
		public const string _PermissionTitle = "PermissionTitle";
		public const string _PermissionValue = "PermissionValue";
		public const string _Nullity = "Nullity";
		public const string _StateFlag = "StateFlag";
		public const string _ParentID = "ParentID";
		private int m_moduleID;
		private string m_permissionTitle;
		private long m_permissionValue;
		private byte m_nullity;
		private int m_stateFlag;
		private int m_parentID;
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
		public string PermissionTitle
		{
			get
			{
				return this.m_permissionTitle;
			}
			set
			{
				this.m_permissionTitle = value;
			}
		}
		public long PermissionValue
		{
			get
			{
				return this.m_permissionValue;
			}
			set
			{
				this.m_permissionValue = value;
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
		public int ParentID
		{
			get
			{
				return this.m_parentID;
			}
			set
			{
				this.m_parentID = value;
			}
		}
		public Base_ModulePermission()
		{
			this.m_moduleID = 0;
			this.m_permissionTitle = "";
			this.m_permissionValue = 0L;
			this.m_nullity = 0;
			this.m_stateFlag = 0;
			this.m_parentID = 0;
		}
	}
}
