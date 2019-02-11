using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Web;
using System.Web.SessionState;
namespace Agent.ashx
{
    public class verify_code : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
        public void ProcessRequest(HttpContext context)
        {
            int num = 80;
            int num2 = 22;
            int num3 = 16;
            string text = string.Empty;
            Color[] array = new Color[]
			{
				Color.Black,
				Color.Red,
				Color.Blue,
				Color.Green,
				Color.Orange,
				Color.Brown,
				Color.Brown,
				Color.DarkBlue
			};
            string[] array2 = new string[]
			{
				"Times New Roman",
				"Verdana",
				"Arial",
				"Gungsuh",
				"Impact"
			};
            char[] array3 = new char[]
			{
				'1',
				'2',
				'3',
				'4',
				'5',
				'6',
				'7',
				'8',
				'9',
				'0'
			};
            System.Random random = new System.Random();
            for (int i = 0; i < 4; i++)
            {
                text += array3[random.Next(array3.Length)];
            }
            context.Session["CheckCode"] = text;
            Bitmap bitmap = new Bitmap(num, num2);
            Graphics graphics = Graphics.FromImage(bitmap);
            graphics.Clear(Color.White);
            for (int j = 0; j < 1; j++)
            {
                int x = random.Next(num);
                int y = random.Next(num2);
                int x2 = random.Next(num);
                int y2 = random.Next(num2);
                Color color = array[random.Next(array.Length)];
                graphics.DrawLine(new Pen(color), x, y, x2, y2);
            }
            for (int k = 0; k < text.Length; k++)
            {
                string familyName = array2[random.Next(array2.Length)];
                Font font = new Font(familyName, (float)num3);
                Color color2 = array[random.Next(array.Length)];
                graphics.DrawString(text[k].ToString(), font, new SolidBrush(color2), (float)k * 18f + 2f, 0f);
            }
            for (int l = 0; l < 100; l++)
            {
                int x3 = random.Next(bitmap.Width);
                int y3 = random.Next(bitmap.Height);
                Color color3 = array[random.Next(array.Length)];
                bitmap.SetPixel(x3, y3, color3);
            }
            context.Response.Buffer = true;
            context.Response.ExpiresAbsolute = System.DateTime.Now.AddMilliseconds(0.0);
            context.Response.Expires = 0;
            context.Response.CacheControl = "no-cache";
            context.Response.AppendHeader("Pragma", "No-Cache");
            System.IO.MemoryStream memoryStream = new System.IO.MemoryStream();
            try
            {
                bitmap.Save(memoryStream, ImageFormat.Png);
                context.Response.ClearContent();
                context.Response.ContentType = "image/Png";
                context.Response.BinaryWrite(memoryStream.ToArray());
            }
            finally
            {
                bitmap.Dispose();
                graphics.Dispose();
            }
        }
    }
}
