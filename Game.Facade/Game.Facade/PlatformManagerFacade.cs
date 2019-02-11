using Game.Data.Factory;
using Game.Entity.PlatformManager;
using Game.IData;
using Game.Kernel;
using Game.Utils;
using Game.Utils.Cache;
using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade
{
	public class PlatformManagerFacade
	{
		private IPlatformManagerDataProvider aidePlatformManagerData;
		public PlatformManagerFacade()
		{
			this.aidePlatformManagerData = ClassFactory.GetIPlatformManagerDataProvider();
		}
		public Message UserLogon(Base_Users user)
		{
			Message message = GameWebRules.CheckedUserLogon(user);
			if (!message.Success)
			{
				return message;
			}
			message = this.aidePlatformManagerData.UserLogon(user);
			if (message.Success)
			{
				Base_Users base_Users = message.EntityList[0] as Base_Users;
				WHCache.Default.Save<SessionCache>(AppConfig.UserCacheKey, base_Users, new int?(AppConfig.UserCacheTimeOut));
				WHCache.Default.Save<CookiesCache>(AppConfig.UserCacheKey, base_Users.UserID, new int?(AppConfig.UserCacheTimeOut));
			}
			return message;
		}
		public void SaveUserCache(Base_Users user)
		{
			WHCache.Default.Save<SessionCache>(AppConfig.UserCacheKey, user, new int?(AppConfig.UserCacheTimeOut));
		}
		public void UserLogout()
		{
			if (!(WHCache.Default.Get<SessionCache>(AppConfig.UserCacheKey) is Base_Users))
			{
				return;
			}
			WHCache.Default.Delete<SessionCache>(AppConfig.UserCacheKey);
			WHCache.Default.Delete<CookiesCache>(AppConfig.UserCacheKey);
		}
		public Base_Users GetUserInfoFromCache()
		{
			object obj = WHCache.Default.Get<SessionCache>(AppConfig.UserCacheKey);
			if (obj == null)
			{
				obj = WHCache.Default.Get<CookiesCache>(AppConfig.UserCacheKey);
				if (obj != null && Validate.IsNumeric(obj.ToString()))
				{
					Base_Users userByUserID = this.GetUserByUserID(System.Convert.ToInt32(obj));
					if (userByUserID != null)
					{
						return userByUserID;
					}
				}
				return null;
			}
			return obj as Base_Users;
		}
		public bool CheckedUserLogon()
		{
			Base_Users userInfoFromCache = this.GetUserInfoFromCache();
			return userInfoFromCache != null && userInfoFromCache.UserID > 0 && userInfoFromCache.RoleID > 0;
		}
		public Message Register(Base_Users user)
		{
			Message message = GameWebRules.CheckedUserToRegister(ref user);
			if (!message.Success)
			{
				return message;
			}
			message = this.ExistUserAccounts(user.Username);
			if (message.Success)
			{
				message.Success = false;
				return message;
			}
			this.aidePlatformManagerData.Register(user);
			return new Message(true);
		}
		public Message ModifyUserInfo(Base_Users user)
		{
			Message message = GameWebRules.CheckedUserToModify(ref user);
			if (!message.Success)
			{
				return message;
			}
			Base_Users userByUserID = this.GetUserByUserID(user.UserID);
			if (userByUserID.Username != user.Username)
			{
				message = this.ExistUserAccounts(user.Username);
				if (message.Success)
				{
					message.Success = false;
					return message;
				}
			}
			this.aidePlatformManagerData.ModifyUserInfo(user);
			return new Message(true);
		}
		public void BindIP(Base_Users user)
		{
			this.aidePlatformManagerData.BindIP(user);
		}
		public void ModifyUserNullity(string userIDList, bool nullity)
		{
			this.aidePlatformManagerData.ModifyUserNullity(userIDList, nullity);
		}
		public DataSet GetUserList()
		{
			return this.aidePlatformManagerData.GetUserList();
		}
		public PagerSet GetUserList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformManagerData.GetUserList(pageIndex, pageSize, condition, orderby);
		}
		public DataSet GetUserListByRoleID(int roleID)
		{
			return this.aidePlatformManagerData.GetUserListByRoleID(roleID);
		}
		public Base_Users GetUserByUserID(int userID)
		{
			return this.aidePlatformManagerData.GetUserByUserID(userID);
		}
		public Base_Users GetUserByAccounts(string accounts)
		{
			return this.aidePlatformManagerData.GetUserByAccounts(accounts);
		}
		public string GetAccountsByUserID(int userID)
		{
			Base_Users userByUserID = this.GetUserByUserID(userID);
			if (userByUserID != null)
			{
				return userByUserID.Username;
			}
			return "";
		}
		public void DeleteUser(string userIDList)
		{
			this.aidePlatformManagerData.DeleteUser(userIDList);
		}
		public Message ExistUserAccounts(string accounts)
		{
			Base_Users userByAccounts = this.aidePlatformManagerData.GetUserByAccounts(accounts);
			if (userByAccounts != null && userByAccounts.UserID > 0)
			{
				return new Message(true, ResMessage.Error_ExistsUser);
			}
			return new Message(false);
		}
		public Message ValidUserLogonPass(int userID, string logonPass)
		{
			Base_Users userByUserID = this.aidePlatformManagerData.GetUserByUserID(userID);
			if (userByUserID == null || userByUserID.UserID <= 0 || !userByUserID.Password.Equals(logonPass, System.StringComparison.InvariantCultureIgnoreCase))
			{
				return new Message(false, "帐号不存在或密码输入错误。");
			}
			return new Message(true);
		}
		public Message ModifyUserLogonPass(Base_Users userExt, string oldPasswd, string newPasswd)
		{
			Message message = GameWebRules.CheckUserPasswordForModify(ref oldPasswd, ref newPasswd);
			if (!message.Success)
			{
				return message;
			}
			message = this.ValidUserLogonPass(userExt.UserID, oldPasswd);
			if (!message.Success)
			{
				return message;
			}
			this.aidePlatformManagerData.ModifyUserLogonPass(userExt, Utility.MD5(newPasswd));
			return new Message(true);
		}
		public Message ModifyPowerUserLogonPass(Base_Users admin, Base_Users powerUser, string newPasswd)
		{
			if (admin.UserID != 1 || admin.RoleID != 1)
			{
				return new Message(false, "您没有修改用户密码的权限。");
			}
			Message message = GameWebRules.CheckedPassword(newPasswd);
			if (!message.Success)
			{
				return message;
			}
			newPasswd = TextEncrypt.EncryptPassword(newPasswd);
			this.aidePlatformManagerData.ModifyUserLogonPass(powerUser, newPasswd);
			return new Message(true);
		}
		public PagerSet GetRoleList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformManagerData.GetRoleList(pageIndex, pageSize, condition, orderby);
		}
		public Base_Roles GetRoleInfo(int roleID)
		{
			return this.aidePlatformManagerData.GetRoleInfo(roleID);
		}
		public string GetRolenameByRoleID(int roleID)
		{
			return this.aidePlatformManagerData.GetRolenameByRoleID(roleID);
		}
		public Message InsertRole(Base_Roles role)
		{
			this.aidePlatformManagerData.InsertRole(role);
			return new Message(true);
		}
		public Message UpdateRole(Base_Roles role)
		{
			this.aidePlatformManagerData.UpdateRole(role);
			return new Message(true);
		}
		public void DeleteRole(string sqlQuery)
		{
			this.aidePlatformManagerData.DeleteRole(sqlQuery);
		}
		public DataSet GetMenuByRoleID(int roleID)
		{
			return this.aidePlatformManagerData.GetMenuByRoleID(roleID);
		}
		public DataSet GetPermissionByModuleID(int moduleID, int RoleID)
		{
			return this.aidePlatformManagerData.GetPermissionByModuleID(moduleID, RoleID);
		}
		public DataSet GetMenuByUserID(int userID)
		{
			return this.aidePlatformManagerData.GetMenuByUserID(userID);
		}
		public System.Collections.Generic.Dictionary<string, long> GetPermissionByUserID(int userID)
		{
			System.Collections.Generic.Dictionary<string, long> dictionary = new System.Collections.Generic.Dictionary<string, long>();
			DataSet permissionByUserID = this.aidePlatformManagerData.GetPermissionByUserID(userID);
			if (permissionByUserID.Tables.Count != 0 && permissionByUserID.Tables[0].Rows.Count != 0)
			{
				for (int i = 0; i < permissionByUserID.Tables[0].Rows.Count; i++)
				{
					dictionary.Add(permissionByUserID.Tables[0].Rows[i]["ModuleID"].ToString().Trim(), (long)Utility.StrToInt(permissionByUserID.Tables[0].Rows[i]["OperationPermission"].ToString().Trim(), 0));
				}
			}
			return dictionary;
		}
		public DataSet GetModuleList()
		{
			return this.aidePlatformManagerData.GetModuleList();
		}
		public DataSet GetModuleParentList()
		{
			return this.aidePlatformManagerData.GetModuleParentList();
		}
		public DataSet GetModuleListByModuleID(int moduleID)
		{
			return this.aidePlatformManagerData.GetModuleListByModuleID(moduleID);
		}
		public DataSet GetModulePermissionList()
		{
			return this.aidePlatformManagerData.GetModulePermissionList();
		}
		public DataSet GetModulePermissionList(int moduleID)
		{
			return this.aidePlatformManagerData.GetModulePermissionList(moduleID);
		}
		public DataSet GetRolePermissionList(int roleID)
		{
			return this.aidePlatformManagerData.GetRolePermissionList(roleID);
		}
		public Message InsertRolePermission(Base_RolePermission rolePermission)
		{
			this.aidePlatformManagerData.InsertRolePermission(rolePermission);
			return new Message(true);
		}
		public void DeleteRolePermission(int roleID)
		{
			this.aidePlatformManagerData.DeleteRolePermission(roleID);
		}
		public PagerSet GetSystemSecurityList(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformManagerData.GetSystemSecurityList(pageIndex, pageSize, condition, orderby);
		}
		public SystemSecurity GetSystemSecurityById(int Id)
		{
			return this.aidePlatformManagerData.GetSystemSecurityById(Id);
		}
		public DataTable GetLogType()
		{
			string sql = "SELECT * FROM View_LogType";
			return this.aidePlatformManagerData.GetDataSetBySql(sql).Tables[0];
		}
		public QPAdminSiteInfo GetQPAdminSiteInfo(int siteID)
		{
			return this.aidePlatformManagerData.GetQPAdminSiteInfo(siteID);
		}
		public void UpdateQPAdminSiteInfo(QPAdminSiteInfo site)
		{
			this.aidePlatformManagerData.UpdateQPAdminSiteInfo(site);
		}
		public Message UserLogonApp(Base_Users user, string machineID)
		{
			return this.aidePlatformManagerData.UserLogonApp(user, machineID);
		}
		public void AddSystemSecurity(System.Collections.Generic.Dictionary<string, object> dic)
		{
			this.aidePlatformManagerData.AddSystemSecurity(dic);
		}
		public PagerSet GetOperatingLog(int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformManagerData.GetOperatingLog(pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			return this.aidePlatformManagerData.GetList(tableName, pageIndex, pageSize, condition, orderby);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby, string[] fields)
		{
			return this.aidePlatformManagerData.GetList(tableName, pageIndex, pageSize, condition, orderby, fields);
		}
		public int ExecuteSql(string sql)
		{
			return this.aidePlatformManagerData.ExecuteSql(sql);
		}
		public DataSet GetDataSetBySql(string sql)
		{
			return this.aidePlatformManagerData.GetDataSetBySql(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return this.aidePlatformManagerData.GetScalarBySql(sql);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			return this.aidePlatformManagerData.ExcuteByProce(proceName, dir);
		}
	}
}
