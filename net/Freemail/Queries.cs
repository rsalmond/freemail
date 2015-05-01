using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Freemail
{
	public class Queries
	{
		private static List<string> FreeDomains { get; set; }
		private static List<string> DisposableDomains { get; set; }
		
		static Queries()
		{
			var freePath = Environment.CurrentDirectory + "\\data\\free.txt";
			var freeContents = File.ReadAllText(freePath);
			FreeDomains = Regex.Split(freeContents, "\r\n").ToList();
			
			var disposablePath = Environment.CurrentDirectory + "\\data\\disposable.txt";
			var disposableContents = File.ReadAllText(disposablePath);
			DisposableDomains = Regex.Split(disposableContents, "\r\n").ToList();
			FreeDomains.AddRange(DisposableDomains);
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
