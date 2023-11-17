using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;


namespace App11
{

    public class ActionTrackingFilter : IActionFilter
    {
        private readonly string logFilePath = "action_log.txt";

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var methodName = context.ActionDescriptor.DisplayName;
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logMessage = $"{timestamp} - Executing {methodName}";

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}