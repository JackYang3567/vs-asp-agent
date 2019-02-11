using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class ConfineContent
	{
		public const string Tablename = "ConfineContent";
		public const string _ContentID = "ContentID";
		public const string _String = "String";
		public const string _EnjoinOverDate = "EnjoinOverDate";
		public const string _CollectDate = "CollectDate";
		private int m_contentID;
		private string m_string;
		private System.DateTime? m_enjoinOverDate;
		private System.DateTime m_collectDate;
		public int ContentID
		{
			get
			{
				return this.m_contentID;
			}
			set
			{
				this.m_contentID = value;
			}
		}
		public string String
		{
			get
			{
				return this.m_string;
			}
			set
			{
				this.m_string = value;
			}
		}
		public System.DateTime? EnjoinOverDate
		{
			get
			{
				return this.m_enjoinOverDate;
			}
			set
			{
				this.m_enjoinOverDate = value;
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
		public ConfineContent()
		{
			this.m_contentID = 0;
			this.m_string = "";
			this.m_enjoinOverDate = null;
			this.m_collectDate = System.DateTime.Now;
		}
	}
}
