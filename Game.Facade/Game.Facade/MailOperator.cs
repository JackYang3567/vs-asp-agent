using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace Game.Facade
{
	public class MailOperator
	{
		public void SendMail(string smtpserver, int? port, string account, string pass, string from_alias, string title, string content, bool ishtml, System.Text.Encoding encoding, MailPriority priority, System.Collections.Generic.Dictionary<string, string> to_list)
		{
			if (to_list.Count <= 0)
			{
				throw new System.Exception("邮件接收人地址不能为空");
			}
			if (to_list.Count >= 20)
			{
				throw new System.Exception("每次只能发送给少于20个接收人！");
			}
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Host = smtpserver;
			if (port.HasValue)
			{
				smtpClient.Port = port.Value;
			}
			smtpClient.EnableSsl = true;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(account, pass);
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			MailAddress from = new MailAddress(account);
			if (!string.IsNullOrEmpty(from_alias))
			{
				from = new MailAddress(account, from_alias);
			}
			MailMessage mailMessage = new MailMessage();
			mailMessage.From = from;
			foreach (System.Collections.Generic.KeyValuePair<string, string> current in to_list)
			{
				if (string.IsNullOrEmpty(current.Value))
				{
					mailMessage.To.Add(new MailAddress(current.Key));
				}
				else
				{
					mailMessage.To.Add(new MailAddress(current.Key, current.Value));
				}
			}
			mailMessage.Subject = title;
			mailMessage.Body = content;
			mailMessage.BodyEncoding = encoding;
			mailMessage.IsBodyHtml = ishtml;
			mailMessage.Priority = priority;
			try
			{
				smtpClient.Send(mailMessage);
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
		public void SendMail(string smtpserver, int? port, string userName, string password, string from_mail, string from_alias, string to_mail, string to_alias, string title, string content, bool ishtml, bool enableSsl, System.Text.Encoding encoding, MailPriority priority)
		{
			SmtpClient smtpClient = new SmtpClient();
			smtpClient.Host = smtpserver;
			if (port.HasValue)
			{
				smtpClient.Port = port.Value;
			}
			smtpClient.EnableSsl = enableSsl;
			smtpClient.UseDefaultCredentials = false;
			smtpClient.Credentials = new NetworkCredential(userName, password);
			smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
			MailAddress from = new MailAddress(from_mail);
			if (!string.IsNullOrEmpty(from_alias))
			{
				from = new MailAddress(from_mail, from_alias);
			}
			MailAddress to = new MailAddress(to_mail);
			if (!string.IsNullOrEmpty(to_alias))
			{
				to = new MailAddress(to_mail, to_alias);
			}
			MailMessage mailMessage = new MailMessage(from, to);
			mailMessage.Subject = title;
			mailMessage.Body = content;
			mailMessage.BodyEncoding = encoding;
			mailMessage.IsBodyHtml = ishtml;
			mailMessage.Priority = priority;
			mailMessage.DeliveryNotificationOptions = DeliveryNotificationOptions.OnSuccess;
			try
			{
				smtpClient.Send(mailMessage);
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
		}
	}
}
