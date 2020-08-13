using System;
using System.IO;
using UI.Models;
using context = System.Web.HttpContext;
namespace UI.ErrorLog
{
    public static class ErrorLogging
    {
        /// <summary>
        /// Error log file path
        /// </summary>
        private static string ErrorLogFilePath { get; set; }

        /// <summary>
        /// Logs the error.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <param name="controller">The controller.</param>
        /// <param name="action">The action.</param>
        public static void LogError(ExceptionLogger exceptionLogger)
        {

            string message = string.Empty;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", exceptionLogger.ExceptionMessage);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", exceptionLogger.ExceptionStackTrace);
            message += Environment.NewLine;
            message += string.Format("DateTime: {0}", exceptionLogger.LogTime);
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = context.Current.Server.MapPath("~/ErrorLog/ErrorLog.txt");
            SetErrorFilePath(path);
            using (StreamWriter writer = new StreamWriter(ErrorLogFilePath, true))
            {
                writer.WriteLine(message);
                writer.Close();
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="basePath"></param>
        public static void SetErrorFilePath(string basePath)
        {
            try
            {
                string dateTime = DateTime.Now.ToString("dd-MMM-yyyy");
                basePath = Path.Combine(basePath, "ErrorLog");
                if (!Directory.Exists(basePath))
                    Directory.CreateDirectory(basePath);
                ErrorLogFilePath = Path.Combine(basePath, "ErrorLog-" + dateTime + ".txt");
                if (!File.Exists(ErrorLogFilePath))
                {
                    var fs = File.Create(ErrorLogFilePath);
                    fs.Close();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



    }
}