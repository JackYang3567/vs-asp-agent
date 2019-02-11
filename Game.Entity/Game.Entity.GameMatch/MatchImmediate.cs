using System;
namespace Game.Entity.GameMatch
{
	[System.Serializable]
	public class MatchImmediate
	{
		public const string Tablename = "MatchImmediate";
		public const string _MatchID = "MatchID";
		public const string _MatchNo = "MatchNo";
		public const string _StartUserCount = "StartUserCount";
		public const string _AndroidUserCount = "AndroidUserCount";
		public const string _InitialBase = "InitialBase";
		public const string _InitialScore = "InitialScore";
		public const string _MinEnterGold = "MinEnterGold";
		public const string _PlayCount = "PlayCount";
		public const string _SwitchTableCount = "SwitchTableCount";
		public const string _PrecedeTimer = "PrecedeTimer";
		private int m_matchID;
		private short m_matchNo;
		private int m_startUserCount;
		private int m_androidUserCount;
		private int m_initialBase;
		private int m_initialScore;
		private int m_minEnterGold;
		private byte m_playCount;
		private byte m_switchTableCount;
		private int m_precedeTimer;
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
		public int StartUserCount
		{
			get
			{
				return this.m_startUserCount;
			}
			set
			{
				this.m_startUserCount = value;
			}
		}
		public int AndroidUserCount
		{
			get
			{
				return this.m_androidUserCount;
			}
			set
			{
				this.m_androidUserCount = value;
			}
		}
		public int InitialBase
		{
			get
			{
				return this.m_initialBase;
			}
			set
			{
				this.m_initialBase = value;
			}
		}
		public int InitialScore
		{
			get
			{
				return this.m_initialScore;
			}
			set
			{
				this.m_initialScore = value;
			}
		}
		public int MinEnterGold
		{
			get
			{
				return this.m_minEnterGold;
			}
			set
			{
				this.m_minEnterGold = value;
			}
		}
		public byte PlayCount
		{
			get
			{
				return this.m_playCount;
			}
			set
			{
				this.m_playCount = value;
			}
		}
		public byte SwitchTableCount
		{
			get
			{
				return this.m_switchTableCount;
			}
			set
			{
				this.m_switchTableCount = value;
			}
		}
		public int PrecedeTimer
		{
			get
			{
				return this.m_precedeTimer;
			}
			set
			{
				this.m_precedeTimer = value;
			}
		}
		public MatchImmediate()
		{
			this.m_matchID = 0;
			this.m_matchNo = 0;
			this.m_startUserCount = 0;
			this.m_androidUserCount = 0;
			this.m_initialBase = 0;
			this.m_initialScore = 0;
			this.m_minEnterGold = 0;
			this.m_playCount = 0;
			this.m_switchTableCount = 0;
			this.m_precedeTimer = 0;
		}
	}
}
