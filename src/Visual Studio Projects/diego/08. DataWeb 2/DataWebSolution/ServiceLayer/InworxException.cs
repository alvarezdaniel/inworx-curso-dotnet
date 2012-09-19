using System;
using System.Diagnostics;

namespace ServiceLayer
{
	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	public class InworxException : ApplicationException
	{
		public InworxException(string message, Exception innerException, bool writesInEventLog) : base(message, innerException)
		{
            if (writesInEventLog)
            {
                if (!EventLog.SourceExists("INWORX"))
                {
                    EventLog.CreateEventSource("INWORX", "Application");
                }
                EventLog elog = new EventLog("Application");
                elog.Source = "INWORX";
                if (innerException != null)
                  elog.WriteEntry(message + " - " + innerException.StackTrace);
                else
                    elog.WriteEntry(message);
            }
		}
        public InworxException(string message, Exception innerException) : this(message, innerException, false)
        {
        }
    }
}
