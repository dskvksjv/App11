using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace App11
{

    public class UserTrackingFilter : IActionFilter
    {
        private readonly string logFilePath = "user_log.txt";
        private HashSet<string> uniqueUsers = new HashSet<string>();

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var userId = context.HttpContext.User.Identity.Name; 

            if (!string.IsNullOrEmpty(userId))
            {
                uniqueUsers.Add(userId);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var logMessage = $"{timestamp} - Unique users: {uniqueUsers.Count}";

            File.AppendAllText(logFilePath, logMessage + Environment.NewLine);
        }
    }
}