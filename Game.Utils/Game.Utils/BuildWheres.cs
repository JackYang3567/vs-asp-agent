using System;
namespace Game.Utils
{
	public class BuildWheres
	{
		private object obj;
		public BuildWheres()
		{
			this.obj = " where ";
		}
		public void Append(string where)
		{
			if (this.obj.ToString().Trim() != "where")
			{
				this.obj = this.obj + " and " + where;
				return;
			}
			this.obj += where;
		}
		public override string ToString()
		{
			if (this.obj == null || this.obj.ToString().Trim() == "where")
			{
				return "";
			}
			return this.obj.ToString();
		}
	}
}
