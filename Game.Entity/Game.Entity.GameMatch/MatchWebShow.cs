using System;
namespace Game.Entity.GameMatch
{
	[System.Serializable]
	public class MatchWebShow
	{
		public const string Tablename = "MatchWebShow";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _ImageUrl = "ImageUrl";
		public const string _BigImageUrl = "BigImageUrl";
		public const string _MatchSummary = "MatchSummary";
		public const string _MatchContent = "MatchContent";
		public const string _IsRecommend = "IsRecommend";
		public const string _MatchStatus = "MatchStatus";
		private int m_matchID;
		private short m_matchNo;
		private string m_imageUrl;
		private string m_bigImageUrl;
		private string m_matchSummary;
		private string m_matchContent;
		private bool m_isRecommend;
		private int m_matchStatus;
		public int MatchID
		{
			get
			{
				return this.m_matchID;
			}
			set
			{
				this.m_matchID = value;
			}
		}
		public short MatchNo
		{
			get
			{
				return this.m_matchNo;
			}
			set
			{
				this.m_matchNo = value;
			}
		}
		public string ImageUrl
		{
			get
			{
				return this.m_imageUrl;
			}
			set
			{
				this.m_imageUrl = value;
			}
		}
		public string BigImageUrl
		{
			get
			{
				return this.m_bigImageUrl;
			}
			set
			{
				this.m_bigImageUrl = value;
			}
		}
		public string MatchSummary
		{
			get
			{
				return this.m_matchSummary;
			}
			set
			{
				this.m_matchSummary = value;
			}
		}
		public string MatchContent
		{
			get
			{
				return this.m_matchContent;
			}
			set
			{
				this.m_matchContent = value;
			}
		}
		public bool IsRecommend
		{
			get
			{
				return this.m_isRecommend;
			}
			set
			{
				this.m_isRecommend = value;
			}
		}
		public int MatchStatus
		{
			get
			{
				return this.m_matchStatus;
			}
			set
			{
				this.m_matchStatus = value;
			}
		}
		public MatchWebShow()
		{
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_imageUrl = "";
			this.m_bigImageUrl = "";
			this.m_matchSummary = "";
			this.m_matchContent = "";
			this.m_isRecommend = false;
			this.m_matchStatus = 0;
		}
	}
}
