using System;
namespace Game.Entity.NativeWeb
{
	[System.Serializable]
	public class MobileInfo
	{
		public const string Tablename = "MobileInfo";
		public const string _MobileID = "MobileID";
		public const string _MobileType = "MobileType";
		public const string _MobileSerial = "MobileSerial";
		public const string _MobileModel = "MobileModel";
		public const string _Size = "Size";
		public const string _Resolution = "Resolution";
		public const string _Screen = "Screen";
		public const string _OperatingSystem = "OperatingSystem";
		public const string _IsHorizontal = "IsHorizontal";
		public const string _Remark = "Remark";
		private int m_mobileID;
		private string m_mobileType;
		private string m_mobileSerial;
		private string m_mobileModel;
		private string m_size;
		private string m_resolution;
		private string m_screen;
		private string m_operatingSystem;
		private byte m_isHorizontal;
		private string m_remark;
		public int MobileID
		{
			get
			{
				return this.m_mobileID;
			}
			set
			{
				this.m_mobileID = value;
			}
		}
		public string MobileType
		{
			get
			{
				return this.m_mobileType;
			}
			set
			{
				this.m_mobileType = value;
			}
		}
		public string MobileSerial
		{
			get
			{
				return this.m_mobileSerial;
			}
			set
			{
				this.m_mobileSerial = value;
			}
		}
		public string MobileModel
		{
			get
			{
				return this.m_mobileModel;
			}
			set
			{
				this.m_mobileModel = value;
			}
		}
		public string Size
		{
			get
			{
				return this.m_size;
			}
			set
			{
				this.m_size = value;
			}
		}
		public string Resolution
		{
			get
			{
				return this.m_resolution;
			}
			set
			{
				this.m_resolution = value;
			}
		}
		public string Screen
		{
			get
			{
				return this.m_screen;
			}
			set
			{
				this.m_screen = value;
			}
		}
		public string OperatingSystem
		{
			get
			{
				return this.m_operatingSystem;
			}
			set
			{
				this.m_operatingSystem = value;
			}
		}
		public byte IsHorizontal
		{
			get
			{
				return this.m_isHorizontal;
			}
			set
			{
				this.m_isHorizontal = value;
			}
		}
		public string Remark
		{
			get
			{
				return this.m_remark;
			}
			set
			{
				this.m_remark = value;
			}
		}
		public MobileInfo()
		{
			this.m_mobileID = 0;
			this.m_mobileType = "";
			this.m_mobileSerial = "";
			this.m_mobileModel = "";
			this.m_size = "";
			this.m_resolution = "";
			this.m_screen = "";
			this.m_operatingSystem = "";
			this.m_isHorizontal = 0;
			this.m_remark = "";
		}
	}
}
