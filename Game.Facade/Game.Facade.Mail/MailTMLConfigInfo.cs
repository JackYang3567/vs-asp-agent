using Game.Kernel;
using Game.Utils;
using System;
using System.Xml.Serialization;
namespace Game.Facade.Mail
{
	public class MailTMLConfigInfo : IConfigInfo
	{
		private CDATA m_contentTempdate = new CDATA("");
		private string m_subjectTemplate = "";
		[XmlElement("MailContent", Type = typeof(CDATA))]
		public CDATA MailContent
		{
			get
			{
				return this.m_contentTempdate;
			}
			set
			{
				this.m_contentTempdate = value;
			}
		}
		public string MailTitle
		{
			get
			{
				return this.m_subjectTemplate;
			}
			set
			{
				this.m_subjectTemplate = value;
			}
		}
		public MailTMLConfigInfo()
		{
		}
		public MailTMLConfigInfo(string contentTml, string titleTml)
		{
			this.m_contentTempdate = new CDATA(contentTml);
			this.m_subjectTemplate = titleTml;
		}
	}
}
