using Game.Utils;
using System;
using System.Text;
using System.Web;
namespace Game.Facade
{
	public class UCHttpModule : System.Web.IHttpModule
	{
		private const int HTTP_ERROR_CODE = 404;
		public void Init(System.Web.HttpApplication context)
		{
			context.Error += new System.EventHandler(this.Application_OnError);
		}
		public void Dispose()
		{
		}
		private void Application_OnError(object sender, System.EventArgs e)
		{
			System.Web.HttpApplication httpApplication = (System.Web.HttpApplication)sender;
			System.Web.HttpContext context = httpApplication.Context;
			System.Exception ex = context.Server.GetLastError();
			if (ex is System.Web.HttpException)
			{
				System.Web.HttpException ex2 = ex as System.Web.HttpException;
				if (ex2.GetHttpCode() == 404)
				{
					string arg_41_0 = httpApplication.Request.PhysicalPath;
					TextLogger.Write(string.Format("文件不存在:{0}", httpApplication.Request.Url.AbsoluteUri));
					return;
				}
			}
			if (ex.InnerException != null)
			{
				ex = ex.InnerException;
			}
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder().AppendFormat("访问路径:{0}", GameRequest.GetRawUrl()).AppendLine().AppendFormat("{0} thrown {1}", ex.Source, ex.GetType().ToString()).AppendLine().Append(ex.Message).Append(ex.StackTrace);
			TextLogger.Write(stringBuilder.ToString());
		}
	}
}
