using System;
using System.Drawing;
using MonoMac.Foundation;
using MonoMac.AppKit;
using MonoMac.ObjCRuntime;
using System.IO;

namespace Easygoing.iMD5
{
	public class MainClass
	{
		static void Main (string[] args)
		{
			NSApplication.Init ();
			try {

				if (args != null && args.Length > 0 && 
					File.Exists (args [0])) {
					string filename = args [0];
					string md5 = FileUtil.GetMD5 (filename).ToUpper ();
					FileUtil.GenerateFileMD5Hash(filename, md5);
				} else {
					NSApplication.Main (args);
				}
			} catch (Exception ex) {
				Console.WriteLine (ex.ToString ());
				NSApplication.Main (args);
			}

		}
	}
}

