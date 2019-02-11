using Game.Kernel;
using System;
using System.IO;
namespace Game.Facade.Mail
{
	public class TMLForgetConfigManager : DefaultConfigFileManager
	{
		private static MailTMLConfigInfo m_configinfo;
		private static System.DateTime m_fileoldchange;
		public static string filename;
		public new static IConfigInfo ConfigInfo
		{
			get
			{
				return TMLForgetConfigManager.m_configinfo;
			}
			set
			{
				TMLForgetConfigManager.m_configinfo = (MailTMLConfigInfo)value;
			}
		}
		static TMLForgetConfigManager()
		{
			TMLForgetConfigManager.m_configinfo = null;
			TMLForgetConfigManager.filename = null;
			TMLForgetConfigManager.m_fileoldchange = System.IO.File.GetLastWriteTime(DefaultConfigFileManager.ConfigFilePath);
			TMLForgetConfigManager.m_configinfo = (MailTMLConfigInfo)DefaultConfigFileManager.DeserializeInfo(DefaultConfigFileManager.ConfigFilePath, typeof(MailTMLConfigInfo));
		}
		public static MailTMLConfigInfo LoadConfig()
		{
			TMLForgetConfigManager.ConfigInfo = DefaultConfigFileManager.LoadConfig(ref TMLForgetConfigManager.m_fileoldchange, DefaultConfigFileManager.ConfigFilePath, TMLForgetConfigManager.ConfigInfo, false);
			return TMLForgetConfigManager.ConfigInfo as MailTMLConfigInfo;
		}
		public override bool SaveConfig()
		{
			return base.SaveConfig(DefaultConfigFileManager.ConfigFilePath, TMLForgetConfigManager.ConfigInfo);
		}
	}
}
