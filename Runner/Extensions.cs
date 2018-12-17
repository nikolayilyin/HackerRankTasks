using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Tasks;

namespace Runner
{
	public static class Extensions
	{
		private static Stopwatch sw = null;

		/// <summary>
		/// WriteLine to Console
		/// with total memory usage, thread id, time and method name
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public static void Wl(this string msg, [CallerMemberName] string methodname = "")
		{
			double totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
			DateTime now = DateTime.Now;
			string time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
			int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
			Console.WriteLine(string.Format("{0,-10:F2} mb. {1,4} {2} {3} {4}", totalmem, threadId, time, methodname, msg));
		}

		/// <summary>
		/// Write array to Console
		/// with total memory usage, and method name
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public static void Wl<T>(this T[] array, [CallerMemberName] string methodname = "", int minwidth = 1, bool useComma = true)
		{
			double totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);

			StringBuilder sb = new StringBuilder();
			foreach (T item in array)
			{
				sb.Append(string.Format("{0," + minwidth + "}", item.ToString()));
				if (useComma) {
					sb.Append(", ");
				}
				else {
					sb.Append(" ");
				}
			}
			if (useComma) {
				sb.Remove(sb.Length - 2, 2);
			}
			else {
				sb.Remove(sb.Length - 1, 1);
			}

			Console.WriteLine(string.Format("{0:F2} mb. {1} {2}", totalmem, methodname, sb.ToString()));
		}

		/// <summary>
		/// WriteLine to Console
		/// with total memory usage, thread id, time and method name
		/// and write elapsed ms from last stopwatch start
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public static long Wl_finish(this string msg, [CallerMemberName] string methodname = "")
		{
			long elapsedms = sw.ElapsedMilliseconds;
			sw.Stop();

			double totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
			DateTime now = DateTime.Now;
			string time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
			int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
			Console.WriteLine(string.Format("{0,-10:F2} mb. {1,4} {2} {3} [{4}] {5}", totalmem, threadId, time, methodname, elapsedms, msg));

			sw = null;
			return elapsedms;
		}

		/// <summary>
		/// start stopwath
		/// </summary>
		public static void Wl_start()
		{
			sw = new Stopwatch();
			sw.Start();
		}

		/// <summary>
		/// WriteLine to Console
		/// with total memory usage, thread id, time and method name
		/// and start stopwatch
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		public static void Wl_start(this string msg, [CallerMemberName] string methodname = "")
		{
			double totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
			DateTime now = DateTime.Now;
			string time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
			int threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
			Console.WriteLine(string.Format("{0,-10:F2} mb. {1,4} {2} {3} [started] {4}", totalmem, threadId, time, methodname, msg));

			sw = new Stopwatch();
			sw.Start();
		}
	}
}