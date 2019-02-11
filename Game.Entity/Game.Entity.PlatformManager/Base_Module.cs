using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class Base_Module
	{
		public const string Tablename = "Base_Module";
		public const string _ModuleID = "ModuleID";
		public const string _ParentID = "ParentID";
		public const string _Title = "Title";
		public const string _Link = "Link";
		public const string _OrderNo = "OrderNo";
		public const string _Nullity = "Nullity";
		public const string _IsMenu = "IsMenu";
		public const string _Description = "Description";
		public const string _ManagerPopedom = "ManagerPopedom";
		private int m_moduleID;
		private int m_parentID;
		private string m_title;
		private string m_link;
		private int m_orderNo;
		private bool m_nullity;
		private bool m_isMenu;
		private string m_description;
		private int m_managerPopedom;
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
		public string Title
		{
			get
			{
				return this.m_title;
			}
			set
			{
				this.m_title = value;
			}
		}
		public string Link
		{
			get
			{
				return this.m_link;
			}
			set
			{
				this.m_link = value;
			}
		}
		public int OrderNo
		{
			get
			{
				return this.m_orderNo;
			}
			set
			{
				this.m_orderNo = value;
			}
		}
		public bool Nullity
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
		public bool IsMenu
		{
			get
			{
				return this.m_isMenu;
			}
			set
			{
				this.m_isMenu = value;
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
		public int ManagerPopedom
		{
			get
			{
				return this.m_managerPopedom;
			}
			set
			{
				this.m_managerPopedom = value;
			}
		}
		public Base_Module()
		{
			this.m_moduleID = 0;
			this.m_parentID = 0;
			this.m_title = "";
			this.m_link = "";
			this.m_orderNo = 0;
			this.m_nullity = false;
			this.m_isMenu = false;
			this.m_description = "";
			this.m_managerPopedom = 0;
		}
	}
}
