using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_Roles
	{
		public const string Tablename = "Base_Roles";
		public const string _RoleID = "RoleID";
		public const string _RoleName = "RoleName";
		public const string _Description = "Description";
		private int m_roleID;
		private string m_roleName;
		private string m_description;
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
		public string RoleName
		{
			get
			{
				return this.m_roleName;
			}
			set
			{
				this.m_roleName = value;
			}
		}
		public string Description
		{
			get
			{
				return this.m_description;
			}
			set
			{
				this.m_description = value;
			}
		}
		public Base_Roles()
		{
			this.m_roleID = 0;
			this.m_roleName = "";
			this.m_description = "";
		}
	}
}
