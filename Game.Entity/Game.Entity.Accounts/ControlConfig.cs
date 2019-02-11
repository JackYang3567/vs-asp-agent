using System;
namespace Game.Entity.Accounts
{
	[System.Serializable]
	public class ControlConfig
	{
		public const string Tablename = "ControlConfig";
		public const string _AutoControlEnable = "AutoControlEnable";
		public const string _BSustainedTimeCount = "BSustainedTimeCount";
		public const string _WSustainedTimeCount = "WSustainedTimeCount";
		public const string _JoinBlackWinScore = "JoinBlackWinScore";
		public const string _JoinWhiteLoseScore = "JoinWhiteLoseScore";
		public const string _BlackControlType = "BlackControlType";
		public const string _WhiteControlType = "WhiteControlType";
		public const string _QuitBlackLoseScore = "QuitBlackLoseScore";
		public const string _QuitWhiteWinScore = "QuitWhiteWinScore";
		public const string _BlackWinRate = "BlackWinRate";
		public const string _WhiteWinRate = "WhiteWinRate";
		private byte m_autoControlEnable;
		private int m_bSustainedTimeCount;
		private int m_wSustainedTimeCount;
		private long m_joinBlackWinScore;
		private long m_joinWhiteLoseScore;
		private short m_blackControlType;
		private short m_whiteControlType;
		private long m_quitBlackLoseScore;
		private long m_quitWhiteWinScore;
		private short m_blackWinRate;
		private short m_whiteWinRate;
		public byte AutoControlEnable
		{
			get
			{
				return this.m_autoControlEnable;
			}
			set
			{
				this.m_autoControlEnable = value;
			}
		}
		public int BSustainedTimeCount
		{
			get
			{
				return this.m_bSustainedTimeCount;
			}
			set
			{
				this.m_bSustainedTimeCount = value;
			}
		}
		public int WSustainedTimeCount
		{
			get
			{
				return this.m_wSustainedTimeCount;
			}
			set
			{
				this.m_wSustainedTimeCount = value;
			}
		}
		public long JoinBlackWinScore
		{
			get
			{
				return this.m_joinBlackWinScore;
			}
			set
			{
				this.m_joinBlackWinScore = value;
			}
		}
		public long JoinWhiteLoseScore
		{
			get
			{
				return this.m_joinWhiteLoseScore;
			}
			set
			{
				this.m_joinWhiteLoseScore = value;
			}
		}
		public short BlackControlType
		{
			get
			{
				return this.m_blackControlType;
			}
			set
			{
				this.m_blackControlType = value;
			}
		}
		public short WhiteControlType
		{
			get
			{
				return this.m_whiteControlType;
			}
			set
			{
				this.m_whiteControlType = value;
			}
		}
		public long QuitBlackLoseScore
		{
			get
			{
				return this.m_quitBlackLoseScore;
			}
			set
			{
				this.m_quitBlackLoseScore = value;
			}
		}
		public long QuitWhiteWinScore
		{
			get
			{
				return this.m_quitWhiteWinScore;
			}
			set
			{
				this.m_quitWhiteWinScore = value;
			}
		}
		public short BlackWinRate
		{
			get
			{
				return this.m_blackWinRate;
			}
			set
			{
				this.m_blackWinRate = value;
			}
		}
		public short WhiteWinRate
		{
			get
			{
				return this.m_whiteWinRate;
			}
			set
			{
				this.m_whiteWinRate = value;
			}
		}
		public ControlConfig()
		{
			this.m_autoControlEnable = 0;
			this.m_bSustainedTimeCount = 0;
			this.m_wSustainedTimeCount = 0;
			this.m_joinBlackWinScore = 0L;
			this.m_joinWhiteLoseScore = 0L;
			this.m_blackControlType = 0;
			this.m_whiteControlType = 0;
			this.m_quitBlackLoseScore = 0L;
			this.m_quitWhiteWinScore = 0L;
			this.m_blackWinRate = 0;
			this.m_whiteWinRate = 0;
		}
	}
}
