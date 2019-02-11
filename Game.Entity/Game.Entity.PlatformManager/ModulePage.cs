using System;
namespace Game.Entity.PlatformManager
{
	[System.Serializable]
	public class ModulePage
	{
		private int m_moduleID;
		private string m_moduleName;
		private string m_pageName;
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
		public string ModuleName
		{
			get
			{
				return this.m_moduleName;
			}
			set
			{
				this.m_moduleName = value;
			}
		}
		public string PageName
		{
			get
			{
				return this.m_pageName;
			}
			set
			{
				this.m_pageName = value;
			}
		}
		public ModulePage()
		{
		}
		public ModulePage(int moduleID, string moduleName, string pageName)
		{
			this.m_moduleID = moduleID;
			this.m_moduleName = moduleName;
			this.m_pageName = pageName;
		}
	}
}
