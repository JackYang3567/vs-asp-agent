using System;
using System.Collections.Generic;
using System.Data;
namespace Game.Facade.Aide
{
	public class Protection
	{
		private string path;
		public Protection(string path)
		{
			this.path = path;
		}
		public System.Collections.Generic.List<string> GetProtectionQuestions()
		{
			System.Collections.Generic.List<string> list = new System.Collections.Generic.List<string>();
			DataSet dataSet = new DataSet();
			dataSet.ReadXml(this.path);
			DataRow[] array = dataSet.Tables["Item"].Select("Questions_ID=0");
			DataRow[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				DataRow dataRow = array2[i];
				list.Add(dataRow[0].ToString());
			}
			return list;
		}
	}
}
