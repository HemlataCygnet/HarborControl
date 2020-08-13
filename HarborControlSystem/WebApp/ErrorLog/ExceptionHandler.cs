using System;
using System.Web.Mvc;
using UI.Models;

namespace UI.ErrorLog
{
    public class ExceptionHandler : HandleErrorAttribute 
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled)
            {
                return;
            }
            Exception e = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            ExceptionLogger exceptionLogger = new ExceptionLogger()
            {
                ExceptionStackTrace = e.StackTrace,
                ExceptionMessage = e.Message,
                LogTime = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"))
        };
            ErrorLogging.LogError(exceptionLogger);
            filterContext.Result = new ViewResult()
            {
                ViewName = "Error"
            };
        }

    }
}