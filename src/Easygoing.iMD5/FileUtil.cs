using System;
using System.Security;
using System.Security.Cryptography;

namespace Easygoing.iMD5
{
	public class FileUtil
	{
		public FileUtil ()
		{
		}

		public static string GetMD5(string filename)
		{
			System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();
			byte[] datSource = System.IO.File.ReadAllBytes (filename);
			byte[] newSource = md5.ComputeHash(datSource);
			string byte2String = null;
			for (int i = 0; i < newSource.Length; i++)
			{
				string thisByte = newSource[i].ToString("x");
				if (thisByte.Length == 1) thisByte ="0"+ thisByte;
				byte2String += thisByte;
			}
			return byte2String.ToUpper();
		}

		public static bool GenerateFileMD5Hash(string filename, string md5)
		{
			bool success = false;
			if (!string.IsNullOrEmpty(filename) &&
				System.IO.File.Exists (filename)) {

				if (string.IsNullOrEmpty (md5) || md5.Length != 32) {

					md5 = GetMD5 (filename);
				}

				string destFilename = filename + ".md5";
				try {
					if (System.IO.File.Exists (destFilename)) {
						System.IO.File.Delete (destFilename);
					}
					System.IO.File.WriteAllText (destFilename, md5, System.Text.Encoding.UTF8);
					success = true;
				} catch (Exception ex) {
					Console.WriteLine (ex);
				}

			}
			return success;

		}
	}
}

