using System;
using System.Globalization;
using System.IO;
using System.Web;
namespace Game.Facade.Tools
{
	public class LogUtil
	{
		public static void WriteError(string errorMessage)
		{
			try
			{
				string text = System.Web.HttpContext.Current.Server.MapPath("~/Log/Error/");
				if (!System.IO.Directory.Exists(text))
				{
					System.IO.Directory.CreateDirectory(text);
				}
				text = text + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(text))
				{
					System.IO.File.Create(text).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(text))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(errorMessage);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
		public static void WritePostLog(string dicname, string errorMessage)
		{
			try
			{
				string path = string.Concat(new string[]
				{
					"~/Log/",
					dicname,
					"/",
					System.DateTime.Today.ToString("yyMMdd"),
					".txt"
				});
				if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(errorMessage);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
		public static void WriteAPIError(string errorMessage)
		{
			try
			{
				string path = "~/Log/Error/" + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(errorMessage);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
		public static void WriteBengBengReturnData(string data)
		{
			try
			{
				string path = "~/Log/BengBeng/" + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(data);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
		public static void WriteDangDangReturnData(string data)
		{
			try
			{
				string path = "~/Log/DangDang/" + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(data);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
		public static void WriteJuJuReturnData(string data)
		{
			try
			{
				string path = "~/Log/JuJu/" + System.DateTime.Today.ToString("yyMMdd") + ".txt";
				if (!System.IO.File.Exists(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					System.IO.File.Create(System.Web.HttpContext.Current.Server.MapPath(path)).Close();
				}
				using (System.IO.StreamWriter streamWriter = System.IO.File.AppendText(System.Web.HttpContext.Current.Server.MapPath(path)))
				{
					streamWriter.WriteLine("\r\nLog Entry : ");
					streamWriter.WriteLine("{0}", System.DateTime.Now.ToString(System.Globalization.CultureInfo.InvariantCulture));
					streamWriter.WriteLine(data);
					streamWriter.WriteLine("________________________________________________________");
					streamWriter.Flush();
					streamWriter.Close();
				}
			}
			catch (System.Exception ex)
			{
				LogUtil.WriteError(ex.Message);
			}
		}
	}
}
