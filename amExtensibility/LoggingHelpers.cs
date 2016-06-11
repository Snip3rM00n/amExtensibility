using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace amExtensibility
{
    /// <summary>
    /// A collection of helper methods for logging and writing messages to the console.
    /// </summary>
    public static class LoggingHelpers
    {
        /// <summary>
        /// Writes a message to the console.
        /// </summary>
        /// <param name="message">The message to write.</param>
        /// <param name="isError">Whether or not the message is an error (default = false)</param>
        public static void writeMessage(string message, bool isError = false)
        {
            if (isError)
                Console.WriteLine("[{0}] Error:\t{1}", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss.ffff tt"), message);
            else
                Console.WriteLine("[{0}] Message:\t{1}", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss.ffff tt"), message);
        }

        /// <summary>
        /// Logs a message to a log file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="isError">Whether or not the message is an error (default = false)</param>
        /// <param name="logfile">The path to the log file (default = "log_" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt")</param>
        public static void logMessage(string message, bool isError = false, string logfile = null)
        {
            logfile = logfile == null ? @"log_" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt" : logfile;
            if (isError)
                File.AppendAllText(logfile, string.Format("[{0}] Error:\t{1}\r\n", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss.ffff tt"), message));
            else
                File.AppendAllText(logfile, string.Format("[{0}] Message:\t{1}\r\n", DateTime.Now.ToString("MM/dd/yyyy h:mm:ss.ffff tt"), message));
        }

        /// <summary>
        /// Writes a message to the console and logs it to a log file.
        /// </summary>
        /// <param name="message">The message to log.</param>
        /// <param name="isError">Whether or not the message is an error (default = false)</param>
        /// <param name="logfile">The path to the log file (default = "log_" + DateTime.Now.ToString("MM-dd-yyyy") + ".txt")</param>
        public static void writeAndLog(string message, bool isError = false, string logfile = null)
        {
            writeMessage(message, isError);
            logMessage(message, isError, logfile);
        }
    }
}
