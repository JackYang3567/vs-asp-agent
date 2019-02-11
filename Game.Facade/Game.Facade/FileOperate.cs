using System;
using System.Collections;
using System.Configuration;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.IO.Compression;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml;
namespace Game.Facade
{
	public class FileOperate
	{
		private string sException;
		public static void ExportDataGrid(string FileType, string FileName, System.Web.UI.WebControls.DataGrid DG)
		{
			System.Web.HttpContext.Current.Response.Charset = "GB2312";
			System.Web.HttpContext.Current.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			System.Web.HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + System.Web.HttpUtility.UrlEncode(FileName, System.Text.Encoding.UTF8).ToString());
			System.Web.HttpContext.Current.Response.ContentType = FileType;
			System.Web.UI.Page page = new System.Web.UI.Page();
			page.EnableViewState = false;
			System.IO.StringWriter stringWriter = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter writer = new System.Web.UI.HtmlTextWriter(stringWriter);
			DG.RenderControl(writer);
			System.Web.HttpContext.Current.Response.Write(stringWriter.ToString());
			System.Web.HttpContext.Current.Response.End();
		}
		public static void FolderCreate(string filepath)
		{
			if (!System.IO.Directory.Exists(filepath))
			{
				System.IO.Directory.CreateDirectory(filepath);
			}
		}
		public static void FolderDelete(string filepath)
		{
			if (System.IO.Directory.Exists(filepath))
			{
				System.IO.Directory.Delete(filepath);
			}
		}
		private static System.Collections.Hashtable getAllFies(string filesdirectorypath, out int dirnamelength)
		{
			System.Collections.Hashtable hashtable = new System.Collections.Hashtable();
			System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(filesdirectorypath);
			if (!directoryInfo.Exists)
			{
				throw new System.IO.FileNotFoundException("目录:" + directoryInfo.FullName + "没有找到!");
			}
			dirnamelength = directoryInfo.Name.Length;
			FileOperate.getAllDirFiles(directoryInfo, hashtable);
			FileOperate.getAllDirsFiles(directoryInfo.GetDirectories(), hashtable);
			return hashtable;
		}
		private static void getAllDirsFiles(System.IO.DirectoryInfo[] dirs, System.Collections.Hashtable filesList)
		{
			for (int i = 0; i < dirs.Length; i++)
			{
				System.IO.DirectoryInfo directoryInfo = dirs[i];
				System.IO.FileInfo[] files = directoryInfo.GetFiles("*.*");
				for (int j = 0; j < files.Length; j++)
				{
					System.IO.FileInfo fileInfo = files[j];
					filesList.Add(fileInfo.FullName, fileInfo.LastWriteTime);
				}
				FileOperate.getAllDirsFiles(directoryInfo.GetDirectories(), filesList);
			}
		}
		private static void getAllDirFiles(System.IO.DirectoryInfo dir, System.Collections.Hashtable filesList)
		{
			System.IO.FileInfo[] files = dir.GetFiles("*.*");
			for (int i = 0; i < files.Length; i++)
			{
				System.IO.FileInfo fileInfo = files[i];
				filesList.Add(fileInfo.FullName, fileInfo.LastWriteTime);
			}
		}
		public static string GetFileNames(string path)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(path));
			System.IO.FileInfo[] files = directoryInfo.GetFiles();
			System.IO.FileInfo[] array = files;
			for (int i = 0; i < array.Length; i++)
			{
				System.IO.FileInfo fileInfo = array[i];
				stringBuilder.Append(fileInfo.Name + "|");
			}
			System.IO.DirectoryInfo[] directories = directoryInfo.GetDirectories();
			System.IO.DirectoryInfo[] array2 = directories;
			for (int j = 0; j < array2.Length; j++)
			{
				System.IO.DirectoryInfo directoryInfo2 = array2[j];
				System.IO.FileInfo[] files2 = directoryInfo2.GetFiles();
				System.IO.FileInfo[] array3 = files2;
				for (int k = 0; k < array3.Length; k++)
				{
					System.IO.FileInfo fileInfo2 = array3[k];
					stringBuilder.Append(fileInfo2.Name + "|");
				}
			}
			return stringBuilder.ToString();
		}
		public static string ReadHtmlFile(string temp)
		{
			System.IO.StreamReader streamReader = null;
			string result = "";
			try
			{
				streamReader = new System.IO.StreamReader(temp);
				result = streamReader.ReadToEnd();
			}
			catch (System.Exception ex)
			{
				throw new System.Exception(ex.Message);
			}
			finally
			{
				streamReader.Dispose();
				streamReader.Close();
			}
			return result;
		}
		public static bool WriteHtmlFile(string str, string htmlfilename)
		{
			System.IO.StreamWriter streamWriter = null;
			try
			{
				streamWriter = new System.IO.StreamWriter(htmlfilename, false, System.Text.Encoding.UTF8);
				streamWriter.Write(str);
				streamWriter.Flush();
			}
			catch (System.Exception ex)
			{
				throw new System.Exception(ex.Message);
			}
			finally
			{
				streamWriter.Dispose();
				streamWriter.Close();
			}
			return true;
		}
		public static string GetXmlValue(string Target, string attributes, string xmlPath)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlNode documentElement = xmlDocument.DocumentElement;
			XmlNode xmlNode = documentElement.SelectSingleNode(Target);
			if (xmlNode != null)
			{
				return xmlNode.Attributes[attributes].Value;
			}
			return string.Empty;
		}
		public static void SetXmlValue(string Target, string attributes, string TargetValue, string xmlPath)
		{
			FileOperate.SetXmlTargetValue(Target, attributes, TargetValue, xmlPath);
		}
		private static void SetXmlTargetValue(string Target, string attributes, string TargetValue, string xmlPath)
		{
			XmlDocument xmlDocument = new XmlDocument();
			xmlDocument.Load(xmlPath);
			XmlElement documentElement = xmlDocument.DocumentElement;
			XmlNode xmlNode = documentElement.SelectSingleNode(Target);
			if (xmlNode != null)
			{
				XmlElement xmlElement = (XmlElement)xmlNode;
				xmlElement.SetAttribute(attributes, TargetValue);
			}
			else
			{
				xmlNode = xmlDocument.CreateElement(Target);
				documentElement.AppendChild(xmlNode);
				xmlNode.InnerText = TargetValue;
			}
			xmlDocument.Save(xmlPath);
		}
		public string GetText(string str)
		{
			return Regex.Replace(str, "src[^>]*[^/].(?:jpg|bmp|gif|png|jpeg|JPG|BMP|GIF|JPEG)(?:\\\"|\\')", new MatchEvaluator(this.SaveYuanFile));
		}
		protected string OverrideFileName(string filePath, string fileName)
		{
			string result = fileName;
			if (System.IO.File.Exists(filePath + fileName))
			{
				string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(fileName);
				string extension = System.IO.Path.GetExtension(fileName);
				string text = string.Empty;
				int num = 1;
				while (true)
				{
					text = string.Concat(new string[]
					{
						fileNameWithoutExtension,
						"(",
						num.ToString(),
						")",
						extension
					});
					if (!System.IO.File.Exists(filePath + text))
					{
						break;
					}
					num++;
				}
				result = text;
			}
			return result;
		}
		public static string GetFileName()
		{
			System.Threading.Thread.Sleep(1000);
			string text = System.DateTime.Now.Year.ToString() + "-";
			if (System.DateTime.Now.Month.ToString().Length < 2)
			{
				text = text + "0" + System.DateTime.Now.Month.ToString() + "-";
			}
			else
			{
				text = text + System.DateTime.Now.Month.ToString() + "-";
			}
			if (System.DateTime.Now.Day.ToString().Length < 2)
			{
				text = text + "0" + System.DateTime.Now.Day.ToString() + "-";
			}
			else
			{
				text = text + System.DateTime.Now.Day.ToString() + "-";
			}
			if (System.DateTime.Now.Hour.ToString().Length < 2)
			{
				text = text + "0" + System.DateTime.Now.Hour.ToString() + "-";
			}
			else
			{
				text = text + System.DateTime.Now.Hour.ToString() + "-";
			}
			if (System.DateTime.Now.Minute.ToString().Length < 2)
			{
				text = text + "0" + System.DateTime.Now.Minute.ToString() + "-";
			}
			else
			{
				text = text + System.DateTime.Now.Minute.ToString() + "-";
			}
			if (System.DateTime.Now.Second.ToString().Length < 2)
			{
				text = text + "0" + System.DateTime.Now.Second.ToString();
			}
			else
			{
				text += System.DateTime.Now.Second.ToString();
			}
			return text;
		}
		public static string UpLoadFile(System.Web.UI.WebControls.FileUpload fileupload, string Folders)
		{
			string fileName = fileupload.PostedFile.FileName;
			if (fileName == null || fileName.Equals(""))
			{
				return "";
			}
			string str = fileName.Substring(fileName.LastIndexOf("."));
			string fileName2 = FileOperate.GetFileName();
			string text = Folders + fileName2 + str;
			string text2 = System.Web.HttpContext.Current.Server.MapPath(text);
			if (System.IO.File.Exists(text2))
			{
				System.IO.File.Delete(text2);
			}
			fileupload.PostedFile.SaveAs(text2);
			return text;
		}
		private bool GetHttpFile(string sUrl, string sSavePath)
		{
			bool result = false;
			WebResponse webResponse = null;
			WebRequest webRequest = WebRequest.Create(sUrl);
			webRequest.Timeout = 100000;
			try
			{
				webResponse = webRequest.GetResponse();
			}
			catch (WebException ex)
			{
				this.sException = ex.Message.ToString();
			}
			catch (System.Exception ex2)
			{
				this.sException = ex2.ToString();
			}
			finally
			{
				if (webResponse != null)
				{
					System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(webResponse.GetResponseStream(), System.Text.Encoding.GetEncoding("GB2312"));
					int num = System.Convert.ToInt32(webResponse.ContentLength);
					try
					{
						System.IO.FileStream fileStream;
						if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath("RecievedData.tmp")))
						{
							fileStream = System.IO.File.OpenWrite(sSavePath);
						}
						else
						{
							fileStream = System.IO.File.Create(sSavePath);
						}
						fileStream.SetLength((long)num);
						fileStream.Write(binaryReader.ReadBytes(num), 0, num);
						fileStream.Close();
					}
					catch (System.Exception)
					{
					}
					finally
					{
						binaryReader.Close();
						webResponse.Close();
					}
					result = true;
				}
			}
			return result;
		}
		private string SaveYuanFile(Match m)
		{
			string text = m.Value;
			string text2 = text.Substring(5);
			text2 = text2.Substring(0, text2.IndexOf("\""));
			Regex regex = new Regex("^http://*");
			string result;
			if (regex.Match(text2).Success)
			{
				text = text.Substring(5);
				text = text.Substring(0, text.IndexOf("\""));
				string str = ConfigurationManager.AppSettings["yuanimg"].ToString();
				string text3 = text;
				string str2 = text3.Substring(text3.LastIndexOf("."));
				string fileName = FileOperate.GetFileName();
				string text4 = str + fileName + str2;
				if (System.IO.File.Exists(System.Web.HttpContext.Current.Request.MapPath(text4)))
				{
					System.IO.File.Delete(System.Web.HttpContext.Current.Request.MapPath(text4));
				}
				this.GetHttpFile(text, System.Web.HttpContext.Current.Request.MapPath(text4));
				result = "src=\"/" + text4.Replace("~/", "") + "\"";
			}
			else
			{
				result = text;
			}
			return result;
		}
		public static bool MoveFiles(string oldpath, string newpath)
		{
			System.IO.DirectoryInfo directoryInfo = new System.IO.DirectoryInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
			System.IO.FileInfo[] files = directoryInfo.GetFiles();
			bool result;
			try
			{
				System.IO.FileInfo[] array = files;
				for (int i = 0; i < array.Length; i++)
				{
					System.IO.FileInfo fileInfo = array[i];
					fileInfo.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath + fileInfo.Name));
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static bool MoveFile(string oldpath, string newpath)
		{
			bool result;
			try
			{
				System.IO.FileInfo fileInfo = new System.IO.FileInfo(System.Web.HttpContext.Current.Server.MapPath(oldpath));
				fileInfo.MoveTo(System.Web.HttpContext.Current.Server.MapPath(newpath));
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}
		public static void DeleteFile(string path)
		{
			if (System.IO.File.Exists(path))
			{
				System.IO.File.Delete(path);
			}
		}
		[System.Runtime.InteropServices.DllImport("kernel32")]
		private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
		[System.Runtime.InteropServices.DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string defVal, System.Text.StringBuilder retVal, int size, string filePath);
		[System.Runtime.InteropServices.DllImport("kernel32")]
		private static extern int GetPrivateProfileString(string section, string key, string defVal, byte[] retVal, int size, string filePath);
		public static void IniWriteValue(string section, string key, string iValue, string path)
		{
			FileOperate.WritePrivateProfileString(section, key, iValue, path);
		}
		public static string IniReadValue(string section, string key, string path)
		{
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder(255);
			FileOperate.GetPrivateProfileString(section, key, "", stringBuilder, 255, path);
			return stringBuilder.ToString();
		}
		public static byte[] IniReadValues(string section, string key, string path)
		{
			byte[] array = new byte[255];
			FileOperate.GetPrivateProfileString(section, key, "", array, 255, path);
			return array;
		}
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int GetPrivateProfileSectionNamesA(byte[] buffer, int iLen, string fileName);
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int GetPrivateProfileStringA(string segName, string keyName, string sDefault, byte[] buffer, int iLen, string fileName);
		public static System.Collections.ArrayList ReadSections(string path)
		{
			byte[] array = new byte[65535];
			int privateProfileSectionNamesA = FileOperate.GetPrivateProfileSectionNamesA(array, array.GetUpperBound(0), path);
			System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
			if (privateProfileSectionNamesA > 0)
			{
				int num = 0;
				for (int i = 0; i < privateProfileSectionNamesA; i++)
				{
					if (array[i] == 0)
					{
						string text = System.Text.Encoding.Default.GetString(array, num, i - num).Trim();
						num = i + 1;
						if (text != "")
						{
							arrayList.Add(text);
						}
					}
				}
			}
			return arrayList;
		}
		public static System.Collections.ArrayList ReadKeys(string sectionName, string path)
		{
			byte[] array = new byte[5120];
			int privateProfileStringA = FileOperate.GetPrivateProfileStringA(sectionName, null, "", array, array.GetUpperBound(0), path);
			System.Collections.ArrayList arrayList = new System.Collections.ArrayList();
			if (privateProfileStringA > 0)
			{
				int num = 0;
				for (int i = 0; i < privateProfileStringA; i++)
				{
					if (array[i] == 0)
					{
						string text = System.Text.Encoding.Default.GetString(array, num, i - num).Trim();
						num = i + 1;
						if (text != "")
						{
							arrayList.Add(text);
						}
					}
				}
			}
			return arrayList;
		}
		public static void MakeThumbnail(string originalImagePath, string thumbnailPath, int width, int height)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(originalImagePath);
			int num = width;
			int num2 = height;
			int x = 0;
			int y = 0;
			int num3 = image.Width;
			int num4 = image.Height;
			string text = "Auto";
			string a;
			if ((a = text) != null && !(a == "HW"))
			{
				if (!(a == "W"))
				{
					if (!(a == "H"))
					{
						if (!(a == "Cut"))
						{
							if (a == "Auto")
							{
								if ((double)image.Width / (double)image.Height > 1.0)
								{
									num2 = image.Height * width / image.Width;
								}
								else
								{
									num = image.Width * height / image.Height;
								}
							}
						}
						else
						{
							if ((double)image.Width / (double)image.Height > (double)num / (double)num2)
							{
								num4 = image.Height;
								num3 = image.Height * num / num2;
								y = 0;
								x = (image.Width - num3) / 2;
							}
							else
							{
								num3 = image.Width;
								num4 = image.Width * height / num;
								x = 0;
								y = (image.Height - num4) / 2;
							}
						}
					}
					else
					{
						num = image.Width * height / image.Height;
					}
				}
				else
				{
					num2 = image.Height * width / image.Width;
				}
			}
			System.Drawing.Image image2 = new Bitmap(num, num2);
			Graphics graphics = Graphics.FromImage(image2);
			graphics.InterpolationMode = InterpolationMode.High;
			graphics.SmoothingMode = SmoothingMode.HighQuality;
			graphics.Clear(Color.Transparent);
			graphics.DrawImage(image, new Rectangle(0, 0, num, num2), new Rectangle(x, y, num3, num4), GraphicsUnit.Pixel);
			try
			{
				image2.Save(thumbnailPath, ImageFormat.Jpeg);
			}
			catch (System.Exception ex)
			{
				throw ex;
			}
			finally
			{
				image.Dispose();
				image2.Dispose();
				graphics.Dispose();
			}
		}
		public static void MarkWaterText(string Path, string NewPath, string WaterText, int x, int y, bool isDelOld)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
			try
			{
				Graphics graphics = Graphics.FromImage(image);
				graphics.DrawImage(image, 0, 0, image.Width, image.Height);
				Font font = new Font("System", 12f);
				Brush brush = new SolidBrush(Color.Blue);
				graphics.DrawString(WaterText, font, brush, (float)x, (float)y);
				graphics.Dispose();
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			catch
			{
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			finally
			{
				if (isDelOld)
				{
					System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
				}
			}
		}
		public static void MarkWaterText(string Path, string NewPath, string WaterText, bool isDelOld)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
			try
			{
				Graphics graphics = Graphics.FromImage(image);
				graphics.DrawImage(image, 0, 0, image.Width, image.Height);
				int num;
				if (image.Height > image.Width)
				{
					num = image.Height / 10;
				}
				else
				{
					num = image.Width / 10;
				}
				if (num > 16)
				{
					num = 16;
				}
				Font font = new Font("Arial", (float)num);
				Brush brush = new SolidBrush(Color.Blue);
				int num2 = WaterText.Length * font.Height;
				int num3 = 15;
				int num4 = 15;
				StringFormat stringFormat = new StringFormat();
				stringFormat.FormatFlags = StringFormatFlags.NoWrap;
				graphics.DrawString(WaterText, font, brush, (float)(image.Width - num3 - num2), (float)(image.Height - num4 - font.Height), stringFormat);
				graphics.Dispose();
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			catch
			{
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			finally
			{
				if (isDelOld)
				{
					System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
				}
			}
		}
		public static void MarkWaterImage(string Path, string NewPath, string ImagePath, int x, int y, bool isDelOld)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
			try
			{
				Graphics graphics = Graphics.FromImage(image);
				graphics.DrawImage(image2, new Rectangle(image.Width - image2.Width - x, image.Height - image2.Height - y, image2.Width, image2.Height), new Rectangle(0, 0, image2.Width, image2.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			catch
			{
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			finally
			{
				if (isDelOld)
				{
					System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
				}
			}
		}
		public static void MarkWaterImage(string Path, string NewPath, string ImagePath, bool isDelOld)
		{
			System.Drawing.Image image = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(Path));
			System.Drawing.Image image2 = System.Drawing.Image.FromFile(System.Web.HttpContext.Current.Server.MapPath(ImagePath));
			try
			{
				Graphics graphics = Graphics.FromImage(image);
				int num = 15;
				int num2 = 15;
				graphics.DrawImage(image2, new Rectangle(image.Width - image2.Width - num, image.Height - image2.Height - num2, image2.Width, image2.Height), new Rectangle(0, 0, image2.Width, image2.Height), GraphicsUnit.Pixel);
				graphics.Dispose();
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			catch
			{
				image.Save(System.Web.HttpContext.Current.Server.MapPath(NewPath));
				image.Dispose();
			}
			finally
			{
				if (isDelOld)
				{
					System.IO.File.Delete(System.Web.HttpContext.Current.Server.MapPath(Path));
				}
			}
		}
		public static string GetRemotImage(string Path, string Url)
		{
			string[] array = new string[]
			{
				"image/gif",
				"image/jpeg",
				"image/bmp",
				"image/png"
			};
			HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(Url.ToLower());
			HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
			string text = httpWebResponse.ContentType.ToString();
			string str = "";
			bool flag = false;
			for (int i = 0; i <= array.Length - 1; i++)
			{
				if (text == array[i].ToString().ToLower())
				{
					string a;
					if ((a = text) != null)
					{
						if (!(a == "image/gif"))
						{
							if (!(a == "image/jpeg"))
							{
								if (!(a == "image/bmp"))
								{
									if (a == "image/png")
									{
										str = "png";
									}
								}
								else
								{
									str = "bmp";
								}
							}
							else
							{
								str = "jpg";
							}
						}
						else
						{
							str = "gif";
						}
					}
					flag = true;
					break;
				}
			}
			if (flag)
			{
				System.Drawing.Image image = System.Drawing.Image.FromStream(httpWebResponse.GetResponseStream());
				string text2 = string.Empty;
				string text3 = System.DateTime.Now.Year.ToString();
				string text4 = System.DateTime.Now.Month.ToString();
				string text5 = System.DateTime.Now.Day.ToString();
				string text6 = System.DateTime.Now.Hour.ToString();
				string text7 = System.DateTime.Now.Minute.ToString();
				string text8 = System.DateTime.Now.Second.ToString();
				text2 = string.Concat(new string[]
				{
					text3,
					text4,
					text5,
					text6,
					text7,
					text8
				});
				System.Random random = new System.Random();
				text2 += random.Next(1000);
				text2 = text2 + "." + str;
				string text9 = Path + text2;
				image.Save(System.Web.HttpContext.Current.Server.MapPath(text9));
				httpWebResponse.Close();
				return text9;
			}
			httpWebResponse.Close();
			return "";
		}
		private static string GetChartset(string url)
		{
			string hTML = FileOperate.getHTML(url);
			Regex regex = new Regex("charset\\b\\s*=\\s*(?<charset>[^\"]*)");
			string text;
			if (regex.IsMatch(hTML))
			{
				text = regex.Match(hTML).Groups["charset"].Value;
			}
			else
			{
				text = System.Text.Encoding.Default.EncodingName;
			}
			if (text.ToLower().Contains("gb2312"))
			{
				text = "gb2312";
			}
			if (text.ToLower().Contains("utf-8"))
			{
				text = "utf-8";
			}
			return text;
		}
		private static string getHTML(string url)
		{
			string result;
			try
			{
				WebRequest webRequest = WebRequest.Create(url);
				WebResponse response = webRequest.GetResponse();
				System.IO.Stream responseStream = response.GetResponseStream();
				System.IO.StreamReader streamReader = new System.IO.StreamReader(responseStream, System.Text.Encoding.GetEncoding(System.Text.Encoding.ASCII.EncodingName));
				string text = streamReader.ReadToEnd();
				result = text;
			}
			catch (UriFormatException ex)
			{
				System.Console.WriteLine(ex.Message);
				result = null;
			}
			catch (WebException ex2)
			{
				System.Console.WriteLine(ex2.Message);
				result = null;
			}
			return result;
		}
		public static string GetRemotUrl(string url, int Type)
		{
			string text = url.Trim();
			string result = string.Empty;
			string text2 = string.Empty;
			try
			{
				HttpWebRequest httpWebRequest = (HttpWebRequest)WebRequest.Create(text);
				HttpWebResponse httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse();
				string contentEncoding = httpWebResponse.ContentEncoding;
				System.IO.Stream responseStream = httpWebResponse.GetResponseStream();
				System.Text.Encoding encoding = System.Text.Encoding.GetEncoding(FileOperate.GetChartset(text));
				if (contentEncoding.ToLower() == "gzip")
				{
					GZipStream stream = new GZipStream(responseStream, CompressionMode.Decompress);
					using (System.IO.StreamReader streamReader = new System.IO.StreamReader(stream, encoding))
					{
						text2 = streamReader.ReadToEnd();
						goto IL_AA;
					}
				}
				using (System.IO.StreamReader streamReader2 = new System.IO.StreamReader(responseStream, encoding))
				{
					text2 = streamReader2.ReadToEnd();
				}
				IL_AA:
				switch (Type)
				{
				case 1:
					result = text2;
					break;
				case 2:
					result = FileOperate.wipeScript(text2);
					break;
				case 3:
					result = FileOperate.ClearHTML(text2);
					break;
				case 4:
					result = FileOperate.getImages(text, text2);
					break;
				case 5:
					result = FileOperate.getLink(text, text2);
					break;
				}
			}
			catch
			{
				result = "Error";
			}
			return result;
		}
		public static string getImages(string Url, string html)
		{
			string text = "";
			string text2 = "";
			string str = "";
			Regex regex = new Regex("<IMG[^>]+src=\\s*(?:'(?<src>[^']+)'|\"(?<src>[^\"]+)\"|(?<src>[^>\\s]+))\\s*[^>]*>", RegexOptions.IgnoreCase);
			Match match = regex.Match(html);
			while (match.Success)
			{
				text2 = match.Groups["src"].Value.ToLower();
				if (text2.IndexOf("http") == 0)
				{
					text = text + match.Value + "<br />";
				}
				else
				{
					string[] array = Url.Trim().Split(new char[]
					{
						'/'
					});
					try
					{
						if (array.Length > 3)
						{
							str = Url.Trim().Replace(array[array.Length - 1], "");
						}
						else
						{
							str = Url.Trim();
						}
					}
					catch
					{
						str = Url.Trim();
					}
					if (text2.IndexOf("/") == 0)
					{
						text = text + match.Value.Replace(match.Groups["src"].Value, "http://" + array[2] + match.Groups["src"].Value) + "<br/>";
					}
					else
					{
						text = text + match.Value.Replace(match.Groups["src"].Value, str + match.Groups["src"].Value) + "<br/>";
					}
				}
				match = match.NextMatch();
			}
			return text;
		}
		public static string ClearHTML(string Htmlstring)
		{
			Htmlstring = Regex.Replace(Htmlstring, "<script[^>]*?>.*?</script>", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "<style[\\s\\S]+</style *>", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "<(.[^>]*)>", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "([\\r\\n])[\\s]+", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "-->", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "<!--.*", "", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(quot|#34);", "\"", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(amp|#38);", "&", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(lt|#60);", "<", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(gt|#62);", ">", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(nbsp|#160);", " ", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(iexcl|#161);", "¡", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(cent|#162);", "¢", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(pound|#163);", "£", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&(copy|#169);", "©", RegexOptions.IgnoreCase);
			Htmlstring = Regex.Replace(Htmlstring, "&#(\\d+);", "", RegexOptions.IgnoreCase);
			Htmlstring.Replace("<", "");
			Htmlstring.Replace(">", "");
			Htmlstring.Replace("\r\n", "");
			Htmlstring = System.Web.HttpContext.Current.Server.HtmlEncode(Htmlstring).Trim();
			return Htmlstring;
		}
		public static string wipeScript(string html)
		{
			Regex regex = new Regex("<script[\\s\\S]+</script *>", RegexOptions.IgnoreCase);
			Regex regex2 = new Regex(" href *= *[\\s\\S]*script *:", RegexOptions.IgnoreCase);
			Regex regex3 = new Regex(" on[\\s\\S]*=", RegexOptions.IgnoreCase);
			Regex regex4 = new Regex("<iframe[\\s\\S]+</iframe *>", RegexOptions.IgnoreCase);
			Regex regex5 = new Regex("<frameset[\\s\\S]+</frameset *>", RegexOptions.IgnoreCase);
			html = regex.Replace(html, "");
			html = regex2.Replace(html, "");
			html = regex3.Replace(html, " _disibledevent=");
			html = regex4.Replace(html, "");
			html = regex5.Replace(html, "");
			return html;
		}
		public static string getLink(string Url, string html)
		{
			string text = "";
			string text2 = "";
			string str = "";
			Regex regex = new Regex("<a[^>]+href=\\s*(?:'(?<href>[^']+)'|\"(?<href>[^\"]+)\"|(?<href>[^>\\s]+))\\s*[^>]*>(?<text>.*?)</a>", RegexOptions.IgnoreCase);
			MatchCollection matchCollection = regex.Matches(html);
			foreach (Match match in matchCollection)
			{
				text2 = match.Groups["href"].Value.ToLower();
				if (text2.IndexOf("http") == 0)
				{
					text = text + match.Value + "<br/>";
				}
				else
				{
					string[] array = Url.Trim().Split(new char[]
					{
						'/'
					});
					try
					{
						if (array.Length > 1)
						{
							str = Url.Trim().Replace(array[array.Length - 1], "");
						}
						else
						{
							str = Url.Trim();
						}
					}
					catch
					{
						str = Url.Trim();
					}
					if (text2.IndexOf("/") == 0)
					{
						text = text + match.Value.Replace(match.Groups["href"].Value, "http://" + array[2] + match.Groups["href"].Value) + "<br/>";
					}
					else
					{
						if (text2.IndexOf("mailto") == 0)
						{
							text = text + match.Value + "<br/>";
						}
						else
						{
							text = text + match.Value.Replace(match.Groups["href"].Value, str + match.Groups["href"].Value) + "<br/>";
						}
					}
				}
			}
			return text;
		}
		public static string GetChinaString(string stringToSub, int length)
		{
			Regex regex = new Regex("[一-龥]+", RegexOptions.Compiled);
			char[] array = stringToSub.ToCharArray();
			System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
			int num = 0;
			bool flag = false;
			for (int i = 0; i < array.Length; i++)
			{
				if (regex.IsMatch(array[i].ToString()))
				{
					stringBuilder.Append(array[i]);
					num += 2;
				}
				else
				{
					stringBuilder.Append(array[i]);
					num++;
				}
				if (num > length)
				{
					flag = true;
					break;
				}
			}
			if (flag)
			{
				return stringBuilder.ToString() + "..";
			}
			return stringBuilder.ToString();
		}
		public static string FiltSQL(string str)
		{
			str = str.Replace("select", "");
			str = str.Replace("insert", "");
			str = str.Replace("update", "");
			str = str.Replace("delete", "");
			str = str.Replace("create", "");
			str = str.Replace("drop", "");
			str = str.Replace("delcare", "");
			str = str.Replace("   ", "&nbsp;");
			str = str.Replace("<script>", "");
			str = str.Replace("</script>", "");
			str = str.Trim();
			return str;
		}
		public static bool IsNumeric(string str)
		{
			Regex regex = new Regex("^\\d+(\\.)?\\d*$");
			return regex.IsMatch(str);
		}
		public static bool IsPic(string Ext)
		{
			bool result = false;
			string[] array = new string[]
			{
				".jpg",
				".jpeg",
				".gif",
				".png",
				".bmp"
			};
			string[] array2 = array;
			for (int i = 0; i < array2.Length; i++)
			{
				string text = array2[i];
				if (text.Equals(Ext, System.StringComparison.InvariantCultureIgnoreCase))
				{
					result = true;
					break;
				}
			}
			return result;
		}
		public static void CreateImage(string checkCode)
		{
			int width = checkCode.Length * 11;
			Bitmap bitmap = new Bitmap(width, 19);
			Graphics graphics = Graphics.FromImage(bitmap);
			graphics.Clear(Color.White);
			Color[] array = new Color[]
			{
				Color.Black,
				Color.Red,
				Color.DarkBlue,
				Color.Green,
				Color.Chocolate,
				Color.Brown,
				Color.DarkCyan,
				Color.Purple
			};
			System.Random random = new System.Random();
			for (int i = 0; i < checkCode.Length; i++)
			{
				int num = random.Next(7);
				Font font = new Font("Microsoft Sans Serif", 11f);
				Brush brush = new SolidBrush(array[num]);
				graphics.DrawString(checkCode.Substring(i, 1), font, brush, (float)(i * 10 + 1), 0f, StringFormat.GenericDefault);
			}
			graphics.DrawRectangle(new Pen(Color.Black, 0f), 0, 0, bitmap.Width - 1, bitmap.Height - 1);
			System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
			bitmap.Save(memoryStream, ImageFormat.Jpeg);
			System.Web.HttpContext.Current.Response.ClearContent();
			System.Web.HttpContext.Current.Response.ContentType = "image/Jpeg";
			System.Web.HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
			graphics.Dispose();
			bitmap.Dispose();
		}
		public static string GetValidateCode(int num)
		{
			char[] array = "023456789".ToCharArray();
			System.Random random = new System.Random();
			string text = string.Empty;
			for (int i = 0; i < num; i++)
			{
				char c = array[random.Next(0, array.Length)];
				if (text.IndexOf(c) > -1)
				{
					i--;
				}
				else
				{
					text += c;
				}
			}
			return text;
		}
	}
}
