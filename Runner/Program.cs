using System;
using System.Diagnostics;
using Tasks;

namespace Runner {
	internal class Program {
		private static void Main(string[] args) {
			"started".Wl();

			try {
				RemoveSymbolsToGetAlphabeticalOrder.Run();
			}
			catch (Exception ex) {
				"Exception catched.".Wl();
				"{0}".Wl(ex.ToStr());
			}
			finally {
				"finished. press any key.".Wl();
				Console.ReadKey();
			}
		}
	}
}
