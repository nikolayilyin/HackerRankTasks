using System;
using System.Collections.Generic;

namespace Tasks
{
    public static class Extensions
    {
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
    }
}