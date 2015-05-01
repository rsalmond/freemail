using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Web.Configuration;

namespace Freemail
{
	public class Queries
	{
		private static List<string> FreeDomains { get; set; }
		private static List<string> DisposableDomains { get; set; }
		
		static Queries()
		{
			var baseDirectory = AssemblyDirectory();

			var freePath = baseDirectory + "\\free.txt";
			var freeContents = File.ReadAllText(freePath);
			FreeDomains = Regex.Split(freeContents, "\r\n").ToList();

			var disposablePath = baseDirectory + "\\disposable.txt";
			var disposableContents = File.ReadAllText(disposablePath);
			DisposableDomains = Regex.Split(disposableContents, "\r\n").ToList();
			FreeDomains.AddRange(DisposableDomains);
		}

		static public string AssemblyDirectory()
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			var uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			return Path.GetDirectoryName(path);
		}

		public static bool IsFree(string email)
		{
			var domain = email.Split('@').LastOrDefault();
			return FreeDomains.Contains(domain);
		}

		public static bool IsDisposable(string email)
		{
			var domain = email.Split('@').LastOrDefault();
			return DisposableDomains.Contains(domain);
		}
	}
}
