using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_UserRole
	{
		public const string Tablename = "Base_UserRole";
		public const string _UserID = "UserID";
		public const string _RoleID = "RoleID";
		private int m_userID;
		private int m_roleID;
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
		public Base_UserRole()
		{
			this.m_userID = 0;
			this.m_roleID = 0;
		}
	}
}
