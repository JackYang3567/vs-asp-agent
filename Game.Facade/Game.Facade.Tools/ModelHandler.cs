using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
namespace Game.Facade.Tools
{
	public class ModelHandler<T> where T : new()
	{
		public System.Collections.Generic.List<T> FillModel(DataSet ds)
		{
			if (ds == null || ds.Tables[0] == null || ds.Tables[0].Rows.Count == 0)
			{
				return null;
			}
			return this.FillModel(ds.Tables[0]);
		}
		public System.Collections.Generic.List<T> FillModel(DataSet ds, int index)
		{
			if (ds == null || ds.Tables.Count <= index || ds.Tables[index].Rows.Count == 0)
			{
				return null;
			}
			return this.FillModel(ds.Tables[index]);
		}
		public System.Collections.Generic.List<T> FillModel(DataTable dt)
		{
			if (dt == null || dt.Rows.Count == 0)
			{
				return null;
			}
			System.Collections.Generic.List<T> list = new System.Collections.Generic.List<T>();
			foreach (DataRow dataRow in dt.Rows)
			{
				T t = (default(T) == null) ? System.Activator.CreateInstance<T>() : default(T);
				for (int i = 0; i < dataRow.Table.Columns.Count; i++)
				{
					System.Reflection.PropertyInfo property = t.GetType().GetProperty(dataRow.Table.Columns[i].ColumnName);
					if (property != null && dataRow[i] != System.DBNull.Value)
					{
						property.SetValue(t, dataRow[i], null);
					}
				}
				list.Add(t);
			}
			return list;
		}
		public T FillModel(DataRow dr)
		{
			if (dr == null)
			{
				return default(T);
			}
			T t = (default(T) == null) ? System.Activator.CreateInstance<T>() : default(T);
			for (int i = 0; i < dr.Table.Columns.Count; i++)
			{
				System.Reflection.PropertyInfo property = t.GetType().GetProperty(dr.Table.Columns[i].ColumnName);
				if (property != null && dr[i] != System.DBNull.Value)
				{
					property.SetValue(t, dr[i], null);
				}
			}
			return t;
		}
		public DataSet FillDataSet(System.Collections.Generic.List<T> modelList)
		{
			if (modelList == null || modelList.Count == 0)
			{
				return null;
			}
			return new DataSet
			{
				Tables = 
				{
					this.FillDataTable(modelList)
				}
			};
		}
		public DataTable FillDataTable(System.Collections.Generic.List<T> modelList)
		{
			if (modelList == null || modelList.Count == 0)
			{
				return null;
			}
			DataTable dataTable = this.CreateData(modelList[0]);
			foreach (T current in modelList)
			{
				DataRow dataRow = dataTable.NewRow();
				System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
				for (int i = 0; i < properties.Length; i++)
				{
					System.Reflection.PropertyInfo propertyInfo = properties[i];
					dataRow[propertyInfo.Name] = propertyInfo.GetValue(current, null);
				}
				dataTable.Rows.Add(dataRow);
			}
			return dataTable;
		}
		private DataTable CreateData(T model)
		{
			DataTable dataTable = new DataTable(typeof(T).Name);
			System.Reflection.PropertyInfo[] properties = typeof(T).GetProperties();
			for (int i = 0; i < properties.Length; i++)
			{
				System.Reflection.PropertyInfo propertyInfo = properties[i];
				dataTable.Columns.Add(new DataColumn(propertyInfo.Name, propertyInfo.PropertyType));
			}
			return dataTable;
		}
	}
}
