using System;
namespace Game.Entity.NativeWeb
{
	[System.Serializable]
	public class GameIssueInfo
	{
		public const string Tablename = "GameIssueInfo";
		public const string _IssueID = "IssueID";
		public const string _IssueTitle = "IssueTitle";
		public const string _IssueContent = "IssueContent";
		public const string _TypeID = "TypeID";
		public const string _Nullity = "Nullity";
		public const string _CollectDate = "CollectDate";
		public const string _ModifyDate = "ModifyDate";
		private int m_issueID;
		private string m_issueTitle;
		private string m_issueContent;
		private int m_typeID;
		private byte m_nullity;
		private System.DateTime m_collectDate;
		private System.DateTime m_modifyDate;
		public int IssueID
		{
			get
			{
				return this.m_issueID;
			}
			set
			{
				this.m_issueID = value;
			}
		}
		public string IssueTitle
		{
			get
			{
				return this.m_issueTitle;
			}
			set
			{
				this.m_issueTitle = value;
			}
		}
		public string IssueContent
		{
			get
			{
				return this.m_issueContent;
			}
			set
			{
				this.m_issueContent = value;
			}
		}
		public int TypeID
		{
			get
			{
				return this.m_typeID;
			}
			set
			{
				this.m_typeID = value;
			}
		}
		public byte Nullity
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
		public System.DateTime CollectDate
		{
			get
			{
				return this.m_collectDate;
			}
			set
			{
				this.m_collectDate = value;
			}
		}
		public System.DateTime ModifyDate
		{
			get
			{
				return this.m_modifyDate;
			}
			set
			{
				this.m_modifyDate = value;
			}
		}
		public int Hot
		{
			get;
			set;
		}
		public GameIssueInfo()
		{
			this.m_issueID = 0;
			this.m_issueTitle = "";
			this.m_issueContent = "";
			this.m_typeID = 0;
			this.m_nullity = 0;
			this.m_collectDate = System.DateTime.Now;
			this.m_modifyDate = System.DateTime.Now;
		}
	}
}
