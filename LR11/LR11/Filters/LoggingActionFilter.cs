using Microsoft.AspNetCore.Mvc.Filters;

namespace LR11.Filters
{
    public class LoggingActionFilter : IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext context)
        {
            string controllerName = context.RouteData.Values["controller"].ToString();
            string actionName = context.RouteData.Values["action"].ToString();
            string logMessage = $"[{DateTime.Now}] Controller: {controllerName}, Action: {actionName}";

            // запис у файл
            string filePath = @"D:\Logs\ActionLogging.txt";
            using (StreamWriter writer = new StreamWriter(filePath, true))
            {
                writer.WriteLine(logMessage);
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // виконується після виконання дії контролера
        }
    }
}
