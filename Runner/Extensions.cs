﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;

namespace Runner
{
    public static class Extensions
    {
        private static Stopwatch sw = null;

        /// <summary>
        /// String.Format
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        /// <returns></returns>
        public static string F(this string format, params object[] args)
        {
            try
            {
                return string.Format(format, args);
            }
            catch (Exception ex)
            {
                string strargs = " ";
                foreach (var arg in args)
                    try { strargs += arg ?? "null" + "| "; }
                    catch { strargs += " ??| "; }
                return format ?? "[format is null]" + strargs + " format exception! \n" + ex.ToStr();
            }
        }

        /// <summary>
        /// String representation of Exception
        /// </summary>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static string ToStr(this Exception exception)
        {
            if (exception == null)
                return string.Empty;

            var exceptions = new List<Exception>();
            for (var ex = exception; ex != null; ex = ex.InnerException)
                exceptions.Add(ex);

            string message = "";
            for (int i = exceptions.Count - 1; i >= 0; i--)
                message += "[{0}] Message: {1}".F(i, exceptions[i].Message);

            message += "\nStackTrace: {0}".F(exception.StackTrace);
            return message;
        }

        /// <summary>
        /// WriteLine to Console
        /// with total memory usage, thread id, time and method name
        /// </summary>
        /// <param name="format"></param>
        /// <param name="args"></param>
        public static void Wl(this string msg, [CallerMemberName] string methodname = "")
        {
            var totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
            var now = DateTime.Now;
            var time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
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
            var totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);

            var sb = new StringBuilder();
            foreach (var item in array)
            {
                sb.Append(string.Format("{0," + minwidth + "}", item.ToString()));
                if (useComma)
                    sb.Append(", ");
                else
                    sb.Append(" ");
            }
            if (useComma)
                sb.Remove(sb.Length - 2, 2);
            else
                sb.Remove(sb.Length - 1, 1);

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
            var elapsedms = sw.ElapsedMilliseconds;
            sw.Stop();

            var totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
            var now = DateTime.Now;
            var time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
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
            var totalmem = GC.GetTotalMemory(false) / (1024.0 * 1024.0);
            var now = DateTime.Now;
            var time = string.Format("{0,2}:{1,2} {2,2} {3,3}", now.Hour, now.Minute, now.Second, now.Millisecond);
            var threadId = System.Threading.Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(string.Format("{0,-10:F2} mb. {1,4} {2} {3} [started] {4}", totalmem, threadId, time, methodname, msg));

            sw = new Stopwatch();
            sw.Start();
        }
    }
}