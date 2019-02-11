using System;
using System.IO;
using System.Web;
namespace Game.Facade.Mail
{
	public class MailConfigInfo
	{
		private string m_accounts;
		private string m_password;
		private string m_smtpServer;
		private int m_port;
		private string m_smtpSenderEmail;
		private string m_lossreportUrl;
		public string Accounts
		{
			get
			{
				return this.m_accounts;
			}
			set
			{
				this.m_accounts = value;
			}
		}
		public string Password
		{
			get
			{
				return this.m_password;
			}
			set
			{
				this.m_password = value;
			}
		}
		public string SmtpServer
		{
			get
			{
				return this.m_smtpServer;
			}
			set
			{
				this.m_smtpServer = value;
			}
		}
		public int Port
		{
			get
			{
				return this.m_port;
			}
			set
			{
				this.m_port = value;
			}
		}
		public string SmtpSenderEmail
		{
			get
			{
				return this.m_smtpSenderEmail;
			}
			set
			{
				this.m_smtpSenderEmail = value;
			}
		}
		public string LossreportUrl
		{
			get
			{
				return this.m_lossreportUrl;
			}
			set
			{
				this.m_lossreportUrl = value;
			}
		}
		public string GetMapPath(string strPath)
		{
			if (string.IsNullOrEmpty(strPath))
			{
				throw new System.Exception("strPath 不能为空！");
			}
			string result = string.Empty;
			System.Web.HttpContext httpContext = null;
			try
			{
				httpContext = System.Web.HttpContext.Current;
			}
			catch
			{
				httpContext = null;
			}
			if (httpContext != null)
			{
				result = httpContext.Server.MapPath(strPath);
			}
			else
			{
				string text = System.IO.Path.Combine(strPath, "");
				string arg_5E_0 = text.StartsWith("\\\\") ? text.Remove(0, 2) : text;
				result = System.AppDomain.CurrentDomain.BaseDirectory + System.IO.Path.Combine(strPath, "");
			}
			return result;
		}
	}
}
