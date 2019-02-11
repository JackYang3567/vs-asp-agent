using Game.Entity.PlatformManager;
using Game.IData;
using Game.Kernel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
namespace Game.Data
{
	public class PlatformManagerDataProvider : BaseDataProvider, IPlatformManagerDataProvider
	{
		private ITableProvider aideUserProvider;
		private ITableProvider aideRoleProvider;
		private ITableProvider aideRolePermissionProvider;
		private ITableProvider aideQPAdminSiteInfoProvider;
		public PlatformManagerDataProvider(string connString) : base(connString)
		{
			this.aideUserProvider = this.GetTableProvider("Base_Users");
			this.aideRoleProvider = this.GetTableProvider("Base_Roles");
			this.aideRolePermissionProvider = this.GetTableProvider("Base_RolePermission");
			this.aideQPAdminSiteInfoProvider = this.GetTableProvider("QPAdminSiteInfo");
		}
		public Message UserLogon(Base_Users user)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strUserName", user.Username));
			list.Add(base.Database.MakeInParam("strPassword", user.Password));
			list.Add(base.Database.MakeInParam("strClientIP", user.LastLoginIP));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<Base_Users>(base.Database, "NET_PM_UserLogon", list);
		}
		public void Register(Base_Users user)
		{
			System.Data.DataRow dataRow = this.aideUserProvider.NewRow();
			dataRow["Username"] = user.Username;
			dataRow["Password"] = user.Password;
			dataRow["RoleID"] = user.RoleID;
			dataRow["Nullity"] = user.Nullity;
			dataRow["PreLoginIP"] = user.PreLoginIP;
			dataRow["PreLogintime"] = user.PreLogintime;
			dataRow["LastLoginIP"] = user.LastLoginIP;
			dataRow["LastLogintime"] = user.LastLogintime;
			dataRow["LoginTimes"] = user.LoginTimes;
			dataRow["IsBand"] = user.IsBand;
			dataRow["BandIP"] = user.BandIP;
			dataRow["IsAssist"] = user.IsAssist;
			dataRow["MobilePhone"] = user.MobilePhone;
			dataRow["IsMobileNeed"] = 1;
			this.aideUserProvider.Insert(dataRow);
		}
		public void DeleteUser(string userIDList)
		{
			this.aideUserProvider.Delete(string.Format("{0}", userIDList));
		}
		public void ModifyUserLogonPass(Base_Users user, string newLogonPass)
		{
			string commandText = "UPDATE Base_Users SET Password = @Password WHERE UserID= @UserID";
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("UserID", user.UserID));
			list.Add(base.Database.MakeInParam("Password", newLogonPass));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public void ModifyUserNullity(string userIDList, bool nullity)
		{
			string commandText = string.Format("UPDATE Base_Users SET Nullity = @Nullity WHERE UserID IN ({0})", userIDList);
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Nullity", nullity));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, commandText, list.ToArray());
		}
		public void ModifyUserInfo(Base_Users user)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Base_Users SET ").Append("Password=@Password, ").Append("RoleID=@RoleID, ").Append("Nullity=@Nullity, ").Append("IsAssist=@IsAssist, ").Append("MobilePhone=@MobilePhone ").Append("WHERE UserID=@UserID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("Password", user.Password));
			list.Add(base.Database.MakeInParam("RoleID", user.RoleID));
			list.Add(base.Database.MakeInParam("Nullity", user.Nullity));
			list.Add(base.Database.MakeInParam("UserID", user.UserID));
			list.Add(base.Database.MakeInParam("IsAssist", user.IsAssist));
			list.Add(base.Database.MakeInParam("MobilePhone", user.MobilePhone));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void BindIP(Base_Users user)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Base_Users SET ").Append("IsBand=@IsBand, ").Append("BandIP=@BandIP ").Append("WHERE UserID=@UserID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("IsBand", user.IsBand));
			list.Add(base.Database.MakeInParam("BandIP", user.BandIP));
			list.Add(base.Database.MakeInParam("UserID", user.UserID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public Base_Users GetUserByAccounts(string userName)
		{
			string where = string.Format("(NOLOCK) WHERE UserName= N'{0}'", userName);
			return this.aideUserProvider.GetObject<Base_Users>(where);
		}
		public Base_Users GetUserByUserID(int userID)
		{
			string where = string.Format("(NOLOCK) WHERE UserID={0}", userID);
			return this.aideUserProvider.GetObject<Base_Users>(where);
		}
		public System.Data.DataSet GetUserListByRoleID(int roleID)
		{
			return this.aideUserProvider.Get(string.Format("(NOLOCK) WHERE RoleID={0}", roleID));
		}
		public System.Data.DataSet GetUserList()
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT UserID, RoleID", new object[0]).AppendFormat("      ,Rolename=", new object[0]).AppendFormat("         CASE UserID", new object[0]).AppendFormat("             WHEN 1 THEN N'超级管理员'", new object[0]).AppendFormat("             ELSE (SELECT RoleName FROM Base_Roles(NOLOCK) WHERE RoleID=u.RoleID)", new object[0]).AppendFormat("         END", new object[0]).AppendFormat("      ,UserName,PreLogintime,PreLoginIP,LastLogintime,LastLoginIP", new object[0]).AppendFormat("      ,LoginTimes,IsBand,BandIP", new object[0]).AppendFormat("  FROM Base_Users(NOLOCK) AS u", new object[0]).Append(" WHERE UserID>1");
			return base.Database.ExecuteDataset(stringBuilder.ToString());
		}
		public PagerSet GetUserList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("Base_Users", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetRoleList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("Base_Roles", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public Base_Roles GetRoleInfo(int roleID)
		{
			string where = string.Format("(NOLOCK) WHERE RoleID= {0}", roleID);
			return this.aideRoleProvider.GetObject<Base_Roles>(where);
		}
		public string GetRolenameByRoleID(int roleID)
		{
			string where = string.Format("(NOLOCK) WHERE RoleID={0}", roleID);
			Base_Roles @object = this.aideRoleProvider.GetObject<Base_Roles>(where);
			if (@object == null)
			{
				return "";
			}
			return @object.RoleName;
		}
		public void InsertRole(Base_Roles role)
		{
			System.Data.DataRow dataRow = this.aideRoleProvider.NewRow();
			dataRow["RoleID"] = role.RoleID;
			dataRow["RoleName"] = role.RoleName;
			dataRow["Description"] = role.Description;
			this.aideRoleProvider.Insert(dataRow);
		}
		public void UpdateRole(Base_Roles role)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE Base_Roles SET ").Append("RoleName=@RoleName ,").Append("Description=@Description ").Append("WHERE RoleID= @RoleID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("RoleName", role.RoleName));
			list.Add(base.Database.MakeInParam("Description", role.Description));
			list.Add(base.Database.MakeInParam("RoleID", role.RoleID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public void DeleteRole(string sqlQuery)
		{
			this.aideRoleProvider.Delete(sqlQuery);
		}
		public System.Data.DataSet GetMenuByRoleID(int roleID)
		{
			string commandText;
			if (roleID <= 1)
			{
				commandText = "SELECT ModuleID,Title,Link,OrderNo,ParentID FROM Base_Module WHERE Nullity=0";
			}
			else
			{
				System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
				stringBuilder.AppendFormat("SELECT b.ModuleID,b.Title,b.Link,b.OrderNo,b.ParentID,b.Nullity,a.RoleID FROM Base_Module b LEFT JOIN Base_RolePermission a ON a.ModuleID = b.ModuleID ", new object[0]);
				stringBuilder.AppendFormat("WHERE b.Nullity=0 AND a.RoleID={0} ", roleID);
				stringBuilder.AppendFormat("UNION ALL SELECT ModuleID,Title,Link,OrderNo,ParentID,Nullity,{0} as RoleID from Base_Module WHERE ModuleID  ", roleID);
				stringBuilder.AppendFormat("IN(SELECT distinct b.ParentID FROM Base_Module b LEFT JOIN Base_RolePermission a ON a.ModuleID = b.ModuleID WHERE b.Nullity=0 AND a.RoleID={0})", roleID);
				commandText = stringBuilder.ToString();
			}
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetPermissionByModuleID(int moduleID, int RoleID)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("SELECT t.PermissionTitle,t.ModuleID,m.Title,m.Link FROM (SELECT a.ModuleID,a.RoleID,c.PermissionTitle,c.PermissionValue FROM Base_ModulePermission c LEFT JOIN Base_RolePermission a ON c.ModuleID=a.ModuleID WHERE c.Nullity=0 {0} AND c.PermissionValue & a.OperationPermission =c.PermissionValue) AS t INNER JOIN Base_Module m ON t.ModuleID = m.ModuleID WHERE m.Nullity=0 AND m.ModuleID={1}", (RoleID <= 1) ? "" : ("AND a.RoleID=" + RoleID), moduleID);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString());
		}
		public System.Data.DataSet GetMenuByUserID(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			System.Data.DataSet result;
			base.Database.RunProc("NET_PM_GetMenuByUserID", list, out result);
			return result;
		}
		public System.Data.DataSet GetPermissionByUserID(int userID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("dwUserID", userID));
			System.Data.DataSet result;
			base.Database.RunProc("NET_PM_GetPermissionByUserID", list, out result);
			return result;
		}
		public System.Data.DataSet GetModuleList()
		{
			string commandText = "SELECT * FROM Base_Module WHERE  Nullity=0 ORDER BY OrderNo";
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetModuleParentList()
		{
			string commandText = "SELECT * FROM Base_Module WHERE ParentID=0 AND Nullity=0 ORDER BY OrderNo";
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetModuleListByModuleID(int moduleID)
		{
			string commandText = string.Format("SELECT * FROM Base_Module WHERE ParentID={0} ORDER BY OrderNo", moduleID);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetModulePermissionList()
		{
			string commandText = string.Format("SELECT * FROM Base_ModulePermission WHERE Nullity=0", new object[0]);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetModulePermissionList(int moduleID)
		{
			string commandText = string.Format("SELECT * FROM Base_ModulePermission WHERE ModuleID={0} AND Nullity=0", moduleID);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public System.Data.DataSet GetRolePermissionList(int roleID)
		{
			string commandText = string.Format("SELECT * FROM Base_RolePermission WHERE RoleID={0}", roleID);
			return base.Database.ExecuteDataset(System.Data.CommandType.Text, commandText);
		}
		public void InsertRolePermission(Base_RolePermission rolePermission)
		{
			System.Data.DataRow dataRow = this.aideRolePermissionProvider.NewRow();
			dataRow["RoleID"] = rolePermission.RoleID;
			dataRow["ModuleID"] = rolePermission.ModuleID;
			dataRow["ManagerPermission"] = rolePermission.ManagerPermission;
			dataRow["OperationPermission"] = rolePermission.OperationPermission;
			dataRow["StateFlag"] = rolePermission.StateFlag;
			this.aideRolePermissionProvider.Insert(dataRow);
		}
		public void DeleteRolePermission(int roleID)
		{
			this.aideRolePermissionProvider.Delete(string.Format("WHERE RoleID = ({0})", roleID));
		}
		public PagerSet GetSystemSecurityList(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("SystemSecurity", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public SystemSecurity GetSystemSecurityById(int Id)
		{
			SystemSecurity systemSecurity = new SystemSecurity();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.AppendFormat("select RecordID,OperatingTime,OperatingName,OperatingIP,OperatingAccounts,Remark from SystemSecurity where RecordID=" + Id, new object[0]);
			System.Data.DataSet dataSet = base.Database.ExecuteDataset(System.Data.CommandType.Text, stringBuilder.ToString());
			int num = 0;
			System.DateTime now = System.DateTime.Now;
			if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				systemSecurity.RecordID = (int.TryParse(dataSet.Tables[0].Rows[0]["RecordID"].ToString(), out num) ? System.Convert.ToInt32(dataSet.Tables[0].Rows[0]["RecordID"]) : 0);
				systemSecurity.OperatingTime = (System.DateTime.TryParse(dataSet.Tables[0].Rows[0]["OperatingTime"].ToString(), out now) ? System.Convert.ToDateTime(dataSet.Tables[0].Rows[0]["OperatingTime"]) : now);
				systemSecurity.OperatingName = ((dataSet.Tables[0].Rows[0]["OperatingName"] == null) ? "" : dataSet.Tables[0].Rows[0]["OperatingName"].ToString());
				systemSecurity.OperatingIP = ((dataSet.Tables[0].Rows[0]["OperatingIP"] == null) ? "" : dataSet.Tables[0].Rows[0]["OperatingIP"].ToString());
				systemSecurity.OperatingAccounts = ((dataSet.Tables[0].Rows[0]["OperatingAccounts"] == null) ? "" : dataSet.Tables[0].Rows[0]["OperatingAccounts"].ToString());
				systemSecurity.Remark = ((dataSet.Tables[0].Rows[0]["Remark"] == null) ? "" : dataSet.Tables[0].Rows[0]["Remark"].ToString());
			}
			return systemSecurity;
		}
		public QPAdminSiteInfo GetQPAdminSiteInfo(int siteID)
		{
			string where = string.Format("(NOLOCK) WHERE SiteID= {0}", siteID);
			return this.aideQPAdminSiteInfoProvider.GetObject<QPAdminSiteInfo>(where);
		}
		public void UpdateQPAdminSiteInfo(QPAdminSiteInfo site)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("UPDATE QPAdminSiteInfo SET ").Append("SiteName=@SiteName ,").Append("PageSize=@PageSize ,").Append("CopyRight=@CopyRight ").Append("WHERE SiteID= @SiteID");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("SiteName", site.SiteName));
			list.Add(base.Database.MakeInParam("PageSize", site.PageSize));
			list.Add(base.Database.MakeInParam("CopyRight", site.CopyRight));
			list.Add(base.Database.MakeInParam("SiteID", site.SiteID));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public Message UserLogonApp(Base_Users user, string machineID)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("strAccounts", user.Username));
			list.Add(base.Database.MakeInParam("strPassword", user.Password));
			list.Add(base.Database.MakeInParam("strClientIP", user.LastLoginIP));
			list.Add(base.Database.MakeInParam("strMachineSerial", machineID));
			list.Add(base.Database.MakeOutParam("strErrorDescribe", typeof(string), 127));
			return MessageHelper.GetMessageForObject<Base_Users>(base.Database, "APP_PM_UserLogon", list);
		}
		public void AddSystemSecurity(System.Collections.Generic.Dictionary<string, object> dic)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			stringBuilder.Append("INSERT SystemSecurity ( OperatingTime ,OperatingName ,OperatingIP ,OperatingAccounts, Remark,ObjectAccounts)VALUES(GETDATE()").Append(",@OperatingName").Append(",@OperatingIP ").Append(",@OperatingAccounts").Append(",@Remark").Append(",@Accounts").Append(")");
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			list.Add(base.Database.MakeInParam("OperatingName", dic["OperatingName"]));
			list.Add(base.Database.MakeInParam("OperatingIP", dic["OperatingIP"]));
			list.Add(base.Database.MakeInParam("OperatingAccounts", dic["OperatingAccounts"]));
			list.Add(base.Database.MakeInParam("Remark", dic["Remark"]));
			list.Add(base.Database.MakeInParam("Accounts", dic["Accounts"]));
			base.Database.ExecuteNonQuery(System.Data.CommandType.Text, stringBuilder.ToString(), list.ToArray());
		}
		public PagerSet GetOperatingLog(int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters("OperatingLog", orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize);
			return this.GetPagerSet2(prams);
		}
		public PagerSet GetList(string tableName, int pageIndex, int pageSize, string condition, string orderby, string[] fields)
		{
			PagerParameters prams = new PagerParameters(tableName, orderby, condition, pageIndex, pageSize, fields);
			return this.GetPagerSet2(prams);
		}
		public int ExecuteSql(string sql)
		{
			return base.Database.ExecuteNonQuery(sql);
		}
		public System.Data.DataSet GetDataSetBySql(string sql)
		{
			return base.Database.ExecuteDataset(sql);
		}
		public string GetScalarBySql(string sql)
		{
			return base.Database.ExecuteScalarToStr(System.Data.CommandType.Text, sql);
		}
		public Message ExcuteByProce(string proceName, System.Collections.Generic.Dictionary<string, object> dir)
		{
			System.Collections.Generic.List<System.Data.Common.DbParameter> list = new System.Collections.Generic.List<System.Data.Common.DbParameter>();
			if (dir != null)
			{
				int num = 0;
				foreach (System.Collections.Generic.KeyValuePair<string, object> current in dir)
				{
					if (num == dir.Count - 1)
					{
						list.Add(base.Database.MakeOutParam(current.Key, typeof(string), 127));
					}
					else
					{
						list.Add(base.Database.MakeInParam(current.Key, current.Value));
					}
					num++;
				}
			}
			return MessageHelper.GetMessage(base.Database, proceName, list);
		}
	}
}
