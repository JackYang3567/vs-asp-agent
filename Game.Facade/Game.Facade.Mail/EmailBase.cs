using Game.Utils;
using System;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;
namespace Game.Facade.Mail
{
	public class EmailBase
	{
		public delegate void MassMailingCallback(string mailAddress, string errorMessage);
		private string m_accounts;
		private string m_password;
		private string m_content;
		private string m_smtpServer;
		private int m_port;
		private string m_smtpSenderEmail;
		private MessageRender _messageRender;
		private string contentTempdate;
		private string subjectTemplate;
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
		public virtual string Subject
		{
			get
			{
				return this._messageRender.Render(this.subjectTemplate);
			}
		}
		public string Content
		{
			get
			{
				if (string.IsNullOrEmpty(this.m_content))
				{
					this.m_content = this._messageRender.Render(this.contentTempdate);
				}
				return this.m_content;
			}
			set
			{
				this.m_content = value;
			}
		}
		public MessageRender Render
		{
			get
			{
				return this._messageRender;
			}
		}
		public EmailBase()
		{
			this._messageRender = new MessageRender();
		}
		public EmailBase(MailConfigInfo mailConfigInfo)
		{
			this._messageRender = new MessageRender();
			this.m_smtpServer = mailConfigInfo.SmtpServer;
			this.m_smtpSenderEmail = mailConfigInfo.SmtpSenderEmail;
			this.m_accounts = mailConfigInfo.Accounts;
			this.m_password = mailConfigInfo.Password;
			this.m_port = mailConfigInfo.Port;
		}
		public EmailBase(string subjectTemplate, string contentTemplate, MailConfigInfo mailConfigInfo) : this(mailConfigInfo)
		{
			this._messageRender = new MessageRender();
			this.subjectTemplate = subjectTemplate;
			this.contentTempdate = contentTemplate;
		}
		public EmailBase(string subjectTemplate, string contentTemplate) : this()
		{
			this._messageRender = new MessageRender();
			this.subjectTemplate = subjectTemplate;
			this.contentTempdate = contentTemplate;
		}
		public EmailBase(MailTMLConfigInfo mailTml, MailConfigInfo mailConfigInfo) : this(mailConfigInfo)
		{
			this._messageRender = new MessageRender();
			this.subjectTemplate = mailTml.MailTitle;
			this.contentTempdate = mailTml.MailContent.Text;
		}
		public void TestEmail(string address)
		{
			SmtpClient smtpClient = new SmtpClient(this.SmtpServer)
			{
				UseDefaultCredentials = false,
				DeliveryMethod = SmtpDeliveryMethod.Network,
				Credentials = new NetworkCredential(this.Accounts, this.Password),
				Port = this.Port
			};
			MailMessage mailMessage = new MailMessage(this.SmtpSenderEmail, address, this.Subject, this.Content)
			{
				IsBodyHtml = true,
				BodyEncoding = System.Text.Encoding.GetEncoding("gb2312")
			};
			if (this.Port != 25)
			{
				smtpClient.EnableSsl = true;
			}
			smtpClient.Send(mailMessage);
			mailMessage.Dispose();
		}
		public void Send(string[] mailAddress)
		{
			if (mailAddress != null)
			{
				System.Threading.WaitCallback callBack = new System.Threading.WaitCallback(this.Send);
				for (int i = 0; i < mailAddress.Length; i++)
				{
					string text = mailAddress[i];
					if (!string.IsNullOrEmpty(text))
					{
						System.Threading.ThreadPool.QueueUserWorkItem(callBack, text.Trim());
					}
				}
			}
		}
		private void Send(object email)
		{
			try
			{
				SmtpClient smtpClient = new SmtpClient(this.SmtpServer)
				{
					UseDefaultCredentials = false,
					DeliveryMethod = SmtpDeliveryMethod.Network,
					Credentials = new NetworkCredential(this.Accounts, this.Password)
				};
				MailMessage mailMessage = new MailMessage(this.SmtpSenderEmail, email.ToString(), this.Subject, this.Content)
				{
					IsBodyHtml = true,
					BodyEncoding = System.Text.Encoding.GetEncoding("gb2312")
				};
				if (this.Port != 25)
				{
					smtpClient.EnableSsl = true;
				}
				smtpClient.Send(mailMessage);
				mailMessage.Dispose();
			}
			catch (System.Exception ex)
			{
				TextLogger.Write(ex.ToString());
			}
		}
		public void Send(string address)
		{
			System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(this.Send), address);
		}
	}
}
