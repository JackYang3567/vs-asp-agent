using System;
using System.Collections.Generic;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class AgentInfo
	{
		public int AgentID
		{
			get;
			set;
		}
		public string AgentAcc
		{
			get;
			set;
		}
		public string Pwd
		{
			get;
			set;
		}
		public double AgentRate
		{
			get;
			set;
		}
		public string RealName
		{
			get;
			set;
		}
		public string QQ
		{
			get;
			set;
		}
		public string Memo
		{
			get;
			set;
		}
		public string AgentDomain
		{
			get;
			set;
		}
		public string RegIP
		{
			get;
			set;
		}
		public double Score
		{
			get;
			set;
		}
		public string BankAcc
		{
			get;
			set;
		}
		public string BankName
		{
			get;
			set;
		}
		public string BankAddress
		{
			get;
			set;
		}
		public byte AgentStatus
		{
			get;
			set;
		}
		public string ParentAcc
		{
			get;
			set;
		}
		public int Operator
		{
			get;
			set;
		}
		public string LastIP
		{
			get;
			set;
		}
		public System.DateTime LastDate
		{
			get;
			set;
		}
		public int AgentLevel
		{
			get;
			set;
		}
		public System.DateTime RegDate
		{
			get;
			set;
		}
		public int ParentID
		{
			get;
			set;
		}
		public int safeOpen
		{
			get;
			set;
		}
		public string ShowName
		{
			get;
			set;
		}
		public string WeChat
		{
			get;
			set;
		}
		public int IsClient
		{
			get;
			set;
		}
		public int ShowSort
		{
			get;
			set;
		}
		public int QueryRight
		{
			get;
			set;
		}
		public System.Collections.Generic.List<AgentMenu> menus
		{
			get;
			set;
		}
		public AgentInfo()
		{
		}
		public AgentInfo(int aid, string bankName, string bankAcc, string bankAddress)
		{
			this.AgentID = aid;
			this.BankName = bankName;
			this.BankAcc = bankAcc;
			this.BankAddress = bankAddress;
		}
		public AgentInfo(string agentAccount, string pword, double agentNum, string trueName, string qq, string memo, string domain)
		{
			this.AgentAcc = agentAccount;
			this.Pwd = pword;
			this.QQ = qq;
			this.Memo = memo;
			this.RealName = trueName;
			this.AgentRate = agentNum;
			this.AgentDomain = domain;
		}
		public AgentInfo(string agentAccount, string pword, double agentNum, string trueName, string qq, string memo, string domain, string clientIP) : this(agentAccount, pword, agentNum, trueName, qq, memo, domain)
		{
			this.RegIP = clientIP;
		}
		public AgentInfo(string agentAccount, string pword, double agentNum, string trueName, string qq, string memo, string domain, string clientIP, int aid) : this(agentAccount, pword, agentNum, trueName, qq, memo, domain, clientIP)
		{
			this.AgentID = aid;
		}
	}
}
