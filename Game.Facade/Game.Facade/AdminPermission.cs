using Game.Entity.PlatformManager;
using System;
using System.Collections.Generic;
namespace Game.Facade
{
	public class AdminPermission
	{
		private Base_Users _user;
		private int _moduleID;
		private System.Collections.Generic.Dictionary<string, long> _userPriv;
		public Base_Users User
		{
			get
			{
				return this._user;
			}
			set
			{
				this._user = value;
			}
		}
		public int ModuleID
		{
			get
			{
				return this._moduleID;
			}
			set
			{
				this._moduleID = value;
			}
		}
		public System.Collections.Generic.Dictionary<string, long> UserPermission
		{
			get
			{
				return this._userPriv;
			}
			set
			{
				this._userPriv = value;
			}
		}
		public AdminPermission(Base_Users user, int moduleID)
		{
			this.User = user;
			this.ModuleID = moduleID;
			this.UserPermission = ((user != null) ? new PlatformManagerFacade().GetPermissionByUserID(user.UserID) : null);
		}
		public bool GetPermission(long authValue)
		{
			bool result = true;
			if (this.User == null)
			{
				return false;
			}
			if (this.User.RoleID == 1 || this.User.UserID == 1)
			{
				return result;
			}
			long num = 0L;
			if (this.UserPermission.TryGetValue(this.ModuleID.ToString().Trim(), out num))
			{
				if ((num & authValue) > 0L)
				{
					return result;
				}
				result = false;
			}
			else
			{
				result = false;
			}
			return result;
		}
		public bool GetUserPagePermission()
		{
			bool result = true;
			if (this.User == null)
			{
				return false;
			}
			if (this.User.RoleID == 1 || this.User.UserID == 1)
			{
				return result;
			}
			long num = 0L;
			return this.UserPermission.TryGetValue(this.ModuleID.ToString().Trim(), out num);
		}
	}
}
