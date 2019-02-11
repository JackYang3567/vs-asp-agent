using System;
using System.Text;
namespace Game.Utils
{
	public sealed class CWHEncryptNet
	{
		private static ushort ENCRYPT_KEY_LEN = 8;
		 private static int MAX_ENCRYPT_LEN = CWHEncryptNet.MAX_SOURCE_LEN * CWHEncryptNet.XOR_TIMES;
		private static ushort MAX_SOURCE_LEN = 64;
		private static ushort XOR_TIMES = 8;
		private CWHEncryptNet()
		{
		}
		public static string XorCrevasse(string encrypData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ushort num = (ushort)encrypData.Length;
			if (num < CWHEncryptNet.ENCRYPT_KEY_LEN * 8)
			{
				return "";
			}
			ushort num2 = Convert.ToUInt16(encrypData.Substring(0, 4), 16);
			if (num != (num2 + CWHEncryptNet.ENCRYPT_KEY_LEN - 1) / CWHEncryptNet.ENCRYPT_KEY_LEN * CWHEncryptNet.ENCRYPT_KEY_LEN * 8)
			{
				return "";
			}
			for (int i = 0; i < (int)num2; i++)
			{
				string value = encrypData.Substring(i * 8, 4);
				string value2 = encrypData.Substring(i * 8 + 4, 4);
				ushort num3 = Convert.ToUInt16(value, 16);
				ushort num4 = Convert.ToUInt16(value2, 16);
				stringBuilder.Append((char)(num3 ^ num4));
			}
			return stringBuilder.ToString();
		}
		public static string XorEncrypt(string sourceData)
		{
			StringBuilder stringBuilder = new StringBuilder();
			ushort[] array = new ushort[(int)CWHEncryptNet.ENCRYPT_KEY_LEN];
			array[0] = (ushort)sourceData.Length;
			Random random = new Random();
			for (int i = 1; i < array.Length; i++)
			{
				array[i] = (ushort)(random.Next(0, 65535) % 65535);
			}
			int num = (array[0] + CWHEncryptNet.ENCRYPT_KEY_LEN - 1) / CWHEncryptNet.ENCRYPT_KEY_LEN * CWHEncryptNet.ENCRYPT_KEY_LEN;
			for (ushort num2 = 0; num2 < num; num2 += 1)
			{
				int num3;
				if (num2 < array[0])
				{
					num3 = (ushort)(sourceData[(int)num2] ^ (char)array[(int)(num2 % CWHEncryptNet.ENCRYPT_KEY_LEN)]);
				}
				else
				{
					num3 = (array[(int)(num2 % CWHEncryptNet.ENCRYPT_KEY_LEN)] ^ (ushort)(random.Next(0, 65535) % 65535));
				}
				stringBuilder.Append(array[(int)(num2 % CWHEncryptNet.ENCRYPT_KEY_LEN)].ToString("X4")).Append(num3.ToString("X4"));
			}
			return stringBuilder.ToString();
		}
	}
}
