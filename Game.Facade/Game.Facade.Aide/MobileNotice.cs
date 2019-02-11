using System;
namespace Game.Facade.Aide
{
	public class MobileNotice
	{
		private string _title;
		private System.DateTime _date;
		private string _content;
		public string title
		{
			get
			{
				return this._title;
			}
			set
			{
				this._title = value;
			}
		}
		public System.DateTime date
		{
			get
			{
				return this._date;
			}
			set
			{
				this._date = value;
			}
		}
		public string content
		{
			get
			{
				return this._content;
			}
			set
			{
				this._content = value;
			}
		}
		public MobileNotice(string startTitle, System.DateTime startDate, string startContent)
		{
			this._title = startTitle;
			this._date = startDate;
			this._content = startContent;
		}
	}
}
